Public Class clsShopAdjustment
    Private objForm As New ShopAdjustments

    Public Sub DoInitForm()
        objForm.cboType.Items.Clear()
        objForm.cboType.Items.Add("Gain")
        objForm.cboType.Items.Add("Loss")


    End Sub
End Class
