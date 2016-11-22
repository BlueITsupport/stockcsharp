Imports Microsoft.Office.Interop
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportStockList1
    Private Sub ReportStockList1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim cryReport As New ReportDocument
        cryReport.Load("c:\Reports\StockListbyShop.rpt")
        cryReport.SetParameterValue("ShopFrom", Criteria.ComboBox1.Text)
        cryReport.SetParameterValue("ShopTo", Criteria.ComboBox3.Text)
        cryReport.SetParameterValue("WeekEnding", Criteria.DateTimePicker2.Value)
        cryReport.SetParameterValue("Date1", Criteria.DateTimePicker1.Value)
        CrystalReportViewer1.ReportSource = cryReport
        Me.Text = "Shop Stock List for [" + Criteria.ComboBox1.Text + "] Report"

    End Sub

    Private Sub EmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailToolStripMenuItem.Click
        Try
            Dim cryReport As New ReportDocument
            cryReport.Load("c:\Reports\StockListbyShop.rpt")
            cryReport.SetParameterValue("ShopFrom", Criteria.ComboBox1.Text)
            cryReport.SetParameterValue("ShopTo", Criteria.ComboBox3.Text)
            cryReport.SetParameterValue("WeekEnding", Criteria.DateTimePicker2.Value)
            cryReport.SetParameterValue("Date1", Criteria.DateTimePicker1.Value)
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = "C:\Reports\StoreStock" + Criteria.ComboBox1.Text + Criteria.DateTimePicker2.Text + ".pdf"
            CrExportOptions = cryReport.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .ExportDestinationOptions = CrDiskFileDestinationOptions
                .ExportFormatOptions = CrFormatTypeOptions
            End With
            cryReport.Export()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Dim Outlook As Outlook.Application
        Dim Mail As Outlook.MailItem
        Dim Acc As Outlook.Account
        Outlook = New Outlook.Application
        Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
        Mail.Subject = "Your Shop Stock List"
        For Each Acc In Outlook.Session.Accounts
            If Acc.AccountType = Microsoft.Office.Interop.Outlook.OlAccountType.olPop3 Then
                Mail.Sender = Acc
            End If
        Next
        '       If Not sender Is Nothing Then Mail.Sender = sender.currentUser.AddressEntry
        Mail.Attachments.Add("C:\Reports\StoreStock" + Criteria.ComboBox1.Text + Criteria.DateTimePicker2.Text + ".pdf")
        Mail.HTMLBody &= "Stock List for " + Criteria.ComboBox1.Text + " "
        Mail.Display()

    End Sub
End Class