﻿Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Threading
Imports System.Data.SqlClient

Public Class FRM_MAIN
    'Public Shared Event Var_Trans(ByVal tel_no As String, ByVal tong_date As String, ByVal tong_time As String, ByVal CALL_TYPE As String)
    Private ss As New CRMmanager
    Private pop As New FRM_CUSTOMER_POPUP1

    Private frmAlarmSchedule As FRM_SCHEDULE_ALARM


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        Elegant.Ui.RibbonLicenser.LicenseKey = "E644-DB48-BFFB-CA0C-53D2-4F3F-C938-C3EF"

        ' 이 호출은 Windows Form 디자이너에 필요합니다.
        InitializeComponent()
        GroupBox5.BackColor = Color.FromArgb(204, 220, 236)
        txtTotalCall.BackColor = Color.FromArgb(204, 220, 236)
        txtReceiveCall.BackColor = Color.FromArgb(204, 220, 236)
        txtConsultCall.BackColor = Color.FromArgb(204, 220, 236)
        txtTransCall.BackColor = Color.FromArgb(204, 220, 236)
        txtCallback.BackColor = Color.FromArgb(204, 220, 236)
    End Sub

    Private Sub FRM_MAIN_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'If MessageBox.Show("프로그램을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.OKCancel, _
        '               Nothing, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
        FormAliveYN = "N"
        Call AllFormExit()
        'Else
        'e.Cancel = True
        'End If
    End Sub

    Private Sub AllFormExit()
        '현재 떠있는 모든 화면을 클로즈 시킨다
        For Each mForm In Me.MdiChildren
            mForm.Close()
        Next

    End Sub

    Private Sub FRM_MAIN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Call SetUserInfo("0001", "0001", "김보성", "", "", "", "", "", "", "6435", "", "", "", "", "솔루션사업팀", "12345", "", "재민정보통신")

        'Call direct_menu()          ' 바로가기 메뉴에 서브메뉴 할당
        Call etcSetting()           ' 기타 정보 세팅해줌
        Call getStatistics()
        Call CheckCustomerTablePatched()
        LoadBackgroundWorkerMain()
    End Sub

    Private Sub etcSetting()
        ' 사업장,사용자 정보 표시해줌
        'toolTXTCompany.Text = gsCompany
        'toolTXTUser.Text = gsUSER_ID + "." + gsUSER_NM

        If gsCompany.Trim = "" Then
            toolSaupJang.Text = "알수없음"
        Else
            toolSaupJang.Text = gsCompany
        End If

        toolUserName.Text = gsUSER_ID + "." + gsUSER_NM

        'MessageBox.Show("gsWORK_AREA" & gsWORK_AREA)

        '관리메뉴는 관리자만 접근가능하도록
        If gsWORK_AREA = "01" Then '일반사용자

            'If gsGRADE = "01" Then
            'Me.NavigationBarGroupItemsContainer5.Visible = False
            'Me.NavigationBarGroup5.Visible = False
            Me.NavigationBarItem12.Visible = False

            'Me.NavigationBarItem13.Visible = False '비밀번호변경은 모두 가능토록
            Me.NavigationBarItem14.Visible = False
            Me.NavigationBarItem15.Visible = False
            Me.NavigationBarItem16.Visible = False
            Me.NavigationBarItem18.Visible = False


        ElseIf gsWORK_AREA = "00" Then '관리자
            'Me.NavigationBarGroupItemsContainer5.Visible = True
            'Me.NavigationBarGroup5.Visible = True
        End If
    End Sub

    Private Sub function_Init()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            Dim ChildForm As Object
            ChildForm = Me.ActiveMdiChild()

            ChildForm.gsInit()

        Catch ex As Exception
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub function_excel_save()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            Dim ChildForm As Object
            ChildForm = Me.ActiveMdiChild()

            ChildForm.gsExcelSave()

        Catch ex As Exception
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub function_save()
        'mdi main에서 저장 버튼 클릭시
        ' Active form(child)에서 gsSave() 호출할것
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            Dim ChildForm As Object
            ChildForm = Me.ActiveMdiChild()

            ChildForm.gsSave()

        Catch ex As Exception
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub


    Private Sub function_select()
        'mdi main에서 조회 버튼 클릭시
        ' Active form(child)에서 gsSelect() 호출할것
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            Dim ChildForm As Object
            ChildForm = Me.ActiveMdiChild()

            ChildForm.gsSelect()

        Catch ex As Exception
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub function_delete()
        'mdi main에서 삭제 버튼 클릭시
        ' Active form(child)에서 gsDelete() 호출할것
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            Dim ChildForm As Object
            ChildForm = Me.ActiveMdiChild()

            ChildForm.gsDelete()

        Catch ex As Exception
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub


    Private Sub toolFormExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mdi main에서 나가기 버튼 클릭시
        ' Active form(child)에서 gsFormExit() 호출할것
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            Dim ChildForm As Object
            ChildForm = Me.ActiveMdiChild()

            ChildForm.gsFormExit()

        Catch ex As Exception
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub


    'Private Sub cbDirectMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '
    '    Dim subMenu As String = cbDirectMenu.SelectedValue.ToString()

    '    If subMenu <> "0000" Then
    '        Call menu_popuu(subMenu)
    '    End If

    'End Sub
    Public Sub menu_popuu(ByVal frmnm As String)
        Try

            'For Each mForm In Me.MdiChildren
            '    If UCase(mForm.Name) = UCase(frmnm) And UCase(mForm.Name) <> "FRM_CUSTOMER_POPUP" Then
            '        mForm.Activate()
            '        Exit Sub
            '    End If
            'Next

            For Each mForm In Me.MdiChildren
                If UCase(mForm.Name) = UCase(frmnm) Then
                    mForm.Activate()

                    'If UCase(frmnm) = "FRM_CUSTOMER_POPUP1" Then
                    '    FRM_CUSTOMER_POPUP1.gsSelect()
                    'End If
                    Exit Sub
                End If
            Next


            Select Case frmnm.Trim
                Case "FRM_CALLLOG"

                    If FRM_CALLLOG Is Nothing Then

                        Dim newF As New FRM_CALLLOG

                        newF.MdiParent = Me
                        newF.Show()
                    End If

                Case "FRM_CODELIST"
                    If FRM_CODELIST Is Nothing Then
                        Dim newF As New FRM_CODELIST

                        newF.MdiParent = Me
                        newF.Show()
                    End If
                Case "FRM_CUSTOMER"
                    If FRM_CUSTOMER Is Nothing Then
                        Dim newF As New FRM_CUSTOMER

                        newF.MdiParent = Me
                        newF.Show()
                    Else
                        FRM_CUSTOMER.Show()
                    End If
                Case "FRM_CUSTOMER_POPUP1"
                    If FRM_CUSTOMER_POPUP1 Is Nothing Then
                        Dim newF As New FRM_CUSTOMER_POPUP1

                        newF.MdiParent = Me
                        newF.Show()
                        'FRM_CUSTOMER_POPUP1.gsSelect()
                        'Else
                        '    FRM_CUSTOMER_POPUP1.Show()
                        '    'FRM_CUSTOMER_POPUP1.gsSelect()
                    End If


                Case "FRM_HISTORY"
                    If FRM_HISTORY Is Nothing Then
                        Dim newF As New FRM_HISTORY

                        newF.MdiParent = Me
                        newF.Show()
                    End If

                Case "FRM_CALLER_LIST"
                    If FRM_CALLER_LIST Is Nothing Then
                        Dim newF As New FRM_CALLER_LIST

                        newF.MdiParent = Me
                        newF.Show()
                    End If

                Case "FRM_HISTORY_VIP"
                    If FRM_HISTORY_VIP Is Nothing Then
                        Dim newF As New FRM_HISTORY_VIP

                        newF.MdiParent = Me
                        newF.Show()
                    End If

                Case "FRM_HISTORY_CALLBACK"
                    If FRM_HISTORY_CALLBACK Is Nothing Then
                        Dim newF As New FRM_HISTORY_CALLBACK

                        newF.MdiParent = Me
                        newF.Show()
                    End If


                Case "FRM_PWD_CHANGE"
                    If FRM_PWD_CHANGE Is Nothing Then
                        Dim newF As New FRM_PWD_CHANGE

                        newF.MdiParent = Me
                        newF.Show()


                    End If
                Case "FRM_SAWON"
                    If FRM_SAWON Is Nothing Then
                        Dim newF As New FRM_SAWON

                        newF.MdiParent = Me
                        newF.Show()
                    End If
                Case "FRM_SCHEDULE"
                    If FRM_SCHEDULE Is Nothing Then
                        Dim newF As New FRM_SCHEDULE

                        newF.MdiParent = Me
                        newF.Show()
                    End If
                Case "FRM_CALL_STATISTICS1"

                    If FRM_CALL_STATISTICS1 Is Nothing Then

                        Dim newF As New FRM_CALL_STATISTICS1

                        newF.MdiParent = Me
                        newF.Show()
                    End If
                Case "FRM_CALL_STATISTICS2"

                    If FRM_CALL_STATISTICS2 Is Nothing Then

                        Dim newF As New FRM_CALL_STATISTICS2

                        newF.MdiParent = Me
                        newF.Show()
                    End If
                Case "FRM_CALL_STATISTICS3"

                    If FRM_CALL_STATISTICS3 Is Nothing Then

                        Dim newF As New FRM_CALL_STATISTICS3

                        newF.MdiParent = Me
                        newF.Show()
                    End If
                Case "FRM_MONITOR"

                    If FRM_MONITOR Is Nothing Then

                        Dim newF As New FRM_MONITOR

                        newF.MdiParent = Me
                        newF.Show()
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub menu_popuu2(ByVal frmnm As String)
        Try

            'For Each mForm In Me.MdiChildren
            '    If UCase(mForm.Name) = UCase(frmnm) And UCase(mForm.Name) <> "FRM_CUSTOMER_POPUP" Then
            '        mForm.Activate()
            '        Exit Sub
            '    End If
            'Next

            For Each mForm In Me.MdiChildren
                If UCase(mForm.Name) = UCase(frmnm) Then
                    mForm.Activate()

                    'If UCase(frmnm) = "FRM_CUSTOMER_POPUP1" Then
                    '    FRM_CUSTOMER_POPUP1.gsSelect()
                    'End If
                    Exit Sub
                End If
            Next


            Select Case frmnm.Trim

                Case "FRM_CUSTOMER_POPUP1"
                    If FRM_CUSTOMER_POPUP1 Is Nothing Then
                        Dim newF As New FRM_CUSTOMER_POPUP1

                        newF.MdiParent = Me
                        newF.Show()
                        'FRM_CUSTOMER_POPUP1.gsSelect()
                        'Else
                        '    FRM_CUSTOMER_POPUP1.Show()
                        '    'FRM_CUSTOMER_POPUP1.gsSelect()
                    End If


            End Select
        Catch ex As Exception

        End Try
    End Sub


    'Private Sub 고객정보입력ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        With OpenFileDialog1
    '            .CheckFileExists = True
    '            .CheckPathExists = True
    '            .Filter = "Excel통합문서(*.xlsx)|*.xlsx|Excel97-2003문서(*.xls)|*.xls"
    '            .FileName = "CustomerInfo"
    '            .Title = "고객정보 파일 읽기"
    '            .Multiselect = False
    '            .ShowDialog()
    '        End With

    '    Catch ex As Exception
    '        WriteLog(ex.ToString)
    '    End Try
    'End Sub


    Private Sub NavigationBarItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem1.Click
        '고객상담화면
        Call menu_popuu("FRM_CUSTOMER_POPUP1")
    End Sub

    Private Sub NavigationBarItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem2.Click
        '고객정보조회
        Call menu_popuu("FRM_CUSTOMER")
    End Sub

    Private Sub NavigationBarItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem21.Click
        ' 수발신 목록
        Call menu_popuu("FRM_CALLER_LIST")
    End Sub

    Private Sub NavigationBarItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem3.Click
        ' 상담이력조회
        Call menu_popuu("FRM_HISTORY")
    End Sub

    Private Sub NavigationBarItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem4.Click
        ' 우수고객조회
        Call menu_popuu("FRM_HISTORY_VIP")
    End Sub

    Private Sub NavigationBarItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem5.Click
        ' 긴급처리조회
        Call menu_popuu("FRM_HISTORY_GINGUB")
    End Sub

    Private Sub NavigationBarItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem6.Click
        ' 콜백조회
        Call menu_popuu("FRM_HISTORY_CALLBACK")
    End Sub

    Private Sub NavigationBarItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem7.Click
        ' 일정관리
        Call menu_popuu("FRM_SCHEDULE")
    End Sub

    Private Sub NavigationBarItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem8.Click
        ' 외근관리
        Call menu_popuu("FRM_OUTWORK")
    End Sub

    Private Sub NavigationBarItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem10.Click
        ' 개인통화건수
        Call menu_popuu("FRM_CALL_STATISTICS1")
    End Sub

    Private Sub NavigationBarItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem12.Click
        ' 계정관리
        Call menu_popuu("FRM_SAWON")
    End Sub

    Private Sub NavigationBarItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem13.Click
        ' 비밀번호변경
        Call menu_popuu("FRM_PWD_CHANGE")
    End Sub

    Private Sub NavigationBarItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem14.Click
        ' 코드관리
        Call menu_popuu("FRM_CODELIST")
    End Sub

    Private Sub NavigationBarItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem15.Click
        Try
            With OpenFileDialog1
                .CheckFileExists = True
                .CheckPathExists = True
                .Filter = "Excel통합문서(*.xlsx)|*.xlsx|Excel97-2003문서(*.xls)|*.xls"
                .FileName = "고객정보(등록용)"
                .Title = "고객정보 가져오기"
                .Multiselect = False
                .ShowDialog()
            End With

        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub NavigationBarItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem16.Click
        Try
            With SaveFileDialog1
                .CheckPathExists = True
                .Filter = "Excel통합문서(*.xlsx)|*.xlsx|Excel97-2003문서(*.xls)|*.xls"
                .FileName = "고객정보추출목록" & Format(Now, "yyyyMMdd")
                .Title = "고객정보 내보내기"
                .ShowDialog()
            End With

        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub NavigationBarItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem18.Click
        ' 콜로그조회
        Call menu_popuu("FRM_CALLLOG")
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            Call Excells_Import(OpenFileDialog1.FileName)
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Try
            Call Excells_Export(SaveFileDialog1.FileName)
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    'Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
    '    Shell("iexplore.exe http://www.nomazin.com/shop/main/index.php")
    'End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start("http://nomazin.com/shop/main/index.php")
    End Sub


    Private Sub NavigationBarItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem17.Click
        ' 팀통화건수
        Call menu_popuu("FRM_CALL_STATISTICS2")
    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    ''' <summary>
    ''' 인입호 : 고객이 전화한 건수(ringing).
    ''' 응대호 : 고객전화를 받은 건수(answer).
    ''' 상담건수: 고객상담화면에서 상담저장 버튼을 누른 건수
    ''' 이관건수: 고객상담화면에서 이관자에게 업무이관한 건수
    ''' 콜백건수: 고객에게 다시 전화 주기로 한 건수
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getStatistics()
        Try
            Dim SQL As String
            Dim strNow As String = Format(Now, "yyyyMMdd")
            '총인입호 
            SQL = "select '1' flag, count(*) cnt from t_call_history where tong_start_time like '" & strNow & "%' and call_result = '1'"
            SQL = SQL & " union all"
            '응대호
            SQL = SQL & " select '2' flag,count(*) cnt from t_call_history where tong_start_time like '" & strNow & "%' and call_result = '3'"
            SQL = SQL & " union all"
            '상담건수
            SQL = SQL & " select '3' flag,count(*) cnt from t_customer_history where tond_dd = '" & strNow & "' and consult_result <> '06' and trans_yn is null"
            SQL = SQL & " union all"
            '이관건수
            SQL = SQL & " select '4' flag,count(*) cnt from t_customer_history where tond_dd = '" & strNow & "' and consult_result = '06'"
            SQL = SQL & " union all"
            '콜백건수
            SQL = SQL & " select '5' flag,count(*) cnt from t_customer_history where tond_dd = '" & strNow & "' and call_back_yn = 'Y' "

            Dim dt1 As DataTable = DoQuery(gsConString, SQL)

            Dim toolTipTotalCall As ToolTip = New ToolTip()
            Dim toolTipReceiveCall As ToolTip = New ToolTip()
            Dim toolTipConsultCall As ToolTip = New ToolTip()
            Dim toolTipTransCall As ToolTip = New ToolTip()
            Dim toolTipCallback As ToolTip = New ToolTip()
            Dim strTotalCall As String = "고객이 전화한 건수"
            Dim strReceiveCall As String = "고객전화를 받은 건수"
            Dim strConsultCall As String = "고객상담화면에서 상담저장 버튼을 누른 건수"
            Dim strTransCall As String = "고객상담화면에서 이관자에게 업무이관한 건수"
            Dim strCallback As String = "고객에게 다시 전화 주기로 한 건수"

            toolTipTotalCall.SetToolTip(txtTotalCall, strTotalCall)
            toolTipTotalCall.SetToolTip(LabelTotalCall, strTotalCall)


            toolTipReceiveCall.SetToolTip(txtReceiveCall, strReceiveCall)
            toolTipReceiveCall.SetToolTip(LabelReceiveCall, strReceiveCall)

            toolTipConsultCall.SetToolTip(txtConsultCall, strConsultCall)
            toolTipConsultCall.SetToolTip(LabelConsultCall, strConsultCall)

            toolTipTransCall.SetToolTip(txtTransCall, strTransCall)
            toolTipTransCall.SetToolTip(LabelTransCall, strTransCall)

            toolTipCallback.SetToolTip(txtCallback, strCallback)
            toolTipCallback.SetToolTip(LabelCallback, strCallback)

            If dt1.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dt1.Rows.Count - 1

                    Dim flag As String = dt1.Rows(i).Item(0).ToString()

                    If flag = "1" Then
                        txtTotalCall.Text = dt1.Rows(i).Item(1).ToString()
                    ElseIf flag = "2" Then
                        txtReceiveCall.Text = dt1.Rows(i).Item(1).ToString()
                    ElseIf flag = "3" Then
                        txtConsultCall.Text = dt1.Rows(i).Item(1).ToString()
                    ElseIf flag = "4" Then
                        txtTransCall.Text = dt1.Rows(i).Item(1).ToString()
                    ElseIf flag = "5" Then
                        txtCallback.Text = dt1.Rows(i).Item(1).ToString()
                    End If
                Next
            Else
                txtTotalCall.Text = "0"
                txtConsultCall.Text = "0"
                txtReceiveCall.Text = "0"
                txtTransCall.Text = "0"
                txtCallback.Text = "0"
            End If


            dt1 = Nothing

        Catch ex As Exception
            txtTotalCall.Text = "0"
            txtConsultCall.Text = "0"
            txtReceiveCall.Text = "0"
            txtTransCall.Text = "0"
            txtCallback.Text = "0"
        End Try

    End Sub

    Public Sub popupCustomer()
        Call menu_popuu("FRM_CUSTOMER_POPUP1")
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Call function_Init()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        On Error Resume Next
        For Each mForm In Me.MdiChildren
            mForm.Close()
        Next
        Me.Close()
    End Sub


    Private Sub AboutWeDoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutWeDoToolStripMenuItem.Click
        'AboutBox.ParentForm = Me
        AboutBox.ShowDialog()

        'AboutBox.Focus()
    End Sub

    '메신저에서 팝업호출
    Public Sub OpenCustomerPopup(ByVal tel_no As String, ByVal TONG_TM As String, ByVal CALL_TYPE As String)

        Try
            '*************************** 전역변수를 설정해서 전역변수에 값을 넣자 *********************************************
            Dim tong_date As String = TONG_TM.Substring(0, 4) + "-" + TONG_TM.Substring(4, 2) + "-" + TONG_TM.Substring(6, 2)
            Dim tong_time As String = TONG_TM.Substring(8, 2) + ":" + TONG_TM.Substring(10, 2) + ":" + TONG_TM.Substring(12, 2)

            Me.Show()
            Dim pop As New FRM_CUSTOMER_POPUP1
            pop.MdiParent = Me
            pop.Show()

            If pop.chModification1.Checked = True Then
                Call pop.Control_disable(True)
            Else
                Call pop.Control_disable(False)
            End If

            pop.txtEnteringNo.Text = tel_no

            If pop.txtEnteringNo.Text.Trim = "" Then
                Call pop.SetActionStatus(ActionStatus.OpenEmpty)
                Call pop.gsInit()                   ' 모든 항목을 초기화 시킨다.
                Exit Sub
            End If

            If (CALL_TYPE = "2") Then
                Call pop.SetActionStatus(ActionStatus.PopUpOutBound)
            Else
                Call pop.SetActionStatus(ActionStatus.PopUpInBound)
            End If

            Call pop.gsInit()                   ' 모든 항목을 초기화 시킨다.

            'txtEnteringNo.Text = tel_no
            pop.txtDate2.Text = tong_date
            pop.txtTongTime2.Text = tong_time
            pop.txtTongUser2.Text = gsUSER_ID & "." & gsUSER_NM

            Call pop.gsSelectPopUp()
            'Call Me.menu_popuu("FRM_CUSTOMER_POPUP1")
            'RaiseEvent Var_Trans(tel_no, tong_date, tong_time, CALL_TYPE)

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " OpenCustomerPopup : " & ex.ToString)
        End Try
    End Sub

    '메신저에서 이관용 팝업호출
    Public Sub OpenCustomerPopupTransfer(ByVal tel_no As String, ByVal SenderId As String, ByVal Tongdate As String, ByVal Tongtime As String, ByVal CALL_TYPE As String)
        'Tongdate 포맷: yyyy-MM-dd
        'Tongtime 포맷: hh:mm:ss

        Try
            '*************************** 전역변수를 설정해서 전역변수에 값을 넣자 *********************************************
            Dim tong_date As String = Tongdate
            Dim tong_time As String = Tongtime
            Dim tong_user_nm As String = ""

            Me.Show()
            Dim pop As New FRM_CUSTOMER_POPUP1
            pop.MdiParent = Me
            pop.Show()

            If pop.chModification1.Checked = True Then
                Call pop.Control_disable(True)
            Else
                Call pop.Control_disable(False)
            End If

            pop.txtEnteringNo.Text = tel_no

            If pop.txtEnteringNo.Text.Trim = "" Then
                Call pop.SetActionStatus(ActionStatus.OpenEmpty)
                Call pop.gsInit()                   ' 모든 항목을 초기화 시킨다.
                Exit Sub
            End If
            Call pop.SetActionStatus(ActionStatus.PopUpInBound)
            Call pop.gsInit()                   ' 모든 항목을 초기화 시킨다.

            '이관전송자명을 가져옴
            Dim SQL As String = " SELECT IFNULL(USER_NM,'') "
            SQL = SQL & " FROM T_USER "
            SQL = SQL & " WHERE COM_CD = '" & gsCOM_CD & "'"
            SQL = SQL & " AND USER_ID = '" & SenderId & "'"

            Dim dt1 As DataTable = DoQuery(gsConString, SQL)

            If dt1.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dt1.Rows.Count - 1
                    tong_user_nm = dt1.Rows(i).Item(0).ToString
                Next
            End If

            dt1 = Nothing

            'txtEnteringNo.Text = tel_no
            pop.txtDate2.Text = tong_date
            pop.txtTongTime2.Text = tong_time

            pop.txtTongUser2.Text = SenderId & "." & tong_user_nm

            Call pop.gsSelectPopUp()
            Call pop.setIsTransfer(True)
            Call pop.gsDisplayTransferDetail(tel_no, tong_date, tong_time, True)

            'Call Me.menu_popuu("FRM_CUSTOMER_POPUP1")
            'RaiseEvent Var_Trans(tel_no, tong_date, tong_time, CALL_TYPE)

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " OpenCustomerPopupTransfer : " & ex.ToString)
        End Try
    End Sub


    ''' <summary>
    '''상세조회버튼클릭시 팝업호출 
    ''' </summary>
    ''' <param name="tel_no"></param>
    ''' <param name="TONG_DT"></param>
    ''' <param name="TONG_TM"></param>
    ''' <remarks></remarks>
    Public Sub OpenCustomerPopupMod(ByVal tel_no As String, ByVal TONG_DT As String, ByVal TONG_TM As String)
        ' TONG_DT YYYY-MM-DD TONG_TM hh:mm:ss

        Try
            Me.Show()
            Dim pop As New FRM_CUSTOMER_POPUP1
            pop.MdiParent = Me
            pop.Show()

            If pop.chModification1.Checked = True Then
                Call pop.Control_disable(True)
            Else
                Call pop.Control_disable(False)
            End If

            pop.txtEnteringNo.Text = tel_no

            If pop.txtEnteringNo.Text.Trim = "" Then
                Call pop.SetActionStatus(ActionStatus.OpenEmpty)
                Call pop.gsInit()                   ' 모든 항목을 초기화 시킨다.
                Exit Sub
            End If

            pop.SetActionStatus(ActionStatus.PopUpDetail)
            Call pop.gsInit()                   ' 모든 항목을 초기화 시킨다.

            'txtEnteringNo.Text = tel_no
            pop.txtDate2.Text = TONG_DT
            pop.txtTongTime2.Text = TONG_TM
            pop.txtTongUser2.Text = gsUSER_ID & "." & gsUSER_NM

            Call pop.gsSelectPopUp()

            Call pop.gsDisplayTransferDetail(tel_no, TONG_DT, TONG_TM, False)
            pop.txtTongEtcInfo4.Focus()
            pop.switchFocus(PANEL_FOCUS.CONSULT_HISTORY)

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " OpenCustomerPopupMod : " & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' (일정미리알림창에서)  호출하여 일정관리창을 열고 선택한 일정내역을 디스플레이
    ''' </summary>
    ''' <param name="alarmSchedule"></param>
    ''' <remarks></remarks>
    Public Sub OpenSchedule(ByVal alarmSchedule As ConstDef.AlarmSchedule)
        ' TONG_DT YYYY-MM-DD TONG_TM hh:mm:ss

        Try
            Me.Show()
            Dim pop As New FRM_SCHEDULE
            pop.MdiParent = Me
            pop.Show()
            pop.OpenSchedule(alarmSchedule)
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " OpenSchedule : " & ex.ToString)
        End Try
    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("http://nomazin.com/shop/main/index.php")
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        MessageBox.Show("도움말서비스는 준비중입니다.", "도움말서비스", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information, _
                        MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub ToolStripMenuItem1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.MouseEnter
        If TypeOf Me.ActiveMdiChild Is FRM_CALL_STATISTICS1 Or _
           TypeOf Me.ActiveMdiChild Is FRM_CALL_STATISTICS2 Or _
           TypeOf Me.ActiveMdiChild Is FRM_CALL_STATISTICS3 _
         Then
            ExcelToolStripMenuItem.Enabled = True
        Else
            ExcelToolStripMenuItem.Enabled = False
        End If

    End Sub


    Private Sub FRM_MAIN_Layout(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles MyBase.Layout
        If Not Me.ActiveMdiChild Is Nothing Then
            If Me.ActiveMdiChild.WindowState = FormWindowState.Maximized Then
                MenuItemIconHide.Visible = False
            Else
                MenuItemIconHide.Visible = True
            End If
        Else
            MenuItemIconHide.Visible = True
        End If
    End Sub


    Private Sub FRM_MAIN_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Call getStatistics()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call getStatistics()
    End Sub

    Private Sub NavigationBarItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem11.Click
        ' 전체통화건수
        Call menu_popuu("FRM_CALL_STATISTICS3")
    End Sub

    Private Sub NavigationBarItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem19.Click
        ' 전체통화건수
        Call menu_popuu("FRM_MONITOR")
    End Sub

    Private Sub NavigationBarItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigationBarItem9.Click
        ' 직원업무일지
        Call menu_popuu("FRM_INNER_WORK")
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigToolStripMenuItem.Click
        Try
            Dim pop As New FRM_CONFIG
            pop.ShowDialog()

            'read xml file 
            'refresh config

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " Open FRM_CONFIG : " & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 일정관리 알림기능 위해서 BackgroundWorker기동
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadBackgroundWorkerMain()
        BackgroundWorkerMain.WorkerReportsProgress = True
        BackgroundWorkerMain.WorkerSupportsCancellation = True
        BackgroundWorkerMain.RunWorkerAsync()
    End Sub

    ''' <summary>
    ''' 일정관리 알림기능
    ''' 1. 일정관리 설정정보를 읽음: 알림 활성화, 주기, 알림시작시간
    ''' 2. 1분단위 슬립을 주고 주기가 되면 알림대상 일정 목록을 가져옴
    ''' 
    ''' ** 주기: 
    ''' a. 최초기동시 1회 알림 목록조회후 주기반영
    ''' b. 주기변경후 이전 알림조회이력 감안하여 변경된 주기반영
    ''' 
    ''' ** 주기적으로 알림주기가 되면 progressChanged호출
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BackgroundWorkerMain_DoWork(ByVal sender As System.Object, _
                                                ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                                    Handles BackgroundWorkerMain.DoWork
        ' Do some time-consuming work on this thread.
        While True
            Try
                If gbAlarmInfo.Enabled AndAlso DateTime.Now.Second Mod 60 < 10 Then '매분 체크 '60
                    If gbAlarmInfo.AlarmPeriodCount = gbAlarmInfo.AlarmPeriod Then
                        WriteLog(Me.Name.ToString & "알림 체크 실행")
                        gbAlarmInfo.AlarmPeriodCount = 0
                        BackgroundWorkerMain.ReportProgress(0, Nothing)
                    End If
                    gbAlarmInfo.AlarmPeriodCount += 1

                    Threading.Thread.Sleep(1000 * 59) 'Threading.Thread.Sleep(1000 * 59)
                    Continue While
                Else
                    Threading.Thread.Sleep(1000)
                    Continue While
                End If
            Catch ex As Exception
                Call WriteLog(Me.Name.ToString & " BackgroundWorkerMain 실행중 에러 : " & ex.ToString)
            End Try
        End While

        If BackgroundWorkerMain.CancellationPending Then
            e.Cancel = True
            BackgroundWorkerMain.ReportProgress(0, "BackgroundWorkerMain 취소요청.")
        End If
    End Sub

    ''' <summary>
    ''' 호출되면 CustomerScheduler.GetAlarmList 호출
    ''' 해당 목록이 있으면 알림창을 팝업
    ''' 알림창은 하나만 띄운다.(떠있는지 확인)
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BackgroundWorkerMain_ProgressChanged(ByVal sender As System.Object, _
                                                        ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
                                                            Handles BackgroundWorkerMain.ProgressChanged
        Dim scheduler As CustomerScheduler = New CustomerScheduler()

        Dim table As DataTable = scheduler.GetAlarmList()
        If table Is Nothing OrElse table.Rows().Count = 0 Then
            Return
        End If

        If frmAlarmSchedule Is Nothing OrElse frmAlarmSchedule.IsDisposed Then
            'OfType(Of FRM_SCHEDULE_ALARM).Any Then
            frmAlarmSchedule = New FRM_SCHEDULE_ALARM
            frmAlarmSchedule.Show()
            frmAlarmSchedule.DisplayAlarmList(table)
        End If
    End Sub


    ''' <summary>
    ''' 호출되는 경우는 없다. 에러로 호출되면 BackGroundWorker를 재기동
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BackgroundWorkerMain_RunWorkerCompleted(ByVal sender As System.Object, _
                                                            ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                                Handles BackgroundWorkerMain.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            '' if BackgroundWorker terminated due to error
            WriteLog(Me.Name.ToString & " BackgroundWorkerMain 에러로 인한 취소 : " & e.Error.ToString)
        ElseIf e.Cancelled Then
            '' otherwise if it was cancelled
            WriteLog(Me.Name.ToString & " BackgroundWorkerMain 취소처리 ")
        Else
            '' otherwise it completed normally
            WriteLog(Me.Name.ToString & " BackgroundWorkerMain 완료처리 ")
        End If
    End Sub


    Private Sub PatchHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchHistoryToolStripMenuItem.Click
        PATCH_HISTORY.ShowDialog()
    End Sub

    Private Sub FRM_MAIN_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not gbIsPatchHistoryOpened Then
            PATCH_HISTORY.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sql As String = "select * from t_user where user_id = @userId and com_cd = @comCd"
        Dim handler As New MySQLHandler(sql)
        handler.Parameters("@userId", "0002")
        handler.Parameters("@comCd", "8888")
        Dim dataTable As DataTable = handler.DoQuery()
        Dim userId As String = ""
        Dim userName As String = ""

        If dataTable.Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To dataTable.Rows.Count - 1

                userId = dataTable.Rows.Item(i).Item("USER_ID").ToString()
                userName = dataTable.Rows.Item(i).Item("user_nm").ToString()

            Next
        End If

        WriteLog("userId[" & userId & "] userName[" & userName & "]")


        dataTable = Nothing

        sql = "INSERT INTO t_user" & _
  "(COM_CD, USER_ID, USER_NM, USR_HP, ADDR1, WOO_NO, H_TELNO, DEPART_CD, GRADE, EXTENSION_NO, WORK_TYPE, ENTERING_DD, RETIRE_DD, USER_EMAIL, DEPART_NM, USER_PWD, WORK_AREA, TEAM_CD, TEAM_NM, MOBILE_USE_YN, EXCEL_USE_YN) " & _
  " VALUES " & _
  " ('8888', @userId, @userNm, '', '', '', '', '', '01', '', '', '20120716', '', '', '', '0001', '01', '01', @teamName, '', '');"
        handler.SetQuery(sql)
        handler.ClearParameters()
        handler.Parameters("@userId", "5555")
        handler.Parameters("@userNm", "최진원")
        handler.Parameters("@teamName", "21세기전략부")
        Dim returnCount As Integer = handler.Execute()

        WriteLog("returnCount[" & returnCount & "] 입력되었습니다.")

        handler.Close()

    End Sub

    ''' <summary>
    ''' select 문 샘플
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim handler As MySQLHandler = Nothing
        Dim dataTable As DataTable = Nothing
        Dim userId As String = ""
        Dim userName As String = ""
        Dim sql As String = ""
        Try
            handler = New MySQLHandler()
            sql = "select * from t_user where user_id = @userId and com_cd = @comCd"

            handler.SetQuery(sql)
            handler.Parameters("@userId", "000")
            handler.Parameters("@comCd", "8888")

            dataTable = handler.DoQuery()

            If dataTable.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dataTable.Rows.Count - 1

                    userId = dataTable.Rows.Item(i).Item("USER_ID").ToString()
                    userName = dataTable.Rows.Item(i).Item("user_nm").ToString()

                Next
            End If

            WriteLog("userId[" & userId & "] userName[" & userName & "]")
        Catch ex As Exception
            WriteLog(Me.Name.ToString & " OpenCustomerPopupMod : " & ex.ToString)
        Finally
            dataTable = Nothing
            If Not handler Is Nothing Then
                handler.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' insert 문 샘플
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim handler As MySQLHandler = Nothing
        Dim userId As String = ""
        Dim userName As String = ""
        Dim sql As String = ""
        Try
            handler = New MySQLHandler()

            sql = "INSERT INTO T_USER " & _
                  "(COM_CD, USER_ID, USER_NM, USR_HP, ADDR1, WOO_NO, H_TELNO, DEPART_CD, GRADE, EXTENSION_NO, " & _
                  "WORK_TYPE, ENTERING_DD, RETIRE_DD, USER_EMAIL, DEPART_NM, USER_PWD, WORK_AREA, TEAM_CD, TEAM_NM, MOBILE_USE_YN, EXCEL_USE_YN) " & _
                  " VALUES " & _
                  " ('8888', @userId, @userNm, '', '', '', '', '', '01', '', '', '20120716', '', '', '', '0001', '01', '01', @teamName, '', '');"

            handler.SetQuery(sql)
            handler.ClearParameters()
            handler.Parameters("@userId", "5555")
            handler.Parameters("@userNm", "최진원")
            handler.Parameters("@teamName", "21세기전략부")

            Dim returnCount As Integer = handler.Execute()

            WriteLog("returnCount[" & returnCount & "] 입력되었습니다.")

        Catch ex As Exception
            WriteLog(Me.Name.ToString & " OpenCustomerPopupMod : " & ex.ToString)
        Finally
            If Not handler Is Nothing Then
                handler.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' select like...
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim handler As MySQLHandler = Nothing
        Dim dataTable As DataTable = Nothing
        Dim userId As String = ""
        Dim userName As String = ""
        Dim sql As String = ""
        Try
            handler = New MySQLHandler()
            'sql = "select * from t_user where user_id like concat(@userId,'%') and com_cd = @comCd"
            sql = "select * from t_user where user_id like @userId and com_cd = @comCd"

            handler.SetQuery(sql)
            handler.Parameters("@userId", "001%")
            handler.Parameters("@comCd", "8888")

            dataTable = handler.DoQuery()

            'If dataTable.Rows.Count > 0 Then
            '    Dim i As Integer
            '    For i = 0 To dataTable.Rows.Count - 1

            '        userId = dataTable.Rows.Item(i).Item("USER_ID").ToString()
            '        userName = dataTable.Rows.Item(i).Item("user_nm").ToString()

            '    Next
            'End If
            For Each row As DataRow In dataTable.Rows
                userId = row("USER_ID").ToString()
                userName = row.Item("user_nm").ToString()
            Next


            WriteLog("userId[" & userId & "] userName[" & userName & "]")
        Catch ex As Exception
            WriteLog(Me.Name.ToString & " OpenCustomerPopupMod : " & ex.ToString)
        Finally
            dataTable = Nothing
            If Not handler Is Nothing Then
                handler.Close()
            End If
        End Try
    End Sub

    Public Sub HandleParametersByExample()
        Dim parameters As Hashtable = New Hashtable

        parameters.Add("test1Key", "test1Val")
        parameters.Add("test2Key", "test2Val")
        parameters.Add("test3Key", "test3Val")
        parameters.Add("test4Key", "test4Val")

        For Each element As DictionaryEntry In parameters
            Console.WriteLine("key[" & element.Key & "] value[" & element.Value & "]")
        Next
    End Sub
End Class


