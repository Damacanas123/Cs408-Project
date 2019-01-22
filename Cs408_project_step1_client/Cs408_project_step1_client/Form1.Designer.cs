namespace Cs408_project_step1_client
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
            this.textBoxIpAddress = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConnectServer = new System.Windows.Forms.Button();
            this.richTextBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAnswer = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSendAction = new System.Windows.Forms.Button();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonClearStatus = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIpAddress
            // 
            this.textBoxIpAddress.Location = new System.Drawing.Point(112, 33);
            this.textBoxIpAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxIpAddress.Name = "textBoxIpAddress";
            this.textBoxIpAddress.Size = new System.Drawing.Size(92, 20);
            this.textBoxIpAddress.TabIndex = 0;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(112, 67);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(92, 20);
            this.textBoxPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // buttonConnectServer
            // 
            this.buttonConnectServer.Location = new System.Drawing.Point(223, 33);
            this.buttonConnectServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConnectServer.Name = "buttonConnectServer";
            this.buttonConnectServer.Size = new System.Drawing.Size(76, 41);
            this.buttonConnectServer.TabIndex = 4;
            this.buttonConnectServer.Text = "Connect to Server";
            this.buttonConnectServer.UseVisualStyleBackColor = true;
            this.buttonConnectServer.Click += new System.EventHandler(this.buttonConnectServer_Click);
            // 
            // richTextBoxQuestion
            // 
            this.richTextBoxQuestion.Enabled = false;
            this.richTextBoxQuestion.Location = new System.Drawing.Point(112, 161);
            this.richTextBoxQuestion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxQuestion.Name = "richTextBoxQuestion";
            this.richTextBoxQuestion.Size = new System.Drawing.Size(187, 51);
            this.richTextBoxQuestion.TabIndex = 6;
            this.richTextBoxQuestion.Text = "";
            // 
            // richTextBoxAnswer
            // 
            this.richTextBoxAnswer.Enabled = false;
            this.richTextBoxAnswer.Location = new System.Drawing.Point(112, 239);
            this.richTextBoxAnswer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxAnswer.Name = "richTextBoxAnswer";
            this.richTextBoxAnswer.Size = new System.Drawing.Size(187, 51);
            this.richTextBoxAnswer.TabIndex = 7;
            this.richTextBoxAnswer.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Your question:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Your answer:";
            // 
            // buttonSendAction
            // 
            this.buttonSendAction.Enabled = false;
            this.buttonSendAction.Location = new System.Drawing.Point(188, 308);
            this.buttonSendAction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSendAction.Name = "buttonSendAction";
            this.buttonSendAction.Size = new System.Drawing.Size(111, 30);
            this.buttonSendAction.TabIndex = 10;
            this.buttonSendAction.Text = "Send Question";
            this.buttonSendAction.UseVisualStyleBackColor = true;
            this.buttonSendAction.Click += new System.EventHandler(this.buttonSendAction_Click);
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(338, 44);
            this.richTextBoxStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(242, 294);
            this.richTextBoxStatus.TabIndex = 11;
            this.richTextBoxStatus.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Status:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(112, 103);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(92, 20);
            this.textBoxName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name:";
            // 
            // buttonClearStatus
            // 
            this.buttonClearStatus.Location = new System.Drawing.Point(482, 10);
            this.buttonClearStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClearStatus.Name = "buttonClearStatus";
            this.buttonClearStatus.Size = new System.Drawing.Size(98, 30);
            this.buttonClearStatus.TabIndex = 15;
            this.buttonClearStatus.Text = "Clear Status";
            this.buttonClearStatus.UseVisualStyleBackColor = true;
            this.buttonClearStatus.Click += new System.EventHandler(this.buttonClearStatus_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(223, 81);
            this.buttonDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(76, 42);
            this.buttonDisconnect.TabIndex = 16;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 361);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonClearStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.buttonSendAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxAnswer);
            this.Controls.Add(this.richTextBoxQuestion);
            this.Controls.Add(this.buttonConnectServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIpAddress);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Client Side Connector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIpAddress;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConnectServer;
        private System.Windows.Forms.RichTextBox richTextBoxQuestion;
        private System.Windows.Forms.RichTextBox richTextBoxAnswer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSendAction;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonClearStatus;
        private System.Windows.Forms.Button buttonDisconnect;
    }
}

