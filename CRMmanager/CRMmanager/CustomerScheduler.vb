Public Class CustomerScheduler

    'Dim mPeriod As Int16      '알람주기(분)
    'Dim mStartTime As Int16  '알람시작시간(분)

    '' 알람주기는 기본 5분 설정창에서 지정
    '' 알람대상:
    '' 1. 현재시간-일정시작시간 <= 시작시간 & 작업완료='N'
    '' 2. 현재시간-(일정시작시간+연기시간) <= 시작시간 & 작업완료='N'
    '로그인 사람의 일정목록중 알람대상업무를 읽고,
    '업무내용을 리턴한다. 2건이상이면 목록을 리턴한다.


    Public Function GetAlarmList() As DataTable

        Dim sqlStr As String
        Dim dt As New DataTable
        Dim result As Boolean = False
        Dim parameters As Hashtable = New Hashtable

        Try
            'StartTime,EndTime, Users,Title, Description, Location,TimeGap,RegName, SharingType, ShareTypeName, 
            sqlStr = "SELECT S_START_TIME " & _
                     " , date_format(STR_TO_DATE(S_START_TIME,'%Y%m%d%H%i'),'%Y-%m-%d %H:%i') StartTime " & _
                     " , case when S_END_TIME = '' then '' else date_format(STR_TO_DATE(S_END_TIME,'%Y%m%d%H%i'),'%Y-%m-%d %H:%i') end EndTime " & _
                     " , S_COMPANY_COWORKER Users, S_TITLE Title, S_DESC Description, S_WORKOUT_LOC Location" & _
                     " , concat(TIMEDIFF(now() " & _
                     "	             ,STR_TO_DATE(S_START_TIME,'%Y%m%d%H%i') " & _
                     "	            )  " & _
                     "       ,case when (TIMESTAMPDIFF(minute,now() " & _
                     "						          ,STR_TO_DATE(S_START_TIME,'%Y%m%d%H%i') " & _
                     "		                          ) > 0) " & _
                     "             then ' (남음)' " & _
                     "             else ' (지연)' end " & _
                     "       ) TimeGap " & _
                     " , REGISTRANT RegName,SHARING_TYPE SharingType" & _
                     " , case sharing_type when 'S' then '내부일정(공유)' when 'P' then '내부일정(개인)' when 'O' then '고객응대' end ShareTypeName" & _
                     "  From t_schedule " & _
                     " Where COM_CD=@gsComCd " & _
                     " AND S_START_TIME <=  date_format(now() + interval (@sStartTime - IFNULL(DELAY_MINUTE,0)) minute, '%Y%m%d%H%i') " & _
                     " AND S_START_TIME >= concat(date_format(now(),'%Y%m%d'),'0000') " & _
                     " AND JOB_DONE = 'N' " & _
                     " AND S_COMPANY_COWORKER LIKE @gsUserId" & _
                     " order by s_start_time "

            parameters.Add("@gsUserId", "%" & gsUSER_ID & "%")
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@sStartTime", gbAlarmInfo.AlarmStart)

            dt = MiniCTI.DoQuery(sqlStr, parameters)

        Catch ex As Exception
            Call WriteLog("미리알림 목록 조회 실패:" & ex.Message)
            Return Nothing
        Finally
            dt = Nothing
        End Try

        Return dt

    End Function

    ''' <summary>
    ''' 알람창을 통해, 알림해제 및 연기시간을 일정정보에 업데이트함
    ''' </summary>
    ''' <param name="alarmSchedule"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateAlarmSchedule(ByVal alarmSchedule As ConstDef.AlarmSchedule) As Boolean

        Dim result As Boolean = True
        Dim sqlStr As String = ""
        Dim resultCnt As Integer
        Dim parameters As Hashtable = New Hashtable

        Try
            Dim userName As String = gsUSER_ID & "." & gsUSER_NM

            'sqlStr = "Update t_schedule " & _
            '        "set JOB_DONE ='" & If(alarmSchedule.JobDone, "Y", "N") & "' " & _
            '        ",DELAY_MINUTE='" & alarmSchedule.DelayMinute & "'" & _
            '       " Where COM_CD='" & gsCOM_CD & "'" & _
            '       "   AND S_START_TIME='" & alarmSchedule.StartTime & "'" & _
            '       "   AND REGISTRANT LIKE '" & gsUSER_ID.Trim & ".%'" & _
            '       "   AND S_COMPANY_COWORKER LIKE '" & alarmSchedule.CompanyCoworker & "%'" & _
            '       "   AND SHARING_TYPE='" & alarmSchedule.SharingType & "'" & _
            '       "   AND S_TITLE='" & MiniCTI.ToQuotedStr(alarmSchedule.Title) & "' "
            sqlStr = "Update t_schedule " & _
                    "set JOB_DONE =@jobDone " & _
                    ",DELAY_MINUTE=@delayMinute " & _
                   " Where COM_CD=@gsComCd " & _
                   "   AND S_START_TIME= @sStartTime " & _
                   "   AND REGISTRANT LIKE @registrant " & _
                   "   AND S_COMPANY_COWORKER LIKE @sCompanyCoWorker " & _
                   "   AND SHARING_TYPE=@sharingType " & _
                   "   AND S_TITLE=@sTitle "

            parameters.Add("@jobDone", If(alarmSchedule.JobDone, "Y", "N"))
            parameters.Add("@delayMinute", alarmSchedule.DelayMinute)
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@sStartTime", alarmSchedule.StartTime)
            parameters.Add("@registrant", gsUSER_ID.Trim & ".%")
            parameters.Add("@sCompanyCoWorker", alarmSchedule.CompanyCoworker & "%")
            parameters.Add("@sharingType", alarmSchedule.SharingType)
            parameters.Add("@sTitle", alarmSchedule.Title)

            resultCnt = MiniCTI.DoExecuteNonQuery(sqlStr, parameters)

        Catch ex As Exception
            Call WriteLog("미리알림 일정 변경 실패:" & ex.Message)
            result = False
            'Finally
        End Try

        Return result

    End Function

End Class
