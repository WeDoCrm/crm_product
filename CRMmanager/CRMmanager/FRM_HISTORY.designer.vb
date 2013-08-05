<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_HISTORY
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_HISTORY))
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.CUSTOMER_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TONG_DD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TONG_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUSTOMER_NM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TONG_TELNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUSTOMER_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HANDLE_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CONSULT_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CONSULT_RESULT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CALL_BACK_YN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CALL_BACK_RESULT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TONG_USER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CALL_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TONG_CONTENTS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbxSearch = New System.Windows.Forms.GroupBox
        Me.pnlSelectColumn = New System.Windows.Forms.Panel
        Me.btnGrpConsult = New Elegant.Ui.ButtonGroup
        Me.ToggleButton1 = New Elegant.Ui.ToggleButton
        Me.ToggleButton2 = New Elegant.Ui.ToggleButton
        Me.ToggleButton3 = New Elegant.Ui.ToggleButton
        Me.ToggleButton4 = New Elegant.Ui.ToggleButton
        Me.ToggleButton6 = New Elegant.Ui.ToggleButton
        Me.ToggleButton7 = New Elegant.Ui.ToggleButton
        Me.ToggleButton5 = New Elegant.Ui.ToggleButton
        Me.ToggleButton8 = New Elegant.Ui.ToggleButton
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.pnlDetailSearch = New System.Windows.Forms.Panel
        Me.cboCallBackResult = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpt1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboConsultResult = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboHandleType = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboConsultType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboUser = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbH1 = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboCustomerType = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.cbT1 = New System.Windows.Forms.ComboBox
        Me.dpt2 = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.cbH2 = New System.Windows.Forms.ComboBox
        Me.cbT2 = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.cbxDetailSearch = New Elegant.Ui.CheckBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnSelect = New System.Windows.Forms.Button
        Me.txtSubCustomerName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSubDate = New System.Windows.Forms.TextBox
        Me.txtSubTongTime = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSubTongNo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSubConsultType = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSubTongUser = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSubConsultResult = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSubTongContents = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnDetail = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.txtSubCallBackResult = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtSubHandleType = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtSubCustomerType = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtSubCallbackYN = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.txtSubCallType = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gbxDetailConsult = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.gbxDetailCallInfo = New System.Windows.Forms.GroupBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.gbxDetailCustomer = New System.Windows.Forms.GroupBox
        Me.Label46 = New System.Windows.Forms.Label
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxSearch.SuspendLayout()
        Me.pnlSelectColumn.SuspendLayout()
        Me.btnGrpConsult.SuspendLayout()
        Me.pnlDetailSearch.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbxDetailConsult.SuspendLayout()
        Me.gbxDetailCallInfo.SuspendLayout()
        Me.gbxDetailCustomer.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CUSTOMER_ID, Me.TONG_DD, Me.TONG_TIME, Me.CUSTOMER_NM, Me.TONG_TELNO, Me.CUSTOMER_TYPE, Me.HANDLE_TYPE, Me.CONSULT_TYPE, Me.CONSULT_RESULT, Me.CALL_BACK_YN, Me.CALL_BACK_RESULT, Me.TONG_USER, Me.CALL_TYPE, Me.TONG_CONTENTS})
        Me.DataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView2.Location = New System.Drawing.Point(3, 155)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(872, 333)
        Me.DataGridView2.TabIndex = 80
        '
        'CUSTOMER_ID
        '
        Me.CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID"
        Me.CUSTOMER_ID.HeaderText = "고객ID"
        Me.CUSTOMER_ID.Name = "CUSTOMER_ID"
        Me.CUSTOMER_ID.ReadOnly = True
        Me.CUSTOMER_ID.Width = 80
        '
        'TONG_DD
        '
        Me.TONG_DD.DataPropertyName = "TONG_DD"
        Me.TONG_DD.HeaderText = "통화일자"
        Me.TONG_DD.Name = "TONG_DD"
        Me.TONG_DD.ReadOnly = True
        Me.TONG_DD.Width = 80
        '
        'TONG_TIME
        '
        Me.TONG_TIME.DataPropertyName = "TONG_TIME"
        Me.TONG_TIME.HeaderText = "통화시간"
        Me.TONG_TIME.Name = "TONG_TIME"
        Me.TONG_TIME.ReadOnly = True
        Me.TONG_TIME.Width = 80
        '
        'CUSTOMER_NM
        '
        Me.CUSTOMER_NM.DataPropertyName = "CUSTOMER_NM"
        Me.CUSTOMER_NM.HeaderText = "고객명"
        Me.CUSTOMER_NM.Name = "CUSTOMER_NM"
        Me.CUSTOMER_NM.ReadOnly = True
        '
        'TONG_TELNO
        '
        Me.TONG_TELNO.DataPropertyName = "TONG_TELNO"
        Me.TONG_TELNO.HeaderText = "전화번호"
        Me.TONG_TELNO.Name = "TONG_TELNO"
        Me.TONG_TELNO.ReadOnly = True
        Me.TONG_TELNO.Width = 80
        '
        'CUSTOMER_TYPE
        '
        Me.CUSTOMER_TYPE.DataPropertyName = "CUSTOMER_TYPE"
        Me.CUSTOMER_TYPE.HeaderText = "고객유형"
        Me.CUSTOMER_TYPE.Name = "CUSTOMER_TYPE"
        Me.CUSTOMER_TYPE.ReadOnly = True
        '
        'HANDLE_TYPE
        '
        Me.HANDLE_TYPE.DataPropertyName = "HANDLE_TYPE"
        Me.HANDLE_TYPE.HeaderText = "처리유형"
        Me.HANDLE_TYPE.Name = "HANDLE_TYPE"
        Me.HANDLE_TYPE.ReadOnly = True
        Me.HANDLE_TYPE.Visible = False
        '
        'CONSULT_TYPE
        '
        Me.CONSULT_TYPE.DataPropertyName = "CONSULT_TYPE"
        Me.CONSULT_TYPE.HeaderText = "상담유형"
        Me.CONSULT_TYPE.Name = "CONSULT_TYPE"
        Me.CONSULT_TYPE.ReadOnly = True
        Me.CONSULT_TYPE.Visible = False
        '
        'CONSULT_RESULT
        '
        Me.CONSULT_RESULT.DataPropertyName = "CONSULT_RESULT"
        Me.CONSULT_RESULT.HeaderText = "상담결과"
        Me.CONSULT_RESULT.Name = "CONSULT_RESULT"
        Me.CONSULT_RESULT.ReadOnly = True
        '
        'CALL_BACK_YN
        '
        Me.CALL_BACK_YN.DataPropertyName = "CALL_BACK_YN"
        Me.CALL_BACK_YN.HeaderText = "콜백여부"
        Me.CALL_BACK_YN.Name = "CALL_BACK_YN"
        Me.CALL_BACK_YN.ReadOnly = True
        Me.CALL_BACK_YN.Visible = False
        '
        'CALL_BACK_RESULT
        '
        Me.CALL_BACK_RESULT.DataPropertyName = "CALL_BACK_RESULT"
        Me.CALL_BACK_RESULT.HeaderText = "콜백처리여부"
        Me.CALL_BACK_RESULT.Name = "CALL_BACK_RESULT"
        Me.CALL_BACK_RESULT.ReadOnly = True
        Me.CALL_BACK_RESULT.Visible = False
        '
        'TONG_USER
        '
        Me.TONG_USER.DataPropertyName = "TONG_USER"
        Me.TONG_USER.HeaderText = "통화자"
        Me.TONG_USER.Name = "TONG_USER"
        Me.TONG_USER.ReadOnly = True
        '
        'CALL_TYPE
        '
        Me.CALL_TYPE.DataPropertyName = "CALL_TYPE"
        Me.CALL_TYPE.HeaderText = "콜타입"
        Me.CALL_TYPE.Name = "CALL_TYPE"
        Me.CALL_TYPE.ReadOnly = True
        Me.CALL_TYPE.Visible = False
        '
        'TONG_CONTENTS
        '
        Me.TONG_CONTENTS.DataPropertyName = "TONG_CONTENTS"
        Me.TONG_CONTENTS.HeaderText = "상담내용"
        Me.TONG_CONTENTS.Name = "TONG_CONTENTS"
        Me.TONG_CONTENTS.ReadOnly = True
        '
        'gbxSearch
        '
        Me.gbxSearch.Controls.Add(Me.pnlSelectColumn)
        Me.gbxSearch.Controls.Add(Me.pnlDetailSearch)
        Me.gbxSearch.Controls.Add(Me.cbxDetailSearch)
        Me.gbxSearch.Controls.Add(Me.Label30)
        Me.gbxSearch.Controls.Add(Me.txtSearch)
        Me.gbxSearch.Controls.Add(Me.Label28)
        Me.gbxSearch.Controls.Add(Me.btnExcel)
        Me.gbxSearch.Controls.Add(Me.btnSelect)
        Me.gbxSearch.Location = New System.Drawing.Point(3, 3)
        Me.gbxSearch.Name = "gbxSearch"
        Me.gbxSearch.Size = New System.Drawing.Size(872, 146)
        Me.gbxSearch.TabIndex = 86
        Me.gbxSearch.TabStop = False
        '
        'pnlSelectColumn
        '
        Me.pnlSelectColumn.Controls.Add(Me.btnGrpConsult)
        Me.pnlSelectColumn.Controls.Add(Me.Label33)
        Me.pnlSelectColumn.Controls.Add(Me.Label32)
        Me.pnlSelectColumn.Location = New System.Drawing.Point(5, 103)
        Me.pnlSelectColumn.Name = "pnlSelectColumn"
        Me.pnlSelectColumn.Size = New System.Drawing.Size(862, 37)
        Me.pnlSelectColumn.TabIndex = 230
        '
        'btnGrpConsult
        '
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton1)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton2)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton3)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton4)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton6)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton7)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton5)
        Me.btnGrpConsult.Controls.Add(Me.ToggleButton8)
        Me.btnGrpConsult.Location = New System.Drawing.Point(121, 8)
        Me.btnGrpConsult.Name = "btnGrpConsult"
        Me.btnGrpConsult.Size = New System.Drawing.Size(624, 22)
        Me.btnGrpConsult.TabIndex = 224
        Me.btnGrpConsult.Text = "ButtonGroup1"
        '
        'ToggleButton1
        '
        Me.ToggleButton1.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton1.Id = "44582519-d9c0-4461-8203-818e6106dbd3"
        Me.ToggleButton1.Location = New System.Drawing.Point(0, 0)
        Me.ToggleButton1.Name = "ToggleButton1"
        Me.ToggleButton1.Pressed = True
        Me.ToggleButton1.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton1.TabIndex = 200
        Me.ToggleButton1.Tag = "1"
        Me.ToggleButton1.Text = "고객유형"
        '
        'ToggleButton2
        '
        Me.ToggleButton2.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton2.Id = "4b7ec386-66bb-4d01-a6cb-0232caf8dde0"
        Me.ToggleButton2.Location = New System.Drawing.Point(71, 0)
        Me.ToggleButton2.Name = "ToggleButton2"
        Me.ToggleButton2.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton2.TabIndex = 201
        Me.ToggleButton2.Tag = "2"
        Me.ToggleButton2.Text = "처리유형"
        '
        'ToggleButton3
        '
        Me.ToggleButton3.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton3.Id = "ef6fb719-e261-4a68-ab7e-ba15385d56d7"
        Me.ToggleButton3.Location = New System.Drawing.Point(142, 0)
        Me.ToggleButton3.Name = "ToggleButton3"
        Me.ToggleButton3.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton3.TabIndex = 202
        Me.ToggleButton3.Tag = "3"
        Me.ToggleButton3.Text = "상담유형"
        '
        'ToggleButton4
        '
        Me.ToggleButton4.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton4.Id = "796c42ec-5003-4530-9d25-e43723069631"
        Me.ToggleButton4.Location = New System.Drawing.Point(213, 0)
        Me.ToggleButton4.Name = "ToggleButton4"
        Me.ToggleButton4.Pressed = True
        Me.ToggleButton4.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton4.TabIndex = 206
        Me.ToggleButton4.Tag = "4"
        Me.ToggleButton4.Text = "상담결과"
        '
        'ToggleButton6
        '
        Me.ToggleButton6.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton6.Id = "8d416132-b3c7-4c75-be3e-621feaff5498"
        Me.ToggleButton6.Location = New System.Drawing.Point(284, 0)
        Me.ToggleButton6.Name = "ToggleButton6"
        Me.ToggleButton6.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton6.TabIndex = 205
        Me.ToggleButton6.Tag = "5"
        Me.ToggleButton6.Text = "콜백여부"
        '
        'ToggleButton7
        '
        Me.ToggleButton7.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton7.Id = "b853d181-e2b9-44d5-947d-5681012a3f20"
        Me.ToggleButton7.Location = New System.Drawing.Point(355, 0)
        Me.ToggleButton7.Name = "ToggleButton7"
        Me.ToggleButton7.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton7.TabIndex = 208
        Me.ToggleButton7.Tag = "6"
        Me.ToggleButton7.Text = "콜백처리여부"
        '
        'ToggleButton5
        '
        Me.ToggleButton5.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton5.Id = "9498e10f-6432-48f0-bcb4-49052d220735"
        Me.ToggleButton5.Location = New System.Drawing.Point(426, 0)
        Me.ToggleButton5.Name = "ToggleButton5"
        Me.ToggleButton5.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton5.TabIndex = 207
        Me.ToggleButton5.Tag = "7"
        Me.ToggleButton5.Text = "콜타입"
        '
        'ToggleButton8
        '
        Me.ToggleButton8.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleButton8.Id = "f4cacf88-925e-4835-be94-6d72d21087f9"
        Me.ToggleButton8.Location = New System.Drawing.Point(497, 0)
        Me.ToggleButton8.Name = "ToggleButton8"
        Me.ToggleButton8.Pressed = True
        Me.ToggleButton8.Size = New System.Drawing.Size(71, 20)
        Me.ToggleButton8.TabIndex = 209
        Me.ToggleButton8.Tag = "8"
        Me.ToggleButton8.Text = "상담내용"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(13, 11)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 12)
        Me.Label33.TabIndex = 225
        Me.Label33.Text = "출력항목 선택하기"
        '
        'Label32
        '
        Me.Label32.Image = CType(resources.GetObject("Label32.Image"), System.Drawing.Image)
        Me.Label32.Location = New System.Drawing.Point(1, 11)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(13, 12)
        Me.Label32.TabIndex = 226
        '
        'pnlDetailSearch
        '
        Me.pnlDetailSearch.Controls.Add(Me.cboCallBackResult)
        Me.pnlDetailSearch.Controls.Add(Me.Label7)
        Me.pnlDetailSearch.Controls.Add(Me.Label17)
        Me.pnlDetailSearch.Controls.Add(Me.Label1)
        Me.pnlDetailSearch.Controls.Add(Me.dpt1)
        Me.pnlDetailSearch.Controls.Add(Me.Label2)
        Me.pnlDetailSearch.Controls.Add(Me.cboConsultResult)
        Me.pnlDetailSearch.Controls.Add(Me.Label3)
        Me.pnlDetailSearch.Controls.Add(Me.Label35)
        Me.pnlDetailSearch.Controls.Add(Me.cboHandleType)
        Me.pnlDetailSearch.Controls.Add(Me.Label34)
        Me.pnlDetailSearch.Controls.Add(Me.Label14)
        Me.pnlDetailSearch.Controls.Add(Me.Label27)
        Me.pnlDetailSearch.Controls.Add(Me.Label25)
        Me.pnlDetailSearch.Controls.Add(Me.cboConsultType)
        Me.pnlDetailSearch.Controls.Add(Me.Label5)
        Me.pnlDetailSearch.Controls.Add(Me.cboUser)
        Me.pnlDetailSearch.Controls.Add(Me.Label29)
        Me.pnlDetailSearch.Controls.Add(Me.Label4)
        Me.pnlDetailSearch.Controls.Add(Me.cbH1)
        Me.pnlDetailSearch.Controls.Add(Me.Label15)
        Me.pnlDetailSearch.Controls.Add(Me.cboCustomerType)
        Me.pnlDetailSearch.Controls.Add(Me.Label26)
        Me.pnlDetailSearch.Controls.Add(Me.cbT1)
        Me.pnlDetailSearch.Controls.Add(Me.dpt2)
        Me.pnlDetailSearch.Controls.Add(Me.Label12)
        Me.pnlDetailSearch.Controls.Add(Me.Label24)
        Me.pnlDetailSearch.Controls.Add(Me.cbH2)
        Me.pnlDetailSearch.Controls.Add(Me.cbT2)
        Me.pnlDetailSearch.Controls.Add(Me.Label31)
        Me.pnlDetailSearch.Location = New System.Drawing.Point(5, 43)
        Me.pnlDetailSearch.Name = "pnlDetailSearch"
        Me.pnlDetailSearch.Size = New System.Drawing.Size(862, 62)
        Me.pnlDetailSearch.TabIndex = 229
        '
        'cboCallBackResult
        '
        Me.cboCallBackResult.BackColor = System.Drawing.Color.MintCream
        Me.cboCallBackResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCallBackResult.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cboCallBackResult.FormattingEnabled = True
        Me.cboCallBackResult.Location = New System.Drawing.Point(671, 7)
        Me.cboCallBackResult.Name = "cboCallBackResult"
        Me.cboCallBackResult.Size = New System.Drawing.Size(93, 20)
        Me.cboCallBackResult.TabIndex = 224
        '
        'Label7
        '
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.Location = New System.Drawing.Point(575, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 12)
        Me.Label7.TabIndex = 226
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(587, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 12)
        Me.Label17.TabIndex = 225
        Me.Label17.Text = "콜백처리여부"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "통화일자"
        '
        'dpt1
        '
        Me.dpt1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpt1.Location = New System.Drawing.Point(84, 7)
        Me.dpt1.Name = "dpt1"
        Me.dpt1.Size = New System.Drawing.Size(91, 21)
        Me.dpt1.TabIndex = 42
        Me.dpt1.Value = New Date(2011, 7, 12, 20, 59, 36, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 12)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "~"
        '
        'cboConsultResult
        '
        Me.cboConsultResult.BackColor = System.Drawing.Color.MintCream
        Me.cboConsultResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsultResult.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cboConsultResult.FormattingEnabled = True
        Me.cboConsultResult.Location = New System.Drawing.Point(587, 34)
        Me.cboConsultResult.Name = "cboConsultResult"
        Me.cboConsultResult.Size = New System.Drawing.Size(85, 20)
        Me.cboConsultResult.TabIndex = 50
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(334, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "통화시간"
        '
        'Label35
        '
        Me.Label35.Image = CType(resources.GetObject("Label35.Image"), System.Drawing.Image)
        Me.Label35.Location = New System.Drawing.Point(691, 37)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(13, 12)
        Me.Label35.TabIndex = 209
        '
        'cboHandleType
        '
        Me.cboHandleType.BackColor = System.Drawing.Color.MintCream
        Me.cboHandleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHandleType.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cboHandleType.FormattingEnabled = True
        Me.cboHandleType.Location = New System.Drawing.Point(229, 34)
        Me.cboHandleType.Name = "cboHandleType"
        Me.cboHandleType.Size = New System.Drawing.Size(85, 20)
        Me.cboHandleType.TabIndex = 223
        '
        'Label34
        '
        Me.Label34.Image = CType(resources.GetObject("Label34.Image"), System.Drawing.Image)
        Me.Label34.Location = New System.Drawing.Point(519, 38)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(13, 12)
        Me.Label34.TabIndex = 207
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(357, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "상담유형"
        '
        'Label27
        '
        Me.Label27.Image = CType(resources.GetObject("Label27.Image"), System.Drawing.Image)
        Me.Label27.Location = New System.Drawing.Point(321, 11)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(13, 12)
        Me.Label27.TabIndex = 210
        '
        'Label25
        '
        Me.Label25.Image = CType(resources.GetObject("Label25.Image"), System.Drawing.Image)
        Me.Label25.Location = New System.Drawing.Point(165, 38)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(13, 12)
        Me.Label25.TabIndex = 222
        '
        'cboConsultType
        '
        Me.cboConsultType.BackColor = System.Drawing.Color.MintCream
        Me.cboConsultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsultType.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cboConsultType.FormattingEnabled = True
        Me.cboConsultType.Location = New System.Drawing.Point(410, 34)
        Me.cboConsultType.Name = "cboConsultType"
        Me.cboConsultType.Size = New System.Drawing.Size(85, 20)
        Me.cboConsultType.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(467, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 12)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "~"
        '
        'cboUser
        '
        Me.cboUser.BackColor = System.Drawing.Color.MintCream
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(748, 33)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(85, 20)
        Me.cboUser.TabIndex = 211
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(176, 38)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 12)
        Me.Label29.TabIndex = 221
        Me.Label29.Text = "처리유형"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(704, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "통화자"
        '
        'cbH1
        '
        Me.cbH1.FormattingEnabled = True
        Me.cbH1.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cbH1.Location = New System.Drawing.Point(389, 7)
        Me.cbH1.Name = "cbH1"
        Me.cbH1.Size = New System.Drawing.Size(36, 20)
        Me.cbH1.TabIndex = 44
        Me.cbH1.Text = "00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(533, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 203
        Me.Label15.Text = "상담결과"
        '
        'cboCustomerType
        '
        Me.cboCustomerType.BackColor = System.Drawing.Color.MintCream
        Me.cboCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerType.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cboCustomerType.FormattingEnabled = True
        Me.cboCustomerType.Location = New System.Drawing.Point(66, 34)
        Me.cboCustomerType.Name = "cboCustomerType"
        Me.cboCustomerType.Size = New System.Drawing.Size(85, 20)
        Me.cboCustomerType.TabIndex = 218
        '
        'Label26
        '
        Me.Label26.Image = CType(resources.GetObject("Label26.Image"), System.Drawing.Image)
        Me.Label26.Location = New System.Drawing.Point(344, 38)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(13, 12)
        Me.Label26.TabIndex = 202
        '
        'cbT1
        '
        Me.cbT1.FormattingEnabled = True
        Me.cbT1.Items.AddRange(New Object() {"00", "10", "20", "30", "40", "50", "60"})
        Me.cbT1.Location = New System.Drawing.Point(428, 7)
        Me.cbT1.Name = "cbT1"
        Me.cbT1.Size = New System.Drawing.Size(36, 20)
        Me.cbT1.TabIndex = 45
        Me.cbT1.Text = "99"
        '
        'dpt2
        '
        Me.dpt2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpt2.Location = New System.Drawing.Point(196, 7)
        Me.dpt2.Name = "dpt2"
        Me.dpt2.Size = New System.Drawing.Size(91, 21)
        Me.dpt2.TabIndex = 43
        Me.dpt2.Value = New Date(2011, 7, 12, 20, 59, 36, 0)
        '
        'Label12
        '
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.Location = New System.Drawing.Point(1, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 12)
        Me.Label12.TabIndex = 220
        '
        'Label24
        '
        Me.Label24.Image = CType(resources.GetObject("Label24.Image"), System.Drawing.Image)
        Me.Label24.Location = New System.Drawing.Point(1, 11)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(13, 12)
        Me.Label24.TabIndex = 199
        '
        'cbH2
        '
        Me.cbH2.FormattingEnabled = True
        Me.cbH2.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cbH2.Location = New System.Drawing.Point(484, 7)
        Me.cbH2.Name = "cbH2"
        Me.cbH2.Size = New System.Drawing.Size(36, 20)
        Me.cbH2.TabIndex = 46
        '
        'cbT2
        '
        Me.cbT2.FormattingEnabled = True
        Me.cbT2.Items.AddRange(New Object() {"00", "10", "20", "30", "40", "50", "60"})
        Me.cbT2.Location = New System.Drawing.Point(523, 7)
        Me.cbT2.Name = "cbT2"
        Me.cbT2.Size = New System.Drawing.Size(36, 20)
        Me.cbT2.TabIndex = 47
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(13, 38)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 12)
        Me.Label31.TabIndex = 219
        Me.Label31.Text = "고객유형"
        '
        'cbxDetailSearch
        '
        Me.cbxDetailSearch.Id = "d483f161-c3cb-472e-9076-023f2c51ff9c"
        Me.cbxDetailSearch.Location = New System.Drawing.Point(634, 14)
        Me.cbxDetailSearch.Name = "cbxDetailSearch"
        Me.cbxDetailSearch.Size = New System.Drawing.Size(104, 24)
        Me.cbxDetailSearch.TabIndex = 228
        Me.cbxDetailSearch.Text = "상세검색"
        '
        'Label30
        '
        Me.Label30.Image = CType(resources.GetObject("Label30.Image"), System.Drawing.Image)
        Me.Label30.Location = New System.Drawing.Point(6, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(13, 12)
        Me.Label30.TabIndex = 217
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(387, 16)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(221, 21)
        Me.txtSearch.TabIndex = 216
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(18, 20)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(363, 12)
        Me.Label28.TabIndex = 215
        Me.Label28.Text = "검색 ( 통화번호/직장전화/핸드폰/고객명/회사명/소속/상담내용 )"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(812, 17)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(45, 25)
        Me.btnExcel.TabIndex = 214
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(761, 17)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(45, 25)
        Me.btnSelect.TabIndex = 213
        Me.btnSelect.Text = "조회"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'txtSubCustomerName
        '
        Me.txtSubCustomerName.Location = New System.Drawing.Point(63, 16)
        Me.txtSubCustomerName.Name = "txtSubCustomerName"
        Me.txtSubCustomerName.Size = New System.Drawing.Size(130, 21)
        Me.txtSubCustomerName.TabIndex = 52
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "고객명"
        '
        'txtSubDate
        '
        Me.txtSubDate.Location = New System.Drawing.Point(231, 16)
        Me.txtSubDate.Name = "txtSubDate"
        Me.txtSubDate.Size = New System.Drawing.Size(70, 21)
        Me.txtSubDate.TabIndex = 53
        Me.txtSubDate.Text = "2013-06-12"
        '
        'txtSubTongTime
        '
        Me.txtSubTongTime.Location = New System.Drawing.Point(302, 16)
        Me.txtSubTongTime.Name = "txtSubTongTime"
        Me.txtSubTongTime.Size = New System.Drawing.Size(50, 21)
        Me.txtSubTongTime.TabIndex = 54
        Me.txtSubTongTime.Text = "09:45:12"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(177, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "통화시간"
        '
        'txtSubTongNo
        '
        Me.txtSubTongNo.Location = New System.Drawing.Point(258, 16)
        Me.txtSubTongNo.Name = "txtSubTongNo"
        Me.txtSubTongNo.Size = New System.Drawing.Size(130, 21)
        Me.txtSubTongNo.TabIndex = 55
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(195, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 12)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "/ 통화번호"
        '
        'txtSubConsultType
        '
        Me.txtSubConsultType.Location = New System.Drawing.Point(78, 17)
        Me.txtSubConsultType.Name = "txtSubConsultType"
        Me.txtSubConsultType.Size = New System.Drawing.Size(90, 21)
        Me.txtSubConsultType.TabIndex = 56
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "상담유형"
        '
        'txtSubTongUser
        '
        Me.txtSubTongUser.Location = New System.Drawing.Point(67, 16)
        Me.txtSubTongUser.Name = "txtSubTongUser"
        Me.txtSubTongUser.Size = New System.Drawing.Size(93, 21)
        Me.txtSubTongUser.TabIndex = 58
        Me.txtSubTongUser.Text = "0001.미스터김"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "통화자"
        '
        'txtSubConsultResult
        '
        Me.txtSubConsultResult.Location = New System.Drawing.Point(248, 18)
        Me.txtSubConsultResult.Name = "txtSubConsultResult"
        Me.txtSubConsultResult.Size = New System.Drawing.Size(90, 21)
        Me.txtSubConsultResult.TabIndex = 57
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(191, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "상담결과"
        '
        'txtSubTongContents
        '
        Me.txtSubTongContents.Location = New System.Drawing.Point(420, 21)
        Me.txtSubTongContents.Multiline = True
        Me.txtSubTongContents.Name = "txtSubTongContents"
        Me.txtSubTongContents.Size = New System.Drawing.Size(435, 83)
        Me.txtSubTongContents.TabIndex = 59
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(360, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 105
        Me.Label16.Text = "상담정보"
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(803, 9)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(66, 25)
        Me.btnDetail.TabIndex = 214
        Me.btnDetail.Text = "상세조회"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "c"
        '
        'txtSubCallBackResult
        '
        Me.txtSubCallBackResult.Location = New System.Drawing.Point(248, 41)
        Me.txtSubCallBackResult.Name = "txtSubCallBackResult"
        Me.txtSubCallBackResult.Size = New System.Drawing.Size(90, 21)
        Me.txtSubCallBackResult.TabIndex = 218
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(191, 44)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(53, 12)
        Me.Label37.TabIndex = 219
        Me.Label37.Text = "처리결과"
        '
        'txtSubHandleType
        '
        Me.txtSubHandleType.Location = New System.Drawing.Point(78, 63)
        Me.txtSubHandleType.Name = "txtSubHandleType"
        Me.txtSubHandleType.Size = New System.Drawing.Size(90, 21)
        Me.txtSubHandleType.TabIndex = 221
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(21, 66)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(53, 12)
        Me.Label39.TabIndex = 222
        Me.Label39.Text = "처리유형"
        '
        'txtSubCustomerType
        '
        Me.txtSubCustomerType.Location = New System.Drawing.Point(78, 40)
        Me.txtSubCustomerType.Name = "txtSubCustomerType"
        Me.txtSubCustomerType.Size = New System.Drawing.Size(90, 21)
        Me.txtSubCustomerType.TabIndex = 224
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(21, 43)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(53, 12)
        Me.Label41.TabIndex = 225
        Me.Label41.Text = "고객유형"
        '
        'txtSubCallbackYN
        '
        Me.txtSubCallbackYN.Location = New System.Drawing.Point(248, 65)
        Me.txtSubCallbackYN.Name = "txtSubCallbackYN"
        Me.txtSubCallbackYN.Size = New System.Drawing.Size(90, 21)
        Me.txtSubCallbackYN.TabIndex = 227
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(191, 69)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(53, 12)
        Me.Label43.TabIndex = 228
        Me.Label43.Text = "콜백여부"
        '
        'txtSubCallType
        '
        Me.txtSubCallType.Location = New System.Drawing.Point(248, 88)
        Me.txtSubCallType.Name = "txtSubCallType"
        Me.txtSubCallType.Size = New System.Drawing.Size(90, 21)
        Me.txtSubCallType.TabIndex = 230
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(191, 92)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(41, 12)
        Me.Label45.TabIndex = 231
        Me.Label45.Text = "콜타입"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.gbxSearch)
        Me.FlowLayoutPanel1.Controls.Add(Me.DataGridView2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(11, 1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(880, 672)
        Me.FlowLayoutPanel1.TabIndex = 236
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gbxDetailConsult)
        Me.Panel1.Controls.Add(Me.gbxDetailCallInfo)
        Me.Panel1.Controls.Add(Me.gbxDetailCustomer)
        Me.Panel1.Controls.Add(Me.btnDetail)
        Me.Panel1.Location = New System.Drawing.Point(3, 494)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(877, 169)
        Me.Panel1.TabIndex = 87
        '
        'gbxDetailConsult
        '
        Me.gbxDetailConsult.Controls.Add(Me.txtSubCustomerType)
        Me.gbxDetailConsult.Controls.Add(Me.Label22)
        Me.gbxDetailConsult.Controls.Add(Me.Label10)
        Me.gbxDetailConsult.Controls.Add(Me.Label38)
        Me.gbxDetailConsult.Controls.Add(Me.txtSubConsultType)
        Me.gbxDetailConsult.Controls.Add(Me.txtSubHandleType)
        Me.gbxDetailConsult.Controls.Add(Me.Label44)
        Me.gbxDetailConsult.Controls.Add(Me.Label41)
        Me.gbxDetailConsult.Controls.Add(Me.Label23)
        Me.gbxDetailConsult.Controls.Add(Me.Label39)
        Me.gbxDetailConsult.Controls.Add(Me.Label13)
        Me.gbxDetailConsult.Controls.Add(Me.Label36)
        Me.gbxDetailConsult.Controls.Add(Me.txtSubTongContents)
        Me.gbxDetailConsult.Controls.Add(Me.Label40)
        Me.gbxDetailConsult.Controls.Add(Me.txtSubCallType)
        Me.gbxDetailConsult.Controls.Add(Me.txtSubCallBackResult)
        Me.gbxDetailConsult.Controls.Add(Me.Label16)
        Me.gbxDetailConsult.Controls.Add(Me.Label37)
        Me.gbxDetailConsult.Controls.Add(Me.txtSubConsultResult)
        Me.gbxDetailConsult.Controls.Add(Me.Label43)
        Me.gbxDetailConsult.Controls.Add(Me.Label45)
        Me.gbxDetailConsult.Controls.Add(Me.txtSubCallbackYN)
        Me.gbxDetailConsult.Controls.Add(Me.Label18)
        Me.gbxDetailConsult.Controls.Add(Me.Label42)
        Me.gbxDetailConsult.Location = New System.Drawing.Point(2, 52)
        Me.gbxDetailConsult.Name = "gbxDetailConsult"
        Me.gbxDetailConsult.Size = New System.Drawing.Size(867, 113)
        Me.gbxDetailConsult.TabIndex = 88
        Me.gbxDetailConsult.TabStop = False
        Me.gbxDetailConsult.Text = "상담정보"
        '
        'Label22
        '
        Me.Label22.Image = CType(resources.GetObject("Label22.Image"), System.Drawing.Image)
        Me.Label22.Location = New System.Drawing.Point(7, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 12)
        Me.Label22.TabIndex = 204
        '
        'Label38
        '
        Me.Label38.Image = CType(resources.GetObject("Label38.Image"), System.Drawing.Image)
        Me.Label38.Location = New System.Drawing.Point(7, 67)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(13, 12)
        Me.Label38.TabIndex = 223
        '
        'Label44
        '
        Me.Label44.Image = CType(resources.GetObject("Label44.Image"), System.Drawing.Image)
        Me.Label44.Location = New System.Drawing.Point(177, 92)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(13, 12)
        Me.Label44.TabIndex = 232
        '
        'Label23
        '
        Me.Label23.Image = CType(resources.GetObject("Label23.Image"), System.Drawing.Image)
        Me.Label23.Location = New System.Drawing.Point(348, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(13, 12)
        Me.Label23.TabIndex = 205
        '
        'Label36
        '
        Me.Label36.Image = CType(resources.GetObject("Label36.Image"), System.Drawing.Image)
        Me.Label36.Location = New System.Drawing.Point(177, 45)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(13, 12)
        Me.Label36.TabIndex = 220
        '
        'Label40
        '
        Me.Label40.Image = CType(resources.GetObject("Label40.Image"), System.Drawing.Image)
        Me.Label40.Location = New System.Drawing.Point(7, 44)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(13, 12)
        Me.Label40.TabIndex = 226
        '
        'Label18
        '
        Me.Label18.Image = CType(resources.GetObject("Label18.Image"), System.Drawing.Image)
        Me.Label18.Location = New System.Drawing.Point(177, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(13, 12)
        Me.Label18.TabIndex = 200
        '
        'Label42
        '
        Me.Label42.Image = CType(resources.GetObject("Label42.Image"), System.Drawing.Image)
        Me.Label42.Location = New System.Drawing.Point(177, 69)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(13, 12)
        Me.Label42.TabIndex = 229
        '
        'gbxDetailCallInfo
        '
        Me.gbxDetailCallInfo.Controls.Add(Me.txtSubTongUser)
        Me.gbxDetailCallInfo.Controls.Add(Me.Label11)
        Me.gbxDetailCallInfo.Controls.Add(Me.txtSubTongTime)
        Me.gbxDetailCallInfo.Controls.Add(Me.Label20)
        Me.gbxDetailCallInfo.Controls.Add(Me.txtSubDate)
        Me.gbxDetailCallInfo.Controls.Add(Me.Label8)
        Me.gbxDetailCallInfo.Controls.Add(Me.Label19)
        Me.gbxDetailCallInfo.Location = New System.Drawing.Point(417, 2)
        Me.gbxDetailCallInfo.Name = "gbxDetailCallInfo"
        Me.gbxDetailCallInfo.Size = New System.Drawing.Size(366, 45)
        Me.gbxDetailCallInfo.TabIndex = 233
        Me.gbxDetailCallInfo.TabStop = False
        Me.gbxDetailCallInfo.Text = "통화정보"
        '
        'Label20
        '
        Me.Label20.Image = CType(resources.GetObject("Label20.Image"), System.Drawing.Image)
        Me.Label20.Location = New System.Drawing.Point(12, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(13, 12)
        Me.Label20.TabIndex = 202
        '
        'Label19
        '
        Me.Label19.Image = CType(resources.GetObject("Label19.Image"), System.Drawing.Image)
        Me.Label19.Location = New System.Drawing.Point(166, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(13, 12)
        Me.Label19.TabIndex = 201
        '
        'gbxDetailCustomer
        '
        Me.gbxDetailCustomer.Controls.Add(Me.txtSubCustomerName)
        Me.gbxDetailCustomer.Controls.Add(Me.Label6)
        Me.gbxDetailCustomer.Controls.Add(Me.txtSubTongNo)
        Me.gbxDetailCustomer.Controls.Add(Me.Label46)
        Me.gbxDetailCustomer.Controls.Add(Me.Label9)
        Me.gbxDetailCustomer.Location = New System.Drawing.Point(2, 2)
        Me.gbxDetailCustomer.Name = "gbxDetailCustomer"
        Me.gbxDetailCustomer.Size = New System.Drawing.Size(401, 45)
        Me.gbxDetailCustomer.TabIndex = 233
        Me.gbxDetailCustomer.TabStop = False
        Me.gbxDetailCustomer.Text = "고객정보"
        '
        'Label46
        '
        Me.Label46.Image = CType(resources.GetObject("Label46.Image"), System.Drawing.Image)
        Me.Label46.Location = New System.Drawing.Point(8, 20)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(13, 12)
        Me.Label46.TabIndex = 198
        '
        'FRM_HISTORY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 676)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRM_HISTORY"
        Me.ShowIcon = False
        Me.Text = "상담이력조회"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxSearch.ResumeLayout(False)
        Me.gbxSearch.PerformLayout()
        Me.pnlSelectColumn.ResumeLayout(False)
        Me.pnlSelectColumn.PerformLayout()
        Me.btnGrpConsult.ResumeLayout(False)
        Me.pnlDetailSearch.ResumeLayout(False)
        Me.pnlDetailSearch.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbxDetailConsult.ResumeLayout(False)
        Me.gbxDetailConsult.PerformLayout()
        Me.gbxDetailCallInfo.ResumeLayout(False)
        Me.gbxDetailCallInfo.PerformLayout()
        Me.gbxDetailCustomer.ResumeLayout(False)
        Me.gbxDetailCustomer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents gbxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dpt1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSubCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSubDate As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTongTime As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSubTongNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSubConsultType As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSubTongUser As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSubConsultResult As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSubTongContents As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbT2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbH2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbT1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbH1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dpt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboConsultResult As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cboConsultType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboUser As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cboHandleType As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnGrpConsult As Elegant.Ui.ButtonGroup
    Friend WithEvents ToggleButton1 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton2 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton3 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton4 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton6 As Elegant.Ui.ToggleButton
    Friend WithEvents ToggleButton5 As Elegant.Ui.ToggleButton
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtSubCallBackResult As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtSubHandleType As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtSubCustomerType As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtSubCallbackYN As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtSubCallType As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cbxDetailSearch As Elegant.Ui.CheckBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailSearch As System.Windows.Forms.Panel
    Friend WithEvents pnlSelectColumn As System.Windows.Forms.Panel
    Friend WithEvents gbxDetailCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents gbxDetailConsult As System.Windows.Forms.GroupBox
    Friend WithEvents gbxDetailCallInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cboCallBackResult As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ToggleButton7 As Elegant.Ui.ToggleButton
    Friend WithEvents CUSTOMER_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TONG_DD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TONG_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMER_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TONG_TELNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMER_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HANDLE_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONSULT_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONSULT_RESULT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CALL_BACK_YN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CALL_BACK_RESULT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TONG_USER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CALL_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TONG_CONTENTS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToggleButton8 As Elegant.Ui.ToggleButton
End Class
