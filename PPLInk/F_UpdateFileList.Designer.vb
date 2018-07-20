<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_UpdateFileList
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_UpdateFileList))
        Me.ProHelpDataSet = New PPLInk.ProHelpDataSet()
        Me.T_filesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_filesTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.t_filesTableAdapter()
        Me.TableAdapterManager = New PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager()
        Me.Tx_playlist_songTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.tx_playlist_songTableAdapter()
        Me.Tx_playlist_songBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.RBtnMakeSelect = New System.Windows.Forms.RadioButton()
        Me.RBtnNoSelect = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.RBtnMakeActive = New System.Windows.Forms.RadioButton()
        Me.RBtnNoActive = New System.Windows.Forms.RadioButton()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBtnDeleteThis = New System.Windows.Forms.RadioButton()
        Me.RBtnDeleteAll = New System.Windows.Forms.RadioButton()
        Me.RBtnMakeInactive = New System.Windows.Forms.RadioButton()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.TxtFolder = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tx_playlist_songBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProHelpDataSet
        '
        Me.ProHelpDataSet.DataSetName = "ProHelpDataSet"
        Me.ProHelpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_filesBindingSource
        '
        Me.T_filesBindingSource.DataMember = "t_files"
        Me.T_filesBindingSource.DataSource = Me.ProHelpDataSet
        '
        'T_filesTableAdapter
        '
        Me.T_filesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.t_files_saveTableAdapter = Nothing
        Me.TableAdapterManager.t_filesTableAdapter = Me.T_filesTableAdapter
        Me.TableAdapterManager.t_playlistsTableAdapter = Nothing
        Me.TableAdapterManager.tx_playlist_songTableAdapter = Me.Tx_playlist_songTableAdapter
        Me.TableAdapterManager.UpdateOrder = PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tx_playlist_songTableAdapter
        '
        Me.Tx_playlist_songTableAdapter.ClearBeforeFill = True
        '
        'Tx_playlist_songBindingSource
        '
        Me.Tx_playlist_songBindingSource.DataMember = "tx_playlist_song"
        Me.Tx_playlist_songBindingSource.DataSource = Me.ProHelpDataSet
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(12, 7)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(776, 89)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.BtnUpdate)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 327)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update the File List"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.RBtnMakeSelect)
        Me.GroupBox4.Controls.Add(Me.RBtnNoSelect)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 201)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(763, 76)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "If a file is found on the disk that was not listed in the database"
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox4.Location = New System.Drawing.Point(8, 19)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(730, 17)
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.TabStop = False
        Me.TextBox4.Text = "If a file that was not listed in the database is found on the disk, it will be ad" &
    "ded to the database and you can select a further action:"
        '
        'RBtnMakeSelect
        '
        Me.RBtnMakeSelect.AutoSize = True
        Me.RBtnMakeSelect.Location = New System.Drawing.Point(30, 35)
        Me.RBtnMakeSelect.Name = "RBtnMakeSelect"
        Me.RBtnMakeSelect.Size = New System.Drawing.Size(511, 17)
        Me.RBtnMakeSelect.TabIndex = 1
        Me.RBtnMakeSelect.TabStop = True
        Me.RBtnMakeSelect.Text = "Alter the file status to SELECTED so that it will now appear in the selection sho" &
    "rt list (RECOMMENDED)"
        Me.ToolTip1.SetToolTip(Me.RBtnMakeSelect, "Files found on the disk that were not previously in the database have probebly be" &
        "en recently added so they are probably wanted on the Short List.")
        Me.RBtnMakeSelect.UseVisualStyleBackColor = True
        '
        'RBtnNoSelect
        '
        Me.RBtnNoSelect.AutoSize = True
        Me.RBtnNoSelect.Location = New System.Drawing.Point(30, 53)
        Me.RBtnNoSelect.Name = "RBtnNoSelect"
        Me.RBtnNoSelect.Size = New System.Drawing.Size(97, 17)
        Me.RBtnNoSelect.TabIndex = 0
        Me.RBtnNoSelect.TabStop = True
        Me.RBtnNoSelect.Text = "Take no action"
        Me.ToolTip1.SetToolTip(Me.RBtnNoSelect, "New files found on the disk will be listed as Active in the database, but the Pow" &
        "erPoint Link operator will have to turn off the Short List option to see them.")
        Me.RBtnNoSelect.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.RBtnMakeActive)
        Me.GroupBox3.Controls.Add(Me.RBtnNoActive)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 126)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(763, 73)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "If an INACTIVE file is found on the disk"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox2.Location = New System.Drawing.Point(8, 19)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(730, 18)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "If a file listed in the database as INACTIVE is found on the disk, you can select" &
    " the action:"
        '
        'RBtnMakeActive
        '
        Me.RBtnMakeActive.AutoSize = True
        Me.RBtnMakeActive.Location = New System.Drawing.Point(30, 35)
        Me.RBtnMakeActive.Name = "RBtnMakeActive"
        Me.RBtnMakeActive.Size = New System.Drawing.Size(467, 17)
        Me.RBtnMakeActive.TabIndex = 1
        Me.RBtnMakeActive.TabStop = True
        Me.RBtnMakeActive.Text = "Alter the file status to ACTIVE so that it will now appear in the selection list " &
    "(RECOMMENDED)"
        Me.RBtnMakeActive.UseVisualStyleBackColor = True
        '
        'RBtnNoActive
        '
        Me.RBtnNoActive.AutoSize = True
        Me.RBtnNoActive.Location = New System.Drawing.Point(30, 52)
        Me.RBtnNoActive.Name = "RBtnNoActive"
        Me.RBtnNoActive.Size = New System.Drawing.Size(97, 17)
        Me.RBtnNoActive.TabIndex = 0
        Me.RBtnNoActive.TabStop = True
        Me.RBtnNoActive.Text = "Take no action"
        Me.ToolTip1.SetToolTip(Me.RBtnNoActive, "Although the file is found on the disk, its Inactive status will prevent the oper" &
        "ator from using it.")
        Me.RBtnNoActive.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(308, 283)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(161, 33)
        Me.BtnUpdate.TabIndex = 6
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBtnDeleteThis)
        Me.GroupBox2.Controls.Add(Me.RBtnDeleteAll)
        Me.GroupBox2.Controls.Add(Me.RBtnMakeInactive)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(763, 104)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "If an ACTIVE file is not on the disk"
        '
        'RBtnDeleteThis
        '
        Me.RBtnDeleteThis.AutoSize = True
        Me.RBtnDeleteThis.Location = New System.Drawing.Point(30, 83)
        Me.RBtnDeleteThis.Name = "RBtnDeleteThis"
        Me.RBtnDeleteThis.Size = New System.Drawing.Size(697, 17)
        Me.RBtnDeleteThis.TabIndex = 16
        Me.RBtnDeleteThis.TabStop = True
        Me.RBtnDeleteThis.Text = "Delete the file record and remove it from any Play List where it appears.  This w" &
    "ill somewhat affect any history that you are keeping in Play Lists."
        Me.ToolTip1.SetToolTip(Me.RBtnDeleteThis, "The Play List names and show times will remain in the database, but the relevant " &
        "song will be missing from the list")
        Me.RBtnDeleteThis.UseVisualStyleBackColor = True
        '
        'RBtnDeleteAll
        '
        Me.RBtnDeleteAll.AutoSize = True
        Me.RBtnDeleteAll.Location = New System.Drawing.Point(30, 64)
        Me.RBtnDeleteAll.Name = "RBtnDeleteAll"
        Me.RBtnDeleteAll.Size = New System.Drawing.Size(629, 17)
        Me.RBtnDeleteAll.TabIndex = 15
        Me.RBtnDeleteAll.TabStop = True
        Me.RBtnDeleteAll.Text = "Delete the file record and all Play Lists where it appears.  This will significan" &
    "tly affect any history that you are keeping in Play Lists"
        Me.ToolTip1.SetToolTip(Me.RBtnDeleteAll, "The Play List names and show times will remain in the database, but they will be " &
        "empty")
        Me.RBtnDeleteAll.UseVisualStyleBackColor = True
        '
        'RBtnMakeInactive
        '
        Me.RBtnMakeInactive.AutoSize = True
        Me.RBtnMakeInactive.Location = New System.Drawing.Point(30, 45)
        Me.RBtnMakeInactive.Name = "RBtnMakeInactive"
        Me.RBtnMakeInactive.Size = New System.Drawing.Size(502, 17)
        Me.RBtnMakeInactive.TabIndex = 14
        Me.RBtnMakeInactive.TabStop = True
        Me.RBtnMakeInactive.Text = "Alter the file status to INACTIVE so that it will no longer appear in the selecti" &
    "on list (RECOMMENDED)"
        Me.ToolTip1.SetToolTip(Me.RBtnMakeInactive, "Your Play List history will be kept intact")
        Me.RBtnMakeInactive.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox3.Location = New System.Drawing.Point(8, 16)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(730, 35)
        Me.TextBox3.TabIndex = 13
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = resources.GetString("TextBox3.Text")
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Location = New System.Drawing.Point(486, 97)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(179, 20)
        Me.BtnBrowse.TabIndex = 30
        Me.BtnBrowse.Text = "Browse for MASTERS folder"
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'TxtFolder
        '
        Me.TxtFolder.Location = New System.Drawing.Point(118, 98)
        Me.TxtFolder.Name = "TxtFolder"
        Me.TxtFolder.Size = New System.Drawing.Size(353, 20)
        Me.TxtFolder.TabIndex = 29
        Me.TxtFolder.Text = "Master Folder"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Results of the update will be written here"})
        Me.ListBox1.Location = New System.Drawing.Point(12, 448)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(775, 251)
        Me.ListBox1.TabIndex = 31
        '
        'F_UpdateFileList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 705)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.TxtFolder)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "F_UpdateFileList"
        Me.Text = "Update the File List"
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tx_playlist_songBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProHelpDataSet As ProHelpDataSet
    Friend WithEvents T_filesBindingSource As BindingSource
    Friend WithEvents T_filesTableAdapter As ProHelpDataSetTableAdapters.t_filesTableAdapter
    Friend WithEvents TableAdapterManager As ProHelpDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tx_playlist_songTableAdapter As ProHelpDataSetTableAdapters.tx_playlist_songTableAdapter
    Friend WithEvents Tx_playlist_songBindingSource As BindingSource
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RBtnMakeActive As RadioButton
    Friend WithEvents RBtnNoActive As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents RBtnDeleteThis As RadioButton
    Friend WithEvents RBtnDeleteAll As RadioButton
    Friend WithEvents RBtnMakeInactive As RadioButton
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents RBtnMakeSelect As RadioButton
    Friend WithEvents RBtnNoSelect As RadioButton
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents BtnBrowse As Button
    Friend WithEvents TxtFolder As TextBox
    Friend WithEvents ListBox1 As ListBox
End Class
