﻿Imports System.Data.OleDb

Public Class AddPaymentBill
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\adwaitrao\Documents\GitHub\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb")
    Dim da As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
    Dim amount As Double
    Dim units As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = Nothing Then
                Throw New Exception("No Units Entered!")
            Else
                Dim s As String = ComboBox2.SelectedItem
                Dim a3 As String = ComboBox3.SelectedItem
                Dim a1 As String = ComboBox1.SelectedItem
                'Dim a As String = a1.ToString
                Select Case s
                    Case "Farmer"
                        units = Val(TextBox1.Text)
                        amount = units * 1.5
                        Dim abc As String = amount.ToString
                        Dim bc As String = units.ToString
                        Dim a2 As String = s
                        cmd = New OleDbCommand("insert into bills (MeterNumber,b_month,ConsumerType,unitsConsumed,amountpayable,unitrate) values('" & a1 & "','" & a3 & "', ' " & a2 & " ','" & bc & "','" & abc & "','" & 1.5 & "')", conn)
                        cmd.ExecuteNonQuery()
                        MsgBox("Data Inserted Into Bills Tables")

                    Case "Industries"
                        units = Val(TextBox1.Text)
                        amount = units * 3
                        Dim abc As String = amount.ToString
                        Dim bc As String = units.ToString
                        Dim a2 As String = s
                        cmd = New OleDbCommand("insert into bills (MeterNumber,b_month,ConsumerType,unitsConsumed,amountpayable,unitrate) values('" & a1 & "','" & a3 & "', ' " & a2 & " ','" & bc & "','" & abc & "','" & 3 & "')", conn)
                        cmd.ExecuteNonQuery()
                        MsgBox("Data Inserted Into Bills Tables")

                    Case "Commercial"
                        units = Val(TextBox1.Text)
                        amount = units * 4
                        Dim abc As String = amount.ToString
                        Dim bc As String = units.ToString
                        Dim a2 As String = s
                        cmd = New OleDbCommand("insert into bills (MeterNumber,b_month,ConsumerType,unitsConsumed,amountpayable,unitrate) values('" & a1 & "','" & a3 & "', ' " & a2 & " ','" & bc & "','" & abc & "','" & 4 & "')", conn)
                        cmd.ExecuteNonQuery()
                        MsgBox("Data Inserted Into Bills Tables")

                    Case "Domestic"
                        units = Val(TextBox1.Text)
                        amount = units * 5
                        Dim abc As String = amount.ToString
                        Dim bc As String = units.ToString
                        Dim a2 As String = s
                        cmd = New OleDbCommand("insert into bills (MeterNumber,b_month,ConsumerType,unitsConsumed,amountpayable,unitrate) values('" & a1 & "','" & a3 & "', ' " & a2 & " ','" & bc & "','" & abc & "','" & 5 & "')", conn)
                        cmd.ExecuteNonQuery()
                        MsgBox("Data Inserted Into Bills Tables")

                End Select

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function Exception(p1 As String) As Exception
        Throw New NotImplementedException
    End Function

    Private Sub AddPaymentBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.Open()
        cmd = New OleDbCommand("select * from Customer_Info", conn)
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr("meterNumber").ToString)
        End While
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dashboard.Show()
    End Sub
End Class