Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ReportShopDeliveries

    Private Sub ReportShopDeliveries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\ShopDeliveryRep.rpt")
        cryReport.SetParameterValue("DateFrom", Criteria.DateTimePicker1.Value)
        cryReport.SetParameterValue("DateTo", Criteria.DateTimePicker2.Value)
        cryReport.SetParameterValue("ShopName", Criteria.ComboBox1.Text.ToString)
        cryReport.SetParameterValue("StockCode", Criteria.ComboBox2.Text.ToString)
        CrystalReportViewer1.ReportSource = cryReport
        Me.Text = "Shop Deliveries for [" + Criteria.ComboBox1.Text + "] Report"
    End Sub
End Class