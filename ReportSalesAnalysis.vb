Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Office.Interop



Public Class ReportSalesAnalysis

    Private Sub ReportSalesAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\SalesAnalysis.rpt")
        cryReport.SetParameterValue("DateFrom1", Criteria.DateTimePicker1.Value)
        cryReport.SetParameterValue("DateTo2", Criteria.DateTimePicker2.Value)
        CrystalReportViewer1.ReportSource = cryReport
    End Sub

End Class