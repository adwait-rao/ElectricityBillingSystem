Imports System.Data.OleDb
Public Class GenerateBill
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\gad proj\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb")
    Dim da As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet

    Private Sub GenerateBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.Open()
        cmd = New OleDbCommand("select * from Customer_Info", conn)
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr("meterNumber").ToString)
        End While

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New OleDbCommand("select * from Customer_Info where meterNumber = '" & ComboBox1.SelectedItem & "'", conn)
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        While dr.Read
            Label10.Text = dr("customerName").ToString
            Label19.Text = dr("State").ToString
            Label20.Text = dr("City").ToString
            Label21.Text = dr("Address").ToString
            Label22.Text = dr("email").ToString
            Label23.Text = "Outside"
            Label24.Text = "Electric"
            Label26.Text = "30"
        End While
        Try

            cmd = New OleDbCommand("select * from bills where meterNumber = '" & ComboBox1.SelectedItem & "' and  b_month = '" & ComboBox2.SelectedItem & "'", conn)
            dr = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox("No Such Data In Bill Table")
        End Try
        Dim a As Integer
        While dr.Read
            Label25.Text = dr("ConsumerType")
            Label27.Text = "₹" & dr("unitrate")
            Label28.Text = ComboBox2.SelectedItem
            Label29.Text = "9%"
            Label30.Text = "9%"
            Label33.Text = dr("unitsConsumed")
            a = Val(dr("amountpayable"))
        End While
        Dim b As Integer
        b = a * (18 / 100)
        a = a + b
        Label31.Text = "₹ " & a.ToString
    End Sub
End Class