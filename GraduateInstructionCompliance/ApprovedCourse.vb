Imports System.Data.OleDb

Public Class ApprovedCourse
    Private m_jnumber As String
    Private m_courseId As String
    Private m_term As String

    Public Property Term() As String
        Get
            Return m_term
        End Get
        Set(ByVal value As String)
            m_term = value
        End Set
    End Property

    Public Property CourseId() As String
        Get
            Return m_courseId
        End Get
        Set(ByVal value As String)
            m_courseId = value
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

End Class
