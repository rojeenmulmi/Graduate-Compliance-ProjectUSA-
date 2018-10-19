'Graduate Instruction Compliance
'Programmed by: Fav4
'Team members: Madhusudan Chaudhary, Chris Patrick, Rojen Mulmi, Suraj Kanu
'CIS497 Spring 2018 


Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Imports System.Text

Public Class frmHome

    'return connectionstring for ms-access database
    Public Function CreateConnection() As OleDb.OleDbConnection
        Return New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Madhusudan\Documents\GraduateInstructionCompliance_Final.accdb")
    End Function

    Private Sub lblUploadCourseAssignment_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblUploadCourseAssignment.LinkClicked
        'delete the previus course schedule from AssignedCourse table
        Using myconnection As System.Data.OleDb.OleDbConnection = CreateConnection()
            myconnection.Open()
            Dim sqlQry As String = "DELETE * FROM AssignedCourse"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                cmd.ExecuteNonQuery()
            End Using
            myconnection.Close()
        End Using

        ' Create new Application.

        Dim excel As Application = New Application
        OpenFileDialog1.ShowDialog()
        Dim filename As String = OpenFileDialog1.FileName

        ' Open Excel spreadsheet.
        Dim w As Workbook = excel.Workbooks.Open(filename)

        ' Loop over all sheets.
        For i As Integer = 1 To w.Sheets.Count

            ' Get sheet.
            Dim sheet As Worksheet = CType(w.Sheets(i), Worksheet)

            ' Get range.
            Dim r As Range = sheet.UsedRange

            ' Load all cells into 2d array.
            Dim array(,) As Object = CType(r.Value(XlRangeValueDataType.xlRangeValueDefault), Object(,))
            Dim line As String = CStr(array(1, 2))
            'Console.WriteLine(array(1, 2))

            ' Scan the cells.
            If array IsNot Nothing Then
                'Console.WriteLine("Length: {0}", array.Length)

                ' Get bounds of the array.
                'number of records
                Dim bound0 As Integer = array.GetUpperBound(0)
                'number of fields
                Dim bound1 As Integer = array.GetUpperBound(1)

                'Console.WriteLine("Dimension 0: {0}", bound0)
                'Console.WriteLine("Dimension 1: {0}", bound1)

                Dim AssignCourse As New Course

                ' Loop over all elements.
                For j As Integer = 2 To bound0
                    'For x As Integer = 1 To bound1
                    'Dim s1 As String = CStr(array(j, x))
                    'Console.WriteLine(s1)
                    'Console.WriteLine(" "c)
                    'Next

                    'get the terms
                    'Dim term As String = CStr(array(j, 2))
                    AssignCourse.Term = CInt((array(j, 2)))

                    'get the department
                    AssignCourse.DepId = CStr(array(j, 5))

                    'get the course
                    AssignCourse.CourseId = CStr(array(j, 6))

                    'get the jag
                    AssignCourse.Jnumber = CStr(array(j, 15))

                    If (AssignCourse.Jnumber IsNot Nothing) Then
                        AssignCourse.uploadAssignedCourse()

                    End If

                Next
            End If
        Next

        'Close.
        w.Close()

        MessageBox.Show("Course Assignment uploaded successfully")
    End Sub

    'open frmCourseException form
    Private Sub lblGenerateReport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGenerateReport.LinkClicked
        frmCourseException.Show()
    End Sub

    'open frmFaculty form
    Private Sub lblArchiveFaculty_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblArchiveFaculty.LinkClicked
        frmFaculty.Show()
    End Sub

    'open frmCourse form
    Private Sub lblArchiveCourse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblArchiveCourse.LinkClicked
        frmCourse.Show()
    End Sub

    'close the application
    Private Sub btnClose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnClose.LinkClicked
        frmCourse.Close()
        frmCourseException.Close()
        frmFaculty.Close()
        Me.Close()
    End Sub
End Class
