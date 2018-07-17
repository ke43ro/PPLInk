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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ProHelpDataSet = New PPLInk.ProHelpDataSet()
        Me.T_filesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_filesTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.t_filesTableAdapter()
        Me.TableAdapterManager = New PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager()
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnListIO
        '
        Me.BtnListIO.Location = New System.Drawing.Point(114, 19)
        Me.BtnListIO.Name = "BtnListIO"
        Me.BtnListIO.Size = New System.Drawing.Size(161, 33)
        Me.BtnListIO.TabIndex = 0
        Me.BtnListIO.Text = "File List Import/Export"
        Me.BtnListIO.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(114, 70)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(161, 33)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "Edit File List"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(114, 120)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(161, 33)
        Me.BtnUpdate.TabIndex = 3
        Me.BtnUpdate.Text = "Update File List"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        'F_Advanced
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 184)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnListIO)
        Me.Name = "F_Advanced"
        Me.Text = "Advanced Settings"
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnListIO As Button
    Friend WithEvents ProHelpDataSet As ProHelpDataSet
    Friend WithEvents T_filesBindingSource As BindingSource
    Friend WithEvents T_filesTableAdapter As ProHelpDataSetTableAdapters.t_filesTableAdapter
    Friend WithEvents TableAdapterManager As ProHelpDataSetTableAdapters.TableAdapterManager
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
