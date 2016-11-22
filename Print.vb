Imports CrystalDecisions.CrystalReports.Engine
Public Class Print
    Private Sub Print_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.Text = "Print Shop Grid" Then PrintShop()
        If Me.Text = "Print Suppliers Grid" Then PrintSuppliers()
        If Me.Text = "Print Stock Grid" Then PrintStock()
        If Me.Text = "Print Shop Sales Grid" Then PrintSales()
        If Me.Text = "Print Shop Deliveries Grid" Then PrintShopDel()
        If Me.Text = "Print Purchase Order Grid" Then PrintPOrders()
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub PrintShop()
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\ShopsList.rpt")
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Private Sub PrintSuppliers()
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\SuppliersReport.rpt")
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Private Sub PrintShopDel()
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\ShopDelGrid.rpt")
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Private Sub PrintStock()
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\StockList.rpt")
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Private Sub PrintSales()
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\SalesGrid.rpt")
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Private Sub PrintPOrders()
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\POrdersList.rpt")
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
End Class