Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Main
    Dim connectionString As String = "Initial Catalog=DMHStockv4;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim cmd As SqlCommand
    Dim duplicatecommand As SqlCommand
    Dim deletecommand As SqlCommand
    ''' <summary>
    ''' structire to hold printed page details
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    ''' <summary>
    ''' dictionary to hold printed page details, with index key
    ''' </summary>
    ''' <remarks></remarks>
    Private pages As Dictionary(Of Integer, pageDetails)

    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer

    ''' <summary>
    ''' this just loads some text values into the dgv
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtMode.Visible = False
        txtOption.Visible = False
        ToolStripTextBox1.Visible = False
        PrintToolStripButton.Visible = False
        ' FindInput.Visible = False
        TextBox1.Visible = False
        TextBox1.Text = "Test"

        FindInput.Enabled = True
        DataGridView1.EnableHeadersVisualStyles = True
        ' ReturnsToolStripMenuItem.Visible = False
    End Sub
    Private Sub LoadStock()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        PrintToolStripButton.Visible = True
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        ' ShowAllStockToolStripMenuItem.Visible = True
        Try

            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryStockvaluespc1 Where DeadCode=0 order by StockCode", connection)
            gridDataAdapter.Fill(data, "qryStockvaluespc1")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryStockvaluespc1"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EditMode = DataGridViewEditMode.EditOnF2
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Text = "DMH Stock Master v2 [Stock]"
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.LightCoral
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            '   DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockCode
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(0).Width = 120
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = 80
            'Dead Code
            DataGridView1.Columns.Item(2).Visible = False
            DataGridView1.Columns.Item(2).HeaderText = "Dead Code"
            DataGridView1.Columns.Item(2).Width = 80
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Amount Taken"
            DataGridView1.Columns.Item(4).Width = 80
            DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            '  DataGridView1.Columns.Item(4).Visible = False
            ' DataGridView1.Columns.Item(4).Width = "10"
            'CostValue
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Cost Value"
            DataGridView1.Columns.Item(3).Width = 80
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DataGridView1.Columns.Item(5).HeaderText = "Markup"
            DataGridView1.Columns.Item(5).Width = 80
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "p"
            'ZeroQty
            DataGridView1.Columns.Item(6).Visible = False
            DataGridView1.Columns.Item(6).Width = 0
            'Stock.CreatedDate
            ToolStripStatusLabel1.Text = "Stock"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub LoadStock2()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Try
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryStockvaluespc1", connection)
            gridDataAdapter.Fill(data, "qryStockvaluespc1")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryStockvaluespc1"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EditMode = DataGridViewEditMode.EditOnF2
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Text = "DMH Stock Master v2 [Stock]"
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.LightCoral
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            '   DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockCode
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(0).Width = 120
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = 80
            'Dead Code
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Dead Code"
            DataGridView1.Columns.Item(2).Width = 80
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Amount Taken"
            DataGridView1.Columns.Item(4).Width = 80
            DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            '  DataGridView1.Columns.Item(4).Visible = False
            ' DataGridView1.Columns.Item(4).Width = "10"
            'CostValue
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Cost Value"
            DataGridView1.Columns.Item(3).Width = 80
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DataGridView1.Columns.Item(5).HeaderText = "Markup"
            DataGridView1.Columns.Item(5).Width = 80
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "p"
            'ZeroQty
            DataGridView1.Columns.Item(6).Visible = False
            '   DataGridView1.Columns.Item(7).HeaderText = "Zero Qty"
            '  DataGridView1.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            '  DataGridView1.Columns.Item(8).HeaderText = "Created By"
            DataGridView1.Columns.Item(6).Width = 0
            'Stock.CreatedDate
            '   DataGridView1.Columns.Item(9).HeaderText = "Created At"
            '   DataGridView1.Columns.Item(9).Width = "12"
            '   DataGridView1.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            ToolStripStatusLabel1.Text = "Stock"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub LoadShop()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        PrintToolStripButton.Visible = True
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Shops]"
        txtOption.Text = "Shops"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShops", connection)
            gridDataAdapter.Fill(data, "tblShops")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblShops"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            'ShopRef
            DataGridView1.Columns.Item(0).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(0).Width = 82
            'ShopName
            DataGridView1.Columns.Item(1).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(1).Width = 182
            'Shop.Address1
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Address"
            DataGridView1.Columns.Item(2).Width = 50
            'Shop.Address2
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).Width = 0
            'Shop.Address3
            DataGridView1.Columns.Item(4).Visible = False
            DataGridView1.Columns.Item(4).Width = 0
            'Shop.Address4
            DataGridView1.Columns.Item(5).Visible = False
            DataGridView1.Columns.Item(5).Width = 0
            'Shop.PostCode
            DataGridView1.Columns.Item(6).Visible = False
            DataGridView1.Columns.Item(6).Width = 0
            'Shop.ContactName
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(7).Width = 0
            'Shop.Telephone
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Telephone"
            DataGridView1.Columns.Item(9).Width = 50
            'Shop.Telephone2
            DataGridView1.Columns.Item(9).Visible = True
            DataGridView1.Columns.Item(8).Width = 0
            'Shop.Fax
            DataGridView1.Columns.Item(10).Visible = False
            DataGridView1.Columns.Item(10).Width = 0
            'Shop.eMail
            DataGridView1.Columns.Item(11).Visible = False
            DataGridView1.Columns.Item(11).Width = 0
            'Shop.ShopType
            DataGridView1.Columns.Item(13).HeaderText = "Type"
            DataGridView1.Columns.Item(12).Visible = False
            DataGridView1.Columns.Item(12).Width = 0
            DataGridView1.Columns.Item(14).Visible = False
            'Shop.CreatedBy
            DataGridView1.Columns.Item(15).HeaderText = "Created By"
            DataGridView1.Columns.Item(15).Visible = False
            DataGridView1.Columns.Item(14).Width = 0
            'Shop.CreatedDate
            '  DataGridView1.Columns.Item(16).HeaderText = "Created At"
            DataGridView1.Columns.Item(15).Width = 0
            ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub LoadSuppliers()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = True
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True

        '  Me.Text = "Suppliers"
        Me.Text = "DMH Stock Master v2 [Suppliers]"
        txtOption.Text = "Suppliers"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSuppliers", connection)
            gridDataAdapter.Fill(data, "tblSuppliers")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblSuppliers"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'SupplierRef
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(0).Width = "182"
            'SupplierName
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Name"
            DataGridView1.Columns.Item(1).Width = "182"
            'Supplier.Address1
            DataGridView1.Columns.Item(2).HeaderText = "Address"
            DataGridView1.Columns.Item(2).Width = "182"
            'Supplier.Address2
            DataGridView1.Columns.Item(3).Visible = False
            'Supplier.Address3
            DataGridView1.Columns.Item(4).Visible = False
            'Supplier.Address4
            DataGridView1.Columns.Item(5).Visible = False
            'Supplier.PostCode
            DataGridView1.Columns.Item(6).Visible = False
            'Supplier.ContactName
            DataGridView1.Columns.Item(7).HeaderText = "Contact Name"
            DataGridView1.Columns.Item(7).Width = "182"
            'Supplier.Telephone
            DataGridView1.Columns.Item(8).HeaderText = "Telephone"
            DataGridView1.Columns.Item(8).Width = "182"
            'Supplier.Telephone2
            DataGridView1.Columns.Item(9).Visible = False
            'Supplier.Fax
            DataGridView1.Columns.Item(10).Visible = False
            'Supplier.eMail
            DataGridView1.Columns.Item(11).Visible = False
            'Supplier.memo
            DataGridView1.Columns.Item(12).Visible = False
            'Supplier.CreatedBy
            DataGridView1.Columns.Item(13).HeaderText = "Created By"
            DataGridView1.Columns.Item(13).Visible = False
            'Supplier.CreatedDate
            DataGridView1.Columns.Item(14).HeaderText = "Created At"
            DataGridView1.Columns.Item(14).Width = 130
            DataGridView1.Columns.Item(14).Visible = False
            connection.Close()
            ToolStripStatusLabel1.Text = "Suppliers"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub LoadShopTrans()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        'Me.Text = "Shop Transfers"
        Me.Text = "DMH Stock Master v2 [Shop Transfers]"
        txtOption.Text = "Shop Transfers"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShopTransfers order by TransferDate desc", connection)
            gridDataAdapter.Fill(data, "tblShopTransfers")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblShopTransfers"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'TransferID
            DataGridView1.Columns.Item(0).Visible = False
            'Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "TF Note"
            DataGridView1.Columns.Item(1).Width = 80
            'From Shop
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Date"
            DataGridView1.Columns.Item(2).Width = 80
            'To Shop
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "From Shop Ref"
            DataGridView1.Columns.Item(3).Width = 80
            'From Quantity
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "From Shop Name"
            DataGridView1.Columns.Item(4).Width = 120
            'Movement Date
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "To Shop Ref"
            DataGridView1.Columns.Item(5).Width = 80
            'Transfer Reference
            'DataGridView1.Columns.Item(6).Visible = False
            DataGridView1.Columns.Item(6).HeaderText = "To Shop Name"
            DataGridView1.Columns.Item(6).Width = 120
            'From Shop Ref
            'DataGridView1.Columns.Item(6).Visible = False
            ' DataGridView1.Columns.Item(6).HeaderText = "From Shop Ref"
            ' DataGridView1.Columns.Item(6).Width = "182"
            'ToShopRef
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Quantity"
            DataGridView1.Columns.Item(7).Width = 50
            'TotalQtyIn
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "To Quantity"
            DataGridView1.Columns.Item(8).Width = "182"
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(10).Visible = False

            connection.Close()
            ToolStripStatusLabel1.Text = "Shop Transfers"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try

    End Sub
    Private Sub LoadPurchaseOrders()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = True
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        '  Me.Text = "Purchase Order"
        Me.Text = "DMH Stock Master v2 [Purchase Order - To Main Warehouse]"
        txtOption.Text = "Purchase Order"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * FROM tblDeliveries Order by DeliveriesID Desc", connection)
            gridDataAdapter.Fill(data, "tblDeliveries")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblDeliveries"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.LightBlue

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            ' DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            ' DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            ' Dim column As DataGridViewColumn = DataGridView1.Columns(0)
            ' column.Width = 70

            ' DataGridView1.AutoResizeColumns()
            '  DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            ' Delivery ID
            DataGridView1.Columns(0).HeaderText = "Delivery ID"
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "000000"
            DataGridView1.Columns(0).Visible = True
            ' Our Ref
            DataGridView1.Columns(1).HeaderText = "Our Ref"
            DataGridView1.Columns(1).Width = 120
            DataGridView1.Columns(1).Visible = True
            ' Supplier Ref
            DataGridView1.Columns(2).HeaderText = "Supplier Ref"
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(2).Visible = False
            ' Supplier Name
            DataGridView1.Columns(3).HeaderText = "Supplier Name"
            DataGridView1.Columns(3).Width = 160
            DataGridView1.Columns(3).Visible = True
            ' Location Ref
            DataGridView1.Columns(4).HeaderText = "Location Ref"
            DataGridView1.Columns(4).Width = 150
            DataGridView1.Columns(4).Visible = False
            ' Location Name
            DataGridView1.Columns(5).HeaderText = "Location Name"
            DataGridView1.Columns(5).Width = 160
            DataGridView1.Columns(5).Visible = True
            ' Stock Code
            DataGridView1.Columns(6).HeaderText = "Stock Code"
            DataGridView1.Columns(6).Width = "50"
            DataGridView1.Columns(6).Visible = False
            ' DQty Garments
            DataGridView1.Columns(7).HeaderText = "Garments"
            DataGridView1.Columns(7).Width = 70
            DataGridView1.Columns(7).Visible = True
            ' DQty Boxes
            DataGridView1.Columns(8).HeaderText = "Boxes"
            DataGridView1.Columns(8).Width = 70
            DataGridView1.Columns(8).Visible = False
            ' DQty Hangers
            DataGridView1.Columns(9).HeaderText = "Hangers"
            DataGridView1.Columns(9).Width = "50"
            DataGridView1.Columns(9).Visible = False
            ' Total Garments
            DataGridView1.Columns(10).HeaderText = "Total Garments"
            DataGridView1.Columns(10).Width = "50"
            DataGridView1.Columns(10).Visible = False
            ' Total Boxes
            DataGridView1.Columns(11).HeaderText = "Total Boxes"
            DataGridView1.Columns(11).Width = "50"
            DataGridView1.Columns(11).Visible = False
            ' Total Hangers
            DataGridView1.Columns(12).HeaderText = "Total Hangers"
            DataGridView1.Columns(12).Width = "50"
            DataGridView1.Columns(12).Visible = False
            ' Net Amount
            DataGridView1.Columns(13).HeaderText = "Net Amount"
            DataGridView1.Columns.Item(13).DefaultCellStyle.Format = "c"
            DataGridView1.Columns(13).Width = 70
            DataGridView1.Columns(13).Visible = True
            ' Delivery Charge
            DataGridView1.Columns(14).HeaderText = "Del. Charge"
            DataGridView1.Columns(14).Width = "50"
            DataGridView1.Columns(14).Visible = False
            ' Commission
            DataGridView1.Columns(15).HeaderText = "Commission"
            DataGridView1.Columns(15).Width = "50"
            DataGridView1.Columns(15).Visible = False
            ' Total Amount
            DataGridView1.Columns(16).HeaderText = "Total Amount"
            DataGridView1.Columns(16).Width = "50"
            DataGridView1.Columns(16).Visible = False
            ' Delivery Date
            DataGridView1.Columns(17).HeaderText = "Delivery Date"
            DataGridView1.Columns(17).Width = 90
            DataGridView1.Columns(17).Visible = True
            ' Delivery Type
            DataGridView1.Columns(18).HeaderText = "Delivery Type"
            DataGridView1.Columns(18).Width = "50"
            DataGridView1.Columns(18).Visible = False
            ' Confirmed Date
            DataGridView1.Columns(19).HeaderText = "Confirmed Date"
            DataGridView1.Columns(19).Width = "50"
            DataGridView1.Columns(19).Visible = False
            ' Notes
            DataGridView1.Columns(20).HeaderText = "Notes"
            DataGridView1.Columns(20).Width = "50"
            DataGridView1.Columns(20).Visible = False
            ' InvoiceNo
            DataGridView1.Columns(21).HeaderText = "Invoice"
            DataGridView1.Columns(21).Width = "50"
            DataGridView1.Columns(21).Visible = False
            ' Shipper
            DataGridView1.Columns(22).HeaderText = "Shipper"
            DataGridView1.Columns(22).Width = "50"
            DataGridView1.Columns(22).Visible = False
            ' ShipperInvoice
            DataGridView1.Columns(23).HeaderText = "Shipper Invoice"
            DataGridView1.Columns(23).Width = "50"
            DataGridView1.Columns(23).Visible = False
            ' Created By
            DataGridView1.Columns(24).HeaderText = "Created By"
            DataGridView1.Columns(24).Width = 80
            DataGridView1.Columns(24).Visible = False
            ' Created Date
            DataGridView1.Columns(25).HeaderText = "Created Date"
            DataGridView1.Columns(25).Width = 100
            DataGridView1.Columns(25).Visible = False
            connection.Close()
            ToolStripStatusLabel1.Text = "Purchase Orders"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try

    End Sub
    Private Sub LoadWarehouseAdjustment()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Warehouse Adjustments]"
        txtOption.Text = "Warehouse Adjustments"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryWarehouseAdjustments order by MovementDate desc", connection)
            gridDataAdapter.Fill(data, "qryWarehouseAdjustments")
            connection.Open()
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryWarehouseAdjustments"
            DataGridView1.AutoGenerateColumns = True
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockmovementID
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(0).HeaderText = "Stocmovement ID"
            DataGridView1.Columns.Item(0).Width = "182"
            'Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Reference"
            DataGridView1.Columns.Item(1).Width = 80
            'Location
            DataGridView1.Columns.Item(2).Visible = False
            DataGridView1.Columns.Item(2).HeaderText = "Date"
            DataGridView1.Columns.Item(2).Width = "182"
            'WarehouseName
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Warehouse Name"
            DataGridView1.Columns.Item(3).Width = 150
            'StockCode
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(4).Width = 80
            'Type
            DataGridView1.Columns.Item(5).Visible = False
            DataGridView1.Columns.Item(5).HeaderText = "Type"
            DataGridView1.Columns.Item(5).Width = 80
            'Qty
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Qty"
            DataGridView1.Columns.Item(6).Width = 50
            ' MovementDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Date"
            DataGridView1.Columns.Item(7).Width = 80
            connection.Close()
            ToolStripStatusLabel1.Text = "Warehouse Adjustments"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try

    End Sub
    Private Sub LoadShopDel()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = True
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True

        Me.Text = "DMH Stock Master v2 [Shop Deliveries]"
        txtOption.Text = "Shop deliveries"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShopDeliveries Order by DeliveryDate desc", connection)
            gridDataAdapter.Fill(data, "tblShopDeliveries")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblShopDeliveries"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'DeliveryID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Record No"
            DataGridView1.Columns.Item(0).Width = 80
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "000000"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = False
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = 80
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop"
            DataGridView1.Columns.Item(2).Width = 140
            'WarehouseRef
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Warehouse Ref"
            DataGridView1.Columns.Item(3).Width = 80
            'WarehouseName
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Warehouse"
            DataGridView1.Columns.Item(4).Width = 140
            'Reference
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Delivery No."
            DataGridView1.Columns.Item(5).Width = 80
            'TotalHangers
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Quantity"
            DataGridView1.Columns.Item(6).Width = 80
            'DeliveryDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Delivery Date"
            DataGridView1.Columns.Item(7).Width = 100
            'DeliveryType
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "Created By"
            DataGridView1.Columns.Item(8).Width = "182"
            'ConfirmedDate
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Created Date"
            DataGridView1.Columns.Item(9).Width = "182"
            'Notes
            DataGridView1.Columns.Item(10).Visible = False
            'DataGridView1.Columns.Item(10).HeaderText = "Notes"
            'DataGridView1.Columns.Item(10).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(11).Visible = False
            ' DataGridView1.Columns.Item(11).HeaderText = "Created By"
            ' DataGridView1.Columns.Item(11).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(12).Visible = False
            'DataGridView1.Columns.Item(12).HeaderText = "Created At"
            'DataGridView1.Columns.Item(12).Width = "182"
            connection.Close()
            ToolStripStatusLabel1.Text = "Shop Deliveries"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub LoadSales()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = True
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Sales]"
        txtOption.Text = "Sales"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSales order by TransactionDate desc", connection)
            gridDataAdapter.Fill(data, "tblSales")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblSales"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '   DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "000000"
            DataGridView1.Columns.Item(0).Width = 50
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = 50
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = 140
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Ref"
            DataGridView1.Columns.Item(3).Width = 10
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "d"
            DataGridView1.Columns.Item(4).Width = 100
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = 80
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = 80
            DataGridView1.Columns.Item(6).DefaultCellStyle.Format = "c"
            'CreatedBy
            DataGridView1.Columns.Item(7).Visible = False
            'DataGridView1.Columns.Item(7).HeaderText = "From ID"
            DataGridView1.Columns.Item(7).Width = 0
            'CreatedDate
            DataGridView1.Columns.Item(8).Visible = False
            ' DataGridView1.Columns.Item(8).HeaderText = "To ID"
            DataGridView1.Columns.Item(8).Width = 0
            connection.Close()
            ToolStripStatusLabel1.Text = "Sales"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub LoadShopAdjustment()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Shop Adjustments]"
        txtOption.Text = "Shop Adjustments"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShopAdjustments order by MovementDate desc", connection)
            gridDataAdapter.Fill(data, "qryShopAdjustments")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryShopAdjustments"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'StockmovementID
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(0).HeaderText = "Stocmovement ID"
            '   DataGridView1.Columns.Item(0).Width = "182"
            'Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Reference"
            DataGridView1.Columns.Item(1).Width = 200
            'Location
            DataGridView1.Columns.Item(2).Visible = False
            '  DataGridView1.Columns.Item(2).HeaderText = "Date"
            '   DataGridView1.Columns.Item(2).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(3).Visible = False
            '  DataGridView1.Columns.Item(3).HeaderText = "Shop Name"
            '   DataGridView1.Columns.Item(3).Width = "182"
            'StockCode
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Stock Code"
            '  DataGridView1.Columns.Item(4).Width = "182"
            'Type
            DataGridView1.Columns.Item(5).Visible = True
            '  DataGridView1.Columns.Item(5).HeaderText = "Type"
            '  DataGridView1.Columns.Item(5).Width = "182"
            'Qty
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Qty"
            DataGridView1.Columns.Item(6).Width = 50
            ' MovementDate
            ' DataGridView1.Columns.Item(7).Visible = True
            'DataGridView1.Columns.Item(7).HeaderText = "Date"
            'DataGridView1.Columns.Item(7).Width = "182"
            ToolStripStatusLabel1.Text = "Shop Adjustments"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try

    End Sub
    Private Sub LoadReturns()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = False
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Returns]"
        txtOption.Text = "Returns"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryReturns order by MovementDate Desc", connection)
            gridDataAdapter.Fill(data, "qryReturns")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryReturns"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'Reference
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Our Reference"
            DataGridView1.Columns.Item(0).Width = 182
            'FromShop
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "From Shop"
            DataGridView1.Columns.Item(1).Width = 182
            'ToWarehouse
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "To Warehouse"
            DataGridView1.Columns.Item(2).Width = 182
            'SMStockCode
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(3).Width = 182
            'MovementDate
            DataGridView1.Columns.Item(4).Visible = False
            DataGridView1.Columns.Item(7).HeaderText = "Movement Date"
            DataGridView1.Columns.Item(4).Width = 182
            'TransferReference
            DataGridView1.Columns.Item(5).Visible = False
            DataGridView1.Columns.Item(5).HeaderText = "Returns Reference"
            DataGridView1.Columns.Item(5).Width = 182
            'FromID
            DataGridView1.Columns.Item(6).Visible = False
            '  DataGridView1.Columns.Item(6).HeaderText = "Reference"
            DataGridView1.Columns.Item(6).Width = 182
            'ToID
            DataGridView1.Columns.Item(8).Visible = False
            'DataGridView1.Columns.Item(7).HeaderText = "Reference"
            DataGridView1.Columns.Item(7).Width = 182
            'SMCreatedDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Qty"
            DataGridView1.Columns.Item(8).Width = 182
            'MovementQtyHangers
            '  DataGridView1.Columns.Item(9).Visible = True
            '    DataGridView1.Columns.Item(9).HeaderText = "Qty"
            '   DataGridView1.Columns.Item(9).Width = 182
            'SMLocation
            '  DataGridView1.Columns.Item(10).Visible = False
            '   DataGridView1.Columns.Item(10).HeaderText = "Reference"
            '  DataGridView1.Columns.Item(10).Width = 182


            connection.Close()
            ToolStripStatusLabel1.Text = "Returns"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)


        End Try
    End Sub

    Private Sub RecordToolStripButton_Click(sender As Object, e As EventArgs) Handles RecordToolStripButton.Click
        txtMode.Text = "OLD"
        If txtOption.Text = "Shops" Then ShopsEntry.Show()
        If txtOption.Text = "Suppliers" Then SuppliersEntry.Show()
        If txtOption.Text = "Shop Transfers" Then ShopTransfers.Show()
        If txtOption.Text = "Purchase Order" Then DeliveriesIn.Show()
        If txtOption.Text = "Stock" Then Stock.Show()
        If txtOption.Text = "Shop deliveries" Then ShopDeliveries.Show()
        If txtOption.Text = "Sales" Then updatedSales.Show()
        If txtOption.Text = "Warehouse Adjustments" Or txtOption.Text = "Shop Adjustments" Then Adjustments.Show()


    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        txtMode.Text = "NEW"
        If txtOption.Text = "Shops" Then ShopsEntry.Show()
        If txtOption.Text = "Suppliers" Then SuppliersEntry.Show()
        If txtOption.Text = "Shop Transfers" Then ShopTransfers.Show()
        If txtOption.Text = "Purchase Order" Then DeliveriesIn.Show()
        If txtOption.Text = "Stock" Then Stock.Show()
        If txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustments.Show()
        If txtOption.Text = "Shop deliveries" Then ShopDeliveries.Show()
        If txtOption.Text = "Sales" Then updatedSales.Show()
        If txtOption.Text = "Shop Adjustments" Then ShopAdjustments.Show()
        If txtOption.Text = "Returns" Then Returns.Show()

    End Sub

    Private Sub DeleteToolStripButton_Click(sender As Object, e As EventArgs) Handles DeleteToolStripButton.Click
        Dim result2 As DialogResult = MessageBox.Show("Are you sure you wish to delete record",
                              "Delete Record",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question)
        ' txtMode.Text = "DELETE"
        If result2 <> DialogResult.Yes Then Exit Sub
        If result2 = DialogResult.Yes And txtOption.Text = "Shops" Then deleteShop()
        If result2 = DialogResult.Yes And txtOption.Text = "Suppliers" Then deleteSupplier()
        If result2 = DialogResult.Yes And txtOption.Text = "Shop Transfers" Then deleteShopTransfers()
        If result2 = DialogResult.Yes And txtOption.Text = "Purchase Order" Then deletePurchaseOrder()
        If result2 = DialogResult.Yes And txtOption.Text = "Stock" Then deleteStock()
        If result2 = DialogResult.Yes And txtOption.Text = "Warehouse Adjustments" Then deleteWarehouseAdjustments()
        If result2 = DialogResult.Yes And txtOption.Text = "Shop deliveries" Then deleteShopDelivery()
        If result2 = DialogResult.Yes And txtOption.Text = "Sales" Then deleteShopSales()
        If result2 = DialogResult.Yes And txtOption.Text = "Shop Adjustments" Then deleteShopAdjustments()
        If result2 = DialogResult.Yes And txtOption.Text = "Returns" Then deleteReturns()
    End Sub

    Private Sub RefreshToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshToolStripButton.Click
        If txtOption.Text = "Shops" Then ShopsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Suppliers" Then SuppliersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop Transfers" Then ShopTransfersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Purchase Order" Then PurchaseOrdersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Stock" Then StockToolStripMenuItem.PerformClick()
        If txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustmentsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop deliveries" Then ShopDeliveriesToolStripMenuItem.PerformClick()
        If txtOption.Text = "Sales" Then SalesToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop Adjustments" Then ShopAdjustmentsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Returns" Then ReturnsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ShopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Color.LightSkyBlue
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShop()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppliersToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Color.LightSkyBlue
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadSuppliers()

    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Color.LightSkyBlue
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        txtOption.Text = "Stock"
        LoadStock()

    End Sub

    Private Sub PurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseOrdersToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Color.LightSkyBlue
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadPurchaseOrders()

    End Sub

    Private Sub CloseToolStripButton_Click(sender As Object, e As EventArgs) Handles CloseToolStripButton.Click
        End
    End Sub

    Private Sub AboutToolStripButton_Click(sender As Object, e As EventArgs) Handles AboutToolStripButton.Click
        AboutBox.Show()
    End Sub

    Private Sub WarehouseAdjustmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseAdjustmentsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Color.LightSkyBlue
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadWarehouseAdjustment()

    End Sub

    Private Sub ShopDeliveriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopDeliveriesToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Color.LightSkyBlue
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShopDel()

    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Color.LightSkyBlue
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadSales()

    End Sub

    Private Sub ShopAdjustmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopAdjustmentsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Color.LightSkyBlue
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShopAdjustment()

    End Sub

    Private Sub ShopTransfersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopTransfersToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Color.LightSkyBlue
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShopTrans()

    End Sub

    Private Sub ReturnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Color.LightSkyBlue
        LoadReturns()

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()

    End Sub
    Private Sub FindToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripButton.Click
        FindInput.Visible = True
        menustripTextbox1.Visible = True

    End Sub
    Private Sub Findshop()
        If FindInput.Text = "" Then LoadShop()
        If FindInput.Text <> "" Then
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShops", connection)
            gridDataAdapter.Fill(data, "tblShops")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()

            'Dim tables As DataTableCollection = data.Tables
            'data.Locale = System.Globalization.CultureInfo.InvariantCulture
            'Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShops", connection)
            'gridDataAdapter.Fill(data, "tblShops")
            'Dim view1 As New DataView(tables(0))
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            '  BindingSource1.DataSource = view1
            ' BindingSource1.Filter = "[ShopRef] = '" & FindInput.Text & "'"
            '  DataGridView1.DataSource = BindingSource1
            '  DataGridView1.Refresh()
            '   Dim dv As DataView
            '   dv = New DataView(ds.Tables(0), "ShopRef = '" & FindInput.Text & "'", "", DataViewRowState.CurrentRows)
            ' DataGridView1.DataSource = dv
            'ShopID
            DataGridView1.Columns.Item(0).Visible = True
            'ShopRef
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Shop.Address1
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Address"
            DataGridView1.Columns.Item(3).Width = "182"
            'Shop.Address2
            DataGridView1.Columns.Item(4).Visible = False
            'Shop.Address3
            DataGridView1.Columns.Item(5).Visible = False
            'Shop.Address4
            DataGridView1.Columns.Item(6).Visible = False
            'Shop.PostCode
            DataGridView1.Columns.Item(7).Visible = False
            'Shop.ContactName
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "Contact Name"
            DataGridView1.Columns.Item(8).Width = "182"
            'Shop.Telephone
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Telephone"
            DataGridView1.Columns.Item(9).Width = "182"
            'Shop.Telephone2
            DataGridView1.Columns.Item(10).Visible = False
            'Shop.Fax
            DataGridView1.Columns.Item(11).Visible = False
            'Shop.eMail
            DataGridView1.Columns.Item(12).Visible = False
            'Shop.memo
            DataGridView1.Columns.Item(13).Visible = False
            'Shop.ShopType
            DataGridView1.Columns.Item(14).HeaderText = "Type"
            DataGridView1.Columns.Item(14).Width = "182"
            'Shop.Clearance
            DataGridView1.Columns.Item(15).HeaderText = "Clearance Shop"
            DataGridView1.Columns.Item(15).Width = "182"
            'Shop.CreatedBy
            '    DataGridView1.Columns.Item(16).HeaderText = "Created By"
            '   DataGridView1.Columns.Item(16).Width = "182"
            'Shop.CreatedDate
            '   DataGridView1.Columns.Item(17).HeaderText = "Created At"
            '   DataGridView1.Columns.Item(17).Width = "182"
        End If
    End Sub

    Private Sub findsuppliers()
        If FindInput.Text = "" Then LoadSuppliers()
        If FindInput.Text <> "" Then
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSuppliers", connection)
            gridDataAdapter.Fill(data, "tblSuppliers")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[SupplierRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            '  Dim dgv As New DataTable
            '  DataGridView1.DataSource = BindingSource1
            ' Dim data As New DataSet()
            ' Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            '  Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSuppliers", connection)
            ' gridDataAdapter.Fill(data, "tblSuppliers")
            '  Dim view1 As New DataView(tables(0))
            '  BindingSource1.DataSource = view1
            '  Dim dv As DataView
            '  dv = New DataView(data.Tables(0), "SupplierRef = '" & FindInput.Text & "'", "", DataViewRowState.CurrentRows)
            '  DataGridView1.DataSource = dv
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            '   BindingSource1.Filter = "[SupplierRef] = '" & FindInput.Text & "'"
            ' DataGridView1.DataSource = BindingSource1
            ' DataGridView1.Refresh()
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'SupplierName
            DataGridView1.Columns.Item(2).HeaderText = "Supplier Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Supplier.Address1
            DataGridView1.Columns.Item(3).HeaderText = "Address"
            DataGridView1.Columns.Item(3).Width = "182"
            'Supplier.Address2
            DataGridView1.Columns.Item(4).Visible = False
            'Supplier.Address3
            DataGridView1.Columns.Item(5).Visible = False
            'Supplier.Address4
            DataGridView1.Columns.Item(6).Visible = False
            'Supplier.PostCode
            DataGridView1.Columns.Item(7).Visible = False
            'Supplier.ContactName
            DataGridView1.Columns.Item(8).HeaderText = "Contact Name"
            DataGridView1.Columns.Item(8).Width = "182"
            'Supplier.Telephone
            DataGridView1.Columns.Item(9).HeaderText = "Telephone"
            DataGridView1.Columns.Item(9).Width = "182"
            'Supplier.Telephone2
            DataGridView1.Columns.Item(10).Visible = False
            'Supplier.Fax
            DataGridView1.Columns.Item(11).Visible = False
            'Supplier.eMail
            DataGridView1.Columns.Item(12).Visible = False
            'Supplier.memo
            DataGridView1.Columns.Item(13).Visible = False
            'Supplier.CreatedBy
            DataGridView1.Columns.Item(14).HeaderText = "Created By"
            DataGridView1.Columns.Item(14).Width = "182"
            'Supplier.CreatedDate
            '  DataGridView1.Columns.Item(15).HeaderText = "Created At"
            ' DataGridView1.Columns.Item(15).Width = "182"
        End If

    End Sub
    Private Sub findstock()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"


            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryStockvaluespc1", connection)
            gridDataAdapter.Fill(data, "qryStockvaluespc1")
            Dim view1 As New DataView(tables(0))
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[StockCode] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'StockCode
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(0).Width = 120
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = 80
            'Dead Code
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Dead Code"
            DataGridView1.Columns.Item(2).Width = 80
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Amount Taken"
            DataGridView1.Columns.Item(4).Width = 80
            DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            '  DataGridView1.Columns.Item(4).Visible = False
            ' DataGridView1.Columns.Item(4).Width = "10"
            'CostValue
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Cost Value"
            DataGridView1.Columns.Item(3).Width = 80
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DataGridView1.Columns.Item(5).HeaderText = "Markup"
            DataGridView1.Columns.Item(5).Width = 80
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "p"
            'ZeroQty
            DataGridView1.Columns.Item(6).Visible = False
            '   DataGridView1.Columns.Item(7).HeaderText = "Zero Qty"
            '  DataGridView1.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            '  DataGridView1.Columns.Item(8).HeaderText = "Created By"
            DataGridView1.Columns.Item(6).Width = 0
            'Stock.CreatedDate
            '   DataGridView1.Columns.Item(9).HeaderText = "Created At"
            '   DataGridView1.Columns.Item(9).Width = "12"
            '   DataGridView1.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            ToolStripStatusLabel1.Text = "Stock"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
        End If
    End Sub
    Private Sub findsales()
        If FindInput.Text = "" Then LoadSales()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "ShopRef"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = "182"
            'CreatedBy
            ' DataGridView1.Columns.Item(7).Visible = False
            'DataGridView1.Columns.Item(7).HeaderText = "From ID"
            'DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            'DataGridView1.Columns.Item(8).Visible = False
            ' DataGridView1.Columns.Item(8).HeaderText = "To ID"
            'DataGridView1.Columns.Item(8).Width = "182"
        End If
    End Sub
    Private Sub findPO()
        If FindInput.Text = "" Then LoadPurchaseOrders()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "SupplierRef"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblDeliveries", connection)
            gridDataAdapter.Fill(data, "tblDeliveries")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[SupplierRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'tblDeliveries.DeliveryID
            DataGridView1.Columns.Item(0).Visible = True
            '   DataGridView1.Columns.Item(0).HeaderText = "Order Number"
            ' DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "Number"
            DataGridView1.Columns.Item(0).Width = "182"

            'tblDeliveries.OurRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Our Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'tblDeliveries.SupplierRef
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(2).Width = "182"
            'tblSuppliers.SupplierName
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Supplier Name"
            DataGridView1.Columns.Item(3).Width = "182"
            'tblDeliveries.Season
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Season"
            DataGridView1.Columns.Item(4).Width = "182"
            'tblDeliveries.WarehouseRef
            DataGridView1.Columns.Item(5).Visible = False
            DataGridView1.Columns.Item(5).HeaderText = "Warehouse Ref"
            DataGridView1.Columns.Item(5).Width = "182"
            'tblDeliveries,TotalGarments
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Garments"
            DataGridView1.Columns.Item(6).Width = "182"
            'tblDeliveries.TotalBoxes 
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Boxes"
            DataGridView1.Columns.Item(7).Width = "182"
            'tblDeliveries.TotalHangers 
            DataGridView1.Columns.Item(8).Visible = True
            DataGridView1.Columns.Item(8).HeaderText = "Hangers"
            DataGridView1.Columns.Item(8).Width = "182"
            'tblDeliveries.NetAmount 
            DataGridView1.Columns.Item(9).Visible = True
            DataGridView1.Columns.Item(9).HeaderText = "Net Cost"
            DataGridView1.Columns.Item(9).Width = "182"
            'tblDeliveries.DeliveryCharge
            DataGridView1.Columns.Item(10).Visible = False
            DataGridView1.Columns.Item(10).HeaderText = "Delivery Charge"
            DataGridView1.Columns.Item(10).Width = "182"
            'tblDeliveries.Commission
            DataGridView1.Columns.Item(11).Visible = False
            DataGridView1.Columns.Item(11).HeaderText = "Commission"
            DataGridView1.Columns.Item(11).Width = "182"
            'tblDeliveries.GrossAmount
            DataGridView1.Columns.Item(12).Visible = False
            DataGridView1.Columns.Item(12).HeaderText = "Total Amount"
            DataGridView1.Columns.Item(12).Width = "182"
            'tblDeliveries.DeliveryDate
            DataGridView1.Columns.Item(13).Visible = True
            DataGridView1.Columns.Item(13).HeaderText = "Order Date"
            DataGridView1.Columns.Item(13).Width = "182"
            'tblDeliveries.DeliveryType
            DataGridView1.Columns.Item(14).Visible = False
            DataGridView1.Columns.Item(14).HeaderText = "Delivery Type"
            DataGridView1.Columns.Item(14).Width = "182"
            'tblDeliveries.ConfirmedDate
            DataGridView1.Columns.Item(15).Visible = False
            DataGridView1.Columns.Item(15).HeaderText = "Confirmed Date"
            DataGridView1.Columns.Item(15).Width = "182"
            'tblDeliveries.Notes
            DataGridView1.Columns.Item(16).Visible = False
            DataGridView1.Columns.Item(16).HeaderText = "Notes"
            DataGridView1.Columns.Item(16).Width = "182"
            'tblDeliveries.Invoice
            DataGridView1.Columns.Item(17).Visible = False
            DataGridView1.Columns.Item(17).HeaderText = "Invoice"
            DataGridView1.Columns.Item(17).Width = "182"
            'tblDeliveries.Shipper
            DataGridView1.Columns.Item(18).Visible = False
            DataGridView1.Columns.Item(18).HeaderText = "Shipper"
            DataGridView1.Columns.Item(18).Width = "182"
            'tblDeliveries.ShipperInvoice
            DataGridView1.Columns.Item(19).Visible = False
            DataGridView1.Columns.Item(19).HeaderText = "Shipper Invoice"
            DataGridView1.Columns.Item(19).Width = "182"
            'tblDeliveries.CreatedBy
            DataGridView1.Columns.Item(20).Visible = False
            DataGridView1.Columns.Item(20).HeaderText = "Created By"
            DataGridView1.Columns.Item(20).Width = "182"
            'tblDeliveries.CreatedDate 
            DataGridView1.Columns.Item(21).Visible = False
            DataGridView1.Columns.Item(21).HeaderText = "Created AT"
            DataGridView1.Columns.Item(21).Width = "182"
        End If
    End Sub
    Private Sub findST()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShopTransferDisplayMain", connection)
            gridDataAdapter.Fill(data, "qryShopTransferDisplayMain")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'tblShopTransfer.TransferID
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(0).HeaderText = "TransID Ref"
            DataGridView1.Columns.Item(0).Width = "182"
            'tblWarehouseTransfer.Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "TF Note"
            DataGridView1.Columns.Item(1).Width = "182"
            'TransferDate
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Date"
            DataGridView1.Columns.Item(2).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "From Ref"
            DataGridView1.Columns.Item(3).Width = "182"
            'TotalQtyOut
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "From Shop"
            DataGridView1.Columns.Item(4).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Created By"
            DataGridView1.Columns.Item(9).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(10).Visible = False
            DataGridView1.Columns.Item(10).HeaderText = "Created At"
            DataGridView1.Columns.Item(10).Width = "182"
            'ToShopRef
            DataGridView1.Columns.Item(7).Visible = True
            'DataGridView1.Columns.Item(7).HeaderText = "To Ref"
            DataGridView1.Columns.Item(7).Width = "182"
            'TotalQtyIn
            DataGridView1.Columns.Item(8).Visible = True
            DataGridView1.Columns.Item(8).HeaderText = "To Quantity"
            DataGridView1.Columns.Item(8).Width = "182"

        End If
    End Sub
    Private Sub findSD()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryGridShopDelDisplay order by DeliveriesID desc", connection)
            gridDataAdapter.Fill(data, "qryGridShopDelDisplay")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'DeliveryID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Reference"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = False
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop"
            DataGridView1.Columns.Item(2).Width = "182"
            'WarehouseRef
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Warehouse Ref"
            DataGridView1.Columns.Item(3).Width = "182"
            'WarehouseName
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Warehouse"
            DataGridView1.Columns.Item(4).Width = "182"
            'Reference
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Delivery No"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalHangers
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Quantity"
            DataGridView1.Columns.Item(6).Width = "182"
            'DeliveryDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Delivery Date"
            DataGridView1.Columns.Item(7).Width = "182"
            'DeliveryType
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "Type"
            DataGridView1.Columns.Item(8).Width = "182"
            'ConfirmedDate
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Confirmed Date"
            DataGridView1.Columns.Item(0).Width = "182"
            'Notes
            '   DataGridView1.Columns.Item(10).Visible = True
            '  DataGridView1.Columns.Item(10).HeaderText = "Notes"
            '  DataGridView1.Columns.Item(10).Width = "182"
            'CreatedBy
            '   DataGridView1.Columns.Item(11).Visible = False
            '   DataGridView1.Columns.Item(11).HeaderText = "Created By"
            '   DataGridView1.Columns.Item(11).Width = "182"
            'CreatedDate
            '    DataGridView1.Columns.Item(12).Visible = False
            '   DataGridView1.Columns.Item(12).HeaderText = "Created At"
            '  DataGridView1.Columns.Item(12).Width = "182"
        End If
    End Sub
    Private Sub findWA()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = "182"
            'CreatedBy
            ' DataGridView1.Columns.Item(7).Visible = False
            'DataGridView1.Columns.Item(7).HeaderText = "From ID"
            'DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            'DataGridView1.Columns.Item(8).Visible = False
            ' DataGridView1.Columns.Item(8).HeaderText = "To ID"
            'DataGridView1.Columns.Item(8).Width = "182"
        End If
    End Sub
    Private Sub findSA()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.FindInput.Visible = True
            Me.menustripTextbox1.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False

            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = "182"
            'CreatedBy
            ' DataGridView1.Columns.Item(7).Visible = False
            'DataGridView1.Columns.Item(7).HeaderText = "From ID"
            'DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            'DataGridView1.Columns.Item(8).Visible = False
            ' DataGridView1.Columns.Item(8).HeaderText = "To ID"
            'DataGridView1.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub FindInput_TextChanged(sender As Object, e As EventArgs) Handles FindInput.TextChanged
        If txtOption.Text = "Shops" Then Findshop() '1
        If txtOption.Text = "Suppliers" Then findsuppliers() '2
        If txtOption.Text = "Shop Transfers" Then findST() '7
        If txtOption.Text = "Purchase Order" Then findPO() '4
        If txtOption.Text = "Stock" Then findstock() ' 3
        If txtOption.Text = "Shop deliveries" Then findSD()
        If txtOption.Text = "Sales" Then findsales()

    End Sub

    Private Sub ProveToolStripButton_Click(sender As Object, e As EventArgs) Handles ProveToolStripButton.Click
        ' If MsgBox("Confirm Recalculate Stock Values.", vbYesNo + vbQuestion + vbDefaultButton2, Application.ProductName) = MsgBoxResult.Yes Then stockupdate()

    End Sub

    Private Sub AllStockMovementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllStockMovementsToolStripMenuItem.Click
        Criteria.Label3.Text = "AllStock"
        Criteria.Show()
    End Sub

    Private Sub DeliveriesByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveriesByStockCodeToolStripMenuItem.Click
        Criteria.Label3.Text = "ShopDeliveries"
        Criteria.Show()

    End Sub

    Private Sub StockListByShopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByShopToolStripMenuItem.Click
        Criteria.Label3.Text = "ShopStock1"
        Criteria.Show()
    End Sub

    Private Sub StockListByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByStockCodeToolStripMenuItem.Click
        Criteria.Label3.Text = "ShopStock2"
        Criteria.Show()
    End Sub

    Private Sub WarehouseStockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseStockListToolStripMenuItem.Click
        ' ReportWarehouseStock.Show()
        Criteria.Label3.Text = "WarehouseStock"
        Criteria.Show()

    End Sub

    Private Sub TotalStockValuationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalStockValuationToolStripMenuItem.Click
        Criteria.Label3.Text = "TotalValue"
        Criteria.Show()
        ' ReportCritera.lblReports.Text = "TotalValue"
        '  ReportCritera.lblReportName.Text = "Total Stock Value Report"
        ' ReportCritera.Show()
        '   ReportTotalvalue.Show()

    End Sub

    Private Sub SalesHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesHistoryToolStripMenuItem.Click
        Criteria.Label3.Text = "SalesHistory"
        Criteria.Show()

    End Sub

    Private Sub SalesAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesAnalysisToolStripMenuItem.Click
        Criteria.Label3.Text = "SalesAnalysis"
        Criteria.Show()


    End Sub

    Private Sub AllStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllStockToolStripMenuItem.Click
        txtOption.Text = "Stock"
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Color.LightSkyBlue
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadStock2()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick


    End Sub

    Private Sub deleteShop()

        Dim conn As New SqlConnection(connectionString)
        Dim Delcmd As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblShops", connection)
        griddataadpter.Fill(data, "tblshops")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        DataGridView1.DataSource = BindingSource1
        '  MessageBox.Show("Shop Record: " + CurrentID + " Has been deleted")
        Delcmd.Connection = conn
        Delcmd.Connection.Open()
        Delcmd.CommandType = CommandType.Text
        Delcmd.CommandText = "DELETE FROM tblShops WHERE ShopRef='" & CurrentID & "'"
        Delcmd.ExecuteNonQuery()
        Delcmd.Connection.Close()
        ShopsToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteSupplier()
        Dim conn As New SqlConnection(connectionString)
        Dim Delcmd As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblSuppliers", connection)
        griddataadpter.Fill(data, "tblSuppliers")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        DataGridView1.DataSource = BindingSource1
        ' MessageBox.Show("Supplier Record: " + CurrentID + " Has been deleted")
        Delcmd.Connection = conn
        Delcmd.Connection.Open()
        Delcmd.CommandType = CommandType.Text
        Delcmd.CommandText = "DELETE FROM tblSuppliers WHERE SupplierRef='" & CurrentID & "'"
        Delcmd.ExecuteNonQuery()
        Delcmd.Connection.Close()
        SuppliersToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deletePurchaseOrder()
        Dim conn As New SqlConnection(connectionString)
        Dim deletecommand As New SqlCommand()
        Dim duplicatecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblDeliveries order by deliveryDate desc", connection)
        griddataadpter.Fill(data, "tblDeliveries")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        Dim StockCode As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        StockCode = DataGridView1.Item(6, i).Value.ToString
        DataGridView1.DataSource = BindingSource1

        Try
            Dim queryResult As Integer
            duplicatecommand.Connection = conn
            duplicatecommand.Connection.Open()
            duplicatecommand.CommandType = CommandType.Text
            duplicatecommand.CommandText = " SELECT COUNT(*) as numRows From tblStockMovements WHERE SMstockcode = '" + StockCode + "' AND MovementType <> 'Delivery (W)'"
            queryResult = duplicatecommand.ExecuteNonQuery()
            duplicatecommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Stock Record :" + StockCode + " Has Other records Unable to delete Purchase Order ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        deletecommand.Connection = conn
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE FROM tblDeliveries WHERE DeliveriesID='" & CurrentID & "'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        deletecommand.Connection = conn
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE FROM tblStockmovements WHERE TransferReference='" & CurrentID & "' AND MovementType = 'Delivery (W)'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        ' MessageBox.Show("Purchase Order " + CurrentID + " Has been deleted")
        PurchaseOrdersToolStripMenuItem.PerformClick()

    End Sub
    Private Sub deleteWarehouseAdjustments()
        Dim conn As New SqlConnection(connectionString)
        Dim DeleteCommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from qryWarehouseAdjustments", connection)
        griddataadpter.Fill(data, "qryWarehouseAdjustments")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        DataGridView1.DataSource = BindingSource1
        MessageBox.Show(CurrentID)
        deletecommand.Connection = conn
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE FROM tblStockmovements WHERE StockMovementID ='" & CurrentID & "'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        '   MessageBox.Show("Warehouse Adjustment " + CurrentID + " Has been deleted")
        WarehouseAdjustmentsToolStripMenuItem.PerformClick()

    End Sub
    Private Sub deleteShopDelivery()
        Dim conn As New SqlConnection(connectionString)
        Dim Delcmd2 As New SqlCommand()

        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblShopDeliveries", connection)
        griddataadpter.Fill(data, "tblshopDeliveries")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        Dim DelNoteNumber As Integer
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        DataGridView1.DataSource = BindingSource1
        '  MessageBox.Show(CurrentID)
        DelNoteNumber = DataGridView1.Item(0, i).Value
        Delcmd2.Connection = connection
        Delcmd2.Connection.Open()
        Delcmd2.CommandType = CommandType.Text
        Delcmd2.CommandText = "DELETE from tblStockMovements where TransferReference = '" + CurrentID + "' AND MovementType = 'Delivery (S)';DELETE from tblShopDeliveriesLines where SDeliveriesID = '" + CurrentID + "';DELETE from tblShopDeliveries where DeliveriesID = '" + CurrentID + "'"
        Delcmd2.ExecuteNonQuery()
        Delcmd2.Connection.Close()
        ' Delcmd2.Connection = connection
        ' Delcmd2.Connection.Open()
        ' Delcmd2.CommandType = CommandType.Text
        ' deletecommand.CommandText = ""
        ' deletecommand.ExecuteNonQuery()
        ' deletecommand.Connection.Close()
        ' deletecommand.Connection = connection
        ' deletecommand.Connection.Open()
        ' deletecommand.CommandType = CommandType.Text
        ' deletecommand.CommandText = ""
        ' deletecommand.ExecuteNonQuery()
        ' deletecommand.Connection.Close()
        ShopDeliveriesToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteShopAdjustments()
        Dim conn As New SqlConnection(connectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from qryShopAdjustments", connection)
        griddataadpter.Fill(data, "qryShopAdjustments")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        'Dim reference As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        DataGridView1.DataSource = BindingSource1
        '  MessageBox.Show(CurrentID)
        Deletecommand.Connection = conn
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE FROM tblStockmovements WHERE StockMovementID ='" & CurrentID & "'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        '   MessageBox.Show("Shop Adjustment " + CurrentID + " Has been deleted")
        ShopAdjustmentsToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteShopSales()
        Dim conn As New SqlConnection(connectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblSales", connection)
        griddataadpter.Fill(data, "tblsales")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        DataGridView1.DataSource = BindingSource1
        '  MessageBox.Show("Sales Record " + CurrentID + "Has been deleted")
        Deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "Delete From tblSalesLines where SalesID='" + CurrentID + "';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + CurrentID + "';Delete from tblSales where SalesID='" + CurrentID.ToString + "';"
        deletecommand.Connection = connection
        deletecommand.Connection.Close()
        deletecommand.Connection.Open()
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        SalesToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteShopTransfers()
        Dim conn As New SqlConnection(connectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblShopTransfers", connection)
        griddataadpter.Fill(data, "tblshopTransfers")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(1, i).Value
        DataGridView1.DataSource = BindingSource1
        '  MessageBox.Show(CurrentID + " Has been deleted")
        Deletecommand.Connection = connection
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "DELETE from tblStockMovements where TransferReference = '" + CurrentID.ToString + "' AND MovementType='Shop Transfer';"
        Deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        deletecommand.Connection = connection
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE from tblShopTransferLines where TransferID = '" + CurrentID.ToString + "'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        deletecommand.Connection = connection
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE from tblShopTransfers where TransferID = '" + CurrentID.ToString + "'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        ShopTransfersToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteReturns()
        Dim conn As New SqlConnection(connectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from qryReturns", connection)
        griddataadpter.Fill(data, "qryReturns")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        Dim reference As String
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(5, i).Value
        DataGridView1.DataSource = BindingSource1
        ' MessageBox.Show(CurrentID)

        reference = DataGridView1.Item(1, i).Value
        '     DateTimePicker1.Value = Main.DataGridView1.Item(9, i).Value
        deletecommand.Connection = connection
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "DELETE from tblStockMovements where Reference = '" + CurrentID + "' AND MovementType = 'return'"
        Deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        Dim DeleteCommand2 As New SqlCommand
        DeleteCommand2.Connection = connection
        DeleteCommand2.CommandType = CommandType.Text
        DeleteCommand2.CommandText = "DELETE from tblReturn where TFNote ='" + reference.ToString + "'"
        DeleteCommand2.Connection.Close()
        DeleteCommand2.Connection.Open()
        DeleteCommand2.ExecuteNonQuery()
        DeleteCommand2.Connection.Close()
        ReturnsToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteStock()
        Dim conn As New SqlConnection(connectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblStock", connection)
        griddataadpter.Fill(data, "tblstock")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CurrentID = DataGridView1.Item(0, i).Value
        DataGridView1.DataSource = BindingSource1
        MessageBox.Show(CurrentID)
        cmd.Connection = connection
        cmd.Connection.Open()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM tblStock WHERE StockCode='" & CurrentID.ToString & "'"
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
        StockToolStripMenuItem.PerformClick()
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave

    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        'Dim rowclicked As Integer
        '  If e.Button = MouseButtons.Left Then Rowclicked = DataGridView1.HitTest(e.Location.X, e.Location.Y).RowIndex : 

        '  If e.Button = MouseButtons.Right Then rowclicked = DataGridView1.HitTest(e.Location.X, e.Location.Y).RowIndex : DeleteToolStripButton.PerformClick()
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If txtOption.Text = "Shops" Then PrintShops() '1
        If txtOption.Text = "Suppliers" Then PrintSuppliers() '2
        If txtOption.Text = "Purchase Order" Then PrintPurchase() '4
        If txtOption.Text = "Stock" Then PrintStock() ' 3
        If txtOption.Text = "Shop deliveries" Then printShopDels()
        If txtOption.Text = "Sales" Then printSales()
        ' Dim fpr As New Print
        ' With fpr
        ' .Text = "Print Preview"
        ' .ShowDialog()
        ' If .DialogResult > 0 Then

        ' End If
        '  End With
        '  PrintDocument1.Print()
        '    Dim ppd As New PrintPreviewDialog
        '   Dim printDlg As New PrintDialog()
        '   PrintDialog1.AllowSomePages = True
        '   PrintDialog1.AllowSelection = True

        '   PrintDialog1.Document = PrintDocument1
        '   PrintDialog1.PrinterSettings.PrintRange = PrintRange.Selection
        '    PrintDocument1.PrinterSettings.FromPage = PrintDialog1.PrinterSettings.FromPage
        ' PrintDocument1.PrinterSettings.ToPage = PrintDialog1.PrinterSettings.ToPage
        '  PrintDocument1.PrinterSettings.Copies = PrintDialog1.PrinterSettings.Copies

        '  ppd.Document = PrintDocument1
        '  ppd.WindowState = FormWindowState.Maximized
        ' ppd.ShowDialog()
        '  PrintDialog1.ShowDialog()
        '   If DialogResult.OK Then PrintDocument1.Print()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Dim bm As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        ' DataGridView1.DrawToBitmap(bm, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        'e.Graphics.DrawImage(bm, 0, 0)
        Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Label1.Height)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(Label1.Text, Label1.Font, Brushes.Black, rect, sf)

        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = 50
        Dim startY As Integer = rect.Bottom

        Static startPage As Integer = 0

        For p As Integer = startPage To pages.Count - 1
            Dim cell As New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.ColumnHeadersHeight)
            e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            e.Graphics.DrawRectangle(Pens.Black, cell)

            startY += DataGridView1.ColumnHeadersHeight

            For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                cell = New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.Rows(r).Height)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)
                e.Graphics.DrawString(DataGridView1.Rows(r).HeaderCell.Value, DataGridView1.Font, Brushes.Black, cell, sf)
                startY += DataGridView1.Rows(r).Height
            Next

            startX += cell.Width
            startY = rect.Bottom

            For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.ColumnHeadersHeight)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)
                e.Graphics.DrawString(DataGridView1.Columns(c).HeaderCell.Value, DataGridView1.Font, Brushes.Black, cell, sf)
                startX += DataGridView1.Columns(c).Width
            Next

            startY = rect.Bottom + DataGridView1.ColumnHeadersHeight

            For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                startX = 50 + DataGridView1.RowHeadersWidth
                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                    cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.Rows(r).Height)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    e.Graphics.DrawString(DataGridView1(c, r).Value, DataGridView1.Font, Brushes.Black, cell, sf)
                    startX += DataGridView1.Columns(c).Width
                Next
                startY += DataGridView1.Rows(r).Height
            Next

            If p <> pages.Count - 1 Then
                startPage = p + 1
                e.HasMorePages = True
                Return
            Else
                startPage = 0
            End If

        Next
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        ''this removes the printed page margins
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)
        PrintDocument1.DefaultPageSettings.Landscape = False

        Dim xCustomSize As New PaperSize("A4", 670, 1100)

        PrintDocument1.DefaultPageSettings.PaperSize = xCustomSize
        pages = New Dictionary(Of Integer, pageDetails)

        Dim maxWidth As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 20
        Dim maxHeight As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40 + Label1.Height

        Dim pageCounter As Integer = 0
        pages.Add(pageCounter, New pageDetails)

        Dim columnCounter As Integer = 0

        Dim columnSum As Integer = DataGridView1.RowHeadersWidth / 1.25

        For c As Integer = 0 To DataGridView1.Columns.Count - 1
            If columnSum + DataGridView1.Columns(c).Width < maxWidth Then
                columnSum += DataGridView1.Columns(c).Width
                columnCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                columnSum = DataGridView1.RowHeadersWidth + DataGridView1.Columns(c).Width
                columnCounter = 1
                pageCounter += 1
                pages.Add(pageCounter, New pageDetails With {.startCol = c})
            End If
            If c = DataGridView1.Columns.Count - 1 Then
                If pages(pageCounter).columns = 0 Then
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                End If
            End If
        Next

        maxPagesWide = pages.Keys.Max + 1

        pageCounter = 0

        Dim rowCounter As Integer = 0

        Dim rowSum As Integer = DataGridView1.ColumnHeadersHeight

        For r As Integer = 0 To DataGridView1.Rows.Count - 2
            If rowSum + DataGridView1.Rows(r).Height < maxHeight Then
                rowSum += DataGridView1.Rows(r).Height
                rowCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                For x As Integer = 1 To maxPagesWide - 1
                    pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                Next

                pageCounter += maxPagesWide
                For x As Integer = 0 To maxPagesWide - 1
                    pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = r})
                Next

                rowSum = DataGridView1.ColumnHeadersHeight + DataGridView1.Rows(r).Height
                rowCounter = 1
            End If
            If r = DataGridView1.Rows.Count - 2 Then
                For x As Integer = 0 To maxPagesWide - 1
                    If pages(pageCounter + x).rows = 0 Then
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                    End If
                Next
            End If
        Next

        maxPagesTall = pages.Count \ maxPagesWide
    End Sub

    Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        RecordToolStripButton.PerformClick()
    End Sub

    Private Sub PrintShops2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintShop", connection)
            gridDataAdapter.Fill(data, "qryPrintShop")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryPrintShop"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.Columns.Item(0).Width = 40
            DataGridView1.RowHeadersWidth = 50
            ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()

        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintSuppliers2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintSuppliers", connection)
            gridDataAdapter.Fill(data, "qryPrintSuppliers")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryPrintSuppliers"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.Columns.Item(0).Width = 40
            DataGridView1.RowHeadersWidth = 50
            '    ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
            '  PrintDocument1.Print()
            ' Dim ppd As New PrintPreviewDialog

            '   ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintStock2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryStockvaluespc1", connection)
            gridDataAdapter.Fill(data, "qryStockvaluespc1")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryStockvaluespc1"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ' DataGridView1.Columns.Item(0).Width = 40
            DataGridView1.RowHeadersWidth = 50
            '  ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
            '  PrintDocument1.Print()
            '   Dim ppd As New PrintPreviewDialog

            '  ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintPurchase2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintPurchase", connection)
            gridDataAdapter.Fill(data, "qryPrintPurchase")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryPrintPurchase"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "c"

            DataGridView1.Columns.Item(0).Width = 50
            DataGridView1.Columns.Item(3).Width = 50
            DataGridView1.RowHeadersWidth = 50
            ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
            '  PrintDocument1.Print()
            '  Dim ppd As New PrintPreviewDialog

            '   ppd.Document = PrintDocument1
            '   ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub printShopDels2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintShopDelivery", connection)
            gridDataAdapter.Fill(data, "qryPrintShopDelivery")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryPrintShopDelivery"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.Columns.Item(0).Width = 50
            DataGridView1.Columns.Item(4).Width = 50
            DataGridView1.RowHeadersWidth = 50
            '  ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
            '  PrintDocument1.Print()
            '  Dim ppd As New PrintPreviewDialog

            '  ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintSalesGrid2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintSalesGrid", connection)
            gridDataAdapter.Fill(data, "qryPrintSalesGrid")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryPrintSalesGrid"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.Columns.Item(0).Width = 40
            DataGridView1.Columns.Item(4).Width = 50
            DataGridView1.Columns.Item(1).Width = 50
            DataGridView1.RowHeadersWidth = 50
            'ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DataGridView1.Rows.Count
            connection.Close()
            '  PrintDocument1.Print()
            '   Dim ppd As New PrintPreviewDialog

            '  ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '   ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub printShops()
        Print.Text = "Print Shop Grid"
        Print.Show()
    End Sub
    Private Sub printSuppliers()
        Print.Text = "Print Suppliers Grid"
        Print.Show()
    End Sub
    Private Sub printStock()
        Print.Text = "Print Stock Grid"
        Print.Show()
    End Sub
    Private Sub printPurchase()
        Print.Text = "Print Purchase Order Grid"
        Print.Show()
    End Sub
    Private Sub printShopDels()
        Print.Text = "Print Shop Deliveries Grid"
        Print.Show()
    End Sub
    Private Sub printSales()
        Print.Text = "Print Shop Sales Grid"
        Print.Show()
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        txtOption.Text = "Stock"
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Color.LightSkyBlue
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadStock2()
    End Sub

    Private Sub BorehamwoodStockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorehamwoodStockListToolStripMenuItem.Click
        Criteria.Label3.Text = "Borehamwood"
        Criteria.Show()
    End Sub
End Class