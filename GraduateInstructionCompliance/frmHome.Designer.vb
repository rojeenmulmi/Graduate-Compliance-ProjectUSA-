<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblGenerateReport = New System.Windows.Forms.LinkLabel()
        Me.lblArchiveFaculty = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.lblArchiveCourse = New System.Windows.Forms.LinkLabel()
        Me.lblUploadCourseAssignment = New System.Windows.Forms.LinkLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DEPARTMENTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnClose = New System.Windows.Forms.LinkLabel()
        CType(Me.DEPARTMENTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGenerateReport
        '
        Me.lblGenerateReport.AutoSize = True
        Me.lblGenerateReport.Location = New System.Drawing.Point(32, 55)
        Me.lblGenerateReport.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGenerateReport.Name = "lblGenerateReport"
        Me.lblGenerateReport.Size = New System.Drawing.Size(217, 20)
        Me.lblGenerateReport.TabIndex = 0
        Me.lblGenerateReport.TabStop = True
        Me.lblGenerateReport.Text = "Generate Compliance Report"
        '
        'lblArchiveFaculty
        '
        Me.lblArchiveFaculty.AutoSize = True
        Me.lblArchiveFaculty.Location = New System.Drawing.Point(32, 108)
        Me.lblArchiveFaculty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArchiveFaculty.Name = "lblArchiveFaculty"
        Me.lblArchiveFaculty.Size = New System.Drawing.Size(116, 20)
        Me.lblArchiveFaculty.TabIndex = 1
        Me.lblArchiveFaculty.TabStop = True
        Me.lblArchiveFaculty.Text = "Archive Faculty"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(32, 175)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(0, 20)
        Me.LinkLabel3.TabIndex = 2
        '
        'lblArchiveCourse
        '
        Me.lblArchiveCourse.AutoSize = True
        Me.lblArchiveCourse.Location = New System.Drawing.Point(32, 162)
        Me.lblArchiveCourse.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArchiveCourse.Name = "lblArchiveCourse"
        Me.lblArchiveCourse.Size = New System.Drawing.Size(116, 20)
        Me.lblArchiveCourse.TabIndex = 3
        Me.lblArchiveCourse.TabStop = True
        Me.lblArchiveCourse.Text = "Archive Course"
        '
        'lblUploadCourseAssignment
        '
        Me.lblUploadCourseAssignment.AutoSize = True
        Me.lblUploadCourseAssignment.Location = New System.Drawing.Point(32, 217)
        Me.lblUploadCourseAssignment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUploadCourseAssignment.Name = "lblUploadCourseAssignment"
        Me.lblUploadCourseAssignment.Size = New System.Drawing.Size(203, 20)
        Me.lblUploadCourseAssignment.TabIndex = 4
        Me.lblUploadCourseAssignment.TabStop = True
        Me.lblUploadCourseAssignment.Text = "Upload Course Assignment"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DEPARTMENTBindingSource
        '
        Me.DEPARTMENTBindingSource.DataMember = "DEPARTMENT"
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.Location = New System.Drawing.Point(32, 270)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(140, 20)
        Me.btnClose.TabIndex = 5
        Me.btnClose.TabStop = True
        Me.btnClose.Text = "Close the Program"
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 323)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblUploadCourseAssignment)
        Me.Controls.Add(Me.lblArchiveCourse)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.lblArchiveFaculty)
        Me.Controls.Add(Me.lblGenerateReport)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmHome"
        Me.Text = "Welcome to Graduate Instruction Compliance System"
        CType(Me.DEPARTMENTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGenerateReport As System.Windows.Forms.LinkLabel
    Friend WithEvents lblArchiveFaculty As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblArchiveCourse As System.Windows.Forms.LinkLabel
    Friend WithEvents lblUploadCourseAssignment As System.Windows.Forms.LinkLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DEPARTMENTBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnClose As System.Windows.Forms.LinkLabel

End Class
