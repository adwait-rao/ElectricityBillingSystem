Imports ElectricityBillingSystem.login
Public Class Dashboard
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        login.Show()
    End Sub
End Class