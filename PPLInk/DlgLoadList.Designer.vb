<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgLoadList
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Save_Button = New System.Windows.Forms.Button()
        Me.Load_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ProHelpDataSet = New PPLInk.ProHelpDataSet()
        Me.T_playlistsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_playlistsTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.t_playlistsTableAdapter()
        Me.TableAdapterManager = New PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LstQueue = New System.Windows.Forms.ListBox()
        Me.T_playlistsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ListnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlaydtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tx_playlist_songBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tx_playlist_songTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.tx_playlist_songTableAdapter()
        Me.T_filesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_filesTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.t_filesTableAdapter()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.ChkFuture = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_playlistsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_playlistsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tx_playlist_songBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Save_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Load_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(361, 314)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(203, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Save_Button
        '
        Me.Save_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Save_Button.Location = New System.Drawing.Point(70, 3)
        Me.Save_Button.Name = "Save_Button"
        Me.Save_Button.Size = New System.Drawing.Size(61, 23)
        Me.Save_Button.TabIndex = 2
        Me.Save_Button.Text = "Save"
        Me.ToolTip1.SetToolTip(Me.Save_Button, "Save the unnamed list from the Main screen into the named Play List currently sel" &
        "ected above.  Any previous entries will be removed first.")
        '
        'Load_Button
        '
        Me.Load_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Load_Button.Location = New System.Drawing.Point(3, 3)
        Me.Load_Button.Name = "Load_Button"
        Me.Load_Button.Size = New System.Drawing.Size(61, 23)
        Me.Load_Button.TabIndex = 0
        Me.Load_Button.Text = "Load"
        Me.ToolTip1.SetToolTip(Me.Load_Button, "Copy the titles listed in the currently selected named Play List into the unnamed" &
        " list on the main screen.  These are added to those already included.")
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(137, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(63, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'ProHelpDataSet
        '
        Me.ProHelpDataSet.DataSetName = "ProHelpDataSet"
        Me.ProHelpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_playlistsBindingSource
        '
        Me.T_playlistsBindingSource.DataMember = "t_playlists"
        Me.T_playlistsBindingSource.DataSource = Me.ProHelpDataSet
        '
        'T_playlistsTableAdapter
        '
        Me.T_playlistsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.t_files_saveTableAdapter = Nothing
        Me.TableAdapterManager.t_filesTableAdapter = Nothing
        Me.TableAdapterManager.t_playlistsTableAdapter = Me.T_playlistsTableAdapter
        Me.TableAdapterManager.tx_playlist_songTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Available Play Lists"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 280)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(551, 20)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Select a row then press Save or Load.  Pressing Cancel will leave the main screen" &
    " unchanged"
        '
        'LstQueue
        '
        Me.LstQueue.FormattingEnabled = True
        Me.LstQueue.Location = New System.Drawing.Point(12, 314)
        Me.LstQueue.Name = "LstQueue"
        Me.LstQueue.Size = New System.Drawing.Size(120, 30)
        Me.LstQueue.TabIndex = 7
        Me.LstQueue.TabStop = False
        Me.LstQueue.Visible = False
        '
        'T_playlistsDataGridView
        '
        Me.T_playlistsDataGridView.AutoGenerateColumns = False
        Me.T_playlistsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_playlistsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ListnoDataGridViewTextBoxColumn, Me.PlaydtDataGridViewTextBoxColumn, Me.LnameDataGridViewTextBoxColumn})
        Me.T_playlistsDataGridView.DataSource = Me.T_playlistsBindingSource
        Me.T_playlistsDataGridView.Location = New System.Drawing.Point(13, 48)
        Me.T_playlistsDataGridView.MultiSelect = False
        Me.T_playlistsDataGridView.Name = "T_playlistsDataGridView"
        Me.T_playlistsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.T_playlistsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.T_playlistsDataGridView.Size = New System.Drawing.Size(551, 226)
        Me.T_playlistsDataGridView.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.T_playlistsDataGridView, "This table lists all the currently defined named Play Lists.  These might be empt" &
        "y or partially built.")
        '
        'ListnoDataGridViewTextBoxColumn
        '
        Me.ListnoDataGridViewTextBoxColumn.DataPropertyName = "list_no"
        Me.ListnoDataGridViewTextBoxColumn.HeaderText = "#"
        Me.ListnoDataGridViewTextBoxColumn.Name = "ListnoDataGridViewTextBoxColumn"
        Me.ListnoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ListnoDataGridViewTextBoxColumn.Width = 40
        '
        'PlaydtDataGridViewTextBoxColumn
        '
        Me.PlaydtDataGridViewTextBoxColumn.DataPropertyName = "play_dt"
        Me.PlaydtDataGridViewTextBoxColumn.HeaderText = "Show Time"
        Me.PlaydtDataGridViewTextBoxColumn.Name = "PlaydtDataGridViewTextBoxColumn"
        Me.PlaydtDataGridViewTextBoxColumn.Width = 150
        '
        'LnameDataGridViewTextBoxColumn
        '
        Me.LnameDataGridViewTextBoxColumn.DataPropertyName = "l_name"
        Me.LnameDataGridViewTextBoxColumn.HeaderText = "Play List Name"
        Me.LnameDataGridViewTextBoxColumn.Name = "LnameDataGridViewTextBoxColumn"
        Me.LnameDataGridViewTextBoxColumn.Width = 325
        '
        'Tx_playlist_songBindingSource
        '
        Me.Tx_playlist_songBindingSource.DataMember = "tx_playlist_song"
        Me.Tx_playlist_songBindingSource.DataSource = Me.ProHelpDataSet
        '
        'Tx_playlist_songTableAdapter
        '
        Me.Tx_playlist_songTableAdapter.ClearBeforeFill = True
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
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(12, 25)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(552, 20)
        Me.TxtStatus.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.TxtStatus, "This is a reminder of how many titles you have iin the unnamed list back on the m" &
        "ain screen.")
        '
        'ChkFuture
        '
        Me.ChkFuture.AutoSize = True
        Me.ChkFuture.Checked = True
        Me.ChkFuture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkFuture.Location = New System.Drawing.Point(102, 321)
        Me.ChkFuture.Name = "ChkFuture"
        Me.ChkFuture.Size = New System.Drawing.Size(135, 17)
        Me.ChkFuture.TabIndex = 9
        Me.ChkFuture.Text = "See only Future Shows"
        Me.ToolTip1.SetToolTip(Me.ChkFuture, "When this is ticked, only Play Lists with a date of today and later will be shown" &
        " in the list above.  Clear it to see prior dated Play Lists.")
        Me.ChkFuture.UseVisualStyleBackColor = True
        '
        'DlgLoadList
        '
        Me.AcceptButton = Me.Load_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(576, 356)
        Me.Controls.Add(Me.ChkFuture)
        Me.Controls.Add(Me.TxtStatus)
        Me.Controls.Add(Me.LstQueue)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_playlistsDataGridView)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgLoadList"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Load or Save a Play List"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_playlistsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_playlistsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tx_playlist_songBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Load_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ProHelpDataSet As ProHelpDataSet
    Friend WithEvents T_playlistsBindingSource As BindingSource
    Friend WithEvents T_playlistsTableAdapter As ProHelpDataSetTableAdapters.t_playlistsTableAdapter
    Friend WithEvents TableAdapterManager As ProHelpDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LstQueue As ListBox
    Friend WithEvents T_playlistsDataGridView As DataGridView
    Friend WithEvents Tx_playlist_songBindingSource As BindingSource
    Friend WithEvents Tx_playlist_songTableAdapter As ProHelpDataSetTableAdapters.tx_playlist_songTableAdapter
    Friend WithEvents ListnoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PlaydtDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Save_Button As Button
    Friend WithEvents T_filesBindingSource As BindingSource
    Friend WithEvents T_filesTableAdapter As ProHelpDataSetTableAdapters.t_filesTableAdapter
    Friend WithEvents TxtStatus As TextBox
    Friend WithEvents ChkFuture As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
