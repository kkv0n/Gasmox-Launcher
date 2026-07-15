namespace GLauncher
{
    partial class GLauncher_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLauncher_main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.versionGif = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.advanced_b = new System.Windows.Forms.Button();
            this.graphics_b = new System.Windows.Forms.Button();
            this.host_b = new System.Windows.Forms.Button();
            this.play_b = new System.Windows.Forms.Button();
            this.help_b = new System.Windows.Forms.Button();
            this.username_tbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.custom_b = new System.Windows.Forms.Button();
            this.octr_b = new System.Windows.Forms.Button();
            this.gasmox_b = new System.Windows.Forms.Button();
            this.rom_tbox = new System.Windows.Forms.TextBox();
            this.sel_rom_b = new System.Windows.Forms.Button();
            this.patch_b = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionGif)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.versionGif);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(2, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1075, 577);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // versionGif
            // 
            this.versionGif.BackColor = System.Drawing.Color.Transparent;
            this.versionGif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.versionGif.Location = new System.Drawing.Point(766, 117);
            this.versionGif.Name = "versionGif";
            this.versionGif.Size = new System.Drawing.Size(283, 101);
            this.versionGif.TabIndex = 4;
            this.versionGif.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.advanced_b);
            this.panel2.Controls.Add(this.graphics_b);
            this.panel2.Controls.Add(this.host_b);
            this.panel2.Controls.Add(this.play_b);
            this.panel2.Controls.Add(this.help_b);
            this.panel2.Controls.Add(this.username_tbox);
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(-1, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 129);
            this.panel2.TabIndex = 1;
            // 
            // advanced_b
            // 
            this.advanced_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.advanced_b.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.advanced_b.FlatAppearance.BorderSize = 0;
            this.advanced_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.advanced_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advanced_b.Location = new System.Drawing.Point(1012, 64);
            this.advanced_b.Name = "advanced_b";
            this.advanced_b.Size = new System.Drawing.Size(44, 48);
            this.advanced_b.TabIndex = 4;
            this.advanced_b.UseVisualStyleBackColor = true;
            this.advanced_b.Click += new System.EventHandler(this.OPEN_ADVANCED);
            // 
            // graphics_b
            // 
            this.graphics_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.graphics_b.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.graphics_b.FlatAppearance.BorderSize = 0;
            this.graphics_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.graphics_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graphics_b.Location = new System.Drawing.Point(1012, 10);
            this.graphics_b.Name = "graphics_b";
            this.graphics_b.Size = new System.Drawing.Size(44, 48);
            this.graphics_b.TabIndex = 1;
            this.graphics_b.UseVisualStyleBackColor = true;
            this.graphics_b.Click += new System.EventHandler(this.OPEN_GRAPHICS_CONFIG);
            // 
            // host_b
            // 
            this.host_b.BackColor = System.Drawing.Color.Transparent;
            this.host_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.host_b.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.host_b.FlatAppearance.BorderSize = 0;
            this.host_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.host_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.host_b.ForeColor = System.Drawing.Color.Transparent;
            this.host_b.Location = new System.Drawing.Point(679, 29);
            this.host_b.Name = "host_b";
            this.host_b.Size = new System.Drawing.Size(55, 76);
            this.host_b.TabIndex = 12;
            this.host_b.UseVisualStyleBackColor = false;
            this.host_b.Click += new System.EventHandler(this.OPEN_HOST_SETTINGS);
            // 
            // play_b
            // 
            this.play_b.BackColor = System.Drawing.Color.Transparent;
            this.play_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play_b.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.play_b.FlatAppearance.BorderSize = 0;
            this.play_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.play_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_b.ForeColor = System.Drawing.Color.Transparent;
            this.play_b.Location = new System.Drawing.Point(460, 29);
            this.play_b.Name = "play_b";
            this.play_b.Size = new System.Drawing.Size(213, 76);
            this.play_b.TabIndex = 0;
            this.play_b.UseVisualStyleBackColor = false;
            this.play_b.Click += new System.EventHandler(this.PLAY_GAME);
            this.play_b.MouseEnter += new System.EventHandler(this.play_b_MouseEnter);
            this.play_b.MouseLeave += new System.EventHandler(this.play_b_MouseLeave);
            // 
            // help_b
            // 
            this.help_b.Cursor = System.Windows.Forms.Cursors.Help;
            this.help_b.FlatAppearance.BorderSize = 0;
            this.help_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help_b.Location = new System.Drawing.Point(407, 42);
            this.help_b.Name = "help_b";
            this.help_b.Size = new System.Drawing.Size(45, 48);
            this.help_b.TabIndex = 15;
            this.help_b.UseVisualStyleBackColor = true;
            this.help_b.Click += new System.EventHandler(this.OPEN_HELP);
            // 
            // username_tbox
            // 
            this.username_tbox.BackColor = System.Drawing.SystemColors.Control;
            this.username_tbox.Location = new System.Drawing.Point(97, 71);
            this.username_tbox.MaxLength = 11;
            this.username_tbox.Name = "username_tbox";
            this.username_tbox.Size = new System.Drawing.Size(84, 20);
            this.username_tbox.TabIndex = 2;
            this.username_tbox.TextChanged += new System.EventHandler(this.WRITE_USERNAME);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.custom_b);
            this.panel1.Controls.Add(this.octr_b);
            this.panel1.Controls.Add(this.gasmox_b);
            this.panel1.Controls.Add(this.rom_tbox);
            this.panel1.Controls.Add(this.sel_rom_b);
            this.panel1.Controls.Add(this.patch_b);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 453);
            this.panel1.TabIndex = 0;
            // 
            // custom_b
            // 
            this.custom_b.BackColor = System.Drawing.Color.Transparent;
            this.custom_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custom_b.ForeColor = System.Drawing.Color.White;
            this.custom_b.Location = new System.Drawing.Point(68, 8);
            this.custom_b.Name = "custom_b";
            this.custom_b.Size = new System.Drawing.Size(75, 23);
            this.custom_b.TabIndex = 9;
            this.custom_b.Text = "CUSTOM";
            this.custom_b.UseVisualStyleBackColor = false;
            this.custom_b.Click += new System.EventHandler(this.SET_CUSTOM);
            // 
            // octr_b
            // 
            this.octr_b.BackColor = System.Drawing.Color.Transparent;
            this.octr_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.octr_b.ForeColor = System.Drawing.Color.White;
            this.octr_b.Location = new System.Drawing.Point(142, 8);
            this.octr_b.Name = "octr_b";
            this.octr_b.Size = new System.Drawing.Size(70, 23);
            this.octr_b.TabIndex = 8;
            this.octr_b.Text = "OFFICIAL";
            this.octr_b.UseVisualStyleBackColor = false;
            this.octr_b.Click += new System.EventHandler(this.SET_OCTR);
            // 
            // gasmox_b
            // 
            this.gasmox_b.BackColor = System.Drawing.Color.Transparent;
            this.gasmox_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gasmox_b.ForeColor = System.Drawing.Color.White;
            this.gasmox_b.Location = new System.Drawing.Point(0, 8);
            this.gasmox_b.Name = "gasmox_b";
            this.gasmox_b.Size = new System.Drawing.Size(71, 23);
            this.gasmox_b.TabIndex = 7;
            this.gasmox_b.Text = "GASMOX";
            this.gasmox_b.UseVisualStyleBackColor = false;
            this.gasmox_b.Click += new System.EventHandler(this.SET_GASMOXIAN);
            // 
            // rom_tbox
            // 
            this.rom_tbox.Location = new System.Drawing.Point(14, 147);
            this.rom_tbox.Name = "rom_tbox";
            this.rom_tbox.ReadOnly = true;
            this.rom_tbox.Size = new System.Drawing.Size(156, 20);
            this.rom_tbox.TabIndex = 1;
            // 
            // sel_rom_b
            // 
            this.sel_rom_b.BackColor = System.Drawing.Color.Transparent;
            this.sel_rom_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sel_rom_b.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.sel_rom_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.sel_rom_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sel_rom_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_rom_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sel_rom_b.ForeColor = System.Drawing.Color.White;
            this.sel_rom_b.Location = new System.Drawing.Point(176, 145);
            this.sel_rom_b.Name = "sel_rom_b";
            this.sel_rom_b.Size = new System.Drawing.Size(30, 23);
            this.sel_rom_b.TabIndex = 2;
            this.sel_rom_b.Text = "...";
            this.sel_rom_b.UseVisualStyleBackColor = false;
            this.sel_rom_b.Click += new System.EventHandler(this.SELECT_ROM);
            // 
            // patch_b
            // 
            this.patch_b.BackColor = System.Drawing.Color.Transparent;
            this.patch_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patch_b.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.patch_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.patch_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.patch_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patch_b.ForeColor = System.Drawing.Color.Transparent;
            this.patch_b.Location = new System.Drawing.Point(50, 179);
            this.patch_b.Name = "patch_b";
            this.patch_b.Size = new System.Drawing.Size(120, 49);
            this.patch_b.TabIndex = 6;
            this.patch_b.UseVisualStyleBackColor = false;
            this.patch_b.Click += new System.EventHandler(this.PATCH_GAME);
            // 
            // GLauncher_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 564);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GLauncher_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gasmoxian Launcher";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.versionGif)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button advanced_b;
        private System.Windows.Forms.Button graphics_b;
        private System.Windows.Forms.Button host_b;
        private System.Windows.Forms.Button play_b;
        private System.Windows.Forms.Button help_b;
        private System.Windows.Forms.TextBox username_tbox;
        private System.Windows.Forms.TextBox rom_tbox;
        private System.Windows.Forms.Button sel_rom_b;
        private System.Windows.Forms.Button patch_b;
        private System.Windows.Forms.Button custom_b;
        private System.Windows.Forms.Button octr_b;
        private System.Windows.Forms.Button gasmox_b;
        private System.Windows.Forms.PictureBox versionGif;
    }
}

