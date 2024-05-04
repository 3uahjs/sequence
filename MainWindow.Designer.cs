using System;
using System.IO;

namespace SequenceInstaller
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.install_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_select_path = new System.Windows.Forms.Button();
            this.label_path = new System.Windows.Forms.Label();
            this.path_line = new System.Windows.Forms.TextBox();
            this.start_menu_shortcut = new System.Windows.Forms.CheckBox();
            this.desktop_shortcut = new System.Windows.Forms.CheckBox();
            this.label_description = new System.Windows.Forms.Label();
            this.welcome_label = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.download_progress = new System.Windows.Forms.ProgressBar();
            this.download_progress_label = new System.Windows.Forms.Label();
            this.installation_progress_label = new System.Windows.Forms.Label();
            this.installation_progress = new System.Windows.Forms.ProgressBar();
            this.installation_label = new System.Windows.Forms.Label();
            this.launch_checkbox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // install_button
            // 
            this.install_button.Location = new System.Drawing.Point(218, 369);
            this.install_button.Name = "install_button";
            this.install_button.Size = new System.Drawing.Size(54, 30);
            this.install_button.TabIndex = 0;
            this.install_button.Text = "Install";
            this.install_button.UseVisualStyleBackColor = true;
            this.install_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.launch_checkbox);
            this.panel1.Controls.Add(this.installation_progress_label);
            this.panel1.Controls.Add(this.installation_progress);
            this.panel1.Controls.Add(this.installation_label);
            this.panel1.Controls.Add(this.download_progress_label);
            this.panel1.Controls.Add(this.download_progress);
            this.panel1.Controls.Add(this.button_select_path);
            this.panel1.Controls.Add(this.label_path);
            this.panel1.Controls.Add(this.path_line);
            this.panel1.Controls.Add(this.start_menu_shortcut);
            this.panel1.Controls.Add(this.desktop_shortcut);
            this.panel1.Controls.Add(this.label_description);
            this.panel1.Controls.Add(this.welcome_label);
            this.panel1.Controls.Add(this.picture);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 351);
            this.panel1.TabIndex = 1;
            // 
            // button_select_path
            // 
            this.button_select_path.Location = new System.Drawing.Point(221, 160);
            this.button_select_path.Name = "button_select_path";
            this.button_select_path.Size = new System.Drawing.Size(25, 22);
            this.button_select_path.TabIndex = 7;
            this.button_select_path.Text = "...";
            this.button_select_path.UseVisualStyleBackColor = true;
            this.button_select_path.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_path
            // 
            this.label_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_path.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label_path.Location = new System.Drawing.Point(17, 132);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(134, 26);
            this.label_path.TabIndex = 6;
            this.label_path.Text = "Installation path:";
            this.label_path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // path_line
            // 
            this.path_line.Location = new System.Drawing.Point(18, 161);
            this.path_line.Name = "path_line";
            this.path_line.Size = new System.Drawing.Size(197, 20);
            this.path_line.TabIndex = 5;
            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                   Environment.OSVersion.Platform == PlatformID.MacOSX)
    ? Environment.GetEnvironmentVariable("HOME")
    : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            this.path_line.Text = Path.Combine(homePath, "Sequence");
            // 
            // start_menu_shortcut
            // 
            this.start_menu_shortcut.Checked = true;
            this.start_menu_shortcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.start_menu_shortcut.Location = new System.Drawing.Point(19, 228);
            this.start_menu_shortcut.Name = "start_menu_shortcut";
            this.start_menu_shortcut.Size = new System.Drawing.Size(225, 24);
            this.start_menu_shortcut.TabIndex = 4;
            this.start_menu_shortcut.Text = "Create Start Menu shortcut";
            this.start_menu_shortcut.UseVisualStyleBackColor = true;
            // 
            // desktop_shortcut
            // 
            this.desktop_shortcut.Checked = true;
            this.desktop_shortcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.desktop_shortcut.Location = new System.Drawing.Point(18, 198);
            this.desktop_shortcut.Name = "desktop_shortcut";
            this.desktop_shortcut.Size = new System.Drawing.Size(225, 24);
            this.desktop_shortcut.TabIndex = 3;
            this.desktop_shortcut.Text = "Create Desktop shortcut";
            this.desktop_shortcut.UseVisualStyleBackColor = true;
            // 
            // label_description
            // 
            this.label_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_description.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label_description.Location = new System.Drawing.Point(15, 61);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(229, 60);
            this.label_description.TabIndex = 2;
            this.label_description.Text = "You have to make some decisions before installation.";
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // welcome_label
            // 
            this.welcome_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcome_label.Location = new System.Drawing.Point(15, 13);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(229, 48);
            this.welcome_label.TabIndex = 1;
            this.welcome_label.Text = "Welcome to Sequence installer!";
            this.welcome_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picture
            // 
            this.picture.BackgroundImage = global::SequenceInstaller.Properties.Resources.sequence1;
            this.picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture.Location = new System.Drawing.Point(3, 275);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(254, 73);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // download_progress
            // 
            this.download_progress.Location = new System.Drawing.Point(18, 160);
            this.download_progress.Name = "download_progress";
            this.download_progress.Size = new System.Drawing.Size(225, 23);
            this.download_progress.TabIndex = 8;
            this.download_progress.Visible = false;
            // 
            // download_progress_label
            // 
            this.download_progress_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.download_progress_label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.download_progress_label.Location = new System.Drawing.Point(157, 132);
            this.download_progress_label.Name = "download_progress_label";
            this.download_progress_label.Size = new System.Drawing.Size(86, 26);
            this.download_progress_label.TabIndex = 9;
            this.download_progress_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // installation_progress_label
            // 
            this.installation_progress_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.installation_progress_label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.installation_progress_label.Location = new System.Drawing.Point(157, 200);
            this.installation_progress_label.Name = "installation_progress_label";
            this.installation_progress_label.Size = new System.Drawing.Size(86, 26);
            this.installation_progress_label.TabIndex = 12;
            this.installation_progress_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // installation_progress
            // 
            this.installation_progress.Location = new System.Drawing.Point(18, 228);
            this.installation_progress.Name = "installation_progress";
            this.installation_progress.Size = new System.Drawing.Size(225, 23);
            this.installation_progress.TabIndex = 11;
            this.installation_progress.Visible = false;
            // 
            // installation_label
            // 
            this.installation_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.installation_label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.installation_label.Location = new System.Drawing.Point(17, 200);
            this.installation_label.Name = "installation_label";
            this.installation_label.Size = new System.Drawing.Size(134, 26);
            this.installation_label.TabIndex = 10;
            this.installation_label.Text = "Installing...";
            this.installation_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.installation_label.Visible = false;
            // 
            // launch_checkbox
            // 
            this.launch_checkbox.Location = new System.Drawing.Point(18, 124);
            this.launch_checkbox.Name = "launch_checkbox";
            this.launch_checkbox.Size = new System.Drawing.Size(223, 34);
            this.launch_checkbox.TabIndex = 13;
            this.launch_checkbox.Text = "Launch Sequence";
            this.launch_checkbox.UseVisualStyleBackColor = true;
            this.launch_checkbox.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(284, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.install_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 450);
            this.MinimumSize = new System.Drawing.Size(300, 450);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sequence Installer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button install_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.CheckBox start_menu_shortcut;
        private System.Windows.Forms.CheckBox desktop_shortcut;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TextBox path_line;
        private System.Windows.Forms.Button button_select_path;
        private System.Windows.Forms.Label installation_progress_label;
        private System.Windows.Forms.ProgressBar installation_progress;
        private System.Windows.Forms.Label installation_label;
        private System.Windows.Forms.Label download_progress_label;
        private System.Windows.Forms.ProgressBar download_progress;
        private System.Windows.Forms.CheckBox launch_checkbox;
        private System.ComponentModel.ComponentResourceManager resources;
    }
}

