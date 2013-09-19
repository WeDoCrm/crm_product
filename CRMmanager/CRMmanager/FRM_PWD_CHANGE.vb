Public Class FRM_PWD_CHANGE

    Private Sub FRM_PWD_CHANGE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call SetToolBar(False, False, True, False, False, True, True)
    End Sub

    Private Sub FRM_PWD_CHANGE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOldPwd.Text = gsUSER_PWD
        Call SetToolBar(False, False, True, False, False, True, True)
    End Sub

    Public Sub gsSave()
        Dim auditValue As String = ""

        If txtNewPwd.Text.Trim = "" Then
            MsgBox("신규로 지정할 비밀번호를 입력 하세요.", MsgBoxStyle.OkOnly, "알림")
            'MessageBox.Show("신규로 지정할 비밀번호를 입력 하세요")
            txtNewPwd.Focus()
            Exit Sub
        End If

        If txtConfirmPwd.Text.Trim = "" Then
            MsgBox("신규로 지정할 비밀번호를 다시 한번 입력 하세요.", MsgBoxStyle.OkOnly, "알림")
            'MessageBox.Show("신규로 지정할 비밀번호를 다시 한번 입력 하세요")
            txtConfirmPwd.Focus()
            Exit Sub
        End If

        If txtConfirmPwd.Text.Trim <> txtNewPwd.Text.Trim Then
            MsgBox("신규로 지정한 비밀번호가 다릅니다,다시 입력 하세요.", MsgBoxStyle.OkOnly, "알림")
            'MessageBox.Show("신규로 지정한 비밀번호가 다릅니다,다시 입력 하세요")
            txtNewPwd.Text = ""
            txtConfirmPwd.Text = ""
            txtNewPwd.Focus()
            Exit Sub
        End If

        Try
            auditValue = "Old PW:" & txtOldPwd.Text.Trim & ", New PW:" & txtNewPwd.Text.Trim

            Dim sql As String = " UPDATE T_USER SET USER_PWD = @userPwd WHERE COM_CD = @gsComCd AND USER_ID = @gsUserId"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsUserId", gsUSER_ID)
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@userPwd", txtNewPwd.Text.Trim)

            If DoExecuteNonQuery(sql, parameters) < 1 Then
                MsgBox("비밀번호 변경에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
                Throw New Exception("비밀번호 변경 실패")
            End If

            MsgBox("비밀번호가 변경 됐습니다.", MsgBoxStyle.OkOnly, "알림")

            '전역변수에 패스워드를 다시 세팅 해준다
            txtOldPwd.Text = txtNewPwd.Text
            gsUSER_PWD = txtNewPwd.Text.Trim

        Catch ex As Exception
            txtNewPwd.Text = ""
            txtConfirmPwd.Text = ""
            Call WriteLog("FRM_PWD_CHANGE : " & ex.ToString)
        Finally
            If auditValue <> "" Then Call Audit_Log(AUDIT_TYPE.PWD_MOD, auditValue)
        End Try

    End Sub

    Public Sub gsFormExit()
        Try
            Me.Close()
        Catch ex As Exception
            Call WriteLog("FRM_PWD_CHANGE : " & ex.ToString)
        End Try
    End Sub

    'Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    Call gsFormExit()
    'End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Call gsSave()
    'End Sub

    'Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call gsFormExit()
    'End Sub

    'Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '수정
    '    Call gsSave()
    'End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    'End Sub

    Private Sub btnCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseForm.Click
        Call gsFormExit()
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        '수정
        Call gsSave()
    End Sub

    Private Sub FRM_PWD_CHANGE_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Call gsFormExit()
    End Sub
End Class