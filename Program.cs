using System;
using Renci.SshNet;
using System.IO;

namespace SFTP_Upload
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProcess();
        }
        
        public static void StartProcess() {
            string host = "13.67.70.136";
            int port = 22;
            string username = "SFTP_User"; //Case Sensitive
            string password = "Password!";
            string filePath = @"C:\Users\vyshag.v\Downloads\Webp.net-resizeimage.jpg";

            SftpClient client = new SftpClient(host, port, username, password);
            client.BufferSize = 1024;
            PrintMessage("Connect to server...");
            client.Connect();
            PrintMessage("Connection successful :)");

            PrintMessage("Creating FileStream object to stream a file");
            FileStream fs = new FileStream(filePath, FileMode.Open);

            PrintMessage("Uploading to server");
            client.UploadFile(fs, Path.GetFileName(filePath));

            PrintMessage("Finished");
            client.Dispose();

            Console.Read();
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
