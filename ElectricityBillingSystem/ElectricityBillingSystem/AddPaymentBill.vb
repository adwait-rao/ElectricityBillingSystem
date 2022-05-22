Imports System.Data.OleDb

Public Class AddPaymentBill
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\adwaitrao\Documents\GitHub\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb")
    Dim da As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
            
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()
            If TextBox1.Text = Nothing Then
                Throw Exception("No Units Entered!")
            Else
                Dim TotalAmnt As Double
                Dim meterno As Integer = Val(ComboBox1.SelectedItem.ToString)
                Select Case ComboBox2.SelectedIndex
                    Case 0
                        TotalAmnt = Val(TextBox1.Text) * 3.46
                    Case 1
                        TotalAmnt = Val(TextBox1.Text) * 7.43
                    Case 2
                        TotalAmnt = Val(TextBox1.Text) * 10.32
                    Case 3
                        TotalAmnt = Val(TextBox1.Text) * 11.71
                End Select
                cmd = New OleDbCommand("Insert into bills(MeterNumber, b_month, units, amount) values (" & meterno & ",'" & ComboBox3.SelectedText & "'," & Val(TextBox1.Text) & ", Round(" & TotalAmnt & ", 0))", conn)
                cmd.ExecuteNonQuery()
                MsgBox("Bill Saved Successfully!", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        Finally
            conn.Close()
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