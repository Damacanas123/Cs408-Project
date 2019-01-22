using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cs408_project_step1_client
{
    public partial class Form1 : Form
    {
        private static bool asking = false;
        private static bool listening = true;
        private static Socket socket;
        private static bool gameStarted = false;
        public Form1()
        {
            InitializeComponent();
            buttonDisconnect.Enabled = false;
            textBoxIpAddress.Text = "127.0.0.1";
            textBoxPort.Text = "3333";
        }

        private void buttonConnectServer_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text == "")
            {
                writeToRichTextBox("Your name cannot be empty.");
                return;
            }
            try
            {
                string ipAdd = textBoxIpAddress.Text;
                int port = Int32.Parse(textBoxPort.Text);
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPAddress ipAddress = IPAddress.Parse(ipAdd);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP  socket.  
                socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipAdd, port);
                
                this.Text = "Client Side Connector - Client Name: " + textBoxName.Text;
                buttonConnectServer.BackColor = Color.Green;
                buttonConnectServer.Text = "Connected";
                buttonDisconnect.Enabled = true;
                listening = true;


                // Send the data through the socket.  
                sendArbitraryLengthMessage(textBoxName.Text);
                buttonConnectServer.Enabled = false;
                Thread receiveMessageThread = new Thread(receiveMessage);
                receiveMessageThread.Start();
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { writeToRichTextBox(ex.ToString()); }));
                buttonConnectServer.BackColor = Color.Red;
            }
        }

        private void buttonClearStatus_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "";
        }

        private void receiveMessage()
        {
            while (listening)
            {
                try
                {
                    string message = ReceiveArbitraryLengthMessage();
                    Invoke(new Action(() => { writeToRichTextBox("Server : \n" + message); }));
                    if (message.Contains("Game started."))
                    {
                        gameStarted = true;
                        Invoke(new Action(() => { buttonSendAction.Enabled = true; }));
                   
                    }
                    else if (message.Contains("You are asking this turn."))
                    {
                        Invoke(new Action(() => {
                            buttonSendAction.Enabled = true;
                            buttonSendAction.Text = "Send question";
                            richTextBoxQuestion.Enabled = true;
                            richTextBoxAnswer.Enabled = true;
                            asking = true;
                        }));
                      
                    }
                    else if (message.Contains("You are answering this turn."))
                    {
                        Invoke(new Action(() => {
                            buttonSendAction.Enabled = true;
                            buttonSendAction.Text = "Send answer";
                            richTextBoxQuestion.Enabled = false;
                            richTextBoxAnswer.Enabled = true;
                            asking = false;
                        }));

                    }
                    else if (message.Contains("Your name already exists. Pick another name."))
                    {
                        Invoke(new Action(() => {
                            buttonConnectServer.Enabled = true;
                            buttonConnectServer.BackColor = Color.Red;
                            buttonConnectServer.Text = "Connect to Server";
                            buttonDisconnect.Enabled = false;
                        }));

                    }
                    else if (message.Contains("Game ends.") || message.Contains("SERVER SHUTDOWN."))
                    {
                        Invoke(new Action(() => {
                            listening = false;
                            socket.Close();
                            buttonDisconnect.Enabled = false;
                            Invoke(new Action(() => {
                                buttonConnectServer.BackColor = default(Color);
                                buttonConnectServer.Enabled = true;
                                buttonConnectServer.Text = "Connect to Server";
                                buttonSendAction.Enabled = false;
                                richTextBoxQuestion.Text = "";
                                richTextBoxAnswer.Text = "";
                                richTextBoxQuestion.Enabled = false;
                                richTextBoxAnswer.Enabled = false;
                                writeToRichTextBox("You disconnected.");
                            }));
                        }));

                    }

                }
                catch (Exception ex)
                {
                    if (listening)
                    {
                        Invoke(new Action(() => { writeToRichTextBox("Error in receive thread : \n" + ex.ToString()); }));
                    }
                    listening = false;
                }
            }
        }

        private void buttonSendAction_Click(object sender, EventArgs e)
        {
            if(richTextBoxAnswer.Text == "")
            {
                writeToRichTextBox("Your answer cannot be empty.");
                return;
            }
            if(asking && richTextBoxQuestion.Text == "")
            {
                writeToRichTextBox("Your question cannot be empty.");
                return;
            }
            buttonSendAction.Enabled = false;

            if (asking)
            {
                sendArbitraryLengthMessage(richTextBoxQuestion.Text + ":" + richTextBoxAnswer.Text);
            }
            else
            {
                sendArbitraryLengthMessage(richTextBoxAnswer.Text);
            }
            
        }
        private void sendArbitraryLengthMessage(string message)
        {
            int messageLength = message.Length;
            byte[] intBytes = BitConverter.GetBytes(messageLength);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;
            
            // First send of the length of the message in 4 bytes
            int bytesSent = socket.Send(result);
            byte[] msg = Encoding.ASCII.GetBytes(message);
            //then send the message itself
            socket.Send(msg);
        }

        private string ReceiveArbitraryLengthMessage()
        {
            //first receive the length of the incoming message in 4 bytes(integer)
            byte[] messageLengthByte = new byte[4];
            socket.Receive(messageLengthByte);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(messageLengthByte);
            int messageLengthInt = BitConverter.ToInt32(messageLengthByte, 0);


            //then receive the message string
            byte[] messageByte = new byte[messageLengthInt];
            int k = socket.Receive(messageByte);
            string message = Encoding.ASCII.GetString(messageByte, 0, k);
            return message;
        }

        public void writeToRichTextBox(string message)
        {
            richTextBoxStatus.Text += message + "\n";
            richTextBoxStatus.SelectionStart = richTextBoxStatus.Text.Length;
            // scroll it automatically
            richTextBoxStatus.ScrollToCaret();
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                listening = false;
                sendArbitraryLengthMessage("DISCONNECT");
                socket.Close();
                buttonDisconnect.Enabled = false;
                Invoke(new Action(() => {
                    buttonConnectServer.BackColor = default(Color);
                    buttonConnectServer.Enabled = true;
                    buttonConnectServer.Text = "Connect to Server";
                    buttonSendAction.Enabled = false;
                    richTextBoxQuestion.Text = "";
                    richTextBoxAnswer.Text = "";
                    richTextBoxQuestion.Enabled = false;
                    richTextBoxAnswer.Enabled = false;
                    writeToRichTextBox("You disconnected.");
                    if (gameStarted)
                    {
                        buttonConnectServer.Enabled = false;
                    }
                }));
            }
            catch(Exception ex)
            {
                Invoke(new Action(() => {writeToRichTextBox(ex.ToString()); }));
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                listening = false;
                sendArbitraryLengthMessage("DISCONNECT");
                socket.Close();
                buttonDisconnect.Enabled = false;
                Invoke(new Action(() =>
                {
                    buttonConnectServer.BackColor = default(Color);
                    buttonConnectServer.Enabled = true;
                    buttonConnectServer.Text = "Connect to Server";
                    writeToRichTextBox("You disconnected.");
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { writeToRichTextBox(ex.ToString()); }));
            }
            
        }
    }
}
