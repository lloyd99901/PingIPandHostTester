using System;
using System.Net.Sockets;

static class Module1
{
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(Environment.NewLine + " ---Ping IP/Host and Port Tester - LunarHunter 2019--- " + Environment.NewLine);
        Console.ResetColor();

        try
        {
            if (args[0].ToLower().Contains("help") | args[0].Contains("?"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Usage:");
                Console.ResetColor();
                Console.WriteLine("pingporthosttester IP:Port Number");
                Console.WriteLine("e.g.: pingporthosttester 127.0.0.1:80");
                Console.WriteLine("Help:");
                Console.WriteLine("If TCPClient returns true, this means that the IP/Website/Other and the Port number is online.");
                Console.WriteLine("If TCPClient returns false, this means that the IP/Website/Other and the Port number is offline or can't be reached.");
                Console.WriteLine("If TCPClient returns an error, this means that you probably typed the ip/port wrong or the ip/website/other can't be reached.");
                Environment.Exit(0);
            }
        }
        catch (Exception)
        {
        }

        if (args.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usage:");
            Console.ResetColor();
            Console.WriteLine("pingporthosttester IP:Port Number");
            Console.WriteLine("or");
            Console.WriteLine("pingporthosttester IP");
            Console.WriteLine("e.g.: pingporthosttester 127.0.0.1");
            Console.WriteLine("Help:");
            Console.WriteLine("If TCPClient returns true, this means that the IP/Website/Other and the Port number is online.");
            Console.WriteLine("If TCPClient returns false, this means that the IP/Website/Other and the Port number is offline or can't be reached.");
            Console.WriteLine("If TCPClient returns an error, this means that you probably typed the ip/port wrong or the ip/website/other can't be reached.");
            Environment.Exit(0);
        }
        else if (args[0].Contains(":"))
        {
            string ip = args[0].Split(':')[0];
            int port = int.Parse(args[0].Split(':')[1]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "Info: TcpClient returned: " + PingHost(ip, port));
            Console.ResetColor();
        }
        else
            try
            {
                System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                if (p.Send(args[0], 500).Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Environment.NewLine + "Info: IP PING returned true");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Environment.NewLine + "Info: IP PING returned false!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "Error: " + ex.ToString());
                Console.ResetColor();
                foreach (string arg in args)
                {
                    Console.WriteLine(Environment.NewLine + "Debug Information (For Developer): " + arg);
                }
            }
    }
    public static bool PingHost(string hostUri, int portNumber)
    {
        try
        {
            using (var client = new TcpClient(hostUri, portNumber))
            {
                return true;
            }
        }
        catch (SocketException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Connection could not be established. This means that the host isn't running or can't be reached.");
            Console.WriteLine("Socket Error when pinging host:'" + hostUri + ":" + portNumber.ToString() + "'");
            Console.WriteLine(Environment.NewLine + "Technical Information: " + Environment.NewLine + Environment.NewLine + ex.ToString());
            return false;
        }
        catch (Exception ex1)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("An error occurred during connection of the host! This means that the program had an error and stopped during the connection.");
            Console.WriteLine("Exception Error has occurred when pinging host:'" + hostUri + ":" + portNumber.ToString() + "'");
            Console.WriteLine("Technical Information: " + Environment.NewLine + Environment.NewLine + ex1.ToString());
            return false;
        }
    }
}
