Imports System.Data.SqlClient
Public Class Criteria
    Dim dLastSunday As Date = Date.Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Dim connectionString As String = "Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim insert2Command As New SqlCommand
    Dim SelectCommand As New SqlCommand

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Label3.Text = "SalesAnalysis" Then SalesAnalysisReport()
        If Label3.Text = "ShopDeliveries" Then ShopdeliveriesReports()
        If Label3.Text = "SalesHistory" Then SalesHistoryReport()
        If Label3.Text = "WarehouseStock" Then WarehouseStockListReport()
        If Label3.Text = "ShopStock1" Then StockListByShopReport()
        If Label3.Text = "ShopStock2" Then StockListByStockCode()
        If Label3.Text = "AllStock" Then StockListByCodeReport()
        If Label3.Text = "TotalValue" Then CalculateTotalValue()
        If Label3.Text = "Borehamwood" Then Borehamwod()

    End Sub
    Private Sub Borehamwod()
        Borehamwood.Show()

    End Sub
    Private Sub StockListByStockCode()
        ReportStocklist2.Show()

    End Sub
    Private Sub SalesAnalysisReport()
        ReportSalesAnalysis.Show()
    End Sub
    Private Sub SalesHistoryReport()
        reportSalesHistory.Show()

    End Sub
    Private Sub StockValueReport()
        '  ReportSalesAnalysis.Show()
    End Sub
    Private Sub WarehouseStockListReport()
        ReportWarehouseStock.Show()

    End Sub
    Private Sub StockListByShopReport()
        ReportStockList1.Show()
    End Sub
    Private Sub StockListByCodeReport()
        ReportAllStock.Show()
    End Sub
    Private Sub ShopdeliveriesReports()
        ReportShopDeliveries.Show()
    End Sub

    Private Sub Criteria_Load(sender As Object, e As EventArgs) Handles Me.Load
        DateTimePicker1.Value = "1/1/2003"
        DateTimePicker2.Value = dLastSunday
        DateTimePicker1.Enabled = False
        Button3.Enabled = True
        Try
            Dim sqlds As New DataSet
            Dim adp As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm As New SqlCommand("SELECT ShopName From tblShops WHERE ShopRef <>'BO'", connection)
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
            ComboBox1.DataSource = ACSC
            ' txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            '   txtShopRef.AutoCompleteCustomSource = ACSC
            '  txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()

        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        Try
            Dim sqlds9 As New DataSet
            Dim adp9 As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm As New SqlCommand("SELECT ShopName From tblShops WHERE ShopRef <>'BO' order by ShopName desc", connection)
            comm.CommandType = CommandType.Text
            adp9.SelectCommand = comm
            adp9.Fill(sqlds9)
            comm.Dispose()
            adp9.Dispose()
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To sqlds9.Tables(0).Rows.Count - 1
                ACSC.Add(sqlds9.Tables(0).Rows(i).Item(0).ToString)
            Next
            ComboBox3.DataSource = ACSC
            ' txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            '   txtShopRef.AutoCompleteCustomSource = ACSC
            '  txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()

        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        Try
            Dim sqlds2 As New DataSet
            Dim adp2 As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm2 As New SqlCommand("SELECT StockCode From tblStock Where DeadCode = '0'", connection)
            comm2.CommandType = CommandType.Text
            adp2.SelectCommand = comm2
            adp2.Fill(sqlds2)
            comm2.Dispose()
            adp2.Dispose()
            Dim ACSC2 As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To sqlds2.Tables(0).Rows.Count - 1
                ACSC2.Add(sqlds2.Tables(0).Rows(i).Item(0).ToString)
            Next
            ComboBox2.DataSource = ACSC2
            ' txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            '   txtShopRef.AutoCompleteCustomSource = ACSC
            '  txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()

        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        Try
            Dim sqlds2 As New DataSet
            Dim adp2 As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm2 As New SqlCommand("SELECT StockCode From tblStock Where DeadCode = '0' Order By StockCode desc", connection)
            comm2.CommandType = CommandType.Text
            adp2.SelectCommand = comm2
            adp2.Fill(sqlds2)
            comm2.Dispose()
            adp2.Dispose()
            Dim ACSC2 As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To sqlds2.Tables(0).Rows.Count - 1
                ACSC2.Add(sqlds2.Tables(0).Rows(i).Item(0).ToString)
            Next
            ComboBox4.DataSource = ACSC2
            ' txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            '   txtShopRef.AutoCompleteCustomSource = ACSC
            '  txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()

        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        '  If Me.Label3.Text = "ShopStock1" Or Me.Label3.Text = "ShopStock2" Then Button3.Enabled = True
        '   If Me.Label3.Text <> "ShopStock1" Or Me.Label3.Text <> "ShopStock2" Then Button3.Enabled = False
        If Label3.Text = "SalesAnalysis" Then LoadSalesAnalysisReport()
        If Label3.Text = "ShopDeliveries" Then LoadShopdeliveriesReports()
        If Label3.Text = "SalesHistory" Then LoadSalesHistoryReport()
        If Label3.Text = "WarehouseStock" Then LoadWarehouseStockListReport()
        If Label3.Text = "ShopStock2" Then LoadStocklistreport()
        If Label3.Text = "ShopStock1" Then LoadStockListByShopReport()
        If Label3.Text = "AllStock" Then LoadStockListByCodeReport()
        If Label3.Text = "TotalValue" Then loadTotalValueReport()
        If Label3.Text = "Borehamwood" Then loadBorehamwood()

    End Sub
    Private Sub loadBorehamwood()
        Me.Text = "Borehamwood Stock Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
    End Sub
    Private Sub LoadTotalValueReport()
        Me.Text = "Total Value Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False

    End Sub
    Private Sub LoadStocklistreport()
        DateTimePicker1.Enabled = False
        Me.Text = "Stock List By Stock Code Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
    End Sub
    Private Sub LoadSalesAnalysisReport()
        Me.Text = "Sales Analysis Report"
        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
        DateTimePicker2.Value = dLastSunday.AddDays(7)
    End Sub
    Private Sub LoadShopDeliveriesReports()
        Me.Text = "Shop Deliveries Report"
        DateTimePicker1.Enabled = False
    End Sub
    Private Sub LoadSalesHistoryReport()
        Me.Text = "Sales History Report"
        DateTimePicker1.Enabled = False
    End Sub
    Private Sub LoadWarehouseStockListReport()
        Me.Text = "Warehouse Stock List Report"
        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
    End Sub
    Private Sub LoadStockListByShopReport()
        Me.Text = "Stock List By Shop"
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub
    Private Sub LoadStockListByCodeReport()
        Me.Text = "All Stock Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using dconn As New SqlConnection(connectionString)
            Dim InsertCommand As New SqlCommand
            InsertCommand.Connection = dconn
            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@StockCode", "All")
            InsertCommand.Parameters.AddWithValue("@SupplierRef", " ")
            InsertCommand.Parameters.AddWithValue("@Location", "All")
            InsertCommand.Parameters.AddWithValue("@Qty", "0")
            InsertCommand.Parameters.AddWithValue("@MovementType", "Reports")
            InsertCommand.Parameters.AddWithValue("@RecordType", "Report Gen")
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker2.Value)
            InsertCommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            InsertCommand.Parameters.AddWithValue("@Reference", "0000")
            InsertCommand.Parameters.AddWithValue("@CreatedBy", Main.TextBox1.Text)
            InsertCommand.ExecuteNonQuery()
        End Using
        Using wq As New SqlConnection(connectionString)
                Dim queryResult As Integer
                Dim sqlstring As String = "SELECT COUNT(*) as numRows From tblSalesThisWeek"
                Dim duplicateCommand As New SqlCommand(sqlstring, wq)
                duplicateCommand.Connection.Open()
                queryResult = DuplicateCommand.ExecuteNonQuery()
                If queryResult = -1 Then
                    Using we2 As New SqlConnection(connectionString)
                        Dim sqlstring2 As String = "DELETE from tblSalesThisWeek;"
                        Dim DeleteCommand As New SqlCommand(sqlstring2, we2)
                        DeleteCommand.Connection.Open()
                        DeleteCommand.ExecuteNonQuery()
                    End Using
                End If
            End Using
            Using wq3 As New SqlConnection(connectionString)
                Dim queryResult As Integer
                Dim sqlstring As String = "SELECT COUNT(*) as numRows From tblCurrentStock"
                Dim duplicateCommand As New SqlCommand(sqlstring, wq3)
                duplicateCommand.Connection.Open()
                queryResult = duplicateCommand.ExecuteNonQuery()
                If queryResult = -1 Then
                    Using we2 As New SqlConnection(connectionString)
                        Dim sqlstring2 As String = "DELETE from tblCurrentStock;"
                        Dim DeleteCommand As New SqlCommand(sqlstring2, we2)
                        DeleteCommand.Connection.Open()
                        DeleteCommand.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Using wq1 As New SqlConnection(connectionString)
            Dim queryResult1 As Integer
            Dim sqlstring1 As String = "SELECT COUNT(*) as numRows From tblShopStockReport"
            Dim duplicateCommand1 As New SqlCommand(sqlstring1, wq1)
            duplicateCommand1.Connection.Open()
            queryResult1 = duplicateCommand1.ExecuteNonQuery()
            If queryResult1 = -1 Then
                Using we21 As New SqlConnection(connectionString)
                    Dim sqlstring21 As String = "DELETE from tblShopStockReport;"
                    Dim DeleteCommand1 As New SqlCommand(sqlstring21, we21)
                    DeleteCommand1.Connection.Open()
                    DeleteCommand1.ExecuteNonQuery()
                End Using
            End If
        End Using

        Using wq1 As New SqlConnection(connectionString)
            Dim queryResult1 As Integer
            Dim sqlstring1 As String = "SELECT COUNT(*) as numRows From tblStockRepTotalDelivered"
            Dim duplicateCommand1 As New SqlCommand(sqlstring1, wq1)
            duplicateCommand1.Connection.Open()
            queryResult1 = duplicateCommand1.ExecuteNonQuery()
            If queryResult1 = -1 Then
                Using we21 As New SqlConnection(connectionString)
                    Dim sqlstring21 As String = "DELETE from tblStockRepTotalDelivered;"
                    Dim DeleteCommand1 As New SqlCommand(sqlstring21, we21)
                    DeleteCommand1.Connection.Open()
                    DeleteCommand1.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using wq1 As New SqlConnection(connectionString)
            Dim queryResult1 As Integer
            Dim sqlstring1 As String = "SELECT COUNT(*) as numRows From tblStockRepTotalGain"
            Dim duplicateCommand1 As New SqlCommand(sqlstring1, wq1)
            duplicateCommand1.Connection.Open()
            queryResult1 = duplicateCommand1.ExecuteNonQuery()
            If queryResult1 = -1 Then
                Using we21 As New SqlConnection(connectionString)
                    Dim sqlstring21 As String = "DELETE from tblStockRepTotalGain;"
                    Dim DeleteCommand1 As New SqlCommand(sqlstring21, we21)
                    DeleteCommand1.Connection.Open()
                    DeleteCommand1.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using wq1 As New SqlConnection(connectionString)
            Dim queryResult1 As Integer
            Dim sqlstring1 As String = "SELECT COUNT(*) as numRows From tblStockRepTotalLoss"
            Dim duplicateCommand1 As New SqlCommand(sqlstring1, wq1)
            duplicateCommand1.Connection.Open()
            queryResult1 = duplicateCommand1.ExecuteNonQuery()
            If queryResult1 = -1 Then
                Using we21 As New SqlConnection(connectionString)
                    Dim sqlstring21 As String = "DELETE from tblStockRepTotalLoss;"
                    Dim DeleteCommand1 As New SqlCommand(sqlstring21, we21)
                    DeleteCommand1.Connection.Open()
                    DeleteCommand1.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using wq1 As New SqlConnection(connectionString)
            Dim queryResult1 As Integer
            Dim sqlstring1 As String = "SELECT COUNT(*) as numRows From tblStockRepTotalSold"
            Dim duplicateCommand1 As New SqlCommand(sqlstring1, wq1)
            duplicateCommand1.Connection.Open()
            queryResult1 = duplicateCommand1.ExecuteNonQuery()
            If queryResult1 = -1 Then
                Using we21 As New SqlConnection(connectionString)
                    Dim sqlstring21 As String = "DELETE from tblStockRepTotalSold;"
                    Dim DeleteCommand1 As New SqlCommand(sqlstring21, we21)
                    DeleteCommand1.Connection.Open()
                    DeleteCommand1.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using wq1 As New SqlConnection(connectionString)
            Dim queryResult1 As Integer
            Dim sqlstring1 As String = "SELECT COUNT(*) as numRows From tblStockRepTotalTI"
            Dim duplicateCommand1 As New SqlCommand(sqlstring1, wq1)
            duplicateCommand1.Connection.Open()
            queryResult1 = duplicateCommand1.ExecuteNonQuery()
            If queryResult1 = -1 Then
                Using we21 As New SqlConnection(connectionString)
                    Dim sqlstring21 As String = "DELETE from tblStockRepTotalTI;"
                    Dim DeleteCommand1 As New SqlCommand(sqlstring21, we21)
                    DeleteCommand1.Connection.Open()
                    DeleteCommand1.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using wq1 As New SqlConnection(connectionString)
            Dim queryResult1 As Integer
            Dim sqlstring1 As String = "SELECT COUNT(*) as numRows From tblStockRepTotalTO"
            Dim duplicateCommand1 As New SqlCommand(sqlstring1, wq1)
            duplicateCommand1.Connection.Open()
            queryResult1 = duplicateCommand1.ExecuteNonQuery()
            If queryResult1 = -1 Then
                Using we21 As New SqlConnection(connectionString)
                    Dim sqlstring21 As String = "DELETE from tblStockRepTotalTO;"
                    Dim DeleteCommand1 As New SqlCommand(sqlstring21, we21)
                    DeleteCommand1.Connection.Open()
                    DeleteCommand1.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using a3 As New SqlConnection(connectionString)
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalDelivered (StockCode,Location,Qty) SELECT SMStockCode,SMLocation, SUM(MovementQtyHangers) AS Expr1
FROM   dbo.tblStockMovements WHERE  (MovementDate <= @Date2) GROUP BY SMStockCode,SMLocation, MovementType HAVING (MovementType = N'Delivery (S)') AND (SMLocation <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, a3)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Using a3 As New SqlConnection(connectionString)
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalGain (StockCode,Location,Qty) SELECT SMStockCode,SMLocation, SUM(MovementQtyHangers) AS Expr1
FROM   dbo.tblStockMovements WHERE  (MovementDate <= @Date2) GROUP BY SMStockCode,SMLocation, MovementType HAVING (MovementType = N'Stock Gain') AND (SMLocation <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, a3)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Using a3 As New SqlConnection(connectionString)
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalLoss (StockCode,Location,Qty) SELECT SMStockCode,SMLocation, SUM(MovementQtyHangers) AS Expr1
FROM   dbo.tblStockMovements WHERE  (MovementDate <= @Date2) GROUP BY SMStockCode,SMLocation, MovementType HAVING (MovementType = N'Stock Loss') AND (SMLocation <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, a3)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Using a3 As New SqlConnection(connectionString)
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalSold (StockCode,Location,Qty) SELECT SMStockCode,SMLocation, SUM(MovementQtyHangers * -1) AS Expr1
FROM   dbo.tblStockMovements WHERE  (MovementDate <= @Date2) GROUP BY SMStockCode,SMLocation, MovementType HAVING (MovementType = N'Sale') AND (SMLocation <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, a3)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Using a3 As New SqlConnection(connectionString)
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalTI (StockCode,Location,Qty) SELECT SMStockCode,SMLocation, SUM(MovementQtyHangers) AS Expr1
FROM   dbo.tblStockMovements WHERE  (MovementDate <= @Date2) GROUP BY SMStockCode,SMLocation, MovementType HAVING (MovementType = N'Shop Transfer') AND (SMLocation <> N'UNI') AND (SUM(MovementQtyHangers) > 0)"
            Dim SCommand As New SqlCommand(sqlstring, a3)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Using a3 As New SqlConnection(connectionString)
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalTO (StockCode,Location,Qty) SELECT SMStockCode,SMLocation, SUM(MovementQtyHangers) AS Expr1
FROM   dbo.tblStockMovements WHERE  (MovementDate <= @Date2) GROUP BY SMStockCode,SMLocation, MovementType HAVING (MovementType = N'Shop Transfer') AND (SMLocation <> N'UNI') AND (SUM(MovementQtyHangers) < 0)"

            Dim SCommand As New SqlCommand(sqlstring, a3)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Using a3 As New SqlConnection(connectionString)
            Dim sqlstring As String = "SELECT        SMLocation, SMStockCode, SUM(MovementQtyHangers) AS Expr1
FROM            dbo.tblStockMovements
WHERE        (MovementDate <= CONVERT(DATETIME, '2014-02-01 00:00:00', 102))
GROUP BY SMLocation, SMStockCode, MovementType
HAVING        (MovementType = N'Delivery (S)') AND (SMLocation <> N'UNI')"
        End Using
        Using conn As New SqlConnection(connectionString)
                Dim sqlString As String = "INSERT INTO tblSalesThisWeek (ShopRef,StockCode,Qty,Date) SELECT tblSales.ShopRef,tblSalesLines.StockCode,SUM(tblSalesLines.QtySold) AS Qty,tblSales.TransactionDate FROM tblSales INNER JOIN tblSalesLines ON tblSales.SalesID = tblSalesLines.SalesID GROUP By tblSales.ShopRef,tblSalesLines.StockCode,tblSales.TransactionDate HAVING (((tblSales.TransactionDate) = CONVERT(DateTime, '" + DateTimePicker2.Text + "')));"
                Dim SCommand As New SqlCommand(sqlString, conn)
                SCommand.Connection.Open()
                SCommand.ExecuteNonQuery()
            End Using
            Using conn As New SqlConnection(connectionString)
                Dim sqlString As String = "INSERT INTO tblCurrentStock (StockCode,Location,Qty) SELECT         dbo.tblStockMovements.SMStockCode,dbo.tblStockMovements.SMLocation, SUM(dbo.tblStockMovements.MovementQtyHangers) AS Qty
FROM            dbo.tblStockMovements INNER JOIN
                         dbo.tblStock ON dbo.tblStockMovements.SMStockCode = dbo.tblStock.StockCode
WHERE        (dbo.tblStockMovements.SMLocationType = 'Shop') AND (dbo.tblStockMovements.MovementType = 'Delivery (S)' OR
                         dbo.tblStockMovements.MovementType = 'Sale' OR
                         dbo.tblStockMovements.MovementType = 'Shop Transfer' OR
                         dbo.tblStockMovements.MovementType = 'Stock Gain' OR
                         dbo.tblStockMovements.MovementType = 'Stock Loss' OR
                         dbo.tblStockMovements.MovementType = 'Return') AND (dbo.tblStock.DeadCode = 0) AND (dbo.tblStockMovements.MovementDate > CONVERT(DATETIME, '2001-01-01 00:00:00', 102)) AND 
                         (dbo.tblStockMovements.MovementDate <= CONVERT(DATETIME, '" + DateTimePicker2.Text + "', 102))
GROUP BY dbo.tblStockMovements.SMLocation, dbo.tblStockMovements.SMStockCode"
                Dim SCommand As New SqlCommand(sqlString, conn)
                SCommand.Connection.Open()
                SCommand.ExecuteNonQuery()
            End Using
            Using conn2 As New SqlConnection(connectionString)
                Dim sqlString As String = "Insert INTo tblShopStockReport (ShopName,Location,Type,StockCode,DeadCode,TotalSold,CurrentQty,QtyDel,TranIn,TranOut,QtyUp,QtyDown)SELECT        dbo.tblShops.ShopName, dbo.tblStockMovements.SMLocation, dbo.tblShops.ShopType, dbo.tblStockMovements.SMStockCode, dbo.tblStock.DeadCode, 
                         ISNULL(SUM(dbo.ssrStockmovementsShopSales.MovementQtyHangers * - 1), 0) AS TotalSold, '0' AS CurrentQty, ISNULL(SUM(dbo.ssrStockMovementsShopDelivery.MovementQtyHangers), 0) 
                         AS QtyDel, ISNULL(SUM(dbo.ssrStockMovementsShopTransfer.TransferIn), 0) AS TranIn, ISNULL(SUM(dbo.ssrStockMovementsShopTransfer.TransferOut), 0) AS TranOut, 
                         ISNULL(SUM(dbo.ssrStockMovementsShopGain.MovementQtyHangers), 0) AS QtyUp, ISNULL(SUM(dbo.ssrStockMovementsShopLoss.MovementQtyHangers), 0) AS QtyDown
FROM            dbo.tblShops INNER JOIN
                         dbo.tblStockMovements ON dbo.tblShops.ShopRef = dbo.tblStockMovements.SMLocation LEFT OUTER JOIN
                         dbo.ssrStockMovementsShopTransfer ON dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopTransfer.StockMovementID LEFT OUTER JOIN
                         dbo.ssrStockMovementsShopLoss ON dbo.tblStockMovements.MovementQtyHangers = dbo.ssrStockMovementsShopLoss.MovementQtyHangers AND 
                         dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopLoss.StockMovementID LEFT OUTER JOIN
                         dbo.ssrStockMovementsShopDelivery ON dbo.tblStockMovements.MovementQtyHangers = dbo.ssrStockMovementsShopDelivery.MovementQtyHangers AND 
                         dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopDelivery.StockMovementID LEFT OUTER JOIN
                         dbo.ssrStockmovementsShopSales ON dbo.tblStockMovements.MovementQtyHangers = dbo.ssrStockmovementsShopSales.MovementQtyHangers AND 
                         dbo.tblStockMovements.StockMovementID = dbo.ssrStockmovementsShopSales.StockMovementID LEFT OUTER JOIN
                         dbo.ssrStockMovementsShopGain ON dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopGain.StockMovementID FULL OUTER JOIN
                         dbo.tblStock ON dbo.tblStockMovements.SMStockCode = dbo.tblStock.StockCode

WHERE        (dbo.tblStockMovements.MovementDate > CONVERT(DATETIME, '2002-01-01 00:00:00', 102)) AND 
                         (dbo.tblStockMovements.MovementDate < CONVERT(DATETIME, '" + DateTimePicker2.Text + "', 102)) OR
                         (dbo.tblStockMovements.MovementType = N'Delivery (S)') OR
                         (dbo.tblStockMovements.MovementType = N'Stock Gain') OR
                         (dbo.tblStockMovements.MovementType = N'Stock Loss') OR
                         (dbo.tblStockMovements.MovementType = N'Shop Transfer') OR (dbo.tblStockMovements.MovementType = N'Sale')
GROUP BY dbo.tblShops.ShopName, dbo.tblStockMovements.SMLocation, dbo.tblShops.ShopType, dbo.tblStockMovements.SMStockCode, dbo.tblStock.DeadCode"
                Dim SCommand As New SqlCommand(sqlString, conn2)
                SCommand.Connection.Open()
                SCommand.ExecuteNonQuery()
            End Using
            Using da93 As New SqlConnection(connectionString)
                Dim sqestring As String = "UPDATE tblShopStockReport SET SoldThisWeek = ISNULL(tblSalesThisWeek.Qty,0) FROM tblShopStockReport,tblSalesThisWeek WHERE(tblShopStockReport.StockCode = tblSalesThisWeek.StockCode) AND (tblShopStockReport.Location = tblSalesThisWeek.ShopRef)"
                Dim scommand As New SqlCommand(sqestring, da93)
                scommand.Connection.Open()
                scommand.ExecuteNonQuery()
                scommand.Connection.Close()

            End Using
            Using da93 As New SqlConnection(connectionString)
                Dim sqestring As String = "UPDATE tblShopStockReport SET CurrentQty = ISNULL(qryShopStock.Qty,0) FROM tblShopStockReport,qryShopStock WHERE(tblShopStockReport.StockCode = qryshopStock.SMStockCode) AND (tblShopStockReport.Location = qryShopStock.SMLocation)"
                Dim sqestring9 As String = "UPDATE tblShopStockReport SET CurrentQty = SUM(dbo.tblStockMovements.MovementQtyHangers) FROM tblShopStockReport,tblStockMovements WHERE(tblShopStockReport.StockCode = tblStockMovements.SMStockCode) AND (tblShopStockReport.Location = tblStockMovements.SMLocation)"
                Dim sqlstring As String = "UPDATE tblShopStockReport SET CurrentQty = tblCurrentStock.Qty FROM tblShopStockReport,tblCurrentStock WHERE (tblShopStockReport.StockCode = tblCurrentStock.StockCode) AND (tblShopStockReport.Location = tblCurrentStock.Location)"
                Dim scommand As New SqlCommand(sqlstring, da93)
                scommand.Connection.Open()
                scommand.ExecuteNonQuery()
                scommand.Connection.Close()

            End Using
        Using da93 As New SqlConnection(connectionString)
            Dim sqlstring As String = "UPDATE tblShopStockReport SET TotalSold = tblStockRepTotalSold.Qty FROM tblShopStockReport,tblStockRepTotalSold WHERE (tblShopStockReport.StockCode = tblStockRepTotalSold.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalSold.Location)"
            Dim scommand As New SqlCommand(sqlstring, da93)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
            scommand.Connection.Close()
        End Using
        Using da93 As New SqlConnection(connectionString)
            Dim sqlstring As String = "UPDATE tblShopStockReport SET QtyDel = tblStockRepTotalDelivered.Qty FROM tblShopStockReport,tblStockRepTotalDelivered WHERE (tblShopStockReport.StockCode = tblStockRepTotalDelivered.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalDelivered.Location)"
            Dim scommand As New SqlCommand(sqlstring, da93)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
            scommand.Connection.Close()
        End Using
        Using da93 As New SqlConnection(connectionString)
            Dim sqlstring As String = "UPDATE tblShopStockReport SET TranIn = tblStockRepTotalTI.Qty FROM tblShopStockReport,tblStockRepTotalTI WHERE (tblShopStockReport.StockCode = tblStockRepTotalTI.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalTI.Location)"
            Dim scommand As New SqlCommand(sqlstring, da93)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
            scommand.Connection.Close()
        End Using
        Using da93 As New SqlConnection(connectionString)
            Dim sqlstring As String = "UPDATE tblShopStockReport SET TranOut = tblStockRepTotalTO.Qty FROM tblShopStockReport,tblStockRepTotalTO WHERE (tblShopStockReport.StockCode = tblStockRepTotalTO.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalTO.Location)"
            Dim scommand As New SqlCommand(sqlstring, da93)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
            scommand.Connection.Close()
        End Using
        Using da93 As New SqlConnection(connectionString)
            Dim sqlstring As String = "UPDATE tblShopStockReport SET QtyUp = tblStockRepTotalGain.Qty FROM tblShopStockReport,tblStockRepTotalGain WHERE (tblShopStockReport.StockCode = tblStockRepTotalGain.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalGain.Location)"
            Dim scommand As New SqlCommand(sqlstring, da93)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
            scommand.Connection.Close()
        End Using
        Using da93 As New SqlConnection(connectionString)
            Dim sqlstring As String = "UPDATE tblShopStockReport SET QtyDown = tblStockRepTotalLoss.Qty FROM tblShopStockReport,tblStockRepTotalLoss WHERE (tblShopStockReport.StockCode = tblStockRepTotalLoss.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalLoss.Location)"
            Dim scommand As New SqlCommand(sqlstring, da93)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
            scommand.Connection.Close()
        End Using
        Using wq As New SqlConnection(connectionString)
            Dim queryResult As Integer
            Dim sqlstring As String = "SELECT COUNT(*) as numRows From tblStockMovementsDate"
            Dim duplicateCommand As New SqlCommand(sqlstring, wq)
            duplicateCommand.Connection.Open()
            queryResult = duplicateCommand.ExecuteNonQuery()
            If queryResult = -1 Then
                Using we2 As New SqlConnection(connectionString)
                    Dim sqlstring2 As String = "DELETE from tblStockMovementsDate;"
                    Dim DeleteCommand As New SqlCommand(sqlstring2, we2)
                    DeleteCommand.Connection.Open()
                    DeleteCommand.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using conn2 As New SqlConnection(connectionString)
            Dim sqlString As String = "Insert INTo tblStockMovementsDate(StockCode,SupplierRef,Location,LocationType,MovementType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,CreatedBy,CreatedDate) SELECT dbo.tblStockMovements.SMStockCode,dbo.tblStockMovements.SMSupplierRef,dbo.tblStockMovements.SMLocation,dbo.tblStockMovements.SMLocationType,dbo.tblStockMovements.MovementType,dbo.tblStockMovements.MovementQtyHangers,dbo.tblStockMovements.MovementQtyBoxes,dbo.tblStockMovements.MovementDate,dbo.tblStockMovements.MovementValue,dbo.tblStockMovements.Reference,dbo.tblStockMovements.TransferReference,dbo.tblStockMovements.SMCreatedBy,dbo.tblStockMovements.SMCreatedDate FROM dbo.tblStockMovements 
WHERE (dbo.tblStockMovements.MovementDate > @Date1) AND (dbo.tblStockMovements.MovementDate <= @Date2) GROUP BY dbo.tblStockMovements.SMStockCode,dbo.tblStockMovements.SMSupplierRef,dbo.tblStockMovements.SMLocation,dbo.tblStockMovements.SMLocationType,dbo.tblStockMovements.MovementType,dbo.tblStockMovements.MovementQtyHangers,dbo.tblStockMovements.MovementQtyBoxes,dbo.tblStockMovements.MovementDate,dbo.tblStockMovements.MovementValue,dbo.tblStockMovements.Reference,dbo.tblStockMovements.TransferReference,dbo.tblStockMovements.SMCreatedBy,dbo.tblStockMovements.SMCreatedDate;"
            Dim SCommand As New SqlCommand(sqlString, conn2)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Button3.Enabled = False
    End Sub

    Private Sub DateTimePicker2_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.TextChanged
        Button3.Enabled = True
    End Sub
    Private Sub CalculateTotalValue()
        Using wq As New SqlConnection(connectionString)
            Dim queryResult As Integer
            Dim sqlstring As String = "SELECT COUNT(*) as numRows From tblStockMovementsDate"
            Dim duplicateCommand As New SqlCommand(sqlstring, wq)
            duplicateCommand.Connection.Open()
            queryResult = duplicateCommand.ExecuteNonQuery()
            If queryResult = -1 Then
                Using we2 As New SqlConnection(connectionString)
                    Dim sqlstring2 As String = "DELETE from tblStockMovementsDate;"
                    Dim DeleteCommand As New SqlCommand(sqlstring2, we2)
                    DeleteCommand.Connection.Open()
                    DeleteCommand.ExecuteNonQuery()
                End Using
            End If
        End Using
        Using conn2 As New SqlConnection(connectionString)
            Dim sqlString As String = "Insert INTo tblStockMovementsDate(StockCode,SupplierRef,Location,LocationType,MovementType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,CreatedBy,CreatedDate) SELECT dbo.tblStockMovements.SMStockCode,dbo.tblStockMovements.SMSupplierRef,dbo.tblStockMovements.SMLocation,dbo.tblStockMovements.SMLocationType,dbo.tblStockMovements.MovementType,dbo.tblStockMovements.MovementQtyHangers,dbo.tblStockMovements.MovementQtyBoxes,dbo.tblStockMovements.MovementDate,dbo.tblStockMovements.MovementValue,dbo.tblStockMovements.Reference,dbo.tblStockMovements.TransferReference,dbo.tblStockMovements.SMCreatedBy,dbo.tblStockMovements.SMCreatedDate FROM dbo.tblStockMovements 
WHERE (dbo.tblStockMovements.MovementDate > @Date1) AND (dbo.tblStockMovements.MovementDate <= @Date2) GROUP BY dbo.tblStockMovements.SMStockCode,dbo.tblStockMovements.SMSupplierRef,dbo.tblStockMovements.SMLocation,dbo.tblStockMovements.SMLocationType,dbo.tblStockMovements.MovementType,dbo.tblStockMovements.MovementQtyHangers,dbo.tblStockMovements.MovementQtyBoxes,dbo.tblStockMovements.MovementDate,dbo.tblStockMovements.MovementValue,dbo.tblStockMovements.Reference,dbo.tblStockMovements.TransferReference,dbo.tblStockMovements.SMCreatedBy,dbo.tblStockMovements.SMCreatedDate;"
            Dim SCommand As New SqlCommand(sqlstring, conn2)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        Button3.Enabled = False
        ReportTotalvalue.Show()
    End Sub
End Class