<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Advanced
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnListIO = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ChkAutoSelectList = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BtnListIO
        '
        Me.BtnListIO.Location = New System.Drawing.Point(114, 19)
        Me.BtnListIO.Name = "BtnListIO"
        Me.BtnListIO.Size = New System.Drawing.Size(161, 33)
        Me.BtnListIO.TabIndex = 0
        Me.BtnListIO.Text = "File List Import/Export"
        Me.ToolTip1.SetToolTip(Me.BtnListIO, "Exports a file that can be read on another installation to transfer your short li" &
        "st and alternative text or vice versa.")
        Me.BtnListIO.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(114, 70)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(161, 33)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "Edit File List"
        Me.ToolTip1.SetToolTip(Me.BtnEdit, "Provides a way to make manual changes to your file list database.")
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(114, 121)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(161, 33)
        Me.BtnUpdate.TabIndex = 3
        Me.BtnUpdate.Text = "Update File List"
        Me.ToolTip1.SetToolTip(Me.BtnUpdate, "Updates your database to match the files you have on your disk.")
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(114, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 33)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Compare With Master"
        Me.ToolTip1.SetToolTip(Me.Button1, "Compares your database with a file created from the Master Cloud Storage collecti" &
        "on.  Use Update File List first for best results.")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ChkAutoSelectList
        '
        Me.ChkAutoSelectList.AutoSize = True
        Me.ChkAutoSelectList.Location = New System.Drawing.Point(13, 224)
        Me.ChkAutoSelectList.Name = "ChkAutoSelectList"
        Me.ChkAutoSelectList.Size = New System.Drawing.Size(246, 17)
        Me.ChkAutoSelectList.TabIndex = 5
        Me.ChkAutoSelectList.Text = "Automatically add all files I use to the Short List"
        Me.ToolTip1.SetToolTip(Me.ChkAutoSelectList, "Files that you add to a Play List or show using Instant Play will be permanently " &
        "denoted as ""Selected"".")
        Me.ChkAutoSelectList.UseVisualStyleBackColor = True
        '
        'F_Advanced
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 253)
        Me.Controls.Add(Me.ChkAutoSelectList)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnListIO)
        Me.Name = "F_Advanced"
        Me.Text = "Advanced Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnListIO As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ChkAutoSelectList As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
