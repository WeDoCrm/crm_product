﻿Public Class FRM_MONITOR
    
    Dim isTest As Boolean = False

    Private Sub FRM_MONITOR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call SettoolBar(False, True, False, False, False, True, True)
    End Sub

    Private Sub FRM_MONITOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Call gsInit(SELECT_INIT.CONSULT)
            Call getConsultStatus()
            Call gsSelect(ConsultResult_All, SELECT_TYPE1.NORMAL, dgViewMain)

            Call gsInit(SELECT_INIT.TRANS)
            Call getTransStatus()
            Call gsSelect(ConsultResult_All, SELECT_TYPE1.TRANS, dgViewTrans)

            Call gsInit(SELECT_INIT.CALLBACK)
            Call getCallbackStatus()
            Call gsSelectCallback(3, dgViewCallback)


        Catch ex As Exception
            Call WriteLog("FRM_MONITOR_Load : " & ex.ToString)
        End Try


    End Sub
    Enum SELECT_INIT
        CONSULT = 0
        TRANS = 1
        CALLBACK = 2
    End Enum


    Public Sub gsInit(ByVal selectInit As SELECT_INIT)
        Select Case selectInit
            Case SELECT_INIT.CONSULT
                ToggleButton01.Text = "상담완료( 0 )"
                ToggleButton02.Text = "미처리( 0 )"
                ToggleButton07.Text = "전체( 0 )"
            Case SELECT_INIT.CALLBACK
                ToggleButton21.Text = "처리완료( 0 )"
                ToggleButton22.Text = "미처리( 0 )"
                ToggleButton27.Text = "전체( 0 )"
            Case SELECT_INIT.TRANS
                ToggleButton11.Text = "처리완료( 0 )"
                ToggleButton12.Text = "미처리( 0 )"
                ToggleButton17.Text = "전체( 0 )"

        End Select
    End Sub

    Public Sub getConsultStatus()
        Try
            Dim SQL As String
            Dim strNow As String = Format(Now, "yyyyMMdd")
            SQL = "select consult_result, count(*) "
            SQL = SQL & " from t_customer_history  "
            If isTest = True Then
                SQL = SQL & " where tond_dd like '" & Format(Now, "yyyyMM") & "%' "
            Else
                SQL = SQL & " where tond_dd =  '" & strNow & "' "
            End If

            SQL = SQL & " and com_cd ='" & gsCOM_CD & "'"
            SQL = SQL & " and trans_yn is null"
            SQL = SQL & " and consult_result <> '06'"
            SQL = SQL & " group by consult_result "

            Dim dt1 As DataTable = DoQuery(gsConString, SQL)

            If dt1.Rows.Count > 0 Then
                Dim i As Integer
                Dim iAll As Integer = 0
                For i = 0 To dt1.Rows.Count - 1

                    Dim flag As String = dt1.Rows(i).Item(0).ToString()

                    If flag = ConsultResult_Completed Then '상담완료"01"
                        ToggleButton01.Text = "상담완료( " & dt1.Rows(i).Item(1).ToString() & " )"
                    ElseIf flag = ConsultResult_UnDone Then '미처리"02"
                        ToggleButton02.Text = "미처리(" & dt1.Rows(i).Item(1).ToString() & " )"
                    End If
                    iAll += dt1.Rows(i).Item(1).ToString
                Next
                ToggleButton07.Text = "전체( " & iAll & " )"

            Else
                Call gsInit(SELECT_INIT.CONSULT)
            End If

            dt1 = Nothing

        Catch ex As Exception
            Call gsInit(SELECT_INIT.CONSULT)
            Call WriteLog("getConsultStatus : " & ex.ToString)
        End Try

    End Sub

    Public Sub getTransStatus()
        Try
            Dim SQL As String
            Dim strNow As String = Format(Now, "yyyyMMdd")
            SQL = "SELECT CONSULT_RESULT, COUNT(*) "
            SQL = SQL & " FROM T_CUSTOMER_HISTORY a "
            If isTest = True Then
                SQL = SQL & " WHERE TOND_DD LIKE '" & Format(Now, "yyyyMM") & "%' "
            Else
                SQL = SQL & " WHERE TOND_DD =  '" & strNow & "' "
            End If

            SQL = SQL & " AND COM_CD ='" & gsCOM_CD & "'"
            SQL = SQL & " AND ( TRANS_YN = 'Y'"  '이관건중 처리완료건
            SQL = SQL & "  OR CONSULT_RESULT ='" & ConsultResult_Transfered & "' )"  '이관한 건 '06'

            SQL = SQL & " AND NOT EXISTS (SELECT * FROM T_CUSTOMER_HISTORY b "
            SQL = SQL & " WHERE b.COM_CD = '" & gsCOM_CD & "'"
            SQL = SQL & " AND b.TOND_DD =  '" & strNow & "' "
            SQL = SQL & " AND b.TRANS_YN = 'Y'"
            SQL = SQL & " AND b.PREV_TONG_DD = a.TOND_DD"
            SQL = SQL & " AND b.PREV_TONG_TIME = a.TONG_TIME"
            SQL = SQL & " )"

            SQL = SQL & " group by consult_result "

            Dim dt1 As DataTable = DoQuery(gsConString, SQL)

            If dt1.Rows.Count > 0 Then
                Dim i As Integer
                Dim iAll As Integer = 0
                Dim iCompleted As Integer = 0
                Dim iUndone As Integer = 0
                For i = 0 To dt1.Rows.Count - 1

                    Dim flag As String = dt1.Rows(i).Item(0).ToString()

                    '상담완료는 처리완료로 집계
                    '미처리는 이관대기건+처리미완료건 즉 이관한건'06'-상담완료건'01'
                    '이관시 : 최초건 '06'으로만 처리
                    '이관후 상담시 : 이관건 '01'/'02' transfer="Y"로 하나더 만들어짐.
                    If flag = ConsultResult_Completed Then '상담완료"01"
                        iCompleted = dt1.Rows(i).Item(1).ToString
                        'ElseIf flag = ConsultResult_UnDone Then '미처리"02"
                        '    iUnDone = dt1.Rows(i).Item(1).ToString
                    Else '상담완료가 아닌 건 Null or 02
                        iUndone += dt1.Rows(i).Item(1).ToString
                    End If
                    iAll += dt1.Rows(i).Item(1).ToString
                Next
                ToggleButton12.Text = "미처리(" & iUndone & " )"
                ToggleButton11.Text = "처리완료( " & iCompleted & " )"
                ToggleButton17.Text = "전체( " & iAll & " )"

            Else
                Call gsInit(SELECT_INIT.TRANS)
            End If

            dt1 = Nothing

        Catch ex As Exception
            Call gsInit(SELECT_INIT.TRANS)
            Call WriteLog("getTransStatus : " & ex.ToString)
        End Try

    End Sub


    Public Sub getCallbackStatus()
        Try
            Dim SQL As String
            Dim strNow As String = Format(Now, "yyyyMMdd")
            SQL = "select call_back_result, count(*) "
            SQL = SQL & " from t_customer_history  "
            If isTest = True Then
                SQL = SQL & " where tond_dd like '" & Format(Now, "yyyyMM") & "%' "
            Else
                SQL = SQL & " where tond_dd =  '" & strNow & "' "
            End If
            SQL = SQL & " and com_cd ='" & gsCOM_CD & "'"
            SQL = SQL & " and call_back_yn ='Y'"
            SQL = SQL & " group by call_back_result "

            Dim dt1 As DataTable = DoQuery(gsConString, SQL)

            If dt1.Rows.Count > 0 Then
                Dim i As Integer
                Dim iAll As Integer = 0
                For i = 0 To dt1.Rows.Count - 1

                    Dim flag As String = dt1.Rows(i).Item(0).ToString()

                    If flag = "1" Then '처리완료
                        ToggleButton21.Text = "처리완료( " & dt1.Rows(i).Item(1).ToString() & " )"
                    ElseIf flag = "2" Then '미처리
                        ToggleButton22.Text = "미처리( " & dt1.Rows(i).Item(1).ToString() & " )"
                    End If
                    iAll += dt1.Rows(i).Item(1).ToString
                Next
                ToggleButton27.Text = "전체( " & iAll & " )"

            Else
                Call gsInit(SELECT_INIT.CALLBACK)
            End If

            dt1 = Nothing

        Catch ex As Exception
            Call gsInit(SELECT_INIT.CALLBACK)
            Call WriteLog("getConsultStatus : " & ex.ToString)
        End Try

    End Sub

    Enum SELECT_TYPE1
        NORMAL = 0
        TRANS = 1
    End Enum

    ''' <summary>
    ''' 상담: 이관(consult_result='06')/이관처리건(trans_yn='Y')은 모두 제외
    '''  - 완료: consult_result='01'
    '''  - 미처리:consult_result='02'
    '''  - 전체:
    ''' 
    ''' 이관: 이관(consult_result='06')/이관처리건(trans_yn='Y')을 포함 
    '''  - 완료: trans_yn='Y' and consult
    '''  - 미처리:
    '''  - 전체:
    ''' </summary>
    ''' <param name="sConsultType"></param>
    ''' <param name="selectMode"></param>
    ''' <param name="dgView"></param>
    ''' <remarks></remarks>
    Public Sub gsSelect(ByVal sConsultType As String, ByVal selectMode As SELECT_TYPE1, ByRef dgView As System.Windows.Forms.DataGridView)

        Try
            Dim strNow As String = Format(Now, "yyyyMMdd")
            Dim SQL As String = "Select CUSTOMER_ID,CUSTOMER_NM "
            SQL = SQL & " ,CONCAT(SUBSTRING(TOND_DD,1,4) , '-' , SUBSTRING(TOND_DD,5,2) , '-' , SUBSTRING(TOND_DD,7,2)) TONG_DD "
            SQL = SQL & " ,CONCAT(SUBSTRING(TONG_TIME,1,2) , ':' , SUBSTRING(TONG_TIME,3,2), ':' , SUBSTRING(TONG_TIME,5,2)) TONG_TIME "
            SQL = SQL & " ,TONG_TELNO"
            SQL = SQL & " ,CONCAT(CONSULT_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '003' AND S_MENU_CD = CONSULT_TYPE )) CONSULT_TYPE "
            SQL = SQL & " ,CONCAT(CONSULT_RESULT , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '004' AND S_MENU_CD = CONSULT_RESULT )) CONSULT_RESULT"
            SQL = SQL & " ,TONG_USER,TONG_CONTENTS "
            SQL = SQL & " ,CONCAT(CALL_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '005' AND S_MENU_CD = CALL_TYPE )) CALL_TYPE "
            SQL = SQL & " ,CONCAT(HANDLE_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '012' AND S_MENU_CD = HANDLE_TYPE )) HANDLE_TYPE "

            If selectMode = SELECT_TYPE1.TRANS Then
                SQL = SQL & " ,CONCAT(SUBSTRING(PREV_TONG_DD,1,4) , '-' , SUBSTRING(PREV_TONG_DD,5,2) , '-' , SUBSTRING(PREV_TONG_DD,7,2)) PREV_TONG_DD "
                SQL = SQL & " ,CONCAT(SUBSTRING(PREV_TONG_TIME,1,2) , ':' , SUBSTRING(PREV_TONG_TIME,3,2), ':' , SUBSTRING(PREV_TONG_TIME,5,2)) PREV_TONG_TIME "
                SQL = SQL & " ,PREV_TONG_USER "
            End If

            SQL = SQL & " FROM T_CUSTOMER_HISTORY a"
            SQL = SQL & " WHERE COM_CD = '" & gsCOM_CD & "'"

            If isTest = True Then
                SQL = SQL & " AND tond_dd like '" & Format(Now, "yyyyMM") & "%' "
            Else
                SQL = SQL & " AND tond_dd =  '" & strNow & "' "
            End If

            If selectMode = SELECT_TYPE1.NORMAL Then '상담결과
                SQL = SQL & " AND CONSULT_RESULT <> '06'" '이관처리아닌 경우
                SQL = SQL & " AND TRANS_YN IS NULL " '이관처리아닌 경우

                If sConsultType = "all" Then '상담 - 전체
                    ' all
                Else '상담 - 상담완료/미처리
                    SQL = SQL & " AND CONSULT_RESULT = '" & sConsultType & "'"
                End If

            Else '이관후 상담결과
                SQL = SQL & " AND ( TRANS_YN = 'Y' OR CONSULT_RESULT = '" & ConsultResult_Transfered & "')" '이관처리

                SQL = SQL & " AND NOT EXISTS (SELECT * FROM T_CUSTOMER_HISTORY b "
                SQL = SQL & " WHERE b.COM_CD = '" & gsCOM_CD & "'"

                If isTest = True Then
                    SQL = SQL & " AND b.tond_dd like '" & Format(Now, "yyyyMM") & "%' "
                Else
                    SQL = SQL & " AND b.tond_dd =  '" & strNow & "' "
                End If
                SQL = SQL & " AND b.TRANS_YN = 'Y'"
                SQL = SQL & " AND b.PREV_TONG_DD = a.TOND_DD"
                SQL = SQL & " AND b.PREV_TONG_TIME = a.TONG_TIME"
                SQL = SQL & " )"

                If sConsultType = ConsultResult_All Then   '이관 - 전체
                    ' all
                ElseIf sConsultType = ConsultResult_UnDone Then '이관 - 미처리
                    SQL = SQL & " AND CONSULT_RESULT <> '" & ConsultResult_Completed & "'"
                ElseIf sConsultType = ConsultResult_Completed Then '이관 - 처리완료
                    SQL = SQL & " AND CONSULT_RESULT = '" & ConsultResult_Completed & "'"
                End If
            End If

            SQL = SQL & " ORDER BY CONCAT(TOND_DD, TONG_TIME) DESC "

            '************************************ 체크하자
            Dim dt1 As DataTable = DoQuery(gsConString, SQL)
            dgView.DataSource = dt1
            dt1 = Nothing

        Catch ex As Exception
            Call WriteLog("FRM_MONITOR : " & ex.ToString)
        End Try
    End Sub

    Enum SELECT_TYPE
        CALLBACK_DONE = 1
        CALLBACK_UNDONE = 2
        CALLBACK_ALL = 3
    End Enum

    Public Sub gsSelectCallback(ByVal selectMode As SELECT_TYPE, ByRef dgView As System.Windows.Forms.DataGridView)
        Try
            Dim strNow As String = Format(Now, "yyyyMMdd")
            Dim SQL As String = "Select CUSTOMER_ID,CUSTOMER_NM "
            SQL = SQL & " ,CONCAT(SUBSTRING(TOND_DD,1,4) , '-' , SUBSTRING(TOND_DD,5,2) , '-' , SUBSTRING(TOND_DD,7,2)) TONG_DD "
            SQL = SQL & " ,CONCAT(SUBSTRING(TONG_TIME,1,2) , ':' , SUBSTRING(TONG_TIME,3,2), ':' , SUBSTRING(TONG_TIME,5,2)) TONG_TIME "
            SQL = SQL & " ,TONG_TELNO"
            SQL = SQL & " ,CONCAT(CALL_BACK_RESULT , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '014' AND S_MENU_CD = CALL_BACK_RESULT )) CALL_BACK_RESULT "
            SQL = SQL & " ,CONCAT(CONSULT_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '003' AND S_MENU_CD = CONSULT_TYPE )) CONSULT_TYPE "
            SQL = SQL & " ,CONCAT(CONSULT_RESULT , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '004' AND S_MENU_CD = CONSULT_RESULT )) CONSULT_RESULT"
            SQL = SQL & " ,TONG_USER,TONG_CONTENTS "
            SQL = SQL & " ,CONCAT(CALL_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '005' AND S_MENU_CD = CALL_TYPE )) CALL_TYPE "
            SQL = SQL & " ,CONCAT(HANDLE_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "' AND L_MENU_CD = '012' AND S_MENU_CD = HANDLE_TYPE )) HANDLE_TYPE "
            SQL = SQL & " FROM T_CUSTOMER_HISTORY "
            SQL = SQL & " WHERE COM_CD = '" & gsCOM_CD & "'"

            If isTest = True Then
                SQL = SQL & " AND tond_dd like '" & Format(Now, "yyyyMM") & "%' "
            Else
                SQL = SQL & " AND tond_dd =  '" & strNow & "' "
            End If

            If selectMode = SELECT_TYPE.CALLBACK_DONE Then
                SQL = SQL & " AND CALL_BACK_YN = 'Y'"
                SQL = SQL & " AND CALL_BACK_RESULT = '1'" '처리완료
            ElseIf selectMode = SELECT_TYPE.CALLBACK_UNDONE Then
                SQL = SQL & " AND CALL_BACK_YN = 'Y'"
                SQL = SQL & " AND CALL_BACK_RESULT = '2'" '미처리
            ElseIf selectMode = SELECT_TYPE.CALLBACK_ALL Then
                SQL = SQL & " AND CALL_BACK_YN = 'Y'"     '콜백전체
            End If

            SQL = SQL & " ORDER BY CONCAT(TOND_DD, TONG_TIME) DESC "

            Dim dt1 As DataTable = DoQuery(gsConString, SQL)
            dgView.DataSource = dt1
            dt1 = Nothing

        Catch ex As Exception
            Call WriteLog("FRM_MONITOR : " & ex.ToString)
        End Try
    End Sub

    Public Sub gsFormExit()
        Try
            Me.Close()
        Catch ex As Exception
            Call WriteLog("FRM_MONITOR : " & ex.ToString)
        End Try
    End Sub


    Private Sub FRM_MONITOR_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        'Call gsFormExit()
    End Sub

    Private Sub ToggleModeSwitch(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleButton01.Click, ToggleButton02.Click, ToggleButton07.Click
        Dim btn As Elegant.Ui.ToggleButton = sender

        For Each mBtn In Me.btnGrpConsult.Controls
            If TypeOf mBtn Is Elegant.Ui.ToggleButton Then
                Dim mTestBtn As Elegant.Ui.ToggleButton = mBtn
                If mTestBtn.Tag = btn.Tag Then
                    'MsgBox(btn.Tag, MsgBoxStyle.OkOnly, "알림")
                Else
                    mTestBtn.Pressed = False
                End If
            End If
        Next

        QueryConsultStatus(btn.Tag)

    End Sub


    Private Sub RefreshConsultStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tag As Object = Nothing
        For Each mBtn In Me.btnGrpConsult.Controls
            If TypeOf mBtn Is Elegant.Ui.ToggleButton Then
                Dim mTestBtn As Elegant.Ui.ToggleButton = mBtn
                If mTestBtn.Pressed Then
                    tag = mTestBtn.Tag
                End If
            End If
        Next

        QueryConsultStatus(tag)
    End Sub

    Private Sub QueryConsultStatus(ByVal tag As Object)
        If tag Is Nothing Then
            tag = 7
        End If

        Select Case tag
            Case 1
                Call gsSelect(ConsultResult_Completed, SELECT_TYPE1.NORMAL, dgViewMain)
            Case 2
                Call gsSelect(ConsultResult_UnDone, SELECT_TYPE1.NORMAL, dgViewMain)
            Case 7
                Call gsSelect(ConsultResult_All, SELECT_TYPE1.NORMAL, dgViewMain)
        End Select

        '값변경가능성 대비 refresh기능
        Call gsInit(SELECT_INIT.CONSULT)
        Call getConsultStatus()
    End Sub

    Private Sub ToggleTransSwitch(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleButton11.Click, ToggleButton12.Click, ToggleButton17.Click
        Dim btn As Elegant.Ui.ToggleButton = sender

        For Each mBtn In Me.btnGrpTrans.Controls
            If TypeOf mBtn Is Elegant.Ui.ToggleButton Then
                Dim mTestBtn As Elegant.Ui.ToggleButton = mBtn
                If mTestBtn.Tag = btn.Tag Then
                    'MsgBox(btn.Tag, MsgBoxStyle.OkOnly, "알림")
                Else
                    mTestBtn.Pressed = False
                End If
            End If
        Next

        QueryTransStatus(btn.Tag)

    End Sub

    Private Sub RefreshTransStatus()
        Dim tag As Object = Nothing
        For Each mBtn In Me.btnGrpTrans.Controls
            If TypeOf mBtn Is Elegant.Ui.ToggleButton Then
                Dim mTestBtn As Elegant.Ui.ToggleButton = mBtn
                If mTestBtn.Pressed Then
                    tag = mTestBtn.Tag
                End If
            End If
        Next

        QueryTransStatus(tag)

    End Sub


    Private Sub QueryTransStatus(ByVal tag As Object)
        If tag Is Nothing Then
            tag = 7
        End If

        Select Case tag
            Case 1
                Call gsSelect(ConsultResult_Completed, SELECT_TYPE1.TRANS, dgViewTrans)
            Case 2
                Call gsSelect(ConsultResult_UnDone, SELECT_TYPE1.TRANS, dgViewTrans)
            Case 7
                Call gsSelect(ConsultResult_All, SELECT_TYPE1.TRANS, dgViewTrans)
        End Select

        '값변경가능성 대비 refresh기능
        Call gsInit(SELECT_INIT.TRANS)
        Call getTransStatus()

    End Sub


    Private Sub ToggleCallbackSwitch(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleButton21.Click, ToggleButton22.Click, ToggleButton27.Click
        Dim btn As Elegant.Ui.ToggleButton = sender

        For Each mBtn In Me.btnGrpCallback.Controls
            If TypeOf mBtn Is Elegant.Ui.ToggleButton Then
                Dim mTestBtn As Elegant.Ui.ToggleButton = mBtn
                If mTestBtn.Tag = btn.Tag Then
                    'MsgBox(btn.Tag, MsgBoxStyle.OkOnly, "알림")
                Else
                    mTestBtn.Pressed = False
                End If
            End If
        Next
        QueryCallBackStatus(btn.Tag)

    End Sub

    Private Sub RefreshCallBackStatus()
        Dim tag As Object = Nothing
        For Each mBtn In Me.btnGrpCallback.Controls
            If TypeOf mBtn Is Elegant.Ui.ToggleButton Then
                Dim mTestBtn As Elegant.Ui.ToggleButton = mBtn
                If mTestBtn.Pressed Then
                    tag = mTestBtn.Tag
                End If
            End If
        Next

        QueryCallBackStatus(tag)

    End Sub


    Private Sub QueryCallBackStatus(ByVal tag As Object)
        If tag Is Nothing Then
            tag = 7
        End If
        Select Case tag
            Case 1
                Call gsSelectCallback(SELECT_TYPE.CALLBACK_DONE, dgViewCallback)
            Case 2
                Call gsSelectCallback(SELECT_TYPE.CALLBACK_UNDONE, dgViewCallback)
            Case 7
                Call gsSelectCallback(SELECT_TYPE.CALLBACK_ALL, dgViewCallback)
        End Select

        '값변경가능성 대비 refresh기능
        Call gsInit(SELECT_INIT.CALLBACK)
        Call getCallbackStatus()
    End Sub

    Private Sub dgViewMain_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewMain.CellContentDoubleClick
        'Call WriteLog("FRM_MONITOR : " & _
        'dgViewMain.Rows(e.RowIndex).Cells(0).Value.ToString & ":" & _
        'dgViewMain.Rows(e.RowIndex).Cells(1).Value & ":" & _
        'dgViewMain.Rows(e.RowIndex).Cells(2).Value & ":" & _
        'dgViewMain.Rows(e.RowIndex).Cells(3).Value & ":" & _
        'dgViewMain.Rows(e.RowIndex).Cells(4).Value & ":" & _
        'dgViewMain.Rows(e.RowIndex).Cells(5).Value)

        'Dim telNo As String = dgViewMain.Rows(e.RowIndex).Cells(4).Value
        'Dim tongDate As String = dgViewMain.Rows(e.RowIndex).Cells(2).Value
        'Dim tongTime As String = dgViewMain.Rows(e.RowIndex).Cells(3).Value
        'Dim frm As FRM_MAIN = Me.MdiParent
        'Call frm.OpenCustomerPopupMod(telNo, tongDate, tongTime)

        Dim consultHistory As New CustomerHistory
        Dim popupFrm As New FRM_DETAIL_POPUP
        Try
            consultHistory.CustomerId = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_CUSTOMER_ID").Value, "")
            consultHistory.CustomerNm = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_CUSTOMER_NM").Value, "")
            consultHistory.TongDD = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_TONG_DD").Value, "")
            consultHistory.TongTime = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_TONG_TIME").Value, "")
            consultHistory.TongTelNo = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_TONG_TELNO").Value, "")
            consultHistory.ConsultType = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_CONSULT_TYPE").Value, "")
            consultHistory.ConsultResult = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_CONSULT_RESULT").Value, "")
            consultHistory.TongUser = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_TONG_USER").Value, "")

            consultHistory.TongContents = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_TONG_CONTENTS").Value, "")

            consultHistory.CallType = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_CALL_TYPE").Value, "")
            consultHistory.HandleType = MiniCTI.NotNull(dgViewMain.Rows(e.RowIndex).Cells("DM_HANDLE_TYPE").Value, "")

            AddHandler popupFrm.btnConfirm.Click, AddressOf RefreshConsultStatus
            popupFrm.OpenDetail(JobType.CONSULT, consultHistory)
            popupFrm.ShowDialog()

        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub


    Private Sub dgViewTrans_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewTrans.CellContentDoubleClick
        'Dim telNo As String = dgViewTrans.Rows(e.RowIndex).Cells(4).Value
        'Dim tongDate As String = dgViewTrans.Rows(e.RowIndex).Cells(2).Value
        'Dim tongTime As String = dgViewTrans.Rows(e.RowIndex).Cells(3).Value
        'Dim frm As FRM_MAIN = Me.MdiParent
        'Call frm.OpenCustomerPopupMod(telNo, tongDate, tongTime)
        Dim consultHistory As New CustomerHistory
        Dim popupFrm As New FRM_DETAIL_POPUP
        Try
            consultHistory.CustomerId = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_CUSTOMER_ID").Value, "")
            consultHistory.CustomerNm = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_CUSTOMER_NM").Value, "")
            consultHistory.TongDD = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_TONG_DD").Value, "")
            consultHistory.TongTime = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_TONG_TIME").Value, "")
            consultHistory.TongTelNo = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_TONG_TELNO").Value, "")
            consultHistory.ConsultType = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_CONSULT_TYPE").Value, "")
            consultHistory.ConsultResult = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_CONSULT_RESULT").Value, "")
            consultHistory.TongUser = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_TONG_USER").Value, "")

            consultHistory.TongContents = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_TONG_CONTENTS").Value, "")

            consultHistory.CallType = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_CALL_TYPE").Value, "")
            consultHistory.HandleType = MiniCTI.NotNull(dgViewTrans.Rows(e.RowIndex).Cells("DT_HANDLE_TYPE").Value, "")

            AddHandler popupFrm.btnConfirm.Click, AddressOf RefreshTransStatus
            popupFrm.OpenDetail(JobType.TRANSFER, consultHistory)
            popupFrm.ShowDialog()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub dgViewCallback_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewCallback.CellContentDoubleClick
        'Dim telNo As String = dgViewCallback.Rows(e.RowIndex).Cells(4).Value
        'Dim tongDate As String = dgViewCallback.Rows(e.RowIndex).Cells(2).Value
        'Dim tongTime As String = dgViewCallback.Rows(e.RowIndex).Cells(3).Value
        'Dim frm As FRM_MAIN = Me.MdiParent
        'Call frm.OpenCustomerPopupMod(telNo, tongDate, tongTime)
        Dim consultHistory As New CustomerHistory
        Dim popupFrm As New FRM_DETAIL_POPUP
        Try
            consultHistory.CustomerId = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_CUSTOMER_ID").Value, "")
            consultHistory.CustomerNm = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_CUSTOMER_NM").Value, "")
            consultHistory.TongDD = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_TONG_DD").Value, "")
            consultHistory.TongTime = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_TONG_TIME").Value, "")
            consultHistory.TongTelNo = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_TONG_TELNO").Value, "")
            consultHistory.ConsultType = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_CONSULT_TYPE").Value, "")
            consultHistory.ConsultResult = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_CONSULT_RESULT").Value, "")
            consultHistory.TongUser = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_TONG_USER").Value, "")

            consultHistory.TongContents = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_TONG_CONTENTS").Value, "")

            consultHistory.CallType = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_CALL_TYPE").Value, "")
            consultHistory.HandleType = MiniCTI.NotNull(dgViewCallback.Rows(e.RowIndex).Cells("DC_HANDLE_TYPE").Value, "")

            AddHandler popupFrm.btnConfirm.Click, AddressOf RefreshCallBackStatus
            popupFrm.OpenDetail(JobType.CALLBACK, consultHistory)
            popupFrm.ShowDialog()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub
End Class