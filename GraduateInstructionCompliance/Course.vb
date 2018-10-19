Imports System.Data.OleDb

Public Class Course
    'private variables
    Private m_jnumber As String
    Private m_course As String
    Private m_term As Integer
    Private m_depId As String
    Private m_isAssigned As Boolean

    'public property
    Public Property IsAssigned() As Boolean
        Get
            Return m_isAssigned
        End Get
        Set(ByVal value As Boolean)
            m_isAssigned = value
        End Set
    End Property

    Public Property DepId() As String
        Get
            Return m_depId
        End Get
        Set(ByVal value As String)
            m_depId = value
        End Set
    End Property

    Public Property Term() As Integer
        Get
            Return m_term
        End Get
        Set(ByVal value As Integer)
            m_term = value
        End Set
    End Property

    Public Property CourseId As String
        Get
            Return m_course
        End Get
        Set(ByVal value As String)
            m_course = value
        End Set
    End Property

    Public Property Jnumber() As String
        Get
            Return m_jnumber
        End Get
        Set(ByVal value As String)
            m_jnumber = value
        End Set
    End Property

    'default cosntructor
    Public Sub New()
        m_jnumber = ""
        m_course = ""
        m_term = 0
        m_depId = ""
        m_isAssigned = True
    End Sub

    'upload excel file into AssignedCourse table to database
    Public Sub uploadAssignedCourse()
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            Dim department As New Department
            myconnection.Open()
            Dim sqlQry As String = "INSERT INTO [AssignedCourse] ([JNumber], [Course], [Term], [DepId]) VALUES (@jnumber, @course,@term, @depId)"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                cmd.Parameters.AddWithValue("@jnumber", m_jnumber)
                cmd.Parameters.AddWithValue("@courseId", m_course)
                cmd.Parameters.AddWithValue("@term", CInt(m_term))
                cmd.Parameters.AddWithValue("@depId", department.getDeptId(m_depId))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    'insert course in CourseList table
    Public Sub AddCourse(ByVal course As String, ByVal dep As String, ByVal courseTitle As String)
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            Dim department As New Department
            myconnection.Open()
            Dim sqlQry As String = "INSERT INTO [CourseList] ([Course], [DepCode], [CourseTitle]) VALUES (@course, @depCode,@courseTitle)"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                cmd.Parameters.AddWithValue("@course", course)
                cmd.Parameters.AddWithValue("@depCode", dep)
                cmd.Parameters.AddWithValue("@courseTitle", courseTitle)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'get CourseId from COURSE table for the COURSE
    'Public Function getCourseId() As Integer
    '    Dim course_Id As Integer
    '    Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
    '        myconnection.Open()
    '        Dim sqlQry As String = "SELECT [CourseId] FROM [Course] WHERE [CourseName] = """ & m_course & """"
    '        Using cmd As New OleDbCommand(sqlQry, myconnection)
    '            course_Id = CInt(cmd.ExecuteScalar())
    '        End Using
    '    End Using
    '    Return (course_Id)
    'End Function


    'generate exception report
    'Function GenerateCourseExceptionReport() As DataTable

    '    Dim jagNumList As New List(Of Course)
    '    Dim ds As DataSet = New DataSet
    '    Dim adapter As OleDbDataAdapter

    '    jagNumList = getJnumberAssigned()
    '    'Dim ExceptionReortList As DataRow
    '    Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
    '        myconnection.Open()
    '        'this query needs to be fixed
    '        Dim exceptionQry As String = "SELECT AssignedCourse.JNumber, AssignedCourse.Course, AssignedCourse.Term, AssignedCourse.isAssigned FROM AssignedCourse WHERE (((AssignedCourse.Course) NOT IN (select AssignedCourse.Course FROM AssignedCourse INNER JOIN ApprovedCourse ON AssignedCourse.Course=ApprovedCourse.Course)) AND (AssignedCourse.JNumber = ""00002270""))"
    '        adapter = New OleDbDataAdapter(exceptionQry, myconnection)
    '        adapter.Fill(ds)
    '        'adapter.SelectCommand = New OleDb.OleDbCommand(exceptionQry, myconnection)
    '        MessageBox.Show(adapter.ToString())
    '        adapter.Dispose()
    '        frmCourseException.dgvFacExceptionReport.DataSource = ds.Tables(0)
    '        'frmCourseException.dgvExceptionReport.Update()
    '        myconnection.Close()
    '        'For Each j As AssignedCourse In jagNumList
    '        'Using cmd As New OleDbCommand(exceptionQry, myconnection)
    '        'cmd.Parameters.AddWithValue("@jagNum", j)
    '        'MessageBox.Show(CStr(cmd.ExecuteScalar()))
    '        'ExceptionReortList = CType(cmd.ExecuteScalar(), DataRow)
    '        'End Using
    '        'Next
    '    End Using

    'End Function

    'select unique JNumber from AssignedCourse table
    Function getJnumberAssigned() As List(Of Course)
        Dim jagNumber As String = ""
        Dim listOfJagNumber As New List(Of Course)

        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            'myconnection.Open()
            Dim jagQry As String = "SELECT DISTINCT [JNumber] FROM [AssignedCourse]"
            Using cmd As New OleDbCommand(jagQry, myconnection)
                myconnection.Open()

                Dim dr = cmd.ExecuteReader()

                While dr.Read()
                    'listOfJagNumber.Add(CType(dr("JNumber"), AssignedCourse))
                    jagNumber = CStr(dr("JNumber").ToString())
                    listOfJagNumber.Add(New Course() With {.Jnumber = jagNumber})

                End While

                'jagNumber = CStr(cmd.ExecuteScalar())
            End Using
        End Using
        'listOfJagNumber.Add(New AssignedCourse() With {.Jnumber = jagNumber})
        Return listOfJagNumber

    End Function


End Class
