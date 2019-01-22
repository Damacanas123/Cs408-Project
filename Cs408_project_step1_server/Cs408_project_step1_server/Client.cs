using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cs408_project_step1_server
{
    public class Client
    {
        public string name;
        public Socket socket;

        public Client(string name, Socket socket)
        {
            this.name = name;
            this.socket = socket;
        }

        public bool isActive()
        {

            try
            {
                try
                {
                    return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
                }
                catch (SocketException) { return false; }
            }
            catch (SocketException) { return false; }
        }

        public void sendMessage(string message)
        {
            int messageLength = message.Length;
            byte[] intBytes = BitConverter.GetBytes(messageLength);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;

            // First send of the length of the message in 4 bytes
            int bytesSent = this.socket.Send(result);
            byte[] msg = Encoding.ASCII.GetBytes(message);
            //then send the message itself
            this.socket.Send(msg);
        }
        public string receiveMessage()
        {
            byte[] messageLengthByte = new byte[4];
            this.socket.Receive(messageLengthByte);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(messageLengthByte);
            int messageLengthInt = BitConverter.ToInt32(messageLengthByte, 0);

            byte[] messageByte = new byte[messageLengthInt];
            int k = this.socket.Receive(messageByte);
            string message = Encoding.ASCII.GetString(messageByte, 0, k);
            return message;
        }
    }
}
