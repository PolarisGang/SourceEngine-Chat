Imports System.ComponentModel
Imports System.Runtime.InteropServices
Public Class Form1

    <DllImport("user32.dll")>
    Public Shared Function GetAsyncKeyState(ByVal vKey As Keys) As Short
    End Function

    'Variables
    Private GamePath() As String = New String() {
        "Counter-Strike Global Offensive\csgo\cfg",
        "Counter-Strike Source\cstrike\cfg"}
    Private ConfigDir As String
    Private KeyBind As String
    Private ChatCount As Integer = 0
    Private WelcomeMsg() As String = New String() {"Clear" & vbCrLf &
        "echo PolarisGang: SourceEngine Chat" & vbCrLf &
        "echo -----------------------------------------------------------" & vbCrLf &
        "echo Spam chat with -> ", vbCrLf &
        "echo -----------------------------------------------------------" & vbCrLf &
        "echo Source -> Github.com/PolarisGang"}

    Private Function FindSteam() As Boolean
        For Each p As Process In Process.GetProcesses()
            If Not p.ProcessName = "Steam" Then Continue For
            Dim file As String
            Try
                file = p.Modules(0).FileName
            Catch ex As Exception

            End Try
            file = file.Replace("Steam.exe", "steamapps\common\")
            Try
                If IO.Directory.Exists(file) Then
                    ConfigDir = file
                    Return True
                End If
            Catch x2 As Exception
                Return False
            End Try
        Next
        End
        Return False
    End Function

    Private Sub ChatMsg_KeyDown(sender As Object, e As KeyEventArgs) Handles ChatMsg.KeyDown
        If GetAsyncKeyState(Keys.Enter) <> 0 Then AddBtn.PerformClick()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not FindSteam() Then
            MyDialog.ShowDialog()
            ConfigDir = MyDialog.SelectedPath
        End If
        For i As Integer = 0 To GamePath.Length - 1
            If IO.File.Exists(ConfigDir + GamePath(i) + "\ChatSpam.cfg") Then
                Using myReader As New IO.StreamReader(ConfigDir + GamePath(i) + "\ChatSpam.cfg")
                    ChatConfig.Text = myReader.ReadToEnd
                End Using
                Dim temp = ChatConfig.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
                'Find current chatcount
                Dim temp2 = temp(temp.Length - 8).Split(" "c)
                Dim ghetto = temp2(1).Replace(Chr(34), "")
                ghetto = ghetto.Replace("ChatSpam", "")
                ChatCount = Convert.ToInt32(ghetto) + 1
                'Find key bind
                temp2 = temp(temp.Length - 7).Split(" "c)
                KeyToBind.Text = temp2(1).Replace(Chr(34), "")
                KeyBind = KeyToBind.Text
                KeyToBind.ReadOnly = True
                'Rebuild config
                temp(temp.Length - 8) = temp(temp.Length - 8).Replace("ChatSpam0", "ChatSpam" & ChatCount)
                ChatConfig.Clear()
                For i2 As Integer = 0 To temp.Length - 8
                    ChatConfig.Text += temp(i2) + vbCrLf
                Next
            End If
        Next
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not ChatConfig.Text = "" Then
            ChatConfig.Text = ChatConfig.Text.Replace(ChatCount, 0)
            ChatConfig.Text += "Bind " & Chr(34) & KeyBind & Chr(34) & " " & Chr(34) & "ChatSpam0" & Chr(34) & vbCrLf
            ChatConfig.Text += WelcomeMsg(0) + KeyBind + WelcomeMsg(1)
            If GamePath.Length > 1 Then
                For i As Integer = 0 To GamePath.Length - 1
                    Using MyWriter As New IO.StreamWriter(ConfigDir + GamePath(i) + "\ChatSpam.cfg")
                        MyWriter.Write(ChatConfig.Text)
                    End Using
                Next
            Else
                Using MyWriter As New IO.StreamWriter(ConfigDir + GamePath(0) + "\ChatSpam.cfg")
                    MyWriter.Write(ChatConfig.Text)
                End Using
            End If

        End If
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        If ChatConfig.Text = "" Then
            If Not KeyToBind.Text = "" AndAlso Not ChatMsg.Text = "" Then
                KeyToBind.ReadOnly = True
                KeyBind = KeyToBind.Text
If ChatMsg.Text.Contains(";") Then ChatMsg.Text = ChatMsg.Replace(";", "")
            AddChat(ChatMsg.Text, KeyBind, ChatCount)
            ChatCount += 1
            ChatMsg.Clear()
End If
        Else
            If Not ChatMsg.Text = "" Then
If ChatMsg.Text.Contains(";") Then ChatMsg.Text = ChatMsg.Replace(";", "")
                AddChat(ChatMsg.Text, KeyBind, ChatCount)
                ChatCount += 1
                ChatMsg.Clear()
            End If
        End If
    End Sub

    Private Sub AddChat(ByVal ChatMsg As String, ByVal KeyBind As String, ByVal AliasNumber As Integer)
        ChatConfig.Text += "Alias " & Chr(34) & "ChatSpam" & AliasNumber.ToString & Chr(34) & " " & Chr(34) & "Say " & ChatMsg & "; Bind " & KeyBind & " ChatSpam" & (AliasNumber + 1).ToString & Chr(34) & vbCrLf
    End Sub

End Class
