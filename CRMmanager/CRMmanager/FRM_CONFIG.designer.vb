﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_CONFIG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_CONFIG))
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gbxUseAlarm = New System.Windows.Forms.GroupBox
        Me.cbxAlarmPeriod = New System.Windows.Forms.ComboBox
        Me.cbxAlarmStart = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ckbUseAlarm = New System.Windows.Forms.CheckBox
        Me.ckbNoCloseOnSave = New System.Windows.Forms.CheckBox
        Me.ckbUseUserDef = New System.Windows.Forms.CheckBox
        Me.ckbUseTongUser = New System.Windows.Forms.CheckBox
        Me.nupAlarmPeriod = New System.Windows.Forms.NumericUpDown
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.gbxUseAlarm.SuspendLayout()
        CType(Me.nupAlarmPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(126, 237)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(45, 25)
        Me.btnConfirm.TabIndex = 187
        Me.btnConfirm.Text = "확인"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbxUseAlarm)
        Me.GroupBox1.Controls.Add(Me.ckbUseAlarm)
        Me.GroupBox1.Controls.Add(Me.ckbNoCloseOnSave)
        Me.GroupBox1.Controls.Add(Me.ckbUseUserDef)
        Me.GroupBox1.Controls.Add(Me.ckbUseTongUser)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 217)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "고객정보관리 설정"
        '
        'gbUseAlarm
        '
        Me.gbxUseAlarm.Controls.Add(Me.cbxAlarmPeriod)
        Me.gbxUseAlarm.Controls.Add(Me.cbxAlarmStart)
        Me.gbxUseAlarm.Controls.Add(Me.Label3)
        Me.gbxUseAlarm.Controls.Add(Me.Label4)
        Me.gbxUseAlarm.Controls.Add(Me.Label2)
        Me.gbxUseAlarm.Controls.Add(Me.Label1)
        Me.gbxUseAlarm.Location = New System.Drawing.Point(18, 130)
        Me.gbxUseAlarm.Name = "gbUseAlarm"
        Me.gbxUseAlarm.Size = New System.Drawing.Size(275, 74)
        Me.gbxUseAlarm.TabIndex = 6
        Me.gbxUseAlarm.TabStop = False
        Me.gbxUseAlarm.Text = "알람설정"
        '
        'cbxAlarmPeriod
        '
        Me.cbxAlarmPeriod.BackColor = System.Drawing.Color.MintCream
        Me.cbxAlarmPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlarmPeriod.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbxAlarmPeriod.FormattingEnabled = True
        Me.cbxAlarmPeriod.Items.AddRange(New Object() {"", "010", "011", "016", "017", "018", "019"})
        Me.cbxAlarmPeriod.Location = New System.Drawing.Point(85, 43)
        Me.cbxAlarmPeriod.Name = "cbxAlarmPeriod"
        Me.cbxAlarmPeriod.Size = New System.Drawing.Size(131, 20)
        Me.cbxAlarmPeriod.TabIndex = 210
        '
        'cbxAlarmStart
        '
        Me.cbxAlarmStart.BackColor = System.Drawing.Color.MintCream
        Me.cbxAlarmStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlarmStart.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbxAlarmStart.FormattingEnabled = True
        Me.cbxAlarmStart.Items.AddRange(New Object() {"", "010", "011", "016", "017", "018", "019"})
        Me.cbxAlarmStart.Location = New System.Drawing.Point(85, 19)
        Me.cbxAlarmStart.Name = "cbxAlarmStart"
        Me.cbxAlarmStart.Size = New System.Drawing.Size(131, 20)
        Me.cbxAlarmStart.TabIndex = 209
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(221, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "마다"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "알람주기"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(221, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "전부터"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "약속시간"
        '
        'ckbUseAlarm
        '
        Me.ckbUseAlarm.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ckbUseAlarm.Location = New System.Drawing.Point(18, 107)
        Me.ckbUseAlarm.Name = "ckbUseAlarm"
        Me.ckbUseAlarm.Size = New System.Drawing.Size(216, 15)
        Me.ckbUseAlarm.TabIndex = 3
        Me.ckbUseAlarm.Text = "고객약속일정을 알람으로 알립니다."
        Me.ckbUseAlarm.UseVisualStyleBackColor = False
        '
        'ckbNoCloseOnSave
        '
        Me.ckbNoCloseOnSave.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ckbNoCloseOnSave.Location = New System.Drawing.Point(18, 82)
        Me.ckbNoCloseOnSave.Name = "ckbNoCloseOnSave"
        Me.ckbNoCloseOnSave.Size = New System.Drawing.Size(200, 16)
        Me.ckbNoCloseOnSave.TabIndex = 2
        Me.ckbNoCloseOnSave.Text = "상담이력 저장후 창을 닫지 않음"
        Me.ckbNoCloseOnSave.UseVisualStyleBackColor = False
        '
        'ckbUseUserDef
        '
        Me.ckbUseUserDef.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ckbUseUserDef.Location = New System.Drawing.Point(18, 57)
        Me.ckbUseUserDef.Name = "ckbUseUserDef"
        Me.ckbUseUserDef.Size = New System.Drawing.Size(200, 16)
        Me.ckbUseUserDef.TabIndex = 1
        Me.ckbUseUserDef.Text = "고객정보의 비고항목을 사용하기"
        Me.ckbUseUserDef.UseVisualStyleBackColor = False
        '
        'ckbUseTongUser
        '
        Me.ckbUseTongUser.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ckbUseTongUser.Location = New System.Drawing.Point(18, 31)
        Me.ckbUseTongUser.Name = "ckbUseTongUser"
        Me.ckbUseTongUser.Size = New System.Drawing.Size(216, 16)
        Me.ckbUseTongUser.TabIndex = 0
        Me.ckbUseTongUser.Text = "고객별 담당자 지정기능을 사용하기"
        Me.ckbUseTongUser.UseVisualStyleBackColor = False
        '
        'nupAlarmPeriod
        '
        Me.nupAlarmPeriod.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupAlarmPeriod.Location = New System.Drawing.Point(270, 210)
        Me.nupAlarmPeriod.Maximum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.nupAlarmPeriod.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupAlarmPeriod.Name = "nupAlarmPeriod"
        Me.nupAlarmPeriod.Size = New System.Drawing.Size(32, 21)
        Me.nupAlarmPeriod.TabIndex = 7
        Me.nupAlarmPeriod.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(177, 237)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(45, 25)
        Me.btnClose.TabIndex = 189
        Me.btnClose.Text = "취소"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FRM_CONFIG
        '
        Me.ClientSize = New System.Drawing.Size(360, 268)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.nupAlarmPeriod)
        Me.Controls.Add(Me.btnConfirm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FRM_CONFIG"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "설정"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.gbxUseAlarm.ResumeLayout(False)
        Me.gbxUseAlarm.PerformLayout()
        CType(Me.nupAlarmPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ckbUseUserDef As System.Windows.Forms.CheckBox
    Friend WithEvents ckbUseTongUser As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ckbNoCloseOnSave As System.Windows.Forms.CheckBox
    Friend WithEvents gbxUseAlarm As System.Windows.Forms.GroupBox
    Friend WithEvents ckbUseAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nupAlarmPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxAlarmPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents cbxAlarmStart As System.Windows.Forms.ComboBox
End Class
