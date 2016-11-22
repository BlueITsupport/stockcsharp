Imports System.Data.SqlClient
Public Class ReportCritera
    Dim dLastSunday As Date = Date.Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Dim connectionString As String = "Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"

    Private Sub ReportCritera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = "1/1/2003"
        Try
            Using conn As New SqlConnection(connectionString)
                Dim da As New DataSet
                Dim adp As New SqlDataAdapter
                Dim sqlstring As String = "SELECT ShopName from tblShops"
                Dim selectcmd As New SqlCommand(sqlstring, conn)
                conn.Open()
                adp.SelectCommand = selectcmd
                adp.Fill(da)
                selectcmd.Dispose()
                adp.Dispose()
                Dim ACSC As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To da.Tables(0).Rows.Count - 1
                    ACSC.Add(da.Tables(0).Rows(i).Item(0).ToString)
                Next
                ComboBox1.DataSource = ACSC
            End Using
            Using conn As New SqlConnection(connectionString)
                Dim da As New DataSet
                Dim adp As New SqlDataAdapter
                Dim sqlstring As String = "SELECT ShopName from tblShops order by ShopName desc"
                Dim selectcmd As New SqlCommand(sqlstring, conn)
                conn.Open()
                adp.SelectCommand = selectcmd
                adp.Fill(da)
                selectcmd.Dispose()
                adp.Dispose()
                Dim ACSC As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To da.Tables(0).Rows.Count - 1
                    ACSC.Add(da.Tables(0).Rows(i).Item(0).ToString)
                Next
                ComboBox2.DataSource = ACSC
            End Using
            Using conn As New SqlConnection(connectionString)
                Dim da As New DataSet
                Dim adp As New SqlDataAdapter
                Dim sqlstring As String = "SELECT StockCode from tblStock"
                Dim selectcmd As New SqlCommand(sqlstring, conn)
                conn.Open()
                adp.SelectCommand = selectcmd
                adp.Fill(da)
                selectcmd.Dispose()
                adp.Dispose()
                Dim ACSC As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To da.Tables(0).Rows.Count - 1
                    ACSC.Add(da.Tables(0).Rows(i).Item(0).ToString)
                Next
                ComboBox3.DataSource = ACSC
            End Using
            Using conn As New SqlConnection(connectionString)
                Dim da As New DataSet
                Dim adp As New SqlDataAdapter
                Dim sqlstring As String = "SELECT StockCode from tblStock order by StockCode desc"
                Dim selectcmd As New SqlCommand(sqlstring, conn)
                conn.Open()
                adp.SelectCommand = selectcmd
                adp.Fill(da)
                selectcmd.Dispose()
                adp.Dispose()
                Dim ACSC As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To da.Tables(0).Rows.Count - 1
                    ACSC.Add(da.Tables(0).Rows(i).Item(0).ToString)
                Next
                ComboBox4.DataSource = ACSC
            End Using
        Catch ex As SqlException
            MessageBox.Show("Please check that the SQL Express server is running", ProductName)
        End Try

    End Sub
    Private Sub loadAllStockReport()

    End Sub
    Private Sub LoadStockDelReport()

    End Sub
    Private Sub LoadShopStock1Report()

    End Sub
    Private Sub LoadShopStock2Report()

    End Sub
    Private Sub LoadWHListReport()

    End Sub
    Private Sub LoadTotalValueReport()
        DateTimePicker1.Value = "1/1/2003"
        DateTimePicker2.Value = dLastSunday
        DateTimePicker1.Enabled = False
    End Sub
    Private Sub LoadSalesHistoryReport()

    End Sub
    Private Sub LoadSalesAReport()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'BuildShopStockReport()
        BuildTotalValueReport()
    End Sub
    Private Sub BuildShopStockReport()
        Dim dsunday As Date = DateTimePicker2.Value.AddDays(-(DateTimePicker2.Value.DayOfWeek + 7) + 7)
        Using wq As New SqlConnection(connectionString)
            Dim queryResult As Integer
            Dim sqlstring As String = "SELECT COUNT(*) as numRows From tblSalesThisWeek"
            Dim duplicateCommand As New SqlCommand(sqlstring, wq)
            duplicateCommand.Connection.Open()
            queryResult = duplicateCommand.ExecuteNonQuery()
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
        Using conn As New SqlConnection(connectionString)
            Dim sqlString As String = "INSERT INTO tblSalesThisWeek (ShopRef,StockCode,Qty,Date) SELECT        dbo.tblSales.ShopRef, dbo.tblSalesLines.StockCode, dbo.tblSalesLines.QtySold, dbo.tblSales.TransactionDate
FROM            dbo.tblSales INNER JOIN
                         dbo.tblSalesLines ON dbo.tblSales.SalesId = dbo.tblSalesLines.SalesID
GROUP BY dbo.tblSales.ShopRef, dbo.tblSalesLines.StockCode, dbo.tblSalesLines.QtySold, dbo.tblSales.TransactionDate
HAVING        (dbo.tblSales.TransactionDate = @Date2);"
            Dim sqlString1 As String = "INSERT INTO tblSalesThisWeek (ShopRef,StockCode,Qty,Date) SELECT tblSales.ShopRef,tblSalesLines.StockCode,SUM(tblSalesLines.QtySold) AS Qty,tblSales.TransactionDate FROM tblSales INNER JOIN tblSalesLines ON tblSales.SalesID = tblSalesLines.SalesID GROUP By tblSales.ShopRef,tblSalesLines.StockCode,tblSales.TransactionDate HAVING (((tblSales.TransactionDate) = CONVERT(DateTime, '" + DateTimePicker2.Value + "')));"
            Dim SCommand As New SqlCommand(sqlString1, conn)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
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
                        (MovementDate <= @Date2)
GROUP BY dbo.tblStockMovements.SMLocation, dbo.tblStockMovements.SMStockCode"
            Dim SCommand As New SqlCommand(sqlString, conn)
            SCommand.Parameters.AddWithValue("@Date1", DateTimePicker1.Value)
            SCommand.Parameters.AddWithValue("@Date2", DateTimePicker2.Value)
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
                         (dbo.tblStockMovements.MovementDate < @Date) OR
                         (dbo.tblStockMovements.MovementType = N'Delivery (S)') OR
                         (dbo.tblStockMovements.MovementType = N'Stock Gain') OR
                         (dbo.tblStockMovements.MovementType = N'Stock Loss') OR
                         (dbo.tblStockMovements.MovementType = N'Shop Transfer') OR (dbo.tblStockMovements.MovementType = N'Sale')
GROUP BY dbo.tblShops.ShopName, dbo.tblStockMovements.SMLocation, dbo.tblShops.ShopType, dbo.tblStockMovements.SMStockCode, dbo.tblStock.DeadCode"
            Dim SCommand As New SqlCommand(sqlString, conn2)
            SCommand.Connection.Open()
            SCommand.Parameters.AddWithValue("@Date", DateTimePicker2.Value)
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
        Button3.Enabled = False
        '  ReportStockList1.Show()
        ' ReportStocklist2.Show()
    End Sub
    Private Sub BuildTotalValueReport()
        Dim dsunday As Date = DateTimePicker2.Value.AddDays(-(DateTimePicker2.Value.DayOfWeek + 7) + 7)
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
        ReportTotalvalue.Show()
    End Sub
End Class