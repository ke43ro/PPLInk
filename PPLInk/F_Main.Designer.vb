<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Main
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
        Me.LBPlayList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_filesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_filesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProHelpDataSet = New PPLInk.ProHelpDataSet()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnPlay = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnAdvanced = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnSetup = New System.Windows.Forms.Button()
        Me.BtnLoadList = New System.Windows.Forms.Button()
        Me.ChkShortList = New System.Windows.Forms.CheckBox()
        Me.LBInstant = New System.Windows.Forms.ListBox()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.T_filesTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.t_filesTableAdapter()
        Me.TableAdapterManager = New PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.T_filesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBPlayList
        '
        Me.LBPlayList.FormattingEnabled = True
        Me.LBPlayList.Location = New System.Drawing.Point(12, 24)
        Me.LBPlayList.Name = "LBPlayList"
        Me.LBPlayList.Size = New System.Drawing.Size(755, 108)
        Me.LBPlayList.TabIndex = 0
        Me.LBPlayList.TabStop = False
        Me.ToolTip1.SetToolTip(Me.LBPlayList, "This is the list of songs that will be played through PowerPoint")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Play List"
        '
        'T_filesDataGridView
        '
        Me.T_filesDataGridView.AllowUserToAddRows = False
        Me.T_filesDataGridView.AllowUserToDeleteRows = False
        Me.T_filesDataGridView.AutoGenerateColumns = False
        Me.T_filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_filesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn9})
        Me.T_filesDataGridView.DataSource = Me.T_filesBindingSource
        Me.T_filesDataGridView.Location = New System.Drawing.Point(12, 269)
        Me.T_filesDataGridView.MultiSelect = False
        Me.T_filesDataGridView.Name = "T_filesDataGridView"
        Me.T_filesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.T_filesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.T_filesDataGridView.Size = New System.Drawing.Size(755, 225)
        Me.T_filesDataGridView.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.T_filesDataGridView, "The PPT Name is the actual file name of the song on the hard disk.  The Other Nam" &
        "e is an alternative title of the song or other search data.")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "file_no"
        Me.DataGridViewTextBoxColumn1.HeaderText = "#"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "f_name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PPT Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 350
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "f_path"
        Me.DataGridViewTextBoxColumn3.HeaderText = "L"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 5
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "f_altname"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Other Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 350
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "inactive"
        Me.DataGridViewTextBoxColumn9.HeaderText = "X"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 5
        '
        'T_filesBindingSource
        '
        Me.T_filesBindingSource.DataMember = "t_files"
        Me.T_filesBindingSource.DataSource = Me.ProHelpDataSet
        '
        'ProHelpDataSet
        '
        Me.ProHelpDataSet.DataSetName = "ProHelpDataSet"
        Me.ProHelpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(12, 226)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(100, 20)
        Me.TxtSearch.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtSearch, "Type letters of any word or partial word in the song name (or its alternate name)" &
        " to find it in the database")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(630, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Search  (While searching:  use UP and DOWN arrow keys to move the selection; use " &
    "ENTER to add the current selection to the list)"
        '
        'BtnPlay
        '
        Me.BtnPlay.Location = New System.Drawing.Point(249, 158)
        Me.BtnPlay.Name = "BtnPlay"
        Me.BtnPlay.Size = New System.Drawing.Size(100, 37)
        Me.BtnPlay.TabIndex = 5
        Me.BtnPlay.Text = "Play"
        Me.ToolTip1.SetToolTip(Me.BtnPlay, "Start PowerPoint and show the list of songs")
        Me.BtnPlay.UseVisualStyleBackColor = True
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(12, 158)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(100, 37)
        Me.BtnClear.TabIndex = 4
        Me.BtnClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.BtnClear, "Delete all the songs from the Play List")
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(129, 158)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(100, 37)
        Me.BtnAdd.TabIndex = 3
        Me.BtnAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.BtnAdd, "Add the song currently selected in the table below to the list above")
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnAdvanced
        '
        Me.BtnAdvanced.Location = New System.Drawing.Point(12, 499)
        Me.BtnAdvanced.Name = "BtnAdvanced"
        Me.BtnAdvanced.Size = New System.Drawing.Size(100, 28)
        Me.BtnAdvanced.TabIndex = 12
        Me.BtnAdvanced.Text = "Advanced"
        Me.ToolTip1.SetToolTip(Me.BtnAdvanced, "Open the advanced features screen")
        Me.BtnAdvanced.UseVisualStyleBackColor = True
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(338, 499)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(100, 28)
        Me.BtnHelp.TabIndex = 14
        Me.BtnHelp.Text = "Help"
        Me.ToolTip1.SetToolTip(Me.BtnHelp, "Show a Screen with instructions on how to use PPLink")
        Me.BtnHelp.UseVisualStyleBackColor = True
        '
        'BtnSetup
        '
        Me.BtnSetup.Location = New System.Drawing.Point(667, 499)
        Me.BtnSetup.Name = "BtnSetup"
        Me.BtnSetup.Size = New System.Drawing.Size(100, 28)
        Me.BtnSetup.TabIndex = 9
        Me.BtnSetup.Text = "Set Up"
        Me.ToolTip1.SetToolTip(Me.BtnSetup, "Set up PowerPoint Link after installation")
        Me.BtnSetup.UseVisualStyleBackColor = True
        '
        'BtnLoadList
        '
        Me.BtnLoadList.Location = New System.Drawing.Point(629, 158)
        Me.BtnLoadList.Name = "BtnLoadList"
        Me.BtnLoadList.Size = New System.Drawing.Size(138, 37)
        Me.BtnLoadList.TabIndex = 16
        Me.BtnLoadList.Text = "Save or Load a Play List"
        Me.ToolTip1.SetToolTip(Me.BtnLoadList, "Save the current Play List to a named record or Load a Play List that was previou" &
        "sly saved.")
        Me.BtnLoadList.UseVisualStyleBackColor = True
        '
        'ChkShortList
        '
        Me.ChkShortList.AutoSize = True
        Me.ChkShortList.Location = New System.Drawing.Point(129, 228)
        Me.ChkShortList.Name = "ChkShortList"
        Me.ChkShortList.Size = New System.Drawing.Size(199, 17)
        Me.ChkShortList.TabIndex = 21
        Me.ChkShortList.Text = "Show only songs from your Short List"
        Me.ToolTip1.SetToolTip(Me.ChkShortList, "When this is ticked, only songs denoted as ""Selected"" will appear in the selectio" &
        "n table below.")
        Me.ChkShortList.UseVisualStyleBackColor = True
        '
        'LBInstant
        '
        Me.LBInstant.FormattingEnabled = True
        Me.LBInstant.Location = New System.Drawing.Point(385, 167)
        Me.LBInstant.Name = "LBInstant"
        Me.LBInstant.Size = New System.Drawing.Size(120, 17)
        Me.LBInstant.TabIndex = 10
        Me.LBInstant.TabStop = False
        Me.LBInstant.Visible = False
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.Location = New System.Drawing.Point(722, 5)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(42, 13)
        Me.LblVersion.TabIndex = 11
        Me.LblVersion.Text = "Version"
        Me.LblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(205, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(388, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "To Edit the Play List: '+' moves selected line down; '-' moves it up, 'DEL' delet" &
    "es it"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(249, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(288, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Double click a row in the table to play that song immediately"
        '
        'F_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 534)
        Me.Controls.Add(Me.ChkShortList)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnLoadList)
        Me.Controls.Add(Me.BtnHelp)
        Me.Controls.Add(Me.BtnAdvanced)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.LBInstant)
        Me.Controls.Add(Me.BtnSetup)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnPlay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.T_filesDataGridView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBPlayList)
        Me.Name = "F_Main"
        Me.Text = "PowerPoint Link"
        CType(Me.T_filesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBPlayList As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ProHelpDataSet As ProHelpDataSet
    Friend WithEvents T_filesBindingSource As BindingSource
    Friend WithEvents T_filesTableAdapter As ProHelpDataSetTableAdapters.t_filesTableAdapter
    Friend WithEvents TableAdapterManager As ProHelpDataSetTableAdapters.TableAdapterManager
    Friend WithEvents T_filesDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnPlay As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnSetup As Button
    Friend WithEvents LBInstant As ListBox
    Friend WithEvents LblVersion As Label
    Friend WithEvents BtnAdvanced As Button
    Friend WithEvents BtnHelp As Button
    Friend WithEvents BtnLoadList As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ChkShortList As CheckBox
End Class
