Imports System.Data.OleDb
Imports ElectricityBillingSystem.Dashboard

Public Class login
    Dim read As String
    'Dim datafile As String
    'Dim connstring As String
    Dim myconnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\proj\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb")
    Dim adminUsername As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '   read = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\adwaitrao\Documents\GitHub\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb"
        '   datafile = "C:\Users\adwaitrao\Documents\GitHub\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingSystem\ElectricityBillingDB.accdb"
        '   connstring = read & datafile

        'myconnection.ConnectionString = connstring

        Dim cmd As OleDbCommand = New OleDbCommand("select * from AdminUsers Where adminName = '" & TextBox1.Text & "' and passwd = '" & TextBox2.Text & "'", myconnection)
        myconnection.Open()

        Dim dr As OleDbDataReader = cmd.ExecuteReader
        Dim userFound As Boolean = False

        If TextBox1.Text = "" Or TextBox2.Text = "" Then

            If TextBox1.Text = "" Then
                ErrorProvider1.SetError(TextBox1, "Enter Your Username")
            End If
            If TextBox2.Text = "" Then
                ErrorProvider1.SetError(TextBox2, "Enter Your Password")
            End If
        Else
            Try
                While dr.Read
                    userFound = True
                    adminUsername = dr("adminName").ToString
                End While

                If userFound = True Then

                    Dashboard.Label1.Text = adminUsername
                    Dashboard.Show()
                    Me.Hide()
                Else
                    MsgBox("Sorry, No User Found!", MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
            Finally
                myconnection.Close()
            End Try
        End If
    End Sub

End Class
