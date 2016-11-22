Imports System.Windows.Forms
Imports System.IO
Imports System.Data
Imports System.IO.File
Imports System.Data.SqlClient

Public Class Backup

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim con As SqlConnection
        con = New SqlConnection("Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;")
        con.Open()
        Using cmd As New SqlCommand("SELECT name from sys.databases", con)
            Using dr As IDataReader = cmd.ExecuteReader()
                While dr.Read
                    ComboBox1.Items.Add(dr(0).ToString())
                    ComboBox2.Items.Add(dr(0).ToString())
                End While
            End Using
        End Using
        con.Close()
        If Directory.Exists("c:\DBBackup") Then
            For Each file As String In IO.Directory.GetFiles("C:\DBBackup")
                ComboBox3.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file))
            Next
        Else
            Directory.CreateDirectory("c:\DBBackup")
        End If
        ComboBox1.SelectedItem = "DMHStockv4"
        ComboBox2.SelectedItem = "DMHStockv4"
        '  ComboBox3.SelectedItem = ComboBox3.Items(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim t As String
            Dim d As String
            Dim m As String
            Dim y As String
            t = Date.Now.Second.ToString + Date.Now.Minute.ToString + Date.Now.Hour.ToString
            d = Date.Now.Day.ToString
            m = Date.Now.Month.ToString
            y = Date.Now.Year.ToString
            Dim uniqueid As String
            uniqueid = t & d & m & y
            Dim con2 As SqlConnection
            con2 = New SqlConnection("Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;")

            Using cmd As New SqlCommand("Backup database " & ComboBox1.Text.Trim & " to  disk='C:\DBBackup\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak'", con2)
                con2.Open()
                cmd.ExecuteNonQuery()
                con2.Close()
                Label2.Text = "Database Backup completed successfully" & vbCrLf & "You can find the backup file in c:\DBBackup\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak"

            End Using
            Using cmd As New SqlCommand("Backup database " & ComboBox1.Text.Trim & " to  disk='F:\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak'", con2)
                con2.Open()
                cmd.ExecuteNonQuery()
                con2.Close()
                Label2.Text = "Database Backup completed successfully" & vbCrLf & "You can find the backup file in c:\DBBackup\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak"

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim con As String = "Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        Using dconn As New SqlConnection(con)
            Dim insertcommand As New SqlCommand
            insertcommand.Connection = dconn
            insertcommand.CommandType = CommandType.Text
            insertcommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            insertcommand.Connection.Open()
            insertcommand.Parameters.AddWithValue("@StockCode", "ALL")
            insertcommand.Parameters.AddWithValue("@SupplierRef", "ALL")
            insertcommand.Parameters.AddWithValue("@Location", "ALL")
            insertcommand.Parameters.AddWithValue("@Qty", "0")
            insertcommand.Parameters.AddWithValue("@MovementType", "Backup")
            insertcommand.Parameters.AddWithValue("@RecordType", "Backup")
            insertcommand.Parameters.AddWithValue("@MovementDate", Date.Now)
            insertcommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            insertcommand.Parameters.AddWithValue("@Reference", " ")
            insertcommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            insertcommand.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con2 As SqlConnection
            con2 = New SqlConnection("Initial Catalog=master;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;")
            Dim alterquery As String = "ALTER DATABASE " & ComboBox2.Text & " SET Single_User WITH Rollback Immediate"
            Dim altercommand As New SqlCommand(alterquery, con2)
            con2.Open()
            altercommand.ExecuteNonQuery()
            Label4.Text = "Database mode set to single user"
            con2.Close()
            Dim restorecommand = New SqlCommand("Restore database " & ComboBox2.Text.Trim & " from disk='C:\DBBackup\" & ComboBox3.Text & ".bak'", con2)
            con2.Open()
            restorecommand.ExecuteNonQuery()
            Label4.Text = Label4.Text & vbNewLine & "Database restoration completed successfully"
            con2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Dim con2 As SqlConnection
            con2 = New SqlConnection("Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;")
            Dim Alter2 As String = "ALTER DATABASE " & ComboBox2.Text.Trim & " SET Multi_User"
            Dim Alter2Cmd As SqlCommand = New SqlCommand(Alter2, con2)
            con2.Open()
            Alter2Cmd.ExecuteNonQuery()
            con2.Close()
            Label4.Text = Label4.Text & vbNewLine & "Database mode set to multiuser"

        End Try
        Dim con As String = "Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        Using dconn As New SqlConnection(con)
            Dim insertcommand As New SqlCommand
            insertcommand.Connection = dconn
            insertcommand.CommandType = CommandType.Text
            insertcommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            insertcommand.Connection.Open()
            insertcommand.Parameters.AddWithValue("@StockCode", "ALL")
            insertcommand.Parameters.AddWithValue("@SupplierRef", "ALL")
            insertcommand.Parameters.AddWithValue("@Location", "ALL")
            insertcommand.Parameters.AddWithValue("@Qty", "0")
            insertcommand.Parameters.AddWithValue("@MovementType", "Restore")
            insertcommand.Parameters.AddWithValue("@RecordType", "Restore")
            insertcommand.Parameters.AddWithValue("@MovementDate", Date.Now)
            insertcommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            insertcommand.Parameters.AddWithValue("@Reference", " ")
            insertcommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            insertcommand.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPage2 Then

            ComboBox3.Items.Clear()
            For Each file As String In IO.Directory.GetFiles("C:\DBBackup\")
                ComboBox3.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file))
            Next
        End If
    End Sub
End Class
