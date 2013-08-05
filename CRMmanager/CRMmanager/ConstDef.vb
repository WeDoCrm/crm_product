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

    Public Structure AlarmSchedule
        Public ComCd As String
        Public StartTime As String
        Public Title As String
        Public Registrant As String
        Public Users As String
        Public SharingType As String
        Public JobDone As Boolean
        Public DelayMinute As Integer
    End Structure

    Public Const SharingType_O As String = "O" '고객응대
    Public Const SharingType_P As String = "P" '내부일정
    Public Const SharingType_S As String = "S" '내부공유일정


    Public Enum SchedulePanel
        INIT = -1 '하단 grid refresh
        QUERIED = 0
        INSERT = 1
    End Enum
End Module
