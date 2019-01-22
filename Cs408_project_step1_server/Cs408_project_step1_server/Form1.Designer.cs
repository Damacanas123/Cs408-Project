namespace Cs408_project_step1_server
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.buttonClearStatusBox = new System.Windows.Forms.Button();
            this.textBoxNumRounds = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(64, 6);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(76, 20);
            this.textBoxPort.TabIndex = 1;
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(67, 80);
            this.richTextBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(488, 213);
            this.richTextBoxStatus.TabIndex = 2;
            this.richTextBoxStatus.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(34, 39);
            this.buttonStartServer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(76, 28);
            this.buttonStartServer.TabIndex = 4;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // buttonClearStatusBox
            // 
            this.buttonClearStatusBox.Location = new System.Drawing.Point(421, 51);
            this.buttonClearStatusBox.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClearStatusBox.Name = "buttonClearStatusBox";
            this.buttonClearStatusBox.Size = new System.Drawing.Size(134, 25);
            this.buttonClearStatusBox.TabIndex = 5;
            this.buttonClearStatusBox.Text = "Clear Status Box";
            this.buttonClearStatusBox.UseVisualStyleBackColor = true;
            this.buttonClearStatusBox.Click += new System.EventHandler(this.buttonClearStatusBox_Click);
            // 
            // textBoxNumRounds
            // 
            this.textBoxNumRounds.Location = new System.Drawing.Point(293, 9);
            this.textBoxNumRounds.Name = "textBoxNumRounds";
            this.textBoxNumRounds.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumRounds.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Num Rounds:";
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(303, 43);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(75, 23);
            this.buttonStartGame.TabIndex = 8;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 319);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNumRounds);
            this.Controls.Add(this.buttonClearStatusBox);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Server Side Connector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Button buttonClearStatusBox;
        private System.Windows.Forms.TextBox textBoxNumRounds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStartGame;
    }
}

