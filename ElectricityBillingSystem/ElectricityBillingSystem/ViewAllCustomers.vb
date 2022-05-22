Imports System.Data.OleDb
Public Class ViewAllCustomers
    'Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\proj\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\adwaitrao\Documents\GitHub\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb")
    Dim da As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
    Dim min As Integer = 0
    Private Sub ViewAllCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.Open()

        cmd = New OleDbCommand("select * from Customer_Info", conn)
        da = New OleDbDataAdapter(cmd)
        da.Fill(ds, "Customer_Info")
        DataGridView1.DataSource = ds.Tables("Customer_Info")
    End Sub
    Public Sub Navigate(ByVal r As Integer)
        Try

      
        TextBox1.Text = ds.Tables("Customer_Info").Rows(r).Item(0)
        TextBox2.Text = ds.Tables("Customer_Info").Rows(r).Item(1)
        TextBox3.Text = ds.Tables("Customer_Info").Rows(r).Item(2)
        TextBox4.Text = ds.Tables("Customer_Info").Rows(r).Item(3)
        TextBox5.Text = ds.Tables("Customer_Info").Rows(r).Item(4)
            TextBox6.Text = ds.Tables("Customer_Info").Rows(r).Item(5)

        Catch ex As Exception
            MsgBox("This Is Last Record")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If min = 0 Then
            MsgBox("This Is First Record")
        Else
            min = 0
            Navigate(min)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        min += 1
        Navigate(min)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If min = 0 Then
            MsgBox("This Is First Record")
        Else
            min -= 1
            Navigate(min)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dashboard.Show()

    End Sub
End Class