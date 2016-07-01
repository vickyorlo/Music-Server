namespace MusicServer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.playButton = new System.Windows.Forms.Button();
            this.playlistTextBox = new System.Windows.Forms.TextBox();
            this.tbProgress = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.addNickelback = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.artistBox = new System.Windows.Forms.TextBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(12, 176);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(212, 49);
            this.playButton.TabIndex = 6;
            this.playButton.Text = "Play music";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // playlistTextBox
            // 
            this.playlistTextBox.Location = new System.Drawing.Point(12, 12);
            this.playlistTextBox.Multiline = true;
            this.playlistTextBox.Name = "playlistTextBox";
            this.playlistTextBox.ReadOnly = true;
            this.playlistTextBox.Size = new System.Drawing.Size(212, 158);
            this.playlistTextBox.TabIndex = 7;
            // 
            // tbProgress
            // 
            this.tbProgress.Location = new System.Drawing.Point(230, 12);
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.ReadOnly = true;
            this.tbProgress.Size = new System.Drawing.Size(228, 20);
            this.tbProgress.TabIndex = 8;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(230, 38);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(228, 23);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Listen for players";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // addNickelback
            // 
            this.addNickelback.Location = new System.Drawing.Point(230, 119);
            this.addNickelback.Name = "addNickelback";
            this.addNickelback.Size = new System.Drawing.Size(228, 23);
            this.addNickelback.TabIndex = 11;
            this.addNickelback.Text = "Add song manually";
            this.addNickelback.UseVisualStyleBackColor = true;
            this.addNickelback.Click += new System.EventHandler(this.addNickelback_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(12, 231);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(212, 44);
            this.pauseButton.TabIndex = 12;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // artistBox
            // 
            this.artistBox.Location = new System.Drawing.Point(230, 67);
            this.artistBox.Name = "artistBox";
            this.artistBox.Size = new System.Drawing.Size(228, 20);
            this.artistBox.TabIndex = 13;
            this.artistBox.Text = "Artist";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(230, 93);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(228, 20);
            this.titleBox.TabIndex = 14;
            this.titleBox.Text = "Title";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 281);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(212, 49);
            this.clearButton.TabIndex = 15;
            this.clearButton.Text = "Clear the playlist";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 338);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.artistBox);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.addNickelback);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tbProgress);
            this.Controls.Add(this.playlistTextBox);
            this.Controls.Add(this.playButton);
            this.Name = "Form1";
            this.Text = "WAI Music Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox playlistTextBox;
        private System.Windows.Forms.TextBox tbProgress;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button addNickelback;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.TextBox artistBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Button clearButton;
    }
}

