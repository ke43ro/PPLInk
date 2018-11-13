<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_CompareWithMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_CompareWithMaster))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.TxtFolder = New System.Windows.Forms.TextBox()
        Me.BtnCompare = New System.Windows.Forms.Button()
        Me.ProHelpDataSet = New PPLInk.ProHelpDataSet()
        Me.T_filesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_filesTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.t_filesTableAdapter()
        Me.TableAdapterManager = New PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnCompareFile = New System.Windows.Forms.Button()
        Me.TxtCompareFile = New System.Windows.Forms.TextBox()
        Me.LstResults = New System.Windows.Forms.ListBox()
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(12, 14)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(776, 66)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Location = New System.Drawing.Point(495, 94)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(179, 20)
        Me.BtnBrowse.TabIndex = 32
        Me.BtnBrowse.Text = "Browse for MASTERS folder"
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'TxtFolder
        '
        Me.TxtFolder.Location = New System.Drawing.Point(127, 95)
        Me.TxtFolder.Name = "TxtFolder"
        Me.TxtFolder.Size = New System.Drawing.Size(353, 20)
        Me.TxtFolder.TabIndex = 31
        Me.TxtFolder.Text = "Master Folder"
        '
        'BtnCompare
        '
        Me.BtnCompare.Location = New System.Drawing.Point(319, 161)
        Me.BtnCompare.Name = "BtnCompare"
        Me.BtnCompare.Size = New System.Drawing.Size(161, 33)
        Me.BtnCompare.TabIndex = 33
        Me.BtnCompare.Text = "Compare"
        Me.BtnCompare.UseVisualStyleBackColor = True
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
        Me.TableAdapterManager.tx_playlist_songTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.InitialDirectory = "Documents"
        '
        'BtnCompareFile
        '
        Me.BtnCompareFile.Location = New System.Drawing.Point(495, 124)
        Me.BtnCompareFile.Name = "BtnCompareFile"
        Me.BtnCompareFile.Size = New System.Drawing.Size(179, 20)
        Me.BtnCompareFile.TabIndex = 35
        Me.BtnCompareFile.Text = "Browse for Compare File"
        Me.BtnCompareFile.UseVisualStyleBackColor = True
        '
        'TxtCompareFile
        '
        Me.TxtCompareFile.Location = New System.Drawing.Point(127, 125)
        Me.TxtCompareFile.Name = "TxtCompareFile"
        Me.TxtCompareFile.Size = New System.Drawing.Size(353, 20)
        Me.TxtCompareFile.TabIndex = 34
        Me.TxtCompareFile.Text = "Compare File ""LyricsMatch - LyricsList.tsv"""
        '
        'LstResults
        '
        Me.LstResults.FormattingEnabled = True
        Me.LstResults.Location = New System.Drawing.Point(13, 205)
        Me.LstResults.Name = "LstResults"
        Me.LstResults.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LstResults.Size = New System.Drawing.Size(775, 212)
        Me.LstResults.TabIndex = 36
        '
        'F_CompareWithMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 426)
        Me.Controls.Add(Me.LstResults)
        Me.Controls.Add(Me.BtnCompareFile)
        Me.Controls.Add(Me.TxtCompareFile)
        Me.Controls.Add(Me.BtnCompare)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.TxtFolder)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "F_CompareWithMaster"
        Me.Text = "CompareWithMaster"
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnBrowse As Button
    Friend WithEvents TxtFolder As TextBox
    Friend WithEvents BtnCompare As Button
    Friend WithEvents ProHelpDataSet As ProHelpDataSet
    Friend WithEvents T_filesBindingSource As BindingSource
    Friend WithEvents T_filesTableAdapter As ProHelpDataSetTableAdapters.t_filesTableAdapter
    Friend WithEvents TableAdapterManager As ProHelpDataSetTableAdapters.TableAdapterManager
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents BtnCompareFile As Button
    Friend WithEvents TxtCompareFile As TextBox
    Friend WithEvents LstResults As ListBox
End Class
