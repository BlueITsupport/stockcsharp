<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSalesAnalysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSalesAnalysis))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SalesAnalysis3 = New DMHStockMaster.SalesAnalysis()
        Me.SalesAnalysis2 = New DMHStockMaster.SalesAnalysis()
        Me.qryReportShopStockListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DMHStockv1DataSet = New DMHStockMaster.DMHStockv1DataSet()
        Me.SalesAnalysis1 = New DMHStockMaster.SalesAnalysis()
        Me.qryReportShopStockListTableAdapter = New DMHStockMaster.DMHStockv1DataSetTableAdapters.qryReportShopStockListTableAdapter()
        CType(Me.qryReportShopStockListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DMHStockv1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1032, 529)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'qryReportShopStockListBindingSource
        '
        Me.qryReportShopStockListBindingSource.DataMember = "qryReportShopStockList"
        Me.qryReportShopStockListBindingSource.DataSource = Me.DMHStockv1DataSet
        '
        'DMHStockv1DataSet
        '
        Me.DMHStockv1DataSet.DataSetName = "DMHStockv1DataSet"
        Me.DMHStockv1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'qryReportShopStockListTableAdapter
        '
        Me.qryReportShopStockListTableAdapter.ClearBeforeFill = True
        '
        'ReportSalesAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 529)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportSalesAnalysis"
        Me.Text = "Sales Analysis Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.qryReportShopStockListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DMHStockv1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SalesAnalysis1 As DMHStockMaster.SalesAnalysis
    Friend WithEvents qryReportShopStockListBindingSource As BindingSource
    Friend WithEvents DMHStockv1DataSet As DMHStockv1DataSet
    Friend WithEvents qryReportShopStockListTableAdapter As DMHStockv1DataSetTableAdapters.qryReportShopStockListTableAdapter
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SalesAnalysis2 As SalesAnalysis
    Friend WithEvents SalesAnalysis3 As SalesAnalysis
End Class
