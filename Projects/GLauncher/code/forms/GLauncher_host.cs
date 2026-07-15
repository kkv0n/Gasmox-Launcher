using GLauncher.functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using static GLauncher.functions.GLauncher_functions;

namespace GLauncher.code.forms
{
    public partial class GLauncher_host : Form
    {
        GLauncher_functions funcs;
        public GLauncher_host(GLauncher_functions funcsRef)
        {
            InitializeComponent();
            funcs = funcsRef;
            funcs.LOAD_THEME(new List<Control> { groupBox1 }, new String[] { THEME_FILES.HostForm.background }, funcs.CURRENT_THEME());
            this.FormClosed += new FormClosedEventHandler(GO_BACK);
            LOAD_FILE_TO_UI();



        }

        string dataFile = L_PATHS.FILES.privatesv_IPfile;


        void LOAD_FILE_TO_UI()
        {
            string[] lines = new string[2];

            string[] file = new string[2];

            if (File.Exists(dataFile))
                file = File.ReadAllLines(dataFile);

           for (byte i = 0; i < file.Length; i++)
            {
                lines[i] = file[i];
            }

           ip_tbox.Text = lines[0];
            port_tbox.Text = lines[1];

        }

        void OPEN_RADMIN(object sender, EventArgs e)
        {
            string link = DOWNLOAD_LINKS.RadminVPN;
            string path = Path.Combine(L_PATHS.FOLDERS.Host, "radmin.exe");
            Process radmin = null;

            if (!File.Exists(path))
            {
                DialogResult download_rad = MessageBox.Show("Radmin.exe not found, do you want to download it?", "RADMIN VPN FOR SERVER HOSTING",MessageBoxButtons.YesNo);
                string message = "Radmin VPN downloaded successfully!";

                if (download_rad == DialogResult.Yes)
                {
                    if (funcs.DOWNLOAD_FILE(link, path, message, true))
                        funcs.execute_process(path, null, L_PATHS.FOLDERS.Root, ref radmin, (byte)EXECUTION_MODE.window_waitexit);
                }
                else
                {
                    return;
                }
            }

            if (radmin != null)
            {
                radmin.Dispose();
                radmin = null;
            }

            funcs.execute_process(path, null, L_PATHS.FOLDERS.Root, ref radmin, (byte)EXECUTION_MODE.window_nowait);

        }

        void OPEN_SERVER_FILE(object sender, EventArgs e)
        {
            Process Gserver = null;
            funcs.execute_process(funcs.SERVER_PATH, null, L_PATHS.FOLDERS.Root, ref Gserver, (byte)EXECUTION_MODE.window_nowait);
        }

        void CLOSE_THIS(object sender, EventArgs e)
        {
            this.Close();
        }

        void GO_BACK(object sender, EventArgs e)
        {
            funcs.MainForm.Show();
        }

        void WRITE_ANY_TEXT(object sender, EventArgs e)
        {
            

            TextBox curr = sender as TextBox;


            if (!File.Exists(dataFile))
                funcs.FILES_(dataFile, null, FILE_MANAGER.CREATE, false);

            string newText = string.Empty;



            if (sender == ip_tbox)
            {
                newText = $"{curr.Text}{Environment.NewLine}{port_tbox.Text}";
            }
            else if (sender == port_tbox)
            {
                int port;

                bool number = int.TryParse(curr.Text, out port);

                port = port % 65535;

                if (port > 0)
                    curr.Text = port.ToString();

                if (!number)
                    curr.Text = string.Empty;

                newText = $"{ip_tbox.Text}{Environment.NewLine}{curr.Text}";

            }

            File.WriteAllText(dataFile, newText);
        }
    }
}
