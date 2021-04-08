Imports System.Net.Sockets

Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        rtbInfo.Document.Blocks.Clear()
        If tbIP.Text.Contains(":") Then
            rtbInfo.AppendText(vbNewLine & "Info: TcpClient returned: " & PingHost(tbIP.Text.Split(":"c)(0), tbIP.Text.Split(":"c)(1)))

        Else
            Try
                If My.Computer.Network.Ping(tbIP.Text, 2000) Then
                    rtbInfo.AppendText(vbNewLine & "Info: IP PING returned true")
                    recColor.Fill = New SolidColorBrush(Color.FromArgb(255, 0, 255, 0))

                Else
                    rtbInfo.AppendText(vbNewLine & "Info: IP PING returned false!")
                    recColor.Fill = New SolidColorBrush(Color.FromArgb(255, 255, 0, 0))
                End If
            Catch ex As Exception
                rtbInfo.AppendText(vbNewLine & "Error: " & ex.ToString)
                recColor.Fill = New SolidColorBrush(Color.FromArgb(255, 255, 0, 0))
                For Each arg As String In tbIP.Text
                    rtbInfo.AppendText(vbNewLine & "Debug Information (For Developer): " & arg)
                Next

            End Try
        End If
    End Sub
    Public Function PingHost(ByVal hostUri As String, ByVal portNumber As Integer) As Boolean
        Try
            rtbInfo.AppendText(vbNewLine)
            Using client = New TcpClient(hostUri, portNumber)
                rtbInfo.AppendText("Client Connected: " & client.Connected.ToString & vbNewLine)
                rtbInfo.AppendText("Client Available: " & client.Available.ToString & vbNewLine)
                rtbInfo.AppendText("Client Buffer Size: " & client.ReceiveBufferSize.ToString & vbNewLine)
                rtbInfo.AppendText("Client Timeout: " & client.ReceiveTimeout.ToString & vbNewLine)
                rtbInfo.AppendText("Client Scoket Type: " & client.Client.SocketType.ToString & vbNewLine)
                rtbInfo.AppendText("Client Protocol Type: " & client.Client.ProtocolType.ToString & vbNewLine)
                rtbInfo.AppendText("Client Address Family: " & client.Client.AddressFamily.ToString & vbNewLine)

                Return True
            End Using

        Catch ex As SocketException
            rtbInfo.AppendText("Connection could not be established. This means that the host isn't running or can't be reached.")
            rtbInfo.AppendText("Socket Error when pinging host:'" & hostUri & ":" & portNumber.ToString() & "'")
            rtbInfo.AppendText(vbNewLine & "Technical Information: " & vbNewLine & vbNewLine & ex.ToString)
            Return False
        Catch ex1 As Exception
            rtbInfo.AppendText("An error occurred during connection of the host! This means that the program had an error and stopped during the connection.")
            rtbInfo.AppendText("Exception Error has occurred when pinging host:'" & hostUri & ":" & portNumber.ToString() & "'")
            rtbInfo.AppendText("Technical Information: " & vbNewLine & vbNewLine & ex1.ToString)
            Return False
        End Try
    End Function

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        rtbInfo.IsReadOnly = True
    End Sub

    Private Sub RtbInfo_TextChanged(sender As Object, e As TextChangedEventArgs) Handles rtbInfo.TextChanged
        rtbInfo.ScrollToEnd()
    End Sub

    Private Sub TbIP_KeyDown(sender As Object, e As KeyEventArgs) Handles tbIP.KeyDown
        If e.Key = Key.Enter Then
            Button_Click(Me, Nothing)
        End If
    End Sub
End Class
