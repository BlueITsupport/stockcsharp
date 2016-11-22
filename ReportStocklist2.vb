Imports CrystalDecisions.CrystalReports.Engine
Public Class ReportStocklist2
    Private Sub ReportStocklist2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\StockListbyCode.rpt")

        cryReport.SetParameterValue("StockCode", Criteria.ComboBox2.Text)
        cryReport.SetParameterValue("StockCode2", Criteria.ComboBox4.Text)
        cryReport.SetParameterValue("WeekEnding", Criteria.DateTimePicker2.Value)
        cryReport.SetParameterValue("Date1", Criteria.DateTimePicker1.Value)
        CrystalReportViewer1.ReportSource = cryReport
        Me.Text = " Stock List for [" + Criteria.ComboBox2.Text + "] Report"
        '   Me.WindowState = FormWindowState.Maximized
    End Sub
End Class