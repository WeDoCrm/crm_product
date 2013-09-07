Public Class FRM_DETAIL_POPUP

    Public parentFrm As Windows.Forms.Form
    Dim mCustomerHistory As CustomerHistory
    Dim mJobType As JobType

    Public Function OpenDetail(ByVal jobType As JobType, ByVal customerHIstory As CustomerHistory) As Boolean

        txtCustomerName.Text = customerHIstory.CustomerNm
        txtTongDD.Text = customerHIstory.TongDD
        txtTongTime.Text = customerHIstory.TongTime
        txtTongContents.Text = customerHIstory.TongContents
        txtTongTel.Text = customerHIstory.TongTelNo

        mJobType = jobType
        mCustomerHistory = customerHIstory

        Select Case mJobType

            Case jobType.CONSULT
                Me.Text = "고객상담내역"
                txtResult.Text = customerHIstory.ConsultResult

            Case jobType.TRANSFER
                Me.Text = "이관업무내역"
                txtResult.Text = customerHIstory.ConsultResult

            Case jobType.CALLBACK
                Me.Text = "콜백업무내역"
                txtResult.Text = customerHIstory.CallBackResult

        End Select

    End Function

    ''' <summary>
    ''' 상담, 콜백인 경우.. 상태변경
    ''' 1. 상담 Consult_Result = '01'
    ''' 2. 콜백 Callback_result = '1'
    '''    상담-콜백 연동인 경우 Consult_Result = '01'
    ''' 
    ''' 이관건이 이미 생성된 경우 상태변경
    ''' 1. Update_date, 
    ''' 2. Consult_result
    ''' 3. Callback_result    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function updateCustomerHistory() As Boolean
        Dim result As Boolean = True
        Dim handler As MySQLHandler = Nothing
        Dim dataTable As DataTable = Nothing
        Dim sql As String = ""
        Dim strDate As String
        Try
            handler = New MySQLHandler()

            strDate = Format(Now, "yyyyMMddHHmmss")
            sql = "UPDATE T_CUSTOMER_HISTORY "

            sql = sql & " SET CONSULT_RESULT = @ConsultResult_Completed"   ' 상담결과
            If mJobType = JobType.CALLBACK Then
                sql = sql & " ,CALL_BACK_RESULT= @CallBackResult_Completed"   ' 콜백처리결과
            End If

            sql = sql & " ,TONG_CONTENTS = @contents "    ' 통화내용
            sql = sql & ",UPDATE_DATE= @strDate "
            sql = sql & " WHERE COM_CD =  @gsCOM_CD"

            sql = sql & " AND CUSTOMER_ID = @customerId "
            sql = sql & " AND TOND_DD =  @tongDD "
            sql = sql & " AND TONG_TIME =  @tongTime "

            handler.SetQuery(sql)
            handler.Parameters("@contents", txtTongContents.Text.Trim)
            handler.Parameters("@strDate", strDate)

            handler.Parameters("@customerId", mCustomerHistory.CustomerId)
            handler.Parameters("@tongDD", mCustomerHistory.TongDD.Trim.Replace(" - ", ""))
            handler.Parameters("@tongTime", mCustomerHistory.TongTime.Trim.Replace(":", ""))

            Dim returnCount As Integer = handler.Execute()

            WriteLog("returnCount[" & returnCount & "] 입력되었습니다.")

            MsgBox("데이터가 수정되었습니다.", MsgBoxStyle.OkOnly, "알림")

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
            result = False
        Finally
            If Not handler Is Nothing Then
                handler.Close()
            End If
        End Try

        Return result

    End Function


    ''' <summary>
    ''' 이관인 경우만 해당
    ''' 이관인 경우 consult_result = '06'인 건외에 
    ''' 이관건 별도 생성
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function insertCustomerHistory() As Boolean

        Dim result As Boolean = True
        Dim handler As MySQLHandler = Nothing
        Dim dataTable As DataTable = Nothing
        Dim sql As String = ""
        Dim tm As String
        Try
            handler = New MySQLHandler()

            tm = Format(Now, "yyyyMMddHHmmss")

            sql = "INSERT INTO T_CUSTOMER_HISTORY( "
            sql = sql & " COM_CD        ,CUSTOMER_ID    ,TOND_DD        ,TONG_TIME"
            sql = sql & ",CALL_TYPE     ,CONSULT_RESULT ,CONSULT_TYPE"
            sql = sql & ",TONG_CONTENTS ,TONG_USER      ,CUSTOMER_NM "
            sql = sql & ",TONG_TELNO    ,HANDLE_TYPE    ,CALL_BACK_YN "
            sql = sql & ",UPDATE_DATE   ,PREV_TONG_DD   ,PREV_TONG_TIME"
            sql = sql & ", PREV_TONG_USER, TRANS_YN)"
            sql = sql & " values( @gsCOM_CD "
            sql = sql & " ,@customerId "
            sql = sql & " ,@strDate "   ' 변경된 통화일자
            sql = sql & " ,@strTime "  '  변경된 통화시간

            sql = sql & " ,@callType"    ' 콜타입

            sql = sql & " ,@consultResultCompleted "   ' 상담결과

            sql = sql & " ,@consultType"    ' 상담유형

            sql = sql & " ,@contents"    ' 통화내용
            sql = sql & " ,@tongUser"    ' 통화자

            sql = sql & " ,@customerNm"     ' 고객명

            sql = sql & " ,@tongTelNo"    ' 통화전화번호

            sql = sql & " ,@handleType"    ' 처리유형

            sql = sql & " ,@callbackYN "    ' 콜백여부

            sql = sql & ",@updateDate"

            sql = sql & " ,@prevTongDD"   ' 이전통화일자
            sql = sql & " ,@prevTongTime"   ' 이전통화시간
            sql = sql & " ,@prevTongUser"    ' 통화자
            sql = sql & " ,'Y'"    ' 이관처리여부
            sql = sql & ")"

            handler.SetQuery(sql)
            handler.Parameters("@gsCOM_CD", gsCOM_CD)
            handler.Parameters("@customerId", mCustomerHistory.CustomerId)
            handler.Parameters("@strDate", tm.Substring(0, 8))
            handler.Parameters("@strTime", tm.Substring(8, 6))
            handler.Parameters("@callType", mCustomerHistory.CallType)
            handler.Parameters("@consultResultCompleted", ConsultResult_Completed)
            handler.Parameters("@consultType", MiniCTI.GetCode(mCustomerHistory.ConsultType))
            handler.Parameters("@contents", txtTongContents.Text)
            handler.Parameters("@tongUser", mCustomerHistory.TongUser)
            handler.Parameters("@constomerNm", mCustomerHistory.CustomerNm)

            handler.Parameters("@tongTelNo", mCustomerHistory.TongTelNo)
            handler.Parameters("@handleType", MiniCTI.GetCode(mCustomerHistory.HandleType))
            handler.Parameters("@callbackYN", mCustomerHistory.CallBackYN)
            handler.Parameters("@updateDate", Format(Now, "yyyyMMddHHmmss"))
            handler.Parameters("@prevTongDD", mCustomerHistory.TongDD.Replace("-", ""))
            handler.Parameters("@prevTongTime", mCustomerHistory.TongTime.Replace(":", ""))
            handler.Parameters("@prevTongUser", mCustomerHistory.TongUser)

            Dim returnCount As Integer = handler.Execute()

            WriteLog("returnCount[" & returnCount & "] 입력되었습니다.")

            MsgBox("데이터가 수정되었습니다.", MsgBoxStyle.OkOnly, "알림")

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
            result = False
        Finally
            If Not handler Is Nothing Then
                handler.Close()
            End If
        End Try

        Return result

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            'parentFrm.Tag = Setting_Address()
            '이관건 최초 처리인경우
            If MiniCTI.GetCode(mCustomerHistory.ConsultResult, ConsultResult_Transfered) = ConsultResult_Transfered Then
                insertCustomerHistory()
            Else '상담건/콜백건/이관건수정
                updateCustomerHistory()
            End If
            Me.Close()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            'parentFrm.Tag = Setting_Address()
            Me.Close()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try

    End Sub
End Class