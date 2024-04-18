
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.artículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarArtículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarArtículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verListadoDeArtículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorIDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNombreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorIDToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNombreToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl1,
            this.tsslFecha});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(850, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl1
            // 
            this.tssl1.Name = "tssl1";
            this.tssl1.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslFecha
            // 
            this.tsslFecha.Image = global::program.Properties.Resources.clock_icon_252111;
            this.tsslFecha.Name = "tsslFecha";
            this.tsslFecha.Size = new System.Drawing.Size(16, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artículosToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.categoríasToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // artículosToolStripMenuItem
            // 
            this.artículosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarArtículoToolStripMenuItem,
            this.buscarArtículoToolStripMenuItem,
            this.verListadoDeArtículosToolStripMenuItem});
            this.artículosToolStripMenuItem.Name = "artículosToolStripMenuItem";
            this.artículosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.artículosToolStripMenuItem.Text = "&Artículos";
            // 
            // agregarArtículoToolStripMenuItem
            // 
            this.agregarArtículoToolStripMenuItem.Image = global::program.Properties.Resources.plus_file_icon_252047;
            this.agregarArtículoToolStripMenuItem.Name = "agregarArtículoToolStripMenuItem";
            this.agregarArtículoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.agregarArtículoToolStripMenuItem.Text = "Agregar artículo";
            this.agregarArtículoToolStripMenuItem.Click += new System.EventHandler(this.agregarArtículoToolStripMenuItem_Click);
            // 
            // buscarArtículoToolStripMenuItem
            // 
            this.buscarArtículoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPorIDToolStripMenuItem,
            this.buscarPorNombreToolStripMenuItem,
            this.buscarPorMarcaToolStripMenuItem,
            this.buscarPorCategoríaToolStripMenuItem});
            this.buscarArtículoToolStripMenuItem.Image = global::program.Properties.Resources.search_data_magnifier_folder_icon_252030;
            this.buscarArtículoToolStripMenuItem.Name = "buscarArtículoToolStripMenuItem";
            this.buscarArtículoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.buscarArtículoToolStripMenuItem.Text = "Buscar artículo";
            // 
            // buscarPorIDToolStripMenuItem
            // 
            this.buscarPorIDToolStripMenuItem.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorIDToolStripMenuItem.Name = "buscarPorIDToolStripMenuItem";
            this.buscarPorIDToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.buscarPorIDToolStripMenuItem.Text = "Buscar por ID";
            this.buscarPorIDToolStripMenuItem.Click += new System.EventHandler(this.buscarPorIDToolStripMenuItem_Click);
            // 
            // buscarPorNombreToolStripMenuItem
            // 
            this.buscarPorNombreToolStripMenuItem.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorNombreToolStripMenuItem.Name = "buscarPorNombreToolStripMenuItem";
            this.buscarPorNombreToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.buscarPorNombreToolStripMenuItem.Text = "Buscar por nombre";
            this.buscarPorNombreToolStripMenuItem.Click += new System.EventHandler(this.buscarPorNombreToolStripMenuItem_Click);
            // 
            // buscarPorMarcaToolStripMenuItem
            // 
            this.buscarPorMarcaToolStripMenuItem.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorMarcaToolStripMenuItem.Name = "buscarPorMarcaToolStripMenuItem";
            this.buscarPorMarcaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.buscarPorMarcaToolStripMenuItem.Text = "Buscar por marca";
            this.buscarPorMarcaToolStripMenuItem.Click += new System.EventHandler(this.buscarPorMarcaToolStripMenuItem_Click);
            // 
            // buscarPorCategoríaToolStripMenuItem
            // 
            this.buscarPorCategoríaToolStripMenuItem.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorCategoríaToolStripMenuItem.Name = "buscarPorCategoríaToolStripMenuItem";
            this.buscarPorCategoríaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.buscarPorCategoríaToolStripMenuItem.Text = "Buscar por categoría";
            this.buscarPorCategoríaToolStripMenuItem.Click += new System.EventHandler(this.buscarPorCategoríaToolStripMenuItem_Click);
            // 
            // verListadoDeArtículosToolStripMenuItem
            // 
            this.verListadoDeArtículosToolStripMenuItem.Image = global::program.Properties.Resources.text_clipboard_icon_252043;
            this.verListadoDeArtículosToolStripMenuItem.Name = "verListadoDeArtículosToolStripMenuItem";
            this.verListadoDeArtículosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.verListadoDeArtículosToolStripMenuItem.Text = "Ver listado de artículos";
            this.verListadoDeArtículosToolStripMenuItem.Click += new System.EventHandler(this.verListadoDeArtículosToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarMarcaToolStripMenuItem,
            this.buscarMarcaToolStripMenuItem});
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.marcasToolStripMenuItem.Text = "&Marcas";
            // 
            // agregarMarcaToolStripMenuItem
            // 
            this.agregarMarcaToolStripMenuItem.Image = global::program.Properties.Resources.plus_file_icon_2520471;
            this.agregarMarcaToolStripMenuItem.Name = "agregarMarcaToolStripMenuItem";
            this.agregarMarcaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarMarcaToolStripMenuItem.Text = "Agregar marca";
            this.agregarMarcaToolStripMenuItem.Click += new System.EventHandler(this.agregarMarcaToolStripMenuItem_Click);
            // 
            // buscarMarcaToolStripMenuItem
            // 
            this.buscarMarcaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPorIDToolStripMenuItem1,
            this.buscarPorNombreToolStripMenuItem1});
            this.buscarMarcaToolStripMenuItem.Image = global::program.Properties.Resources.search_data_magnifier_folder_icon_252030;
            this.buscarMarcaToolStripMenuItem.Name = "buscarMarcaToolStripMenuItem";
            this.buscarMarcaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buscarMarcaToolStripMenuItem.Text = "Buscar marca";
            // 
            // buscarPorIDToolStripMenuItem1
            // 
            this.buscarPorIDToolStripMenuItem1.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorIDToolStripMenuItem1.Name = "buscarPorIDToolStripMenuItem1";
            this.buscarPorIDToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.buscarPorIDToolStripMenuItem1.Text = "Buscar por ID";
            this.buscarPorIDToolStripMenuItem1.Click += new System.EventHandler(this.buscarPorIDToolStripMenuItem1_Click);
            // 
            // buscarPorNombreToolStripMenuItem1
            // 
            this.buscarPorNombreToolStripMenuItem1.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorNombreToolStripMenuItem1.Name = "buscarPorNombreToolStripMenuItem1";
            this.buscarPorNombreToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.buscarPorNombreToolStripMenuItem1.Text = "Buscar por nombre";
            this.buscarPorNombreToolStripMenuItem1.Click += new System.EventHandler(this.buscarPorNombreToolStripMenuItem1_Click);
            // 
            // categoríasToolStripMenuItem
            // 
            this.categoríasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarCategoríaToolStripMenuItem,
            this.buscarCategoríaToolStripMenuItem});
            this.categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            this.categoríasToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoríasToolStripMenuItem.Text = "&Categorías";
            // 
            // agregarCategoríaToolStripMenuItem
            // 
            this.agregarCategoríaToolStripMenuItem.Image = global::program.Properties.Resources.plus_file_icon_2520471;
            this.agregarCategoríaToolStripMenuItem.Name = "agregarCategoríaToolStripMenuItem";
            this.agregarCategoríaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarCategoríaToolStripMenuItem.Text = "Agregar categoría";
            this.agregarCategoríaToolStripMenuItem.Click += new System.EventHandler(this.agregarCategoríaToolStripMenuItem_Click);
            // 
            // buscarCategoríaToolStripMenuItem
            // 
            this.buscarCategoríaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPorIDToolStripMenuItem2,
            this.buscarPorNombreToolStripMenuItem2});
            this.buscarCategoríaToolStripMenuItem.Image = global::program.Properties.Resources.search_data_magnifier_folder_icon_252030;
            this.buscarCategoríaToolStripMenuItem.Name = "buscarCategoríaToolStripMenuItem";
            this.buscarCategoríaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buscarCategoríaToolStripMenuItem.Text = "Buscar categoría";
            // 
            // buscarPorIDToolStripMenuItem2
            // 
            this.buscarPorIDToolStripMenuItem2.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorIDToolStripMenuItem2.Name = "buscarPorIDToolStripMenuItem2";
            this.buscarPorIDToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.buscarPorIDToolStripMenuItem2.Text = "Buscar por ID";
            this.buscarPorIDToolStripMenuItem2.Click += new System.EventHandler(this.buscarPorIDToolStripMenuItem2_Click);
            // 
            // buscarPorNombreToolStripMenuItem2
            // 
            this.buscarPorNombreToolStripMenuItem2.Image = global::program.Properties.Resources.search_file_icon_252034;
            this.buscarPorNombreToolStripMenuItem2.Name = "buscarPorNombreToolStripMenuItem2";
            this.buscarPorNombreToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.buscarPorNombreToolStripMenuItem2.Text = "Buscar por nombre";
            this.buscarPorNombreToolStripMenuItem2.Click += new System.EventHandler(this.buscarPorNombreToolStripMenuItem2_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About&";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = global::program.Properties.Resources.Cool_Text___ABM_PRODUCTOS_456120502568613;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(850, 520);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIAPP";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem artículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarArtículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarArtículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorMarcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorCategoríaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verListadoDeArtículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarMarcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarMarcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoríasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarCategoríaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarCategoríaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel tsslFecha;
        private System.Windows.Forms.ToolStripMenuItem buscarPorIDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNombreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarPorIDToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNombreToolStripMenuItem2;
    }
}

