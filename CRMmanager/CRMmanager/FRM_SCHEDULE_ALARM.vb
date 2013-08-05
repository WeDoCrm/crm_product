Imports System.Xml
''' <summary>
''' 기능 : 
''' 1. 일정을 디스 플레이
''' 2. 해당 일정에 대해 알람기능해제
''' 
''' </summary>
''' <remarks></remarks>
Public Class FRM_SCHEDULE_ALARM

    Private mAlarmSchedule As ConstDef.AlarmSchedule = New AlarmSchedule

    Private mScheduler As CustomerScheduler = New CustomerScheduler()

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Me.Close()
    End Sub

    Private Sub FRM_SCHEDULE_ALARM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '선택시간설정
        btnRelease.Enabled = False
    End Sub

    Public Sub RefreshAlarmList()
        Dim dataTable As DataTable = mScheduler.GetAlarmList()
        DisplayAlarmList(dataTable)
    End Sub

    ''' <summary>
    ''' 1. 상단 그리드 보여줌
    ''' 2. 그리드 최종내역 하단에 상세에 보여줌
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisplayAlarmList(ByVal dataTable As DataTable)
        DisplayGrid(dataTable)
        DisplayDetail(0)
    End Sub

    ''' <summary>
    ''' 상단 목록을 보여줌
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayGrid(ByVal dataTable As DataTable)

        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            DGViewAlarmSchedule.AutoGenerateColumns = False
            DGViewAlarmSchedule.DataSource = dataTable

            For value As Integer = 0 To DGViewAlarmSchedule.RowCount - 1
                DGViewAlarmSchedule.Rows(value).Cells("UserNameList").Value = _
                   MiniCTI.GetUserList(DGViewAlarmSchedule.Rows(value).Cells("Users").Value)
            Next


        Catch ex As Exception
            Call WriteLog(Me.Name & ": " & ex.ToString)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            dataTable = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' 목록중 최종내용을 하단에 디스플레이
    ''' </summary>
    ''' <param name="rowIndex"></param>
    ''' <remarks></remarks>
    Private Sub DisplayDetail(ByVal rowIndex As Integer)

        'StartTime,Users,Title, Description, Location,TimeGap,RegName, SharingType, ShareTypeName,

        With DGViewAlarmSchedule.Rows(rowIndex)

            lblUsers.Text = .Cells("UserNameList").Value.ToString
            ToolTipLabelUsers.SetToolTip(lblUsers, lblUsers.Text)


            If .Cells("SharingType").Value.ToString <> ConstDef.SharingType_O Then
                lblStartTime.Text = .Cells("StartTime").Value.ToString
                lblEndTime.Text = .Cells("EndTime").Value.ToString
                lblTimeBetween.Visible = True
                lblEndTime.Visible = True

                lblContents.Text = .Cells("Title").Value.ToString & _
                                           vbNewLine & .Cells("Description").Value.ToString
            Else
                lblStartTime.Text = .Cells("StartTime").Value.ToString
                lblTimeBetween.Visible = False
                lblEndTime.Visible = False

                lblContents.Text = .Cells("Title").Value.ToString & _
                                           vbNewLine & .Cells("Location").Value.ToString & _
                                           vbNewLine & .Cells("Description").Value.ToString
            End If
            ToolTipLabelDesc.SetToolTip(lblContents, lblContents.Text)


            mAlarmSchedule.StartTime = .Cells("S_START_TIME").Value.ToString
            mAlarmSchedule.Title = .Cells("Title").Value.ToString
            mAlarmSchedule.Users = .Cells("Users").Value.ToString
            mAlarmSchedule.Registrant = .Cells("RegName").Value.ToString
            mAlarmSchedule.SharingType = .Cells("SharingType").Value.ToString

            btnRelease.Enabled = True

        End With

    End Sub



    ''' <summary>
    ''' 해당건에 대해 미리알림건 해제
    ''' ALARM_MINUTE = -1로 설정
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelease.Click
        mAlarmSchedule.JobDone = True
        mScheduler.UpdateAlarmSchedule(mAlarmSchedule)
        'RefreshAlarmList()
        Me.Close()
    End Sub


    ''' <summary>
    ''' 목록을 클릭하면 하단 상세내용을 반영한다. 
    ''' 알림해제버튼을 활성화 시킨다.
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DGViewAlarmSchedule_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGViewAlarmSchedule.CellMouseClick
        Try
            If e.RowIndex < 0 OrElse e.RowIndex = DGViewAlarmSchedule.Rows.Count Then
                btnRelease.Enabled = False
                Return
            End If

            DisplayDetail(e.RowIndex)

        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 선택항목을 일정관리창에서 오픈함
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DGViewAlarmSchedule_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGViewAlarmSchedule.CellMouseDoubleClick

        Try
            If e.RowIndex < 0 OrElse e.RowIndex = DGViewAlarmSchedule.Rows.Count Then
                btnRelease.Enabled = False
                Return
            End If

            DisplayDetail(e.RowIndex)

            Dim frm As FRM_MAIN = Me.MdiParent

            Call frm.OpenSchedule(mAlarmSchedule)

        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try
    End Sub
End Class