Imports System.Data.OleDb

Public Class frmCourseException

    Dim assignedCourse As New Course

    'fill the datagridview with course exception for one faculty
    Private Sub frmFCourseException_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'close thi form and retun back to home
    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Me.Close()
        frmHome.Show()
    End Sub

    'clear all the input field
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtJagNumber.Clear()

    End Sub


    'search for unApprovedCourse for given faculty
    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click

        CourseExceptionForFac()
    End Sub

    'loop through "Approve" column in datagridview and checking the checkbox add course to ApprovedCourse table in database
    Private Sub dgvFacExceptionReport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacExceptionReport.CellContentClick
        Dim jNum, courseId As String
        Dim term As Integer
        jNum = CStr(dgvFacExceptionReport.Rows(e.RowIndex).Cells("JNumber").Value())
        courseId = CStr(dgvFacExceptionReport.Rows(e.RowIndex).Cells("Course").Value())
        term = CInt(CStr(dgvFacExceptionReport.Rows(e.RowIndex).Cells("Term").Value()))
        'check if the right column name
        If dgvFacExceptionReport.Columns(e.ColumnIndex).Name = "Approve" Then
            'check that checkbox is not checked
            If CType(dgvFacExceptionReport.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Boolean) = False Then
                'insert new record into ApprovedCourse table database
                Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
                    myconnection.Open()
                    Dim sqlQry As String = "INSERT INTO [ApprovedCourse] ([JNumber], [Course], [Term]) VALUES (@jnumber, @course,@term)"
                    Using cmd As New OleDbCommand(sqlQry, myconnection)
                        cmd.Parameters.AddWithValue("@jnumber", jNum)
                        cmd.Parameters.AddWithValue("@courseId", courseId)
                        cmd.Parameters.AddWithValue("@term", CInt(term))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End If
            'update the datagridview
            CourseExceptionForFac()
        Else
            Return
        End If

    End Sub

    'check for textbox inputs
    Function DataOK() As Boolean
        If (txtJagNumber.Text = "") Then
            MessageBox.Show("Please enter Jag Number.")
            Return False
        ElseIf (Not (IsNumeric(txtJagNumber.Text))) Then
            MessageBox.Show("Excludes" & " J," & " only enter numeric value!")
            Return False
        Else
            Return True
        End If

        Return True
    End Function


    'generate course exception for given jagNumber
    Public Sub CourseExceptionForFac()
        If DataOK() Then
            'grab textbox input
            Dim jNumber As String
            jNumber = txtJagNumber.Text

            'get unApprovedCourse by jag number
            If Not (jNumber = "") Then
                Dim jNum As String = "J" + jNumber
                Dim ds As DataSet = New DataSet
                Dim adapter As OleDbDataAdapter
                Try
                    Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
                        myconnection.Open()
                        Dim exceptionQry As String = "SELECT AssignedCourse.JNumber, AssignedCourse.Course, AssignedCourse.Term FROM AssignedCourse WHERE (((AssignedCourse.Course) NOT IN (select AssignedCourse.Course FROM AssignedCourse INNER JOIN ApprovedCourse ON AssignedCourse.Course=ApprovedCourse.Course)) AND (AssignedCourse.JNumber = '" & jNum & " ' ))"
                        adapter = New OleDbDataAdapter(exceptionQry, myconnection)
                        adapter.Fill(ds)
                        adapter.Dispose()
                        'add a new column "Approve" at end of the table
                        ds.Tables(0).Columns.Add("Approve", GetType(Boolean), CStr(False))
                        'fill datagridview with the query result
                        dgvFacExceptionReport.DataSource = ds.Tables(0)
                        dgvFacExceptionReport.RowHeadersVisible = False
                        dgvFacExceptionReport.AllowUserToAddRows = False
                        dgvFacExceptionReport.Visible = True
                        myconnection.Close()

                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If

        End If
    End Sub





    'genertate exception report for all the faculty at one time
    'Function generateException() As DataSet
    '    Dim jagNumList As New List(Of Course)
    '    Dim ds As DataSet = New DataSet
    '    Dim adapter As OleDbDataAdapter
    '    Dim jagNumber As String
    '    jagNumList = assignedCourse.getJnumberAssigned()

    '    Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
    '        myconnection.Open()
    '        Dim exceptionQry As String = "SELECT AssignedCourse.JNumber, AssignedCourse.Course, AssignedCourse.Term, AssignedCourse.isAssigned FROM AssignedCourse WHERE (((AssignedCourse.Course) NOT IN (select AssignedCourse.Course FROM AssignedCourse INNER JOIN ApprovedCourse ON AssignedCourse.Course=ApprovedCourse.Course)) AND (AssignedCourse.JNumber = ""00002270""))"
    '        adapter = New OleDbDataAdapter(exceptionQry, myconnection)
    '        adapter.Fill(ds)
    '        'adapter.SelectCommand = New OleDb.OleDbCommand(exceptionQry, myconnection)
    '        adapter.Dispose()
    '        dgvFacExceptionReport.DataSource = ds.Tables(0)
    '        dgvFacExceptionReport.Visible = True

    '        myconnection.Close()

    '        'For Each j In jagNumList
    '        '    jagNumber = j.Jnumber
    '        '    Dim exceptionQry As String = "SELECT AssignedCourse.JNumber, AssignedCourse.Course, AssignedCourse.Term, AssignedCourse.isAssigned FROM AssignedCourse WHERE (((AssignedCourse.Course) NOT IN (select AssignedCourse.Course FROM AssignedCourse INNER JOIN ApprovedCourse ON AssignedCourse.Course=ApprovedCourse.Course)) AND (AssignedCourse.JNumber = ' " & jagNumber & " '))"
    '        '    Using cmd As New OleDbCommand(exceptionQry, myconnection)
    '        '        'cmd.Parameters.Add("@jagNum", OleDbType.VarChar, 50).Value = j
    '        '        adapter = New OleDbDataAdapter(exceptionQry, myconnection)
    '        '        adapter.Fill(ds)
    '        '        'adapter.SelectCommand = New OleDb.OleDbCommand(exceptionQry, myconnection)
    '        '        adapter.Dispose()
    '        '        dgvFacExceptionReport.DataSource = ds.Tables(0)

    '        '    End Using
    '        'Next
    '        ''adapter.Dispose()
    '        ''dgvFacExceptionReport.DataSource = ds.Tables()
    '        ''adapter.Dispose()

    '        'myconnection.Close()
    '        'dgvFacExceptionReport.Visible = True

    '    End Using

    '    'dgvFacExceptionReport.DataSource = assignedCourse.GenerateCourseExceptionReport()
    '    'dgvFacExceptionReport.Visible = True
    'End Function


End Class