Imports CrystalDecisions.CrystalReports.Engine

Public Class reportSalesHistory
    Private Sub reportSalesHistory_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\SalesHistory.rpt")
        cryReport.SetParameterValue("DateFrom", Criteria.DateTimePicker1.Value)
        cryReport.SetParameterValue("DateTo", Criteria.DateTimePicker2.Value)

        cryReport.SetParameterValue("StockCode", Criteria.ComboBox2.Text)
        cryReport.SetParameterValue("ShopName", Criteria.ComboBox1.Text)
        CrystalReportViewer1.ReportSource = cryReport
        Me.Text = "Sales History for Shop [" + Criteria.ComboBox1.Text + "] and Stock Code [" + Criteria.ComboBox2.Text + "] Report"
    End Sub
End Class