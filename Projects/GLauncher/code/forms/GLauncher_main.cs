using GLauncher.code.forms;
using GLauncher.functions;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GLauncher.functions.GLauncher_functions;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GLauncher
{
    public partial class GLauncher_main : Form
    {
        GLauncher_functions funcs = new GLauncher_functions();
        

        System.Windows.Forms.Timer check_buttons = new System.Windows.Forms.Timer();
        ContextMenuStrip custom_;
        ContextMenuStrip mods;


        public GLauncher_main()
        {
            InitializeComponent();

            LOAD_ALL_DATA();

            funcs.MainForm = this;

            username_tbox.Text = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,
                S_JSON.Settings.Nickname).ToString();

            check_buttons.Interval = 1000;
            check_buttons.Tick += (sender, e) => ROM_OR_PATCH_EXISTS();
            check_buttons.Start();

            
            System.Windows.Forms.Timer check_process = new System.Windows.Forms.Timer();
            check_process.Interval = 1000;
            check_process.Tick += funcs.CHECK_PROCESS;
            check_process.Start();
        }



        void ROM_OR_PATCH_EXISTS()
        {
            if (funcs.playing_game) return;

            if (funcs.VANILLA_ROM_PATH != string.Empty && !File.Exists(funcs.VANILLA_ROM_PATH))
                funcs.VANILLA_ROM_PATH = string.Empty;

            bool patch_available = (funcs.VANILLA_ROM_PATH != string.Empty &&
                File.Exists(funcs.SET_PATCH_FILE(funcs.CURRENT_GAME, null)));

            if (funcs.IS_MODDED_ONLINE(funcs.CURRENT_GAME))
                patch_available = ((File.Exists(funcs.SET_BASE_ROM_FORMODS(funcs.CURRENT_GAME))));

            if (patch_b.Enabled != patch_available)
                    patch_b.Enabled = patch_available;

            bool play_available = (File.Exists(funcs.SET_ROM_FILE(funcs.CURRENT_GAME, null)));

            if (funcs.IS_MODDED_ONLINE(funcs.CURRENT_GAME))
                play_available = (funcs.SET_ONLINE_MODDED_ROM_LIST() != null);

                if (play_b.Enabled != play_available)
                    play_b.Enabled = play_available;


        }

        void CHECK_GASMOX_UPDATES(string[] comparelines, bool launcher_init)
        {
            string webFile = Path.Combine(L_PATHS.FOLDERS.Temp_dir, "latest_versions.json");

            funcs.DOWNLOAD_FILE(DOWNLOAD_LINKS.GasmoxVersionsJSON,
                webFile, null, false);

            if (!File.Exists(webFile))
            {
                MessageBox.Show("Error while checking updates!", "Error:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (byte i = 0; i < comparelines.Length; i++)
            {
                if (!launcher_init && i == 0) i++;

                Version local = new Version(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, comparelines[i]).ToString());
            
                Version web = new Version(funcs.READ_JSON_LINE(webFile, comparelines[i]).ToString());



                if (web > local)
                {


                        UPDATE_GASMOX(i, web, comparelines[i], false);

                        // a launcher update restarts the app, no point in checking the rest
                        if (i == 0) break;

                }
            }
        }

        enum UPDATES : byte
        {
            UPDATE_LAUNCHER,
            UPDATE_GASMOXIAN,
            UPDATE_CLIENT,
            UPDATE_SERVER,
            UPDATE_THEME, //not done yet
        };




        void DOWNLOAD_DUCK()
        {
            string duck_url = DOWNLOAD_LINKS.LatestDuck;
            string download_path = Path.Combine(L_PATHS.FOLDERS.Temp_dir, "duck.zip");

            funcs.DOWNLOAD_FILE(duck_url, download_path, null, false);

            if (!File.Exists(download_path)) return;

            funcs.FILES_(download_path, Path.Combine(L_PATHS.FOLDERS.Datadir, "duckstation"),
                 FILE_MANAGER.EXTRACT, false);

            funcs.FILES_(download_path, null,  FILE_MANAGER.DELETE, false);

            // freshly extracted duck: an old gamedb_backup would restore a yaml from another version on top
            funcs.FILES_(Path.Combine(L_PATHS.FOLDERS.Datadir, "duckstation", "resources", "gamedb_backup.yaml"),
                null, FILE_MANAGER.DELETE, false);

            MessageBox.Show("DuckStation downloaded successfully!", "Success!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        void CHECK_OCTR_FILES()
        {
            string temp_zip = Path.Combine(L_PATHS.FOLDERS.Temp_dir, "octr.zip");

            string[] octr_files = { funcs.SET_CLIENT_FILE((byte) GAMES.ONLINECTR),
                funcs.SET_PATCH_FILE((byte) GAMES.ONLINECTR, null),
                funcs.SET_SERVER_FILE((byte) GAMES.ONLINECTR) };

            bool skip_download = true;

            for (byte i = 0; i < octr_files.Length; i++)
            {
                if (!File.Exists(octr_files[i])) skip_download = false;
            }

            if (skip_download) return;

            MessageBox.Show("Can't find OnlineCTR files, downloading the latest version...", "Gasmoxian Launcher:",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

            funcs.DOWNLOAD_FILE(DOWNLOAD_LINKS.OCTR_ZIP,
                temp_zip, null, false);

            if (!File.Exists(temp_zip))
            {
                MessageBox.Show("Error while downloading OnlineCTR files!", "Error:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                funcs.FILES_(temp_zip, L_PATHS.FOLDERS.Root,  FILE_MANAGER.EXTRACT, false);

                MessageBox.Show("Done, now you should patch a clean NTSC-U bin to play", "Info:",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error:",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            funcs.FILES_(temp_zip, null,  FILE_MANAGER.DELETE, false);
        }
        void CHECK_GASMOX_FILES(string[] jsonlines)
        { 


            string versions_json = Path.Combine(L_PATHS.FOLDERS.Temp_dir, "latest_versions.json");

            funcs.DOWNLOAD_FILE(DOWNLOAD_LINKS.GasmoxVersionsJSON,
                versions_json, null, false);


            List<string> gasmox_files = new List<string> {
    funcs.SET_PATCH_FILE((byte)GAMES.GASMOXIAN, null),
    funcs.SET_CLIENT_FILE((byte)GAMES.GASMOXIAN),
    funcs.SET_SERVER_FILE((byte)GAMES.GASMOXIAN)
};

            if (!File.Exists(versions_json)) return;

            bool something_wasupdated = false;
            bool message = false;

            for (byte i = 0; i < gasmox_files.Count; i++)
            {
               

                if (!File.Exists(gasmox_files[i]))
                {
                    if (!message)
                    {
                        MessageBox.Show("Can't find Gasmoxian files, downloading the latest game files...",
                        "Gasmoxian Launcher:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        message = true;
                    }


                    Version updatedVersion = new Version(funcs.READ_JSON_LINE(versions_json, jsonlines[i]).ToString());

                    UPDATE_GASMOX((byte)(i + 1), updatedVersion, jsonlines[i], true);

                    if (!File.Exists(gasmox_files[i]))
                    {
                        MessageBox.Show("Error while downloading Gasmoxian files! Try again later",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    something_wasupdated = true;
                    
                }
            }

            if (something_wasupdated)
                MessageBox.Show("Done! now you should patch a clean NTSC-U bin to play",
               "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void UPDATE_GASMOX(byte updateCase, Version updated_ver, string line, bool no_message)
        {
            string tempPath = Path.Combine(L_PATHS.FOLDERS.Datadir, "temp");
            string url;
            string download_path;

            string[] messages = {
    "Launcher update available! Please wait...",
    "Gasmoxian update available! Please wait...",
    "Client update available! Please wait...",
    "Server update available! Please wait..."
};

            if (!no_message)
            MessageBox.Show(messages[updateCase], "Gasmoxian updater:",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            switch (updateCase)
            {
                case (byte)UPDATES.UPDATE_LAUNCHER:
                    {
                        Process updater = null;

                        url = DOWNLOAD_LINKS.Launcher;

                        download_path = Path.Combine(tempPath, "launcher_latest.7z");

                        funcs.DOWNLOAD_FILE(url, download_path, null, false);

                        if (!File.Exists(download_path)) return;

                        funcs.FILES_(download_path, Path.Combine(tempPath, "update"),
                             FILE_MANAGER.EXTRACT, false);

                        Thread.Sleep(1000);

                        funcs.FILES_(download_path, null,
                         FILE_MANAGER.DELETE, false);

                        if (!Directory.Exists(Path.Combine(tempPath, "update")))
                            return;

                        funcs.execute_process(L_PATHS.FILES.updater, $"\"{L_PATHS.FOLDERS.Root}\"",
                            L_PATHS.FOLDERS.Root, ref updater, (byte) EXECUTION_MODE.window_nowait);

                        funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, line, updated_ver.ToString());

                        Environment.Exit(0);

                        break;
                    }
                case (byte)UPDATES.UPDATE_GASMOXIAN:
                    {
                        url = DOWNLOAD_LINKS.GasmoxianPatch;

                        download_path = 
                            funcs.SET_PATCH_FILE((byte) GAMES.GASMOXIAN, null);

                        funcs.DOWNLOAD_FILE(url, download_path, null, false);

                        if (!File.Exists(download_path)) return;

                        string message = "Gasmoxian xdelta updated successfully, make sure to re-patch the ROM";

                        if (File.Exists(funcs.VANILLA_ROM_PATH))
                        {
                            funcs.APPLY_XDELTA_PATCH(funcs.VANILLA_ROM_PATH,
                                funcs.SET_PATCH_FILE((byte) GAMES.GASMOXIAN, null),
                                funcs.SET_ROM_FILE((byte) GAMES.GASMOXIAN, null));

                            message = "Game updated & re-patched successfully!";
                        }

                        if(!no_message)
                        MessageBox.Show(message, "Gasmoxian updater:",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }
                case (byte)UPDATES.UPDATE_CLIENT:
                    {
                        url = DOWNLOAD_LINKS.GClient;

                        download_path = funcs.SET_CLIENT_FILE((byte) GAMES.GASMOXIAN);
                        funcs.DOWNLOAD_FILE(url, download_path, null, false);

                        if (!File.Exists(download_path)) return;


                        if (!no_message)
                        MessageBox.Show("Client & Server executables updated successfully!", "Gasmoxian updater:",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }
                case (byte)UPDATES.UPDATE_SERVER:
                    {
                        url = DOWNLOAD_LINKS.Gserver;

                        download_path = funcs.SET_SERVER_FILE((byte) GAMES.GASMOXIAN);
                        funcs.DOWNLOAD_FILE(url, download_path, null, false);

                        break;
                    }
            }

            funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, line, updated_ver.ToString());

        }

        void CUSTOM_MENU_INIT()
        {
            custom_ = new ContextMenuStrip();

            string[] text = { "CUSTOM ONLINE", "MODDED GASMOXIAN", "MODDED OCTR", "MODDED OFFLINE", "VANILLA CTR" };

            for (byte i = 0; i < text.Length; i++)
            {
                byte index = i;

                custom_.Items.Add(text[i], null, (s, ev) =>
                {
                    funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Settings.SelectedGame,
                        (byte) GAMES.CUSTOM_ONLINE + index);

                    funcs.RELOAD_DATA((byte) DATA_REGIONS.CHANGE_GAME);
                });
            }

        }

        void SELECT_MOD() //context menu to pick a mod, shown when pressing the patch button
        {
            if (mods != null)
            {
                mods.Dispose();
            }

            

            if (!funcs.DOWNLOAD_FILE(DOWNLOAD_LINKS.ModList,
                L_PATHS.FILES.ModList, null, false))
            {
                MessageBox.Show("Error downloading mod list, try again later", "Mod downloader:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            mods = new ContextMenuStrip();

            string[] modlist = funcs.READ_ALL_JSON(L_PATHS.FILES.ModList, null).ToArray();

            for (byte i = 0; i < modlist.Length; i++)
            {
                byte index = i;

                mods.Items.Add(modlist[i], null, (s, ev) =>
                {
                    MessageBox.Show($"Downloading {modlist[index]}, please wait, this can take a few minutes...", "Mod downloader:",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    funcs.DOWNLOAD_MODS(modlist[index]);

                });
            }

            mods.Show(patch_b, new Point(0, patch_b.Height));


        }
        async Task<bool> DISPLAY_THEME_LIST()
        {
            ContextMenuStrip theme_list = new ContextMenuStrip();


            string[] available_themes = funcs.GET_LAUNCHER_THEMES();

            var wait_until_menu_is_closed = new TaskCompletionSource<bool>();

            bool theme_was_selected = false;

            for (byte i = 0; i < available_themes.Length; i++)
            {
                byte index = i;
                string name = Path.GetFileName(available_themes[index]);

                theme_list.Items.Add(name, null, (s, ev) =>
                {
                    string curr_theme = name;
                    funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.SelectedTheme, curr_theme);
                    theme_was_selected = true;
                    wait_until_menu_is_closed.TrySetResult(true);
                });
            }

            // menu closed without picking anything: complete the Task anyway (it used to hang forever)
            theme_list.Closed += (s, ev) =>
            {
                if (ev.CloseReason != ToolStripDropDownCloseReason.ItemClicked)
                    wait_until_menu_is_closed.TrySetResult(false);
            };

            theme_list.Show(advanced_b, new Point(0, -theme_list.Height));

            await wait_until_menu_is_closed.Task;

            if (theme_was_selected)
                funcs.RELOAD_DATA((byte)DATA_REGIONS.RELOAD_THEME);

            return theme_was_selected;
        }
        async Task<bool> DISPLAY_ONLINE_MODS()
        {
            if (mods != null)
            {
                mods.Dispose();
            }

                mods = new ContextMenuStrip();


            string[] available_mods = funcs.SET_ONLINE_MODDED_ROM_LIST();

            var wait_until_menu_is_closed = new TaskCompletionSource<bool>();

            bool modwas_selected = false;

            for (byte i = 0; i < available_mods.Length; i++)
            {
                byte index = i;
                string name = Path.GetFileNameWithoutExtension(available_mods[index]);

                mods.Items.Add(name, null, (s, ev) =>
                {
                    funcs.MOD_NAME = name;
                    funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Custom.Mod, funcs.MOD_NAME);
                    modwas_selected = true;
                    wait_until_menu_is_closed.TrySetResult(true);
                });
            }

            // menu closed without picking anything: complete the Task anyway (it used to hang forever)
            mods.Closed += (s, ev) =>
            {
                if (ev.CloseReason != ToolStripDropDownCloseReason.ItemClicked)
                    wait_until_menu_is_closed.TrySetResult(false);
            };

            mods.Show(play_b, new Point(0, - mods.Height));

            await wait_until_menu_is_closed.Task;

            return modwas_selected;
        }

        void LOAD_ALL_DATA()
        {
            funcs.restart_music = SynchronizationContext.Current;

            funcs.CHECK_LAUNCHER_FILES();

            funcs.CURRENT_GAME = Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Settings.SelectedGame));
            funcs.DUCK_PATH = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Custom.Duck).ToString();
            funcs.VANILLA_ROM_PATH = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Settings.RomPath).ToString();
            rom_tbox.Text = funcs.VANILLA_ROM_PATH;
            funcs.LANG = (LANGUAGES)Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.SelectedLanguage));

            if (funcs.IS_MODDED_ONLINE(funcs.CURRENT_GAME))
            {
                // load the mod name from the json and keep online vs gasmoxian mods apart
                funcs.MOD_NAME = funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Custom.Mod).ToString();

                funcs.MODS_FOLDER = (funcs.CURRENT_GAME == (byte) GAMES.MODDED_OCTR) ?
                        Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "mods" ,"octr_mods") : Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "mods");
            }

            funcs.CLIENT_PATH = funcs.SET_CLIENT_FILE((byte)funcs.CURRENT_GAME);
            funcs.SERVER_PATH = funcs.SET_SERVER_FILE((byte)funcs.CURRENT_GAME);

            // if the previous session died without restoring (crash/forced close), clean the duck up
            if (!string.IsNullOrEmpty(funcs.DUCK_PATH) && File.Exists(funcs.DUCK_PATH) &&
                Process.GetProcessesByName(Path.GetFileNameWithoutExtension(funcs.DUCK_PATH)).Length == 0)
            {
                funcs.UPDATE_DUCK_SETTINGS(true);
            }

            funcs.HEAL_THEME_RESIDUE();

            funcs.MainForm_Controls = new List<Control> { panel1, panel2, groupBox1, versionGif };
            funcs.RELOAD_DATA((byte)DATA_REGIONS.RELOAD_THEME);
            CUSTOM_MENU_INIT();

            string[] version_lines = {
    S_JSON.GasmoxVersion.LauncherVersion,
    S_JSON.GasmoxVersion.GasmoxianVersion,
    S_JSON.GasmoxVersion.GClientVersion,
    S_JSON.GasmoxVersion.GServerVersion
};

            if (funcs.CURRENT_GAME == ((byte) GAMES.GASMOXIAN) ||
               funcs.CURRENT_GAME == ((byte) GAMES.MODDED_GASMOXIAN))
                CHECK_GASMOX_FILES(version_lines);

            if (funcs.CURRENT_GAME == ((byte) GAMES.ONLINECTR) ||
                funcs.CURRENT_GAME == ((byte) GAMES.MODDED_OCTR))
                CHECK_OCTR_FILES();

            CHECK_GASMOX_UPDATES(version_lines, true);

        }

        void SELECT_ROM(object sender, EventArgs e)
        {
            OpenFileDialog rom = funcs.SEARCH_FILE_WINDOW("CTR ROM FILE (*.bin) |*.bin", new OpenFileDialog());

            if (rom != null)
            {
                funcs.VANILLA_ROM_PATH = rom.FileName;
                rom_tbox.Text = funcs.VANILLA_ROM_PATH;
                funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Settings.RomPath, funcs.VANILLA_ROM_PATH);

            }
        }
        void WRITE_USERNAME(object sender, EventArgs e)
        {
            funcs.REWRITE_JSON_LINE( L_PATHS.FILES.Settings,
                 S_JSON.Settings.Nickname,
                username_tbox.Text);
        }


        void SET_CUSTOM(object sender, EventArgs e)
        {
            custom_.Show(custom_b, new Point(0, custom_b.Height));
        }
        void SET_OCTR(object sender, EventArgs e)
        {
            CHECK_OCTR_FILES();
            funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Settings.SelectedGame,
                $"{(byte) GAMES.ONLINECTR}");

            funcs.RELOAD_DATA((byte) DATA_REGIONS.CHANGE_GAME);
        }
        void SET_GASMOXIAN(object sender, EventArgs e)
        {
            CHECK_GASMOX_FILES(new string[] {
    S_JSON.GasmoxVersion.GasmoxianVersion,
    S_JSON.GasmoxVersion.GClientVersion,
    S_JSON.GasmoxVersion.GServerVersion });

            funcs.REWRITE_JSON_LINE(L_PATHS.FILES.Settings,  S_JSON.Settings.SelectedGame,
                $"{(byte) GAMES.GASMOXIAN}");

            funcs.RELOAD_DATA((byte) DATA_REGIONS.CHANGE_GAME);
        }
        void OPEN_HELP(object sender, EventArgs e)
        {
            string DiscordLink = funcs.discord_Invite;

            Process.Start(new ProcessStartInfo
                {
                FileName = DiscordLink,
                UseShellExecute = true,
                });
        }
        void OPEN_HOST_SETTINGS(object sender, EventArgs e)
        {
            GLauncher_host host_form = new GLauncher_host(funcs);
            host_form.Show();
            host_form.BringToFront();
            this.Hide();
        }
        void OPEN_GRAPHICS_CONFIG(object sender, EventArgs e)
        {

            GLauncher_settings settings_form = new GLauncher_settings(funcs);
            settings_form.Show();
            settings_form.BringToFront();
            this.Hide();

        }
        async void OPEN_ADVANCED(object sender, EventArgs e)
        {
            await DISPLAY_THEME_LIST();
        }



        void PATCH_GAME(object sender, EventArgs e)
        {
            funcs.PLAY_FX("menu_confirm.wav");


            if (funcs.IS_MODDED_ONLINE(funcs.CURRENT_GAME))
            {
                SELECT_MOD();
                return;
            }

            string xdelta_path = funcs.SET_PATCH_FILE(funcs.CURRENT_GAME, null);

            string output = funcs.SET_ROM_FILE(funcs.CURRENT_GAME, null);

            funcs.APPLY_XDELTA_PATCH(funcs.VANILLA_ROM_PATH, xdelta_path, output);
        }



        async void PLAY_GAME(object sender, EventArgs e)
        {
            funcs.PLAY_FX("menu_confirm.wav");

            // let the user pick which modded rom to play
            if (funcs.IS_MODDED_ONLINE(funcs.CURRENT_GAME) && !await DISPLAY_ONLINE_MODS())
            return;

            funcs.PLAY_MUSIC(false);
            funcs.playing_game = true;



            if (funcs.CURRENT_GAME == (byte) GAMES.GASMOXIAN ||
                funcs.CURRENT_GAME == (byte) GAMES.MODDED_GASMOXIAN)
            {
                CHECK_GASMOX_UPDATES(new string[] { null,
                     S_JSON.GasmoxVersion.GasmoxianVersion,
                     S_JSON.GasmoxVersion.GClientVersion, S_JSON.GasmoxVersion.GServerVersion }, false);
            }

            if (funcs.IS_MODDED_ONLINE(funcs.CURRENT_GAME))
            {
                bool octr = (funcs.CURRENT_GAME == (byte) GAMES.MODDED_OCTR);

                if (octr) 
                funcs.CHECK_UPDATE_FOR_ALTERNATIVE_GAMES((byte) GAMES.ONLINECTR);


                funcs.CHECK_UPDATE_FOR_ALTERNATIVE_GAMES(funcs.CURRENT_GAME);
            }

            string args;
            string nickname = funcs.READ_JSON_LINE( L_PATHS.FILES.Settings,
                 S_JSON.Settings.Nickname).ToString();


            string romfile = (funcs.IS_MODDED_ONLINE(funcs.CURRENT_GAME)) ?
                funcs.SET_ROM_FILE(funcs.CURRENT_GAME, funcs.MOD_NAME) :
                funcs.SET_ROM_FILE(funcs.CURRENT_GAME, null);

            if (!File.Exists(romfile))
            {
                MessageBox.Show($"ROM file not found:\n{romfile}", "Error:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                funcs.playing_game = false;
                funcs.PLAY_MUSIC(true);
                return;
            }

            string screen = (Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings, 
                 S_JSON.Settings.FullScreen)) == 1) ?
                "-fullscreen" : string.Empty;

            string duckexe = Path.Combine(L_PATHS.FOLDERS.Datadir, "duckstation",
               "duckstation-qt-x64-ReleaseLTCG.exe");

            if ((string.IsNullOrEmpty(funcs.DUCK_PATH) || !File.Exists(funcs.DUCK_PATH)) && !File.Exists(duckexe))
            {

                DialogResult no_valid_duck = MessageBox.Show("Your DuckStation path is not set! Do you want to download the latest version?",
                    "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (no_valid_duck == DialogResult.Yes)
                {
                    DOWNLOAD_DUCK();

                    if (File.Exists(duckexe))
                    {

                        funcs.DUCK_PATH = duckexe;
                    }
                    else
                    {
                        MessageBox.Show("Failed! Can't find the downloaded DuckStation", "Error:",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        funcs.playing_game = false;
                        funcs.PLAY_MUSIC(true);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please set your DuckStation path in the launcher settings first!", "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    funcs.PLAY_MUSIC(true);
                    funcs.playing_game = false;

                    return;
                }

            }
            else if ((string.IsNullOrEmpty(funcs.DUCK_PATH) || !File.Exists(funcs.DUCK_PATH)) && File.Exists(duckexe))
            {
                    funcs.DUCK_PATH = duckexe;
            }


            // if the username is empty use the default name
            if (nickname == string.Empty)
            {
                nickname = "GASMOXIAN";
                funcs.REWRITE_JSON_LINE( L_PATHS.FILES.Settings,
                     S_JSON.Settings.Nickname, nickname);

                username_tbox.Text = nickname;
            }


            if (funcs.CURRENT_GAME == (byte)GAMES.CUSTOM_ONLINE)
            {
                MessageBox.Show("The launcher nickname is not compatible with custom OnlineCTR clients",
    "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (!funcs.UPDATE_DUCK_SETTINGS(false))
            {
                funcs.playing_game = false;
                funcs.PLAY_MUSIC(true);
                return;
            }


            List <Button> disable = new List<Button> { custom_b, gasmox_b, octr_b, play_b, patch_b };

            funcs.buttons_to_disable = disable;

            funcs.DISABLE_MAINFORM_BUTTONS(false);


            args = $"{screen} -fastboot -batch \"{romfile}\"";

            funcs.execute_process(funcs.DUCK_PATH, args, L_PATHS.FOLDERS.Root,
                ref funcs.duck_process, (byte) EXECUTION_MODE.window_nowait);

            // local reference: CHECK_PROCESS can dispose/null funcs.duck_process in parallel
            Process duck = funcs.duck_process;

            try
            {
                duck.Refresh();

                // generous margin: on slow pcs or with high graphics duck takes a while to open
                int timeout = 0;
                while (duck.MainWindowHandle == IntPtr.Zero)
                {
                    if (duck.HasExited)
                    {
                        ABORT_PLAY("Duckstation closed unexpectedly before loading.");
                        return;
                    }
                    if (timeout > 60000)
                    {
                        duck.Kill(); // don't leave it alive with the launcher already reset
                        ABORT_PLAY("Duckstation took too long to open.");
                        return;
                    }

                    await Task.Delay(350);
                    timeout += 350;
                    duck.Refresh();
                }

                int retries = 0;
                const int MAX_RETRIES = 120; // 120 * 500ms = 60 sec

                while (retries < MAX_RETRIES)
                {
                    try
                    {
                        string shmemName = $"duckstation_{duck.Id}";
                        using (MemoryMappedFile.OpenExisting(shmemName, MemoryMappedFileRights.Read))
                        {

                        }
                        break;
                    }
                    catch (FileNotFoundException)
                    {
                        if (duck.HasExited)
                        {
                            ABORT_PLAY("Duckstation closed before the game could load, or shared memory error");
                            return;
                        }
                        await Task.Delay(500);
                        retries++;
                    }
                }

                if (retries >= MAX_RETRIES)
                {
                    ABORT_PLAY("Duckstation is not responding.");
                    return;
                }
            }
            catch (Exception ex)
            {
                // duck closed/disposed mid-startup
                ABORT_PLAY(ex.Message);
                return;
            }

            if (funcs.CURRENT_GAME == (byte) GAMES.CUSTOM_ONLINE)
            {

                funcs.execute_process(funcs.CLIENT_PATH, string.Empty, L_PATHS.FOLDERS.Root,
                    ref funcs.client_process, (byte) EXECUTION_MODE.window_nowait);
            }
            else if (funcs.CURRENT_GAME < (byte) GAMES.MODDED_OFFLINE &&
                funcs.CURRENT_GAME != (byte) GAMES.CUSTOM_ONLINE)
            {
                args = nickname;
                funcs.execute_process(funcs.CLIENT_PATH, args, L_PATHS.FOLDERS.Root,
     ref funcs.client_process, (byte) EXECUTION_MODE.window_nowait);
            }


            await funcs.MODIFY_GAMEAUDIO(Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,
                S_JSON.Settings.FX_VOLUME)), GAME_AUDIO.FX);

             await funcs.MODIFY_GAMEAUDIO(Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,
                S_JSON.Settings.VOICE_VOLUME)), GAME_AUDIO.VOICE);

             await funcs.MODIFY_GAMEAUDIO(Convert.ToByte(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,
                S_JSON.Settings.MUSIC_VOLUME)), GAME_AUDIO.MUSIC);

            await funcs.SET_TURBO_COUNTER(Convert.ToBoolean(funcs.READ_JSON_LINE(L_PATHS.FILES.Settings,
                S_JSON.Settings.TurboCounter)));

            await funcs.SET_ROM_LANG(funcs.LANG);
        }

        void ABORT_PLAY(string message)
        {
            MessageBox.Show(message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            funcs.playing_game = false;
            funcs.PLAY_MUSIC(true);
            funcs.DISABLE_MAINFORM_BUTTONS(true);
        }

        private void play_b_MouseEnter(object sender, EventArgs e)
        {

            if (play_b.Enabled && play_b.Image == null)
            {
                funcs.PLAY_FX("menu_selection_change.wav");

                bool gif_exists;

                string image_path = (Path.Combine(L_PATHS.FOLDERS.Themes, funcs.CURRENT_THEME()));

                string curr_lang = funcs.LANG.ToString();

               gif_exists = (File.Exists(Path.Combine(image_path, $"{curr_lang}{THEME_FILES.MainForm.playButton}")));

                string desired_gif = (!gif_exists) ?
                    string.Empty : curr_lang;

               gif_exists = (File.Exists(Path.Combine(image_path, $"{desired_gif}{THEME_FILES.MainForm.playButton}")));

                if (!gif_exists) return;

                funcs.load_image_to_ui(Path.Combine(image_path, $"{desired_gif}{THEME_FILES.MainForm.playButton}"), play_b, true);
            }
        }

        private void play_b_MouseLeave(object sender, EventArgs e)
        {
            if (play_b.Image != null)
                play_b.Image = null;
        }
    }
}
