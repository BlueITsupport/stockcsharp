<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports2
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Deliveries By Stock Code")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock List By Shop")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock List By Stock Code")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Total Stock Valuation")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All Stock Movements")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Warehouse Stock List")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales History")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Analysis")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9})
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSeasons = New System.Windows.Forms.ComboBox()
        Me.cboStockDesc = New System.Windows.Forms.ComboBox()
        Me.cboStockAsc = New System.Windows.Forms.ComboBox()
        Me.cboSupplierDesc = New System.Windows.Forms.ComboBox()
        Me.cboSupplierAsc = New System.Windows.Forms.ComboBox()
        Me.cboShopDesc = New System.Windows.Forms.ComboBox()
        Me.cboShopAsc = New System.Windows.Forms.ComboBox()
        Me.cboWarehouseDes = New System.Windows.Forms.ComboBox()
        Me.cboWarehouseAsc = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.twvReports = New System.Windows.Forms.TreeView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(469, 380)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 49
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(388, 380)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 48
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(307, 380)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton2.Location = New System.Drawing.Point(422, 110)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton2.TabIndex = 46
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Concessions"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(361, 110)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton1.TabIndex = 45
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Shops"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(292, 337)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Season:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(292, 254)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Stock Range:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(292, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Supplier Range:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(513, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = ")"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(352, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "("
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(292, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Shop Range:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(292, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Warehouse Range:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(292, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Date Range:"
        '
        'cboSeasons
        '
        Me.cboSeasons.FormattingEnabled = True
        Me.cboSeasons.Location = New System.Drawing.Point(295, 353)
        Me.cboSeasons.Name = "cboSeasons"
        Me.cboSeasons.Size = New System.Drawing.Size(248, 21)
        Me.cboSeasons.TabIndex = 36
        '
        'cboStockDesc
        '
        Me.cboStockDesc.FormattingEnabled = True
        Me.cboStockDesc.Location = New System.Drawing.Point(295, 297)
        Me.cboStockDesc.Name = "cboStockDesc"
        Me.cboStockDesc.Size = New System.Drawing.Size(248, 21)
        Me.cboStockDesc.TabIndex = 35
        '
        'cboStockAsc
        '
        Me.cboStockAsc.FormattingEnabled = True
        Me.cboStockAsc.Location = New System.Drawing.Point(295, 270)
        Me.cboStockAsc.Name = "cboStockAsc"
        Me.cboStockAsc.Size = New System.Drawing.Size(248, 21)
        Me.cboStockAsc.TabIndex = 34
        '
        'cboSupplierDesc
        '
        Me.cboSupplierDesc.FormattingEnabled = True
        Me.cboSupplierDesc.Location = New System.Drawing.Point(295, 218)
        Me.cboSupplierDesc.Name = "cboSupplierDesc"
        Me.cboSupplierDesc.Size = New System.Drawing.Size(248, 21)
        Me.cboSupplierDesc.TabIndex = 33
        '
        'cboSupplierAsc
        '
        Me.cboSupplierAsc.FormattingEnabled = True
        Me.cboSupplierAsc.Location = New System.Drawing.Point(295, 191)
        Me.cboSupplierAsc.Name = "cboSupplierAsc"
        Me.cboSupplierAsc.Size = New System.Drawing.Size(248, 21)
        Me.cboSupplierAsc.TabIndex = 32
        '
        'cboShopDesc
        '
        Me.cboShopDesc.FormattingEnabled = True
        Me.cboShopDesc.Location = New System.Drawing.Point(422, 130)
        Me.cboShopDesc.Name = "cboShopDesc"
        Me.cboShopDesc.Size = New System.Drawing.Size(121, 21)
        Me.cboShopDesc.TabIndex = 31
        '
        'cboShopAsc
        '
        Me.cboShopAsc.FormattingEnabled = True
        Me.cboShopAsc.Location = New System.Drawing.Point(295, 130)
        Me.cboShopAsc.Name = "cboShopAsc"
        Me.cboShopAsc.Size = New System.Drawing.Size(121, 21)
        Me.cboShopAsc.TabIndex = 30
        '
        'cboWarehouseDes
        '
        Me.cboWarehouseDes.FormattingEnabled = True
        Me.cboWarehouseDes.Location = New System.Drawing.Point(422, 78)
        Me.cboWarehouseDes.Name = "cboWarehouseDes"
        Me.cboWarehouseDes.Size = New System.Drawing.Size(121, 21)
        Me.cboWarehouseDes.TabIndex = 29
        '
        'cboWarehouseAsc
        '
        Me.cboWarehouseAsc.FormattingEnabled = True
        Me.cboWarehouseAsc.Location = New System.Drawing.Point(295, 78)
        Me.cboWarehouseAsc.Name = "cboWarehouseAsc"
        Me.cboWarehouseAsc.Size = New System.Drawing.Size(121, 21)
        Me.cboWarehouseAsc.TabIndex = 28
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(422, 29)
        Me.DateTimePicker2.MaxDate = New Date(2045, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker2.TabIndex = 27
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(295, 29)
        Me.DateTimePicker1.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 26
        '
        'twvReports
        '
        Me.twvReports.FullRowSelect = True
        Me.twvReports.Location = New System.Drawing.Point(12, 12)
        Me.twvReports.Name = "twvReports"
        TreeNode1.Name = "Node6"
        TreeNode1.Text = "Deliveries By Stock Code"
        TreeNode2.Name = "Node7"
        TreeNode2.Text = "Stock List By Shop"
        TreeNode3.Name = "Node8"
        TreeNode3.Text = "Stock List By Stock Code"
        TreeNode4.Name = "Node9"
        TreeNode4.Text = "Total Stock Valuation"
        TreeNode5.Name = "Node10"
        TreeNode5.Text = "All Stock Movements"
        TreeNode6.Name = "Node11"
        TreeNode6.Text = "Warehouse Stock List"
        TreeNode7.Name = "Node1"
        TreeNode7.Text = "Stock"
        TreeNode8.Name = "Node12"
        TreeNode8.Text = "Sales History"
        TreeNode9.Name = "Node13"
        TreeNode9.Text = "Sales Analysis"
        TreeNode10.Name = "Node2"
        TreeNode10.Text = "Sales"
        Me.twvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode10})
        Me.twvReports.Size = New System.Drawing.Size(262, 362)
        Me.twvReports.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(168, 392)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Needs coding"
        '
        'Reports2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 419)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSeasons)
        Me.Controls.Add(Me.cboStockDesc)
        Me.Controls.Add(Me.cboStockAsc)
        Me.Controls.Add(Me.cboSupplierDesc)
        Me.Controls.Add(Me.cboSupplierAsc)
        Me.Controls.Add(Me.cboShopDesc)
        Me.Controls.Add(Me.cboShopAsc)
        Me.Controls.Add(Me.cboWarehouseDes)
        Me.Controls.Add(Me.cboWarehouseAsc)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.twvReports)
        Me.Name = "Reports2"
        Me.Text = "Reports"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSeasons As System.Windows.Forms.ComboBox
    Friend WithEvents cboStockDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cboStockAsc As System.Windows.Forms.ComboBox
    Friend WithEvents cboSupplierDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cboSupplierAsc As System.Windows.Forms.ComboBox
    Friend WithEvents cboShopDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cboShopAsc As System.Windows.Forms.ComboBox
    Friend WithEvents cboWarehouseDes As System.Windows.Forms.ComboBox
    Friend WithEvents cboWarehouseAsc As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents twvReports As System.Windows.Forms.TreeView
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
