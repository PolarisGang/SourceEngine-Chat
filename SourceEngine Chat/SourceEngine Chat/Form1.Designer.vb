<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ChatConfig = New System.Windows.Forms.TextBox()
        Me.KeyToBind = New System.Windows.Forms.TextBox()
        Me.ChatMsg = New System.Windows.Forms.TextBox()
        Me.AddBtn = New System.Windows.Forms.Button()
        Me.MyDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'ChatConfig
        '
        Me.ChatConfig.Location = New System.Drawing.Point(12, 12)
        Me.ChatConfig.Multiline = True
        Me.ChatConfig.Name = "ChatConfig"
        Me.ChatConfig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ChatConfig.Size = New System.Drawing.Size(1006, 559)
        Me.ChatConfig.TabIndex = 0
        '
        'KeyToBind
        '
        Me.KeyToBind.Location = New System.Drawing.Point(13, 578)
        Me.KeyToBind.Name = "KeyToBind"
        Me.KeyToBind.Size = New System.Drawing.Size(100, 20)
        Me.KeyToBind.TabIndex = 1
        '
        'ChatMsg
        '
        Me.ChatMsg.Location = New System.Drawing.Point(119, 578)
        Me.ChatMsg.Name = "ChatMsg"
        Me.ChatMsg.Size = New System.Drawing.Size(809, 20)
        Me.ChatMsg.TabIndex = 2
        '
        'AddBtn
        '
        Me.AddBtn.Location = New System.Drawing.Point(943, 576)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(75, 23)
        Me.AddBtn.TabIndex = 3
        Me.AddBtn.Text = "Add"
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'MyDialog
        '
        Me.MyDialog.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 608)
        Me.Controls.Add(Me.AddBtn)
        Me.Controls.Add(Me.ChatMsg)
        Me.Controls.Add(Me.KeyToBind)
        Me.Controls.Add(Me.ChatConfig)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "SourceEngine Chat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChatConfig As TextBox
    Friend WithEvents KeyToBind As TextBox
    Friend WithEvents ChatMsg As TextBox
    Friend WithEvents AddBtn As Button
    Friend WithEvents MyDialog As FolderBrowserDialog
End Class
