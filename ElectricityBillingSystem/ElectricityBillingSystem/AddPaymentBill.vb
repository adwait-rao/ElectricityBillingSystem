Imports System.Data.OleDb

Public Class AddPaymentBill
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\adwaitrao\Documents\GitHub\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb")
    Dim da As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
            
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = Nothing Then
                Throw Exception("No Units Entered!")
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function Exception(p1 As String) As Exception
        Throw New NotImplementedException
    End Function

    Private Sub AddPaymentBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmd = New OleDbCommand("Select * from Customer_Info", conn)
        da = New OleDbDataAdapter(cmd)
        da.Fill(ds, "Customer_Info")

        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "MeterNumber"
    End Sub
End Class