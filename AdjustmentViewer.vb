Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Adjustments
    Dim connectionString As String = "Initial Catalog=DMHStockv4;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        adjustmentupdate

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Adjustments_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Main.txtOption.Text = "Shop Adjustments" Then ShopAdjustments()
        If Main.txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustments()
    End Sub
    Private Sub WarehouseAdjustments()
        Me.Text = "Warehouse Adjustment"
        Dim i As Integer
        i = Main.DataGridView1.CurrentRow.Index
        Label9.Text = Main.DataGridView1.Item(0, i).Value
        TextBox1.Text = Main.DataGridView1.Item(1, i).Value
        TextBox2.Text = Main.DataGridView1.Item(2, i).Value
        TextBox3.Text = Main.DataGridView1.Item(3, i).Value
        TextBox4.Text = "Warehouse"
        TextBox5.Text = Main.DataGridView1.Item(4, i).Value
        TextBox6.Text = Main.DataGridView1.Item(6, i).Value
        DateTimePicker1.Value = Main.DataGridView1.Item(7, i).Value
        ComboBox1.Text = Main.DataGridView1.Item(8, i).Value

    End Sub
    Private Sub ShopAdjustments()
        Me.Text = "Shop Adjustment"
        Dim i As Integer
        i = Main.DataGridView1.CurrentRow.Index
        Label9.Text = Main.DataGridView1.Item(0, i).Value
        TextBox1.Text = Main.DataGridView1.Item(1, i).Value
        TextBox2.Text = Main.DataGridView1.Item(2, i).Value
        TextBox3.Text = Main.DataGridView1.Item(4, i).Value
        TextBox4.Text = "Shop"
        TextBox5.Text = Main.DataGridView1.Item(5, i).Value
        TextBox6.Text = Main.DataGridView1.Item(6, i).Value
        DateTimePicker1.Value = Main.DataGridView1.Item(7, i).Value
        ComboBox1.Text = Main.DataGridView1.Item(8, i).Value
    End Sub
    Private Sub adjustmentupdate()
        Using conn As New SqlConnection(connectionString)
            Dim insertcommand As New SqlCommand()
            insertcommand.Connection = conn
            insertcommand.CommandType = CommandType.Text
            insertcommand.CommandText = "UPDATE tblStockMovements SET Movementtype = @MovementType, MovementQtyHangers = @MovementQtyHangers, MovementValue = @MovementValue Where StockMovementID ='" + Label9.Text + "'"
            insertcommand.Parameters.AddWithValue("@MovementType", ComboBox1.Text)
            If ComboBox1.Text = "Stock Gain" Then insertcommand.Parameters.AddWithValue("@MovementQtyHangers", TextBox6.Text)
            If ComboBox1.Text = "Stock Loss" Then insertcommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(TextBox6.Text * -1))
            insertcommand.Parameters.AddWithValue("@MovementValue", "0")  '8
            insertcommand.Connection.Open()
            insertcommand.ExecuteNonQuery()
            conn.Close()
        End Using
        Using dconn As New SqlConnection(connectionString)
                Dim insertCommand2 As New SqlCommand

                insertCommand2.Connection = dconn
                insertCommand2.CommandType = CommandType.Text
                insertCommand2.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
                insertCommand2.Connection.Open()
                insertCommand2.Parameters.AddWithValue("@StockCode", TextBox5.Text)
                insertCommand2.Parameters.AddWithValue("@SupplierRef", " ")
                insertCommand2.Parameters.AddWithValue("@Location", TextBox3.Text)
                insertCommand2.Parameters.AddWithValue("@MovementQtyHangers", TextBox6.Text)
                insertCommand2.Parameters.AddWithValue("@MovementType", "Adjustments")
                insertCommand2.Parameters.AddWithValue("@RecordType", "Adjustment-Update")
                insertCommand2.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                insertCommand2.Parameters.AddWithValue("@Timestamp", Date.Now)
                insertCommand2.Parameters.AddWithValue("@Reference", Label9.Text)
                insertCommand2.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
                insertCommand2.ExecuteNonQuery()
            End Using

    End Sub
End Class
