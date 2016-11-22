Imports CrystalDecisions.CrystalReports.Engine
Public Class ReportAllStock
    Private Sub ReportAllStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\AllStock.rpt")
        cryReport.SetParameterValue("DateFrom", Criteria.DateTimePicker1.Value)
        cryReport.SetParameterValue("DateTo", Criteria.DateTimePicker2.Value)
        cryReport.SetParameterValue("Stock", Criteria.ComboBox2.Text)
        cryReport.SetParameterValue("Stock2", Criteria.ComboBox4.Text)
        CrystalReportViewer1.ReportSource = cryReport
        Me.Text = "All StockMovements for [" + Criteria.ComboBox2.Text + "] Report"
    End Sub
End Class