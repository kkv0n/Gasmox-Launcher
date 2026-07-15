namespace GLauncher.code.forms
{
    partial class GLauncher_host
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.l_1 = new System.Windows.Forms.Label();
            this.hback_b = new System.Windows.Forms.Button();
            this.ip_l = new System.Windows.Forms.Label();
            this.port_l = new System.Windows.Forms.Label();
            this.sv_b = new System.Windows.Forms.Button();
            this.port_tbox = new System.Windows.Forms.TextBox();
            this.ip_tbox = new System.Windows.Forms.TextBox();
            this.radmin_b = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.l_1);
            this.groupBox1.Controls.Add(this.hback_b);
            this.groupBox1.Controls.Add(this.ip_l);
            this.groupBox1.Controls.Add(this.port_l);
            this.groupBox1.Controls.Add(this.sv_b);
            this.groupBox1.Controls.Add(this.port_tbox);
            this.groupBox1.Controls.Add(this.ip_tbox);
            this.groupBox1.Controls.Add(this.radmin_b);
            this.groupBox1.Location = new System.Drawing.Point(2, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1075, 577);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(513, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "2.";
            // 
            // l_1
            // 
            this.l_1.AutoSize = true;
            this.l_1.BackColor = System.Drawing.Color.Gray;
            this.l_1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_1.ForeColor = System.Drawing.Color.White;
            this.l_1.Location = new System.Drawing.Point(513, 42);
            this.l_1.Name = "l_1";
            this.l_1.Size = new System.Drawing.Size(31, 27);
            this.l_1.TabIndex = 7;
            this.l_1.Text = "1.";
            // 
            // hback_b
            // 
            this.hback_b.BackColor = System.Drawing.Color.Transparent;
            this.hback_b.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.hback_b.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.hback_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.hback_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hback_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hback_b.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hback_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.hback_b.Location = new System.Drawing.Point(10, 500);
            this.hback_b.Name = "hback_b";
            this.hback_b.Size = new System.Drawing.Size(181, 60);
            this.hback_b.TabIndex = 6;
            this.hback_b.Text = "<-------";
            this.hback_b.UseVisualStyleBackColor = false;
            this.hback_b.Click += new System.EventHandler(this.CLOSE_THIS);
            // 
            // ip_l
            // 
            this.ip_l.AutoSize = true;
            this.ip_l.BackColor = System.Drawing.Color.Gray;
            this.ip_l.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_l.ForeColor = System.Drawing.Color.White;
            this.ip_l.Location = new System.Drawing.Point(464, 314);
            this.ip_l.Name = "ip_l";
            this.ip_l.Size = new System.Drawing.Size(126, 27);
            this.ip_l.TabIndex = 5;
            this.ip_l.Text = "SERVER IP";
            // 
            // port_l
            // 
            this.port_l.AutoSize = true;
            this.port_l.BackColor = System.Drawing.Color.Gray;
            this.port_l.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.port_l.ForeColor = System.Drawing.Color.White;
            this.port_l.Location = new System.Drawing.Point(447, 435);
            this.port_l.Name = "port_l";
            this.port_l.Size = new System.Drawing.Size(164, 27);
            this.port_l.TabIndex = 4;
            this.port_l.Text = "SERVER PORT";
            // 
            // sv_b
            // 
            this.sv_b.BackColor = System.Drawing.Color.Transparent;
            this.sv_b.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.sv_b.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.sv_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.sv_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.sv_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sv_b.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sv_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.sv_b.Location = new System.Drawing.Point(436, 218);
            this.sv_b.Name = "sv_b";
            this.sv_b.Size = new System.Drawing.Size(181, 60);
            this.sv_b.TabIndex = 3;
            this.sv_b.Text = "SERVER";
            this.sv_b.UseVisualStyleBackColor = false;
            this.sv_b.Click += new System.EventHandler(this.OPEN_SERVER_FILE);
            // 
            // port_tbox
            // 
            this.port_tbox.Location = new System.Drawing.Point(391, 465);
            this.port_tbox.Name = "port_tbox";
            this.port_tbox.Size = new System.Drawing.Size(276, 20);
            this.port_tbox.TabIndex = 2;
            this.port_tbox.TextChanged += new System.EventHandler(this.WRITE_ANY_TEXT);
            // 
            // ip_tbox
            // 
            this.ip_tbox.Location = new System.Drawing.Point(391, 344);
            this.ip_tbox.Name = "ip_tbox";
            this.ip_tbox.Size = new System.Drawing.Size(276, 20);
            this.ip_tbox.TabIndex = 1;
            this.ip_tbox.TextChanged += new System.EventHandler(this.WRITE_ANY_TEXT);
            // 
            // radmin_b
            // 
            this.radmin_b.BackColor = System.Drawing.Color.Transparent;
            this.radmin_b.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.radmin_b.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radmin_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.radmin_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.radmin_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radmin_b.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radmin_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.radmin_b.Location = new System.Drawing.Point(436, 74);
            this.radmin_b.Name = "radmin_b";
            this.radmin_b.Size = new System.Drawing.Size(181, 60);
            this.radmin_b.TabIndex = 0;
            this.radmin_b.Text = "RADMIN VPN";
            this.radmin_b.UseVisualStyleBackColor = false;
            this.radmin_b.Click += new System.EventHandler(this.OPEN_RADMIN);
            // 
            // GLauncher_host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 564);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GLauncher_host";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOST SETTINGS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button sv_b;
        private System.Windows.Forms.TextBox port_tbox;
        private System.Windows.Forms.TextBox ip_tbox;
        private System.Windows.Forms.Button radmin_b;
        private System.Windows.Forms.Label ip_l;
        private System.Windows.Forms.Label port_l;
        private System.Windows.Forms.Button hback_b;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_1;
    }
}