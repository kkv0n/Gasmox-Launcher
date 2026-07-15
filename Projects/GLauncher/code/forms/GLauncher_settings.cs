using GLauncher.functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GLauncher.functions.GLauncher_functions;
using static System.Collections.Specialized.BitVector32;

namespace GLauncher.code.forms
{
    public partial class GLauncher_settings : Form
    {
        GLauncher_functions funcs;

        List<Control> settings_controls = new List<Control>();
        public GLauncher_settings(GLauncher_functions funcsRef)
        {
            InitializeComponent();
            funcs = funcsRef;
            settings_controls = new List<Control> { fscreen_ch, turboc_ch, low_b, med_b, high_b, ultra_b };
            funcs.LOAD_THEME(new List<Control> { groupBox1 }, new string[] { THEME_FILES.SettingsForm.background }, funcs.CURRENT_THEME());
            LOAD_PREV_SETTINGS_UI();
            this.FormClosed += new FormClosedEventHandler(OPEN_MAINFORM);


        }

        void load_lists()
        {
            byte graphics_length = (byte)Enum.GetValues(typeof(RENDER_MODE)).Length;
            byte cpu_length = (byte)Enum.GetValues(typeof(S_CPU_MODE)).Length;

            byte language_length = (byte)Enum.GetValues(typeof(LANGUAGES)).Length; //this is the bigger one

            for (byte i = 0; i < language_length; i++)
            {
                if (i < graphics_length)
                    gprofile_menu.Items.Add(((RENDER_MODE)i).ToString());

                if (i < language_length)
                    lang_menu.Items.Add(((LANGUAGES)i).ToString());

                if (i < cpu_length)
                    cpu_menu.Items.Add(((S_CPU_MODE)i).ToString());
            }
        }



        void LOAD_PREV_SETTINGS_UI()
        {
            load_lists();

            

            funcs.SET_LANGUAGE_TO_UI(settings_controls);
            
            fx_bar.Value = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.FX_VOLUME));
            voice_bar.Value = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.VOICE_VOLUME));
            music_bar.Value = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.MUSIC_VOLUME));
           gprofile_menu.SelectedIndex = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.GraphicProfile));
            cpu_menu.SelectedIndex = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.CpuMode));
            lang_menu.SelectedIndex = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.SelectedLanguage));
            duck_tbox.Text = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Duck).ToString();
            xdelta_tbox.Text = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Xdelta).ToString();
            client_tbox.Text = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Client).ToString();
            server_tbox.Text = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Server).ToString();
            turboc_ch.Checked = Convert.ToBoolean(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.TurboCounter));
            fscreen_ch.Checked = Convert.ToBoolean(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.FullScreen));

            byte current_quality = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.GraphicQuality));


            switch ((VIDEO_PRESETS)current_quality)
            {
                case VIDEO_PRESETS.LOW:
                    {
                        low_b.Checked = true;
                        break;
                    }
                case VIDEO_PRESETS.MEDIUM:
                    {
                        med_b.Checked = true;
                        break;
                    }
                case VIDEO_PRESETS.HIGH:
                    {
                        high_b.Checked = true;
                        break;
                    }
                case VIDEO_PRESETS.ULTRA:
                    {
                        ultra_b.Checked= true;
                        break;
                    }
                case VIDEO_PRESETS.MANUAL:
                    {
                        presets_ch.Checked = false;
                        break;
                    }
            }

        }

        async void CHANGE_ALL_VOLUME(object sender, EventArgs e)
        {

            TrackBar current_button = sender as TrackBar;

            // dummy init to satisfy the compiler, always reassigned below
            GAME_AUDIO desired_option = (GAME_AUDIO)0;



            if (sender == music_bar)
            {
                desired_option = GAME_AUDIO.MUSIC;

            }
            else if (sender == fx_bar)
            {
                desired_option = GAME_AUDIO.FX;

            }
            else if (sender == voice_bar)
            {
                desired_option = GAME_AUDIO.VOICE;

            }

            
            await funcs.MODIFY_GAMEAUDIO((byte)current_button.Value, desired_option);
            
                
        }
        void SEARCH_CUSTOM_FILES(object sender, EventArgs e)
        {
            OpenFileDialog customs = null;

            string parameters = string.Empty;
            string write_this = string.Empty;
            TextBox current_textbox = null;

            if (sender == sel_duck_b)
            {
                parameters = "DUCK EXECUTABLE (*.exe) |*.exe";
                write_this = S_JSON.Custom.Duck;
                current_textbox = duck_tbox;
            }
            else if (sender == sel_patch_b)
            {
                parameters = "XDELTA PATCH (*.xdelta) |*.xdelta";
                write_this = S_JSON.Custom.Xdelta;
                current_textbox = xdelta_tbox;
            }
            else if (sender == sel_client_b)
            {
                parameters = "ONLINE CLIENT FILE (*.exe) |*.exe";
                write_this = S_JSON.Custom.Client;
                current_textbox = client_tbox;
            }
            else if (sender == sel_server_b)
            {
                parameters = "ONLINE SERVER FILE (*.exe) |*.exe";
                write_this = S_JSON.Custom.Server;
                current_textbox = server_tbox;
            }

            customs = funcs.SEARCH_FILE_WINDOW(parameters, new OpenFileDialog());

            if (customs != null)
            {
                // when switching ducks, restore the previous one if launcher state was left in it
                if (sender == sel_duck_b && !funcs.playing_game &&
                    !string.IsNullOrEmpty(funcs.DUCK_PATH) && File.Exists(funcs.DUCK_PATH) &&
                    Process.GetProcessesByName(Path.GetFileNameWithoutExtension(funcs.DUCK_PATH)).Length == 0)
                {
                    funcs.UPDATE_DUCK_SETTINGS(true);
                }

                funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, write_this, customs.FileName);
                MessageBox.Show(customs.FileName, "Path saved:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                current_textbox.Text = customs.FileName;
                funcs.RELOAD_DATA((byte)DATA_REGIONS.UPDATE_CUSTOM);
            }
        }

        void SET_ANY_PROFILE_MODE(object sender, EventArgs e)
        {
            ComboBox current_cbox = sender as ComboBox;
            string current_option = string.Empty;

            if (sender == gprofile_menu)
            {
                current_option = S_JSON.Settings.GraphicProfile;
            }
            else if (sender == cpu_menu)
            {
                current_option = S_JSON.Settings.CpuMode;
            }
            else if (sender == lang_menu)
            {
                current_option = S_JSON.Settings.SelectedLanguage;
                
            }


           

            funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, current_option, current_cbox.SelectedIndex);

            if (sender == lang_menu)
            {             
                funcs.RELOAD_DATA((byte)DATA_REGIONS.RELOAD_LANG);
                funcs.SET_LANGUAGE_TO_UI(settings_controls);
            }
        }
        void CHOOSE_GAME_QUALITY(object sender, EventArgs e)
        {
            VIDEO_PRESETS quality = (VIDEO_PRESETS)0;

            if (sender == low_b)
            {
                quality = VIDEO_PRESETS.LOW;
            }
            else if (sender == med_b)
            {
                quality = VIDEO_PRESETS.MEDIUM;
            }
            else if (sender == high_b)
            {
                quality = VIDEO_PRESETS.HIGH;
            }
            else if (sender == ultra_b)
            {
                quality = VIDEO_PRESETS.ULTRA;
            }
            else if (sender == presets_ch)
            {
                TOGGLE_PRESETS(presets_ch.Checked);

                quality = VIDEO_PRESETS.MANUAL;

                if (presets_ch.Checked)
                    quality = VIDEO_PRESETS.LOW;
            }

                funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.GraphicQuality, (byte)quality);
        }

        void TOGGLE_PRESETS(bool toggle)
        {
            gprofile_menu.Enabled = toggle;
            low_b.Enabled = toggle;
            med_b.Enabled = toggle;
            high_b.Enabled = toggle;
            ultra_b.Enabled = toggle;
        }

         async void TURBO_COUNTER_CHECKED(object sender, EventArgs e)
        {
            funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.TurboCounter, Convert.ToByte(turboc_ch.Checked));
            await funcs.SET_TURBO_COUNTER(turboc_ch.Checked);
        }

        void FULLSCREEN_CHECKED(object sender, EventArgs e)
        {
            funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.FullScreen, Convert.ToByte(fscreen_ch.Checked));
        }

        void OPEN_MAINFORM(object sender, EventArgs e)
        {
            funcs.MainForm.Show();
            funcs.RELOAD_MAINFORM();
        }
        void GO_BACK(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
