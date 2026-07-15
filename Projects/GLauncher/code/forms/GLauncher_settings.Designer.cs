namespace GLauncher.code.forms
{
    partial class GLauncher_settings
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
            this.presets_ch = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cpu_l = new System.Windows.Forms.Label();
            this.cpu_menu = new System.Windows.Forms.ComboBox();
            this.turboc_ch = new System.Windows.Forms.CheckBox();
            this.fscreen_ch = new System.Windows.Forms.CheckBox();
            this.music_l = new System.Windows.Forms.Label();
            this.voice_l = new System.Windows.Forms.Label();
            this.fx_l = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lang_l = new System.Windows.Forms.Label();
            this.profile_l2 = new System.Windows.Forms.Label();
            this.profile_l1 = new System.Windows.Forms.Label();
            this.duck_l = new System.Windows.Forms.Label();
            this.sel_server_b = new System.Windows.Forms.Button();
            this.sel_client_b = new System.Windows.Forms.Button();
            this.sel_patch_b = new System.Windows.Forms.Button();
            this.sback_b = new System.Windows.Forms.Button();
            this.lang_menu = new System.Windows.Forms.ComboBox();
            this.fx_bar = new System.Windows.Forms.TrackBar();
            this.voice_bar = new System.Windows.Forms.TrackBar();
            this.music_bar = new System.Windows.Forms.TrackBar();
            this.sel_duck_b = new System.Windows.Forms.Button();
            this.xdelta_tbox = new System.Windows.Forms.TextBox();
            this.duck_tbox = new System.Windows.Forms.TextBox();
            this.server_tbox = new System.Windows.Forms.TextBox();
            this.client_tbox = new System.Windows.Forms.TextBox();
            this.gprofile_menu = new System.Windows.Forms.ComboBox();
            this.ultra_b = new System.Windows.Forms.RadioButton();
            this.high_b = new System.Windows.Forms.RadioButton();
            this.med_b = new System.Windows.Forms.RadioButton();
            this.low_b = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fx_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voice_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.music_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.presets_ch);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cpu_l);
            this.groupBox1.Controls.Add(this.cpu_menu);
            this.groupBox1.Controls.Add(this.turboc_ch);
            this.groupBox1.Controls.Add(this.fscreen_ch);
            this.groupBox1.Controls.Add(this.music_l);
            this.groupBox1.Controls.Add(this.voice_l);
            this.groupBox1.Controls.Add(this.fx_l);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lang_l);
            this.groupBox1.Controls.Add(this.profile_l2);
            this.groupBox1.Controls.Add(this.profile_l1);
            this.groupBox1.Controls.Add(this.duck_l);
            this.groupBox1.Controls.Add(this.sel_server_b);
            this.groupBox1.Controls.Add(this.sel_client_b);
            this.groupBox1.Controls.Add(this.sel_patch_b);
            this.groupBox1.Controls.Add(this.sback_b);
            this.groupBox1.Controls.Add(this.lang_menu);
            this.groupBox1.Controls.Add(this.fx_bar);
            this.groupBox1.Controls.Add(this.voice_bar);
            this.groupBox1.Controls.Add(this.music_bar);
            this.groupBox1.Controls.Add(this.sel_duck_b);
            this.groupBox1.Controls.Add(this.xdelta_tbox);
            this.groupBox1.Controls.Add(this.duck_tbox);
            this.groupBox1.Controls.Add(this.server_tbox);
            this.groupBox1.Controls.Add(this.client_tbox);
            this.groupBox1.Controls.Add(this.gprofile_menu);
            this.groupBox1.Controls.Add(this.ultra_b);
            this.groupBox1.Controls.Add(this.high_b);
            this.groupBox1.Controls.Add(this.med_b);
            this.groupBox1.Controls.Add(this.low_b);
            this.groupBox1.Location = new System.Drawing.Point(2, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1075, 577);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // presets_ch
            // 
            this.presets_ch.AutoSize = true;
            this.presets_ch.Checked = true;
            this.presets_ch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.presets_ch.Location = new System.Drawing.Point(140, 155);
            this.presets_ch.Name = "presets_ch";
            this.presets_ch.Size = new System.Drawing.Size(15, 14);
            this.presets_ch.TabIndex = 39;
            this.presets_ch.UseVisualStyleBackColor = true;
            this.presets_ch.CheckedChanged += new System.EventHandler(this.CHOOSE_GAME_QUALITY);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(965, 258);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(110, 22);
            this.panel4.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(965, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(107, 16);
            this.panel3.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(965, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 57);
            this.panel2.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(965, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 55);
            this.panel1.TabIndex = 35;
            // 
            // cpu_l
            // 
            this.cpu_l.AutoSize = true;
            this.cpu_l.BackColor = System.Drawing.Color.Transparent;
            this.cpu_l.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpu_l.ForeColor = System.Drawing.Color.White;
            this.cpu_l.Location = new System.Drawing.Point(219, 46);
            this.cpu_l.Name = "cpu_l";
            this.cpu_l.Size = new System.Drawing.Size(84, 18);
            this.cpu_l.TabIndex = 34;
            this.cpu_l.Text = "CPU MODE";
            // 
            // cpu_menu
            // 
            this.cpu_menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cpu_menu.FormattingEnabled = true;
            this.cpu_menu.Location = new System.Drawing.Point(219, 67);
            this.cpu_menu.Name = "cpu_menu";
            this.cpu_menu.Size = new System.Drawing.Size(79, 21);
            this.cpu_menu.TabIndex = 33;
            this.cpu_menu.SelectedIndexChanged += new System.EventHandler(this.SET_ANY_PROFILE_MODE);
            // 
            // turboc_ch
            // 
            this.turboc_ch.AutoSize = true;
            this.turboc_ch.BackColor = System.Drawing.Color.Transparent;
            this.turboc_ch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turboc_ch.ForeColor = System.Drawing.Color.Gold;
            this.turboc_ch.Location = new System.Drawing.Point(219, 133);
            this.turboc_ch.Name = "turboc_ch";
            this.turboc_ch.Size = new System.Drawing.Size(15, 14);
            this.turboc_ch.TabIndex = 32;
            this.turboc_ch.UseVisualStyleBackColor = false;
            this.turboc_ch.CheckedChanged += new System.EventHandler(this.TURBO_COUNTER_CHECKED);
            // 
            // fscreen_ch
            // 
            this.fscreen_ch.AutoSize = true;
            this.fscreen_ch.BackColor = System.Drawing.Color.Transparent;
            this.fscreen_ch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fscreen_ch.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.fscreen_ch.Location = new System.Drawing.Point(219, 174);
            this.fscreen_ch.Name = "fscreen_ch";
            this.fscreen_ch.Size = new System.Drawing.Size(15, 14);
            this.fscreen_ch.TabIndex = 31;
            this.fscreen_ch.UseVisualStyleBackColor = false;
            this.fscreen_ch.CheckedChanged += new System.EventHandler(this.FULLSCREEN_CHECKED);
            // 
            // music_l
            // 
            this.music_l.AutoSize = true;
            this.music_l.BackColor = System.Drawing.Color.Transparent;
            this.music_l.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.music_l.ForeColor = System.Drawing.Color.White;
            this.music_l.Location = new System.Drawing.Point(904, 79);
            this.music_l.Name = "music_l";
            this.music_l.Size = new System.Drawing.Size(55, 18);
            this.music_l.TabIndex = 30;
            this.music_l.Text = "MUSIC";
            // 
            // voice_l
            // 
            this.voice_l.AutoSize = true;
            this.voice_l.BackColor = System.Drawing.Color.Transparent;
            this.voice_l.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voice_l.ForeColor = System.Drawing.Color.White;
            this.voice_l.Location = new System.Drawing.Point(906, 158);
            this.voice_l.Name = "voice_l";
            this.voice_l.Size = new System.Drawing.Size(53, 18);
            this.voice_l.TabIndex = 29;
            this.voice_l.Text = "VOICE";
            // 
            // fx_l
            // 
            this.fx_l.AutoSize = true;
            this.fx_l.BackColor = System.Drawing.Color.Transparent;
            this.fx_l.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fx_l.ForeColor = System.Drawing.Color.White;
            this.fx_l.Location = new System.Drawing.Point(917, 239);
            this.fx_l.Name = "fx_l";
            this.fx_l.Size = new System.Drawing.Size(27, 18);
            this.fx_l.TabIndex = 28;
            this.fx_l.Text = "FX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(889, 505);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "SERVER";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(658, 506);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "CLIENT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(402, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "XDELTA PATCH";
            // 
            // lang_l
            // 
            this.lang_l.AutoSize = true;
            this.lang_l.BackColor = System.Drawing.Color.Transparent;
            this.lang_l.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lang_l.ForeColor = System.Drawing.Color.White;
            this.lang_l.Location = new System.Drawing.Point(32, 388);
            this.lang_l.Name = "lang_l";
            this.lang_l.Size = new System.Drawing.Size(90, 18);
            this.lang_l.TabIndex = 24;
            this.lang_l.Text = "LANGUAGE";
            // 
            // profile_l2
            // 
            this.profile_l2.AutoSize = true;
            this.profile_l2.BackColor = System.Drawing.Color.Transparent;
            this.profile_l2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_l2.ForeColor = System.Drawing.Color.White;
            this.profile_l2.Location = new System.Drawing.Point(40, 131);
            this.profile_l2.Name = "profile_l2";
            this.profile_l2.Size = new System.Drawing.Size(70, 18);
            this.profile_l2.TabIndex = 23;
            this.profile_l2.Text = "PROFILE";
            // 
            // profile_l1
            // 
            this.profile_l1.AutoSize = true;
            this.profile_l1.BackColor = System.Drawing.Color.Transparent;
            this.profile_l1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_l1.ForeColor = System.Drawing.Color.White;
            this.profile_l1.Location = new System.Drawing.Point(34, 109);
            this.profile_l1.Name = "profile_l1";
            this.profile_l1.Size = new System.Drawing.Size(83, 18);
            this.profile_l1.TabIndex = 22;
            this.profile_l1.Text = "GRAPHICS";
            // 
            // duck_l
            // 
            this.duck_l.AutoSize = true;
            this.duck_l.BackColor = System.Drawing.Color.Transparent;
            this.duck_l.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duck_l.ForeColor = System.Drawing.Color.White;
            this.duck_l.Location = new System.Drawing.Point(19, 46);
            this.duck_l.Name = "duck_l";
            this.duck_l.Size = new System.Drawing.Size(112, 18);
            this.duck_l.TabIndex = 21;
            this.duck_l.Text = "DUCKSTATION";
            // 
            // sel_server_b
            // 
            this.sel_server_b.BackColor = System.Drawing.Color.Transparent;
            this.sel_server_b.FlatAppearance.BorderColor = System.Drawing.Color.Magenta;
            this.sel_server_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sel_server_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sel_server_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_server_b.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sel_server_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sel_server_b.Location = new System.Drawing.Point(980, 525);
            this.sel_server_b.Name = "sel_server_b";
            this.sel_server_b.Size = new System.Drawing.Size(28, 23);
            this.sel_server_b.TabIndex = 20;
            this.sel_server_b.Text = "...";
            this.sel_server_b.UseVisualStyleBackColor = false;
            this.sel_server_b.Click += new System.EventHandler(this.SEARCH_CUSTOM_FILES);
            // 
            // sel_client_b
            // 
            this.sel_client_b.BackColor = System.Drawing.Color.Transparent;
            this.sel_client_b.FlatAppearance.BorderColor = System.Drawing.Color.Magenta;
            this.sel_client_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sel_client_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sel_client_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_client_b.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sel_client_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sel_client_b.Location = new System.Drawing.Point(745, 525);
            this.sel_client_b.Name = "sel_client_b";
            this.sel_client_b.Size = new System.Drawing.Size(28, 23);
            this.sel_client_b.TabIndex = 19;
            this.sel_client_b.Text = "...";
            this.sel_client_b.UseVisualStyleBackColor = false;
            this.sel_client_b.Click += new System.EventHandler(this.SEARCH_CUSTOM_FILES);
            // 
            // sel_patch_b
            // 
            this.sel_patch_b.BackColor = System.Drawing.Color.Transparent;
            this.sel_patch_b.FlatAppearance.BorderColor = System.Drawing.Color.Magenta;
            this.sel_patch_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sel_patch_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sel_patch_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_patch_b.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sel_patch_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sel_patch_b.Location = new System.Drawing.Point(510, 526);
            this.sel_patch_b.Name = "sel_patch_b";
            this.sel_patch_b.Size = new System.Drawing.Size(28, 23);
            this.sel_patch_b.TabIndex = 18;
            this.sel_patch_b.Text = "...";
            this.sel_patch_b.UseVisualStyleBackColor = false;
            this.sel_patch_b.Click += new System.EventHandler(this.SEARCH_CUSTOM_FILES);
            // 
            // sback_b
            // 
            this.sback_b.BackColor = System.Drawing.Color.Transparent;
            this.sback_b.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.sback_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.sback_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sback_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sback_b.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sback_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sback_b.Location = new System.Drawing.Point(22, 524);
            this.sback_b.Name = "sback_b";
            this.sback_b.Size = new System.Drawing.Size(75, 23);
            this.sback_b.TabIndex = 17;
            this.sback_b.Text = "<--------";
            this.sback_b.UseVisualStyleBackColor = false;
            this.sback_b.Click += new System.EventHandler(this.GO_BACK);
            // 
            // lang_menu
            // 
            this.lang_menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lang_menu.FormattingEnabled = true;
            this.lang_menu.Location = new System.Drawing.Point(22, 409);
            this.lang_menu.Name = "lang_menu";
            this.lang_menu.Size = new System.Drawing.Size(112, 21);
            this.lang_menu.TabIndex = 16;
            this.lang_menu.SelectedIndexChanged += new System.EventHandler(this.SET_ANY_PROFILE_MODE);
            // 
            // fx_bar
            // 
            this.fx_bar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fx_bar.Location = new System.Drawing.Point(965, 226);
            this.fx_bar.Maximum = 255;
            this.fx_bar.Name = "fx_bar";
            this.fx_bar.Size = new System.Drawing.Size(104, 45);
            this.fx_bar.TabIndex = 15;
            this.fx_bar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.fx_bar.Scroll += new System.EventHandler(this.CHANGE_ALL_VOLUME);
            // 
            // voice_bar
            // 
            this.voice_bar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.voice_bar.Location = new System.Drawing.Point(965, 146);
            this.voice_bar.Maximum = 255;
            this.voice_bar.Name = "voice_bar";
            this.voice_bar.Size = new System.Drawing.Size(104, 45);
            this.voice_bar.TabIndex = 14;
            this.voice_bar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.voice_bar.Scroll += new System.EventHandler(this.CHANGE_ALL_VOLUME);
            // 
            // music_bar
            // 
            this.music_bar.BackColor = System.Drawing.Color.DimGray;
            this.music_bar.Location = new System.Drawing.Point(965, 68);
            this.music_bar.Maximum = 255;
            this.music_bar.Name = "music_bar";
            this.music_bar.Size = new System.Drawing.Size(104, 45);
            this.music_bar.TabIndex = 13;
            this.music_bar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.music_bar.Scroll += new System.EventHandler(this.CHANGE_ALL_VOLUME);
            // 
            // sel_duck_b
            // 
            this.sel_duck_b.BackColor = System.Drawing.Color.Transparent;
            this.sel_duck_b.FlatAppearance.BorderColor = System.Drawing.Color.Magenta;
            this.sel_duck_b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sel_duck_b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sel_duck_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_duck_b.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sel_duck_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sel_duck_b.Location = new System.Drawing.Point(128, 67);
            this.sel_duck_b.Name = "sel_duck_b";
            this.sel_duck_b.Size = new System.Drawing.Size(28, 22);
            this.sel_duck_b.TabIndex = 9;
            this.sel_duck_b.Text = "...";
            this.sel_duck_b.UseVisualStyleBackColor = false;
            this.sel_duck_b.Click += new System.EventHandler(this.SEARCH_CUSTOM_FILES);
            // 
            // xdelta_tbox
            // 
            this.xdelta_tbox.Location = new System.Drawing.Point(404, 527);
            this.xdelta_tbox.Name = "xdelta_tbox";
            this.xdelta_tbox.ReadOnly = true;
            this.xdelta_tbox.Size = new System.Drawing.Size(100, 20);
            this.xdelta_tbox.TabIndex = 8;
            // 
            // duck_tbox
            // 
            this.duck_tbox.Location = new System.Drawing.Point(22, 68);
            this.duck_tbox.Name = "duck_tbox";
            this.duck_tbox.Size = new System.Drawing.Size(100, 20);
            this.duck_tbox.TabIndex = 7;
            // 
            // server_tbox
            // 
            this.server_tbox.Location = new System.Drawing.Point(872, 526);
            this.server_tbox.Name = "server_tbox";
            this.server_tbox.ReadOnly = true;
            this.server_tbox.Size = new System.Drawing.Size(100, 20);
            this.server_tbox.TabIndex = 6;
            // 
            // client_tbox
            // 
            this.client_tbox.Location = new System.Drawing.Point(639, 527);
            this.client_tbox.Name = "client_tbox";
            this.client_tbox.ReadOnly = true;
            this.client_tbox.Size = new System.Drawing.Size(100, 20);
            this.client_tbox.TabIndex = 5;
            // 
            // gprofile_menu
            // 
            this.gprofile_menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gprofile_menu.FormattingEnabled = true;
            this.gprofile_menu.Location = new System.Drawing.Point(22, 152);
            this.gprofile_menu.Name = "gprofile_menu";
            this.gprofile_menu.Size = new System.Drawing.Size(112, 21);
            this.gprofile_menu.TabIndex = 4;
            this.gprofile_menu.SelectedIndexChanged += new System.EventHandler(this.SET_ANY_PROFILE_MODE);
            // 
            // ultra_b
            // 
            this.ultra_b.AutoSize = true;
            this.ultra_b.BackColor = System.Drawing.Color.Transparent;
            this.ultra_b.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultra_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ultra_b.Location = new System.Drawing.Point(22, 322);
            this.ultra_b.Name = "ultra_b";
            this.ultra_b.Size = new System.Drawing.Size(14, 13);
            this.ultra_b.TabIndex = 3;
            this.ultra_b.UseVisualStyleBackColor = false;
            this.ultra_b.CheckedChanged += new System.EventHandler(this.CHOOSE_GAME_QUALITY);
            // 
            // high_b
            // 
            this.high_b.AutoSize = true;
            this.high_b.BackColor = System.Drawing.Color.Transparent;
            this.high_b.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.high_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.high_b.Location = new System.Drawing.Point(22, 282);
            this.high_b.Name = "high_b";
            this.high_b.Size = new System.Drawing.Size(14, 13);
            this.high_b.TabIndex = 2;
            this.high_b.UseVisualStyleBackColor = false;
            this.high_b.CheckedChanged += new System.EventHandler(this.CHOOSE_GAME_QUALITY);
            // 
            // med_b
            // 
            this.med_b.AutoSize = true;
            this.med_b.BackColor = System.Drawing.Color.Transparent;
            this.med_b.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.med_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.med_b.Location = new System.Drawing.Point(22, 242);
            this.med_b.Name = "med_b";
            this.med_b.Size = new System.Drawing.Size(14, 13);
            this.med_b.TabIndex = 1;
            this.med_b.UseVisualStyleBackColor = false;
            this.med_b.CheckedChanged += new System.EventHandler(this.CHOOSE_GAME_QUALITY);
            // 
            // low_b
            // 
            this.low_b.AutoSize = true;
            this.low_b.BackColor = System.Drawing.Color.Transparent;
            this.low_b.Checked = true;
            this.low_b.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.low_b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.low_b.Location = new System.Drawing.Point(22, 198);
            this.low_b.Name = "low_b";
            this.low_b.Size = new System.Drawing.Size(14, 13);
            this.low_b.TabIndex = 0;
            this.low_b.TabStop = true;
            this.low_b.UseVisualStyleBackColor = false;
            this.low_b.CheckedChanged += new System.EventHandler(this.CHOOSE_GAME_QUALITY);
            // 
            // GLauncher_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 564);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GLauncher_settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fx_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voice_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.music_bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ultra_b;
        private System.Windows.Forms.RadioButton high_b;
        private System.Windows.Forms.RadioButton med_b;
        private System.Windows.Forms.RadioButton low_b;
        private System.Windows.Forms.ComboBox gprofile_menu;
        private System.Windows.Forms.Button sel_duck_b;
        private System.Windows.Forms.TextBox xdelta_tbox;
        private System.Windows.Forms.TextBox duck_tbox;
        private System.Windows.Forms.TextBox server_tbox;
        private System.Windows.Forms.TextBox client_tbox;
        private System.Windows.Forms.TrackBar fx_bar;
        private System.Windows.Forms.TrackBar voice_bar;
        private System.Windows.Forms.TrackBar music_bar;
        private System.Windows.Forms.ComboBox lang_menu;
        private System.Windows.Forms.Button sback_b;
        private System.Windows.Forms.Button sel_patch_b;
        private System.Windows.Forms.Button sel_server_b;
        private System.Windows.Forms.Button sel_client_b;
        private System.Windows.Forms.Label duck_l;
        private System.Windows.Forms.Label profile_l2;
        private System.Windows.Forms.Label profile_l1;
        private System.Windows.Forms.Label lang_l;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label music_l;
        private System.Windows.Forms.Label voice_l;
        private System.Windows.Forms.Label fx_l;
        private System.Windows.Forms.CheckBox turboc_ch;
        private System.Windows.Forms.CheckBox fscreen_ch;
        private System.Windows.Forms.Label cpu_l;
        private System.Windows.Forms.ComboBox cpu_menu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox presets_ch;
    }
}