using SequenceInstaller.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SequenceInstaller
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Directory |directory";
            dialog.Title = "Select directory";
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = false;
            dialog.FileName = "Select folder!";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(dialog.FileName);
                if (!path.EndsWith("/") && !path.EndsWith("\\")) path += "\\";
                path += "Sequence";
                path_line.Text = path;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label_description.Visible)
            {
                welcome_label.Text = "Installation...";
                label_description.Text = "Please, don't close this window!";
                label_path.Text = "Downloading...";
                download_progress.Visible = true;
                path_line.Visible = false;
                button_select_path.Visible = false;
                install_button.Visible = false;
                install_button.Text = "Finish";
                desktop_shortcut.Visible = false;
                start_menu_shortcut.Visible = false;
                if (!Directory.Exists(path_line.Text))
                {
                    Directory.CreateDirectory(path_line.Text);
                }
                if (File.Exists(path_line.Text))
                {

                }
                StartDownload("https://www.dropbox.com/scl/fi/q5q6zx2nk63ulone6x762/java.zip?rlkey=leg8er2mcclapzfglff3a23vi&st=iypvemuk&dl=1");
            }
            else
            {
                if (launch_checkbox.Checked)
                {
                    launch();
                }
            }
        }
        private void launch()
        {
            string path = path_line.Text;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            /*startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;*/
            startInfo.FileName = Path.Combine(path, "sequence.jar");
            process.StartInfo = startInfo;
            process.Start();
            this.Close();
        }
        private void StartDownload(string url)
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url), Path.Combine(path_line.Text, "archive.zip"));
            });
            thread.Start();
        }
        void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                download_progress_label.Text = Math.Round(percentage, 1) + "%";
                download_progress.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                installation_progress.Visible = true;
                installation_label.Visible = true;
                download_progress_label.Visible = false;
                label_path.Text = "Download complete.";
                Unzip(Path.Combine(path_line.Text, "archive.zip"), path_line.Text);
            });
        }
        private void AppShortcutToDesktop(string path,string linkName)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            IWshShortcut shortcut = (IWshShortcut)m_type.InvokeMember("CreateShortcut", System.Reflection.BindingFlags.InvokeMethod, null, m_shell, new object[] { Path.Combine(deskDir, "Sequence.lnk") });
            shortcut.Description = "Shortcut to Sequence";
            shortcut.TargetPath = Path.Combine(path, "sequence.jar");
            shortcut.IconLocation = Path.Combine(path, "icon.ico");
            shortcut.Save();
        }
        private static Type m_type = Type.GetTypeFromProgID("WScript.Shell");
        private static object m_shell = Activator.CreateInstance(m_type);

        [ComImport, TypeLibType((short)0x1040), Guid("F935DC23-1CF0-11D0-ADB9-00C04FD58A0B")]
        private interface IWshShortcut
        {
            [DispId(0)]
            string FullName { [return: MarshalAs(UnmanagedType.BStr)][DispId(0)] get; }
            [DispId(0x3e8)]
            string Arguments { [return: MarshalAs(UnmanagedType.BStr)][DispId(0x3e8)] get; [param: In, MarshalAs(UnmanagedType.BStr)][DispId(0x3e8)] set; }
            [DispId(0x3e9)]
            string Description { [return: MarshalAs(UnmanagedType.BStr)][DispId(0x3e9)] get; [param: In, MarshalAs(UnmanagedType.BStr)][DispId(0x3e9)] set; }
            [DispId(0x3ea)]
            string Hotkey { [return: MarshalAs(UnmanagedType.BStr)][DispId(0x3ea)] get; [param: In, MarshalAs(UnmanagedType.BStr)][DispId(0x3ea)] set; }
            [DispId(0x3eb)]
            string IconLocation { [return: MarshalAs(UnmanagedType.BStr)][DispId(0x3eb)] get; [param: In, MarshalAs(UnmanagedType.BStr)][DispId(0x3eb)] set; }
            [DispId(0x3ec)]
            string RelativePath { [param: In, MarshalAs(UnmanagedType.BStr)][DispId(0x3ec)] set; }
            [DispId(0x3ed)]
            string TargetPath { [return: MarshalAs(UnmanagedType.BStr)][DispId(0x3ed)] get; [param: In, MarshalAs(UnmanagedType.BStr)][DispId(0x3ed)] set; }
            [DispId(0x3ee)]
            int WindowStyle { [DispId(0x3ee)] get; [param: In][DispId(0x3ee)] set; }
            [DispId(0x3ef)]
            string WorkingDirectory { [return: MarshalAs(UnmanagedType.BStr)][DispId(0x3ef)] get; [param: In, MarshalAs(UnmanagedType.BStr)][DispId(0x3ef)] set; }
            [TypeLibFunc((short)0x40), DispId(0x7d0)]
            void Load([In, MarshalAs(UnmanagedType.BStr)] string PathLink);
            [DispId(0x7d1)]
            void Save();
        }
        private void AppShortcutToStartMenu(string path, string linkName)
        {
            string deskDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu), "Programs");

            IWshShortcut shortcut = (IWshShortcut)m_type.InvokeMember("CreateShortcut", System.Reflection.BindingFlags.InvokeMethod, null, m_shell, new object[] { Path.Combine(deskDir, "Sequence.lnk") });
            shortcut.Description = "Shortcut to Sequence";
            shortcut.TargetPath = Path.Combine(path, "sequence.jar");
            shortcut.IconLocation = Path.Combine(path, "icon.ico");
            shortcut.Save();
        }
        async void Unzip(string filePath, string extractPath)
        {
            var fileList = new List<ZipArchiveEntry>();
            var filesExtracted = 0;

            using (var archive = await Task.Run(() => ZipFile.OpenRead(filePath)))
            {
                foreach (var file in archive.Entries)
                {
                    fileList.Add(file);
                }

                foreach (var file in fileList)
                {
                    var path = $"{Path.Combine(extractPath,file.FullName.Replace('/', Path.DirectorySeparatorChar))}";
                    var isDir = path.EndsWith(Path.DirectorySeparatorChar.ToString());
                    if (isDir) Directory.CreateDirectory($"{path}");
                    else file.ExtractToFile($"{path}", true);
                    filesExtracted++;
                    var progress = Convert.ToInt32(100 * filesExtracted / fileList.Count);
                    installation_progress.Value = progress;
                    installation_progress_label.Text = progress + "%";
                }
            }
            File.Delete(filePath);
            if (desktop_shortcut.Checked)
            {
                AppShortcutToDesktop(extractPath, "Sequence");
            }
            if (start_menu_shortcut.Checked)
            {
                AppShortcutToStartMenu(extractPath, "Sequence");
            }
                ;
            welcome_label.Text = "Installation complete!";
            installation_label.Visible = false;
            installation_progress.Visible = false;
            installation_progress_label.Visible = false;
            download_progress.Visible = false;
            download_progress_label.Visible = false;
            label_path.Visible = false;
            label_description.Visible = false;
            launch_checkbox.Visible = true;
            install_button.Visible = true;
        }
    }
}
