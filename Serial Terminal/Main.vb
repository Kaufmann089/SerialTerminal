Imports System.IO.Ports
Imports System.Threading

Module Main

    Public _serialportio As New SerialPort 'für iO zur Freigabe Erkennung


    Public Function Freigabe(ByRef CTS As Boolean)
        CTS = False

        Try
            If _serialportio.IsOpen = False Then OpenPortIO()
            If _serialportio.IsOpen = True Then
                CTS = _serialportio.CtsHolding
            End If
        Catch ex As Exception
            MsgBox("Fehler Freigabe abfragen: " & ex.ToString)
        End Try
        'If g_FreigabeOverride = True Then CTS = True


    End Function

    Public Function OpenPortIO()


        Try
            If _serialportio.IsOpen = False Then
                _serialportio.PortName = "COM10"
                _serialportio.BaudRate = 19200
                _serialportio.Parity = Parity.None
                _serialportio.DataBits = 8
                _serialportio.StopBits = 1
                _serialportio.DtrEnable = True
                _serialportio.Handshake = Handshake.None
                _serialportio.NewLine = vbCrLf
                _serialportio.Open()

            End If
        Catch ex As Exception
            ' fehlernachricht_neu("Fehler PortIO Com 7 öffnen: " & ex.ToString)
            MsgBox("Fehler Port öffnen:  " & ex.ToString)
        End Try

    End Function
End Module
