Imports System.Data.OleDb

Public Class frmFaculty

    Dim faculty As Faculty

    'close current form and take back to Home
    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Me.Close()
        frmHome.Show()
    End Sub


    'clear all the textboxes
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
    End Sub



    'add and edit faculty 
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim jag, fName, lName, dep As String
        Dim fac As New Faculty()
        jag = (txtJagNumber.Text)
        fName = txtFirstName.Text
        lName = txtLastName.Text
        dep = txtDepartment.Text

        'if faculty exists
        If fac.IsFacExist(jag) Then
            'call UpdateFaculty method
            Try
                fac.Updatefaculty(jag, fName, lName, dep)
                MessageBox.Show("Faculty updated successfully.")
                clearFields()
            Catch ex As Exception
                MessageBox.Show("please make sure all the fields are correct!")
            End Try
        Else
            'otherwise call AddFaculty method
            Try
                fac.Addfaculty(jag, fName, lName, dep)
                MessageBox.Show("Faculty added successfully.")
                clearFields()
            Catch ex As Exception
                MessageBox.Show("please make sure all the fields are correct!")
            End Try
        End If
       

    End Sub


    'valudate user input
    Function ValidateOK() As Boolean
        If (txtJagNumber.Text = "") Then
            MessageBox.Show("Please enter Jag Number.")
            Return False
        ElseIf (Not (IsNumeric(txtJagNumber.Text))) Then
            MessageBox.Show("Excludes" & " J," & " only enter numeric value!")
            Return False
        ElseIf (txtFirstName.Text = "") Then
            MessageBox.Show("Please enter First Name.")
            Return False
        ElseIf (txtLastName.Text = "") Then
            MessageBox.Show("Please enter Last Name.")
            Return False
        ElseIf (txtDepartment.Text = "") Then
            MessageBox.Show("Please enter Department code.")
            Return False
        Else
            Return True
        End If

        Return True
    End Function


    'fill the textboxes for faculty if the faculty exists
    Private Sub GetFaculty(ByVal jNum As String)
        txtFirstName.Clear()
        txtDepartment.Clear()
        txtLastName.Clear()

        Dim dept As New Department
        Dim adapter As OleDbDataAdapter
        Dim ds As DataSet = New DataSet
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            myconnection.Open()
            Dim sqlQry As String = "SELECT [FirstName], [LastName], [DepId] FROM [Faculty] WHERE [JNumber] = """ & jNum & """"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                adapter = New OleDbDataAdapter(sqlQry, myconnection)
                adapter.Fill(ds, "faculty")
                'check if the query returned is not null
                If ds.Tables("faculty").Rows.Count > 0 Then
                    Dim row = ds.Tables("faculty").Rows(0)
                    txtLastName.Text = row.Field(Of String)("LastName")
                    txtFirstName.Text = row.Field(Of String)("FirstName")
                    Dim depId As Integer = row.Field(Of Integer)("DepId")
                    txtDepartment.Text = dept.getDeptCode(depId).ToString()
                Else
                    Return
                End If
                adapter.Dispose()
            End Using
        End Using

    End Sub

    'when the jag number textBox loose focus, fill the textBoxes if faculty exists
    Private Sub txtJagNumber_Leave(sender As Object, e As EventArgs) Handles txtJagNumber.Leave
        If Not (txtJagNumber.Text = "") Then
            Dim jag As String
            jag = (txtJagNumber.Text)
            GetFaculty(jag)
        End If
    End Sub


    'clear all the textboxes
    Private Sub clearFields()
        txtJagNumber.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtDepartment.Clear()
        txtJagNumber.Focus()
    End Sub
End Class