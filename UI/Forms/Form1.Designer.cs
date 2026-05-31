namespace RutaCarritoESP32
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            lblPanelTitulo = new Label();
            lblPuertos = new Label();
            picLienzo = new PictureBox();
            cmbPuertos = new ComboBox();
            btnConector = new Button();
            btnLimpiar = new Button();
            btnEnviar = new Button();
            lblDistancia = new Label();
            lblEstado = new Label();
            txtLogDetallado = new TextBox();
            panelHeader = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            panelContenido = new Panel();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLienzo).BeginInit();
            panelHeader.SuspendLayout();
            panelContenido.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.White;
            panelSidebar.Controls.Add(lblPanelTitulo);
            panelSidebar.Controls.Add(lblPuertos);
            panelSidebar.Controls.Add(cmbPuertos);
            panelSidebar.Controls.Add(btnConector);
            panelSidebar.Controls.Add(btnEnviar);
            panelSidebar.Controls.Add(btnLimpiar);
            panelSidebar.Controls.Add(lblDistancia);
            panelSidebar.Controls.Add(lblEstado);
            panelSidebar.Controls.Add(txtLogDetallado);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Padding = new Padding(20);
            panelSidebar.Size = new Size(300, 720);
            panelSidebar.TabIndex = 0;
            // 
            // lblPanelTitulo
            // 
            lblPanelTitulo.AutoSize = true;
            lblPanelTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPanelTitulo.Location = new Point(23, 22);
            lblPanelTitulo.Name = "lblPanelTitulo";
            lblPanelTitulo.Size = new Size(84, 28);
            lblPanelTitulo.TabIndex = 0;
            lblPanelTitulo.Text = "Control";
            // 
            // lblPuertos
            // 
            lblPuertos.AutoSize = true;
            lblPuertos.Location = new Point(23, 82);
            lblPuertos.Name = "lblPuertos";
            lblPuertos.Size = new Size(104, 20);
            lblPuertos.TabIndex = 1;
            lblPuertos.Text = "Puerto COM";
            // 
            // picLienzo
            // 
            picLienzo.Dock = DockStyle.Fill;
            picLienzo.Location = new Point(24, 24);
            picLienzo.Margin = new Padding(12);
            picLienzo.Name = "picLienzo";
            picLienzo.Size = new Size(936, 608);
            picLienzo.TabIndex = 1;
            picLienzo.TabStop = false;
            picLienzo.MouseDown += picLienzo_MouseDown;
            picLienzo.MouseMove += picLienzo_MouseMove;
            picLienzo.MouseUp += picLienzo_MouseUp;
            // 
            // cmbPuertos
            // 
            cmbPuertos.FormattingEnabled = true;
            cmbPuertos.Location = new Point(23, 106);
            cmbPuertos.Name = "cmbPuertos";
            cmbPuertos.Size = new Size(272, 28);
            cmbPuertos.TabIndex = 2;
            // 
            // btnConector
            // 
            btnConector.Location = new Point(23, 158);
            btnConector.Name = "btnConector";
            btnConector.Size = new Size(272, 40);
            btnConector.TabIndex = 3;
            btnConector.Text = "Conectar Bluetooth";
            btnConector.UseVisualStyleBackColor = true;
            btnConector.Click += btnConector_Click;
            // 
            // btnZoomIn (visible)
            // 
            btnZoomIn = new Button();
            btnZoomIn.Location = new Point(23, 320);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(130, 40);
            btnZoomIn.TabIndex = 100;
            btnZoomIn.Text = "Zoom +";
            btnZoomIn.UseVisualStyleBackColor = true;
            btnZoomIn.BackColor = Color.FromArgb(45, 125, 220);
            btnZoomIn.ForeColor = Color.White;
            btnZoomIn.FlatStyle = FlatStyle.Flat;
            btnZoomIn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnZoomIn.Click += btnZoomIn_Click;
            panelSidebar.Controls.Add(btnZoomIn);
            // 
            // btnZoomOut (visible)
            // 
            btnZoomOut = new Button();
            btnZoomOut.Location = new Point(165, 320);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(130, 40);
            btnZoomOut.TabIndex = 101;
            btnZoomOut.Text = "Zoom -";
            btnZoomOut.UseVisualStyleBackColor = true;
            btnZoomOut.BackColor = Color.FromArgb(45, 125, 220);
            btnZoomOut.ForeColor = Color.White;
            btnZoomOut.FlatStyle = FlatStyle.Flat;
            btnZoomOut.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnZoomOut.Click += btnZoomOut_Click;
            panelSidebar.Controls.Add(btnZoomOut);
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(23, 214);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(272, 40);
            btnEnviar.TabIndex = 4;
            btnEnviar.Text = "Enviar Ruta";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(23, 270);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(272, 40);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Location = new Point(23, 340);
            lblDistancia.Name = "lblDistancia";
            lblDistancia.Size = new Size(109, 20);
            lblDistancia.TabIndex = 6;
            lblDistancia.Text = "Distancia: 0 cm";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(23, 374);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(107, 20);
            lblEstado.TabIndex = 7;
            lblEstado.Text = "Estado: Listo para dibujar";
            // 
            // txtLogDetallado
            // 
            txtLogDetallado.BackColor = Color.FromArgb(30, 30, 30);
            txtLogDetallado.ForeColor = Color.FromArgb(0, 240, 120);
            txtLogDetallado.Font = new Font("Consolas", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtLogDetallado.Location = new Point(23, 410);
            txtLogDetallado.Multiline = true;
            txtLogDetallado.Name = "txtLogDetallado";
            txtLogDetallado.ReadOnly = true;
            txtLogDetallado.ScrollBars = ScrollBars.Vertical;
            txtLogDetallado.Size = new Size(272, 280);
            txtLogDetallado.TabIndex = 8;
            txtLogDetallado.Text = "=== TELEMETRIA INICIADA ===";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(300, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(24, 18, 24, 18);
            panelHeader.Size = new Size(984, 88);
            panelHeader.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.FromArgb(95, 95, 95);
            lblSubtitulo.Location = new Point(27, 50);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(406, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Dibuja una ruta con el mouse y envíala al carrito por Bluetooth";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(254, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ruta Carrito ESP32";
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(picLienzo);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(300, 88);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(24);
            panelContenido.Size = new Size(984, 632);
            panelContenido.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 720);
            Controls.Add(panelContenido);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            MinimumSize = new Size(1160, 680);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ruta Carrito ESP32";
            Load += Form1_Load;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLienzo).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContenido.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Label lblPanelTitulo;
        private Label lblPuertos;
        private PictureBox picLienzo;
        private ComboBox cmbPuertos;
        private Button btnConector;
        private Button btnLimpiar;
        private Button btnEnviar;
        private Label lblDistancia;
        private Label lblEstado;
        private TextBox txtLogDetallado;
        private Panel panelHeader;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Panel panelContenido;
        private Button btnZoomIn;
        private Button btnZoomOut;
    }
}
