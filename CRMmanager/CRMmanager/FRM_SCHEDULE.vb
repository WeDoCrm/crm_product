''' <summary>
'''sharing_type 0 외근관리  - drpGubun 1  외근관리  
'''             P 일정관리(비공유) - drpGubun 0 일정관리
'''             S 일정관리(공유  ) - drpGubun 0 일정관리
'''Sharing 1 sharing_type S
'''Sharing 0 sharing_type 0, P
''' 
''' 외근관리-> 고객약속
''' 
''' 1. 고객약속
'''  약속일시
'''  수행자
'''  등록자
'''  약속제목 - "고객약속"
'''  약속사유(007-외근사유)
'''  약속장소
'''  세부내용
''' 2. 일정관리
'''  시작시간 - 종료시간
'''  공유/비공유
'''  내용
'''  팀명 and 참석자
'''  
''' 
''' 초기화: 
''' 저장: 초기화->하단디스플레이->우측디스플레이
''' 삭제: 초기화->하단디스플레이->우측디스플레이
''' 
''' </summary>
''' <remarks></remarks>
Public Class FRM_SCHEDULE

    Private selectedDate As String = ""
    Private labelSelectedDay As Label = New Label

    Private ColorClicked As Color = Color.LightSteelBlue 'Color.WhiteSmoke
    Private ColorEntered As Color = Color.Khaki
    Private ColorNone As Color = Color.White


    Private Sub FRM_SCHEDULE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            SettoolBar(False, False, True, True, False, True, True)
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub FRM_SCHEDULE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            InitCtrls()
            DisplayCalendar()
            DPYear.Value = Today
            DPMonth.Value = Today
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 각 콤보박스의 코드값설정. 로딩시 호출함
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitCtrls()
        Dim dt As DataTable
        Try
            Me.WindowState = FormWindowState.Maximized

            '팀명
            Dim strSelectTeam As String = _
                   "SELECT '' S_MENU_CD, '-' S_MENU_NM " & _
                   " UNION " & _
                   "SELECT S_MENU_CD, S_MENU_NM " & _
                   "  FROM T_S_CODE " & _
                   " WHERE COM_CD='" & gsCOM_CD & "'" & _
                   "   AND L_MENU_CD='010' " & _
                   " ORDER BY S_MENU_CD"
            '외근자
            Dim strSelectUser As String = _
                    "SELECT '' USER_ID, '-' USER_NM " & _
                    " UNION " & _
                    "SELECT USER_ID, Concat(USER_ID,'.',USER_NM) USER_NM " & _
                    "  FROM t_user " & _
                    " Where COM_CD='" & gsCOM_CD & "'" & _
                    "   AND (RETIRE_DD IS NULL OR RTRIM(RETIRE_DD)='') " & _
                    " Order By USER_ID "
            '약속유형
            Dim strSelectContactType As String = _
                    "SELECT '' S_MENU_CD, '-' S_MENU_NM " & _
                    " UNION " & _
                    "SELECT S_MENU_CD, S_MENU_NM " & _
                    "  FROM T_S_CODE " & _
                    " WHERE COM_CD='" & gsCOM_CD & "'" & _
                    "   AND L_MENU_CD='007' " & _
                    " ORDER BY S_MENU_CD "


            DPYear.CustomFormat = "yyyy"
            DPMonth.CustomFormat = "MM"
            DPYear.Value = New Date(DPYear.Value.Year, DPMonth.Value.Month, 1)
            DPMonth.Value = New Date(DPYear.Value.Year, DPMonth.Value.Month, 1)


            '=======고객응대============
            txtTitleCustSchedule.MaxLength = 50
            txtWLocCustSchedule.MaxLength = 30
            txtDescCustSchedule.MaxLength = 200

            txtTitleCustSchedule.ImeMode = Windows.Forms.ImeMode.Hangul
            txtWLocCustSchedule.ImeMode = Windows.Forms.ImeMode.Hangul
            txtDescCustSchedule.ImeMode = Windows.Forms.ImeMode.Hangul

            dtpDateCustSchedule.Value = Now

            CB_Set2(cboHourCustSchedule, "datetime", 0, 23, 1, "")
            CB_Set2(cboMinCustSchedule, "datetime", 0, 50, 10, "")
            cboHourCustSchedule.Text = "00"
            cboMinCustSchedule.Text = "00"

            CB_Set(gsConString, strSelectUser, cboUserCustSchedule, "USER_NM", "USER_ID", "") '약속응대자

            CB_Set(gsConString, strSelectContactType, cboWReasonCustSchedule, "S_MENU_NM", "S_MENU_CD", "") '약속유형

            '=======내부일정============
            txtTitleInternal.MaxLength = 50
            txtDescInternal.MaxLength = 200

            txtTitleInternal.ImeMode = Windows.Forms.ImeMode.Hangul
            txtDescInternal.ImeMode = Windows.Forms.ImeMode.Hangul

            dtpStartInternal.Value = Now
            dtpEndInternal.Value = Now
            CB_Set2(cboHourStartInternal, "datetime", 0, 23, 1, "")
            CB_Set2(cboHourEndInternal, "datetime", 0, 23, 1, "")
            CB_Set2(cboMinStartInternal, "datetime", 0, 50, 10, "")
            CB_Set2(cboMinEndInternal, "datetime", 0, 50, 10, "")
            cboHourStartInternal.Text = "00"
            cboHourEndInternal.Text = "23"
            cboMinStartInternal.Text = "00"
            cboMinEndInternal.Text = "50"

            '팀명
            CB_Set(gsConString, strSelectTeam, cboTeam, "S_MENU_NM", "S_MENU_CD", gsTeam_CD)


            '달력에 있는 라벨 클릭 이벤트에 Day_Click 함수 연결
            Dim obj As Label = New Label
            For Each ctrl In FlowLayoutPanel1.Controls
                If ctrl.GetType() Is obj.GetType Then
                    obj = ctrl
                    AddHandler obj.Click, AddressOf Day_Click
                    AddHandler obj.MouseEnter, AddressOf Calendar_MouseEnter
                    AddHandler obj.MouseLeave, AddressOf Calendar_MouseLeave
                End If
            Next

        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub Calendar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CType(sender, Label).BackColor = ColorClicked Then
            CType(sender, Label).BackColor = ColorNone
        End If
    End Sub

    Private Sub Calendar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CType(sender, Label).BackColor = ColorClicked Then
            CType(sender, Label).BackColor = ColorEntered
        End If
    End Sub

    Private Sub UserList_Setting()
        Dim dt As DataTable
        Dim i As Short
        Dim item1 As DataRowView
        Dim Team_cd As String = ""
        Dim sqlStr As String = ""
        Try
            '팀선택한지 체크 후 팀코드
            If cboTeam.SelectedIndex > -1 AndAlso cboTeam.SelectedValue.ToString.Contains("System.") = False Then
                Team_cd = cboTeam.SelectedValue.ToString()
            End If

            sqlStr = "SELECT USER_ID, Concat(USER_ID,'.',USER_NM) USER_NM, TEAM_CD, TEAM_NM " & _
                   "From t_user a " & _
                   "Where COM_CD='" & gsCOM_CD & "'" & _
                   " AND TEAM_CD like '" & Team_cd & "%' AND (RETIRE_DD IS NULL OR RTRIM(RETIRE_DD)='') "
            CB_Set(gsConString, sqlStr, lboTeamUserTemp, "USER_NM", "USER_ID", "")

            '목록 갱신
            lboTeamUserList.BeginUpdate()
            lboTeamUserList.Items.Clear()
            For i = 0 To lboTeamUserTemp.Items.Count - 1
                item1 = lboTeamUserTemp.Items(i)
                If lboTeamUserSelected.FindString(item1.Row(1).ToString) < 0 Then _
                    lboTeamUserList.Items.Add(item1.Row(1).ToString) 'item1.Row(0) : ValueMember, item1.Row(1) : DisplayMember
            Next
            lboTeamUserList.EndUpdate()

        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' 동적으로 칼렌더 디스플레이
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayCalendar()
        Try
            Dim obj As Label = New Label
            Dim i As Short = 0
            Dim j As Short = 0
            Dim cur_month As Integer = DPMonth.Value.Month
            Dim startday As Date = New Date(DPYear.Value.Year, DPMonth.Value.Month, 1)
            Dim startdayofweek As Short = CShort(startday.DayOfWeek)
            'startday.DayOfWeek :1(sun:0, sat:6)   startday.DayOfWeek.ToString : Monday 

            For Each ctrl In FlowLayoutPanel1.Controls
                If ctrl.GetType() Is obj.GetType Then
                    obj = ctrl
                    obj.Image = Nothing
                    obj.BackColor = ColorNone
                    obj.BorderStyle = BorderStyle.None
                    'WriteLog(Me.Name & " : j=" & j.ToString & " startdayofweek=" & startdayofweek.ToString & " i=" & i.ToString & " startday.AddDays(i).Month=" & startday.AddDays(i).Month.ToString & " DTMonth=" & cur_month)
                    If j < 7 AndAlso j < startdayofweek Then
                        obj.Text = ""
                        obj.Enabled = False
                    Else
                        obj.Enabled = Enabled
                        If startday.AddDays(i).Month = cur_month Then
                            i += 1
                            '날짜 지정
                            obj.Text = i.ToString
                            '요일별 폰트 색상 지정
                            Select Case startday.AddDays(i - 1).DayOfWeek
                                Case DayOfWeek.Sunday
                                    obj.ForeColor = Color.Red
                                Case DayOfWeek.Saturday
                                    obj.ForeColor = Color.Blue
                                Case Else
                                    obj.ForeColor = Color.Black
                            End Select
                            '오늘 표시
                            If startday.AddDays(i - 1) = Today Then
                                obj.BorderStyle = BorderStyle.FixedSingle
                            End If
                        Else
                            obj.Text = ""
                            obj.Enabled = False
                        End If
                    End If

                    j += 1
                    'WriteLog(Me.Name & " : " & obj.Name & "-" & obj.Text & "-" & obj.Tag)
                End If
            Next

            GetCalendarInfo()

        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' 생성된 칼렌더에 일정이 있는 경우 "시계"마크를 해줌.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCalendarInfo()
        Dim dt As DataTable
        Dim i As Short
        Dim obj As Label = New Label
        Dim tmpDate As String
        Dim sqlStr As String = ""

        'Dim tmpPath As String = Application.StartupPath & "\resources\mark1.bmp"
        'WriteLog(Me.Name & " : tmpPath=" & tmpPath)
        Try
            sqlStr = "SELECT SUBSTRING(S_START_TIME,1,8) S_START_DD " & _
                   " ,SUBSTRING(S_END_TIME,1,8) S_END_DD " & _
                   " ,if(SHARING_TYPE = 'S',1,0) SHARING " & _
                   " ,SHARING_TYPE " & _
                   " FROM t_schedule  " & _
                   " WHERE COM_CD='" & gsCOM_CD & _
                   "' AND ( S_START_TIME between '" & DPYear.Text & DPMonth.Text & "320000' and '" & DPYear.Text & DPMonth.Text & "000000'" & _
                   "     OR ( S_START_TIME <= '" & DPYear.Text & DPMonth.Text & "320000' and  S_END_TIME >= '" & DPYear.Text & DPMonth.Text & "000000'))" & _
                   " AND ((SHARING_TYPE = '" & ConstDef.SharingType_P & "' AND REGISTRANT LIKE '" & gsUSER_ID.Trim & ".%')" & _
                   "      OR SHARING_TYPE = '" & ConstDef.SharingType_S & "' OR SHARING_TYPE = '" & ConstDef.SharingType_O & "')" & _
                   " ORDER BY S_START_TIME, S_END_TIME "
            dt = MiniCTI.DoQuery(gsConString, sqlStr)

            For i = 0 To dt.Rows.Count - 1
                For Each ctrl In FlowLayoutPanel1.Controls
                    If ctrl.GetType() Is obj.GetType Then
                        obj = ctrl
                        tmpDate = DPYear.Text & DPMonth.Text & If(obj.Text.Length = 2, obj.Text, "0" & obj.Text)
                        tmpDate = If(tmpDate.Length = 8, tmpDate, "")
                        If obj.Text.Trim <> "" AndAlso _
                            dt.Rows(i).Item(0).ToString <= tmpDate AndAlso dt.Rows(i).Item(1).ToString >= tmpDate Then
                            'obj.Image = Image.FromFile(tmpPath)
                            ' obj.Image = PictureBox2.Image  '20*20
                            obj.Image = PictureBox2.Image  '15*15

                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Function SelectDay(ByVal day As String) As Boolean
        Dim sqlStr As String = ""
        Dim result As Boolean = False

        Try
            If day = "" Then
                Return False
            End If

            For Each ctrl In FlowLayoutPanel1.Controls
                If TypeOf ctrl Is Label Then
                    '선택일자 라벨인 경우
                    If day <> "" AndAlso CType(ctrl, Label).Text = day Then
                        ctrl.BackColor = ColorClicked
                    Else ' 그외 일자인 경우
                        ctrl.BackColor = ColorNone
                    End If
                End If
            Next

            Dim selDay As String = If(day.Length = 1, "0" & day, day)
            Dim selFullDate = DPYear.Text & DPMonth.Text & selDay
            sqlStr = "SELECT date_format(STR_TO_DATE(S_START_TIME,'%Y%m%d%H%i'),'%Y-%m-%d %H:%i') S_START_TIME " & _
                     " , case when S_END_TIME = '' then '' else " & _
                     "             date_format(STR_TO_DATE(S_END_TIME,'%Y%m%d%H%i'),'%Y-%m-%d %H:%i') end S_END_TIME " & _
                   " ,if(SHARING_TYPE = 'P',0,1) SHARING, REGISTRANT, SHARING_TYPE " & _
                   ", if(SHARING_TYPE = 'O','고객약속','일정관리') SHARING_TYPE2 " & _
                   ", S_TITLE, S_DESC, S_COMPANY_COWORKER, S_WORKOUT_REASON, S_WORKOUT_LOC " & _
                   " FROM t_schedule  " & _
                   " WHERE COM_CD='" & gsCOM_CD & "'" & _
                   " AND ( S_START_TIME like '" & selFullDate & "%'" & _
                   "     OR ( S_START_TIME <= '" & selFullDate & "2400' and  S_END_TIME >= '" & selFullDate & "0000'))" & _
                   " AND ((SHARING_TYPE = 'P' AND REGISTRANT LIKE '" & gsUSER_ID.Trim & ".%')" & _
                   "      OR SHARING_TYPE = 'S' OR SHARING_TYPE = 'O')" & _
                   " ORDER BY S_START_TIME, S_END_TIME, SHARING_TYPE, REGISTRANT "
            GV_DataBind(gsConString, sqlStr, DataGridView1)

            '일정참석자 정보 할당
            For value As Integer = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(value).Cells("COWORKER").Value = _
                   MiniCTI.GetUserList(DataGridView1.Rows(value).Cells("S_COMPANY_COWORKER").Value)
            Next

            InitSchedule(False)
            result = True
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally

        End Try
        Return result

    End Function


    ''' <summary>
    ''' 칼렌더의 특정일자 선택=> 하단 일정목록 디스플레이
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Day_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As Label = CType(sender, Label)
        labelSelectedDay = obj
        Dim result As Boolean = SelectDay(obj.Text)

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If e.RowIndex < 0 Then Exit Try
            Dim i As Integer = e.RowIndex
            Dim info As String = ""
            DisplayRightDetail(i)
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub


    ''' <summary>
    ''' 하단 개발 스케쥴 클릭할 때 우측 상세
    ''' </summary>
    ''' <param name="k">하단 목록 인덱스</param>
    ''' <remarks></remarks>
    Private Sub DisplayRightDetail(ByVal k As Short)
        Dim dt As DataTable
        Try
            If k < 0 Then Exit Try
            'DataGridView1 컬럼 : S_START_TIME, S_END_TIME, SHARING, SHARING_TYPE2, REGISTRANT, S_TITLE, SHARING_TYPE, S_DESC, S_COMPANY_COWORKER, S_WORKOUT_REASON, S_WORKOUT_LOC
            '데이타 포맷: 201108051900  201108060000    0   일정관리    0001.개똥이	전체회식1   P	'전체' "회식1" & ....	0001,0002,0003,0004             
            With DataGridView1.Rows(k)
                If .Cells("SHARING_TYPE").Value.ToString.Trim = "O" Then  ' 0 == 고객약속
                    tabScheduleDetail.SelectFirstTab()
                    txtTitleCustSchedule.Text = .Cells("S_TITLE").Value.ToString
                    dtpDateCustSchedule.Text = .Cells("S_START_TIME").Value.ToString.Trim.Split(" ")(0)
                    cboHourCustSchedule.Text = .Cells("S_START_TIME").Value.ToString.Trim.Split(" ")(1).Split(":")(0)
                    cboMinCustSchedule.Text = .Cells("S_START_TIME").Value.ToString.Trim.Split(" ")(1).Split(":")(1)

                    If .Cells("S_COMPANY_COWORKER").Value.ToString.Trim <> "" Then
                        cboUserCustSchedule.Text = .Cells("S_COMPANY_COWORKER").Value.ToString.Trim.Split(".")(0)
                    End If
                    cboWReasonCustSchedule.SelectedValue = .Cells("S_WORKOUT_REASON").Value.ToString.Trim
                    txtWLocCustSchedule.Text = .Cells("S_WORKOUT_LOC").Value.ToString.Trim
                    txtDescCustSchedule.Text = .Cells("S_DESC").Value.ToString.Trim

                Else ' S/P = 내부일정
                    tabScheduleDetail.SelectLastTab()
                    txtTitleInternal.Text = .Cells("S_TITLE").Value.ToString
                    dtpStartInternal.Text = .Cells("S_START_TIME").Value.ToString.Trim.Split(" ")(0)
                    cboHourStartInternal.Text = .Cells("S_START_TIME").Value.ToString.Trim.Split(" ")(1).Split(":")(0)
                    cboMinStartInternal.Text = .Cells("S_START_TIME").Value.ToString.Trim.Split(" ")(1).Split(":")(1)
                    dtpEndInternal.Text = .Cells("S_END_TIME").Value.ToString.Trim.Split(" ")(0)
                    cboHourEndInternal.Text = .Cells("S_END_TIME").Value.ToString.Trim.Split(" ")(1).Split(":")(0)
                    cboMinEndInternal.Text = .Cells("S_END_TIME").Value.ToString.Trim.Split(" ")(1).Split(":")(1)
                    ckbSharing.Checked = .Cells("SHARING").Value
                    txtDescInternal.Text = .Cells("S_DESC").Value.ToString.Trim
                    cboTeam.SelectedValue = ""
                    lboTeamUserList.Items.Clear()
                    lboTeamUserSelected.Items.Clear()

                    UserList_Setting()
                    'WriteLog("Schedule_Setting>>>  drpGubun:" & drpGubun.SelectedValue & " S_COMPANY_COWORKER:" & .Cells("S_COMPANY_COWORKER").Value.ToString.Trim)
                    '일정관리
                    '20120120 ' If .Cells("S_COMPANY_COWORKER").Value.ToString.Trim <> "" Then
                    If .Cells("S_COMPANY_COWORKER").Value.ToString.Trim <> "" Then
                        Dim str As String() = .Cells("S_COMPANY_COWORKER").Value.ToString.Split(",")
                        Dim i, j As Short
                        lboTeamUserSelected.BeginUpdate()
                        For i = 0 To str.Length - 1
                            j = lboTeamUserTemp.FindString(str(i) & ".")
                            If j > -1 Then
                                lboTeamUserSelected.Items.Add(lboTeamUserTemp.GetItemText(lboTeamUserTemp.Items(j)))
                            End If
                        Next
                        lboTeamUserSelected.EndUpdate()

                        If lboTeamUserList.Items.Count > 0 AndAlso lboTeamUserSelected.Items.Count > 0 Then
                            lboTeamUserList.BeginUpdate()
                            For i = 0 To lboTeamUserSelected.Items.Count - 1
                                If lboTeamUserList.Items.Contains(lboTeamUserSelected.Items(i).ToString) Then
                                    lboTeamUserList.Items.Remove(lboTeamUserSelected.Items(i).ToString)
                                End If
                            Next
                            lboTeamUserList.EndUpdate()
                        End If
                    End If
                End If

                btnDel.Enabled = True
                btnNew.Enabled = True
                btnSave.Enabled = True

            End With
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub


    ''' <summary>
    ''' 우측 상세 초기화
    ''' </summary>
    ''' <param name="clearGridList">true:칼렌더변경으로 하단목록 초기화, false:우측만초기화</param>
    ''' <remarks></remarks>
    Private Sub InitSchedule(ByVal clearGridList As Boolean)
        Try
            If clearGridList Then
                DataGridView1.DataSource = Nothing
                btnDel.Enabled = False
                btnNew.Enabled = True
                btnSave.Enabled = False
            Else
                btnDel.Enabled = False
                btnNew.Enabled = True
                btnSave.Enabled = True
            End If

            '고객응대
            txtTitleCustSchedule.Text = ""
            dtpDateCustSchedule.Value = Now
            cboHourCustSchedule.Text = "00"
            cboMinCustSchedule.Text = "00"
            cboUserCustSchedule.SelectedIndex = cboUserCustSchedule.FindString(gsUSER_ID)
            cboWReasonCustSchedule.SelectedValue = ""
            txtWLocCustSchedule.Text = ""
            txtDescCustSchedule.Text = ""

            '내부일정
            txtTitleInternal.Text = ""
            dtpStartInternal.Value = Now
            cboHourStartInternal.Text = "00"
            cboMinStartInternal.Text = "00"
            dtpEndInternal.Value = Now
            cboHourEndInternal.Text = "23"
            cboMinEndInternal.Text = "50"
            ckbSharing.Checked = False
            txtDescInternal.Text = ""
            cboTeam.SelectedIndex = cboTeam.FindString(gsTeam_CD)
            lboTeamUserList.Items.Clear()
            lboTeamUserSelected.Items.Clear()
            'lboTeamUserTemp.Items.Clear()
            UserList_Setting()

        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 상단 연도 변경 ==> 칼렌더초기화
    ''' 실제 변경아닌 경우 스킵
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DTYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DPYear.ValueChanged
        Try
            If selectedDate = DPYear.Text & DPMonth.Text Then Exit Sub
            selectedDate = DPYear.Text & DPMonth.Text
            DisplayCalendar()
            InitSchedule(True)
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 상단 월 변경 ==>칼렌더 초기화
    ''' 실제 변경 아닌 경우 스킵
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DTMonth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DPMonth.ValueChanged
        Try
            If selectedDate = DPYear.Text & DPMonth.Text Then Exit Sub
            selectedDate = DPYear.Text & DPMonth.Text
            DisplayCalendar()
            InitSchedule(True)
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 오늘로 설정
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_today_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_today.Click
        Try
            If DPYear.Value.Year <> Today.Year Then DPYear.Value = Today
            If DPMonth.Value.Month <> Today.Month Then DPMonth.Value = Today
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub


    Private Sub drpTeam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTeam.SelectedIndexChanged
        Try
            UserList_Setting()
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If lboTeamUserList.SelectedIndex > -1 Then
                If lboTeamUserSelected.Items.Contains(lboTeamUserList.SelectedItem) = False Then
                    lboTeamUserSelected.Items.Add(lboTeamUserList.SelectedItem)
                End If
                lboTeamUserList.Items.Remove(lboTeamUserList.SelectedItem)
                lboTeamUserList.ClearSelected()
                lboTeamUserSelected.ClearSelected()
            End If
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            If lboTeamUserSelected.SelectedIndex > -1 Then
                If lboTeamUserTemp.FindString(lboTeamUserSelected.SelectedItem.ToString) >= 0 _
                        AndAlso lboTeamUserList.Items.Contains(lboTeamUserSelected.SelectedItem) = False Then
                    lboTeamUserList.Items.Add(lboTeamUserSelected.SelectedItem)
                End If
                lboTeamUserSelected.Items.Remove(lboTeamUserSelected.SelectedItem)
                lboTeamUserList.ClearSelected()
                lboTeamUserSelected.ClearSelected()
            End If
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub btnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAll.Click
        Try
            Dim i As Integer
            For i = 0 To lboTeamUserList.Items.Count - 1
                lboTeamUserSelected.Items.Add(lboTeamUserList.Items(i))
            Next
            lboTeamUserList.Items.Clear()
            lboTeamUserList.ClearSelected()
            lboTeamUserSelected.ClearSelected()
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub btnRemove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        Try
            Dim i As Integer
            For i = 0 To lboTeamUserSelected.Items.Count - 1
                lboTeamUserList.Items.Add(lboTeamUserSelected.Items(i))
            Next
            lboTeamUserSelected.Items.Clear()
            lboTeamUserList.ClearSelected()
            lboTeamUserSelected.ClearSelected()
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally

        End Try
    End Sub

    Public Sub gsSave()
        Dim dt As DataTable
        Dim i As Short
        Dim users As String = ""
        Dim sqlStr As String = ""
        Dim whereStr As String = ""
        Dim txCnt As Integer = 0
        Dim startTime As String = ""
        Dim endTime As String = ""
        Dim title As String = ""
        Dim desc As String = ""
        Dim reason As String = ""
        Dim location As String = ""
        Dim sharingType As String = ""

        Try
            '고객일정관리
            If tabScheduleDetail.SelectedTabPage.TabIndex = 0 Then
                If txtTitleCustSchedule.Text.Trim = "" Then
                    MsgBox("제목을 입력하십시오.", MsgBoxStyle.OkOnly, "정보")
                    txtTitleCustSchedule.Focus()
                    Exit Try
                End If

                If cboHourCustSchedule.Text.Trim = "" Then
                    MsgBox("예약시간을 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                    cboHourCustSchedule.Focus()
                    Exit Try
                End If

                If cboMinCustSchedule.Text.Trim = "" Then
                    MsgBox("예약시간을 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                    cboMinCustSchedule.Focus()
                    Exit Try
                End If

                If cboUserCustSchedule.SelectedValue.ToString = "" Then
                    MsgBox("예약담당자를 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                    cboUserCustSchedule.Focus()
                    Exit Try
                End If

                'If cboWReasonCustSchedule.SelectedValue.ToString = "" Then
                '    MsgBox("예약사유를 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                '    cboWReasonCustSchedule.Focus()
                '    Exit Try
                'End If

                ''동일한 내용이 등록되었는지 확인
                startTime = dtpDateCustSchedule.Text.Replace("-", "").Replace("/", "") _
                            & cboHourCustSchedule.Text _
                            & cboMinCustSchedule.Text
                users = cboUserCustSchedule.Text.Trim
                title = MiniCTI.ToQuotedStr(txtTitleCustSchedule.Text)
                desc = MiniCTI.ToQuotedStr(txtDescCustSchedule.Text)
                reason = MiniCTI.ToQuotedStr(cboWReasonCustSchedule.SelectedValue.ToString)
                location = MiniCTI.ToQuotedStr(txtWLocCustSchedule.Text)
                sharingType = ConstDef.SharingType_O

            Else '내부일정관리
                If txtTitleInternal.Text.Trim = "" Then
                    MsgBox("제목을 입력하십시오.", MsgBoxStyle.OkOnly, "정보")
                    txtTitleInternal.Focus()
                    Exit Try
                End If
                If cboHourStartInternal.Text.Trim = "" Then
                    MsgBox("시작시간을 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                    cboHourStartInternal.Focus()
                    Exit Try
                End If
                If cboMinStartInternal.Text.Trim = "" Then
                    MsgBox("시작시간을 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                    cboMinStartInternal.Focus()
                    Exit Try
                End If
                If cboHourEndInternal.Text.Trim = "" Then
                    MsgBox("종료시간을 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                    cboHourEndInternal.Focus()
                    Exit Try
                End If
                If cboMinEndInternal.Text.Trim = "" Then
                    MsgBox("종료시간을 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                    cboMinEndInternal.Focus()
                    Exit Try
                End If

                startTime = dtpStartInternal.Text.Replace("-", "").Replace("/", "") & cboHourStartInternal.Text & cboMinStartInternal.Text
                endTime = dtpEndInternal.Text.Replace("-", "").Replace("/", "") & cboHourEndInternal.Text & cboMinEndInternal.Text

                If startTime > endTime Then
                    MsgBox("시간 설정이 유효하지 않습니다.", MsgBoxStyle.OkOnly, "정보")
                    dtpEndInternal.Focus()
                    Exit Try
                End If


                For i = 0 To lboTeamUserSelected.Items.Count - 1
                    users &= lboTeamUserSelected.Items(i).ToString.Split(".")(0) & ","
                Next
                If users.Trim.Length > 0 Then users = users.Substring(0, users.Trim.Length - 1)
                title = MiniCTI.ToQuotedStr(txtTitleInternal.Text)
                desc = MiniCTI.ToQuotedStr(txtDescInternal.Text)
                reason = ""
                location = ""
                sharingType = If(ckbSharing.Checked = False, ConstDef.SharingType_P, ConstDef.SharingType_S)

            End If

            whereStr = " Where COM_CD='" & gsCOM_CD & "'" & _
                       "   AND S_START_TIME='" & startTime & "'" & _
                       "   AND REGISTRANT LIKE '" & gsUSER_ID.Trim & "'" & _
                       "   AND S_COMPANY_COWORKER LIKE '" & users & "'" & _
                       "   AND SHARING_TYPE='" & sharingType & "'" & _
                       "   AND S_TITLE='" & title & "' "


            Dim userName As String = gsUSER_ID & "." & gsUSER_NM

            sqlStr = "Update t_schedule " & _
                    "set S_END_TIME='" & endTime & "' " & _
                    ",S_COMPANY_COWORKER='" & users & "'" & _
                    ",S_DESC='" & desc & "'" & _
                    ",S_WORKOUT_REASON='" & reason & "'" & _
                    ",S_WORKOUT_LOC='" & location & "' " & _
                    whereStr
            txCnt = MiniCTI.DoExecuteNonQuery(gsConString, sqlStr)

            If txCnt = 0 Then
                sqlStr = "Insert into t_schedule(" & _
                       "COM_CD,S_START_TIME,S_END_TIME" & _
                       ",REGISTRANT,SHARING_TYPE " & _
                       ",S_TITLE,S_COMPANY_COWORKER" & _
                       ",S_DESC,S_WORKOUT_REASON,S_WORKOUT_LOC " & _
                       ") values(" & _
                        "'" & gsCOM_CD & "','" & startTime & "','" & endTime & "'" & _
                        ",'" & userName & "','" & sharingType & "'" & _
                        ",'" & title & "','" & users & "'" & _
                        ",'" & desc & "'" & _
                        ",'" & reason & "'" & _
                        ",'" & location & "') "
                txCnt = MiniCTI.DoExecuteNonQuery(gsConString, sqlStr)
            End If

            If txCnt > 0 Then
                MsgBox("처리되었습니다.", MsgBoxStyle.OkOnly, "정보")
                DisplayCalendar()
                Day_Click(labelSelectedDay, Nothing)
                InitSchedule(False)
            Else
                MsgBox("장애가 발생하여 처리되지 않았습니다.", MsgBoxStyle.OkOnly, "정보")
                Throw New Exception("트랜잭션 오류발생")
            End If

        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub

    Public Sub gsDelete()
        Dim dt As DataTable
        Dim selectStr As String
        Dim deleteStr As String
        Dim whereStr As String
        Dim startTime As String
        Dim users As String
        Dim title As String
        Dim sharingType As String

        Try
            If txtTitleInternal.Text.Trim = "" Then
                MsgBox("삭제할 일정을 다시 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            End If

            selectStr = "SELECT count(S_START_TIME) From t_schedule "

            '고객일정
            If tabScheduleDetail.SelectedTabPage.TabIndex = 0 Then

                startTime = dtpDateCustSchedule.Text.Replace("-", "").Replace("/", "") _
                                            & cboHourCustSchedule.Text _
                                            & cboMinCustSchedule.Text
                users = cboUserCustSchedule.Text.Trim
                title = MiniCTI.ToQuotedStr(txtTitleCustSchedule.Text)
                sharingType = ConstDef.SharingType_O

            Else '내부일정관리

                startTime = dtpStartInternal.Text.Replace("-", "").Replace("/", "") & cboHourStartInternal.Text & cboMinStartInternal.Text
                users = ""
                For i = 0 To lboTeamUserSelected.Items.Count - 1
                    users &= lboTeamUserSelected.Items(i).ToString.Split(".")(0) & ","
                Next
                If users.Trim.Length > 0 Then users = users.Substring(0, users.Trim.Length - 1)
                title = MiniCTI.ToQuotedStr(txtTitleInternal.Text)
                sharingType = If(ckbSharing.Checked = False, ConstDef.SharingType_P, ConstDef.SharingType_S)

            End If

            selectStr = selectStr & _
                   " Where COM_CD='" & gsCOM_CD & "'" & _
                   "   AND S_START_TIME='" & startTime & "'" & _
                   "   AND REGISTRANT LIKE '" & gsUSER_ID.Trim & ".%" & _
                   "   AND S_COMPANY_COWORKER LIKE '%" & users & "%" & _
                   "   AND SHARING_TYPE='" & sharingType & "'" & _
                   "   AND S_TITLE='" & title & "' "

            dt = MiniCTI.DoQuery(gsConString, selectStr)

            If dt.Rows(0).Item(0).ToString.Trim = "0" Then
                MsgBox("삭제할 일정을 다시 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            End If

            dt.Reset()
            MsgBox(txtTitleInternal.Text.Trim & " 일정을 삭제하시겠습니까?", MsgBoxStyle.YesNo, "확인")

            deleteStr = "Delete from t_schedule "
            Dim deleteCnt As Integer = MiniCTI.DoExecuteNonQuery(gsConString, deleteStr & whereStr)

            If deleteCnt > 0 Then
                MsgBox("처리되었습니다.", MsgBoxStyle.OkOnly, "정보")
                DisplayCalendar()
                Day_Click(labelSelectedDay, Nothing)
                InitSchedule(False)
            Else
                MsgBox("장애가 발생하여 처리되지 않았습니다.", MsgBoxStyle.OkOnly, "정보")
                Throw New Exception("트랜잭션 오류발생")
            End If
        Catch ex As Exception
            WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="alarmSchedule"></param>
    ''' <remarks></remarks>
    Public Sub OpenSchedule(ByVal alarmSchedule As ConstDef.AlarmSchedule)

        Dim year As String = alarmSchedule.StartTime.Substring(0, 4)
        Dim month As String = alarmSchedule.StartTime.Substring(4, 2)
        Dim day As String = alarmSchedule.StartTime.Substring(6, 2)

        If SelectDay(day) Then
            For i = 0 To DataGridView1.RowCount - 1
                With DataGridView1.Rows(i)
                    If alarmSchedule.StartTime = .Cells("S_START_TIME").Value.ToString.Trim() _
                        AndAlso alarmSchedule.Registrant = .Cells("REGISTRANT").Value.ToString.Trim() _
                        AndAlso alarmSchedule.Users = .Cells("S_COMPANY_COWORKER").Value.ToString.Trim() _
                        AndAlso alarmSchedule.SharingType = .Cells("SHARING_TYPE").Value.ToString.Trim() _
                        AndAlso alarmSchedule.Title = .Cells("S_TITLE").Value.ToString.Trim() Then
                        DisplayRightDetail(i)
                    End If
                End With
            Next

        End If
    End Sub

    Public Sub gsFormExit()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        gsSave()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        gsDelete()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        InitSchedule(False)
    End Sub

    Private Sub SaveButtonEnable_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitleInternal.TextChanged, txtTitleCustSchedule.TextChanged
        If btnSave.Enabled = False Then
            btnSave.Enabled = True
        End If
    End Sub

End Class