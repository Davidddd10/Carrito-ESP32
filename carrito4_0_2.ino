#include <Wire.h> 
#include <LiquidCrystal_I2C.h>
#include <WiFi.h>

LiquidCrystal_I2C lcd(0x27, 16, 2); 

// Declaración del Servidor TCP en el puerto 8080
WiFiServer server(8080);
WiFiClient client;

// Pines Motores (Puente H)
int IN1 = 26; int IN2 = 27; int IN3 = 33; int IN4 = 25;

const int pinSensor = 18; 
volatile long contadorPulsos = 0; 
volatile unsigned long ultimoTiempoPulso = 0; 

// --- MATEMÁTICAS DE ODOMETRÍA ---
// Factor calibrado según tus pruebas físicas (43 pulsos = 50 cm)
const float CM_POR_PULSO = 1.16; 

// --- AJUSTES DE INERCIA Y TRACCIÓN ---
int potenciaIzq = 200;  // Potencia para avanzar
int potenciaDer = 200;  // Potencia para avanzar
int velocidadGiro = 140; // Velocidad reducida para que los giros no derrapen
const float COMPENSACION_INERCIA = 1.0; 

bool enModoAuto = false;
String tramaRecibida = "";

struct Segmento {
  int distancia;
  int angulo;
};
Segmento ruta[100]; 
int totalSegmentos = 0;

void registrarEvento(const String& mensaje) {
  Serial.println(mensaje);
  if (client && client.connected()) {
    client.println(mensaje);
  }
}

// Filtro rápido a 1ms
void IRAM_ATTR contarPulso() {
  unsigned long tiempoActual = millis();
  if (tiempoActual - ultimoTiempoPulso > 1) { 
    contadorPulsos++;
    ultimoTiempoPulso = tiempoActual;
  }
}

void setup() {
  Serial.begin(115200);
  pinMode(IN1, OUTPUT); pinMode(IN2, OUTPUT);
  pinMode(IN3, OUTPUT); pinMode(IN4, OUTPUT);
  
  pinMode(pinSensor, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(pinSensor), contarPulso, FALLING);

  lcd.init();
  lcd.backlight();
  lcd.setCursor(0, 0);
  lcd.print("ESP32 CAR READY");
  
  stopCar();
  
  WiFi.softAP("ESP32_CAR_WIFI");
  server.begin();
  registrarEvento("BOOT: ESP32 listo");
  registrarEvento("WIFI: AP ESP32_CAR_WIFI activa en 192.168.4.1:8080");
  
  lcd.setCursor(0, 1);
  lcd.print("IP: 192.168.4.1");
}

void loop() { 
  if (!client || !client.connected()) {
    WiFiClient nuevoCliente = server.available();
    if (nuevoCliente) {
      client = nuevoCliente;
      registrarEvento("WIFI: Cliente conectado");
    }
  }

  if (client && client.connected()) {
    while (client.available()) {
      char c = client.read();
      if (c == '\r' || c == '\n') {
        continue;
      }
      
      if (c == 'S') { 
        stopCar();
        enModoAuto = false;
        tramaRecibida = "";
        lcd.clear();
        lcd.print("STOPPED");
        registrarEvento("CTRL: Parada de emergencia recibida");
      } else {
        tramaRecibida += c;
        if (tramaRecibida.endsWith("END")) {
          registrarEvento("RX: Trama recibida -> " + tramaRecibida);
          decodificarRuta(tramaRecibida);
          tramaRecibida = ""; 
          ejecutarRutaAutonoma();
        }
      }
    }
  }
}

void decodificarRuta(String trama) {
  totalSegmentos = 0;
  int inicioPunto = trama.indexOf(';');
  while (inicioPunto != -1 && totalSegmentos < 100) {
    int finPunto = trama.indexOf(';', inicioPunto + 1);
    if (finPunto == -1) break;
    String fragmento = trama.substring(inicioPunto + 1, finPunto);
    if (fragmento.startsWith("D:")) {
      int comaIndex = fragmento.indexOf(',');
      ruta[totalSegmentos].distancia = fragmento.substring(2, comaIndex).toInt();
      ruta[totalSegmentos].angulo = fragmento.substring(comaIndex + 3).toInt();
      registrarEvento(
        "PLAN: Segmento " + String(totalSegmentos + 1) +
        " -> giro=" + String(ruta[totalSegmentos].angulo) +
        " deg, distancia=" + String(ruta[totalSegmentos].distancia) + " cm");
      totalSegmentos++;
    }
    inicioPunto = finPunto;
  }
  registrarEvento("PLAN: Total de segmentos decodificados = " + String(totalSegmentos));
}

void ejecutarRutaAutonoma() {
  enModoAuto = true;
  registrarEvento("AUTO: Inicio de ruta autonoma");

  for (int i = 0; i < totalSegmentos; i++) {
    if (!enModoAuto) break;

    registrarEvento(
      "AUTO: Segmento " + String(i + 1) +
      " -> giro=" + String(ruta[i].angulo) +
      " deg, avance=" + String(ruta[i].distancia) + " cm");

    if (abs(ruta[i].angulo) >= 5) {
      ejecutarGiro(ruta[i].angulo);
    }

    if (ruta[i].distancia > 0) {
      contadorPulsos = 0; 
      float distRecorrida = 0;
      unsigned long ultimoReporte = 0;
      
      // Aplicar compensación de inercia inteligentemente
      float distanciaObjetivo = ruta[i].distancia; 
      if (distanciaObjetivo > (COMPENSACION_INERCIA * 2)) {
          distanciaObjetivo -= COMPENSACION_INERCIA; // Frenado anticipado
      }

      registrarEvento(
        "AUTO: Segmento " + String(i + 1) +
        " inicia avance recto. Objetivo real = " + String(distanciaObjetivo, 1) + " cm");

      forward();

      while (distRecorrida < distanciaObjetivo) {
        if (client && client.connected() && client.available()) {
          char cCmd = client.read();
          if (cCmd == 'S') {
            enModoAuto = false;
            registrarEvento("CTRL: Parada recibida durante avance");
            break;
          }
        }
        
        distRecorrida = (float)contadorPulsos * CM_POR_PULSO;

        if (millis() - ultimoReporte >= 250) {
          ultimoReporte = millis();
          registrarEvento(
            "AUTO: Segmento " + String(i + 1) +
            " progreso -> pulsos=" + String(contadorPulsos) +
            ", recorrido=" + String(distRecorrida, 1) +
            " cm");
        }
        
        lcd.setCursor(0, 0);
        lcd.print("Seg: "); lcd.print(i+1);
        lcd.setCursor(0, 1);
        lcd.print("Faltan: "); lcd.print(distanciaObjetivo - distRecorrida, 1); lcd.print("cm   ");
        
        delay(5); 
      }
      stopCar();
      registrarEvento(
        "AUTO: Segmento " + String(i + 1) +
        " finalizado -> recorrido (math)=" + String(distRecorrida, 1) +
        " cm, pulsos=" + String(contadorPulsos));
        
      delay(300); // Pausa para que el carro se estabilice tras el deslizamiento
    }
  }
  lcd.clear();
  lcd.print("RUTA FINALIZADA");
  registrarEvento("AUTO: Ruta finalizada");
}

void ejecutarGiro(int grados) {
  if (abs(grados) < 5) return; 

  int gradosFisicos = abs(grados);

  // Sintonía fina: Ajuste de 7 grados
  if (grados < 0) {
    // Giro a la izquierda: le SUMAMOS 7 grados
    gradosFisicos += 7;
  } else {
    // Giro a la derecha: le RESTAMOS 7 grados
    gradosFisicos -= 7;
  }

  if (gradosFisicos < 0) gradosFisicos = 0;

  // Calculamos el tiempo con la escala corregida
  int tiempoGiro = (gradosFisicos * 4) + 20; 

  registrarEvento(
    "AUTO: Giro Original " + String(grados) + 
    " deg -> Fisico Ajustado " + String(gradosFisicos) +
    " deg -> tiempo=" + String(tiempoGiro) +
    " ms, direccion=" + String(grados > 0 ? "derecha" : "izquierda"));
  
  if (grados > 0) right();
  else left();
  
  delay(tiempoGiro);
  stopCar();
  registrarEvento("AUTO: Giro completado");
  delay(200); 
}

void forward(){ 
  analogWrite(IN1, potenciaIzq); 
  analogWrite(IN2, 0); 
  analogWrite(IN3, potenciaDer); 
  analogWrite(IN4, 0); 
}
void back(){ 
  analogWrite(IN1, 0); 
  analogWrite(IN2, potenciaIzq); 
  analogWrite(IN3, 0); 
  analogWrite(IN4, potenciaDer); 
}
void left(){ 
  analogWrite(IN1, 0); 
  analogWrite(IN2, velocidadGiro);  
  analogWrite(IN3, velocidadGiro);  
  analogWrite(IN4, 0); 
}
void right(){ 
  analogWrite(IN1, velocidadGiro);  
  analogWrite(IN2, 0); 
  analogWrite(IN3, 0); 
  analogWrite(IN4, velocidadGiro);  
}
void stopCar(){ 
  analogWrite(IN1, 0); 
  analogWrite(IN2, 0); 
  analogWrite(IN3, 0); 
  analogWrite(IN4, 0); 
}