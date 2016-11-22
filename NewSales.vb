Imports System.Data.SqlClient

Public Class NewSales
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim insertcommand2 As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim SelectCommand As New SqlCommand
    Dim selectcommand4 As New SqlCommand
    Dim strWarehouse As String
    Dim strStock As String
    Dim dds As DataTable = New DataTable()
    Dim dSales As DataSet

    Dim strStockCode As String
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub NewSales_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Main.txtMode.Text = "NEW" Then loadnew()
        If Main.txtMode.Text = "OLD" Then LoadOldRecord()
        If Main.txtMode.Text = "DELETE" Then DeleteRecords()
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        'If txtShopRef.Text = "" And DataGridView1.RowCount = 0 Then MsgBox("Please Enter a Shop Code and Add Some Sales before Continueing", MsgBoxStyle.Critical, ProductName) : txtShopRef.Select()
        If txtShopRef.Text <> "" Then createSales()
        'If txtShopRef.Text = "" Then MsgBox("Please Enter a Shop Code", vbExclamation, ProductName) : txtShopRef.Select()

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If txtShopRef.Text = "" And DataGridView1.RowCount = 0 Then MsgBox("Please Enter a Shop Code and Add Some Sales before Continueing", MsgBoxStyle.Critical, ProductName)
    End Sub

    Private Sub cmdAddToGrid_Click(sender As Object, e As EventArgs) Handles cmdAddToGrid.Click

        Try
            Dim rowNum As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(rowNum).Cells(0).Value = ComboBox1.Text.ToString()
            DataGridView1.Rows.Item(rowNum).Cells(1).Value = txtDelivered.Text.ToString()
            DataGridView1.Rows.Item(rowNum).Cells(3).Value = txtSoldToDate.Text.ToString()
            DataGridView1.Rows.Item(rowNum).Cells(2).Value = txtCurrentQty.Text.ToString()
            DataGridView1.Rows.Item(rowNum).Cells(5).Value = txtNetSale.Text.ToString()
            DataGridView1.Rows.Item(rowNum).Cells(4).Value = txtQty.Text.ToString()

            totals2()

            txtCurrentQty.Clear()
            txtNetSale.Clear()
            txtSoldToDate.Clear()
        Catch ex As Exception
            MsgBox("Please Enter a new Sales Record or delete this record", vbCritical, ProductName)
        End Try
        'Dim newrow As DataRow = dds.NewRow
        'newrow(0) = ComboBox1.Text
        'newrow(2) = txtDelivered.Text
        'newrow(1) = txtCurrentQty.Text
        'newrow(3) = txtSoldToDate.Text
        'newrow(4) = txtQty.Text
        'newrow(5) = txtNetSale.Text

        '        dds.Rows.Add(newrow)
        'DataGridView1.Rows.Add()


    End Sub

    Private Sub cmdDelToGrid_Click(sender As Object, e As EventArgs) Handles cmdDelToGrid.Click
        If DataGridView1.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
        End If

        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
        If DataGridView1.SelectedRows.Count < 1 Then
            MessageBox.Show("Select one or more rows before you click delete", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        Dim total5 As String = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total3 += DataGridView1.Rows(i).Cells(2).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        txtTotalCurrQty.Text = total2
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total2 += DataGridView1.Rows(i).Cells(3).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
    End Sub
    Private Sub loadnew()
        Dim VATRate As Double
        txtVATRate.Text = FormatPercent(VATRate, "0.00")
        DateTimePicker1.Value = dLastSunday
        cmdOK.Visible = False
        Try
            Dim sqlds As New DataSet
            Dim adp As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm As New SqlCommand("SELECT ShopRef From tblShops", connection)
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
            txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtShopRef.AutoCompleteCustomSource = ACSC
            txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()

        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try

    End Sub
    Private Sub LoadOldRecord()
        cmdAdd.Visible = False
        cmdOK.Visible = True
        Dim i As Integer
        i = Main.DataGridView1.CurrentRow.Index
        txtSalesID.Text = Main.DataGridView1.Item(0, i).Value
        DateTimePicker1.Value = Main.DataGridView1.Item(4, i).Value
        Label17.Text = Main.DataGridView1.Item(2, i).Value
        txtShopRef.Text = Main.DataGridView1.Item(1, i).Value
        txtTotalGarments.Text = Main.DataGridView1.Item(5, i).Value
        txtTotal.Text = Main.DataGridView1.Item(6, i).Value
        txtVATRate.Text = "0.00"
        LoadLines()
    End Sub
    Private Sub LoadLines()
        ' DataGridView1.Columns.Clear()
        Dim sql As String = "Select * from tblSalesLines Where SalesID='" + txtSalesID.Text + "'"

        Dim dtTable As DataTable
        Dim sqlCMD As New SqlCommand
        sqlCMD.CommandText = "Select * from tblSalesLines Where SalesID='" + txtSalesID.Text + "'"
        sqlCMD.CommandType = CommandType.Text
        sqlCMD.Connection = connection
        Dim sqladp As New SqlDataAdapter
        sqladp.SelectCommand = sqlCMD
        dtTable = New DataTable
        sqladp.Fill(dtTable)
        DataGridView1.DataSource = dtTable

        DataGridView1.AutoGenerateColumns = True
        DataGridView1.Columns.Item(0).Visible = False
        DataGridView1.Columns.Item(1).Visible = False
        DataGridView1.Columns.Item(2).Visible = False
        DataGridView1.Columns.Item(3).Visible = False
        DataGridView1.Columns.Item(4).Visible = False
        DataGridView1.Columns.Item(5).Visible = False
        DataGridView1.Columns.Item(6).Visible = False
        DataGridView1.Columns.Item(7).Visible = False
        DataGridView1.Columns.Item(12).Visible = False

        DataGridView1.Columns.Item(11).DefaultCellStyle.Format = "c"
        Dim lngQtyHangers As Long
        Dim curNetSales As Double
        Dim lngTotalDel As Long
        Dim lngTotalSold As Long
        Dim lngTotalCurrent As Long
        lngQtyHangers = 0
        curNetSales = 0
        lngTotalDel = 0
        lngTotalSold = 0
        lngTotalCurrent = 0

        ' If txtVATRate.Text = "" Then
        txtVATRate.Text = "0.00"
        ' End If
        For x As Integer = 0 To DataGridView1.RowCount - 1
            curNetSales += CLng(DataGridView1.Rows(x).Cells(11).Value)
            '  curNetSales += IIf(DataGridView1.Rows(x).Cells(11).Value = "", 0, DataGridView1.Rows(x).Cells(11).Value)

            lngQtyHangers += CLng(IIf(DataGridView1.Rows(x).Cells(4).Value = "", 0, DataGridView1.Rows(x).Cells(4).Value))
            lngTotalDel = 0
            'lngTotalDel += CLng(IIf(DataGridView1.Rows(x).Cells(1).Value = "", 0, DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CLng(DataGridView1.Rows(x).Cells(10).Value)
            lngTotalCurrent += CLng(DataGridView1.Rows(x).Cells(9).Value)
        Next
        txtTotalDelivered.Text = lngTotalDel
        '  txtTotalCurrQty.Text = lngTotalSold
        txtTotalSold.Text = lngTotalCurrent
        txtTotalGarments.Text = lngTotalSold
        txtNet.Text = curNetSales

        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat

        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)

        txtTotal.Text = FormatCurrency(txtTotal.Text)


    End Sub
    Private Sub DeleteRecords()
        Dim i As Integer
        i = Main.DataGridView1.CurrentRow.Index
        txtSalesID.Text = Main.DataGridView1.Item(0, i).Value
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "Delete From tblSalesLines where SalesID='" + txtSalesID.Text + "';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + txtSalesID.Text + "';Delete from tblSales where SalesID='" + txtSalesID.Text + "'"
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection.Open()
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        Main.SalesToolStripMenuItem.PerformClick()

        Me.Close()

    End Sub
    Private Sub SaveStockMovements()
        InsertCommand.CommandType = CommandType.Text
        InsertCommand.CommandText = " INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            InsertCommand.Parameters.Clear()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(0).Value) '1
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "") '2
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtShopRef.Text) '3 
            InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop") '4
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(4).Value * -1)) '5
            InsertCommand.Parameters.AddWithValue("@MovementType", "Sale") '6
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value) '7
            InsertCommand.Parameters.AddWithValue("@MovementValue", DataGridView1.Rows(i).Cells(5).Value) '8
            InsertCommand.Parameters.AddWithValue("@Reference", TextBox2.Text) '9
            InsertCommand.Parameters.AddWithValue("@TransferReference", CInt(txtSalesID.Text)) '10
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", Main.TextBox1.Text) '11
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now) '12
            InsertCommand.Parameters.Add("@StockMovementID", SqlDbType.Int, 16, "StockMovementID").Direction = ParameterDirection.Output '0
            InsertCommand.Connection.Close()
            InsertCommand.Connection.Open()
            InsertCommand.ExecuteNonQuery()

            insertcommand2.Connection = connection
            '  insertcommand2.Connection.ConnectionString = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
            Dim id2 As Integer


            '     id2 = InsertCommand.Parameters("@StockMovementID").Value
            Dim selectcommand4 As New SqlCommand
            selectcommand4.CommandText = "Select Max(StockMovementID) From tblStockMovements Where SMLocation='" + txtShopRef.Text + "' AND MovementType ='Sale'"
            selectcommand4.Connection = connection
            selectcommand4.Connection.Close()
            selectcommand4.CommandType = CommandType.Text
            selectcommand4.Connection = connection
            selectcommand4.Connection.Open()
            id2 = selectcommand4.ExecuteScalar()
            selectcommand4.Connection.Close()


            InsertCommand.Parameters.Clear()
            'For p As Integer = 0 To DataGridView1.Rows.Count - 1
            ' InsertCommand.CommandText = "Select @@Identity"
            '  Dim sid As Integer
            ' sid = InsertCommand.Parameters("@StockMovementID").Value
            ' InsertCommand.Parameters(0).Value = DataGridView1.Rows(i).Cells(1).Value
            'InsertCommand.Parameters(1).Value = Nothing
            '   InsertCommand.Parameters(2).Value = txtShopRef.Text
            '    InsertCommand.Parameters.AddWithValue("@LocationType", "Shop")
            '   InsertCommand.Parameters(7).Value = DataGridView1.Rows(i).Cells(6).Value
            '   InsertCommand.Parameters(5).Value = "Sale"
            '    InsertCommand.Parameters(6).Value = DateTimePicker1.Value
            '   InsertCommand.Parameters(4).Value = CInt(DataGridView1.Rows(i).Cells(5).Value * -1)
            '   InsertCommand.Parameters(8).Value = txtSalesID.Text.ToString()
            '   InsertCommand.Parameters(9).Value = txtSalesID.Text.ToString()
            '  InsertCommand.Parameters(10).Value = LoginForm.UsernameTextBox.Text
            '  InsertCommand.Parameters(11).Value = Date.Now
            ' InsertCommand.ExecuteNonQuery()
            'InsertCommand.CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@QtySold,@SalesAmount,@StockMovementID)"
            '  insertcommand2.Connection.Close()
            insertcommand2.Parameters.Clear()
            insertcommand2.Connection.Close()

            insertcommand2.CommandType = CommandType.Text
            insertcommand2.CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,CurrentQty,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@CurrentQty,@QtySold,@SalesAmount,@StockMovementID)"
            insertcommand2.Parameters.AddWithValue("@SalesID", txtSalesID.Text)
            insertcommand2.Parameters.AddWithValue("@StockCode", DataGridView1.Rows(i).Cells(0).Value)
            insertcommand2.Parameters.AddWithValue("@CurrentQty", DataGridView1.Rows(i).Cells(3).Value)
            insertcommand2.Parameters.AddWithValue("@QtySold", DataGridView1.Rows(i).Cells(4).Value)
            insertcommand2.Parameters.AddWithValue("@SalesAmount", DataGridView1.Rows(i).Cells(5).Value)
            insertcommand2.Parameters.AddWithValue("@StockMovementID", id2)
            insertcommand2.Connection.Open()
            insertcommand2.ExecuteNonQuery()
            insertcommand2.Parameters.Clear()
            insertcommand2.Connection.Close()
        Next
        InsertCommand.Connection.Close()
        insertcommand2.Connection.Close()
        Main.SalesToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub createSales()
        InsertCommand.Connection = connection
        InsertCommand.CommandText = "InsertSalesReturnID"
        InsertCommand.CommandType = CommandType.StoredProcedure
        InsertCommand.Parameters.AddWithValue("@ShopRef", txtShopRef.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@ShopName", Label17.Text)
        InsertCommand.Parameters.AddWithValue("@SAReference", TextBox2.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@TransactionDate", DateTimePicker1.Value)
        InsertCommand.Parameters.AddWithValue("@TotalQty", txtTotalGarments.Text)
        InsertCommand.Parameters.AddWithValue("@TotalValue", txtTotal.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
        InsertCommand.Parameters.Add("@SalesID", SqlDbType.Int, 0, "SalesID").Direction = ParameterDirection.Output
        InsertCommand.Connection.Open()
        InsertCommand.ExecuteNonQuery()
        ' InsertCommand.CommandText = "Select @@Identity"
        Dim id As Integer
        id = InsertCommand.Parameters("@SalesID").Value
        InsertCommand.Connection.Close()
        txtSalesID.Text = id
        InsertCommand.Parameters.Clear()
        SaveStockMovements()

    End Sub
    Private Sub totals2()
        ' Dim x As Integer
        Dim lngQtyHangers As Long
        Dim curNetSales As Double
        Dim lngTotalDel As Long
        Dim lngTotalSold As Long
        Dim lngTotalCurrent As Long
        lngQtyHangers = 0
        curNetSales = 0
        lngTotalDel = 0
        lngTotalSold = 0
        lngTotalCurrent = 0

        ' If txtVATRate.Text = "" Then
        txtVATRate.Text = "0.00"
        ' End If
        For x As Integer = 0 To DataGridView1.RowCount - 1
            '  curNetSales += CLng(DataGridView1.Rows(i).Cells(5).Value)
            curNetSales += CLng(IIf(DataGridView1.Rows(x).Cells(5).Value = "", 0, DataGridView1.Rows(x).Cells(5).Value))

            lngQtyHangers += CLng(IIf(DataGridView1.Rows(x).Cells(4).Value = "", 0, DataGridView1.Rows(x).Cells(4).Value))
            lngTotalDel += CLng(IIf(DataGridView1.Rows(x).Cells(1).Value = "", 0, DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CLng(IIf(DataGridView1.Rows(x).Cells(2).Value = "", 0, DataGridView1.Rows(x).Cells(2).Value))
            lngTotalCurrent += CLng(IIf(DataGridView1.Rows(x).Cells(3).Value = "", 0, DataGridView1.Rows(x).Cells(3).Value))
        Next
        txtTotalDelivered.Text = lngTotalDel
        txtTotalCurrQty.Text = lngTotalSold
        txtTotalSold.Text = lngTotalCurrent
        txtTotalGarments.Text = lngQtyHangers
        txtNet.Text = curNetSales
        ' Dim total2 As String = 0
        ' Dim total3 As String = 0
        ' Dim total4 As String = 0
        ' Dim total5 As String = 0
        '   Dim total As Integer = 0
        '   Dim total2 As Integer
        ' Dim total3 As Integer
        '    Dim total4 As Integer
        ' Dim total5 As Double
        '   For i As Integer = 0 To DataGridView1.RowCount - 1
        '   total += DataGridView1.Rows(i).Cells(1).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '   Next
        ' txtTotalDelivered.Text = total
        '  For i As Integer = 0 To DataGridView1.RowCount - 1
        '  total2 += DataGridView1.Rows(i).Cells(2).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '   Next
        ' txtTotalSold.Text = total2
        ' For i As Integer = 0 To DataGridView1.RowCount - 1
        'total3 += DataGridView1.Rows(i).Cells(3).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '  Next
        '  txtTotalCurrQty.Text = total3
        '  For i As Integer = 0 To DataGridView1.RowCount - 1
        ' total4 += DataGridView1.Rows(i).Cells(3).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '  Next
        ' txtNet.Text = total4
        '  For i As Integer = 0 To DataGridView1.RowCount - 1
        ' total5 += DataGridView1.Rows(i).Cells(11).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '    Next


        'txtTotalDelivered.Text = total
        '  txtTotalCurrQty.Text = total
        '  txtTotalSold.Text = total2
        '  txtTotalGarments.Text = total4
        ' txtNet.Text = total4
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat

        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        'Dim decCost As Double
        ' Dim qty As Double
        ' Dim override As Double
        '  Dim purchase As Double

        'calculate the purchase

        ' Note: i changed the "CDec" to "decimal.Parse"

        '  decCost = txtNet.Text
        '  override = txtVATRate.Text
        ' qty = Decimal.Parse(txtVAT.Text)
        ' qty = decCost * override
        '  txtVAT.Text = qty
        ' txtVAT.Text = FormatCurrency(txtVAT.Text)
        '  purchase = qty + decCost

        ' txtTotal.Text = purchase
        txtTotal.Text = FormatCurrency(txtTotal.Text)


        '  Dim RetailPrice As Double
        '  Dim RetailDisc As Double
        '  Dim DiscountResult As Double
        '  Dim DiscountValue As Double

        '  DiscountValue = RetailPrice * RetailDisc
        '   DiscountResult = RetailPrice - DiscountValue
        '  txtVAT.Text = DiscountValue
        '  txtTotal.Text = CDbl(DiscountResult).ToString()
        '  txtVAT.Text = FormatCurrency(txtVAT.Text)
        '  txtTotal.Text = FormatCurrency(txtTotal.Text)
        '  Dim totalsum As Integer
        '  For i As Integer = 0 To DataGridView1.Rows.Count - 1
        'totalsum += DataGridView1.Rows(i).Cells(5).Value
        '  Next
        '  txtTotal.Text = totalsum.ToString()
    End Sub

    Private Sub ComboBox1_LostFocus(sender As Object, e As EventArgs) Handles ComboBox1.LostFocus
        If ComboBox1.Items.Count > 0 Then
            Dim sql As String = "Select Qty,Delivered,Sold from qrySalesEntryQtyDelivered where SMStockCode ='" + ComboBox1.Text + "'"
            Dim cbodata As New SqlDataAdapter
            Dim dds As DataTable = New DataTable()
            cbodata.SelectCommand = New SqlCommand(sql, connection)
            cbodata.Fill(dds)
            txtCurrentQty.Text = dds.Rows(0)("Qty").ToString
            txtDelivered.Text = dds.Rows(0)("Delivered").ToString
            txtSoldToDate.Text = dds.Rows(0)("Sold").ToString
        Else
            txtCurrentQty.Text = "0"
            txtDelivered.Text = "0"
            txtSoldToDate.Text = "0"
        End If
    End Sub

    Private Sub txtShopRef_LostFocus(sender As Object, e As EventArgs) Handles txtShopRef.LostFocus
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "SELECT ShopName from tblShops Where ShopRef='" + txtShopRef.Text.Trim + "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        Label17.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
        Me.Text = "Sales for [" + txtShopRef.Text + "]  " + Label17.Text
        Dim sql As String = "SELECT * from qrySalesGrid WHERE SMLocation ='" + txtShopRef.Text + "'"
        Dim Reader As SqlDataReader
        Try
            connection.Open()
            Dim Comm As New SqlCommand(sql, connection)
            Reader = Comm.ExecuteReader
            Dim count As Integer
            count = 0
            While Reader.Read
                count = count + 1
            End While
            connection.Close()
            If count = 0 Then DataBlank()
            If count >= 1 Then getshopStock()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataBlank()
        getallstock()

    End Sub
    Private Sub getshopStock()

        '   DataGridView1.Columns.Clear()
        Dim sql As String = "Select SMStockCode,Qty,Delivered,Sold,SoldQty,SalesAmount from qrySalesGrid where SMLocation ='" + txtShopRef.Text + "'"
        Dim strSQL As String = "SELECT dbo.tblStockMovements.SMStockCode, SUM(dbo.tblStockMovements.MovementQtyHangers) AS Qty,dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, '' AS SoldQty, '' AS SalesAmount,                      dbo.tblStockMovements.SMLocation FROM dbo.qrySalesEntryQtyDelivered INNER JOIN dbo.tblStockMovements ON dbo.qrySalesEntryQtyDelivered.SMStockCode = dbo.tblStockMovements.SMStockCode AND dbo.qrySalesEntryQtyDelivered.SMLocation = dbo.tblStockMovements.SMLocation INNER JOIN                        dbo.tblStock ON dbo.tblStockMovements.SMStockCode = dbo.tblStock.StockCode INNER JOIN  dbo.qrySalesEntryQtySold ON dbo.tblStockMovements.SMStockCode = dbo.qrySalesEntryQtySold.SMStockCode AND dbo.tblStockMovements.SMLocation = dbo.qrySalesEntryQtySold.SMLocation WHERE tblStockMovements.SMLocation = '" + txtShopRef.Text.ToString() + "' GROUP BY dbo.tblStockMovements.SMStockCode, dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, dbo.tblStockMovements.SMLocation, dbo.tblStockMovements.SMLocationType HAVING (dbo.tblStockMovements.SMLocationType = N'Shop')"
        Dim cbodata As New SqlDataAdapter

        cbodata.SelectCommand = New SqlCommand(sql, connection)
        cbodata.Fill(dds)
        ' DataGridView1.Refresh()
        ComboBox1.DataSource = dds
        ComboBox1.DisplayMember = "SMStockCode"
        'txtCurrentQty.Text = dds.Rows(0)("Qty").ToString


        '  DataGridView1.DataSource = cbodata
        ' DataGridView1.Refresh()
        ' DataGridView1.Columns.Item(6).Visible = False
        DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
        DataGridView1.Columns.Item(5).HeaderText = "Sales Amount"
        DataGridView1.Columns.Item(1).Width = "60"
        DataGridView1.Columns.Item(4).HeaderText = "Units Sold"
        DataGridView1.Columns.Item(2).Width = "60"
        ' DataGridView1.Columns.Add("SalesAmt", "Sales Amount")


    End Sub

    Private Sub getallstock()
        Dim selectdata As String = "SELECT SMStockCode from qrySalesEntryQtyDelivered where SMLocation ='" + txtShopRef.Text + "'"
        Dim da As New SqlDataAdapter(selectdata, connectionString)
        Dim ds As New DataSet
        connection.Open()
        da.Fill(ds)
        connection.Close()
        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "SMStockCode"
    End Sub
    Private Sub UpdateRecords()
        Dim i As Integer
        i = Main.DataGridView1.CurrentRow.Index
        txtSalesID.Text = Main.DataGridView1.Item(0, i).Value
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "Delete From tblSalesLines where SalesID='" + txtSalesID.Text + "';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + txtSalesID.Text + "'"
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection.Open()
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        SaveStockMovements()
    End Sub
End Class