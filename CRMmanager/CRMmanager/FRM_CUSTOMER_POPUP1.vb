Imports System.Net.Sockets
Imports System.Text

Public Class FRM_CUSTOMER_POPUP1

    Private WithEvents ss As New CRMmanager
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim mIsTransfered As Boolean = False

    Dim mWoopyonNumber As String = ""

    Dim dgTelNocol_DeleteRecord As DataGridViewButtonColumn = New DataGridViewButtonColumn()
    'Dim mIsEnteringNoQueried As Boolean = False
    'Dim mIsCustomerTablePatched As Boolean = False
    Dim actionStatus As ActionStatus = ConstDef.ActionStatus.OpenEmpty

    Public Sub SetActionStatus(ByVal status As ActionStatus)
        Me.actionStatus = status
    End Sub

    Private Sub Call_history_Init()
        '***************** 화면 맨 아래 상담이력 수정 화면 데이터 클리어 시킴****************************************
        On Error Resume Next
        txtDate4.Text = ""   ' 통화일자
        txtTongTime4.Text = "" ' 통화시간
        txtCallType4.Text = "" ' 콜타입
        txtSubCustomerName4.Text = "" '고객명
        chCallBack4.Checked = False  ' 콜백여부
        txtTongNo4.Text = ""
        cboConsultType4.SelectedValue = "XXXX" ' 콜타입
        cboConsultResult4.SelectedValue = "XXXX" ' 콜타입
        txtTongUser4.Text = "" '통화자
        cboCallbackResult4.SelectedValue = "XXXX" ' 콜백처리결과
        txtTongEtcInfo4.Text = "" '기타정보
        txtCCId4.Text = ""  '고객아이디
        'DataGridView2.Columns.Clear()
    End Sub

    Private Sub Customer_info_init()
        On Error Resume Next
        '********************************* 고객기본정보 클리어 시킴 ************************************************
        txtCustomerID.Text = ""
        txtCustomerID.ReadOnly = True
        txtCustomerName.Text = ""
        txtTelInfo1.Text = ""
        txtHP1.Text = ""
        txtFaxNo1.Text = ""

        txtCompany.Text = ""
        txtDepartment.Text = ""
        txtJobTitle.Text = ""
        txtEmail.Text = ""

        cboCustomerType.SelectedValue = "XXXX"
        txtAddress1.Text = ""
        txtEtcInfo1.Text = ""


        '조회전 초기상태에서 상태설정
        chModification1.Text = "고객정보등록"
        chModification1.Checked = False

        cboTongUser.SelectedValue = "XXXX"
        txtUserDef1.Text = ""
        txtUserDef2.Text = ""
    End Sub

    Private Sub Call_Consult_Init()
        On Error Resume Next
        '************************* 상담이력 등록 화면 클리어 ******************************************************
        setComboSelect(cboConsultResult2, 2) 'cboConsultResult2.SelectedIndex = 2 '미처리
        
        setComboSelect(cboConsultType2, 1) 'cboConsultType2.SelectedIndex = 1 '일반상담
        setComboSelect(cboHandleType2, 1) 'cboHandleType2.SelectedIndex = 1 '보통0

        If (actionStatus = ConstDef.ActionStatus.PopUpOutBound) Then
            setComboSelect(cboCallType2, 2) 'cboCallType2.SelectedIndex = 2 '아웃바운드
        Else
            setComboSelect(cboCallType2, 1) 'cboCallType2.SelectedIndex = 1 '인바운드
        End If

        txtDate2.Text = ""
        txtTongTime2.Text = ""
        txtTongUser2.Text = ""
        chCallBack2.Checked = False
        txtTongEtcInfo2.Text = ""

        mIsTransfered = False
        '외부업무등록
        dpt333.Value = Format(Now, "yyyy-MM-dd")

        CB_Set2(drpHour3, "datetime", 0, 23, 1, "")
        CB_Set2(drpMin3, "datetime", 0, 55, 5, "")
        drpHour3.Text = "00"
        drpMin3.Text = "00"

        cboCoWorker3.SelectedValue = "XXXX"
        cboWorkReason3.SelectedValue = "XXXX"
        txtWorkArea3.Text = ""
        txtWorkContents3.Text = ""
        '이관담당자
        cboDamdangja.SelectedValue = "XXXX"

    End Sub

    Public Sub gsInit()
        Try
            Call Customer_info_init()
            Call Call_history_Init()
            If (actionStatus <> ConstDef.ActionStatus.PopUpNoUser _
                And actionStatus <> ConstDef.ActionStatus.PopUpUserExist) Then
                Call Call_Consult_Init()
            End If
            Call switchFocus(PANEL_FOCUS.NONE)
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
        End Try

    End Sub


    Public Sub switchFocus(ByVal focus As PANEL_FOCUS)
        Call WriteLog("switchFocus PANEL_FOCUS=" & focus)
        Select Case focus
            Case PANEL_FOCUS.CUSTOMER_INFO
                blinkFocus(gbCustomerInfo)
                gbConsultInfo.BackColor = System.Drawing.SystemColors.Control
                gbCustomerHistory.BackColor = System.Drawing.SystemColors.Control
            Case PANEL_FOCUS.CONSULT_INFO
                gbCustomerInfo.BackColor = System.Drawing.SystemColors.Control
                blinkFocus(gbConsultInfo)
                gbCustomerHistory.BackColor = System.Drawing.SystemColors.Control
            Case PANEL_FOCUS.CONSULT_HISTORY
                gbCustomerInfo.BackColor = System.Drawing.SystemColors.Control
                gbConsultInfo.BackColor = System.Drawing.SystemColors.Control
                blinkFocus(gbCustomerHistory)
            Case PANEL_FOCUS.NONE
                gbCustomerInfo.BackColor = System.Drawing.SystemColors.Control
                gbConsultInfo.BackColor = System.Drawing.SystemColors.Control
                gbCustomerHistory.BackColor = System.Drawing.SystemColors.Control
        End Select
    End Sub


    Private Sub blinkFocus(ByVal sender As System.Object)
        Dim gBox As GroupBox = sender
        gBox.BackColor = Color.MistyRose
    End Sub

    Public Sub setIsTransfer(ByVal isTransfer As Boolean)
        mIsTransfered = isTransfer
    End Sub


    Public Sub gsSelectPopUp()
        Call gsSelect()
        'mIsEnteringNoQueried = True
        btnFindId.Enabled = True

        If (txtCustomerID.Text.Trim = "") Then
            If (actionStatus = ConstDef.ActionStatus.PopUpInBound Or actionStatus = ConstDef.ActionStatus.PopUpOutBound) Then
                actionStatus = ConstDef.ActionStatus.PopUpNoUser
            ElseIf (actionStatus = ConstDef.ActionStatus.OpenEmpty) Then
                actionStatus = ConstDef.ActionStatus.OpenNoUserSearched
            End If
            switchFocus(PANEL_FOCUS.CUSTOMER_INFO)
            chModification1.Focus()
        Else
            If (actionStatus = ConstDef.ActionStatus.PopUpInBound Or actionStatus = ConstDef.ActionStatus.PopUpOutBound) Then
                actionStatus = ConstDef.ActionStatus.PopUpUserExist
            ElseIf (actionStatus = ConstDef.ActionStatus.OpenEmpty) Then
                actionStatus = ConstDef.ActionStatus.OpenUserSearched
            End If
            Call WriteLog("gsSelectPopUp actionStatus=" & actionStatus)
            switchFocus(PANEL_FOCUS.CONSULT_INFO)
            cboConsultType2.Focus()
        End If
    End Sub

    Public Sub gsSelect()

        Try
            Dim SQL As String = ""
            Dim custom_id = "0"
            Dim selectPhoneNumber As String = ""

            selectPhoneNumber = txtEnteringNo.Text

            If selectPhoneNumber.Trim = "" Then
                MsgBox("전화번호를 입력하세요.", MsgBoxStyle.OkOnly, "알림")
                Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            If selectPhoneNumber.Trim.Length < 3 Then
                SQL = ""
            Else

                If selectPhoneNumber.Trim <> "" Then
                    SQL = " SELECT ifnull(max(CUSTOMER_ID),'0') FROM t_customer_telno  WHERE COM_CD ='" & gsCOM_CD & "'"
                    SQL = SQL & " AND TELNO = '" & selectPhoneNumber.Trim.Replace("-", "") & "'"

                    Dim dt1 As DataTable = DoQuery(gsConString, SQL)

                    Dim CNT As String = "0"
                    Dim i As Integer

                    If dt1.Rows.Count > 0 Then

                        For i = 0 To dt1.Rows.Count - 1
                            custom_id = dt1.Rows(i).Item(0).ToString
                        Next
                    Else
                        custom_id = "0"
                    End If
                    dt1 = Nothing
                End If

                '기등록된 경우
                If custom_id <> "0" Then
                    SQL = "SELECT COM_CD,CUSTOMER_ID,CUSTOMER_NM,C_TELNO,"
                    SQL = SQL & "H_TELNO,FAX_NO,CUSTOMER_TYPE,WOO_NO,CUSTOMER_ADDR,CUSTOMER_ETC "
                    SQL = SQL & ",COMPANY, DEPARTMENT, JOB_TITLE, EMAIL, TONG_USER, USER_DEF"
                    SQL = SQL & " FROM T_CUSTOMER where customer_id = " & custom_id
                    SQL = SQL & " LIMIT 1"
                    '결과없는 경우 2차 검색
                Else
                    SQL = "SELECT COM_CD,CUSTOMER_ID,CUSTOMER_NM,C_TELNO"
                    SQL = SQL & ",H_TELNO,FAX_NO,CUSTOMER_TYPE,WOO_NO"
                    SQL = SQL & ",CUSTOMER_ADDR,CUSTOMER_ETC"
                    SQL = SQL & ",COMPANY, DEPARTMENT, JOB_TITLE, EMAIL, TONG_USER, USER_DEF"
                    SQL = SQL & " FROM T_CUSTOMER "
                    If IsHPNumber(selectPhoneNumber.Trim) Then
                        SQL = SQL & " WHERE H_TELNO LIKE '" & selectPhoneNumber.Trim.Replace("-", "") & "%'"
                        SQL = SQL & "    OR C_TELNO LIKE '" & selectPhoneNumber.Trim.Replace("-", "") & "%'"
                    Else
                        SQL = SQL & " WHERE C_TELNO LIKE '" & selectPhoneNumber.Trim.Replace("-", "") & "%'"
                    End If
                    SQL = SQL & " LIMIT 1"
                End If
            End If 'If selectPhoneNumber.Trim.Length < 3 Then

            If SQL <> "" Then

                Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                '************************************ 체크하자
                Dim dt1 As DataTable = DoQuery(gsConString, SQL)

                Call WriteLog("CUSTOMER_POP_UP dt1.Rows.Count[" & dt1.Rows.Count & "]")

                If dt1.Rows.Count > 0 Then
                    Dim I As Integer
                    For I = 0 To dt1.Rows.Count - 1
                        '                       0        1          2            3      4     5        6            7         8            9 
                        ' SQL = "SELECT TOP 1 COM_CD,CUSTOMER_ID,CUSTOMER_NM,C_TELNO,H_TELNO,FAX_NO,CUSTOMER_TYPE,WOO_NO,CUSTOMER_ADDR,CUSTOMER_ETC FROM T_CUSTOMER "

                        txtCustomerID.Text = dt1.Rows(I).Item(1).ToString()
                        txtCustomerName.Text = dt1.Rows(I).Item(2).ToString()

                        txtTelInfo1.Text = dt1.Rows(I).Item(3).ToString.Trim
                        txtHP1.Text = dt1.Rows(I).Item(4).ToString.Trim

                        txtFaxNo1.Text = dt1.Rows(I).Item(5).ToString.Trim.Replace("-", "")

                        Dim customertype As String = dt1.Rows(I).Item(6).ToString.Trim

                        If customertype <> "" Then
                            cboCustomerType.SelectedValue = customertype
                        Else
                            cboCustomerType.SelectedValue = "XXXX"
                        End If

                        Dim woo_no As String = dt1.Rows(I).Item(7).ToString
                        If woo_no.Length = 6 Then
                            mWoopyonNumber = woo_no
                        Else
                            mWoopyonNumber = ""
                        End If
                        txtAddress1.Text = dt1.Rows(I).Item(8).ToString
                        txtEtcInfo1.Text = dt1.Rows(I).Item(9).ToString

                        txtCompany.Text = dt1.Rows(I).Item(10).ToString
                        txtDepartment.Text = dt1.Rows(I).Item(11).ToString
                        txtJobTitle.Text = dt1.Rows(I).Item(12).ToString
                        txtEmail.Text = dt1.Rows(I).Item(13).ToString

                        Dim tongUser As String = dt1.Rows(I).Item(14).ToString.Trim
                        If tongUser <> "" Then
                            cboTongUser.SelectedValue = tongUser
                            cboDamdangja.SelectedValue = tongUser '이관 담당자도 같이 지정해줌
                        Else
                            cboTongUser.SelectedValue = "XXXX"
                        End If

                        Dim userDef As String = dt1.Rows(I).Item(15).ToString.Trim
                        If userDef.Length = 13 Then
                            txtUserDef1.Text = userDef.Substring(0, 6)
                            txtUserDef2.Text = userDef.Substring(6, 7)
                        End If

                        If I = 0 Then Exit For

                    Next

                    dt1 = Nothing

                    '조회상태에서 상태설정
                    chModification1.Text = "고객정보수정"
                    chModification1.Checked = False
                    Call gsSelectTelNo(txtCustomerID.Text.Trim)
                    Call gsSubSelect(txtCustomerID.Text.Trim)
                Else
                    Call WriteLog("CUSTOMER_POP_UP gsSelect MAIN-002 No Data SQL[" & SQL & "]")

                    If IsHPNumber(selectPhoneNumber.Trim) Then
                        txtHP1.Text = selectPhoneNumber.Trim
                    Else
                        txtTelInfo1.Text = selectPhoneNumber.Trim
                    End If
                End If
            Else
                MsgBox("전화번호를 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            End If

            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub FRM_CUSTOMER_POPUP1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call SettoolBar(False, False, False, False, False, True, True)
        Me.Focus()
    End Sub

    Private Sub FRM_CUSTOMER_POPUP1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '이벤트 관련 메모리를 해제하여 이벤트가 두번 실행 되지 않게 한다
        ss = Nothing
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Call selectEnteringNo()
    End Sub

    Private Sub selectEnteringNo()
        '조회
        If txtEnteringNo.Text.Trim = "" Then
            MsgBox("전화번호를 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            Exit Sub
        End If

        Call gsInit()
        Call gsSubSelect("") '하단 클리어
        Call gsSelectPopUp()
    End Sub

    Public Sub gsSubSelect(ByVal customerid As String)
        Try
            Dim SQL As String = "Select CUSTOMER_ID,CUSTOMER_NM "
            SQL = SQL & " ,CONCAT(SUBSTRING(TOND_DD,1,4),'-', SUBSTRING(TOND_DD,5,2) ,'-',SUBSTRING(TOND_DD,7,2)) TONG_DD"
            SQL = SQL & " ,CONCAT(SUBSTRING(TONG_TIME,1,2), ':', SUBSTRING(TONG_TIME,3,2), ':' , SUBSTRING(TONG_TIME,5,2)) TONG_TM"
            SQL = SQL & " ,TONG_TELNO"
            SQL = SQL & " ,CONCAT(CONSULT_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '003' AND S_MENU_CD = CONSULT_TYPE )) consult_type "
            SQL = SQL & " ,CONCAT(CONSULT_RESULT , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '004' AND S_MENU_CD = CONSULT_RESULT )) consult_result "
            SQL = SQL & " ,TONG_USER,TONG_CONTENTS "
            SQL = SQL & " ,CONCAT(CALL_TYPE ,'.', (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '005' AND S_MENU_CD = CALL_TYPE )) call_type "

            SQL = SQL & " ,CALL_BACK_YN CALL_BACK_YN"
            SQL = SQL & " ,CONCAT(CALL_BACK_RESULT ,'.', (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '014' AND S_MENU_CD = CALL_BACK_RESULT )) CALL_BACK_RESULT "
            SQL = SQL & " ,CONCAT(HANDLE_TYPE ,'.', (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '012' AND S_MENU_CD = HANDLE_TYPE )) HANDLE_TYPE "

            SQL = SQL & " FROM T_CUSTOMER_HISTORY "
            SQL = SQL & " WHERE COM_CD ='" & gsCOM_CD & "'"

            If customerid.Trim = "" Then
                SQL = SQL & " AND CUSTOMER_ID = 0"
            Else
                SQL = SQL & " AND CUSTOMER_ID = " & customerid
            End If


            SQL = SQL & " ORDER BY TOND_DD DESC, TONG_TIME DESC "

            '************************************ 체크하자
            DataGridView2.DataSource = DoQuery(gsConString, SQL)

            Call WriteLog("FRM_CUSTOMER : DataGridView2.Columns=" & DataGridView2.Columns.Count)

            '조회된 첫번째건을 보여줌: 상세조회나 조회정보가 없는 경우를 제외하고
            If Not (actionStatus = ConstDef.ActionStatus.PopUpDetail _
                Or actionStatus = ConstDef.ActionStatus.OpenNoUserSearched _
                Or actionStatus = ConstDef.ActionStatus.PopUpNoUser) Then
                Call setSubDetailByGridCell(0)
            End If


        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)

        End Try
    End Sub

    Public Sub gsSelectTelNo(ByVal customerid As String)

        Try
            Dim SQL As String = "Select TELNO "
            SQL = SQL & " FROM T_CUSTOMER_TELNO "
            SQL = SQL & " WHERE COM_CD ='" & gsCOM_CD & "'"
            SQL = SQL & " AND CUSTOMER_ID = " & customerid
            SQL = SQL & " ORDER BY TELNO "

            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '************************************ 체크하자
            Dim dt1 As DataTable = DoQuery(gsConString, SQL)
            dgTelNo.DataSource = Nothing

            With dgTelNo
                .Columns.Clear()
                .DataSource = dt1
                .Columns.Item(0).FillWeight = 20
                .Columns.Item(0).Width = 120
                .Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns.Item(0).ToolTipText = .Columns.Item(0).ToString
                Call WriteLog("FRM_CUSTOMER_POPUP : dgTelNo.Columns=" & .Columns.Count)
                'dgTelNo.EditMode = DataGridViewEditMode.EditProgrammatically

                'dgTelNocol_DeleteRecord.UseColumnTextForButtonValue = True
                'dgTelNocol_DeleteRecord.Text = "삭제"
                'dgTelNocol_DeleteRecord.Resizable = DataGridViewTriState.False
                'dgTelNocol_DeleteRecord.FlatStyle = FlatStyle.Standard
                'dgTelNocol_DeleteRecord.HeaderText = ""
                'dgTelNocol_DeleteRecord.Width = 50
                'dgTelNo.Columns.Insert(1, dgTelNocol_DeleteRecord)
            End With

            dt1 = Nothing
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub


    Public Sub gsFormExit()
        Try
            Me.Close()
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":" & ex.ToString)
        End Try
    End Sub

    Private Sub InitOnLoad()
        Try
            If chModification1.Checked = True Then
                Call Control_disable(True)
            Else
                Call Control_disable(False)
            End If

            If DBConReadYn = "N" Then
                Call ReadXmlInfo()
            End If

            pnlTongUser.Visible = gbUseTongUser
            pnlUserDef.Visible = gbUseUserDef
            gbTelNoList.Top = If(gbUseUserDef, pnlUserDef.Bottom, pnlUserDef.Top)
            'txtTongUser4.Text = gsUSER_ID & "." & gsUSER_NM

            '******************************************* 고객 유형 입력 ***********************************************************
            Dim SQL_TEMP As String = Find_Query("006")
            Dim dt1 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboCustomerType.DataSource = dt1
            cboCustomerType.DisplayMember = dt1.Columns(0).ToString
            cboCustomerType.ValueMember = dt1.Columns(1).ToString

            setComboSelect(cboCustomerType, 0) 'cboCustomerType.SelectedIndex = 0 '3 '일반고객
            dt1 = Nothing


            '************************************** 상담결과 입력 *********************************************
            SQL_TEMP = Find_Query("004")
            Dim dt2 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboConsultResult2.DataSource = dt2
            cboConsultResult2.DisplayMember = dt2.Columns(0).ToString
            cboConsultResult2.ValueMember = dt2.Columns(1).ToString

            setComboSelect(cboConsultResult2, 2) 'cboConsultResult2.SelectedIndex = 2 '미처리

            dt2 = Nothing

            '************************************** 상담유형 입력 *********************************************
            SQL_TEMP = Find_Query("003")
            Dim dt3 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboConsultType2.DataSource = dt3
            cboConsultType2.DisplayMember = dt3.Columns(0).ToString
            cboConsultType2.ValueMember = dt3.Columns(1).ToString

            setComboSelect(cboConsultType2, 1) 'cboConsultType2.SelectedIndex = 1 '일반상담
            dt3 = Nothing

            '************************************** 콜타입입력 *********************************************
            SQL_TEMP = Find_Query("005")
            Dim dt4 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboCallType2.DataSource = dt4
            cboCallType2.DisplayMember = dt4.Columns(0).ToString
            cboCallType2.ValueMember = dt4.Columns(1).ToString

            setComboSelect(cboCallType2, 1) 'cboCallType2.SelectedIndex = 1 '인바운드
            dt4 = Nothing

            '******************************************* 처리 유형 입력 ***********************************************************
            SQL_TEMP = Find_Query("012")
            Dim dt6 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboHandleType2.DataSource = dt6
            cboHandleType2.DisplayMember = dt6.Columns(0).ToString
            cboHandleType2.ValueMember = dt6.Columns(1).ToString

            setComboSelect(cboHandleType2, 1) 'cboHandleType2.SelectedIndex = 1 '보통
            dt6 = Nothing


            '************************************** 상담결과 입력 *********************************************
            SQL_TEMP = Find_Query("004")
            Dim dt7 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboConsultResult4.DataSource = dt7
            cboConsultResult4.DisplayMember = dt7.Columns(0).ToString
            cboConsultResult4.ValueMember = dt7.Columns(1).ToString

            cboConsultResult4.SelectedIndex = 0 '3 '미처리
            dt7 = Nothing

            '************************************** 상담유형 입력 *********************************************
            SQL_TEMP = Find_Query("003")
            Dim dt8 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboConsultType4.DataSource = dt8
            cboConsultType4.DisplayMember = dt8.Columns(0).ToString
            cboConsultType4.ValueMember = dt8.Columns(1).ToString

            cboConsultType4.SelectedIndex = 0 '1 '일반상담
            dt8 = Nothing

            '************************************** 콜타입입력 *********************************************
            'SQL_TEMP = Find_Query("005")
            'Dim dt9 As DataTable = DoQuery(gsConString, SQL_TEMP)


            'cboCallType4.DataSource = dt9
            'cboCallType4.DisplayMember = dt9.Columns(0).ToString
            'cboCallType4.ValueMember = dt9.Columns(1).ToString

            'cboCallType4.SelectedIndex = 0
            'dt9 = Nothing

            'cboCallType4.SelectedValue = 0


            '******************************************* 처리유형 입력 ***********************************************************
            SQL_TEMP = Find_Query("012")
            Dim dt10 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboHandleType4.DataSource = dt10
            cboHandleType4.DisplayMember = dt10.Columns(0).ToString
            cboHandleType4.ValueMember = dt10.Columns(1).ToString

            cboHandleType4.SelectedIndex = 0
            dt10 = Nothing

            '******************************************* 담당자 입력 ***********************************************************
            SQL_TEMP = "select '' user_name  ,'XXXX' user_id  union all select concat(user_id , '.' , user_nm) user_name , user_id user_id from t_user where com_cd ='" & gsCOM_CD & "'"
            Dim dt11 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboDamdangja.DataSource = dt11
            cboDamdangja.DisplayMember = dt11.Columns(0).ToString
            cboDamdangja.ValueMember = dt11.Columns(1).ToString

            cboDamdangja.SelectedIndex = 0
            dt11 = Nothing
            '******************************************* 고객약속등록.수행자 ***********************************************************
            Dim dt12 As DataTable = DoQuery(gsConString, SQL_TEMP)
            cboCoWorker3.DataSource = dt12
            cboCoWorker3.DisplayMember = dt12.Columns(0).ToString
            cboCoWorker3.ValueMember = dt12.Columns(1).ToString

            cboCoWorker3.SelectedIndex = 0

            dt12 = Nothing

            '******************************************* 콜백처리결과 입력 ***********************************************************
            SQL_TEMP = Find_Query("014")
            Dim dt13 As DataTable = DoQuery(gsConString, SQL_TEMP)

            cboCallbackResult4.DataSource = dt13
            cboCallbackResult4.DisplayMember = dt13.Columns(0).ToString
            cboCallbackResult4.ValueMember = dt13.Columns(1).ToString

            cboCallbackResult4.SelectedIndex = 0
            dt13 = Nothing

            '******************************************* 고객정보 담당자 ***********************************************************
            Dim dt14 As DataTable = DoQuery(gsConString, SQL_TEMP)
            cboTongUser.DataSource = dt14
            cboTongUser.DisplayMember = dt14.Columns(0).ToString
            cboTongUser.ValueMember = dt14.Columns(1).ToString

            cboTongUser.SelectedIndex = 0

            dt14 = Nothing

            dpt333.Value = Format(Now, "yyyy-MM-dd")

            CB_Set2(drpHour3, "datetime", 0, 23, 1, "")
            CB_Set2(drpMin3, "datetime", 0, 55, 5, "")
            drpHour3.Text = "00"
            drpMin3.Text = "00"


            '**************************************외근사유 입력 *********************************************
            Dim SQL_TEMP1 As String = Find_Query("007")
            Dim dt15 As DataTable = DoQuery(gsConString, SQL_TEMP1)

            cboWorkReason3.DataSource = dt15
            cboWorkReason3.DisplayMember = dt15.Columns(0).ToString
            cboWorkReason3.ValueMember = dt15.Columns(1).ToString
            cboWorkReason3.SelectedIndex = 0

            dt15 = Nothing


            Call WriteLog(Me.Name.ToString & " Popup Load :gsInit ")
            'Call gsInit()
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " Popup Load : " & ex.ToString)
        End Try
    End Sub

    Private Sub FRM_CUSTOMER_POPUP1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''

    End Sub

    Private Sub btnZipCode1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZipCode1.Click
        Try
            FRM_ZIPCODE.ParentFrm = Me
            AddHandler FRM_ZIPCODE.btnConfirm.Click, AddressOf Setting_Address
            FRM_ZIPCODE.ShowDialog()
            FRM_ZIPCODE.Focus()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub
    Private Sub Setting_Address(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim str As String = Me.Tag.ToString
            Dim tmp As String() = str.Split("^")
            If tmp.Length < 3 Then Exit Try
            mWoopyonNumber = tmp(0).Substring(0, 3) & tmp(0).Substring(4, 3)
            txtAddress1.Text = tmp(1).ToString.Trim & IIf(tmp(2).ToString.Trim = "", "", " " & tmp(2).ToString.Trim)
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Public Sub gsDisplayTransferDetail(ByVal tel_no As String, ByVal tong_date As String, ByVal tong_time As String, ByVal isTrans As Boolean)
        Call findCellInDataGridView2(tel_no, tong_date, tong_time, isTrans)
    End Sub

    ''' <summary>
    ''' 데이터가 조회된 중간 dbgrid에 key인 인자값으로 데이터를 찾아 이관인 경우 우측에 뿌리고, 일반상세조회인 경우 하단에 뿌림
    ''' </summary>
    ''' <param name="tel_no"></param>
    ''' <param name="tong_date"></param>
    ''' <param name="tong_time"></param>
    ''' <param name="isTrans"></param>
    ''' <remarks></remarks>
    Private Sub findCellInDataGridView2(ByVal tel_no As String, ByVal tong_date As String, ByVal tong_time As String, ByVal isTrans As Boolean)
        Dim intcount As Integer = 0
        For Each Row As DataGridViewRow In DataGridView2.Rows
            With DataGridView2.Rows(intcount)

                'txtDate4.Text = .Cells(2).Value.ToString   ' 통화일자
                'txtTongTime4.Text = .Cells(3).Value.ToString ' 통화시간
                Call WriteLog("findCellInDataGridView2_1" & .Cells(4).Value.ToString & ":" & .Cells(2).Value.ToString & ":" & .Cells(3).Value.ToString)
                Call WriteLog("findCellInDataGridView2_2" & tel_no & ":" & tong_date & ":" & tong_time)

                If .Cells(4).Value.ToString = tel_no.Trim.Replace("-", "") And .Cells(2).Value.ToString = tong_date.Trim And .Cells(3).Value.ToString = tong_time.Trim Then
                    'Do Something
                    .Selected = True
                    Exit For
                Else
                    intcount += 1
                End If
            End With
        Next Row
        Call WriteLog("intcount=" & intcount)

        If isTrans Then
            Call setTransDetailByGridCell(intcount)
        Else
            Call setSubDetailByGridCell(intcount)
        End If

    End Sub

    Private Sub setSubDetailByGridCell(ByVal idx As Integer)
        If (idx >= DataGridView2.RowCount) Then
            Exit Sub
        End If

        With DataGridView2.Rows(idx)
            txtDate4.Text = .Cells(2).Value.ToString   ' 통화일자
            txtTongTime4.Text = .Cells(3).Value.ToString ' 통화시간

            Dim callType As String = .Cells(9).Value.ToString

            If callType.Contains(".") Then
                Dim str() As String = callType.Split(".")
                'tag_string = tag_string & "$" & str(0)
                txtCallType4.Tag = str(0) ' 콜타입
                txtCallType4.Text = str(1)
            Else
                txtCallType4.Text = callType
            End If

            txtSubCustomerName4.Text = .Cells(1).Value.ToString '고객명

            If .Cells(4).Value.ToString.Trim.Replace("-", "").Length < 9 Then
                txtTongNo4.Text = ""
            Else
                txtTongNo4.Text = gfTelNoTransReturn(.Cells(4).Value.ToString.Trim.Replace("-", ""))
            End If


            Dim consultType As String = .Cells(5).Value.ToString

            If consultType.Contains(".") Then
                Dim str() As String = consultType.Split(".")
                'tag_string = tag_string & "$" & str(0)
                cboConsultType4.SelectedValue = str(0) ' 상담유형
            Else
                'tag_string = tag_string & "$" & "XXXX"
                cboConsultType4.SelectedValue = "XXXX" ' 상담유형
            End If

            Dim consultResult As String = .Cells(6).Value.ToString

            If consultResult.Contains(".") Then
                Dim str() As String = consultResult.Split(".")
                cboConsultResult4.SelectedValue = str(0) ' 상담결과
            Else
                cboConsultResult4.SelectedValue = "XXXX" ' 상담결과
            End If

            txtTongUser4.Text = .Cells(7).Value.ToString '통화자


            Dim callResult As String = .Cells(11).Value.ToString

            If callResult.Contains(".") Then
                Dim str() As String = callResult.Split(".")
                cboCallbackResult4.SelectedValue = str(0) ' 콜백처리결과
            Else
                cboCallbackResult4.SelectedValue = "XXXX"
            End If

            If .Cells(10).Value.ToString = "Y" Then
                chCallBack4.Checked = True  ' 콜백여부
                cboCallbackResult4.Enabled = True
            Else
                chCallBack4.Checked = False  ' 콜백여부
                cboCallbackResult4.Enabled = False
            End If



            Dim handleType As String = .Cells(12).Value.ToString

            If handleType.Contains(".") Then
                Dim str() As String = handleType.Split(".")
                cboHandleType4.SelectedValue = str(0) ' 처리유형
            Else
                cboHandleType4.SelectedValue = "XXXX" ' 처리유형
            End If

            txtTongEtcInfo4.Text = .Cells(8).Value.ToString '기타정보
            txtCCId4.Text = .Cells(0).Value.ToString  '고객아이디

        End With

    End Sub

    Private Sub setTransDetailByGridCell(ByVal idx As Integer)

        If (idx >= DataGridView2.RowCount) Then
            Exit Sub
        End If

        With DataGridView2.Rows(idx)
            txtDate2.Text = .Cells(2).Value.ToString     ' 통화일자
            txtTongTime2.Text = .Cells(3).Value.ToString ' 통화시간

            Dim call_type As String = .Cells(9).Value.ToString

            If call_type.Contains(".") Then
                Dim str() As String = call_type.Split(".")
                cboCallType2.SelectedValue = str(0) ' 콜타입
            Else
                cboCallType2.SelectedValue = "XXXX" ' 콜타입
            End If

            If .Cells(10).Value.ToString = "Y" Then
                chCallBack2.Checked = True   ' 콜백여부
            Else
                chCallBack2.Checked = False  ' 콜백여부
            End If

            Dim Consult_Type As String = .Cells(5).Value.ToString

            If Consult_Type.Contains(".") Then
                Dim str() As String = Consult_Type.Split(".")
                cboConsultType2.SelectedValue = str(0) ' 상담유형
            Else
                cboConsultType2.SelectedValue = "XXXX" ' 상담유형
            End If

            Dim Consult_result As String = .Cells(6).Value.ToString

            If Consult_result.Contains(".") Then
                Dim str() As String = Consult_result.Split(".")
                cboConsultResult2.SelectedValue = str(0) ' 상담결과
            Else
                cboConsultResult2.SelectedValue = ConsultResult_Transfered ' 상담결과'06'
            End If

            Dim handle_type As String = .Cells(12).Value.ToString

            If handle_type.Contains(".") Then
                Dim str() As String = handle_type.Split(".")
                cboHandleType2.SelectedValue = str(0) ' 처리유형
            Else
                cboHandleType2.SelectedValue = "XXXX" ' 처리유형
            End If

            txtTongEtcInfo2.Text = .Cells(8).Value.ToString '기타정보

        End With

    End Sub

    Private Sub DataGridView2_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick

        Try

            If e.RowIndex < 0 Then Exit Try
            Dim i As Integer = e.RowIndex

            Call Call_history_Init()

            Call setSubDetailByGridCell(i)
        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub btnCallHistoryUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCallHistoryUpdate.Click
        '저장
        Try
            Dim sql As String


            If txtCCId4.Text.Trim = "" Then
                MsgBox("수정할 데이터를 상담이력에서 선택하세요.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            sql = "UPDATE T_CUSTOMER_HISTORY SET CALL_TYPE = @callType"
            sql = sql & " ,CALL_BACK_YN = @callBackYn"    ' 콜백여부
            sql = sql & " ,CALL_BACK_RESULT= @callBackResult "   ' 콜백처리결과
            sql = sql & " ,CONSULT_RESULT = @consultResult "   ' 상담결과
            sql = sql & " ,CONSULT_TYPE = @consultType "    ' 상담유형
            sql = sql & " ,TONG_CONTENTS = @tongContents "    ' 통화내용
            sql = sql & " ,TONG_USER = @tongUser "    ' 통화자
            sql = sql & " ,CUSTOMER_NM = @customerNm "    ' 통화자
            sql = sql & " ,TONG_TELNO = @tongTelNo "    ' 통화자
            sql = sql & " ,HANDLE_TYPE = @handleType "    ' 처리유형
            sql = sql & " ,UPDATE_DATE= @updateDate "
            sql = sql & " WHERE COM_CD = @gsComCd"
            sql = sql & " AND CUSTOMER_ID =  @customerId "
            sql = sql & " AND TOND_DD = @tongDD "
            sql = sql & " AND TONG_TIME = @tongTime "

            Dim parameters As Hashtable = New Hashtable

            parameters.Add("@callType", txtCallType4.Tag)
            parameters.Add("@callBackYn", If(chCallBack4.Checked, "Y", "N"))    ' 콜백여부   
            parameters.Add("@callBackResult", cboCallbackResult4.SelectedValue.ToString.Trim.Replace("XXXX", ""))    ' 콜백처리결과
            parameters.Add("@consultResult", cboConsultResult4.SelectedValue.ToString.Trim.Replace("XXXX", ""))    ' 상담결과
            parameters.Add("@consultType", cboConsultType4.SelectedValue.ToString.Trim.Replace("XXXX", ""))    ' 상담유형
            parameters.Add("@tongContents", txtTongEtcInfo4.Text.Trim)    ' 통화내용
            parameters.Add("@tongUser", txtTongUser4.Text.Trim)    ' 통화자  
            parameters.Add("@customerNm", txtSubCustomerName4.Text.Trim)    ' 통화자  
            parameters.Add("@tongTelNo", txtTongNo4.Text.Trim.Replace("-", ""))    ' 통화자  
            parameters.Add("@handleType", cboHandleType4.SelectedValue.ToString.Trim.Replace("XXXX", "0"))    ' 처리유형
            parameters.Add("@updateDate", Format(Now, "yyyyMMddHHmmss"))
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", If(txtCCId4.Text.Trim = "", "0", txtCCId4.Text.Trim))
            parameters.Add("@tongDD", txtDate4.Text.Trim.Replace("-", ""))
            parameters.Add("@tongTime", txtTongTime4.Text.Trim.Replace(":", ""))

            If DoExecuteNonQuery(sql, parameters) < 1 Then
                MsgBox("상담이력 변경에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
                Throw New Exception("상담이력 변경 실패")
            End If

            MsgBox("데이터가 수정되었습니다.", MsgBoxStyle.OkOnly, "알림")

            Call gsSubSelect(txtCCId4.Text.Trim)
            Call Call_history_Init()
            txtCCId4.Text = ""

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
        End Try

    End Sub

    Private Sub btnContentsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContentsSave.Click

        Dim tm As String = ""

        '아웃바운드인 경우 시간을 설정해줌.
        If txtDate2.Text.Trim.Replace("-", "") = "" _
            And txtTongTime2.Text.Trim.Replace(":", "") = "" Then
            If cboCallType2.SelectedIndex = 2 Then '아웃바운드
                tm = Format(Now, "yyyyMMddHHmmss")
                txtDate2.Text = tm.Substring(0, 4) + "-" + tm.Substring(4, 2) + "-" + tm.Substring(6, 2)
                txtTongTime2.Text = tm.Substring(8, 2) + ":" + tm.Substring(10, 2) + ":" + tm.Substring(12, 2)
                txtTongUser2.Text = gsUSER_ID & "." & gsUSER_NM
            End If

        End If

        If CallHistorySave() Then
            Dim frm As FRM_NOTI_MSG = New FRM_NOTI_MSG
            frm.Show("저장되었습니다.")
            System.Threading.Thread.Sleep(1000)
            frm.Hide()
            frm.Close()
            If Not gbNoCloseOnSave Then
                Call gsFormExit()
            Else
                Call gsSubSelect(txtCustomerID.Text.Trim)
            End If
        Else
            ''
        End If
    End Sub

    '***********************상담이력저장*************************************************
    '1. 일자,시간값이 없으면 오류
    '2. 고객ID가 없을때
    '  - 이관이면 정상==>이전단계에서 고객등록오류 처리 <===dead code
    '  - else 일반이면 고객등록 오류
    '3. 상담이력 기등록 여부 확인
    '  - 기등록일때
    '    - 이관온 경우 정상처리
    '    - else 일반인 경우 
    '      - 이관이면 상세조회 포커스이동 <= 이관불가 메시지 추가 필요
    '      - else 일반등록인 경우 오류메시지 후 상세조회 포커스 이동
    '  - else 정상처리
    '4. insert문 생성
    ' - 고객ID없는 경우(이관인 경우) 고객ID=0 <===dead code
    ' - 이관온 경우
    '   - 이관온 시간으로 변경, ***넘어온 이관시간은 이전 통화시간으로 처리
    ' - else 일반인 경우
    '   - 설정 시간을 사용
    ' - 이관인 경우 상담결과='이관처리'
    ' - 고객ID없는 경우 '미등록고객' <===dead code
    ' - 이관온경우 넘어온 이관시간은 이전 통화시간으로 처리

    ' - 입력처리

    ' - 이관처리아닐 경우 하단 상세조회
    '************************************************************************************

    Private Function CallHistorySave(Optional ByVal flag As String = "") As Boolean
        Dim dt1 As DataTable = Nothing
        CallHistorySave = False
        Dim sql As String = ""

        If txtDate2.Text.Trim.Replace("-", "") = "" _
           OrElse txtTongTime2.Text.Trim.Replace(":", "") = "" Then
            MsgBox("저장되지 않았습니다. 통화일자 및 시간이 설정되지 않았습니다.", MsgBoxStyle.OkOnly, "알림")
            Exit Function
        End If

        If txtCustomerID.Text.Trim = "" Then
            MsgBox("확인할 수 없는 고객입니다." & vbCrLf & "고객정보를 신규 등록후 상담이력을 등록하세요.", MsgBoxStyle.OkOnly, "알림")
            Exit Function
        End If

        Try

            sql = " SELECT count(*) FROM T_CUSTOMER_HISTORY "
            sql = sql & " WHERE COM_CD = @gsComCd"
            sql = sql & " AND CUSTOMER_ID = @customerId"
            sql = sql & " AND TOND_DD = @tongDD"
            sql = sql & " AND TONG_TIME = @tongTime"  ' 통화시간
            sql = sql & " AND TONG_USER = @tongUser"  ' 통화유저

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", txtCustomerID.Text.Trim)
            parameters.Add("@tongDD", txtDate2.Text.Trim.Replace("-", ""))
            parameters.Add("@tongTime", txtTongTime2.Text.Trim.Replace(":", ""))
            parameters.Add("@tongUser", txtTongUser2.Text.Trim)

            dt1 = DoQuery(sql, parameters)

            Dim recCount As Integer = 0

            For Each row As DataRow In dt1.Rows
                recCount = row.Item(0)
            Next
            
            If recCount > 0 Then
                If mIsTransfered Then
                    '이관넘어온 경우
                    '이관처리건, 이관넘어온 건은 새로운 통화시간으로 별개건으로 처리하므로, 정상처리함.
                Else
                    '이관건이 아니고 수정하려고 할때
                    MsgBox("이미 데이터가 저장 되어 있습니다." & vbCrLf & "이력 수정은 하단 상세내역에서만 수정하세요.", MsgBoxStyle.OkOnly, "알림")
                    Call gsSubSelect(txtCustomerID.Text.Trim)
                    Exit Function
                End If
            End If

            Dim tm As String = Format(Now, "yyyyMMddHHmmss")

            Dim tongDD As String
            Dim tongTime As String

            If mIsTransfered Then '이관된 건은 이관후 통화시간으로 변경함
                tongDD = tm.Substring(0, 8)    ' 변경된 통화일자
                tongTime = tm.Substring(8, 6)  '  변경된 통화시간
            Else
                tongDD = txtDate2.Text.Trim.Replace("-", "")   ' 통화일자
                tongTime = txtTongTime2.Text.Trim.Replace(":", "")  ' 통화시간
            End If

            Dim callType As String = ""
            If cboCallType2.SelectedIndex >= 0 Then
                callType = cboCallType2.SelectedValue.ToString.Trim.Replace("XXXX", "")  ' 콜타입
            End If

            Dim consultResult As String = ""
            If flag = "trans" Then '이관하는 경우 "이관처리"로 등록
                consultResult = ConsultResult_Transfered '"06" => 상담결과 = "이관처리"
            Else
                consultResult = cboConsultResult2.SelectedValue.ToString.Trim.Replace("XXXX", "")  ' 상담결과
            End If

            Dim consultType As String = ""
            consultType = cboConsultType2.SelectedValue.ToString.Trim.Replace("XXXX", "")

            Dim tongUser As String = ""
            If mIsTransfered Then
                tongUser = gsUSER_ID & "." & gsUSER_NM  ' 통화자(이관받은자)
            Else
                tongUser = txtTongUser2.Text.Trim       ' 통화자
            End If

            Dim handleType As String = ""
            If cboHandleType2.SelectedIndex < 0 Then
                handleType = "0"    ' 처리유형
            Else
                handleType = cboHandleType2.SelectedValue.ToString.Trim.Replace("XXXX", "")  ' 처리유형
            End If

            Dim callBack As String = ""
            If chCallBack2.Checked Then
                callBack = "Y"    ' 콜백여부
            Else
                callBack = "N"    ' 콜백여부
            End If

            Dim prevTongDD As String = ""
            Dim prevTongTime As String = ""
            Dim prevTongUser As String = ""
            Dim transYN As String = ""
            If mIsTransfered Then
                prevTongDD = txtDate2.Text.Trim.Replace("-", "")        ' 이전통화일자
                prevTongTime = txtTongTime2.Text.Trim.Replace(":", "")  ' 이전통화시간
                prevTongUser = txtTongUser2.Text.Trim  ' 통화자
                transYN = "Y"    ' 이관처리여부
            End If

            sql = "INSERT INTO T_CUSTOMER_HISTORY "
            sql = sql & " (COM_CD,CUSTOMER_ID,TOND_DD,TONG_TIME,CALL_TYPE,CONSULT_RESULT, CONSULT_TYPE "
            sql = sql & ", TONG_CONTENTS,TONG_USER,CUSTOMER_NM,TONG_TELNO,HANDLE_TYPE "
            sql = sql & ", CALL_BACK_YN,UPDATE_DATE "
            sql = sql & ", PREV_TONG_DD, PREV_TONG_TIME, PREV_TONG_USER, TRANS_YN) "
            sql = sql & "values "
            sql = sql & " (@gsComCd, @customerId,@tongDD,@tongTime,@callType,@consultResult, @consultType "
            sql = sql & ", @tongContents,@tongUser,@customerNm,@tongTelNo,@handleType "
            sql = sql & ", @callBackYN,@updateDate "
            sql = sql & ", @prevTongDD, @prevTongTime, @prevTongUser, @transYN)"

            Dim paramIns As Hashtable = New Hashtable
            paramIns.Add("@gsComCd", gsCOM_CD)
            paramIns.Add("@customerId   ", txtCustomerID.Text.Trim)
            paramIns.Add("@tongDD       ", tongDD)   ' 통화일자
            paramIns.Add("@tongTime     ", tongTime) ' 통화시간
            paramIns.Add("@callType     ", callType) ' 콜타입
            paramIns.Add("@consultResult", consultResult)  ' 상담결과
            paramIns.Add("@consultType  ", consultType) ' 상담유형
            paramIns.Add("@tongContents ", txtTongEtcInfo2.Text.Trim) ' 통화내용
            paramIns.Add("@tongUser     ", tongUser) ' 통화자
            paramIns.Add("@customerNm   ", txtCustomerName.Text.Trim) ' 고객명
            paramIns.Add("@tongTelNo    ", txtEnteringNo.Text.Trim.Replace("-", ""))    ' 통화전화번호
            paramIns.Add("@handleType   ", handleType)
            paramIns.Add("@callBackYN   ", callBack)
            paramIns.Add("@updateDate   ", Format(Now, "yyyyMMddHHmmss"))
            paramIns.Add("@prevTongDD   ", prevTongDD)
            paramIns.Add("@prevTongTime ", prevTongTime)
            paramIns.Add("@prevTongUser ", prevTongUser)
            paramIns.Add("@transYN      ", transYN)

            DoExecuteNonQuery(sql, paramIns)

            CallHistorySave = True

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " CallHistorySave : " & ex.ToString)
        Finally
            dt1 = Nothing
        End Try
        Return CallHistorySave
    End Function

    Private Sub chModification1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chModification1.CheckedChanged

        If chModification1.Checked = True Then
            Call Control_disable(True)
        Else
            Call Control_disable(False)
        End If

    End Sub

    Public Sub Control_disable(ByVal flag As Boolean)
        On Error Resume Next
        ' 여기서 초기 컨트롤을 초기화 시킨다.
        'txtCustomerName.Enabled = flag
        'txtTelInfo1.Enabled = flag
        'cboCustomerType.Enabled = flag
        btnZipCode1.Enabled = flag

        'txtAddress1.Enabled = flag
        'txtEtcInfo1.Enabled = flag
        btnSave1.Enabled = flag
        btnDel1.Enabled = flag
        btnIni1.Enabled = flag

        btnFindId.Enabled = flag
        btnCustomerTelNo.Enabled = flag

        'txtCustomerID.BackColor = Color.White
        txtCustomerName.ReadOnly = Not flag
        txtTelInfo1.ReadOnly = Not flag
        txtHP1.ReadOnly = Not flag
        txtFaxNo1.ReadOnly = Not flag
        txtCompany.ReadOnly = Not flag
        txtDepartment.ReadOnly = Not flag
        txtJobTitle.ReadOnly = Not flag
        txtEmail.ReadOnly = Not flag

        txtAddress1.ReadOnly = Not flag
        txtEtcInfo1.ReadOnly = Not flag

        txtUserDef1.ReadOnly = Not flag
        txtUserDef2.ReadOnly = Not flag

    End Sub

    Private Sub btnSave1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave1.Click
        Call CustomerInfoSave()
    End Sub

    Private Sub CustomerInfoSave()

        ' 고객정보저장
        Dim SQL As String = ""
        Dim parameters As Hashtable = New Hashtable

        If txtTelInfo1.Text.Trim = "" And txtHP1.Text.Trim = "" Then
            MsgBox("전화 번호를 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            txtTelInfo1.Focus()
            Exit Sub
        End If

        If txtTelInfo1.Text.Trim <> "" Then
            If Not IsNumeric(txtTelInfo1.Text.Trim) Then
                MsgBox("전화 번호를 숫자로 입력하세요.", MsgBoxStyle.OkOnly, "알림")
                txtTelInfo1.Focus()
                Exit Sub
            End If
            If Not txtTelInfo1.Text.Trim.Length >= 8 Then
                MsgBox("전화번호가 잘못된 유형입니다. 다시 확인하시고 입력하세요.", MsgBoxStyle.OkOnly, "알림")
                txtTelInfo1.Focus()
                Exit Sub
            End If
        End If


        If txtHP1.Text.Trim <> "" Then
            If Not IsNumeric(txtHP1.Text.Trim) Then
                MsgBox("핸드폰 번호를 숫자로 입력하세요.", MsgBoxStyle.OkOnly, "알림")
                txtHP1.Focus()
                Exit Sub
            End If

            Dim tel_no As String = txtHP1.Text.Trim.Substring(0, 3)

            If Not txtTelInfo1.Text.Trim.Length >= 8 _
                And Not (tel_no = "010" Or tel_no = "011" Or tel_no = "016" _
                     Or tel_no = "017" Or tel_no = "018" Or tel_no = "019") Then
                MsgBox("핸드폰 번호가 잘못된 유형입니다. 다시 확인하시고 입력하세요.", MsgBoxStyle.OkOnly, "알림")
                txtHP1.Focus()
                Exit Sub
            End If
        End If

        If txtFaxNo1.Text.Trim <> "" _
            AndAlso Not IsNumeric(txtFaxNo1.Text.Trim) Then
            MsgBox("팩스 번호를 숫자로 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            txtFaxNo1.Focus()
            Exit Sub
        End If

        If txtCustomerName.Text.Trim = "" Then
            MsgBox("고객명을 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            txtCustomerName.Focus()
            Exit Sub
        End If

        Dim isInsert As Boolean = False

        If txtCustomerID.Text.Trim = "" Then       ' 입력
            isInsert = True
            SQL = " INSERT INTO T_CUSTOMER "
            SQL = SQL & "( COM_CD,CUSTOMER_NM,C_TELNO,H_TELNO,FAX_NO,CUSTOMER_TYPE "
            SQL = SQL & ",WOO_NO,CUSTOMER_ADDR,CUSTOMER_ETC, UPDATE_DATE"
            SQL = SQL & ", COMPANY, DEPARTMENT, JOB_TITLE, EMAIL,TONG_USER, USER_DEF ) "
            SQL = SQL & "values "
            SQL = SQL & "(@gsComCd ,@customerNm ,@cTelNo ,@hTelNo ,@faxNo ,@customerType "
            SQL = SQL & ",@wooNo ,@customerAddr ,@customerEtc ,@updateDate "
            SQL = SQL & ",@company ,@department, @jobTitle, @email, @tongUser ,@userDef)"
        Else                                       ' 업데이트
            isInsert = False

            SQL = " UPDATE T_CUSTOMER SET CUSTOMER_NM = @customerNm "
            SQL = SQL & ",C_TELNO=@cTelNo "
            SQL = SQL & ",H_TELNO=@hTelNo "

            SQL = SQL & ",FAX_NO=@faxNo"
            SQL = SQL & ",CUSTOMER_TYPE=@customerType " ' CUSTOMER TYPE
            SQL = SQL & ",WOO_NO=@wooNo"
            SQL = SQL & ",CUSTOMER_ADDR=@customerAddr"
            SQL = SQL & ",CUSTOMER_ETC=@customerEtc"
            SQL = SQL & ",UPDATE_DATE=@updateDate"
            SQL = SQL & ",COMPANY=@company"
            SQL = SQL & ",DEPARTMENT=@department"
            SQL = SQL & ",JOB_TITLE=@jobTitle"
            SQL = SQL & ",EMAIL=@email"
            '옵션지정부분
            SQL = SQL & ",TONG_USER=@tongUser" ' TONG_USER
            SQL = SQL & ",USER_DEF=@userDef"
            SQL = SQL & " WHERE COM_CD=@gsComCd"
            SQL = SQL & "   AND CUSTOMER_ID=@customerId"

            parameters.Add("@customerId", txtCustomerID.Text.Trim)
        End If

        Dim cTelNo As String = ""
        If txtTelInfo1.Text.Trim <> "" And txtTelInfo1.Text.Trim.Length >= 8 Then
            cTelNo = txtTelInfo1.Text.Trim
        End If

        Dim hTelNo As String = ""
        If txtHP1.Text.Trim <> "" And txtHP1.Text.Trim.Length >= 8 Then
            hTelNo = txtHP1.Text.Trim
        End If

        Dim customerType As String = ""
        If cboCustomerType.SelectedIndex >= 0 Then
            customerType = cboCustomerType.SelectedValue.ToString.Replace("XXXX", "") ' CUSTOMER TYPE
        End If

        '옵션지정부분
        Dim tongUser As String = ""
        If cboTongUser.SelectedIndex >= 0 Then
            tongUser = cboTongUser.SelectedValue.ToString.Replace("XXXX", "") ' TONG_USER
        End If

        parameters.Add("@gsComCd", gsCOM_CD)
        parameters.Add("@customerNm", txtCustomerName.Text.Trim)
        parameters.Add("@cTelNo", cTelNo)
        parameters.Add("@hTelNo", hTelNo)
        parameters.Add("@faxNo", txtFaxNo1.Text.Trim)
        parameters.Add("@customerType", customerType)
        parameters.Add("@wooNo", mWoopyonNumber.Trim)
        parameters.Add("@customerAddr", txtAddress1.Text.Trim)
        parameters.Add("@customerEtc", txtEtcInfo1.Text.Trim)
        parameters.Add("@updateDate", Format(Now, "yyyyMMddHHmmss"))
        parameters.Add("@company", txtCompany.Text.Trim)
        parameters.Add("@department", txtDepartment.Text.Trim)
        parameters.Add("@jobTitle", txtJobTitle.Text.Trim)
        parameters.Add("@email", txtEmail.Text.Trim)
        parameters.Add("@tongUser", tongUser)
        parameters.Add("@userDef", txtUserDef1.Text.Trim & txtUserDef2.Text.Trim)


        Try
            If DoExecuteNonQuery(SQL, parameters) < 1 Then
                MsgBox("고객정보 등록에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
                Throw New Exception("고객정보 등록 실패")
            End If

            If isInsert Then
                MsgBox("고객정보가 등록되었습니다.", MsgBoxStyle.OkOnly, "알림")
            Else
                MsgBox("고객정보가 변경되었습니다.", MsgBoxStyle.OkOnly, "알림")
            End If
            Call gsSelectPopUp()
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":" & ex.ToString)
        End Try
    End Sub

    Private Sub btnDel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel1.Click
        '고객정보삭제
        Try
            If txtCustomerID.Text.Trim = "" Then
                MsgBox("삭제할 고객정보를 선택하세요.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            '삭제
            If MessageBox.Show("선택한 고객정보를 삭제하시겠습니까?", "고객정보삭제", _
                               MessageBoxButtons.OKCancel, _
                                Nothing, _
                                MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
                Exit Sub
            End If

            Dim SQL As String = " DELETE FROM T_CUSTOMER WHERE COM_CD = @gsComCd AND CUSTOMER_ID = @customerId"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", txtCustomerID.Text.Trim)

            If DoExecuteNonQuery(SQL, parameters) < 1 Then
                MsgBox("고객정보 삭제에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
                Throw New Exception("고객정보 삭제 실패")
            End If

            MsgBox("고객정보가 삭제되었습니다.", MsgBoxStyle.OkOnly, "알림")
            Call gsSelect()
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":" & ex.ToString)
        End Try
    End Sub

    Private Sub info_trans()


        If cboDamdangja.SelectedValue = "XXXX" Or cboDamdangja.SelectedIndex < 0 Then
            MsgBox("대상자를 선택하세요.", MsgBoxStyle.OkOnly, "알림")
            cboDamdangja.Focus()
            Exit Sub
        End If

        '전달
        If txtEnteringNo.Text.Trim = "" Then
            MsgBox("전달할 전화번호가 없습니다.", MsgBoxStyle.OkOnly, "알림")
            txtEnteringNo.Focus()
            Exit Sub
        ElseIf txtEnteringNo.Text.Trim.Length < 9 Then
            MsgBox("전달할 전화번호를 정확히 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            txtEnteringNo.Focus()
            Exit Sub
        End If

        If txtCustomerID.Text.Trim = "" Then
            MsgBox("신규 고객이거나 전달할 고객 정보가 없습니다.고객을 먼저 등록후 데이터를 이관하세요.", MsgBoxStyle.OkOnly, "알림")
            Exit Sub
        End If

        Try
            clientSocket.Connect(gsSocketIP, CLng(gsSocketPort))

            Dim serverStream As NetworkStream = clientSocket.GetStream()

            Dim outStreamString As String = ""
            If mIsTransfered Then '이관된 건은 이관후 통화시간으로 변경함
                Dim tm As String = Format(Now, "yyyyMMddHHmmss")
                Dim tong_date As String = tm.Substring(0, 4) + "-" + tm.Substring(4, 2) + "-" + tm.Substring(6, 2)
                Dim tong_time As String = tm.Substring(8, 2) + ":" + tm.Substring(10, 2) + ":" + tm.Substring(12, 2)
                outStreamString = _
                "22&" & txtEnteringNo.Text.Trim _
                      & "&" & gsUSER_ID _
                      & "&" & cboDamdangja.SelectedValue.ToString _
                      & "&" & tong_date _
                      & "&" & tong_time    ' 변경된 통화일자/시간
            Else
                outStreamString = _
                "22&" & txtEnteringNo.Text.Trim _
                      & "&" & gsUSER_ID _
                      & "&" & cboDamdangja.SelectedValue.ToString _
                      & "&" & txtDate2.Text.Trim _
                      & "&" & txtTongTime2.Text.Trim
            End If


            '22&전화번호&유저아이&대상자아이디
            Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(outStreamString)
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":" & ex.ToString)
        End Try

        Try
            clientSocket.Close()
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":" & ex.ToString)
        End Try

        Try
            'Call CustomerInfoSave()  고객정보를 저장할 이유가 없잔여
            If CallHistorySave("trans") Then
                Dim frm As FRM_NOTI_MSG = New FRM_NOTI_MSG
                frm.Show("이관되었습니다.")
                System.Threading.Thread.Sleep(1000)
                frm.Hide()
                frm.Close()
                Call gsFormExit()
            End If

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub btnTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrans.Click
        Call info_trans()
    End Sub

    ''' <summary>
    ''' 수행자, 일시만 필수 나머지는 선택항목
    ''' 수행자는 자기자신이 디폴트
    ''' 고객정보를 추가
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave3.Click

        Dim temp As String
        Dim dt As DataTable = Nothing

        Try

            If txtCustomerID.Text.Trim = "" Then
                MsgBox("확인할 수 없는 고객입니다." & vbCrLf & "고객정보를 신규 등록후 예약을 등록하세요.", MsgBoxStyle.OkOnly, "알림")
                txtCustomerID.Focus()
                Exit Sub
            End If

            If cboCoWorker3.SelectedValue = "XXXX" Or cboCoWorker3.SelectedIndex < 0 Then
                MsgBox("대상자를 선택하세요.", MsgBoxStyle.OkOnly, "알림")
                cboCoWorker3.Focus()
                Exit Sub
            End If

            'If cboWorkReason3.SelectedValue = "XXXX" Or cboWorkReason3.SelectedIndex < 0 Then
            '    MsgBox("약속사유를 선택하세요.", MsgBoxStyle.OkOnly, "알림")
            '    cboWorkReason3.Focus()
            '    Exit Sub
            'End If


            '전달
            'If txtWorkArea3.Text.Trim = "" Then
            '    MsgBox("약속장소를 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            '    txtWorkArea3.Focus()
            '    Exit Sub
            'ElseIf txtWorkContents3.Text.Trim = "" Then
            '    MsgBox("업무 세부내용을 입력하세요.", MsgBoxStyle.OkOnly, "알림")
            '    txtWorkContents3.Focus()
            '    Exit Sub
            'End If

            '같은시간대 동일인이 등록한 약속이 있는지 확인
            temp = "SELECT count(S_START_TIME) From t_schedule  " & _
                   " Where COM_CD=@gsComCd" & _
                   " AND S_START_TIME=@sStartTime" & _
                   " AND REGISTRANT LIKE @registrant " & _
                   " AND S_COMPANY_COWORKER LIKE @sCompanyCoWorker " & _
                   " AND SHARING_TYPE='O'"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@sStartTime", dpt333.Text.ToString.Replace("-", "") & drpHour3.Text & drpMin3.Text)
            parameters.Add("@registrant", gsUSER_ID & ".%")
            parameters.Add("@sCompanyCoWorker", "%" & cboCoWorker3.SelectedIndex.ToString & "%")

            dt = MiniCTI.DoQuery(temp, parameters)

            Dim workReason As String = ""
            If cboWorkReason3.SelectedValue.ToString.Replace("XXXX", "") <> "" Then
                Dim str() As String = cboWorkReason3.SelectedValue.ToString.Split(".")
                workReason = str(0).Trim
            End If

            'title          - '고객약속'
            'desc           - 약속상세
            'workout_reason - 약속사유
            'workout_loc    - 약속장소
            Dim paramIns As Hashtable = New Hashtable

            If dt.Rows(0).Item(0).ToString.Trim = "0" Then

                temp = "Insert into t_schedule " & _
                        " (COM_CD,S_START_TIME" & _
                        ",S_END_TIME" & _
                        ",REGISTRANT, SHARING_TYPE " & _
                        ",S_COMPANY_COWORKER,S_TITLE" & _
                        ",S_DESC,S_WORKOUT_REASON,S_WORKOUT_LOC " & _
                        ",JOB_DONE, CUSTOMER_ID, DELAY_MINUTE) " & _
                        "values " & _
                        " (@gsComCd, @sStartTime" & _
                        ",@sEndTime" & _
                        ",@registrant, @sharingType " & _
                        ",@sCompanyCoWorker,@sTitle" & _
                        ",@sDesc, @sWorkOutReason ,@sWorkOutLoc" & _
                        ",@jobDone ,@customerId ,@delayMinute) "

                paramIns.Add("@gsComCd", gsCOM_CD)
                paramIns.Add("@sStartTime", dpt333.Text.ToString.Replace("-", "") & drpHour3.Text & drpMin3.Text)
                paramIns.Add("@sEndTime", dpt333.Text.ToString.Replace("-", "") & "2359")
                paramIns.Add("@registrant", gsUSER_ID.Trim & "." & gsUSER_NM.Trim)
                paramIns.Add("@sharingType", "O")
                paramIns.Add("@sCompanyCoWorker", cboCoWorker3.SelectedValue.ToString)
                paramIns.Add("@sTitle", "고객약속")
                paramIns.Add("@sDesc", txtWorkContents3.Text.Trim)
                paramIns.Add("@sWorkOutReason", workReason)
                paramIns.Add("@sWorkOutLoc", txtWorkArea3.Text.Trim)
                paramIns.Add("@jobDone", "N")
                paramIns.Add("@customerId", txtCustomerID.Text.Trim)
                paramIns.Add("@delayMinute", gbAlarmInfo.AlarmPeriod)

            Else
                temp = " UPDATE t_schedule SET S_WORKOUT_LOC = @sWorkOutLoc" & _
                       " , S_DESC = @sDesc" & _
                       " , S_WORKOUT_REASON = @sWorkOutReason" & _
                       " Where COM_CD=@gsComCd" & _
                       " AND S_START_TIME=@sStartTime" & _
                       " AND REGISTRANT LIKE @registrant " & _
                       " AND S_COMPANY_COWORKER LIKE @sCompanyCoWorker " & _
                       " AND SHARING_TYPE='O'"

                paramIns.Add("@sWorkOutLoc", txtWorkArea3.Text.Trim)
                paramIns.Add("@sDesc", txtWorkContents3.Text.Trim)
                paramIns.Add("@sWorkOutReason", workReason)
                paramIns.Add("@gsComCd", gsCOM_CD)
                paramIns.Add("@sStartTime", dpt333.Text.ToString.Replace("-", "") & drpHour3.Text & drpMin3.Text)
                paramIns.Add("@registrant", gsUSER_ID & ".%")
                paramIns.Add("@sCompanyCoWorker", "%" & cboCoWorker3.SelectedIndex.ToString & "%")

            End If

            If DoExecuteNonQuery(temp, parameters) < 1 Then
                MsgBox("고객약속 등록에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
                Throw New Exception("고객약속 등록 실패")
            End If

            MsgBox("고객약속이 등록 되었습니다.", MsgBoxStyle.OkOnly, "알림")
        Catch ex As Exception
            Call WriteLog("고객약속 등록 실패:" & ex.Message)
        Finally
            dt = Nothing
        End Try
    End Sub


    Private Sub txtEnteringNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEnteringNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call selectEnteringNo()
        End If
    End Sub

    Private Sub txtTongEtcInfo2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTongEtcInfo2.TextChanged
        If (txtCustomerID.Text.Trim <> "" And txtDate2.Text = "" And gsUseARS = "Y") Then
            Dim tm As String = Format(Now, "yyyyMMddHHmmss")
            txtDate2.Text = tm.Substring(0, 4) + "-" + tm.Substring(4, 2) + "-" + tm.Substring(6, 2)
            txtTongTime2.Text = tm.Substring(8, 2) + ":" + tm.Substring(10, 2) + ":" + tm.Substring(12, 2)
            txtTongUser2.Text = gsUSER_ID & "." & gsUSER_NM
        End If
    End Sub

    Private Sub btnFindId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindId.Click
        Try
            Dim pop As New FRM_FIND_ID_BY_TELNO
            pop.ParentFrm = Me
            pop.setInfo(txtEnteringNo.Text.Trim, txtCustomerName.Text.Trim)
            AddHandler pop.btnConfirm.Click, AddressOf Setting_CustomerId
            pop.ShowDialog()
            pop.Focus()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub Setting_CustomerId(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Dim str As String = Me.Tag.ToString
            Call selectEnteringNo()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub chModification1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chModification1.Click
        '고객정보수정은 
        '1.조회되었으나 정보가 없는 경우, 
        '2.정상조회된 경우, 
        '수정불가인 경우는,
        '1. 메뉴선택으로 오픈 했으나, 고객정보 조회한 적이 없는 경우 
        ' => mIsEnteringNoQueried = false
        ' => ActionStatus = OpenEmpty
        'If (chModification1.Checked = True And mIsEnteringNoQueried = False) Then
        If (chModification1.Checked = True And actionStatus = ConstDef.ActionStatus.OpenEmpty) Then
            MsgBox("고객번호를 조회 후 등록하세요.", MsgBoxStyle.OkOnly, "알림")
            chModification1.Checked = False
        End If

    End Sub

    Private Sub txtEnteringNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnteringNo.TextChanged
        'mIsEnteringNoQueried = False
        btnFindId.Enabled = False
        actionStatus = ConstDef.ActionStatus.OpenEmpty
    End Sub


    Private Sub GroupBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbConsultInfo.Enter, gbCustomerInfo.Enter, gbCustomerHistory.Enter
        Dim gBox As GroupBox = sender

        If gBox.Equals(gbCustomerInfo) Then
            switchFocus(PANEL_FOCUS.CUSTOMER_INFO)
        ElseIf gBox.Equals(gbConsultInfo) Then
            switchFocus(PANEL_FOCUS.CONSULT_INFO)
        ElseIf gBox.Equals(gbCustomerHistory) Then
            switchFocus(PANEL_FOCUS.CONSULT_HISTORY)
        End If
        'For Each mBtn In Me.btnGrpConsult.Controls
        '    If TypeOf mBtn Is Elegant.Ui.ToggleButton Then
        '        Dim mTestBtn As Elegant.Ui.ToggleButton = mBtn
        '        If mTestBtn.Tag = btn.Tag Then
        '            'MsgBox(btn.Tag, MsgBoxStyle.OkOnly, "알림")
        '        Else
        '            mTestBtn.Pressed = False
        '        End If
        '    End If
        'Next
    End Sub

    Private Sub GroupBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbCustomerInfo.Leave, gbCustomerHistory.Leave, gbConsultInfo.Leave
        switchFocus(PANEL_FOCUS.NONE)
    End Sub

    Private Sub btnCustomerTelNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerTelNo.Click
        Try
            Dim pop As New FRM_CUSTOMER_TELNO
            pop.ParentFrm = Me
            pop.setInfo(txtCustomerID.Text, txtCustomerName.Text)
            AddHandler pop.btnConfirm.Click, AddressOf Setting_TelNo
            pop.ShowDialog()
            pop.Focus()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub
    Private Sub Setting_TelNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Call gsSelectTelNo(txtCustomerID.Text.Trim)
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtUserDef1.TextLength >= txtUserDef1.MaxLength Then
            txtUserDef2.Focus()
        End If
    End Sub

    Public Sub New()

        ' 이 호출은 Windows Form 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        InitOnLoad()
    End Sub
End Class