<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_SetUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_SetUp))
        Me.ChkStep1 = New System.Windows.Forms.CheckBox()
        Me.TxtAdvice1 = New System.Windows.Forms.TextBox()
        Me.TxtServer = New System.Windows.Forms.TextBox()
        Me.TxtAdvice2 = New System.Windows.Forms.TextBox()
        Me.ChkStep2 = New System.Windows.Forms.CheckBox()
        Me.TxtDatabase = New System.Windows.Forms.TextBox()
        Me.BtnTest1 = New System.Windows.Forms.Button()
        Me.BtnTest2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnTest3 = New System.Windows.Forms.Button()
        Me.TxtAdvice3 = New System.Windows.Forms.TextBox()
        Me.ChkStep3 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TxtFolder = New System.Windows.Forms.TextBox()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChkStep1
        '
        Me.ChkStep1.AutoSize = True
        Me.ChkStep1.Location = New System.Drawing.Point(12, 228)
        Me.ChkStep1.Name = "ChkStep1"
        Me.ChkStep1.Size = New System.Drawing.Size(99, 17)
        Me.ChkStep1.TabIndex = 1
        Me.ChkStep1.TabStop = False
        Me.ChkStep1.Text = "Step 1: Waiting"
        Me.ChkStep1.UseVisualStyleBackColor = True
        '
        'TxtAdvice1
        '
        Me.TxtAdvice1.Location = New System.Drawing.Point(12, 83)
        Me.TxtAdvice1.Multiline = True
        Me.TxtAdvice1.Name = "TxtAdvice1"
        Me.TxtAdvice1.ReadOnly = True
        Me.TxtAdvice1.Size = New System.Drawing.Size(346, 116)
        Me.TxtAdvice1.TabIndex = 2
        Me.TxtAdvice1.TabStop = False
        Me.TxtAdvice1.Text = resources.GetString("TxtAdvice1.Text")
        '
        'TxtServer
        '
        Me.TxtServer.Location = New System.Drawing.Point(12, 205)
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(179, 20)
        Me.TxtServer.TabIndex = 4
        Me.TxtServer.Text = ".\SQLExpress"
        '
        'TxtAdvice2
        '
        Me.TxtAdvice2.Location = New System.Drawing.Point(12, 276)
        Me.TxtAdvice2.Multiline = True
        Me.TxtAdvice2.Name = "TxtAdvice2"
        Me.TxtAdvice2.ReadOnly = True
        Me.TxtAdvice2.Size = New System.Drawing.Size(346, 46)
        Me.TxtAdvice2.TabIndex = 6
        Me.TxtAdvice2.TabStop = False
        Me.TxtAdvice2.Text = "PowerPoint Link needs access to a database that stores your show list.  This data" &
    "base is named ProHelp and will be installed now if it is not already available."
        '
        'ChkStep2
        '
        Me.ChkStep2.AutoSize = True
        Me.ChkStep2.Location = New System.Drawing.Point(12, 353)
        Me.ChkStep2.Name = "ChkStep2"
        Me.ChkStep2.Size = New System.Drawing.Size(99, 17)
        Me.ChkStep2.TabIndex = 5
        Me.ChkStep2.TabStop = False
        Me.ChkStep2.Text = "Step 2: Waiting"
        Me.ChkStep2.UseVisualStyleBackColor = True
        '
        'TxtDatabase
        '
        Me.TxtDatabase.Enabled = False
        Me.TxtDatabase.Location = New System.Drawing.Point(12, 327)
        Me.TxtDatabase.Name = "TxtDatabase"
        Me.TxtDatabase.ReadOnly = True
        Me.TxtDatabase.Size = New System.Drawing.Size(179, 20)
        Me.TxtDatabase.TabIndex = 8
        Me.TxtDatabase.TabStop = False
        Me.TxtDatabase.Text = "ProHelp"
        '
        'BtnTest1
        '
        Me.BtnTest1.Location = New System.Drawing.Point(224, 205)
        Me.BtnTest1.Name = "BtnTest1"
        Me.BtnTest1.Size = New System.Drawing.Size(135, 20)
        Me.BtnTest1.TabIndex = 9
        Me.BtnTest1.Text = "Test"
        Me.BtnTest1.UseVisualStyleBackColor = True
        '
        'BtnTest2
        '
        Me.BtnTest2.Enabled = False
        Me.BtnTest2.Location = New System.Drawing.Point(223, 327)
        Me.BtnTest2.Name = "BtnTest2"
        Me.BtnTest2.Size = New System.Drawing.Size(135, 20)
        Me.BtnTest2.TabIndex = 10
        Me.BtnTest2.Text = "Test"
        Me.BtnTest2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(215, 551)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(8, 2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(356, 56)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "For each step, complete the entries as instructed then press Test" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Successful cha" &
    "nges are saved at once.  Cancel button does not revert values"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 187)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Step 1: Set SQL Server"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(8, 257)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(356, 120)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Step 2: Connect to Database"
        '
        'BtnTest3
        '
        Me.BtnTest3.Enabled = False
        Me.BtnTest3.Location = New System.Drawing.Point(222, 493)
        Me.BtnTest3.Name = "BtnTest3"
        Me.BtnTest3.Size = New System.Drawing.Size(135, 20)
        Me.BtnTest3.TabIndex = 24
        Me.BtnTest3.Text = "Test"
        Me.BtnTest3.UseVisualStyleBackColor = True
        '
        'TxtAdvice3
        '
        Me.TxtAdvice3.Location = New System.Drawing.Point(11, 404)
        Me.TxtAdvice3.Multiline = True
        Me.TxtAdvice3.Name = "TxtAdvice3"
        Me.TxtAdvice3.ReadOnly = True
        Me.TxtAdvice3.Size = New System.Drawing.Size(346, 60)
        Me.TxtAdvice3.TabIndex = 22
        Me.TxtAdvice3.TabStop = False
        Me.TxtAdvice3.Text = resources.GetString("TxtAdvice3.Text")
        '
        'ChkStep3
        '
        Me.ChkStep3.AutoSize = True
        Me.ChkStep3.Location = New System.Drawing.Point(11, 519)
        Me.ChkStep3.Name = "ChkStep3"
        Me.ChkStep3.Size = New System.Drawing.Size(99, 17)
        Me.ChkStep3.TabIndex = 21
        Me.ChkStep3.TabStop = False
        Me.ChkStep3.Text = "Step 3: Waiting"
        Me.ChkStep3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(7, 385)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(356, 157)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Step 3: Fill Database Tables"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Please find the MASTERS folder as described above the Browse button"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'TxtFolder
        '
        Me.TxtFolder.Enabled = False
        Me.TxtFolder.Location = New System.Drawing.Point(12, 493)
        Me.TxtFolder.Name = "TxtFolder"
        Me.TxtFolder.ReadOnly = True
        Me.TxtFolder.Size = New System.Drawing.Size(179, 20)
        Me.TxtFolder.TabIndex = 26
        Me.TxtFolder.TabStop = False
        Me.TxtFolder.Text = "Master Folder"
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Enabled = False
        Me.BtnBrowse.Location = New System.Drawing.Point(12, 468)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(179, 20)
        Me.BtnBrowse.TabIndex = 27
        Me.BtnBrowse.Text = "Browse for MASTERS folder"
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'F_SetUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 587)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.TxtFolder)
        Me.Controls.Add(Me.BtnTest3)
        Me.Controls.Add(Me.TxtAdvice3)
        Me.Controls.Add(Me.ChkStep3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.BtnTest2)
        Me.Controls.Add(Me.BtnTest1)
        Me.Controls.Add(Me.TxtDatabase)
        Me.Controls.Add(Me.TxtAdvice2)
        Me.Controls.Add(Me.ChkStep2)
        Me.Controls.Add(Me.TxtServer)
        Me.Controls.Add(Me.TxtAdvice1)
        Me.Controls.Add(Me.ChkStep1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_SetUp"
        Me.Text = "Set Up Wizard"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChkStep1 As CheckBox
    Friend WithEvents TxtAdvice1 As TextBox
    Friend WithEvents TxtServer As TextBox
    Friend WithEvents TxtAdvice2 As TextBox
    Friend WithEvents ChkStep2 As CheckBox
    Friend WithEvents TxtDatabase As TextBox
    Friend WithEvents BtnTest1 As Button
    Friend WithEvents BtnTest2 As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnTest3 As Button
    Friend WithEvents TxtAdvice3 As TextBox
    Friend WithEvents ChkStep3 As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents TxtFolder As TextBox
    Friend WithEvents BtnBrowse As Button
End Class
