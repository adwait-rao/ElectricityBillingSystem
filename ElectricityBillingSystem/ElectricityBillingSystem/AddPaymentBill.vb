Imports System.Data.OleDb

Public Class AddPaymentBill
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\gad proj\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb")
    Dim da As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
    Dim amount As Double
    Dim units As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
<<<<<<< HEAD
        'Try
        If TextBox1.Text = Nothing Then
            Throw New Exception("No Units Entered!")
        Else
            Dim s As String = ComboBox2.SelectedItem
            Dim a3 As String = ComboBox3.SelectedItem
            Dim a1 As String = ComboBox1.SelectedItem.ToString
            MsgBox(s)
            Select Case s
                Case "Farmer"
                    conn.Open()
                    units = Val(TextBox1.Text)
                    amount = units * 1.5
                    Dim abc As String = amount.ToString
                    Dim bc As String = units.ToString
                    Dim a2 As String = s
                    cmd = New OleDbCommand("insert into bills (MeterNumber,b_month,ConsumerType,unitsConsumed,amountpayable) values('" & a1 & "','" & a3 & "', ' " & a2 & " ','" & bc & "','" & abc & "')", conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Inserted Into Bills Tables")

            End Select

        End If

        'Catch ex As Exception
        'MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        ' End Try
=======
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
>>>>>>> 024b6c21912c9b9e06c0fb3e77809de54d43d121
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
        ComboBox1.ValueMember = "MeterNumber"
    End Sub
End Class