<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeliveriesIn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeliveriesIn))
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.txtWarehouseName = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtQtyGarments = New System.Windows.Forms.TextBox()
        Me.cmdFindWarehouse = New System.Windows.Forms.Button()
        Me.cmdFindStockCode = New System.Windows.Forms.Button()
        Me.DGVStock = New System.Windows.Forms.DataGridView()
        Me.DGVSupplier = New System.Windows.Forms.DataGridView()
        Me.cmdFindSupplier = New System.Windows.Forms.Button()
        Me.txtNetCost = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DGVWarehouse = New System.Windows.Forms.DataGridView()
        Me.txtOurRef = New System.Windows.Forms.TextBox()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.txtSupplierInv = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.txtShipper = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtShipperInv = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtOrderID = New System.Windows.Forms.TextBox()
        Me.txtTotalGarments = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtCommission = New System.Windows.Forms.TextBox()
        Me.txtDelCharges = New System.Windows.Forms.TextBox()
        Me.txtTotalNet = New System.Windows.Forms.TextBox()
        Me.txtWarehouseRef = New System.Windows.Forms.TextBox()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.txtSupplierRef = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBoxes = New System.Windows.Forms.TextBox()
        Me.txtHangers = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.DGVStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVWarehouse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(137, 12)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "Consessions"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'txtWarehouseName
        '
        Me.txtWarehouseName.Location = New System.Drawing.Point(108, 105)
        Me.txtWarehouseName.Name = "txtWarehouseName"
        Me.txtWarehouseName.Size = New System.Drawing.Size(133, 20)
        Me.txtWarehouseName.TabIndex = 19
        Me.txtWarehouseName.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(22, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Text = "Direct To Shop"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtQtyGarments
        '
        Me.txtQtyGarments.Location = New System.Drawing.Point(108, 201)
        Me.txtQtyGarments.Name = "txtQtyGarments"
        Me.txtQtyGarments.Size = New System.Drawing.Size(104, 20)
        Me.txtQtyGarments.TabIndex = 3
        Me.txtQtyGarments.Text = "0"
        '
        'cmdFindWarehouse
        '
        Me.cmdFindWarehouse.Location = New System.Drawing.Point(218, 77)
        Me.cmdFindWarehouse.Name = "cmdFindWarehouse"
        Me.cmdFindWarehouse.Size = New System.Drawing.Size(27, 23)
        Me.cmdFindWarehouse.TabIndex = 43
        Me.cmdFindWarehouse.Text = "..."
        Me.cmdFindWarehouse.UseVisualStyleBackColor = True
        Me.cmdFindWarehouse.Visible = False
        '
        'cmdFindStockCode
        '
        Me.cmdFindStockCode.Location = New System.Drawing.Point(218, 178)
        Me.cmdFindStockCode.Name = "cmdFindStockCode"
        Me.cmdFindStockCode.Size = New System.Drawing.Size(27, 23)
        Me.cmdFindStockCode.TabIndex = 46
        Me.cmdFindStockCode.Text = "..."
        Me.cmdFindStockCode.UseVisualStyleBackColor = True
        Me.cmdFindStockCode.Visible = False
        '
        'DGVStock
        '
        Me.DGVStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVStock.Location = New System.Drawing.Point(22, 327)
        Me.DGVStock.Name = "DGVStock"
        Me.DGVStock.Size = New System.Drawing.Size(240, 150)
        Me.DGVStock.TabIndex = 38
        Me.DGVStock.Visible = False
        '
        'DGVSupplier
        '
        Me.DGVSupplier.AllowUserToAddRows = False
        Me.DGVSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSupplier.Location = New System.Drawing.Point(56, 327)
        Me.DGVSupplier.Name = "DGVSupplier"
        Me.DGVSupplier.RowHeadersVisible = False
        Me.DGVSupplier.Size = New System.Drawing.Size(208, 166)
        Me.DGVSupplier.TabIndex = 37
        Me.DGVSupplier.Visible = False
        '
        'cmdFindSupplier
        '
        Me.cmdFindSupplier.Location = New System.Drawing.Point(218, 35)
        Me.cmdFindSupplier.Name = "cmdFindSupplier"
        Me.cmdFindSupplier.Size = New System.Drawing.Size(27, 23)
        Me.cmdFindSupplier.TabIndex = 40
        Me.cmdFindSupplier.Text = "..."
        Me.cmdFindSupplier.UseVisualStyleBackColor = True
        Me.cmdFindSupplier.Visible = False
        '
        'txtNetCost
        '
        Me.txtNetCost.Location = New System.Drawing.Point(108, 225)
        Me.txtNetCost.Name = "txtNetCost"
        Me.txtNetCost.Size = New System.Drawing.Size(104, 20)
        Me.txtNetCost.TabIndex = 4
        Me.txtNetCost.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.Location = New System.Drawing.Point(13, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Supplier Ref:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label25.Location = New System.Drawing.Point(13, 222)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(48, 13)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "Net Cost"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Supplier Name:"
        '
        'DGVWarehouse
        '
        Me.DGVWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVWarehouse.Location = New System.Drawing.Point(24, 317)
        Me.DGVWarehouse.Name = "DGVWarehouse"
        Me.DGVWarehouse.Size = New System.Drawing.Size(240, 150)
        Me.DGVWarehouse.TabIndex = 36
        Me.DGVWarehouse.Visible = False
        '
        'txtOurRef
        '
        Me.txtOurRef.Location = New System.Drawing.Point(108, 129)
        Me.txtOurRef.Name = "txtOurRef"
        Me.txtOurRef.Size = New System.Drawing.Size(104, 20)
        Me.txtOurRef.TabIndex = 13
        Me.txtOurRef.Visible = False
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(108, 180)
        Me.txtStockCode.MaxLength = 30
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(104, 20)
        Me.txtStockCode.TabIndex = 2
        '
        'txtSupplierInv
        '
        Me.txtSupplierInv.Location = New System.Drawing.Point(358, 111)
        Me.txtSupplierInv.MaxLength = 60
        Me.txtSupplierInv.Name = "txtSupplierInv"
        Me.txtSupplierInv.Size = New System.Drawing.Size(121, 20)
        Me.txtSupplierInv.TabIndex = 8
        Me.txtSupplierInv.Text = "0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(13, 157)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(75, 13)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "Delivery Type:"
        Me.Label26.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label22.Location = New System.Drawing.Point(13, 204)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Qty Garments"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label21.Location = New System.Drawing.Point(13, 183)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Stock Code"
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Expected", "Confirmed"})
        Me.cboType.Location = New System.Drawing.Point(108, 153)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(104, 21)
        Me.cboType.TabIndex = 20
        Me.cboType.Visible = False
        '
        'txtShipper
        '
        Me.txtShipper.Location = New System.Drawing.Point(358, 63)
        Me.txtShipper.MaxLength = 60
        Me.txtShipper.Name = "txtShipper"
        Me.txtShipper.Size = New System.Drawing.Size(121, 20)
        Me.txtShipper.TabIndex = 6
        Me.txtShipper.Text = "0"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(302, 317)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtShipperInv
        '
        Me.txtShipperInv.Location = New System.Drawing.Point(358, 87)
        Me.txtShipperInv.MaxLength = 60
        Me.txtShipperInv.Name = "txtShipperInv"
        Me.txtShipperInv.Size = New System.Drawing.Size(121, 20)
        Me.txtShipperInv.TabIndex = 7
        Me.txtShipperInv.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.Location = New System.Drawing.Point(13, 87)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Warehouse Ref:"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(382, 317)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(358, 15)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 108)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "Warehouse Name:"
        '
        'txtOrderID
        '
        Me.txtOrderID.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtOrderID.Location = New System.Drawing.Point(358, 39)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.Size = New System.Drawing.Size(121, 20)
        Me.txtOrderID.TabIndex = 21
        Me.txtOrderID.TabStop = False
        '
        'txtTotalGarments
        '
        Me.txtTotalGarments.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTotalGarments.Location = New System.Drawing.Point(358, 283)
        Me.txtTotalGarments.Name = "txtTotalGarments"
        Me.txtTotalGarments.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalGarments.TabIndex = 24
        Me.txtTotalGarments.TabStop = False
        Me.txtTotalGarments.Text = "0"
        Me.txtTotalGarments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTotal.Location = New System.Drawing.Point(358, 252)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 23
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "£0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCommission
        '
        Me.txtCommission.Location = New System.Drawing.Point(358, 228)
        Me.txtCommission.Name = "txtCommission"
        Me.txtCommission.Size = New System.Drawing.Size(100, 20)
        Me.txtCommission.TabIndex = 10
        Me.txtCommission.Text = "£0.00"
        Me.txtCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDelCharges
        '
        Me.txtDelCharges.Location = New System.Drawing.Point(358, 202)
        Me.txtDelCharges.Name = "txtDelCharges"
        Me.txtDelCharges.Size = New System.Drawing.Size(100, 20)
        Me.txtDelCharges.TabIndex = 9
        Me.txtDelCharges.Text = "£0.00"
        Me.txtDelCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNet
        '
        Me.txtTotalNet.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTotalNet.Location = New System.Drawing.Point(358, 173)
        Me.txtTotalNet.Name = "txtTotalNet"
        Me.txtTotalNet.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalNet.TabIndex = 22
        Me.txtTotalNet.TabStop = False
        Me.txtTotalNet.Text = "£0.00"
        Me.txtTotalNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWarehouseRef
        '
        Me.txtWarehouseRef.Location = New System.Drawing.Point(108, 84)
        Me.txtWarehouseRef.MaxLength = 8
        Me.txtWarehouseRef.Name = "txtWarehouseRef"
        Me.txtWarehouseRef.Size = New System.Drawing.Size(104, 20)
        Me.txtWarehouseRef.TabIndex = 1
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Location = New System.Drawing.Point(108, 57)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(104, 20)
        Me.txtSupplierName.TabIndex = 18
        Me.txtSupplierName.TabStop = False
        '
        'txtSupplierRef
        '
        Me.txtSupplierRef.Location = New System.Drawing.Point(108, 37)
        Me.txtSupplierRef.MaxLength = 8
        Me.txtSupplierRef.Name = "txtSupplierRef"
        Me.txtSupplierRef.Size = New System.Drawing.Size(104, 20)
        Me.txtSupplierRef.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.Location = New System.Drawing.Point(247, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Delivery Date:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(247, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Order No:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(270, 286)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Total Garments:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(318, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Total:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(287, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Commission:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(262, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Delivery Charges:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(325, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Net:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(345, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 20)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Order Totals:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(247, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Suppliers Invoice No:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(247, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Shipper Invoice No:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Our Ref:"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(247, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Shipper:"
        '
        'txtBoxes
        '
        Me.txtBoxes.Location = New System.Drawing.Point(108, 252)
        Me.txtBoxes.Name = "txtBoxes"
        Me.txtBoxes.Size = New System.Drawing.Size(100, 20)
        Me.txtBoxes.TabIndex = 5
        Me.txtBoxes.Visible = False
        '
        'txtHangers
        '
        Me.txtHangers.Location = New System.Drawing.Point(108, 272)
        Me.txtHangers.Name = "txtHangers"
        Me.txtHangers.Size = New System.Drawing.Size(100, 20)
        Me.txtHangers.TabIndex = 6
        Me.txtHangers.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(31, 252)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Qty Boxes"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 272)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Qty Hangers"
        Me.Label12.Visible = False
        '
        'DeliveriesIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 352)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtHangers)
        Me.Controls.Add(Me.txtBoxes)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.txtWarehouseName)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtQtyGarments)
        Me.Controls.Add(Me.cmdFindWarehouse)
        Me.Controls.Add(Me.cmdFindStockCode)
        Me.Controls.Add(Me.DGVStock)
        Me.Controls.Add(Me.DGVSupplier)
        Me.Controls.Add(Me.cmdFindSupplier)
        Me.Controls.Add(Me.txtNetCost)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.DGVWarehouse)
        Me.Controls.Add(Me.txtOurRef)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.txtSupplierInv)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.txtShipper)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtShipperInv)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtOrderID)
        Me.Controls.Add(Me.txtTotalGarments)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtCommission)
        Me.Controls.Add(Me.txtDelCharges)
        Me.Controls.Add(Me.txtTotalNet)
        Me.Controls.Add(Me.txtWarehouseRef)
        Me.Controls.Add(Me.txtSupplierName)
        Me.Controls.Add(Me.txtSupplierRef)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DeliveriesIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DeliveriesIn"
        CType(Me.DGVStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVWarehouse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents txtWarehouseName As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtQtyGarments As System.Windows.Forms.TextBox
    Friend WithEvents cmdFindWarehouse As System.Windows.Forms.Button
    Friend WithEvents cmdFindStockCode As System.Windows.Forms.Button
    Friend WithEvents DGVStock As System.Windows.Forms.DataGridView
    Friend WithEvents DGVSupplier As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFindSupplier As System.Windows.Forms.Button
    Friend WithEvents txtNetCost As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DGVWarehouse As System.Windows.Forms.DataGridView
    Friend WithEvents txtOurRef As System.Windows.Forms.TextBox
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierInv As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents txtShipper As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtShipperInv As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtOrderID As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalGarments As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtCommission As System.Windows.Forms.TextBox
    Friend WithEvents txtDelCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNet As System.Windows.Forms.TextBox
    Friend WithEvents txtWarehouseRef As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierRef As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBoxes As TextBox
    Friend WithEvents txtHangers As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
End Class
