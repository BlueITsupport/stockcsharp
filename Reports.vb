Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Public Class Reports2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' If twvReports.SelectedNode.Text = "All Stock Movements" Then Form2.Show()
    End Sub

    Private Sub twvReports_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles twvReports.AfterSelect

    End Sub
    Private Sub loadtsvReport()

    End Sub
End Class