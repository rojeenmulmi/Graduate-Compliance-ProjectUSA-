Public Class frmCourse

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Me.Close()
        frmHome.Show()
    End Sub

    'clear textBoxes and put focus on course textBox
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearField()
    End Sub

    'add course to CourseList table in database
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim course As New Course()
        If DataOK() Then
            course.AddCourse(txtCourse.Text, txtDept.Text, txtCourseTitle.Text)
            MessageBox.Show("Course added successfully.")
            clearField()
        End If

    End Sub

    'validate user input
    Private Function DataOK() As Boolean
        If (txtCourse.Text = "") Then
            MessageBox.Show("please enter a course.")
            Return False
        ElseIf (txtCourseTitle.Text = "") Then
            MessageBox.Show("please enter a course title.")
            Return False
        ElseIf (txtDept.Text = "") Then
            MessageBox.Show("please enter a department code.")
            Return False
        Else
            Return True
        End If
    End Function

    'clear text boxes
    Private Sub clearField()
        txtCourse.Clear()
        txtCourseTitle.Clear()
        txtDept.Clear()
        txtCourse.Focus()
    End Sub
End Class