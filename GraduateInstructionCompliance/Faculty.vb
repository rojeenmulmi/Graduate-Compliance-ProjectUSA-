Imports System.Data.OleDb

Public Class Faculty

    'private variables
    Private m_jagNumber As String
    Private m_firstName As String
    Private m_lastName As String
    Private m_deptId As Integer

    'public property
    Public Property JagNumber() As String
        Get
            Return m_jagNumber
        End Get
        Set(ByVal value As String)
            m_jagNumber = value
        End Set
    End Property

    Public Property Firstname() As String
        Get
            Return m_firstName
        End Get
        Set(ByVal value As String)
            m_firstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return m_lastName
        End Get
        Set(ByVal value As String)
            m_lastName = value
        End Set
    End Property

    Public Property DepartmentId() As Integer
        Get
            Return m_deptId
        End Get
        Set(ByVal value As Integer)
            m_deptId = value
        End Set
    End Property

    'default constructor
    Public Sub New()
        m_jagNumber = ""
        m_firstName = ""
        m_lastName = ""
        m_deptId = 0
    End Sub

    'overloaded constructor
    Public Sub New(ByVal p_jagNumber As String, ByVal p_firstName As String, ByVal p_lastName As String, ByVal p_deptID As Integer)
        m_jagNumber = p_jagNumber
        m_firstName = p_firstName
        m_lastName = p_lastName
        m_deptId = p_deptID
    End Sub


    'overrided toString method
    Public Overrides Function ToString() As String
        Return (m_jagNumber & "-" & m_firstName & "-" & m_lastName & "-" & m_deptId)
    End Function

    'insert into Faculty table
    Public Sub Addfaculty(ByVal jNum As String, ByVal fName As String, ByVal lName As String, ByVal depCode As String)
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            Dim department As New Department
            myconnection.Open()
            Dim sqlQry As String = "INSERT INTO [Faculty] ([JNumber], [FirstName], [LastName], [DepId]) VALUES (@jnumber, @fname,@lname, @depId)"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                cmd.Parameters.AddWithValue("@jnumber", jNum)
                cmd.Parameters.AddWithValue("@fname", fName)
                cmd.Parameters.AddWithValue("@lname", lName)
                cmd.Parameters.AddWithValue("@depId", department.getDeptId(depCode))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    'Update Faculty table
    Public Sub Updatefaculty(ByVal jNum As String, ByVal fName As String, ByVal lName As String, ByVal depCode As String)
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            Dim department As New Department
            myconnection.Open()
            Dim sqlQry As String = "UPDATE [Faculty] SET [JNumber] = """ & jNum & """, [FirstName] = """ & fName & """ , [LastName] = """ & lName & """, [DepId] = @depId WHERE [JNumber] = """ & jNum & """"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                cmd.Parameters.AddWithValue("@depId", department.getDeptId(depCode))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'Check if faculty Exists
    Public Function IsFacExist(ByVal jNum As String) As Boolean
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            Dim department As New Department
            myconnection.Open()
            Dim sqlQry As String = "SELECT [JNumber] FROM [Faculty] WHERE [JNumber] = """ & jNum & """"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                Dim dr = cmd.ExecuteReader
                If dr.HasRows Then
                    Return True
                Else
                    Return False
                End If

            End Using
        End Using
    End Function

End Class
