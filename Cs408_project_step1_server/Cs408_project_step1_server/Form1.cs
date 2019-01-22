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

namespace Cs408_project_step1_server
{
    public partial class Form1 : Form
    {
        
        private static IPEndPoint localEndPoint ;
        private static Socket listener ;
        private static List<Client> clients = new List<Client>();
        private static List<bool> hasSentMessage = new List<bool>();
        private static List<string> answersAndQuestion = new List<string>();
        private static List<int> scoreList = new List<int>();
        private readonly object clientsLock = new object();

        private static int turnIndex = 0;
        private static bool gameNotStarted = true;
        private static bool gameFinished = false;
        private static int currentRound = 0;
        private static int roundCount;

        private static Thread listenThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Int32.Parse(textBoxPort.Text);
                startServer(port);
                listenThread = new Thread(startListening);
                listenThread.Start();
                buttonStartServer.Enabled = false;
                textBoxPort.Enabled = false;
            }
            catch
            {
                Invoke(new Action(() => { writeToRichTextBox("Please enter an integer port number"); }));
            }
            
            
        }
        public void startServer(int port){
            try {
                //ipHostInfo = Dns.Resolve(Dns.GetHostName());  
                //ipAddress = ipHostInfo.AddressList[0];  
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                localEndPoint = new IPEndPoint(IPAddress.Any, port);
                Invoke(new Action(() => { writeToRichTextBox("Server opened."); }));  
            }
            catch(Exception ex){
                Invoke(new Action(() => { writeToRichTextBox(ex.ToString()); }));   
            }
        }
        
        public void startListening(){
            
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                Invoke(new Action(() => { writeToRichTextBox("Started listening for connecting clients."); }));
                
                //accept clients until there 2 clients connected
                while (gameNotStarted)
                {
                    Console.Write(gameNotStarted);
                    Socket newClientSocket = listener.Accept();
                    Client newClient = new Client("", newClientSocket);
                    newClient.name = newClient.receiveMessage();
                    Thread newCLientListenThread = new Thread(() => clientListenThread(newClient));
                    newCLientListenThread.Start();


                    bool acceptable = true;
                    lock (clientsLock)
                    {
                        foreach (Client cl in clients)
                        {
                            if (newClient.name == cl.name)
                            {
                                acceptable = false;
                                Invoke(new Action(() => { writeToRichTextBox("New client with name : " + newClient.name + " can't join because her name already exists."); }));
                                newClient.sendMessage("Your name already exists. Pick another name.");
                            }
                        }
                    }
                    

                    if (acceptable && gameNotStarted)
                    {
                        lock (clientsLock)
                        {
                            clients.Add(newClient);
                        }
                        newClient.sendMessage("You connected to server.");
                        sendMessageToAllClients("New client with name : " + newClient.name + " connected.");
                        
                    }                    
                }
            }
            catch(Exception e)
            {
                Invoke(new Action(() => { writeToRichTextBox("Error occured while listening to connections. Error message:\n" + e.ToString()); }));
            }
            Console.Write("Stopped listening for client connections.\n");
            
        }


        public void clientListenThread(Client client)
        {
            while (!gameFinished || gameNotStarted)
            {
                try
                {
                    string message = client.receiveMessage();

                    if (message == "DISCONNECT")
                    {
                        bool isDisconnectorAsker = clients.IndexOf(client) == turnIndex;
                        lock (clientsLock)
                        {
                            //we have to remove the client information from multiple lists thats why we call a free function here
                            RemoveClient(client);
                        }
                        sendMessageToAllClients(client.name + " " + "has disconnected.");

                        if (!gameNotStarted)
                        {
                            lock (clientsLock)
                            {
                                if (clients.Count < 2)
                                {
                                    gameFinished = true;
                                    gameNotStarted = false;
                                    clients[0].sendMessage("You win.");
                                    clients[0].sendMessage("Game ends.");
                                }
                                //check if the disconnector was asking question
                                else if(isDisconnectorAsker)
                                {
                                    sendMessageToAllClients("New asker : " + clients[turnIndex].name);
                                    clients[turnIndex].sendMessage("You are asking this turn.");
                                    sendMessageToAllClientsExceptOne("You are answering this turn.", clients[turnIndex]);
                                }
                            }
                        }
                        
                        return;
                    }
                    //then it means that this is a question or an answer
                    else if(!gameFinished)
                    {
                        int indexOfClient = clients.IndexOf(client);
                        if (indexOfClient == turnIndex)
                        {
                            string questionAnswer = message;
                            string question = questionAnswer.Substring(0, questionAnswer.IndexOf(':'));
                            string answer = questionAnswer.Substring(questionAnswer.IndexOf(':') + 1);
                            sendMessageToAllClientsExceptOne("Question: "+question, client);
                        }
                        hasSentMessage[indexOfClient] = true;
                        answersAndQuestion[indexOfClient] = message;
                        bool allHasSent = true;
                        for (int i = 0; i < hasSentMessage.Count; i++)
                        {
                            if (!hasSentMessage[i])
                            {
                                allHasSent = false;
                                break;
                            }
                        }
                        if (allHasSent)
                        {
                            Thread handleAnswerThread = new Thread(handleAnswers);
                            handleAnswerThread.Start();
                        }
                    }
                }
                catch(SocketException ex)
                {

                }
                catch(Exception ex)
                {
                    writeToRichTextBox(ex.ToString());
                }
            }
            Console.Write("Stopped listening for client " + client.name+"\n");
        }
        public void RemoveClient(Client client)
        {
            int indexOfClient = clients.IndexOf(client);
            clients.Remove(client);
            Console.Write("Index of client : " + indexOfClient.ToString() + " client count : " + clients.Count.ToString() + "\n");
            if(turnIndex > indexOfClient)
            {
                turnIndex = (turnIndex - 1) % clients.Count;
            }
            //means that last client in the client list disconnected
            else if(indexOfClient  == clients.Count)
            {
                turnIndex = 0;
            }
            if (!gameNotStarted)
            {
                hasSentMessage.RemoveAt(indexOfClient);
                answersAndQuestion.RemoveAt(indexOfClient);
                scoreList.RemoveAt(indexOfClient);
            }
            
        }
        public void sendMessageToAllClients(string message)
        {
            writeToRichTextBox(message);
            lock (clientsLock)
            {
                foreach (Client client in clients)
                {
                    client.sendMessage(message);
                }
            }
            
        }
        public void sendMessageToAllClientsExceptOne(string message, Client clientX)
        {
            lock(clientsLock)
            {
                foreach (Client client in clients)
                {
                    if (clientX != client)
                    {
                        client.sendMessage(message);
                    }

                }
            }
            
        }
        private void handleAnswers() {

            string questionAnswer = answersAndQuestion[turnIndex];
            string question = questionAnswer.Substring(0, questionAnswer.IndexOf(':'));
            string answer = questionAnswer.Substring(questionAnswer.IndexOf(':') + 1); 
            for(int i=0; i < clients.Count; i++)
            {
                if (i != turnIndex)
                {
                    if(answersAndQuestion[i] != answer)
                    {
                        sendMessageToAllClients(clients[i].name + " Answered Wrongly");
                    }
                    else
                    {
                        scoreList[i] += 1;
                        sendMessageToAllClients(clients[i].name + " Answered Correctly");
                    }
                }
            }
            for (int i = 0; i < clients.Count; i++)
            {
                hasSentMessage[i] = false;
            }
            string scores = "";
            turnIndex = (turnIndex + 1) % clients.Count;
            for (int i = 0; i < scoreList.Count; i++)
            {
                scores += clients[i].name + " : " + scoreList[i].ToString() + "\n";

            }
            sendMessageToAllClientsExceptOne("You are answering this turn.", clients[turnIndex]);
            clients[turnIndex].sendMessage("You are asking this turn.");
            
            sendMessageToAllClients(scores);
            if(currentRound + 2 <= roundCount)
            {
                sendMessageToAllClients("Round : " + (currentRound + 2).ToString());
                writeToRichTextBox(clients[turnIndex].name + " is asking this turn.");
            }
            
            if (++currentRound == roundCount)
            {
                gameFinished = true;
                gameNotStarted = false;
                int maxScore = -1;
                for (int i = 0; i < scoreList.Count; i++)
                {
                    if(scoreList[i] > maxScore)
                    {
                        maxScore = scoreList[i];
                    }
                }
                List<int> winnerIndexes = new List<int>();
                for (int i = 0; i < scoreList.Count; i++)
                {
                    if (scoreList[i] == maxScore)
                    {
                        winnerIndexes.Add(i);
                    }
                }
                string winnerMessage = "";
                foreach(int index in winnerIndexes)
                {
                    winnerMessage += clients[index].name + " wins with a score of : " + scoreList[index] + "\n";
                }
                sendMessageToAllClients(winnerMessage);
                sendMessageToAllClients("Game ends.");
                return;
            }
            
        }

        
        private void buttonClearStatusBox_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "";
        }
        public void writeToRichTextBox(string message)
        {
            Invoke(new Action(() =>
            {
                richTextBoxStatus.Text += message + "\n";
                richTextBoxStatus.SelectionStart = richTextBoxStatus.Text.Length;
                // scroll it automatically
                richTextBoxStatus.ScrollToCaret();
            }));
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            int clientCount;
            lock (clientsLock)
            {
                clientCount = clients.Count;
            }
            //means that game should start
            if (clientCount > 1)
            {
                
                try
                {
                    string numRounds = textBoxNumRounds.Text;
                    if(numRounds == "")
                    {
                        writeToRichTextBox("Please enter a valid number for number of rounds.");
                        return;
                    }
                    roundCount = Int32.Parse(numRounds);
                    gameNotStarted = false;
                    clients.Sort((x, y) => x.name.CompareTo(y.name));
                    sendMessageToAllClients("Game started.");
                    clients[turnIndex].sendMessage("You are asking this turn.");
                    writeToRichTextBox("Client : " + clients[0].name + " is asking this turn.");
                    sendMessageToAllClients("Round : " + (currentRound + 1).ToString());
                    sendMessageToAllClientsExceptOne("You are answering this turn.", clients[turnIndex]);
                    for(int i = 0; i < clients.Count; i++)
                    {
                        answersAndQuestion.Add("");
                        hasSentMessage.Add(false);
                        scoreList.Add(0);
                    }
                }
                catch (FormatException ex)
                {
                    writeToRichTextBox("Please enter a valid number for number of rounds.");
                }
                catch(Exception ex)
                {
                    writeToRichTextBox(ex.ToString());
                }


            }
            else
            {
                writeToRichTextBox("There are not enough players to start the game.");
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                sendMessageToAllClients("SERVER SHUTDOWN.");
                foreach(Client client in clients)
                {
                    client.socket.Close();
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { writeToRichTextBox(ex.ToString()); }));
            }

        }
    }
}
