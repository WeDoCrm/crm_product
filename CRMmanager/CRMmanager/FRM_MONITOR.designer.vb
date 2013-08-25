<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MONITOR
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MONITOR))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgViewMain = New System.Windows.Forms.DataGridView
        Me.btnGrpConsult = New Elegant.Ui.ButtonGroup
        Me.ToggleButton01 = New Elegant.Ui.ToggleButton
        Me.ToggleButton02 = New Elegant.Ui.ToggleButton
        Me.ToggleButton07 = New Elegant.Ui.ToggleButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnGrpTrans = New Elegant.Ui.ButtonGroup
        Me.ToggleButton11 = New Elegant.Ui.ToggleButton
        Me.ToggleButton12 = New Elegant.Ui.ToggleButton
        Me.ToggleButton17 = New Elegant.Ui.ToggleButton
        Me.dgViewTrans = New System.Windows.Forms.DataGridView
        Me.Label43 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgViewCallback = New System.Windows.Forms.DataGridView
        Me.btnGrpCallback = New Elegant.Ui.ButtonGroup
        Me.ToggleButton21 = New Elegant.Ui.ToggleButton
        Me.ToggleButton22 = New Elegant.Ui.ToggleButton
        Me.ToggleButton27 = New Elegant.Ui.ToggleButton
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.DM_CUSTOMER_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_CUSTOMER_NM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_TONG_DD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_TONG_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_TONG_TELNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_CONSULT_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_CONSULT_RESULT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_TONG_USER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_TONG_CONTENTS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_CALL_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_HANDLE_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_PREV_TONG_DD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_PREV_TONG_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DM_PREV_TONG_USER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_CUSTOMER_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_CUSTOMER_NM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_TONG_DD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_TONG_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_TONG_TELNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_CONSULT_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_CONSULT_RESULT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_TONG_USER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_TONG_CONTENTS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_CALL_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_HANDLE_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_PREV_TONG_DD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_PREV_TONG_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DT_PREV_TONG_USER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_CUSTOMER_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_CUSTOMER_NM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_TONG_DD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_TONG_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_TONG_TELNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_CALL_BACK_RESULT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_CONSULT_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_CONSULT_RESULT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_TONG_USER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_CALL_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_TONG_CONTENTS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DC_HANDLE_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgViewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnGrpConsult.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.btnGrpTrans.SuspendLayout()
        CType(Me.dgViewTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgViewCallback, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnGrpCallback.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgViewMain)
        Me.GroupBox1.Controls.Add(Me.btnGrpConsult)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(885, 225)
        Me.GroupBox1.TabIndex = 86
        Me.GroupBox1.TabStop = False
        '
        'dgViewMain
        '
        Me.dgViewMain.AllowUserToAddRows = False
        Me.dgViewMain.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgViewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgViewMain.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DM_CUSTOMER_ID, Me.DM_CUSTOMER_NM, Me.DM_TONG_DD, Me.DM_TONG_TIME, Me.DM_TONG_TELNO, Me.DM_CONSULT_TYPE, Me.DM_CONSULT_RESULT, Me.DM_TONG_USER, Me.DM_TONG_CONTENTS, Me.DM_CALL_TYPE, Me.DM_HANDLE_TYPE, Me.DM_PREV_TONG_DD, Me.DM_PREV_TONG_TIME, Me.DM_PREV_TONG_USER})
        Me.dgViewMain.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgViewMain.Location = New System.Drawing.Point(6, 39)
        Me.dgViewMain.MultiSelect = False
        Me.dgViewMain.Name = "dgViewMain"
        Me.dgViewMain.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewMain.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgViewMain.RowHeadersVisible = False
        Me.dgViewMain.RowTemplate.Height = 23
        Me.dgViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewMain.Size = New System.Drawing.Size(872, 180)
        Me.dgViewMain.TabIndex = 203
        '
        'btnGrpConsult
        '
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton01)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton02)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton07)
        Me.btnGrpConsult.Location = New System.Drawing.Point(139, 11)
        Me.btnGrpConsult.Name = "btnGrpConsult"
        Me.btnGrpConsult.Size = New System.Drawing.Size(739, 25)
        Me.btnGrpConsult.TabIndex = 202
        Me.btnGrpConsult.Text = "ButtonGroup1"
        '
        'ToggleButton01
        '
        Me.ToggleButton01.Id = "49caf8f5-731b-496c-ad10-8a1b1322529c"
        Me.ToggleButton01.Location = New System.Drawing.Point(0, 0)
        Me.ToggleButton01.Name = "ToggleButton01"
        Me.ToggleButton01.Size = New System.Drawing.Size(120, 22)
        Me.ToggleButton01.TabIndex = 200
        Me.ToggleButton01.Tag = "1"
        Me.ToggleButton01.Text = "상담완료( 34 )"
        '
        'ToggleButton02
        '
        Me.ToggleButton02.Id = "0c1f7a95-b104-4c4b-bd42-7f0f70205e54"
        Me.ToggleButton02.Location = New System.Drawing.Point(120, 0)
        Me.ToggleButton02.Name = "ToggleButton02"
        Me.ToggleButton02.Size = New System.Drawing.Size(120, 22)
        Me.ToggleButton02.TabIndex = 202
        Me.ToggleButton02.Tag = "2"
        Me.ToggleButton02.Text = "미처리( 34 )"
        '
        'ToggleButton07
        '
        Me.ToggleButton07.Id = "95c2734f-5897-45eb-bfc0-6de980dce0f3"
        Me.ToggleButton07.Location = New System.Drawing.Point(240, 0)
        Me.ToggleButton07.Name = "ToggleButton07"
        Me.ToggleButton07.Size = New System.Drawing.Size(120, 22)
        Me.ToggleButton07.TabIndex = 205
        Me.ToggleButton07.Tag = "7"
        Me.ToggleButton07.Text = "전체( 34 )"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "상담 진행현황"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGrpTrans)
        Me.GroupBox2.Controls.Add(Me.dgViewTrans)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(885, 225)
        Me.GroupBox2.TabIndex = 215
        Me.GroupBox2.TabStop = False
        '
        'btnGrpTrans
        '
        Me.btnGrpTrans.Controls.Add(Me.ToggleButton11)
        Me.btnGrpTrans.Controls.Add(Me.ToggleButton12)
        Me.btnGrpTrans.Controls.Add(Me.ToggleButton17)
        Me.btnGrpTrans.Location = New System.Drawing.Point(139, 11)
        Me.btnGrpTrans.Name = "btnGrpTrans"
        Me.btnGrpTrans.Size = New System.Drawing.Size(739, 25)
        Me.btnGrpTrans.TabIndex = 216
        Me.btnGrpTrans.Text = "ButtonGroup3"
        '
        'ToggleButton11
        '
        Me.ToggleButton11.Id = "3d59252a-d2dc-415f-9a92-1c8122996c2f"
        Me.ToggleButton11.Location = New System.Drawing.Point(0, 0)
        Me.ToggleButton11.Name = "ToggleButton11"
        Me.ToggleButton11.Size = New System.Drawing.Size(120, 22)
        Me.ToggleButton11.TabIndex = 200
        Me.ToggleButton11.Tag = "1"
        Me.ToggleButton11.Text = "처리완료( 34 )"
        '
        'ToggleButton12
        '
        Me.ToggleButton12.Id = "bfe94587-5da7-440c-855f-d0cba7d750ce"
        Me.ToggleButton12.Location = New System.Drawing.Point(120, 0)
        Me.ToggleButton12.Name = "ToggleButton12"
        Me.ToggleButton12.Size = New System.Drawing.Size(120, 22)
        Me.ToggleButton12.TabIndex = 202
        Me.ToggleButton12.Tag = "2"
        Me.ToggleButton12.Text = "미처리( 34 )"
        '
        'ToggleButton17
        '
        Me.ToggleButton17.Id = "17edc640-212f-4362-9b9d-4753842cb5f0"
        Me.ToggleButton17.Location = New System.Drawing.Point(240, 0)
        Me.ToggleButton17.Name = "ToggleButton17"
        Me.ToggleButton17.Size = New System.Drawing.Size(120, 22)
        Me.ToggleButton17.TabIndex = 205
        Me.ToggleButton17.Tag = "7"
        Me.ToggleButton17.Text = "전체( 34 )"
        '
        'dgViewTrans
        '
        Me.dgViewTrans.AllowUserToAddRows = False
        Me.dgViewTrans.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgViewTrans.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgViewTrans.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewTrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgViewTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewTrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DT_CUSTOMER_ID, Me.DT_CUSTOMER_NM, Me.DT_TONG_DD, Me.DT_TONG_TIME, Me.DT_TONG_TELNO, Me.DT_CONSULT_TYPE, Me.DT_CONSULT_RESULT, Me.DT_TONG_USER, Me.DT_TONG_CONTENTS, Me.DT_CALL_TYPE, Me.DT_HANDLE_TYPE, Me.DT_PREV_TONG_DD, Me.DT_PREV_TONG_TIME, Me.DT_PREV_TONG_USER})
        Me.dgViewTrans.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgViewTrans.Location = New System.Drawing.Point(6, 37)
        Me.dgViewTrans.MultiSelect = False
        Me.dgViewTrans.Name = "dgViewTrans"
        Me.dgViewTrans.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewTrans.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgViewTrans.RowHeadersVisible = False
        Me.dgViewTrans.RowTemplate.Height = 23
        Me.dgViewTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewTrans.Size = New System.Drawing.Size(872, 180)
        Me.dgViewTrans.TabIndex = 215
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(19, 16)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(105, 12)
        Me.Label43.TabIndex = 3
        Me.Label43.Text = "이관업무 진행현황"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgViewCallback)
        Me.GroupBox3.Controls.Add(Me.btnGrpCallback)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 448)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(885, 225)
        Me.GroupBox3.TabIndex = 216
        Me.GroupBox3.TabStop = False
        '
        'dgViewCallback
        '
        Me.dgViewCallback.AllowUserToAddRows = False
        Me.dgViewCallback.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgViewCallback.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgViewCallback.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewCallback.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgViewCallback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewCallback.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DC_CUSTOMER_ID, Me.DC_CUSTOMER_NM, Me.DC_TONG_DD, Me.DC_TONG_TIME, Me.DC_TONG_TELNO, Me.DC_CALL_BACK_RESULT, Me.DC_CONSULT_TYPE, Me.DC_CONSULT_RESULT, Me.DC_TONG_USER, Me.DC_CALL_TYPE, Me.DC_TONG_CONTENTS, Me.DC_HANDLE_TYPE})
        Me.dgViewCallback.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgViewCallback.Location = New System.Drawing.Point(6, 38)
        Me.dgViewCallback.MultiSelect = False
        Me.dgViewCallback.Name = "dgViewCallback"
        Me.dgViewCallback.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewCallback.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgViewCallback.RowHeadersVisible = False
        Me.dgViewCallback.RowTemplate.Height = 23
        Me.dgViewCallback.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewCallback.Size = New System.Drawing.Size(872, 181)
        Me.dgViewCallback.TabIndex = 220
        '
        'btnGrpCallback
        '
        Me.btnGrpCallback.Controls.Add(Me.ToggleButton21)
        Me.btnGrpCallback.Controls.Add(Me.ToggleButton22)
        Me.btnGrpCallback.Controls.Add(Me.ToggleButton27)
        Me.btnGrpCallback.Location = New System.Drawing.Point(138, 11)
        Me.btnGrpCallback.Name = "btnGrpCallback"
        Me.btnGrpCallback.Size = New System.Drawing.Size(391, 25)
        Me.btnGrpCallback.TabIndex = 219
        Me.btnGrpCallback.Text = "ButtonGroup2"
        '
        'ToggleButton21
        '
        Me.ToggleButton21.Id = "47622b8b-a55c-4f12-a788-e273c9c2a589"
        Me.ToggleButton21.Location = New System.Drawing.Point(0, 0)
        Me.ToggleButton21.Name = "ToggleButton21"
        Me.ToggleButton21.Size = New System.Drawing.Size(120, 22)
        Me.ToggleButton21.TabIndex = 200
        Me.ToggleButton21.Tag = "1"
        Me.ToggleButton21.Text = "처리완료( 34 )"
        '
        'ToggleButton22
        '
        Me.ToggleButton22.Id = "72d56d1a-de91-436d-844b-bc3654f00a7a"
        Me.ToggleButton22.Location = New System.Drawing.Point(120, 0)
        Me.ToggleButton22.Name = "ToggleButton22"
        Me.ToggleButton22.Size = New System.Drawing.Size(125, 22)
        Me.ToggleButton22.TabIndex = 201
        Me.ToggleButton22.Tag = "2"
        Me.ToggleButton22.Text = "미완료( 34 )"
        '
        'ToggleButton27
        '
        Me.ToggleButton27.Id = "48560acb-9277-40b2-8c41-4879bf2b06de"
        Me.ToggleButton27.Location = New System.Drawing.Point(245, 0)
        Me.ToggleButton27.Name = "ToggleButton27"
        Me.ToggleButton27.Size = New System.Drawing.Size(125, 22)
        Me.ToggleButton27.TabIndex = 202
        Me.ToggleButton27.Tag = "7"
        Me.ToggleButton27.Text = "전체( 34 )"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 12)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "콜백업무 진행현황"
        '
        'Label16
        '
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.Location = New System.Drawing.Point(5, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(13, 12)
        Me.Label16.TabIndex = 199
        '
        'Label37
        '
        Me.Label37.Image = CType(resources.GetObject("Label37.Image"), System.Drawing.Image)
        Me.Label37.Location = New System.Drawing.Point(6, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(13, 12)
        Me.Label37.TabIndex = 199
        '
        'Label24
        '
        Me.Label24.Image = CType(resources.GetObject("Label24.Image"), System.Drawing.Image)
        Me.Label24.Location = New System.Drawing.Point(6, 14)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(13, 12)
        Me.Label24.TabIndex = 199
        '
        'DM_CUSTOMER_ID
        '
        Me.DM_CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DM_CUSTOMER_ID.DefaultCellStyle = DataGridViewCellStyle3
        Me.DM_CUSTOMER_ID.HeaderText = "고객아이디"
        Me.DM_CUSTOMER_ID.Name = "DM_CUSTOMER_ID"
        Me.DM_CUSTOMER_ID.ReadOnly = True
        Me.DM_CUSTOMER_ID.Width = 90
        '
        'DM_CUSTOMER_NM
        '
        Me.DM_CUSTOMER_NM.DataPropertyName = "CUSTOMER_NM"
        Me.DM_CUSTOMER_NM.HeaderText = "고객명"
        Me.DM_CUSTOMER_NM.Name = "DM_CUSTOMER_NM"
        Me.DM_CUSTOMER_NM.ReadOnly = True
        '
        'DM_TONG_DD
        '
        Me.DM_TONG_DD.DataPropertyName = "TONG_DD"
        Me.DM_TONG_DD.HeaderText = "통화일자"
        Me.DM_TONG_DD.Name = "DM_TONG_DD"
        Me.DM_TONG_DD.ReadOnly = True
        Me.DM_TONG_DD.Width = 90
        '
        'DM_TONG_TIME
        '
        Me.DM_TONG_TIME.DataPropertyName = "TONG_TIME"
        Me.DM_TONG_TIME.HeaderText = "통화시간"
        Me.DM_TONG_TIME.Name = "DM_TONG_TIME"
        Me.DM_TONG_TIME.ReadOnly = True
        Me.DM_TONG_TIME.Width = 90
        '
        'DM_TONG_TELNO
        '
        Me.DM_TONG_TELNO.DataPropertyName = "TONG_TELNO"
        Me.DM_TONG_TELNO.HeaderText = "전화번호"
        Me.DM_TONG_TELNO.Name = "DM_TONG_TELNO"
        Me.DM_TONG_TELNO.ReadOnly = True
        '
        'DM_CONSULT_TYPE
        '
        Me.DM_CONSULT_TYPE.DataPropertyName = "CONSULT_TYPE"
        Me.DM_CONSULT_TYPE.HeaderText = "상담유형"
        Me.DM_CONSULT_TYPE.Name = "DM_CONSULT_TYPE"
        Me.DM_CONSULT_TYPE.ReadOnly = True
        Me.DM_CONSULT_TYPE.Width = 90
        '
        'DM_CONSULT_RESULT
        '
        Me.DM_CONSULT_RESULT.DataPropertyName = "CONSULT_RESULT"
        Me.DM_CONSULT_RESULT.HeaderText = "상담결과"
        Me.DM_CONSULT_RESULT.Name = "DM_CONSULT_RESULT"
        Me.DM_CONSULT_RESULT.ReadOnly = True
        Me.DM_CONSULT_RESULT.Width = 90
        '
        'DM_TONG_USER
        '
        Me.DM_TONG_USER.DataPropertyName = "TONG_USER"
        Me.DM_TONG_USER.HeaderText = "통화자"
        Me.DM_TONG_USER.Name = "DM_TONG_USER"
        Me.DM_TONG_USER.ReadOnly = True
        '
        'DM_TONG_CONTENTS
        '
        Me.DM_TONG_CONTENTS.DataPropertyName = "TONG_CONTENTS"
        Me.DM_TONG_CONTENTS.HeaderText = "내용"
        Me.DM_TONG_CONTENTS.Name = "DM_TONG_CONTENTS"
        Me.DM_TONG_CONTENTS.ReadOnly = True
        Me.DM_TONG_CONTENTS.Visible = False
        '
        'DM_CALL_TYPE
        '
        Me.DM_CALL_TYPE.DataPropertyName = "CALL_TYPE"
        Me.DM_CALL_TYPE.HeaderText = "콜타입"
        Me.DM_CALL_TYPE.Name = "DM_CALL_TYPE"
        Me.DM_CALL_TYPE.ReadOnly = True
        Me.DM_CALL_TYPE.Width = 90
        '
        'DM_HANDLE_TYPE
        '
        Me.DM_HANDLE_TYPE.DataPropertyName = "HANDLE_TYPE"
        Me.DM_HANDLE_TYPE.HeaderText = "처리유형"
        Me.DM_HANDLE_TYPE.Name = "DM_HANDLE_TYPE"
        Me.DM_HANDLE_TYPE.ReadOnly = True
        Me.DM_HANDLE_TYPE.Visible = False
        '
        'DM_PREV_TONG_DD
        '
        Me.DM_PREV_TONG_DD.DataPropertyName = "PREV_TONG_DD"
        Me.DM_PREV_TONG_DD.HeaderText = "이전통화일자"
        Me.DM_PREV_TONG_DD.Name = "DM_PREV_TONG_DD"
        Me.DM_PREV_TONG_DD.ReadOnly = True
        Me.DM_PREV_TONG_DD.Visible = False
        '
        'DM_PREV_TONG_TIME
        '
        Me.DM_PREV_TONG_TIME.DataPropertyName = "PREV_TONG_TIME"
        Me.DM_PREV_TONG_TIME.HeaderText = "이전통화시간"
        Me.DM_PREV_TONG_TIME.Name = "DM_PREV_TONG_TIME"
        Me.DM_PREV_TONG_TIME.ReadOnly = True
        Me.DM_PREV_TONG_TIME.Visible = False
        '
        'DM_PREV_TONG_USER
        '
        Me.DM_PREV_TONG_USER.DataPropertyName = "PREV_TONG_USER"
        Me.DM_PREV_TONG_USER.HeaderText = "이전통화자"
        Me.DM_PREV_TONG_USER.Name = "DM_PREV_TONG_USER"
        Me.DM_PREV_TONG_USER.ReadOnly = True
        Me.DM_PREV_TONG_USER.Visible = False
        '
        'DT_CUSTOMER_ID
        '
        Me.DT_CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID"
        Me.DT_CUSTOMER_ID.HeaderText = "고객아이디"
        Me.DT_CUSTOMER_ID.Name = "DT_CUSTOMER_ID"
        Me.DT_CUSTOMER_ID.ReadOnly = True
        Me.DT_CUSTOMER_ID.Width = 90
        '
        'DT_CUSTOMER_NM
        '
        Me.DT_CUSTOMER_NM.DataPropertyName = "CUSTOMER_NM"
        Me.DT_CUSTOMER_NM.HeaderText = "고객명"
        Me.DT_CUSTOMER_NM.Name = "DT_CUSTOMER_NM"
        Me.DT_CUSTOMER_NM.ReadOnly = True
        '
        'DT_TONG_DD
        '
        Me.DT_TONG_DD.DataPropertyName = "TONG_DD"
        Me.DT_TONG_DD.HeaderText = "통화일자"
        Me.DT_TONG_DD.Name = "DT_TONG_DD"
        Me.DT_TONG_DD.ReadOnly = True
        Me.DT_TONG_DD.Width = 90
        '
        'DT_TONG_TIME
        '
        Me.DT_TONG_TIME.DataPropertyName = "TONG_TIME"
        Me.DT_TONG_TIME.HeaderText = "통화시간"
        Me.DT_TONG_TIME.Name = "DT_TONG_TIME"
        Me.DT_TONG_TIME.ReadOnly = True
        Me.DT_TONG_TIME.Width = 90
        '
        'DT_TONG_TELNO
        '
        Me.DT_TONG_TELNO.DataPropertyName = "TONG_TELNO"
        Me.DT_TONG_TELNO.HeaderText = "전화번호"
        Me.DT_TONG_TELNO.Name = "DT_TONG_TELNO"
        Me.DT_TONG_TELNO.ReadOnly = True
        '
        'DT_CONSULT_TYPE
        '
        Me.DT_CONSULT_TYPE.DataPropertyName = "CONSULT_TYPE"
        Me.DT_CONSULT_TYPE.HeaderText = "상담유형"
        Me.DT_CONSULT_TYPE.Name = "DT_CONSULT_TYPE"
        Me.DT_CONSULT_TYPE.ReadOnly = True
        Me.DT_CONSULT_TYPE.Width = 90
        '
        'DT_CONSULT_RESULT
        '
        Me.DT_CONSULT_RESULT.DataPropertyName = "CONSULT_RESULT"
        Me.DT_CONSULT_RESULT.HeaderText = "상담결과"
        Me.DT_CONSULT_RESULT.Name = "DT_CONSULT_RESULT"
        Me.DT_CONSULT_RESULT.ReadOnly = True
        '
        'DT_TONG_USER
        '
        Me.DT_TONG_USER.DataPropertyName = "TONG_USER"
        Me.DT_TONG_USER.HeaderText = "통화자"
        Me.DT_TONG_USER.Name = "DT_TONG_USER"
        Me.DT_TONG_USER.ReadOnly = True
        Me.DT_TONG_USER.Width = 90
        '
        'DT_TONG_CONTENTS
        '
        Me.DT_TONG_CONTENTS.DataPropertyName = "TONG_CONTENTS"
        Me.DT_TONG_CONTENTS.HeaderText = "내용"
        Me.DT_TONG_CONTENTS.Name = "DT_TONG_CONTENTS"
        Me.DT_TONG_CONTENTS.ReadOnly = True
        Me.DT_TONG_CONTENTS.Visible = False
        '
        'DT_CALL_TYPE
        '
        Me.DT_CALL_TYPE.DataPropertyName = "CALL_TYPE"
        Me.DT_CALL_TYPE.HeaderText = "콜타입"
        Me.DT_CALL_TYPE.Name = "DT_CALL_TYPE"
        Me.DT_CALL_TYPE.ReadOnly = True
        '
        'DT_HANDLE_TYPE
        '
        Me.DT_HANDLE_TYPE.DataPropertyName = "HANDLE_TYPE"
        Me.DT_HANDLE_TYPE.HeaderText = "처리유형"
        Me.DT_HANDLE_TYPE.Name = "DT_HANDLE_TYPE"
        Me.DT_HANDLE_TYPE.ReadOnly = True
        Me.DT_HANDLE_TYPE.Visible = False
        '
        'DT_PREV_TONG_DD
        '
        Me.DT_PREV_TONG_DD.DataPropertyName = "PREV_TONG_DD"
        Me.DT_PREV_TONG_DD.HeaderText = "이전통화일자"
        Me.DT_PREV_TONG_DD.Name = "DT_PREV_TONG_DD"
        Me.DT_PREV_TONG_DD.ReadOnly = True
        Me.DT_PREV_TONG_DD.Visible = False
        '
        'DT_PREV_TONG_TIME
        '
        Me.DT_PREV_TONG_TIME.DataPropertyName = "PREV_TONG_TIME"
        Me.DT_PREV_TONG_TIME.HeaderText = "이전통화시간"
        Me.DT_PREV_TONG_TIME.Name = "DT_PREV_TONG_TIME"
        Me.DT_PREV_TONG_TIME.ReadOnly = True
        Me.DT_PREV_TONG_TIME.Visible = False
        '
        'DT_PREV_TONG_USER
        '
        Me.DT_PREV_TONG_USER.DataPropertyName = "PREV_TONG_USER"
        Me.DT_PREV_TONG_USER.HeaderText = "이전통화자"
        Me.DT_PREV_TONG_USER.Name = "DT_PREV_TONG_USER"
        Me.DT_PREV_TONG_USER.ReadOnly = True
        Me.DT_PREV_TONG_USER.Visible = False
        Me.DT_PREV_TONG_USER.Width = 90
        '
        'DC_CUSTOMER_ID
        '
        Me.DC_CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID"
        Me.DC_CUSTOMER_ID.HeaderText = "고객아이디"
        Me.DC_CUSTOMER_ID.Name = "DC_CUSTOMER_ID"
        Me.DC_CUSTOMER_ID.ReadOnly = True
        '
        'DC_CUSTOMER_NM
        '
        Me.DC_CUSTOMER_NM.DataPropertyName = "CUSTOMER_NM"
        Me.DC_CUSTOMER_NM.HeaderText = "고객명"
        Me.DC_CUSTOMER_NM.Name = "DC_CUSTOMER_NM"
        Me.DC_CUSTOMER_NM.ReadOnly = True
        '
        'DC_TONG_DD
        '
        Me.DC_TONG_DD.DataPropertyName = "TONG_DD"
        Me.DC_TONG_DD.HeaderText = "통화일자"
        Me.DC_TONG_DD.Name = "DC_TONG_DD"
        Me.DC_TONG_DD.ReadOnly = True
        '
        'DC_TONG_TIME
        '
        Me.DC_TONG_TIME.DataPropertyName = "TONG_TIME"
        Me.DC_TONG_TIME.HeaderText = "통화시간"
        Me.DC_TONG_TIME.Name = "DC_TONG_TIME"
        Me.DC_TONG_TIME.ReadOnly = True
        '
        'DC_TONG_TELNO
        '
        Me.DC_TONG_TELNO.DataPropertyName = "TONG_TELNO"
        Me.DC_TONG_TELNO.HeaderText = "전화번호"
        Me.DC_TONG_TELNO.Name = "DC_TONG_TELNO"
        Me.DC_TONG_TELNO.ReadOnly = True
        '
        'DC_CALL_BACK_RESULT
        '
        Me.DC_CALL_BACK_RESULT.DataPropertyName = "CALL_BACK_RESULT"
        Me.DC_CALL_BACK_RESULT.HeaderText = "콜백처리결과"
        Me.DC_CALL_BACK_RESULT.Name = "DC_CALL_BACK_RESULT"
        Me.DC_CALL_BACK_RESULT.ReadOnly = True
        '
        'DC_CONSULT_TYPE
        '
        Me.DC_CONSULT_TYPE.DataPropertyName = "CONSULT_TYPE"
        Me.DC_CONSULT_TYPE.HeaderText = "상담유형"
        Me.DC_CONSULT_TYPE.Name = "DC_CONSULT_TYPE"
        Me.DC_CONSULT_TYPE.ReadOnly = True
        '
        'DC_CONSULT_RESULT
        '
        Me.DC_CONSULT_RESULT.DataPropertyName = "CONSULT_RESULT"
        Me.DC_CONSULT_RESULT.HeaderText = "상담결과"
        Me.DC_CONSULT_RESULT.Name = "DC_CONSULT_RESULT"
        Me.DC_CONSULT_RESULT.ReadOnly = True
        '
        'DC_TONG_USER
        '
        Me.DC_TONG_USER.DataPropertyName = "TONG_USER"
        Me.DC_TONG_USER.HeaderText = "통화자"
        Me.DC_TONG_USER.Name = "DC_TONG_USER"
        Me.DC_TONG_USER.ReadOnly = True
        '
        'DC_CALL_TYPE
        '
        Me.DC_CALL_TYPE.DataPropertyName = "CALL_TYPE"
        Me.DC_CALL_TYPE.HeaderText = "콜타입"
        Me.DC_CALL_TYPE.Name = "DC_CALL_TYPE"
        Me.DC_CALL_TYPE.ReadOnly = True
        '
        'DC_TONG_CONTENTS
        '
        Me.DC_TONG_CONTENTS.DataPropertyName = "TONG_CONTENTS"
        Me.DC_TONG_CONTENTS.HeaderText = "상담내용"
        Me.DC_TONG_CONTENTS.Name = "DC_TONG_CONTENTS"
        Me.DC_TONG_CONTENTS.ReadOnly = True
        Me.DC_TONG_CONTENTS.Visible = False
        '
        'DC_HANDLE_TYPE
        '
        Me.DC_HANDLE_TYPE.DataPropertyName = "HANDLE_TYPE"
        Me.DC_HANDLE_TYPE.HeaderText = "처리유형"
        Me.DC_HANDLE_TYPE.Name = "DC_HANDLE_TYPE"
        Me.DC_HANDLE_TYPE.ReadOnly = True
        Me.DC_HANDLE_TYPE.Visible = False
        '
        'FRM_MONITOR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 676)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRM_MONITOR"
        Me.ShowIcon = False
        Me.Text = "업무진행현황"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgViewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnGrpConsult.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.btnGrpTrans.ResumeLayout(False)
        CType(Me.dgViewTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgViewCallback, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnGrpCallback.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToggleButton01 As Elegant.Ui.ToggleButton
    Friend WithEvents btnGrpConsult As Elegant.Ui.ButtonGroup
    Friend WithEvents ToggleButton02 As Elegant.Ui.ToggleButton
    Friend WithEvents dgViewMain As System.Windows.Forms.DataGridView
    Friend WithEvents dgViewTrans As System.Windows.Forms.DataGridView
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ToggleButton07 As Elegant.Ui.ToggleButton
    Friend WithEvents btnGrpCallback As Elegant.Ui.ButtonGroup
    Friend WithEvents ToggleButton21 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton22 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton27 As Elegant.Ui.ToggleButton
    Friend WithEvents btnGrpTrans As Elegant.Ui.ButtonGroup
    Friend WithEvents ToggleButton11 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton12 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton17 As Elegant.Ui.ToggleButton
    Friend WithEvents dgViewCallback As System.Windows.Forms.DataGridView
    Friend WithEvents DM_CUSTOMER_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_CUSTOMER_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_TONG_DD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_TONG_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_TONG_TELNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_CONSULT_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_CONSULT_RESULT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_TONG_USER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_TONG_CONTENTS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_CALL_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_HANDLE_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_PREV_TONG_DD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_PREV_TONG_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DM_PREV_TONG_USER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_CUSTOMER_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_CUSTOMER_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_TONG_DD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_TONG_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_TONG_TELNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_CONSULT_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_CONSULT_RESULT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_TONG_USER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_TONG_CONTENTS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_CALL_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_HANDLE_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_PREV_TONG_DD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_PREV_TONG_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DT_PREV_TONG_USER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_CUSTOMER_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_CUSTOMER_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_TONG_DD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_TONG_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_TONG_TELNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_CALL_BACK_RESULT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_CONSULT_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_CONSULT_RESULT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_TONG_USER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_CALL_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_TONG_CONTENTS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC_HANDLE_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
