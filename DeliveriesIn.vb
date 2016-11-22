Imports System.Data.SqlClient

Public Class DeliveriesIn
    Dim connectionString As String = "Initial Catalog=DMHStockv4;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    ' Create a DataSet
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim duplicateCommand As New SqlCommand
    Dim selectcommand As New SqlCommand
    Dim strShop As String
    Dim strStock As String
    Dim strWarehouse As String
    Dim strStockCode As String
    'GET LAST SATURDAY
    Dim dLastSaturday As Date = Date.Now.AddDays(-(Now.DayOfWeek + 1))
    'GET LAST SUNDAY
    Dim dLastSunday As Date = Date.Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub DeliveryLog()
        Using dconn As New SqlConnection(connectionString)
            Dim insertcmd As New SqlCommand
            insertcmd.Connection = dconn
            insertcmd.CommandType = CommandType.Text
            insertcmd.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            insertcmd.Connection.Open()
            insertcmd.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@Qty", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
            InsertCommand.Parameters.AddWithValue("@RecordType", "Purchase-Add")
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            InsertCommand.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub DeliveriesIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DateTimePicker1.Value = dLastSunday
        CheckBox2.Visible = False
        txtBoxes.Text = "0"
        txtHangers.Text = "0"
        txtWarehouseRef.Text = "UNI"
        txtWarehouseName.Text = "Universal Warehouse"
        If Main.txtMode.Text = "OLD" Then loadOld()
        If Main.txtMode.Text = "NEW" Then LoadNew()
        If Main.txtMode.Text = "DELETE" Then DeleteRecord()
    End Sub
    Private Sub loadOld()
        Dim i As Integer
        i = Main.DataGridView1.CurrentRow.Index
        txtOrderID.Text = Main.DataGridView1.Item(0, i).Value
        txtOurRef.Text = Main.DataGridView1.Item(1, i).Value
        txtSupplierRef.Text = Main.DataGridView1.Item(2, i).Value
        txtSupplierName.Text = Main.DataGridView1.Item(3, i).Value
        txtWarehouseRef.Text = Main.DataGridView1.Item(4, i).Value
        txtWarehouseName.Text = Main.DataGridView1.Item(5, i).Value
        txtStockCode.Text = Main.DataGridView1.Item(6, i).Value
        txtQtyGarments.Text = Main.DataGridView1.Item(7, i).Value
        txtTotalGarments.Text = Main.DataGridView1.Item(7, i).Value
        txtHangers.Text = Main.DataGridView1.Item(9, i).Value
        txtBoxes.Text = Main.DataGridView1.Item(8, i).Value
        txtNetCost.Text = Main.DataGridView1.Item(13, i).Value
        txtTotalNet.Text = Main.DataGridView1.Item(16, i).Value
        txtDelCharges.Text = Main.DataGridView1.Item(14, i).Value
        txtCommission.Text = Main.DataGridView1.Item(15, i).Value
        txtTotal.Text = Main.DataGridView1.Item(16, i).Value
        txtSupplierInv.Text = Main.DataGridView1.Item(21, i).Value.ToString
        txtShipper.Text = Main.DataGridView1.Item(22, i).Value.ToString
        txtShipperInv.Text = Main.DataGridView1.Item(23, i).Value.ToString
        DateTimePicker1.Value = Main.DataGridView1.Item(17, i).Value
        CheckBox1.Visible = False
        CheckBox2.Visible = False
        Me.Text = "Delivery for [" + txtWarehouseName.Text + "]"
        txtNetCost.Text = FormatCurrency(txtNetCost.Text)
        txtTotalNet.Text = FormatCurrency(txtTotalNet.Text)
        txtCommission.Text = FormatCurrency(txtCommission.Text)
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        txtDelCharges.Text = FormatCurrency(txtDelCharges.Text)
        Label18.Text = "Location Ref:"
        Label20.Text = "Location Name:"
        cmdOK.Text = "OK"
        cmdOK.Select()
    End Sub
    Private Sub LoadNew()
        txtWarehouseRef.Enabled = False
        txtWarehouseName.Enabled = False
        DateTimePicker1.Value = dLastSunday
        cmdOK.Text = "Add"
        Try
            Dim sqlds As New DataSet
            Dim adp As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm As New SqlCommand("SELECT SupplierRef From tblSuppliers", connection)
            comm.CommandType = CommandType.Text
            adp.SelectCommand = comm
            adp.Fill(sqlds)
            comm.Dispose()
            adp.Dispose()
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To sqlds.Tables(0).Rows.Count - 1
                ACSC.Add(sqlds.Tables(0).Rows(i).Item(0).ToString)
            Next
            txtSupplierRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSupplierRef.AutoCompleteCustomSource = ACSC
            txtSupplierRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()
            Me.Text = "Delivery for [" + txtWarehouseName.Text + "]"
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        Try
            Dim sqlds As New DataSet
            Dim adp As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm As New SqlCommand("SELECT StockCode From tblStock where DeadCode='0'", connection)
            comm.CommandType = CommandType.Text
            adp.SelectCommand = comm
            adp.Fill(sqlds)
            comm.Dispose()
            adp.Dispose()
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To sqlds.Tables(0).Rows.Count - 1
                ACSC.Add(sqlds.Tables(0).Rows(i).Item(0).ToString)
            Next
            txtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtStockCode.AutoCompleteCustomSource = ACSC
            txtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()

        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        Try
            Dim sqlds4 As New DataSet
            Dim adp4 As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm4 As New SqlCommand("SELECT ShopRef From tblShops", connection)
            comm4.CommandType = CommandType.Text
            adp4.SelectCommand = comm4
            adp4.Fill(sqlds4)
            comm4.Dispose()
            adp4.Dispose()
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To sqlds4.Tables(0).Rows.Count - 1
                ACSC.Add(sqlds4.Tables(0).Rows(i).Item(0).ToString)
            Next
            txtWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtWarehouseRef.AutoCompleteCustomSource = ACSC
            txtWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()
            Me.Text = "Delivery for [" + txtWarehouseName.Text + "]"
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblStockMovements WHERE SMstockcode = '" + txtStockCode.Text + "' AND MovementType <> 'Delivery (W)'"
            queryResult = duplicateCommand.ExecuteNonQuery()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Stock Record :" + txtStockCode.Text + " Has Other records ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Dim i As Integer
        i = Main.DataGridView1.CurrentRow.Index
        txtOrderID.Text = Main.DataGridView1.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblDeliveries WHERE DeliveriesID='" & txtOrderID.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblStockmovements WHERE TransferReference='" & txtOrderID.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        Main.PurchaseOrdersToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then Label18.Text = "Shop Ref:" : Label20.Text = "Shop Name:" : CheckBox2.Visible = False : DateTimePicker1.Value = dLastSunday.AddDays(7) : txtWarehouseRef.Text = "" : txtWarehouseName.Text = "" : txtWarehouseRef.Enabled = True : txtWarehouseName.Enabled = True
        If CheckBox1.Checked = False Then Label18.Text = "Warehouse Ref:" : Label20.Text = "Warehouse Name:" : CheckBox2.Visible = False : DateTimePicker1.Value = dLastSunday : txtWarehouseRef.Text = "Uni" : txtWarehouseName.Text = "Universal Warehouse" : txtWarehouseRef.Enabled = False : txtWarehouseName.Enabled = False
    End Sub
    Private Sub cmdFindWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindWarehouse.Click
        If CheckBox1.Checked = True Then findshops()
        If CheckBox1.Checked = False Then findwarehouse()
        Me.Text = "Delivery For: [" + txtWarehouseRef.Text + "] " + txtWarehouseName.Text
    End Sub
    Private Sub findshops()
        Dim shoptype As String
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select ShopName From tblShops Where ShopRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtWarehouseName.Text = selectcommand.ExecuteScalar
        selectcommand.CommandText = "Select ShopType From tblShops Where ShopRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        shoptype = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
        If shoptype = "Shop" Then CheckBox2.Checked = False
        If shoptype <> "Shop" Then CheckBox2.Checked = True
    End Sub
    Private Sub findwarehouse()
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select WarehouseName From tblWarehouses Where WarehouseRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtWarehouseName.Text = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
    End Sub
    Private Sub txtNetCost_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNetCost.LostFocus
        If txtNetCost.Text = "" Then MsgBox("please enter a Money Value", vbExclamation + vbOKOnly, ProductName)
        txtNetCost.Text = FormatCurrency(txtNetCost.Text)
        txtTotalNet.Text = FormatCurrency(txtNetCost.Text)
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        CalculateTotals()
    End Sub
    Private Sub txtStockCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStockCode.LostFocus
        If txtStockCode.Text = "" Then MsgBox("Please Enter a Stock Code", vbExclamation + vbOKOnly, ProductName)
        txtStockCode.Text = UCase(txtStockCode.Text)
        txtOurRef.Text = txtStockCode.Text
        txtOurRef.Text = UCase(txtOurRef.Text)
    End Sub
    Private Sub txtWarehouseRef_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWarehouseRef.LostFocus
        ' cmdFindWarehouse.PerformClick()
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select ShopName From tblShops Where ShopRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtWarehouseName.Text = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
        txtWarehouseRef.Text = UCase(txtWarehouseRef.Text)
    End Sub
    Private Sub txtSupplierRef_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSupplierRef.LostFocus
        'cmdFindSupplier.PerformClick()
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select SupplierName From tblSuppliers Where SupplierRef = '" & txtSupplierRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtSupplierName.Text = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
        txtSupplierRef.Text = UCase(txtSupplierRef.Text)
    End Sub
    Private Sub txtDelCharges_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDelCharges.LostFocus
        txtDelCharges.Text = FormatCurrency(txtDelCharges.Text)
        CalculateTotals()
    End Sub
    Private Sub CalculateTotals()
        Dim curNetTotal As Decimal
        curNetTotal = 0
        txtTotalNet.Text = FormatCurrency(txtTotalNet.Text)
        txtTotal.Text = FormatCurrency(CDec(txtTotalNet.Text) + CDec(txtCommission.Text) + CDec(txtDelCharges.Text))

    End Sub
    Private Sub GarmentsTotal()
        '  txtTotalGarments.Text = (CInt(txtHangers.Text) + CInt(txtQtyGarments.Text) + CInt(txtBoxes.Text))
        txtTotalGarments.Text = txtQtyGarments.Text
        txtHangers.Text = txtQtyGarments.Text
    End Sub
    Private Sub txtCommission_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommission.LostFocus
        txtCommission.Text = FormatCurrency(txtCommission.Text)
        CalculateTotals()
    End Sub
    Private Sub AddRecord()
        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblStock WHERE StockCode = '" + txtStockCode.Text.ToString() + "'"
            queryResult = duplicateCommand.ExecuteScalar()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then MessageBox.Show("Stock Record : [" + txtStockCode.Text + "] Already Exists in the database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) : txtStockCode.SelectAll() : Exit Sub
            If queryResult = 0 Then CreateStock()
        Catch ex As Exception
            MessageBox.Show("Error in database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub CreateStock()
        Try
            Dim insertdb As String = " INSERT INTO tblStock (StockCode,SupplierRef,DeadCode,DeliveredQtyHangers,AmountTaken,CostValue,PCMarkUp,ZeroQty,CreatedBy,CreatedDate) VALUES (@StockCode,@SupplierRef,@DeadCode,@DeliveredQtyHangers,@AmountTaken,@CostValue,@PCMarkUp,@ZeroQty,@CreatedBy,@CreatedDate)"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(insertdb, connection)
            com.Connection.Open()
            com.Parameters.AddWithValue("@ZeroQty", "0")
            com.Parameters.AddWithValue("@StockCode", txtStockCode.Text.ToString)
            com.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text.ToString)
            com.Parameters.AddWithValue("@DeadCode", "0")
            com.Parameters.AddWithValue("@AmountTaken", "0.00")
            com.Parameters.AddWithValue("@CostValue", txtTotalNet.Text)
            com.Parameters.AddWithValue("@PCMarkUp", "0")
            com.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            com.Parameters.AddWithValue("@CreatedDate", Date.Now)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", txtTotalGarments.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            ' Main.StockToolStripMenuItem.PerformClick()
            '  MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
        Using dconn As New SqlConnection(connectionString)
            Dim InsertCommand As New SqlCommand
            InsertCommand.Connection = dconn
            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@Qty", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
            InsertCommand.Parameters.AddWithValue("@RecordType", "Purchase-Add")
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            InsertCommand.ExecuteNonQuery()
        End Using
    End Sub
    Private Sub CreateShopDelivery()
        Dim insertcommand1 As New SqlCommand
        AddRecord()
        Try
            Dim id As Integer
            ' Create record for the Delviery
            InsertCommand.Connection = connection
            InsertCommand.Connection.Open()
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertDeliveries"
            ' Create a DataSet
            Me.Validate()
            InsertCommand.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text)
            InsertCommand.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@LocationName", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@DQtyGarments", txtQtyGarments.Text)
            InsertCommand.Parameters.AddWithValue("@DQtyBoxes", txtBoxes.Text)
            InsertCommand.Parameters.AddWithValue("@DQtyHangers", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@TotalGarments", txtQtyGarments.Text)
            InsertCommand.Parameters.AddWithValue("@TotalBoxes", txtBoxes.Text)
            InsertCommand.Parameters.AddWithValue("@TotalHangers", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@NetAmount", txtTotalNet.Text)
            InsertCommand.Parameters.AddWithValue("@Commission", txtCommission.Text)
            InsertCommand.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@DeliveryType", "Confirmed")
            InsertCommand.Parameters.AddWithValue("@ConfirmedDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@Notes", "")
            InsertCommand.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryCharge", txtDelCharges.Text)
            InsertCommand.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            InsertCommand.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Now)
            InsertCommand.Parameters.Add("@DeliveriesId", SqlDbType.Int, 0, "DeliveriesId")
            InsertCommand.Parameters("@DeliveriesId").Direction = ParameterDirection.Output
            InsertCommand.ExecuteNonQuery()
            id = InsertCommand.Parameters("@DeliveriesId").Value
            ' Dim newID As Integer = CInt(InsertCommand.ExecuteScalar())
            txtOrderID.Text = id
            ' Create record in the Stock Movements Table.
            InsertCommand.Connection = connection
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertStockMovements"
            InsertCommand.Connection.Close()
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
            If CheckBox2.Checked = True Then InsertCommand.Parameters.AddWithValue("@LocationType", "Consession")
            If CheckBox2.Checked = False Then InsertCommand.Parameters.AddWithValue("@LocationType", "Shop")
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", Main.TextBox1.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            InsertCommand.ExecuteNonQuery()
            Main.PurchaseOrdersToolStripMenuItem.PerformClick()
            'MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
            InsertCommand1.Parameters.Clear()
            InsertCommand1.Connection = connection
            InsertCommand1.CommandText = "INSERT INTO tblStockMovementsSDel (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementQtyBoxes,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementQtyBoxes,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            insertcommand1.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@SMSupplierRef", "")
            InsertCommand1.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
            InsertCommand1.Parameters.AddWithValue("@SMLocationType", "Shop")
            insertcommand1.Parameters.AddWithValue("@MovementQtyHangers", txtTotalGarments.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@MovementQtyBoxes", "0")
            InsertCommand1.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            InsertCommand1.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            insertcommand1.Parameters.AddWithValue("@MovementValue", txtNetCost.ToString())
            insertcommand1.Parameters.AddWithValue("@Reference", txtOrderID.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            insertcommand1.Parameters.AddWithValue("@SMCreatedBy", Main.TextBox1.Text.ToString())
            InsertCommand1.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            InsertCommand1.Connection.Open()
            InsertCommand1.ExecuteNonQuery()
            InsertCommand1.Connection.Close()
            Using upe As New SqlConnection(connectionString)
                Dim insertcommand As New SqlCommand()
                insertcommand.Connection = upe
                insertcommand.CommandType = CommandType.Text
                insertcommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES (@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementQtyBoxes,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                insertcommand.Connection.Open()
                insertcommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
                insertcommand.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
                insertcommand.Parameters.AddWithValue("@SMLocation", "UNI")
                insertcommand.Parameters.AddWithValue("@SMLocationType", "Warehouse")
                insertcommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
                insertcommand.Parameters.AddWithValue("@MovementQtyHangers", "0")
                insertcommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                insertcommand.Parameters.AddWithValue("@MovementValue", "0")
                insertcommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
                insertcommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
                insertcommand.Parameters.AddWithValue("@SMCreatedBy", Main.TextBox1.Text)
                insertcommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
                insertcommand.ExecuteNonQuery()
            End Using
            Using upe As New SqlConnection(connectionString)
                Dim insertcommand2 As New SqlCommand()

                insertcommand2.Connection = upe
                insertcommand2.CommandType = CommandType.Text
                insertcommand2.CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,CurrentQty,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@CurrentQty,@QtySold,@SalesAmount,@StockMovementID)"
                insertcommand2.Parameters.AddWithValue("@SalesID", "0")
                insertcommand2.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                insertcommand2.Parameters.AddWithValue("@CurrentQty", "0")
                insertcommand2.Parameters.AddWithValue("@QtySold", "0")
                insertcommand2.Parameters.AddWithValue("@SalesAmount", "0.00")
                insertcommand2.Parameters.AddWithValue("@StockMovementID", "0")
                insertcommand2.Connection.Open()
                insertcommand2.ExecuteNonQuery()
                insertcommand2.Parameters.Clear()
                insertcommand2.Connection.Close()
            End Using
            Using dconn As New SqlConnection(connectionString)
                Dim InsertCommand As New SqlCommand
                InsertCommand.Connection = dconn
                InsertCommand.CommandType = CommandType.Text
                InsertCommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
                InsertCommand.Connection.Open()
                InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
                InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseName.Text)
                InsertCommand.Parameters.AddWithValue("@Qty", txtHangers.Text)
                InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
                InsertCommand.Parameters.AddWithValue("@RecordType", "Purchase-Add")
                InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                InsertCommand.Parameters.AddWithValue("@Timestamp", Date.Now)
                InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
                InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
                InsertCommand.ExecuteNonQuery()
            End Using
            Me.Close()

        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub
    Private Sub CreateDelivery()

        AddRecord()
        Try
            Dim id As Integer
            ' Create record for the Delviery
            InsertCommand.Connection = connection
            InsertCommand.Connection.Open()
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertDeliveries"
            ' Create a DataSet
            Me.Validate()
            InsertCommand.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text)
            InsertCommand.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@LocationName", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@DQtyGarments", txtQtyGarments.Text)
            InsertCommand.Parameters.AddWithValue("@DQtyBoxes", txtBoxes.Text)
            InsertCommand.Parameters.AddWithValue("@DQtyHangers", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@TotalGarments", txtQtyGarments.Text)
            InsertCommand.Parameters.AddWithValue("@TotalBoxes", txtBoxes.Text)
            InsertCommand.Parameters.AddWithValue("@TotalHangers", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@NetAmount", txtTotalNet.Text)
            InsertCommand.Parameters.AddWithValue("@Commission", txtCommission.Text)
            InsertCommand.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@DeliveryType", "Confirmed")
            InsertCommand.Parameters.AddWithValue("@ConfirmedDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@Notes", "")
            InsertCommand.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryCharge", txtDelCharges.Text)
            InsertCommand.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            InsertCommand.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Now)
            InsertCommand.Parameters.Add("@DeliveriesId", SqlDbType.Int, 0, "DeliveriesId")
            InsertCommand.Parameters("@DeliveriesId").Direction = ParameterDirection.Output
            InsertCommand.ExecuteNonQuery()
            id = InsertCommand.Parameters("@DeliveriesId").Value
            ' Dim newID As Integer = CInt(InsertCommand.ExecuteScalar())
            txtOrderID.Text = id
            InsertCommand.Connection.Close()
            ' Create record in the Stock Movements Table.
            InsertCommand.Connection = connection
            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES (@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementQtyBoxes,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
            If CheckBox1.Checked = True Then InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop")
            'If CheckBox1.Checked = True And CheckBox2.Checked = True Then InsertCommand.Parameters.AddWithValue("@SMLocationType", "Consession")
            If CheckBox1.Checked = False Then InsertCommand.Parameters.AddWithValue("@SMLocationType", "Warehouse")
            If CheckBox1.Checked = True Then InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            If CheckBox1.Checked = False Then InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", txtHangers.Text)
            InsertCommand.Parameters.AddWithValue("@MovementQtyBoxes", txtBoxes.Text)
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", Main.TextBox1.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            InsertCommand.ExecuteNonQuery()
            Main.PurchaseOrdersToolStripMenuItem.PerformClick()
            InsertCommand.Connection.Close()
            Using dconn As New SqlConnection(connectionString)
                Dim InsertCommand As New SqlCommand
                InsertCommand.Connection = dconn
                InsertCommand.CommandType = CommandType.Text
                InsertCommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
                InsertCommand.Connection.Open()
                InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
                InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseName.Text)
                InsertCommand.Parameters.AddWithValue("@Qty", txtHangers.Text)
                InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
                InsertCommand.Parameters.AddWithValue("@RecordType", "Purchase-Add")
                InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                InsertCommand.Parameters.AddWithValue("@Timestamp", Date.Now)
                InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
                InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
                InsertCommand.ExecuteNonQuery()
            End Using
            If CheckBox1.Checked = True Then
                Using upe As New SqlConnection(connectionString)
                    Dim insertcommand As New SqlCommand()
                    insertcommand.Connection = upe
                    insertcommand.CommandType = CommandType.Text
                    insertcommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES (@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementQtyBoxes,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                    insertcommand.Connection.Open()
                    insertcommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
                    insertcommand.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
                    insertcommand.Parameters.AddWithValue("@SMLocation", "UNI")
                    insertcommand.Parameters.AddWithValue("@SMLocationType", "Warehouse")
                    insertcommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
                    insertcommand.Parameters.AddWithValue("@MovementQtyHangers", "0")
                    insertcommand.Parameters.AddWithValue("@MovementQtyBoxes", "0")
                    insertcommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                    insertcommand.Parameters.AddWithValue("@MovementValue", "0")
                    insertcommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
                    insertcommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
                    insertcommand.Parameters.AddWithValue("@SMCreatedBy", Main.TextBox1.Text)
                    insertcommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
                    insertcommand.ExecuteNonQuery()
                End Using
                Using upe1 As New SqlConnection(connectionString)
                    Dim insertcommand2 As New SqlCommand()

                    insertcommand2.Connection = upe1
                    insertcommand2.CommandType = CommandType.Text
                    insertcommand2.CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,CurrentQty,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@CurrentQty,@QtySold,@SalesAmount,@StockMovementID)"
                    insertcommand2.Parameters.AddWithValue("@SalesID", "0")
                    insertcommand2.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                    insertcommand2.Parameters.AddWithValue("@CurrentQty", "0")
                    insertcommand2.Parameters.AddWithValue("@QtySold", "0")
                    insertcommand2.Parameters.AddWithValue("@SalesAmount", "0.00")
                    insertcommand2.Parameters.AddWithValue("@StockMovementID", "0")
                    insertcommand2.Connection.Open()
                    insertcommand2.ExecuteNonQuery()
                    insertcommand2.Parameters.Clear()
                    insertcommand2.Connection.Close()
                End Using
                Me.Close()
                Main.RefreshToolStripButton.PerformClick()
            Else
                Using upe As New SqlConnection(connectionString)
                    Dim insertcommand As New SqlCommand()
                    insertcommand.Connection = upe
                    insertcommand.CommandType = CommandType.Text
                    insertcommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES (@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementQtyBoxes,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                    insertcommand.Connection.Open()
                    insertcommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
                    insertcommand.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
                    insertcommand.Parameters.AddWithValue("@SMLocation", "DU")
                    insertcommand.Parameters.AddWithValue("@SMLocationType", "Shop")
                    insertcommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
                    insertcommand.Parameters.AddWithValue("@MovementQtyHangers", "0")
                    insertcommand.Parameters.AddWithValue("@MovementQtyBoxes", "0")
                    insertcommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                    insertcommand.Parameters.AddWithValue("@MovementValue", "0")
                    insertcommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
                    insertcommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
                    insertcommand.Parameters.AddWithValue("@SMCreatedBy", Main.TextBox1.Text)
                    insertcommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
                    insertcommand.ExecuteNonQuery()
                End Using
                Using upe1 As New SqlConnection(connectionString)
                    Dim insertcommand2 As New SqlCommand()

                    insertcommand2.Connection = upe1
                    insertcommand2.CommandType = CommandType.Text
                    insertcommand2.CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,CurrentQty,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@CurrentQty,@QtySold,@SalesAmount,@StockMovementID)"
                    insertcommand2.Parameters.AddWithValue("@SalesID", "0")
                    insertcommand2.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                    insertcommand2.Parameters.AddWithValue("@CurrentQty", "0")
                    insertcommand2.Parameters.AddWithValue("@QtySold", "0")
                    insertcommand2.Parameters.AddWithValue("@SalesAmount", "0.00")
                    insertcommand2.Parameters.AddWithValue("@StockMovementID", "0")
                    insertcommand2.Connection.Open()
                    insertcommand2.ExecuteNonQuery()
                    insertcommand2.Parameters.Clear()
                    insertcommand2.Connection.Close()
                End Using
                Me.Close()
                Main.RefreshToolStripButton.PerformClick()
            End If

        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub

    Private Sub txtQtyGarments_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtyGarments.LostFocus

        If txtQtyGarments.Text = "" Then MsgBox("Please enter a quantity to be delivered!", vbExclamation + vbOKOnly, ProductName)
        '  txtTotalGarments.Text = txtQtyGarments.Text
        GarmentsTotal()
    End Sub
    Private Sub txtQtyGarments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyGarments.TextChanged

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        '   If CheckBox1.Checked = True Then CreateShopDelivery()
        '  If CheckBox1.Checked = False Then CreateDelivery()
        If txtStockCode.Text = "" Then MsgBox("Please enter a stock code!", vbExclamation, Application.ProductName)
        If txtSupplierRef.Text = "" Then MsgBox("Please enter a supplier ref!", vbExclamation, Application.ProductName)
        If txtNetCost.Text = "" Then MsgBox("please enter a Money Value!", vbExclamation, ProductName)
        If txtStockCode.Text <> "" And txtSupplierRef.Text <> "" And txtNetCost.Text <> "" And cmdOK.Text = "Add" Then CreateDelivery()
        If cmdOK.Text = "OK" And txtWarehouseRef.Text = "UNI" Then
            updaterecord()
        ElseIf cmdOK.Text = "OK" And txtWarehouseRef.Text <> "UNI" Then
            updaterecordShop()
        End If
    End Sub

    Private Sub cmdFindSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFindSupplier.Click
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select SupplierName From tblSuppliers Where SupplierRef = '" & txtSupplierRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtSupplierName.Text = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
    End Sub
    Private Sub updaterecord()

        Try
            Dim updatedb As String = " UPDATE tblStock SET SupplierRef = @SupplierRef,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers, CostValue = @CostValue WHERE StockCode = '" + txtStockCode.Text + "';"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(updatedb, connection)
            com.Connection.Open()
            '  com.Parameters.AddWithValue("@StockCode", txtStockCode.Text.ToString)
            com.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text.ToString)
            ' com.Parameters.AddWithValue("@Season", SeasonComboBox.Text.ToString)
            com.Parameters.AddWithValue("@DeadCode", "0")
            'com.Parameters.AddWithValue("@RemoveFromClearance", RemoveFromClearanceCheckBox.CheckState)
            'com.Parameters.AddWithValue("@AmountTaken", "0.00")
            com.Parameters.AddWithValue("@CostValue", txtTotalNet.Text)
            ' com.Parameters.AddWithValue("@PCMarkUp", "0")
            'com.Parameters.AddWithValue("@ZeroQty", "0")
            ' com.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", txtTotalGarments.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            Dim updatedb2 As String = " UPDATE tblStockMovements SET SMStockCode = @SMStockCode,SMSupplierRef = @SMSupplierRef, MovementQtyHangers = @MovementQtyHangers, MovementQtyBoxes = @MovementQtyBoxes, MovementDate = @MovementDate,MovementValue = @MovementValue WHERE TransferReference = @TransferReference;"
            Dim updatedb3 As String = " UPDATE tblDeliveries SET OurRef = @OurRef, SupplierRef = @SupplierRef,SupplierName = @SupplierName,LocationRef = @LocationRef,LocationName = @LocationName , StockCode = @StockCode, DQtyGarments = @DQtyGarments, DQtyBoxes = @DQtyBoxes, DQtyHangers = @DQtyHangers, TotalGarments = @TotalGarments,TotalBoxes = @TotalBoxes, TotalHangers = @TotalHangers, NetAmount = @NetAmount, DeliveryCharge = @DeliveryCharge, Commission = @Commission, TotalAmount = @TotalAmount, InvoiceNo = @InvoiceNo, Shipper = @Shipper, ShipperInvoice = @ShipperInvoice, DeliveryDate = @DeliveryDate WHERE DeliveriesID = '" + txtOrderID.Text + "';"
            Dim update1 As New SqlCommand(updatedb2, connection)
            Dim update2 As New SqlCommand(updatedb3, connection)
            update2.Connection.Open()
            update2.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            update2.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            update2.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text)
            update2.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text)
            update2.Parameters.AddWithValue("@LocationName", txtWarehouseName.Text)
            update2.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            update2.Parameters.AddWithValue("@DQtyGarments", txtQtyGarments.Text)
            update2.Parameters.AddWithValue("@DQtyBoxes", txtBoxes.Text)
            update2.Parameters.AddWithValue("@DQtyHangers", txtHangers.Text)
            update2.Parameters.AddWithValue("@TotalGarments", txtQtyGarments.Text)
            update2.Parameters.AddWithValue("@TotalBoxes", txtBoxes.Text)
            update2.Parameters.AddWithValue("@TotalHangers", txtHangers.Text)
            update2.Parameters.AddWithValue("@NetAmount", txtNetCost.Text)
            update2.Parameters.AddWithValue("@DeliveryCharge", txtDelCharges.Text)
            update2.Parameters.AddWithValue("@Commission", txtCommission.Text)
            update2.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            update2.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            update2.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            update2.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            update2.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            update2.ExecuteNonQuery()
            update2.Connection.Close()
            update1.Connection.Open()
            update1.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
            update1.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
            update1.Parameters.AddWithValue("@MovementQtyHangers", txtHangers.Text)
            update1.Parameters.AddWithValue("@MovementQtyBoxes", txtBoxes.Text)
            update1.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            update1.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            update1.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            update1.ExecuteNonQuery()
            update1.Connection.Close()
            MsgBox("Update Successful", MsgBoxStyle.Information, ProductName)
            Main.PurchaseOrdersToolStripMenuItem.PerformClick()
            Using dconn As New SqlConnection(connectionString)
                Dim insertcommand As New SqlCommand
                insertcommand.Connection = dconn
                insertcommand.CommandType = CommandType.Text
                insertcommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
                insertcommand.Connection.Open()
                insertcommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                insertcommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
                InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseName.Text)
                InsertCommand.Parameters.AddWithValue("@Qty", txtHangers.Text)
                InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
                InsertCommand.Parameters.AddWithValue("@RecordType", "Purchase-Update")
                InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                InsertCommand.Parameters.AddWithValue("@Timestamp", Date.Now)
                InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
                InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
                InsertCommand.ExecuteNonQuery()
            End Using
            Me.Close()
        Catch ex As SqlException
            MsgBox("Update Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, Application.ProductName)
        End Try
    End Sub

    Private Sub txtSupplierRef_TextChanged(sender As Object, e As EventArgs) Handles txtSupplierRef.TextChanged

    End Sub

    Private Sub txtShipper_LostFocus(sender As Object, e As EventArgs) Handles txtShipper.LostFocus
        txtShipper.Text = StrConv(txtShipper.Text, VbStrConv.ProperCase)

    End Sub
    Private Sub updaterecordShop()

        Try
            Dim updatedb As String = " UPDATE tblStock SET SupplierRef = @SupplierRef,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers, CostValue = @CostValue WHERE StockCode = '" + txtStockCode.Text + "';"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(updatedb, connection)
            com.Connection.Open()
            '  com.Parameters.AddWithValue("@StockCode", txtStockCode.Text.ToString)
            com.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text.ToString)
            ' com.Parameters.AddWithValue("@Season", SeasonComboBox.Text.ToString)
            com.Parameters.AddWithValue("@DeadCode", "0")
            'com.Parameters.AddWithValue("@RemoveFromClearance", RemoveFromClearanceCheckBox.CheckState)
            'com.Parameters.AddWithValue("@AmountTaken", "0.00")
            com.Parameters.AddWithValue("@CostValue", txtTotalNet.Text)
            ' com.Parameters.AddWithValue("@PCMarkUp", "0")
            'com.Parameters.AddWithValue("@ZeroQty", "0")
            ' com.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", txtTotalGarments.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            Dim updatedb2 As String = " UPDATE tblStockMovements SET SMStockCode = @SMStockCode,SMSupplierRef = @SMSupplierRef, MovementQtyHangers = @MovementQtyHangers, MovementQtyBoxes = @MovementQtyBoxes, MovementDate = @MovementDate,MovementValue = @MovementValue WHERE TransferReference = @TransferReference and MovementType = 'Delivery (S)';"
            Dim updatedb3 As String = " UPDATE tblDeliveries SET OurRef = @OurRef, SupplierRef = @SupplierRef,SupplierName = @SupplierName,LocationRef = @LocationRef,LocationName = @LocationName , StockCode = @StockCode, DQtyGarments = @DQtyGarments, DQtyBoxes = @DQtyBoxes, DQtyHangers = @DQtyHangers, TotalGarments = @TotalGarments,TotalBoxes = @TotalBoxes, TotalHangers = @TotalHangers, NetAmount = @NetAmount, DeliveryCharge = @DeliveryCharge, Commission = @Commission, TotalAmount = @TotalAmount, InvoiceNo = @InvoiceNo, Shipper = @Shipper, ShipperInvoice = @ShipperInvoice, DeliveryDate = @DeliveryDate WHERE DeliveriesID = '" + txtOrderID.Text + "';"
            Dim update1 As New SqlCommand(updatedb2, connection)
            Dim update2 As New SqlCommand(updatedb3, connection)
            update2.Connection.Open()
            update2.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            update2.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            update2.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text)
            update2.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text)
            update2.Parameters.AddWithValue("@LocationName", txtWarehouseName.Text)
            update2.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            update2.Parameters.AddWithValue("@DQtyGarments", txtQtyGarments.Text)
            update2.Parameters.AddWithValue("@DQtyBoxes", txtBoxes.Text)
            update2.Parameters.AddWithValue("@DQtyHangers", txtHangers.Text)
            update2.Parameters.AddWithValue("@TotalGarments", txtQtyGarments.Text)
            update2.Parameters.AddWithValue("@TotalBoxes", txtBoxes.Text)
            update2.Parameters.AddWithValue("@TotalHangers", txtHangers.Text)
            update2.Parameters.AddWithValue("@NetAmount", txtNetCost.Text)
            update2.Parameters.AddWithValue("@DeliveryCharge", txtDelCharges.Text)
            update2.Parameters.AddWithValue("@Commission", txtCommission.Text)
            update2.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            update2.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            update2.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            update2.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            update2.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            update2.ExecuteNonQuery()
            update2.Connection.Close()
            update1.Connection.Open()
            update1.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
            update1.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
            update1.Parameters.AddWithValue("@MovementQtyHangers", txtHangers.Text)
            update1.Parameters.AddWithValue("@MovementQtyBoxes", txtBoxes.Text)
            update1.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            update1.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            update1.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            update1.ExecuteNonQuery()
            update1.Connection.Close()
            Using dconn As New SqlConnection(connectionString)
                Dim insertcommand As New SqlCommand
                insertcommand.Connection = dconn
                insertcommand.CommandType = CommandType.Text
                insertcommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
                insertcommand.Connection.Open()
                insertcommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                insertcommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
                InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseName.Text)
                InsertCommand.Parameters.AddWithValue("@Qty", txtHangers.Text)
                InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
                InsertCommand.Parameters.AddWithValue("@RecordType", "Purchase-Update")
                InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                InsertCommand.Parameters.AddWithValue("@Timestamp", Date.Now)
                InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
                InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
                InsertCommand.ExecuteNonQuery()
            End Using
            MsgBox("Update Successful", MsgBoxStyle.Information, ProductName)
            Main.PurchaseOrdersToolStripMenuItem.PerformClick()
            Me.Close()
        Catch ex As SqlException
            MsgBox("Update Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, Application.ProductName)
        End Try
    End Sub
End Class