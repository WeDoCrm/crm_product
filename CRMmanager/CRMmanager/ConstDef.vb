Public Module ConstDef
    Public Enum ActionStatus
        OpenEmpty = 0
        PopUpInBound = 1
        PopUpOutBound = 2
        PopUpUserExist = 3  '사용자정보, 통화정보 올라온 상태
        PopUpNoUser = 4     '사용자정보 없고 통화정보 올라온 상태
        PopUpDetail = 5     '상담이력 수정 상태
        OpenUserSearched = 6       '사용자정보 조회 - 아웃바운드준비상태
        OpenNoUserSearched = 7 '사용자정보 조회없음 
    End Enum

    Public Enum PANEL_FOCUS
        NONE = -1
        CUSTOMER_INFO = 0
        CONSULT_INFO = 1
        CONSULT_HISTORY = 2
    End Enum

    Enum JobType
        CONSULT = 0
        TRANSFER = 1
        CALLBACK = 2
    End Enum

    Public Structure AlarmSchedule
        Public ComCd As String               'COM_CD
        Public StartTime As String           'S_START_TIME 
        Public Registrant As String          'REGISTRANT
        Public SharingType As String         'SHARING_TYPE
        Public Title As String               'S_TITLE
        Public EndTime As String             'S_END_TIME
        Public Desc As String                'S_DESC
        Public CompanyCoworker As String     'S_COMPANY_COWORKER
        Public WorkoutReason As String       'S_WORKOUT_REASON 
        Public WorkoutLoc As String          'S_WORKOUT_LOC
        Public JobDone As Boolean            'JOB_DONE
        Public CustomerId As String          'CUSTOMER_ID
        Public DelayMinute As Integer        'DELAY_MINUTE
    End Structure

    Public Structure CustomerInfo
        Public ComCd As String         'COM_CD	varchar(4)
        Public CustomerId As Integer   'CUSTOMER_ID	bigint(20) unsigned
        Public CustomerName As String  'CUSTOMER_NM	varchar(20)
        Public CTelNo As String        'C_TELNO	varchar(20)
        Public HTelNo As String        'H_TELNO	varchar(20)
        Public FaxNo As String         'FAX_NO	varchar(20)
        Public Company As String       'COMPANY	varchar(100)
        Public Department As String    'DEPARTMENT	varchar(100)
        Public JobTitle As String      'JOB_TITLE	varchar(100)
        Public Email As String         'EMAIL	varchar(100)
        Public CustomerType As String  'CUSTOMER_TYPE	varchar(4)
        Public TempId As String        'TEMP_ID	varchar(40)
        Public WooNo As String         'WOO_NO	varchar(8)
        Public CustomerAddr As String  'CUSTOMER_ADDR	varchar(120)
        Public CustomerEtc As String   'CUSTOMER_ETC	varchar(100)
        Public CTelNo1 As String       'C_TELNO1	varchar(20)
        Public HTelNo1 As String       'H_TELNO1	varchar(20)
        Public UpdateDate As String    'UPDATE_DATE	varchar(14)
        Public TongUser As String      'TONG_USER	varchar(45)
        Public UserDef As String       'USER_DEF	varchar(100)
    End Structure

    Public Structure CustomerHistory
        Public ComCd As String             'COM_CD	varchar(4)
        Public CustomerId As String        'CUSTOMER_ID	bigint(20) unsigned
        Public TongDD As String            'TOND_DD	varchar(8)
        Public TongTime As String          'TONG_TIME	varchar(6)
        Public TongUser As String          'TONG_USER	varchar(45)
        Public CallType As String          'CALL_TYPE	varchar(1)
        Public ConsultResult As String     'CONSULT_RESULT	varchar(4)
        Public ConsultType As String       'CONSULT_TYPE	varchar(4)
        Public TongContents As String      'TONG_CONTENTS	varchar(100)
        Public TongTelNo As String         'TONG_TELNO	varchar(20)
        Public TelNoType As String         'TELNO_TYPE	varchar(4)
        Public CustomerNm As String        'CUSTOMER_NM	varchar(20)
        Public BkYN As String              'BK_YN	varchar(1)
        Public HandleType As String        'HANDLE_TYPE	varchar(1)
        Public CallBackYN As String        'CALL_BACK_YN	varchar(1)
        Public CallBackResult As String    'CALL_BACK_RESULT	varchar(1)
        Public CallBackAgent As String     'CALL_BACK_AGENT	varchar(50)
        Public UpdateDate As String        'UPDATE_DATE	varchar(14)
        Public PrevTongDD As String        'PREV_TONG_DD	varchar(8)
        Public PrevTongTime As String      'PREV_TONG_TIME	varchar(6)
        Public PrevTongUser As String      'PREV_TONG_USER	varchar(45)
        Public TransYN As String           'TRANS_YN	varchar(1)
        Public TempId As String            'TEMP_ID	varchar(40)
    End Structure

    Public Structure CallHistory
        Public TongStartTime As String 'TONG_START_TIME	varchar(14)
        Public TongEndTime As String   'TONG_END_TIME	varchar(14)
        Public CallType As String      'CALL_TYPE	varchar(1)
        Public Ani As String           'ANI	varchar(20)
        Public TongDuration As Integer  'TONG_DURATION	int(11)
        Public CallResult As String    'CALL_RESULT	varchar(4)
        Public ExtensionNo As String   'EXTENSION_NO	varchar(20)
        Public ComCd As String         'COM_CD	varchar(10)
        Public Callid As String        'CALL_ID	varchar(50)
        Public TongUser As String      'TONG_USER	varchar(45)
        Public PBXType As String       'PBX_TYPE	varchar(1)
    End Structure

    Public Structure UserInfo
        Public ComCd As String         'COM_CD	varchar(4)
        Public UserId As String        'USER_ID	varchar(20)
        Public UserNm As String        'USER_NM	varchar(20)
        Public UsrHP As String         'USR_HP	varchar(20)
        Public Addr1 As String         'ADDR1	varchar(120)
        Public WooNo As String         'WOO_NO	varchar(8)
        Public HTelNo As String        'H_TELNO	varchar(20)
        Public DepartCd As String      'DEPART_CD	varchar(4)
        Public Grade As String         'GRADE	varchar(4)
        Public ExtensionNo As String   'EXTENSION_NO	varchar(10)
        Public WorkType As String      'WORK_TYPE	varchar(4)
        Public EnteringDD As String    'ENTERING_DD	varchar(8)
        Public RetireDD As String      'RETIRE_DD	varchar(8)
        Public UserEmail As String     'USER_EMAIL	varchar(30)
        Public DepartNm As String      'DEPART_NM	varchar(30)
        Public UserPwd As String       'USER_PWD	varchar(50)
        Public WorkArea As String      'WORK_AREA	varchar(2)
        Public TeamCd As String        'TEAM_CD	varchar(4)
        Public TeamNm As String        'TEAM_NM	varchar(30)
        Public MobileUseYN As String   'MOBILE_USE_YN	varchar(1)
        Public ExcelUseYN As String    'EXCEL_USE_YN	varchar(1) 
    End Structure




    Public Const SharingType_O As String = "O" '고객응대
    Public Const SharingType_P As String = "P" '내부일정
    Public Const SharingType_S As String = "S" '내부공유일정


    Public Enum SchedulePanel
        INIT = -1 '하단 grid refresh
        QUERIED = 0
        INSERT = 1
    End Enum

    Public Const ConsultResult_All As String = "all"       '전체
    Public Const ConsultResult_UnDone As String = "02"     '미처리
    Public Const ConsultResult_Completed As String = "01"  '상담완료
    Public Const ConsultResult_Transfered As String = "06" '이관처리

    Public Const CallBackResult_UnDone As String = "2" '미처리
    Public Const CallBackResult_Completed As String = "1" '상담완료

End Module
