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
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.ProHelpDataSet = New PPLInk.ProHelpDataSet()
        Me.T_filesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_filesTableAdapter = New PPLInk.ProHelpDataSetTableAdapters.t_filesTableAdapter()
        Me.TableAdapterManager = New PPLInk.ProHelpDataSetTableAdapters.TableAdapterManager()
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(104, 31)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(161, 33)
        Me.BtnExport.TabIndex = 0
        Me.BtnExport.Text = "Export File List"
        Me.BtnExport.UseVisualStyleBackColor = True
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
        Me.ClientSize = New System.Drawing.Size(399, 478)
        Me.Controls.Add(Me.BtnExport)
        Me.Name = "F_Advanced"
        Me.Text = "F_Advanced"
        CType(Me.ProHelpDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_filesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnExport As Button
    Friend WithEvents ProHelpDataSet As ProHelpDataSet
    Friend WithEvents T_filesBindingSource As BindingSource
    Friend WithEvents T_filesTableAdapter As ProHelpDataSetTableAdapters.t_filesTableAdapter
    Friend WithEvents TableAdapterManager As ProHelpDataSetTableAdapters.TableAdapterManager
End Class
