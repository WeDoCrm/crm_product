<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_SCHEDULE_ALARM
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_SCHEDULE_ALARM))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.btnRelease = New System.Windows.Forms.Button
        Me.gbScheduleDetail = New System.Windows.Forms.GroupBox
        Me.lblContents = New System.Windows.Forms.Label
        Me.lblUsers = New System.Windows.Forms.Label
        Me.lblTimeBetween = New System.Windows.Forms.Label
        Me.lblEndTime = New System.Windows.Forms.Label
        Me.lblStartTime = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label77 = New System.Windows.Forms.Label
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label69 = New System.Windows.Forms.Label
        Me.DGViewAlarmSchedule = New System.Windows.Forms.DataGridView
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.S_START_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Users = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserNameList = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StartTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeGap = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RegName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShareTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SharingType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolTipLabelUsers = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipLabelDesc = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbScheduleDetail.SuspendLayout()
        CType(Me.DGViewAlarmSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(475, 360)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(69, 25)
        Me.btnConfirm.TabIndex = 187
        Me.btnConfirm.Text = "확인"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnRelease
        '
        Me.btnRelease.Location = New System.Drawing.Point(384, 360)
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(70, 25)
        Me.btnRelease.TabIndex = 189
        Me.btnRelease.Text = "알람해제"
        Me.btnRelease.UseVisualStyleBackColor = True
        '
        'gbScheduleDetail
        '
        Me.gbScheduleDetail.Controls.Add(Me.lblContents)
        Me.gbScheduleDetail.Controls.Add(Me.lblUsers)
        Me.gbScheduleDetail.Controls.Add(Me.lblTimeBetween)
        Me.gbScheduleDetail.Controls.Add(Me.lblEndTime)
        Me.gbScheduleDetail.Controls.Add(Me.lblStartTime)
        Me.gbScheduleDetail.Controls.Add(Me.Label5)
        Me.gbScheduleDetail.Controls.Add(Me.Label6)
        Me.gbScheduleDetail.Controls.Add(Me.Label77)
        Me.gbScheduleDetail.Controls.Add(Me.Label72)
        Me.gbScheduleDetail.Controls.Add(Me.Label73)
        Me.gbScheduleDetail.Controls.Add(Me.Label68)
        Me.gbScheduleDetail.Controls.Add(Me.Label69)
        Me.gbScheduleDetail.Location = New System.Drawing.Point(12, 144)
        Me.gbScheduleDetail.Name = "gbScheduleDetail"
        Me.gbScheduleDetail.Size = New System.Drawing.Size(532, 210)
        Me.gbScheduleDetail.TabIndex = 244
        Me.gbScheduleDetail.TabStop = False
        Me.gbScheduleDetail.Text = "고객약속등록"
        '
        'lblContents
        '
        Me.lblContents.Location = New System.Drawing.Point(91, 73)
        Me.lblContents.Name = "lblContents"
        Me.lblContents.Size = New System.Drawing.Size(422, 125)
        Me.lblContents.TabIndex = 267
        Me.lblContents.Text = "3. 필드변경으로 디비그리드중 엉뚱한데이터 가는 부분 정리" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. 고객정보관리->엉뚱한 사람선택->" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. 필드변경으로 디비그리드중 엉뚱한데이터 " & _
            "가는 부분 정리" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4. 고객약속등록 ==> 일부만 저장가능하게" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5. 주민번호 등록" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6. 기타전화번호 목록 -> 힌트" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7. 통화일자 및 약속" & _
            "일정: 해당일 또는 일정주기로 알람기능" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblUsers
        '
        Me.lblUsers.Location = New System.Drawing.Point(91, 47)
        Me.lblUsers.Name = "lblUsers"
        Me.lblUsers.Size = New System.Drawing.Size(407, 12)
        Me.lblUsers.TabIndex = 266
        Me.lblUsers.Text = "최진원, 정창식, 임준규, 김호상"
        '
        'lblTimeBetween
        '
        Me.lblTimeBetween.AutoSize = True
        Me.lblTimeBetween.Location = New System.Drawing.Point(210, 20)
        Me.lblTimeBetween.Name = "lblTimeBetween"
        Me.lblTimeBetween.Size = New System.Drawing.Size(11, 12)
        Me.lblTimeBetween.TabIndex = 265
        Me.lblTimeBetween.Text = "-"
        '
        'lblEndTime
        '
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Location = New System.Drawing.Point(228, 20)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(113, 12)
        Me.lblEndTime.TabIndex = 264
        Me.lblEndTime.Text = "2013-05-19 12:30:00"
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(91, 20)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(113, 12)
        Me.lblStartTime.TabIndex = 263
        Me.lblStartTime.Text = "2013-05-19 12:30:00"
        '
        'Label5
        '
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.Location = New System.Drawing.Point(7, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 12)
        Me.Label5.TabIndex = 262
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 261
        Me.Label6.Text = "참석자"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(-12, -86)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(41, 12)
        Me.Label77.TabIndex = 255
        Me.Label77.Text = "외근지"
        '
        'Label72
        '
        Me.Label72.Image = CType(resources.GetObject("Label72.Image"), System.Drawing.Image)
        Me.Label72.Location = New System.Drawing.Point(7, 72)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(13, 12)
        Me.Label72.TabIndex = 250
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(18, 73)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(53, 12)
        Me.Label73.TabIndex = 249
        Me.Label73.Text = "일정내용"
        '
        'Label68
        '
        Me.Label68.Image = CType(resources.GetObject("Label68.Image"), System.Drawing.Image)
        Me.Label68.Location = New System.Drawing.Point(8, 20)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(13, 12)
        Me.Label68.TabIndex = 244
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(19, 20)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(53, 12)
        Me.Label69.TabIndex = 243
        Me.Label69.Text = "예약일정"
        '
        'DGViewAlarmSchedule
        '
        Me.DGViewAlarmSchedule.AllowUserToAddRows = False
        Me.DGViewAlarmSchedule.AllowUserToDeleteRows = False
        Me.DGViewAlarmSchedule.AllowUserToOrderColumns = True
        Me.DGViewAlarmSchedule.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGViewAlarmSchedule.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGViewAlarmSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGViewAlarmSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Title, Me.S_START_TIME, Me.Users, Me.UserNameList, Me.StartTime, Me.TimeGap, Me.RegName, Me.ShareTypeName, Me.Location, Me.EndTime, Me.SharingType, Me.Description})
        Me.DGViewAlarmSchedule.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGViewAlarmSchedule.Location = New System.Drawing.Point(12, 13)
        Me.DGViewAlarmSchedule.MultiSelect = False
        Me.DGViewAlarmSchedule.Name = "DGViewAlarmSchedule"
        Me.DGViewAlarmSchedule.ReadOnly = True
        Me.DGViewAlarmSchedule.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGViewAlarmSchedule.RowHeadersVisible = False
        Me.DGViewAlarmSchedule.RowHeadersWidth = 15
        Me.DGViewAlarmSchedule.RowTemplate.Height = 23
        Me.DGViewAlarmSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGViewAlarmSchedule.Size = New System.Drawing.Size(532, 119)
        Me.DGViewAlarmSchedule.TabIndex = 245
        '
        'Title
        '
        Me.Title.DataPropertyName = "Title"
        Me.Title.HeaderText = "주제"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        '
        'S_START_TIME
        '
        Me.S_START_TIME.DataPropertyName = "S_START_TIME"
        Me.S_START_TIME.HeaderText = "S_START_TIME"
        Me.S_START_TIME.Name = "S_START_TIME"
        Me.S_START_TIME.ReadOnly = True
        Me.S_START_TIME.Visible = False
        '
        'Users
        '
        Me.Users.DataPropertyName = "Users"
        Me.Users.HeaderText = "참석자"
        Me.Users.Name = "Users"
        Me.Users.ReadOnly = True
        Me.Users.Visible = False
        '
        'UserNameList
        '
        Me.UserNameList.HeaderText = "참석자"
        Me.UserNameList.Name = "UserNameList"
        Me.UserNameList.ReadOnly = True
        '
        'StartTime
        '
        Me.StartTime.DataPropertyName = "StartTime"
        Me.StartTime.HeaderText = "시작시간"
        Me.StartTime.Name = "StartTime"
        Me.StartTime.ReadOnly = True
        '
        'TimeGap
        '
        Me.TimeGap.DataPropertyName = "TimeGap"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TimeGap.DefaultCellStyle = DataGridViewCellStyle3
        Me.TimeGap.HeaderText = "남은시간"
        Me.TimeGap.Name = "TimeGap"
        Me.TimeGap.ReadOnly = True
        '
        'RegName
        '
        Me.RegName.DataPropertyName = "RegName"
        Me.RegName.HeaderText = "등록자"
        Me.RegName.Name = "RegName"
        Me.RegName.ReadOnly = True
        '
        'ShareTypeName
        '
        Me.ShareTypeName.DataPropertyName = "ShareTypeName"
        Me.ShareTypeName.HeaderText = "일정유형"
        Me.ShareTypeName.Name = "ShareTypeName"
        Me.ShareTypeName.ReadOnly = True
        '
        'Location
        '
        Me.Location.DataPropertyName = "Location"
        Me.Location.HeaderText = "위치"
        Me.Location.Name = "Location"
        Me.Location.ReadOnly = True
        Me.Location.Visible = False
        '
        'EndTime
        '
        Me.EndTime.DataPropertyName = "EndTime"
        Me.EndTime.HeaderText = "종료시간"
        Me.EndTime.Name = "EndTime"
        Me.EndTime.ReadOnly = True
        Me.EndTime.Visible = False
        '
        'SharingType
        '
        Me.SharingType.DataPropertyName = "SharingType"
        Me.SharingType.HeaderText = "일정유형"
        Me.SharingType.Name = "SharingType"
        Me.SharingType.ReadOnly = True
        Me.SharingType.Visible = False
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "상세내용"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Visible = False
        '
        'FRM_SCHEDULE_ALARM
        '
        Me.ClientSize = New System.Drawing.Size(556, 391)
        Me.Controls.Add(Me.DGViewAlarmSchedule)
        Me.Controls.Add(Me.gbScheduleDetail)
        Me.Controls.Add(Me.btnRelease)
        Me.Controls.Add(Me.btnConfirm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FRM_SCHEDULE_ALARM"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "일정 알림"
        Me.TopMost = True
        Me.gbScheduleDetail.ResumeLayout(False)
        Me.gbScheduleDetail.PerformLayout()
        CType(Me.DGViewAlarmSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnRelease As System.Windows.Forms.Button
    Friend WithEvents gbScheduleDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents lblUsers As System.Windows.Forms.Label
    Friend WithEvents lblTimeBetween As System.Windows.Forms.Label
    Friend WithEvents lblEndTime As System.Windows.Forms.Label
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents lblContents As System.Windows.Forms.Label
    Friend WithEvents DGViewAlarmSchedule As System.Windows.Forms.DataGridView
    Friend WithEvents RegId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShareType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S_START_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Users As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameList As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeGap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RegName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShareTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SharingType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTipLabelUsers As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipLabelDesc As System.Windows.Forms.ToolTip
End Class
