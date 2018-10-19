Imports System.Data.OleDb

Public Class Department

    'private variables
    Private m_depID As Integer
    Private m_collegeId As Integer
    Private m_depCode As String
    Private m_depName As String
    Private m_orgn As String


    'public property
    Public Property Orgn() As String
        Get
            Return m_orgn
        End Get
        Set(ByVal value As String)
            m_orgn = value
        End Set
    End Property

    Public Property DeptName() As String
        Get
            Return m_depName
        End Get
        Set(ByVal value As String)
            m_depName = value
        End Set
    End Property

    Public Property DeptCode() As String
        Get
            Return m_depCode
        End Get
        Set(ByVal value As String)
            m_depCode = value
        End Set
    End Property

    Public Property CollegeId() As Integer
        Get
            Return m_collegeId
        End Get
        Set(ByVal value As Integer)
            m_collegeId = value
        End Set
    End Property

    Public Property DeptId() As Integer
        Get
            Return m_depID
        End Get
        Set(ByVal value As Integer)
            m_depID = value
        End Set
    End Property

    'default constructor
    Public Sub New()
        m_depID = 0
        m_collegeId = 0
        m_depCode = ""
        m_depName = ""
        m_orgn = ""
    End Sub

    'get DepId from DEPARTMENT table for the DepCode
    Public Function getDeptId(ByVal dCode As String) As Integer
        Dim dep_Id As Integer
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            myconnection.Open()
            Dim sqlQry As String = "SELECT [DepId] FROM [Department] WHERE [DepCode] = """ & depCode((dCode)) & """"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                dep_Id = CInt(cmd.ExecuteScalar())
            End Using
        End Using
        Return (dep_Id)
    End Function

    'get DepCode from Department table for the DepId
    Public Function getDeptCode(ByVal depId As Integer) As String
        Dim dep_code As String
        Using myconnection As System.Data.OleDb.OleDbConnection = frmHome.CreateConnection()
            myconnection.Open()
            Dim sqlQry As String = "SELECT [DepCode] FROM [Department] WHERE [DepId] = @DepId"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                cmd.Parameters.AddWithValue("@DepId", depId)
                dep_code = CStr((cmd.ExecuteScalar()))
            End Using
        End Using
        Return (dep_code)
    End Function


    'concatenate DepCode to run getDeptID() function
    Public Function depCode(ByVal dCode As String) As String
        If dCode = "MA" Then
            Return ("MA/ST")
        ElseIf dCode = "SY" Then
            Return ("SY/AN")
        ElseIf dCode = "EC" Then
            Return ("EC/FN")
        ElseIf dCode = "MKT" Then
            Return ("MKT/QN")
        ElseIf dCode = "MA" Then
            Return ("MA/DS")
        ElseIf dCode = "CHE" Then
            Return ("CHE/BIO")
        ElseIf dCode = "ART" Then
            Return ("VART")
        Else
            Return dCode
        End If
    End Function


End Class
