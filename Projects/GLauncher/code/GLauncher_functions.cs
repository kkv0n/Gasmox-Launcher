using duckshmem_dll;
using GLauncher.code.forms;
using GLauncher.Properties;
using IniParser;
using IniParser.Model;
using LibVLCSharp.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SevenZip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core.Tokens;
using YamlDotNet.RepresentationModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace GLauncher.functions
{
    public class GLauncher_functions
    {

        public Process duck_process = null;
        public Process client_process = null;
        public SynchronizationContext restart_music;
        public GLauncher_main MainForm;
        public List<Control> MainForm_Controls;


       



        public byte CURRENT_GAME;
        public string DUCK_PATH;
        public string CLIENT_PATH;
        public string MOD_NAME;
        public string VANILLA_ROM_PATH;
        public string MODS_FOLDER;
        public string SERVER_PATH;

        public LANGUAGES LANG;

        public static readonly Version Launcher_ver = new Version(1, 0, 6);

        public enum EXECUTION_MODE : byte
        {
            all_false,
            all_false_debug_output,
            all_false_waitexit,
            debug_output_waitexit_window,
            debug_error_all_false,
            debug_error_output_waitexit,
            debug_error_output_waitexit_window,
            window_insert_input,
            window_insert_input_wait,
            debug_error_window_waitexit,
            window_waitexit,
            window_nowait
        };

        public enum GAMES : byte
        {
            GASMOXIAN,
            ONLINECTR,
            CUSTOM_ONLINE,
            MODDED_GASMOXIAN,
            MODDED_OCTR,
            MODDED_OFFLINE,
            VANILLA_CTR,
            ANY_ONLINE_MODDED,
        };

        public enum LANGUAGES: byte
        {
            ENGLISH,
            ESPAÑOL,
            ITALIANO,
            PORTUGUÊS,
            ARABIC,
            GERMAN,
            JAPANESE
        };

        public enum VIDEO_PRESETS : byte
        {
            LOW,
            MEDIUM,
            HIGH,
            ULTRA,
            MANUAL
        };

        public enum RENDER_MODE : byte
        {
            AUTOMATIC,
            SOFTWARE,
            D3D11,
            OPENGL,
            D3D12,
            VULKAN
        };

        public enum S_CPU_MODE : byte
        {
            Recompiler,
            NewRecompiler,
            CachedInterpreter
        };

        public enum FILE_MANAGER : byte
        {
            COPY,
            MOVE,
            DELETE,
            CREATE,
            EXTRACT,
            COMPRESS
        };

        public enum DATA_REGIONS : byte
        {
            APP_INIT,
            RELOAD_THEME,
            RELOAD_LANG,
            CHANGE_GAME,
            UPDATE_CUSTOM
        };

        public enum ROM_TASK : byte
        {
            DISASSEMBLE,
            REBUILD
        };

        public readonly string discord_Invite = "https://discord.gg/usjUQFpgMm"; //gasmoxian discord


        public struct DOWNLOAD_LINKS
        {
            public const string Launcher = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/Launcher/latest_update.7z";
            public const string GClient = "https://github.com/kkv0n/Penguin-MODSK/releases/download/launcher/GClient.exe";
            public const string GasmoxianPatch = "https://github.com/kkv0n/Penguin-MODSK/releases/download/Patch/octr_gasmoxian.xdelta";
            public const string Gserver = "https://github.com/kkv0n/Penguin-MODSK/releases/download/launcher/GServer.exe";
            public const string GUpdater = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/tools/GUpdater.exe";
            public const string OCTR_ZIP = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/Launcher/latest_octr.zip";
            public const string OCTR_VersionJSON = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/Launcher/latest_octr.txt";
            public const string sevenzipDLL = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/tools/7z.dll";
            public const string xdelta3exe = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/tools/xdelta3.exe";
            public const string Essentialszip = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/tools/essential.zip";
            public const string ModList = "https://github.com/kkv0n/Gasmox-Launcher/releases/download/Launcher/mods.json";
            public const string LatestDuck = "https://github.com/stenzek/duckstation/releases/download/latest/duckstation-windows-x64-release.zip";
            public const string GasmoxVersionsJSON = "https://raw.githubusercontent.com/kkv0n/Gasmox-Launcher/refs/heads/main/update.json";
            public const string RadminVPN = "https://download.radmin-vpn.com/download/files/Radmin_VPN_1.4.4642.1.exe";
        }
        public struct S_JSON
        {
            public struct JSON_FORMAT
            {
                public struct Settings
                {
                    public const string self = "Settings";
                    public const string CpuMode = "CpuMode";
                    public const string GraphicProfile = "GraphicsProfile";
                    public const string GraphicQuality = "GraphicQuality";
                    public const string FX_VOLUME = "fx_volume";
                    public const string VOICE_VOLUME = "voice_volume";
                    public const string MUSIC_VOLUME = "music_volume";
                    public const string FullScreen = "FullScreen";
                    public const string TurboCounter = "TurboCounter";
                    public const string SelectedGame = "Curr_Game";
                    public const string SelectedLanguage = "SelectedLanguage";
                    public const string Nickname = "Username";
                }

                public struct Rom
                {
                    public const string self = "Rom";
                    public const string RomPath = "Path";
                }

                public struct Theme
                {
                    public const string self = "Theme";
                    public const string SelectedTheme = "Selected";
                }

                public struct CustomPaths
                {
                    public const string self = "Custom";
                    public const string Mod = "current_mod_name";
                    public const string Xdelta = "xdelta";
                    public const string Client = "client";
                    public const string Server = "server";
                    public const string Duck = "duck";
                }

                public struct Version

                {
                    public const string self = "Versions";
                    public const string LauncherVersion = "launcher_version";
                    public const string GasmoxianVersion = "xdelta_version";
                    public const string GClientVersion = "gclient_version";
                    public const string GServerVersion = "gserver_version";
                }
            }

            public struct Settings
            {
                public const string CpuMode = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.CpuMode;
                public const string GraphicProfile = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.GraphicProfile;
                public const string GraphicQuality = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.GraphicQuality;
                public const string FX_VOLUME = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.FX_VOLUME;
                public const string VOICE_VOLUME = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.VOICE_VOLUME;
                public const string MUSIC_VOLUME = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.MUSIC_VOLUME;
                public const string FullScreen = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.FullScreen;
                public const string TurboCounter = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.TurboCounter;
                public const string RomPath = JSON_FORMAT.Rom.self + "." + JSON_FORMAT.Rom.RomPath;
                public const string SelectedGame = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.SelectedGame;
                public const string SelectedTheme = JSON_FORMAT.Theme.self + "." + JSON_FORMAT.Theme.SelectedTheme;
                public const string SelectedLanguage = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.SelectedLanguage;
                public const string Nickname = JSON_FORMAT.Settings.self + "." + JSON_FORMAT.Settings.Nickname;
            }

            public struct Custom
            {
                public const string Mod = JSON_FORMAT.CustomPaths.self + "." + JSON_FORMAT.CustomPaths.Mod;
                public const string Xdelta = JSON_FORMAT.CustomPaths.self + "." + JSON_FORMAT.CustomPaths.Xdelta;
                public const string Client = JSON_FORMAT.CustomPaths.self + "." + JSON_FORMAT.CustomPaths.Client;
                public const string Server = JSON_FORMAT.CustomPaths.self + "." + JSON_FORMAT.CustomPaths.Server;
                public const string Duck = JSON_FORMAT.CustomPaths.self + "." + JSON_FORMAT.CustomPaths.Duck;
            }

            public struct GasmoxVersion

            {
                public const string LauncherVersion = JSON_FORMAT.Version.self + "." + JSON_FORMAT.Version.LauncherVersion;
                public const string GasmoxianVersion = JSON_FORMAT.Version.self + "." + JSON_FORMAT.Version.GasmoxianVersion;
                public const string GClientVersion = JSON_FORMAT.Version.self + "." + JSON_FORMAT.Version.GClientVersion;
                public const string GServerVersion = JSON_FORMAT.Version.self + "." + JSON_FORMAT.Version.GServerVersion;
            }
        }


        public struct THEME_FILES
        {
            public struct MainForm
            {
                public static readonly string background = "groupbox1.png";
                public static readonly string patchPanel = "panel1.png";
                public static readonly string playPanel = "panel2.png";
                public static readonly string versionGif = "version.gif";
                public static readonly string playButton = "button.gif";
            }

            public struct SettingsForm
            {
                public static readonly string background = "settings.png";
            }

            public struct HostForm
            {
                public static readonly string background = "host.png";
            }

            public struct HelpForm
            {
                public static readonly string background = "help.png";
            }
            
         }

        public struct L_PATHS
        {
            public struct FOLDERS
            {
                public static readonly string Root = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
                public static readonly string Datadir = Path.Combine(Root, "data");
                public static readonly string Graphics = Path.Combine(Datadir, "graphics");
                public static readonly string Themes = Path.Combine(Datadir, "themes");
                public static readonly string Default_theme = Path.Combine(Themes, "default");
                public static readonly string Host = Path.Combine(Datadir, "host");
                public static readonly string Languages = Path.Combine(Datadir, "languages");
                public static readonly string Launcher_Rompath = Path.Combine(Datadir, "rom");
                public static readonly string Gasmoxian_mods = Path.Combine(Launcher_Rompath, "mods");
                public static readonly string Octr_mods = Path.Combine(Gasmoxian_mods, "octr_mods");
                public static readonly string Temp_dir = Path.Combine(Datadir, "temp");
                public static readonly string Tools = Path.Combine(Datadir, "tools");
                public static readonly string Essential = Path.Combine(Tools, "essential");
            }

            public struct FILES
            {
                public static readonly string Settings = Path.Combine(FOLDERS.Root, "gamesettings.json");
                public static readonly string Langs = Path.Combine(FOLDERS.Languages, "langs.json");
                public static readonly string ModList = Path.Combine(FOLDERS.Launcher_Rompath, "mods.json");
                public static readonly string Openbios = Path.Combine(FOLDERS.Essential, "openbios.bin");
                public static readonly string sevenzipdll = Path.Combine(FOLDERS.Tools, "7z.dll");
                public static readonly string xdelta3 = Path.Combine(FOLDERS.Tools, "xdelta3.exe");
                public static readonly string updater = Path.Combine(FOLDERS.Tools, "GUpdater.exe");
                public static readonly string privatesv_IPfile = Path.Combine(FOLDERS.Host, "host.txt");
            }
        }

        public List<Button> buttons_to_disable = new List<Button>();
        public bool playing_game;

        public void DISABLE_MAINFORM_BUTTONS(bool enabled)
        {
            for (byte i = 0; i < buttons_to_disable.Count; i++)
            {
                Button toggle_this = buttons_to_disable[i];

                if (toggle_this.InvokeRequired)
                {
                    toggle_this.Invoke((MethodInvoker)(() =>
                    {
                        toggle_this.Enabled = enabled;
                    }));
                }
                else
                {
                    toggle_this.Enabled = enabled;
                }
            }
        }

        public void CHECK_PROCESS(object sender, EventArgs e)
        {
            // the Exited event fires on a threadpool thread: serialize everything onto the UI thread
            if (MainForm != null && MainForm.InvokeRequired)
            {
                MainForm.BeginInvoke((MethodInvoker)(() => CHECK_PROCESS(sender, e)));
                return;
            }

            if (duck_process != null && duck_process.HasExited)
            {
                if (CURRENT_GAME < (byte)GAMES.MODDED_OFFLINE)
                    if (client_process != null && !client_process.HasExited)
                    {
                        client_process.Kill();
                        client_process?.Dispose();
                        client_process = null;
                    }

                UPDATE_DUCK_SETTINGS(true);

                PLAY_MUSIC(true);

                DISABLE_MAINFORM_BUTTONS(true);

                playing_game = false;

                duck_process?.Dispose();
                duck_process = null;
            }
        }

        public void execute_process(string filename, string args, string workdir, ref Process execute, byte mode)
        {
            // 0 = no shell, no window, no error, no output, no wait for exit
            // 1 = no shell, no window, no error, output, no wait for exit
            // 2 = no shell, no window, no error, no output, wait for exit
            // 3 = no shell, window, no error, output, wait for exit
            // 4 = no shell, no window, error, no output, no wait for exit
            // 5 = no shell, no window, error, output, wait for exit
            // 6 = no shell, window, error, output, wait for exit
            // 7 = no shell, window, no error, no output, insert input, no wait for exit
            // 8 = no shell, window, no error, no output, insert input, wait for exit
            // 9 = no shell, window, error, no output, wait for exit
            // 10 = shell, window, no error, no output, wait for exit
            // 11 = shell, window, no error, no output, no wait for exit

            string error = string.Empty;
            string output = string.Empty;
            string logsfile = string.Empty;

            bool input_disabled = (mode != (byte)EXECUTION_MODE.window_insert_input &&
                mode != (byte)EXECUTION_MODE.window_insert_input_wait);

            bool waitforexit = (mode != (byte)EXECUTION_MODE.all_false &&
    mode != (byte)EXECUTION_MODE.window_nowait &&
    mode != (byte)EXECUTION_MODE.debug_error_all_false &&
    mode != (byte)EXECUTION_MODE.all_false_debug_output) &&
    mode != (byte)EXECUTION_MODE.window_insert_input;

            bool nowindow = (mode < (byte)EXECUTION_MODE.debug_error_output_waitexit_window &&
                mode != (byte)EXECUTION_MODE.debug_output_waitexit_window);

            bool show_output = (mode <= (byte)EXECUTION_MODE.debug_error_output_waitexit_window &&
                mode != (byte)EXECUTION_MODE.all_false_waitexit && mode != (byte)EXECUTION_MODE.debug_error_all_false);

            bool show_errors = (mode > (byte)EXECUTION_MODE.debug_output_waitexit_window &&
                mode < (byte)EXECUTION_MODE.window_waitexit);

            bool shell = (mode > (byte)EXECUTION_MODE.debug_error_window_waitexit);

            execute = new Process();
            execute.StartInfo.FileName = filename;

            if (input_disabled && args != string.Empty)
                execute.StartInfo.Arguments = args;

            execute.StartInfo.WorkingDirectory = workdir;
            execute.StartInfo.UseShellExecute = shell;

            execute.StartInfo.CreateNoWindow = nowindow;

            execute.StartInfo.RedirectStandardOutput = show_output;

            execute.StartInfo.RedirectStandardError = show_errors;

            execute.StartInfo.RedirectStandardInput = (!input_disabled);

            if (execute == duck_process)
            {
                execute.EnableRaisingEvents = true;
                execute.Exited += new EventHandler(CHECK_PROCESS);
            }

            execute.Start();

            if (!input_disabled) execute.StandardInput.WriteLine(args);

            if (execute.StartInfo.RedirectStandardError) error = execute.StandardError.ReadToEnd();

            if (execute.StartInfo.RedirectStandardOutput)
            {
                output = execute.StandardOutput.ReadToEnd();
                logsfile = Path.Combine(L_PATHS.FOLDERS.Root, "logs.txt");
            }

            if (waitforexit) execute.WaitForExit();

            if (!string.IsNullOrEmpty(error)) MessageBox.Show(error, "Process:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!string.IsNullOrEmpty(output)) File.AppendAllText(logsfile, Environment.NewLine + output);
        }

        public void load_image_to_ui(string img, Control dest, bool gif)
        {
            if (gif)
            {
                if (dest is PictureBox picbox)
                {
                    picbox.Image = Image.FromFile(img);
                    picbox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (dest is Button btn)
                {
                    btn.Image = Image.FromFile(img);
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                }
            }
            else
            {
                dest.BackgroundImage = new Bitmap(img);
                dest.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public void load_text_to_ui(string text, Control dest)
        {
            dest.Text = text;
        }

        public void REWRITE_JSON_LINE(string filepath, string og_line, JToken replacement)
        {
            using (var fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                string readAll = string.Empty;

                using (var reader = new StreamReader(fs, Encoding.UTF8, true, 1024, leaveOpen: true))
                {
                    readAll = reader.ReadToEnd();
                }

                fs.Seek(0, SeekOrigin.Begin);

                using (var writer = new StreamWriter(fs))
                {
                    JObject write = JObject.Parse(readAll);

                    write.SelectToken(og_line).Replace(JToken.FromObject(replacement));

                    fs.SetLength(0);
                    writer.Write(write);
                }
            }
        }

        public JToken READ_JSON_LINE(string filepath, string line)
        {

            using (var fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fs))
            {

                JObject read = JObject.Parse(reader.ReadToEnd());

                return read.SelectToken(line);
            }
        }

        // returns the json property names, or the items of a property when property_name is an empty string
        public List<string> READ_ALL_JSON(string filepath, string property_name)
        {
            List<string> properties_names = new List<string>();
            List<string> items = new List<string>();

            using (var fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fs))
            {
                JObject read = JObject.Parse(reader.ReadToEnd());

                var all_properties = read.Properties().ToList();

                for (ushort i = 0; i < all_properties.Count; i++)
                {
                    properties_names.Add(all_properties[i].Name);

                    if (all_properties[i].ToString() == property_name && property_name != null)
                    {
                        var all_items = all_properties[i].Value.ToList();

                        for (ushort j = 0; j < all_items.Count; j++)
                        {
                            items.Add((string)all_items[j]);
                        }
                    }
                }
            }

            return (property_name != string.Empty) ? properties_names : items;
        }

        public void WRITE_TXT_LINE(string filepath, string text_ref_from_line, string replacement, char starts_with, char ends_with)
        {
            string[] allLines = File.ReadAllLines(filepath);

            for (uint i = 0; i < allLines.Length; i++)
            {
                if (allLines[i].Contains(text_ref_from_line))
                {
                    ushort start = (ushort)allLines[i].IndexOf(starts_with);
                    ushort end = (ushort)allLines[i].LastIndexOf(ends_with);

                    if (start >= 0 && end > start) //TO DO: start is unsigned so the >= 0 check does nothing
                    {
                        allLines[i] = allLines[i].Substring(0, start + 1) + replacement + allLines[i].Substring(end + 1);
                    }
                }
            }

            File.WriteAllLines(filepath, allLines);
        }

        public string READ_TXT_TEXT(string filepath, string search_text, char starts_with, char ends_with)
        {
            string[] allLines = File.ReadAllLines(filepath);

            for (uint i = 0; i < allLines.Length; i++)
            {
                if (allLines[i].Contains(search_text))
                {
                    ushort start = (ushort)allLines[i].IndexOf(starts_with);
                    int end = (ushort)allLines[i].LastIndexOf(ends_with);

                    if (start >= 0 && end > start) //TO DO: start is unsigned so the >= 0 check does nothing
                    {
                        return allLines[i].Substring(start + 1, end - start - 1);
                    }
                }
            }
            return null;
        }



        public void DOWNLOAD_MODS(string name)
        {
            string downloadLink = READ_JSON_LINE(Path.Combine(L_PATHS.FILES.ModList), $"{name}.download").ToString();
            string webVersion = READ_JSON_LINE(Path.Combine(L_PATHS.FILES.ModList), $"{name}.version_link").ToString();

            DOWNLOAD_FILE(webVersion, Path.Combine(MODS_FOLDER, name + ".txt"), null, false);

            DOWNLOAD_FILE(downloadLink, SET_PATCH_FILE((byte)GAMES.ANY_ONLINE_MODDED, name), null, false);

            if (!File.Exists(SET_PATCH_FILE((byte)GAMES.ANY_ONLINE_MODDED, name)) || !File.Exists(Path.Combine(MODS_FOLDER, name + ".txt")))
            {
                MessageBox.Show($"Error while downloading {name}! Try again later", "Mod downloader:",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            INSTALL_MOD(name);

            if (File.Exists(SET_ROM_FILE((byte)GAMES.ANY_ONLINE_MODDED, name)))
            {
                REWRITE_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Mod, name);
                MessageBox.Show($"{name} mod installed successfully!", "Mod downloader:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void INSTALL_MOD(string name)
        {
            ROM_MANAGER(VANILLA_ROM_PATH, Path.Combine(L_PATHS.FOLDERS.Datadir, "temp", "mod_files"),
           SET_PATCH_FILE(CURRENT_GAME, name), (byte)ROM_TASK.DISASSEMBLE);

            ROM_MANAGER(SET_BASE_ROM_FORMODS(CURRENT_GAME), Path.Combine(L_PATHS.FOLDERS.Datadir, "temp", name),
            null, (byte)ROM_TASK.DISASSEMBLE);

            MOVE_MOD_FILES(Path.Combine(L_PATHS.FOLDERS.Datadir, "temp", "mod_files"), Path.Combine(L_PATHS.FOLDERS.Datadir, "temp", name));

            ROM_MANAGER(Path.Combine(L_PATHS.FOLDERS.Datadir, "temp", name), Path.Combine(MODS_FOLDER, name + ".bin"),
            null, (byte)ROM_TASK.REBUILD);
        }

        public void MOVE_MOD_FILES(string extracted_mod_folder, string dest_ctr_folder)
        {
            if (!Directory.Exists(extracted_mod_folder) || !Directory.Exists(dest_ctr_folder))
                return;

            string HOWL = "SOUNDS";
            string XA = "XA";
            string lng = Path.Combine("bigfile", "lang");
            string textures = Path.Combine("bigfile", "packs");
            string screen_tittle = Path.Combine("bigfile", "screen");
            string models = Path.Combine("bigfile", "models", "racers");

            string[] folders = { HOWL, XA, lng, textures, screen_tittle, models };

            for (byte i = 0; i < folders.Length; i++)
            {
                FILES_(Path.Combine(extracted_mod_folder, folders[i]),
                    Path.Combine(dest_ctr_folder,
                    folders[i]), FILE_MANAGER.MOVE, true);
            }

            FILES_(extracted_mod_folder, null, FILE_MANAGER.DELETE, true);

            FILES_(Path.Combine(Path.GetDirectoryName(extracted_mod_folder), Path.GetFileName(extracted_mod_folder) + ".xml"),
                null, FILE_MANAGER.DELETE, false);
        }

        public void ROM_MANAGER(string input_path, string output_path, string optional_xdelta, byte task)
        {
            string temp_path = Path.Combine(L_PATHS.FOLDERS.Datadir, "temp");

            Process rom_process = null;
            string args;

            if (task == (byte)ROM_TASK.DISASSEMBLE)
            {
                if (!File.Exists(input_path)) return;

                if (optional_xdelta != null)
                {
                    APPLY_XDELTA_PATCH(input_path,
                    optional_xdelta, Path.Combine(temp_path, "ex_temp.bin"));

                    input_path = Path.Combine(temp_path, "ex_temp.bin");
                }

                args = $"\"{input_path}\" -x \"{output_path}\" -s \"{output_path + ".xml"}\"";

                execute_process(Path.Combine(L_PATHS.FOLDERS.Tools, "dumpsxiso.exe"),
                 args, L_PATHS.FOLDERS.Root, ref rom_process, (byte)EXECUTION_MODE.all_false_waitexit);

                args = $"\"{Path.Combine(output_path, "bigfile.big")}\"";

                execute_process(Path.Combine(L_PATHS.FOLDERS.Tools, "bigtool.exe"),
                args, L_PATHS.FOLDERS.Root, ref rom_process, (byte)EXECUTION_MODE.all_false_waitexit);

                if (optional_xdelta != null)
                    FILES_(input_path, null, FILE_MANAGER.DELETE, false);
            }
            else
            {
                if (!Directory.Exists(input_path)) return;

                args = $"\"{Path.Combine(input_path, "bigfile.txt")}\"";

                execute_process(Path.Combine(L_PATHS.FOLDERS.Tools, "bigtool.exe"), args, input_path,
                    ref rom_process, (byte)EXECUTION_MODE.debug_error_output_waitexit);

                string xml = Path.Combine(Path.GetDirectoryName(input_path), Path.GetFileNameWithoutExtension(input_path)) + ".xml";

                args = $"\"{xml}\" -y -q -o \"{output_path}\"";

                execute_process(Path.Combine(L_PATHS.FOLDERS.Tools, "mkpsxiso.exe"), args, L_PATHS.FOLDERS.Root,
                    ref rom_process, (byte)EXECUTION_MODE.all_false_waitexit);

                FILES_(xml, null, FILE_MANAGER.DELETE, false);

                FILES_(input_path, null, FILE_MANAGER.DELETE, true);
            }
        }

        //TO DO: REPLACE .TXT WITH JSON
        public void CHECK_UPDATE_FOR_ALTERNATIVE_GAMES(byte game)
        {
            string downloadUrl = string.Empty;
            string downloadPath = string.Empty;
            string webVersionUrl = string.Empty;
            string localFile = string.Empty;
            bool shouldExtract = false;
            string message = string.Empty;

            if (game <= (byte)GAMES.MODDED_OCTR &&
                game != (byte)GAMES.GASMOXIAN &&
                game != (byte)GAMES.CUSTOM_ONLINE)
            {
                if (IS_MODDED_ONLINE(game))
                {
                    string mods_link = DOWNLOAD_LINKS.ModList;

                    if (!File.Exists(L_PATHS.FILES.ModList))
                        DOWNLOAD_FILE(mods_link, Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "mods.json"), null, false);

                    downloadUrl = READ_JSON_LINE(Path.Combine(L_PATHS.FILES.ModList), $"{MOD_NAME}.download").ToString();
                    downloadPath = SET_PATCH_FILE((byte)GAMES.ANY_ONLINE_MODDED, MOD_NAME);
                    webVersionUrl = READ_JSON_LINE(Path.Combine(L_PATHS.FILES.ModList), $"{MOD_NAME}.version_link").ToString();
                    localFile = Path.Combine(MODS_FOLDER, MOD_NAME + ".txt");
                    shouldExtract = false;
                    message = $"New {MOD_NAME} version available! Updating...";
                }
                else
                {
                    downloadUrl = DOWNLOAD_LINKS.OCTR_ZIP;
                    downloadPath = Path.Combine(L_PATHS.FOLDERS.Temp_dir, "octr.zip");
                    webVersionUrl = DOWNLOAD_LINKS.OCTR_VersionJSON;
                    localFile = Path.ChangeExtension(SET_ROM_FILE((byte)GAMES.ONLINECTR, null), "txt");
                    shouldExtract = true;
                    message = "New OnlineCTR version available! Updating...";
                }

                if (!GET_UPDATE_FOR_ALTERNATIVE_STUFF(downloadUrl, downloadPath, webVersionUrl, localFile, message, "version", shouldExtract))
                    return;

                if (game == (byte)GAMES.ONLINECTR)
                {
                    APPLY_XDELTA_PATCH(VANILLA_ROM_PATH,
                        SET_PATCH_FILE((byte)GAMES.ONLINECTR, null),
                        SET_ROM_FILE((byte)GAMES.ONLINECTR, null));

                    return;
                }

                INSTALL_MOD(MOD_NAME);
            }
        }

        public bool GET_UPDATE_FOR_ALTERNATIVE_STUFF(string downloadUrl, string downloadPath, string web_fileUrl, string localFile, string message, string line, bool extract)
        {
            // line = json token path for .json files, or the text to search for in .txt files

            string temp_path = Path.Combine(L_PATHS.FOLDERS.Datadir, "temp");
            string webfile_path = Path.Combine(temp_path, Path.GetFileName(localFile));

            DOWNLOAD_FILE(web_fileUrl, webfile_path, null, false);

            if (!File.Exists(webfile_path)) return false;

            Version local;
            Version web;

            if (Path.GetExtension(localFile) == ".json")
            {
                local = new Version(READ_JSON_LINE(localFile, line).ToString());
                web = new Version(READ_JSON_LINE(webfile_path, line).ToString());
            }
            else
            {
                local = new Version(READ_TXT_TEXT(localFile, line, '"', '"'));
                web = new Version(READ_TXT_TEXT(webfile_path, line, '"', '"'));
            }

            if (local < web)
            {
                MessageBox.Show(message, "Updater:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DOWNLOAD_FILE(downloadUrl, downloadPath, null, false);

                if (!File.Exists(downloadPath))
                {
                    MessageBox.Show($"Error while updating: {Path.GetFileName(downloadPath)}",
                        "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (extract)
                {
                    string extract_path = Path.GetDirectoryName(downloadPath);

                    FILES_(downloadPath, extract_path, FILE_MANAGER.EXTRACT, false);

                    if (!Directory.Exists(extract_path))
                    {
                        MessageBox.Show("Error while extracting the update",
                       "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    FILES_(downloadPath, null, FILE_MANAGER.DELETE, false);
                }

                if (Path.GetExtension(localFile) == ".json")
                    REWRITE_JSON_LINE(localFile, line, web.ToString());
                else 
                    WRITE_TXT_LINE(localFile, line, web.ToString(), '"', '"');

                FILES_(webfile_path, null, FILE_MANAGER.DELETE, false);

                return true;
            }

            return false;
        }

        //TO DO: add yml files and bios check
        //TO DO: CHECK DEFAULT THEME FILES
        public void CHECK_LAUNCHER_FILES()
        {
            string[] folders = {L_PATHS.FOLDERS.Tools,  L_PATHS.FOLDERS.Languages,
                 L_PATHS.FOLDERS.Launcher_Rompath, L_PATHS.FOLDERS.Gasmoxian_mods, L_PATHS.FOLDERS.Octr_mods, string.Empty, string.Empty};

            string[] files = { L_PATHS.FILES.xdelta3,  L_PATHS.FILES.sevenzipdll, string.Empty,
            L_PATHS.FILES.updater, string.Empty, string.Empty  ,string.Empty,};

            string[] download_links =
            {
              DOWNLOAD_LINKS.xdelta3exe,
             DOWNLOAD_LINKS.sevenzipDLL,
             DOWNLOAD_LINKS.Essentialszip,
             DOWNLOAD_LINKS.GUpdater,
             string.Empty,
             string.Empty,
             string.Empty,
            };

            string[] jsons =
            {
                L_PATHS.FILES.Settings,
                string.Empty,
                L_PATHS.FILES.Langs,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty

            };

            for (byte i = 0; i < folders.Length; i++)
            {
                if (!String.IsNullOrEmpty(folders[i]) && !Directory.Exists(folders[i]))
                {
                    FILES_(folders[i], null, FILE_MANAGER.CREATE, true);
                }


                if (!String.IsNullOrEmpty(jsons[i]) && !File.Exists(jsons[i]))
                {
                    string writetext;

                    FILES_(jsons[i], null, FILE_MANAGER.CREATE, false);

                    if (jsons[i] == L_PATHS.FILES.Settings)
                        writetext = gamesettings.ToString(Formatting.Indented);

                    else if (jsons[i] == L_PATHS.FILES.Langs)
                        writetext = languages.ToString(Formatting.Indented); 
                    else continue; //just in case 

                        File.WriteAllText(jsons[i], writetext);
                }

                if (download_links[i] == DOWNLOAD_LINKS.Essentialszip)
                {
                    string essentials_name = Path.ChangeExtension(Path.GetFileName(L_PATHS.FOLDERS.Essential), "zip");
                    DOWNLOAD_FILE(download_links[i], Path.Combine(L_PATHS.FOLDERS.Temp_dir, essentials_name), null, false);
                    SEVENZIP_TASK(Path.Combine(L_PATHS.FOLDERS.Temp_dir, essentials_name), L_PATHS.FOLDERS.Tools, true);
                }

                else if (!String.IsNullOrEmpty(files[i]) && !File.Exists(files[i]))
                {

                    if (!String.IsNullOrEmpty(download_links[i]))
                    {

                            DOWNLOAD_FILE(download_links[i], files[i], null, false);
                    }

                }


            }

            // jsons from older launcher versions: add any new keys they are missing
            MERGE_MISSING_JSON(L_PATHS.FILES.Settings, gamesettings);
            MERGE_MISSING_JSON(L_PATHS.FILES.Langs, languages);
        }

        public void MERGE_MISSING_JSON(string filepath, JObject defaults)
        {
            if (!File.Exists(filepath)) return;

            JObject current;
            bool changed = false;

            try
            {
                current = JObject.Parse(File.ReadAllText(filepath));
            }
            catch (Exception)
            {
                current = new JObject(); // corrupted json (e.g. interrupted write): regenerate it
                changed = true;
            }

            foreach (var prop in defaults.Properties())
            {
                if (!(current[prop.Name] is JObject subcur) || !(prop.Value is JObject subdef))
                {
                    if (current[prop.Name] == null)
                    {
                        current[prop.Name] = prop.Value.DeepClone();
                        changed = true;
                    }
                    continue;
                }

                foreach (var subprop in subdef.Properties())
                {
                    if (subcur[subprop.Name] == null)
                    {
                        subcur[subprop.Name] = subprop.Value.DeepClone();
                        changed = true;
                    }
                }
            }

            if (changed)
                File.WriteAllText(filepath, current.ToString(Formatting.Indented));
        }

        //TO DO: remember to copy memory card for offline games
        public bool UPDATE_DUCK_SETTINGS(bool restore)
        {
            try
            {
                return UPDATE_DUCK_SETTINGS_INTERNAL(restore);
            }
            catch (Exception ex)
            {
                // duck folder without write permission, or any other file failure
                MessageBox.Show($"Can't modify files in the DuckStation folder:\n{ex.Message}\n\n" +
                    "Move DuckStation to a folder with write access (avoid Program Files).",
                    "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool UPDATE_DUCK_SETTINGS_INTERNAL(bool restore)
        {
            if (string.IsNullOrEmpty(DUCK_PATH) || !File.Exists(DUCK_PATH)) return false;

            string duck_folder = Path.GetDirectoryName(DUCK_PATH);
            string duck_settings = Path.Combine(duck_folder, "settings.ini");
            string duck_backup = Path.Combine(duck_folder, "backup.ini");
            string config_dest = Path.Combine(duck_folder, "gamesettings", "SCUS-94426.ini");
            string config_backup = Path.Combine(duck_folder, "gamesettings", "backup.ini");
            string bios_src = L_PATHS.FILES.Openbios;
            string bios_dest = Path.Combine(duck_folder, "bios", Path.GetFileName(bios_src));
            string yaml_file = Path.Combine(duck_folder, "resources", "gamedb.yaml");
            string yaml_backup = Path.Combine(duck_folder, "resources", "gamedb_backup.yaml");
            string docs_settings = Path.Combine(Environment.GetFolderPath(
                                       Environment.SpecialFolder.MyDocuments), "DuckStation", "settings.ini");
            string essential_cfg = Path.Combine(L_PATHS.FOLDERS.Tools, "essential", "duckcfg.ini");

            // settings from the previous session (keeps controls/config made inside duck)
            string session_cfg = Path.Combine(L_PATHS.FOLDERS.Essential, "duckcfg_last.ini");
            string portable_file = Path.Combine(duck_folder, "portable.txt");

            // there is only something to restore if a launcher session left backups behind
            bool session_leftover = File.Exists(duck_backup) || File.Exists(yaml_backup) || File.Exists(config_backup);

            if (!restore)
            {
                // previous session never got restored (crash/forced close): clean up before overwriting the backups
                if (session_leftover)
                    UPDATE_DUCK_SETTINGS(true);

                // priority: last session > duck's own portable settings > Documents > default config
                string settings_source =
                    File.Exists(session_cfg) ? session_cfg :
                    File.Exists(duck_settings) ? duck_settings :
                    File.Exists(docs_settings) ? docs_settings : essential_cfg;

                if (!Directory.Exists(Path.GetDirectoryName(config_dest)))
                    FILES_(Path.GetDirectoryName(config_dest), null, FILE_MANAGER.CREATE, true);

                if (!Directory.Exists(Path.GetDirectoryName(bios_dest)))
                    FILES_(Path.GetDirectoryName(bios_dest), null, FILE_MANAGER.CREATE, true);

                // make sure memcards exists instead of relying on duck creating it on every machine
                if (!Directory.Exists(Path.Combine(duck_folder, "memcards")))
                    FILES_(Path.Combine(duck_folder, "memcards"), null, FILE_MANAGER.CREATE, true);

                // copy the BIOS first
                FILES_(bios_src, bios_dest, FILE_MANAGER.COPY, false);


                if (!File.Exists(bios_dest))
                {
                    MessageBox.Show("Failed to copy BIOS file to Duckstation folder.", "Error:",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // backup the yaml BEFORE modifying it
                FILES_(yaml_file, yaml_backup, FILE_MANAGER.COPY, false);

                // backup the game-specific ini if it exists
                if (File.Exists(config_dest))
                    FILES_(config_dest, config_backup, FILE_MANAGER.MOVE, false);

                // backup the current settings from duck_folder
                if (File.Exists(duck_settings))
                    FILES_(duck_settings, duck_backup, FILE_MANAGER.MOVE, false);

                // if the source was duck's own settings, it now lives in the backup
                if (settings_source == duck_settings)
                    settings_source = duck_backup;

                // copy the chosen source as the temporary settings in duck_folder
                FILES_(settings_source, duck_settings, FILE_MANAGER.COPY, false);

                // --- write the game-specific ini (SCUS) ---
                CREATE_CTR_SETTINGS(
                    config_dest,
                    duck_settings,
                    (VIDEO_PRESETS)Convert.ToByte(READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.GraphicQuality)),
                    (RENDER_MODE)Convert.ToByte(READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.GraphicProfile)),
                    (S_CPU_MODE)Convert.ToByte(READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.CpuMode)));

                if (!EDIT_YAML(yaml_file, ((GAMES)CURRENT_GAME).ToString()))
                {
                    UPDATE_DUCK_SETTINGS(true); // undo the half-done backups
                    return false;
                }

                // mark portable.txt as ours so we never delete one that already belonged to the user
                if (!File.Exists(portable_file))
                    File.WriteAllText(portable_file, "GLauncher");
            }
            else
            {
                if (!session_leftover) return true;

                // delete the temporary game-specific ini
                FILES_(config_dest, null, FILE_MANAGER.DELETE, false);

                // restore the yaml from its backup
                if (File.Exists(yaml_backup))
                    FILES_(yaml_backup, yaml_file, FILE_MANAGER.MOVE, false);

                // keep whatever the user changed while playing (controllers, etc.) for the next session
                if (File.Exists(duck_settings))
                {
                    if (!Directory.Exists(L_PATHS.FOLDERS.Essential))
                        FILES_(L_PATHS.FOLDERS.Essential, null, FILE_MANAGER.CREATE, true);

                    FILES_(duck_settings, session_cfg, FILE_MANAGER.COPY, false);

                    // don't let the per-game color stick as the base theme of future sessions
                    try
                    {
                        IniData last = MANAGE_INI_FILE(session_cfg, null, true);
                        last["UI"]["Theme"] = DUCK_DEFAULT_THEME;
                        MANAGE_INI_FILE(session_cfg, last, false);
                    }
                    catch (Exception) { }
                }

                // delete the temporary settings
                FILES_(duck_settings, null, FILE_MANAGER.DELETE, false);

                bool had_settings_backup = File.Exists(duck_backup);

                // restore the original settings from the backup
                if (had_settings_backup)
                    FILES_(duck_backup, duck_settings, FILE_MANAGER.MOVE, false);

                // restore the game-specific ini from its backup
                if (File.Exists(config_backup))
                    FILES_(config_backup, config_dest, FILE_MANAGER.MOVE, false);

                // only delete portable.txt if the launcher created it
                try
                {
                    if (File.Exists(portable_file))
                    {
                        string marker = File.ReadAllText(portable_file).Trim();

                        // old launcher versions created it empty: it's ours if the duck had no settings of its own
                        if (marker == "GLauncher" || (marker == string.Empty && !had_settings_backup))
                            FILES_(portable_file, null, FILE_MANAGER.DELETE, false);
                    }
                }
                catch (IOException) { }
            }

            return true;
        }

        public bool DOWNLOAD_FILE(string URL, string savePath, string finished_text, bool message)
        {
            bool finished = false;

            System.Threading.Thread downloader = new System.Threading.Thread(() =>
            {

                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                        FILES_(Path.GetDirectoryName(savePath), null, FILE_MANAGER.CREATE, true);

                    using (HttpClient web = new HttpClient())
                    {
                        using (HttpResponseMessage download = web.GetAsync(URL, HttpCompletionOption.ResponseHeadersRead).Result)
                        {
                            download.EnsureSuccessStatusCode();

                            using (FileStream saveFolder = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))

                            using (Stream fileDownloaded = download.Content.ReadAsStreamAsync().Result)
                            {
                                fileDownloaded.CopyTo(saveFolder);
                            }
                        }
                    }

                    if (message)
                        MessageBox.Show(finished_text, "Gasmoxian downloader:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error:" + exception, "Gasmoxian downloader:", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    FILES_(savePath, null, FILE_MANAGER.DELETE, false);
                }
                finished = true;
            });

            downloader.Start();

            while (!finished)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(300);
            }

            return File.Exists(savePath);
        }

        public void SEVENZIP_TASK(string file, string destpath, bool extract)
        {
            bool finished = false;

            System.Threading.Thread szip = new System.Threading.Thread(() =>
            {
                SevenZipBase.SetLibraryPath(L_PATHS.FILES.sevenzipdll);

                if (extract)
                {
                    SevenZipExtractor extract_file = new SevenZipExtractor(file);

                    if (!Directory.Exists(destpath))
                        FILES_(destpath, null, FILE_MANAGER.CREATE, true);

                    try
                    {
                        extract_file.ExtractArchive(destpath);
                    }
                    catch (Exception)
                    {
                        FILES_(destpath, null, FILE_MANAGER.DELETE, true);
                        MessageBox.Show("Error while extracting files!", "Gasmoxian Extractor:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SevenZipCompressor compress_file = new SevenZipCompressor(file);
                    compress_file.ArchiveFormat = OutArchiveFormat.SevenZip;
                    compress_file.CompressionMethod = CompressionMethod.Lzma2;
                    compress_file.CompressionLevel = CompressionLevel.Ultra;

                    compress_file.CompressDirectory(file, destpath);
                }

                finished = true;
            });

            szip.Start();

            while (!finished)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(300);
            }
        }


        
        private static readonly LibVLC audio_player = new LibVLC(new string[]
{
    $"--plugin-path={Path.Combine(L_PATHS.FOLDERS.Datadir,"libvlc", "win-x64", "plugins")}"
});
        private MediaPlayer fx = new MediaPlayer(audio_player);

        //TO DO: ADD SOUND TO PATCH BUTTON AND GIF TOO
        public void PLAY_FX(string sound_name)
        {
            
            if (fx.IsPlaying)
                fx.Stop();

            sound_name = SET_FX_PATH(sound_name);

            if (!File.Exists(sound_name)) return;


            fx.Media?.Dispose();

            var fx_sound = new Media(audio_player, sound_name, FromType.FromPath);



            fx.Media = fx_sound;
            fx.Volume = 40;
            fx.Play();
        }

        public MediaPlayer mediaplayer = new MediaPlayer(audio_player);
        


        
        public void MUSIC_RESTART(object sender, EventArgs e)
        {
            Task.Run(() => PLAY_MUSIC(true));
        }
        public void PLAY_MUSIC(bool play)
        {
            if (play)
            {

                if (mediaplayer.IsPlaying)
                mediaplayer.Stop();



                var launcher_music = new Media(audio_player, Path.Combine(L_PATHS.FOLDERS.Themes, CURRENT_THEME(), "music.mp3"), FromType.FromPath);

                mediaplayer.EndReached -= MUSIC_RESTART;
                mediaplayer.EndReached += MUSIC_RESTART;

                mediaplayer.Volume = 40;
                mediaplayer.Media?.Dispose();
                mediaplayer.Media = launcher_music;
                mediaplayer.Play();
            }
            else
            {
                mediaplayer.Stop();   
            }
        }


        public IniData MANAGE_INI_FILE(string path, IniData settings, bool read)
        { 
            FileIniDataParser parser = new FileIniDataParser();
            parser.Parser.Configuration.AllowDuplicateKeys = true;
            if (!read)
                parser.WriteFile(path, settings);
            else
                return parser.ReadFile(path);
            
            return null;
        }


        public void CREATE_CTR_SETTINGS(string game_ini_path, string duck_settings_path,
            VIDEO_PRESETS quality, RENDER_MODE mode, S_CPU_MODE cpu)
        {
            IniData game_settings = new IniData();

            string[] properties = { "Main", "Console", "PINE", "CPU", "GPU", "Display",
        "CDROM", "Hacks", "BIOS", "MemoryCards", "Folders"};

            string memoryCard = (CURRENT_GAME <= (byte)GAMES.MODDED_OCTR) ?
                "None" : "PerGameTitle";

            string g_spritefilter, g_resolution, multisample;
            g_spritefilter = string.Empty;

            switch (quality)
            {
                default:
                case VIDEO_PRESETS.LOW:
                    g_resolution = "1"; multisample = "1";
                    if (mode == RENDER_MODE.AUTOMATIC) mode = RENDER_MODE.OPENGL;
                    break;
                case VIDEO_PRESETS.MEDIUM:
                    g_resolution = "2"; multisample = "2";
                    if (mode == RENDER_MODE.D3D11) g_spritefilter = SET_TEXTURE_QUALITY(quality, mode);
                    else if (mode == RENDER_MODE.AUTOMATIC) mode = RENDER_MODE.D3D11;
                    break;
                case VIDEO_PRESETS.HIGH:
                    g_resolution = "3"; multisample = "4";
                    if (mode == RENDER_MODE.D3D12) g_spritefilter = SET_TEXTURE_QUALITY(quality, mode);
                    else if (mode == RENDER_MODE.AUTOMATIC) mode = RENDER_MODE.D3D12;
                    break;
                case VIDEO_PRESETS.ULTRA:
                    g_resolution = "5"; multisample = "8";
                    if (mode == RENDER_MODE.VULKAN) { g_resolution = "6"; g_spritefilter = SET_TEXTURE_QUALITY(quality, mode); }
                    else if (mode == RENDER_MODE.AUTOMATIC) mode = RENDER_MODE.VULKAN;
                    break;
            }

            if (mode == RENDER_MODE.SOFTWARE) multisample = "1";

            List<Dictionary<string, string>> all_data = new List<Dictionary<string, string>>
    {
        new Dictionary<string, string> // Main
        {
            ["SettingsVersion"] = "3", ["EmulationSpeed"] = "1", ["FastForwardSpeed"] = "0",
            ["TurboSpeed"] = "0", ["SyncToHostRefreshRate"] = "false", ["IncreaseTimerResolution"] = "true",
            ["InhibitScreensaver"] = "true", ["StartPaused"] = "false", ["StartFullscreen"] = "false",
            ["PauseOnFocusLoss"] = "false", ["PauseOnControllerDisconnection"] = "false",
            ["SaveStateOnExit"] = "false", ["CreateSaveStateBackups"] = "false",
            ["CompressSaveStates"] = "true", ["ConfirmPowerOff"] = "true",
            ["LoadDevicesFromSaveStates"] = "false", ["DisableAllEnhancements"] = "false",
            ["RunaheadFrameCount"] = "0", ["SetupWizardIncomplete"] = "false"
        },
        new Dictionary<string, string> // Console
        {
            ["Region"] = "Auto", ["Enable8MBRAM"] = "true", ["EnableCheats"] = "false"
        },
        new Dictionary<string, string> // PINE
        {
            ["Enabled"] = "true", ["Slot"] = "28011"
        },
        new Dictionary<string, string> // CPU
        {
            ["ExecutionMode"] = SET_CPU_MODE(cpu), ["OverclockEnable"] = "true",
            ["OverclockNumerator"] = "4", ["OverclockDenominator"] = "1",
            ["RecompilerMemoryExceptions"] = "false", ["RecompilerBlockLinking"] = "true",
            ["RecompilerICache"] = "true", ["FastmemMode"] = "MMap"
        },
        new Dictionary<string, string> // GPU
        {
            ["Renderer"] = SET_RENDERMODE(mode), ["ResolutionScale"] = g_resolution,
            ["Multisamples"] = multisample, ["UseDebugDevice"] = "false",
            ["DisableShaderCache"] = "false", ["DisableDualSourceBlend"] = "false",
            ["DisableFramebufferFetch"] = "false", ["DisableTextureBuffers"] = "false",
            ["DisableTextureCopyToSelf"] = "false", ["PerSampleShading"] = "false",
            ["UseThread"] = "true", ["ThreadedPresentation"] = "false",
            ["UseSoftwareRendererForReadbacks"] = "false", ["TrueColor"] = "true",
            ["Debanding"] = "false", ["ScaledDithering"] = "true",
            ["ForceRoundTextureCoordinates"] = "false", ["TextureFilter"] = SET_TEXTURE_QUALITY(quality, mode),
            ["SpriteTextureFilter"] = g_spritefilter, ["LineDetectMode"] = "Disabled",
            ["DownsampleMode"] = "Disabled", ["DownsampleScale"] = "1", ["WireframeMode"] = "Disabled",
            ["DisableInterlacing"] = "true", ["ForceNTSCTimings"] = "false",
            ["WidescreenHack"] = "false", ["ChromaSmoothing24Bit"] = "false",
            ["PGXPEnable"] = "false", ["PGXPCulling"] = "true", ["PGXPTextureCorrection"] = "true",
            ["PGXPColorCorrection"] = "false", ["PGXPVertexCache"] = "false", ["PGXPCPU"] = "false",
            ["PGXPPreserveProjFP"] = "false", ["PGXPTolerance"] = "-1", ["PGXPDepthBuffer"] = "false",
            ["PGXPDisableOn2DPolygons"] = "false", ["PGXPDepthClearThreshold"] = "300"
        },
        new Dictionary<string, string> // Display
        {
            ["DeinterlacingMode"] = "Adaptive", ["CropMode"] = "Overscan",
            ["ActiveStartOffset"] = "0", ["ActiveEndOffset"] = "0",
            ["LineStartOffset"] = "0", ["LineEndOffset"] = "0",
            ["Force4_3For24Bit"] = "false", ["AspectRatio"] = "16:9", ["Alignment"] = "Center",
            ["Scaling"] = "BilinearSmooth", ["OptimalFramePacing"] = "false",
            ["PreFrameSleep"] = "false", ["SkipPresentingDuplicateFrames"] = "false",
            ["PreFrameSleepBuffer"] = "2", ["VSync"] = "false", ["DisableMailboxPresentation"] = "true",
            ["ExclusiveFullscreenControl"] = "Automatic", ["ScreenshotMode"] = "ScreenResolution",
            ["ScreenshotFormat"] = "PNG", ["ScreenshotQuality"] = "85",
            ["CustomAspectRatioNumerator"] = "0", ["ShowOSDMessages"] = "true",
            ["ShowFPS"] = "false", ["ShowSpeed"] = "false", ["ShowResolution"] = "false",
            ["ShowLatencyStatistics"] = "false", ["ShowGPUStatistics"] = "false",
            ["ShowCPU"] = "false", ["ShowGPU"] = "false", ["ShowFrameTimes"] = "false",
            ["ShowStatusIndicators"] = "true", ["ShowInputs"] = "false",
            ["ShowEnhancements"] = "false", ["OSDScale"] = "100", ["StretchVertically"] = "false"
        },
        new Dictionary<string, string> // CDROM
        {
            ["ReadaheadSectors"] = "8", ["MechaconVersion"] = "VC1A", ["RegionCheck"] = "false",
            ["LoadImageToRAM"] = "false", ["LoadImagePatches"] = "false",
            ["MuteCDAudio"] = "false", ["ReadSpeedup"] = "10", ["SeekSpeedup"] = "0"
        },
        new Dictionary<string, string> // Hacks
        {
            ["UseOldMDECRoutines"] = "false", ["DMAMaxSliceTicks"] = "1000",
            ["DMAHaltTicks"] = "100", ["GPUFIFOSize"] = "16",
            ["GPUMaxRunAhead"] = "128", ["ExportSharedMemory"] = "true"
        },
        new Dictionary<string, string> // BIOS
        {
            ["PatchFastBoot"] = "true", ["SearchDirectory"] = "bios"
        },
        new Dictionary<string, string> // MemoryCards
        {
            ["Card1Type"] = memoryCard, ["Card2Type"] = "None",
            ["UsePlaylistTitle"] = "true", ["Directory"] = "memcards"
        },
        new Dictionary<string, string> // Folders
        {
            ["Cache"] = "cache", ["Cheats"] = "cheats", ["Covers"] = "covers",
            ["Dumps"] = "dump", ["GameIcons"] = "gameicons", ["GameSettings"] = "gamesettings",
            ["InputProfiles"] = "inputprofiles", ["SaveStates"] = "savestates",
            ["Screenshots"] = "screenshots", ["Shaders"] = "shaders",
            ["Textures"] = "textures", ["UserResources"] = "resources"
        },
    };

            for (byte i = 0; i < properties.Length; i++)
            {
                if (quality == VIDEO_PRESETS.MANUAL && i >= 4 && i <= 5) continue;
                foreach (var config in all_data[i])
                    game_settings[properties[i]][config.Key] = config.Value;
            }

            MANAGE_INI_FILE(game_ini_path, game_settings, false);

            // 2. read the settings.ini already copied into duck_folder
            IniData duck_settings;
            try
            {
                duck_settings = File.Exists(duck_settings_path)
                    ? MANAGE_INI_FILE(duck_settings_path, null, true)
                    : new IniData();
            }
            catch (Exception)
            {
                // corrupted or unparseable ini: better to boot with defaults than to crash
                duck_settings = new IniData();
            }

            // --- 3. apply only the launcher overrides on top ---
            duck_settings["Main"]["SetupWizardIncomplete"] = "false";
            duck_settings["UI"]["Theme"] = SET_DUCK_COLOR((GAMES)CURRENT_GAME);
            duck_settings["UI"]["CPUOverclockingWarningShown"] = "false";
            duck_settings["AutoUpdater"]["CheckAtStartup"] = "false";
            duck_settings["Cheevos"]["Enabled"] = "false";
            duck_settings["BIOS"]["SearchDirectory"] = "bios";

            // --- 4. save the final settings.ini into duck_folder ---
            MANAGE_INI_FILE(duck_settings_path, duck_settings, false);

        }

        public bool EDIT_YAML(string filepath, string game_name)
        {
            if (!File.Exists(filepath))
            {
                MessageBox.Show("Failed! Can't find DuckStation's gamedb.yaml", "Error:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                YamlStream yaml = new YamlStream();
                using (StreamReader reader = new StreamReader(filepath))
                    yaml.Load(reader);

                YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
                YamlMappingNode gameID = (YamlMappingNode)mapping.Children[new YamlScalarNode("SCUS-94426")];
                gameID.Children[new YamlScalarNode("name")] = new YamlScalarNode(game_name);

                using (StreamWriter writer = new StreamWriter(filepath))
                    yaml.Save(writer, assignAnchors: false);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to edit gamedb.yaml: {ex.Message}", "Error:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public enum GAME_AUDIO : byte
        {
            FX,
            VOICE,
            MUSIC
        };


        public OpenFileDialog SEARCH_FILE_WINDOW(string parameters, OpenFileDialog search)
        {
            search.FilterIndex = 1;
            search.Filter = parameters;

            if (search.ShowDialog() == DialogResult.OK)
            {
                return search;
            }

            return null;
        }

        public async Task SET_ROM_LANG(LANGUAGES lang)
        {
            //sdata->unused_8008d700;
            uint sdata_unused = 0x8008d700;
            byte desired_lang;


            switch (lang)
            {
                default:
                case LANGUAGES.ENGLISH:
                    {
                        desired_lang = 0;
                        break;
                    }
                case LANGUAGES.ESPAÑOL:
                    {
                        desired_lang = 1;
                        break;
                    }
                case LANGUAGES.ITALIANO:
                    {
                        desired_lang = 2;
                        break;
                    }
                case LANGUAGES.PORTUGUÊS:
                    {
                        desired_lang = 3;
                        break;
                    }
                case LANGUAGES.GERMAN:
                    {
                        desired_lang = 4;
                        break;
                    }
            }

            await LOAD_GAME_HACK(sdata_unused, desired_lang, Duck_Mem.types.INT);

        }

        public async Task SET_TURBO_COUNTER(bool enable)
        {
            // no game running means no shared memory to touch (this used to crash when opening settings)
            if (!playing_game || duck_process == null)
                return;

            uint gGT_gameMode2 = 0x80096b28;
            int turboCounter_Cheat = 0x8000000;

            int curr_flags;

            try
            {
                curr_flags = (int)Duck_Mem.Read_DuckShmem(duck_process.Id, gGT_gameMode2, Duck_Mem.types.INT);
            }
            catch (Exception)
            {
                return; // duck closed just now
            }

            if (enable)
                curr_flags |= turboCounter_Cheat;
            else
                curr_flags &= ~(turboCounter_Cheat);


            await LOAD_GAME_HACK(gGT_gameMode2, curr_flags, Duck_Mem.types.INT);
        }


        public async Task LOAD_GAME_HACK(uint address, long value, Duck_Mem.types size)
        {
            bool notFirstTime = true;

            Process duck = duck_process;

            if (!playing_game || duck == null)
                return;

            //sdata->mainGameState
            uint mainGameState = 0x8008d0f4;

            try
            {
                while (playing_game && !duck.HasExited &&
                    (int)Duck_Mem.Read_DuckShmem(duck.Id, mainGameState, Duck_Mem.types.INT) == 0)
                {
                    notFirstTime = false;
                    await Task.Delay(750);
                }

                if (!playing_game || duck.HasExited)
                    return;

                do
                {
                    //write new values with the custom dll that i made
                    Duck_Mem.Write_DuckShmem(duck.Id, address, value, size);

                    if (!notFirstTime)
                        await Task.Delay(550);
                    else
                        break;

                } while (playing_game && !duck.HasExited &&
                    (int)Duck_Mem.Read_DuckShmem(duck.Id, (long)(address), size) != value);
            }
            catch (Exception)
            {
                // duck closed/disposed mid-hack: abort without crashing the launcher
            }
        }


        public async Task MODIFY_GAMEAUDIO(byte value, GAME_AUDIO desired_one)
        {
            uint offset = 0;
            string current_line = string.Empty;

            switch (desired_one)
            {
                case GAME_AUDIO.FX:
                    {
                        //sdata->vol_FX
                        offset = 0x8008d7ac;
                        current_line = S_JSON.Settings.FX_VOLUME;
                        break;
                    }
                case GAME_AUDIO.VOICE:
                    {
                        //sdata->vol_Voice
                        offset = 0x8008d7bc;
                        current_line = S_JSON.Settings.VOICE_VOLUME;
                        break;
                    }
                case GAME_AUDIO.MUSIC:
                    {
                        //sdata->vol_Music
                        offset = 0x8008d7b8;
                        current_line = S_JSON.Settings.MUSIC_VOLUME;
                        break;
                    }
                default:
                    return;
            }



            await LOAD_GAME_HACK(offset, value, Duck_Mem.types.INT);

            REWRITE_JSON_LINE(L_PATHS.FILES.Settings, current_line, value);


        }

        public void FILES_(string file, string dest, FILE_MANAGER operation, bool isfolder)
        {
            switch (operation)
            {
                case FILE_MANAGER.COPY: //copy
                    {
                        if (isfolder)
                        {
                            if (!Directory.Exists(file)) return;

                            string[] subfolders = Directory.GetDirectories(file, "*.*", SearchOption.AllDirectories);
                            List<string> _folders = subfolders.ToList();
                            _folders.Insert(0, file);

                            for (int j = 0; j < _folders.Count; j++)
                            {
                                string[] _files = Directory.GetFiles(_folders[j]);

                                string folderdest = Path.Combine(dest, _folders[j].Substring(file.Length).TrimStart('\\', '/'));

                                if (!Directory.Exists(folderdest))
                                {
                                    Directory.CreateDirectory(folderdest);
                                }

                                for (int i = 0; i < _files.Length; i++)
                                {
                                    File.Copy(_files[i], Path.Combine(folderdest, Path.GetFileName(_files[i])), true);
                                }
                            }
                        }
                        else
                        {
                            if (!File.Exists(file)) return;

                            File.Copy(file, dest, true);
                        }
                        break;
                    }
                case FILE_MANAGER.MOVE: //move
                    {
                        if (isfolder)
                        {
                            if (!Directory.Exists(file)) return;

                            string[] subfolders = Directory.GetDirectories(file, "*.*", SearchOption.AllDirectories);
                            List<string> _folders = subfolders.ToList();
                            _folders.Insert(0, file);

                            for (int j = 0; j < _folders.Count; j++)
                            {
                                string[] _files = Directory.GetFiles(_folders[j]);

                                string folderdest = Path.Combine(dest, _folders[j].Substring(file.Length).TrimStart('\\', '/'));

                                if (!Directory.Exists(folderdest))
                                {
                                    Directory.CreateDirectory(folderdest);
                                }

                                for (int i = 0; i < _files.Length; i++)
                                {
                                    string filedest = Path.Combine(folderdest, Path.GetFileName(_files[i]));

                                    if (File.Exists(filedest))
                                        File.Delete(filedest);

                                    File.Move(_files[i], filedest);
                                }
                            }

                            for (int del = 0; del < _folders.Count; del++)
                            {
                                if (!Directory.Exists(_folders[del])) continue;

                                Directory.Delete(_folders[del], true);
                            }
                        }
                        else
                        {
                            if (!File.Exists(file)) return;

                            if (File.Exists(dest))
                                File.Delete(dest);

                            File.Move(file, dest);
                        }
                        break;
                    }
                case FILE_MANAGER.DELETE: //delete
                    {
                        if (isfolder)
                        {
                            if (!Directory.Exists(file)) return;
                            Directory.Delete(file, true);
                        }
                        else
                        {
                            if (!File.Exists(file)) return;
                            File.Delete(file);
                        }
                        break;
                    }
                case FILE_MANAGER.CREATE: //create
                    {
                        if (isfolder)
                        {
                            if (Directory.Exists(file)) return;

                            Directory.CreateDirectory(file);
                        }
                        else
                        {
                            if (File.Exists(file)) return;

                            File.Create(file).Dispose();
                        }
                        break;
                    }
                case FILE_MANAGER.EXTRACT:
                    {
                        if (!File.Exists(file)) return;

                        SEVENZIP_TASK(file, dest, true);
                        break;
                    }
                case FILE_MANAGER.COMPRESS:
                    {
                        if (!File.Exists(file)) return;

                        SEVENZIP_TASK(file, dest, false);
                        break;
                    }
            }
        }

        public void APPLY_XDELTA_PATCH(string baserom, string xdelta_path, string output)
        {
            Process Patch = null;

            if (xdelta_path == string.Empty)
            {
                MessageBox.Show("No xdelta patch found", "Gasmoxian patcher:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filename = L_PATHS.FILES.xdelta3;
            string args = $"-d -f -s \"{baserom}\" \"{xdelta_path}\" \"{output}\"";

            execute_process(filename, args, L_PATHS.FOLDERS.Root, ref Patch,
                (byte)EXECUTION_MODE.debug_error_output_waitexit);

            if (File.Exists(output) && !IS_MODDED_ONLINE(CURRENT_GAME))
                MessageBox.Show("Patched successfully!", "Gasmoxian patcher:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RELOAD_MAINFORM()
        {
            string[] MainForm_images = {THEME_FILES.MainForm.patchPanel, THEME_FILES.MainForm.playPanel,
                THEME_FILES.MainForm.background, THEME_FILES.MainForm.versionGif};

            LOAD_THEME(MainForm_Controls, MainForm_images, CURRENT_THEME());

        }

        public void RELOAD_DATA(byte section)
        {
            switch (section)
            {
                case (byte)DATA_REGIONS.RELOAD_THEME:
                    {
                        RELOAD_MAINFORM();

                        if (!playing_game)
                        {
                            if (mediaplayer.IsPlaying)
                                PLAY_MUSIC(false);

                            if (!mediaplayer.IsPlaying)
                                PLAY_MUSIC(true);
                        }

                        break;
                    }
                case (byte)DATA_REGIONS.RELOAD_LANG:
                    {
                        LANG = (LANGUAGES)Convert.ToByte(READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.SelectedLanguage));
                        break;
                    }
                case (byte)DATA_REGIONS.CHANGE_GAME:
                    {
                        CURRENT_GAME = Convert.ToByte(READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.SelectedGame));

                        if (CURRENT_GAME == (byte)GAMES.MODDED_GASMOXIAN ||
                             CURRENT_GAME == (byte)GAMES.MODDED_OCTR)
                        {
                            MODS_FOLDER = (CURRENT_GAME == (byte)GAMES.MODDED_OCTR) ?
                                   Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "mods", "octr_mods") : Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "mods");
                        }

                        SERVER_PATH = SET_SERVER_FILE((byte)CURRENT_GAME);
                        CLIENT_PATH = SET_CLIENT_FILE((byte)CURRENT_GAME);
                        break;
                    }
                case (byte)DATA_REGIONS.UPDATE_CUSTOM:
                    {
                        SERVER_PATH = SET_SERVER_FILE((byte)CURRENT_GAME);
                        CLIENT_PATH = SET_CLIENT_FILE((byte)CURRENT_GAME);
                        DUCK_PATH = READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Duck).ToString();
                        break;
                    }
            }
        }

        public string SET_FX_PATH(string name)
        {
            return Path.Combine(L_PATHS.FOLDERS.Themes, CURRENT_THEME(), "fx", name);
        }

        public void SET_LANGUAGE_TO_UI(List<Control> control)
        {
            string curr_lang = LANG.ToString();

            for (byte i = 0; i < control.Count; i++)
            {
                string translated_line = READ_JSON_LINE(L_PATHS.FILES.Langs, $"{control[i].Name}.{curr_lang}").ToString();
                load_text_to_ui(translated_line, control[i]);
            }
        }

        public void LOAD_THEME(List<Control> controls, string[] filenames, string theme_name)
        {

            theme_name = Path.Combine(L_PATHS.FOLDERS.Themes, theme_name);

            string curr_lang = LANG.ToString();

            string lang_image = (LANG == LANGUAGES.ENGLISH) ? string.Empty : curr_lang;

            for (byte i = 0; i < controls.Count; i++)
            {
                bool gif = (Path.GetExtension(filenames[i]) == ".gif");

                bool image_exists = File.Exists(Path.Combine(theme_name, $"{lang_image}{filenames[i]}"));

                if (!image_exists) lang_image = string.Empty;

                load_image_to_ui(Path.Combine(theme_name, $"{lang_image}{filenames[i]}"), controls[i], gif);
            }
        }
        public string SET_CPU_MODE(S_CPU_MODE cpu)
        {
            switch(cpu)
            {
                default:
                case S_CPU_MODE.Recompiler: return "Recompiler";
                case S_CPU_MODE.NewRecompiler: return "NewRec";
                case S_CPU_MODE.CachedInterpreter: return "CachedInterpreter";
            }
        }

        public string SET_RENDERMODE(RENDER_MODE mode)
        {
            switch (mode)
            {
                case RENDER_MODE.AUTOMATIC: return "Automatic"; //unused
                case RENDER_MODE.SOFTWARE: return "Software";
                case RENDER_MODE.D3D11: return "D3D11";
                default:
                case RENDER_MODE.OPENGL: return "OpenGL";
                case RENDER_MODE.D3D12: return "D3D12";
                case RENDER_MODE.VULKAN: return "Vulkan";
            }
        }


        public string SET_TEXTURE_QUALITY(VIDEO_PRESETS quality, RENDER_MODE mode)
        {
            if (mode == RENDER_MODE.SOFTWARE)
                return "Nearest";

            switch (quality)
            {
                default:
                case VIDEO_PRESETS.LOW: return "Nearest";
                case VIDEO_PRESETS.MEDIUM:return "Bilinear";
                case VIDEO_PRESETS.HIGH: return "JINC2";
                case VIDEO_PRESETS.ULTRA: return "xBR";
            }
        }

        // "darkfusion" is duckstation's real default (missing UI\Theme key = darkfusion)
        public const string DUCK_DEFAULT_THEME = "darkfusion";

        public string SET_DUCK_COLOR(GAMES version)
        {
            switch(version)
            {
                case GAMES.GASMOXIAN: return "purplerain";
                case GAMES.ONLINECTR: return "cobaltsky";
                case GAMES.MODDED_GASMOXIAN:
                case GAMES.MODDED_OCTR: return "darkruby";
                default: return DUCK_DEFAULT_THEME;
            }
        }

        // one time per install: remove launcher themes that older versions
        // left stuck in the settings (the infamous permanent purple background)
        public void HEAL_THEME_RESIDUE()
        {
            string marker = Path.Combine(L_PATHS.FOLDERS.Datadir, "theme_fix.txt");

            if (File.Exists(marker)) return;

            string[] launcher_colors = { "purplerain", "cobaltsky", "darkruby", "greymatter" };

            List<string> inis = new List<string>
            {
                Path.Combine(L_PATHS.FOLDERS.Essential, "duckcfg.ini"),
                Path.Combine(L_PATHS.FOLDERS.Essential, "duckcfg_last.ini")
            };

            // duck's own settings only if it isn't running
            if (!string.IsNullOrEmpty(DUCK_PATH) && File.Exists(DUCK_PATH) &&
                Process.GetProcessesByName(Path.GetFileNameWithoutExtension(DUCK_PATH)).Length == 0)
            {
                inis.Add(Path.Combine(Path.GetDirectoryName(DUCK_PATH), "settings.ini"));
            }

            foreach (string ini in inis)
            {
                if (!File.Exists(ini)) continue;

                try
                {
                    IniData data = MANAGE_INI_FILE(ini, null, true);
                    string theme = data["UI"]["Theme"];

                    if (theme != null && launcher_colors.Contains(theme))
                    {
                        data["UI"]["Theme"] = DUCK_DEFAULT_THEME;
                        MANAGE_INI_FILE(ini, data, false);
                    }
                }
                catch (Exception) { }
            }

            FILES_(marker, null, FILE_MANAGER.CREATE, false);
        }

        public string CURRENT_THEME()
        {
            return READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Settings.SelectedTheme).ToString();
        }

        public bool IS_MODDED_ONLINE(byte version)
        {
            if (version == (byte)GAMES.MODDED_GASMOXIAN ||
                version == (byte)GAMES.MODDED_OCTR) return true;

            return false;
        }

        public string[] SET_ONLINE_MODDED_ROM_LIST()
        {
            return Directory.GetFiles(MODS_FOLDER, "*.bin");
        }

        public string SET_BASE_ROM_FORMODS(byte version)
        {
            if (version == (byte)GAMES.MODDED_GASMOXIAN) return SET_ROM_FILE((byte)GAMES.GASMOXIAN, null);
            else if (version == (byte)GAMES.MODDED_OCTR) return SET_ROM_FILE((byte)GAMES.ONLINECTR, null);
            else return VANILLA_ROM_PATH;
        }


        public string SET_PATCH_FILE(byte version, string mod_name)
        {
            switch (version)
            {
                case (byte)GAMES.GASMOXIAN: return Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "gasmoxian.xdelta");
                case (byte)GAMES.ONLINECTR: return Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "official.xdelta");
                case (byte)GAMES.MODDED_GASMOXIAN:
                case (byte)GAMES.MODDED_OCTR:
                case (byte)GAMES.ANY_ONLINE_MODDED: return Path.Combine(MODS_FOLDER, mod_name + ".xdelta");
                case (byte)GAMES.CUSTOM_ONLINE:
                case (byte)GAMES.MODDED_OFFLINE: return READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Xdelta).ToString();
                case (byte)GAMES.VANILLA_CTR: return string.Empty;
            }

            return string.Empty;
        }

        public string SET_SERVER_FILE(byte version)
        {
            switch (version)
            {
                case (byte)GAMES.MODDED_GASMOXIAN:
                case (byte)GAMES.GASMOXIAN: return Path.Combine(L_PATHS.FOLDERS.Host, "GServer.exe");
                case (byte)GAMES.MODDED_OCTR:
                case (byte)GAMES.ONLINECTR: return Path.Combine(L_PATHS.FOLDERS.Host, "ofserver.exe");
                case (byte)GAMES.CUSTOM_ONLINE: return READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Server).ToString();

                case (byte)GAMES.MODDED_OFFLINE: return string.Empty;
                case (byte)GAMES.VANILLA_CTR: return string.Empty;
            }
            return string.Empty;
        }

        public string[] GET_LAUNCHER_THEMES()
        {
            return Directory.GetDirectories(L_PATHS.FOLDERS.Themes);
        }

        public string SET_CLIENT_FILE(byte version)
        {
            switch (version)
            {
                case (byte)GAMES.MODDED_GASMOXIAN:
                case (byte)GAMES.GASMOXIAN: return Path.Combine(L_PATHS.FOLDERS.Datadir, "GClient.exe");
                case (byte)GAMES.MODDED_OCTR:
                case (byte)GAMES.ONLINECTR: return Path.Combine(L_PATHS.FOLDERS.Datadir, "official.exe");
                case (byte)GAMES.CUSTOM_ONLINE: return READ_JSON_LINE(L_PATHS.FILES.Settings, S_JSON.Custom.Client).ToString();

                case (byte)GAMES.MODDED_OFFLINE: return string.Empty;
                case (byte)GAMES.VANILLA_CTR: return string.Empty;
            }
            return string.Empty;
        }

        public string SET_ROM_FILE(byte version, string mod_name)
        {
            switch (version)
            {
                case (byte)GAMES.GASMOXIAN: return Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "GASMOXIAN.bin");
                case (byte)GAMES.ONLINECTR: return Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "officialonline.bin");
                case (byte)GAMES.CUSTOM_ONLINE: return Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "custom.bin");
                case (byte)GAMES.MODDED_GASMOXIAN:
                case (byte)GAMES.MODDED_OCTR:
                case (byte)GAMES.ANY_ONLINE_MODDED: return Path.Combine(MODS_FOLDER, $"{mod_name}.bin");
                case (byte)GAMES.MODDED_OFFLINE: return Path.Combine(L_PATHS.FOLDERS.Launcher_Rompath, "modded_offline.bin");
                case (byte)GAMES.VANILLA_CTR: return VANILLA_ROM_PATH;
            }

            return string.Empty;
        }

        public static readonly JObject languages = new JObject
        {
            ["fscreen_ch"] = new JObject
            {
                [LANGUAGES.ENGLISH.ToString()] = "FULLSCREEN",
                [LANGUAGES.ESPAÑOL.ToString()] = "PANTALLA COMPLETA",
                [LANGUAGES.ITALIANO.ToString()] = "FULLSCREEN",
                [LANGUAGES.PORTUGUÊS.ToString()] = "TELA CHEIA",
                [LANGUAGES.ARABIC.ToString()] = "شاشة كاملة",
                [LANGUAGES.GERMAN.ToString()] = "VOLLBILD",
                [LANGUAGES.JAPANESE.ToString()] = "フルスクリーン"

            },
            ["turboc_ch"] = new JObject
            {
                [LANGUAGES.ENGLISH.ToString()] = "TURBO COUNTER",
                [LANGUAGES.ESPAÑOL.ToString()] = "CONTADOR DE TURBO",
                [LANGUAGES.ITALIANO.ToString()] = "CONTATORE TURBO",
                [LANGUAGES.PORTUGUÊS.ToString()] = "CONTADOR TURBO",
                [LANGUAGES.ARABIC.ToString()] = "عداد توربو",
                [LANGUAGES.GERMAN.ToString()] = "TURBOZÄHLER",
                [LANGUAGES.JAPANESE.ToString()] = "ターボカウンター"
            },
            ["low_b"] = new JObject
            {
                [LANGUAGES.ENGLISH.ToString()] = "LOW",
                [LANGUAGES.ESPAÑOL.ToString()] = "BAJO",
                [LANGUAGES.ITALIANO.ToString()] = "BASSA",
                [LANGUAGES.PORTUGUÊS.ToString()] = "BAIXO",
                [LANGUAGES.ARABIC.ToString()] = "منخفض",
                [LANGUAGES.GERMAN.ToString()] = "NIEDRIG",
                [LANGUAGES.JAPANESE.ToString()] = "低い"
            },
            ["med_b"] = new JObject
            {
                [LANGUAGES.ENGLISH.ToString()] = "MEDIUM",
                [LANGUAGES.ESPAÑOL.ToString()] = "MEDIO",
                [LANGUAGES.ITALIANO.ToString()] = "MEDIA",
                [LANGUAGES.PORTUGUÊS.ToString()] = "MÉDIO",
                [LANGUAGES.ARABIC.ToString()] = "متوسط",
                [LANGUAGES.GERMAN.ToString()] = "MITTEL",
                [LANGUAGES.JAPANESE.ToString()] = "中程度"
            },
            ["high_b"] = new JObject
            {
                [LANGUAGES.ENGLISH.ToString()] = "HIGH",
                [LANGUAGES.ESPAÑOL.ToString()] = "ALTO",
                [LANGUAGES.ITALIANO.ToString()] = "ALTA",
                [LANGUAGES.PORTUGUÊS.ToString()] = "ALTO",
                [LANGUAGES.ARABIC.ToString()] = "عالي",
                [LANGUAGES.GERMAN.ToString()] = "HOCH",
                [LANGUAGES.JAPANESE.ToString()] = "高い"
            },
            ["ultra_b"] = new JObject
            {
                [LANGUAGES.ENGLISH.ToString()] = "ULTRA",
                [LANGUAGES.ESPAÑOL.ToString()] = "ULTRA",
                [LANGUAGES.ITALIANO.ToString()] = "ULTRA",
                [LANGUAGES.PORTUGUÊS.ToString()] = "ULTRA",
                [LANGUAGES.ARABIC.ToString()] = "فائق",
                [LANGUAGES.GERMAN.ToString()] = "ULTRA",
                [LANGUAGES.JAPANESE.ToString()] = "ウルトラ"
            },
        };

        public static readonly JObject gamesettings = new JObject
        {
            [S_JSON.JSON_FORMAT.Settings.self] = new JObject
            {
                [S_JSON.JSON_FORMAT.Settings.CpuMode] = 0,
                [S_JSON.JSON_FORMAT.Settings.GraphicProfile] = 0,
                [S_JSON.JSON_FORMAT.Settings.GraphicQuality] = 0,
                [S_JSON.JSON_FORMAT.Settings.FX_VOLUME] = 127,
                [S_JSON.JSON_FORMAT.Settings.VOICE_VOLUME] = 127,
                [S_JSON.JSON_FORMAT.Settings.MUSIC_VOLUME] = 127,
                [S_JSON.JSON_FORMAT.Settings.FullScreen] = 0,
                [S_JSON.JSON_FORMAT.Settings.TurboCounter] = 0,
                [S_JSON.JSON_FORMAT.Settings.SelectedLanguage] = 0,
                [S_JSON.JSON_FORMAT.Settings.Nickname] = "Gasmoxian",
                [S_JSON.JSON_FORMAT.Settings.SelectedGame] = 0
            },
            [S_JSON.JSON_FORMAT.Theme.self] = new JObject
            {
                [S_JSON.JSON_FORMAT.Theme.SelectedTheme] = "default"
            },

            [S_JSON.JSON_FORMAT.Rom.self] = new JObject
            {
                [S_JSON.JSON_FORMAT.Rom.RomPath] = ""
            },
            [S_JSON.JSON_FORMAT.CustomPaths.self] = new JObject
            {
                [S_JSON.JSON_FORMAT.CustomPaths.Mod] = "",
                [S_JSON.JSON_FORMAT.CustomPaths.Client] = "",
                [S_JSON.JSON_FORMAT.CustomPaths.Server] = "",
                [S_JSON.JSON_FORMAT.CustomPaths.Xdelta] = "",
                [S_JSON.JSON_FORMAT.CustomPaths.Duck] = ""
            },
            [S_JSON.JSON_FORMAT.Version.self] = new JObject
            {
                [S_JSON.JSON_FORMAT.Version.LauncherVersion] = Launcher_ver.ToString(),
                [S_JSON.JSON_FORMAT.Version.GasmoxianVersion] = "1.0.0",
                [S_JSON.JSON_FORMAT.Version.GClientVersion] = "1.0.0",
                [S_JSON.JSON_FORMAT.Version.GServerVersion] = "1.0.0"
            }
        };
    }
}