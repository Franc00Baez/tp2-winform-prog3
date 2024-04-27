
namespace program
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.SS1 = new System.Windows.Forms.StatusStrip();
            this.tssl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSML1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.MS1 = new System.Windows.Forms.MenuStrip();
            this.artículosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarArtículoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarArtículoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorIDTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNombreTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.verListadoDeArtículosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarMarcaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.verListadoDeMarcasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.categoríasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCategoríaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.verListadoDeCategoríasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SS1.SuspendLayout();
            this.MS1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SS1
            // 
            this.SS1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SS1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl1,
            this.TSML1,
            this.tsslFecha});
            this.SS1.Location = new System.Drawing.Point(0, 498);
            this.SS1.Name = "SS1";
            this.SS1.Size = new System.Drawing.Size(850, 22);
            this.SS1.TabIndex = 0;
            this.SS1.Text = "statusStrip1";
            // 
            // tssl1
            // 
            this.tssl1.Name = "tssl1";
            this.tssl1.Size = new System.Drawing.Size(0, 17);
            // 
            // TSML1
            // 
            this.TSML1.Image = global::program.Properties.Resources.clock_icon_252111;
            this.TSML1.Name = "TSML1";
            this.TSML1.Size = new System.Drawing.Size(98, 17);
            this.TSML1.Text = "Fecha y Hora: ";
            // 
            // tsslFecha
            // 
            this.tsslFecha.Name = "tsslFecha";
            this.tsslFecha.Size = new System.Drawing.Size(0, 17);
            // 
            // MS1
            // 
            this.MS1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.MS1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artículosTSMI,
            this.marcasTSMI,
            this.categoríasTSMI,
            this.aboutTSMI});
            this.MS1.Location = new System.Drawing.Point(0, 0);
            this.MS1.Name = "MS1";
            this.MS1.Size = new System.Drawing.Size(850, 24);
            this.MS1.TabIndex = 1;
            this.MS1.Text = "menuStrip1";
            // 
            // artículosTSMI
            // 
            this.artículosTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarArtículoTSMI,
            this.buscarArtículoTSMI,
            this.verListadoDeArtículosTSMI});
            this.artículosTSMI.Name = "artículosTSMI";
            this.artículosTSMI.Size = new System.Drawing.Size(66, 20);
            this.artículosTSMI.Text = "&Artículos";
            // 
            // agregarArtículoTSMI
            // 
            this.agregarArtículoTSMI.Image = global::program.Properties.Resources.plus_file_icon_252047;
            this.agregarArtículoTSMI.Name = "agregarArtículoTSMI";
            this.agregarArtículoTSMI.Size = new System.Drawing.Size(192, 22);
            this.agregarArtículoTSMI.Text = "Agregar artículo";
            this.agregarArtículoTSMI.Click += new System.EventHandler(this.agregarArtículoToolStripMenuItem_Click);
            // 
            // buscarArtículoTSMI
            // 
            this.buscarArtículoTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPorIDTSMI,
            this.buscarPorNombreTSMI});
            this.buscarArtículoTSMI.Image = global::program.Properties.Resources.search_data_magnifier_folder_icon_252030;
            this.buscarArtículoTSMI.Name = "buscarArtículoTSMI";
            this.buscarArtículoTSMI.Size = new System.Drawing.Size(192, 22);
            this.buscarArtículoTSMI.Text = "Buscar artículo";
            // 
            // buscarPorIDTSMI
            // 
            this.buscarPorIDTSMI.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorIDTSMI.Name = "buscarPorIDTSMI";
            this.buscarPorIDTSMI.Size = new System.Drawing.Size(180, 22);
            this.buscarPorIDTSMI.Text = "Buscar por ID";
            this.buscarPorIDTSMI.Click += new System.EventHandler(this.buscarPorIDToolStripMenuItem_Click);
            // 
            // buscarPorNombreTSMI
            // 
            this.buscarPorNombreTSMI.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorNombreTSMI.Name = "buscarPorNombreTSMI";
            this.buscarPorNombreTSMI.Size = new System.Drawing.Size(180, 22);
            this.buscarPorNombreTSMI.Text = "Buscar por nombre";
            this.buscarPorNombreTSMI.Click += new System.EventHandler(this.buscarPorNombreToolStripMenuItem_Click);
            // 
            // verListadoDeArtículosTSMI
            // 
            this.verListadoDeArtículosTSMI.Image = global::program.Properties.Resources.text_clipboard_icon_252043;
            this.verListadoDeArtículosTSMI.Name = "verListadoDeArtículosTSMI";
            this.verListadoDeArtículosTSMI.Size = new System.Drawing.Size(192, 22);
            this.verListadoDeArtículosTSMI.Text = "Ver listado de artículos";
            this.verListadoDeArtículosTSMI.Click += new System.EventHandler(this.verListadoDeArtículosToolStripMenuItem_Click);
            // 
            // marcasTSMI
            // 
            this.marcasTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarMarcaTSMI,
            this.verListadoDeMarcasTSMI});
            this.marcasTSMI.Name = "marcasTSMI";
            this.marcasTSMI.Size = new System.Drawing.Size(57, 20);
            this.marcasTSMI.Text = "&Marcas";
            // 
            // agregarMarcaTSMI
            // 
            this.agregarMarcaTSMI.Image = global::program.Properties.Resources.plus_file_icon_2520471;
            this.agregarMarcaTSMI.Name = "agregarMarcaTSMI";
            this.agregarMarcaTSMI.Size = new System.Drawing.Size(185, 22);
            this.agregarMarcaTSMI.Text = "Agregar marca";
            this.agregarMarcaTSMI.Click += new System.EventHandler(this.agregarMarcaToolStripMenuItem_Click);
            // 
            // verListadoDeMarcasTSMI
            // 
            this.verListadoDeMarcasTSMI.Image = global::program.Properties.Resources.text_clipboard_icon_252043;
            this.verListadoDeMarcasTSMI.Name = "verListadoDeMarcasTSMI";
            this.verListadoDeMarcasTSMI.Size = new System.Drawing.Size(185, 22);
            this.verListadoDeMarcasTSMI.Text = "Ver listado de marcas";
            this.verListadoDeMarcasTSMI.Click += new System.EventHandler(this.verListadoDeMarcasToolStripMenuItem_Click);
            // 
            // categoríasTSMI
            // 
            this.categoríasTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarCategoríaTSMI,
            this.verListadoDeCategoríasTSMI});
            this.categoríasTSMI.Name = "categoríasTSMI";
            this.categoríasTSMI.Size = new System.Drawing.Size(75, 20);
            this.categoríasTSMI.Text = "&Categorías";
            // 
            // agregarCategoríaTSMI
            // 
            this.agregarCategoríaTSMI.Image = global::program.Properties.Resources.plus_file_icon_2520471;
            this.agregarCategoríaTSMI.Name = "agregarCategoríaTSMI";
            this.agregarCategoríaTSMI.Size = new System.Drawing.Size(201, 22);
            this.agregarCategoríaTSMI.Text = "Agregar categoría";
            this.agregarCategoríaTSMI.Click += new System.EventHandler(this.agregarCategoríaToolStripMenuItem_Click);
            // 
            // verListadoDeCategoríasTSMI
            // 
            this.verListadoDeCategoríasTSMI.Image = global::program.Properties.Resources.text_clipboard_icon_252043;
            this.verListadoDeCategoríasTSMI.Name = "verListadoDeCategoríasTSMI";
            this.verListadoDeCategoríasTSMI.Size = new System.Drawing.Size(201, 22);
            this.verListadoDeCategoríasTSMI.Text = "Ver listado de categorías";
            this.verListadoDeCategoríasTSMI.Click += new System.EventHandler(this.verListadoDeCategoríasToolStripMenuItem_Click);
            // 
            // aboutTSMI
            // 
            this.aboutTSMI.Name = "aboutTSMI";
            this.aboutTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.aboutTSMI.Size = new System.Drawing.Size(52, 20);
            this.aboutTSMI.Tag = "";
            this.aboutTSMI.Text = "About&";
            this.aboutTSMI.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = global::program.Properties.Resources.Cool_Text___ABM_PRODUCTOS_456120502568613;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(850, 520);
            this.Controls.Add(this.SS1);
            this.Controls.Add(this.MS1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MS1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Articulos";
            this.SS1.ResumeLayout(false);
            this.SS1.PerformLayout();
            this.MS1.ResumeLayout(false);
            this.MS1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SS1;
        private System.Windows.Forms.ToolStripStatusLabel tssl1;
        private System.Windows.Forms.MenuStrip MS1;
        private System.Windows.Forms.ToolStripMenuItem artículosTSMI;
        private System.Windows.Forms.ToolStripMenuItem agregarArtículoTSMI;
        private System.Windows.Forms.ToolStripMenuItem buscarArtículoTSMI;
        private System.Windows.Forms.ToolStripMenuItem buscarPorIDTSMI;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNombreTSMI;
        private System.Windows.Forms.ToolStripMenuItem verListadoDeArtículosTSMI;
        private System.Windows.Forms.ToolStripMenuItem marcasTSMI;
        private System.Windows.Forms.ToolStripMenuItem agregarMarcaTSMI;
        private System.Windows.Forms.ToolStripMenuItem categoríasTSMI;
        private System.Windows.Forms.ToolStripMenuItem agregarCategoríaTSMI;
        private System.Windows.Forms.ToolStripMenuItem aboutTSMI;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel tsslFecha;
        private System.Windows.Forms.ToolStripStatusLabel TSML1;
        private System.Windows.Forms.ToolStripMenuItem verListadoDeMarcasTSMI;
        private System.Windows.Forms.ToolStripMenuItem verListadoDeCategoríasTSMI;
    }
}

