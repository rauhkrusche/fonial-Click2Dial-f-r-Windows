''' <summary>
''' Stellt Fukntionen zum Anrufaufbau für fonial Cloud-TK Anlagen zur verfügung.
''' </summary>
Public Class fonial
    Private Const url_base As String = "https://kundenkonto.fonial.de/api/2.0/call/initiate/direct"
    Private Const url_id As String = "?id="
    Private Const url_guid As String = "&guid="
    Private url_target As String = "&ip-target="
    Private Const url_number As String = "&number="

    ''' <summary>
    ''' Baut eine Verbindung zu einer Telefonnummer vom gewünschten Endgerät (Druchwahl) aus auf.
    ''' </summary>
    ''' <param name="id">fonial Kundennummer</param>
    ''' <param name="guid">generische Identifikationsnummer für die fonial-API (erhältlich per Support-Ticket)</param>
    ''' <param name="target">Durchwahl des Gerätes, von welchem aus der Anruf getätigt werden soll</param>
    ''' <param name="number">Zielrufnummer</param>
    ''' <returns></returns>
    Public Function phonecall(ByRef id As String, ByRef guid As String, ByRef target As String, ByRef number As String) As String
        If target Is Nothing Xor number Is Nothing Then
            Throw New ArgumentNullException()
            Exit Function
        End If
        Dim url As String = url_base + url_id + id + url_guid + guid + url_target + target + url_number + number
        Dim client As New System.Net.WebClient
        Dim response As String = client.DownloadString(url)
        Return response

    End Function
End Class
