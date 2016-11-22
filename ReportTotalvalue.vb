Imports CrystalDecisions.CrystalReports.Engine
Public Class ReportTotalvalue
    Private Sub ReportTotalvalue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
        Dim cryReport As New ReportDocument
        cryReport.Load("C:\Reports\TotalValueRep.rpt")
        cryReport.SetParameterValue("WeekEnding", Criteria.DateTimePicker2.Value)
        cryReport.SetParameterValue("Date1", Criteria.DateTimePicker1.Value)
        cryReport.SetParameterValue("Date2", Criteria.DateTimePicker2.Value)
        CrystalReportViewer1.ReportSource = cryReport
        Me.Text = "Total Stock Valuation Report"
        ' Me.WindowState = FormWindowState.Maximized
    End Sub
End Class