# PingIPandHostTester
[![CodeFactor](https://www.codefactor.io/repository/github/lloyd99901/pingipandhosttester/badge)](https://www.codefactor.io/repository/github/lloyd99901/pingipandhosttester)

You can check if an Ip/host/address or an IP/host/address and port are online.

## Usage
pingporthosttester.exe IP:Port Number
or
pingporthosttester.exe IP
Examples:
pingporthosttester.exe 127.0.0.1:8080
pingporthosttester.exe 127.0.0.1

If TCPClient returns true, this means that the IP/Website/Other and the Port number is online.
If TCPClient returns false, this means that the IP/Website/Other and the Port number is offline or can't be reached.
If TCPClient returns an error, this means that you probably typed the ip/port wrong or the ip/website/other can't be reached.
