﻿Public Class FRM_SAWON

    Private temp As String
    Private temp2 As String = ""

    Private Sub FRM_SAWON_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Call SettoolBar(True, True, True, True, False, True, True)
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub FRM_SAWON_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call Controls_Setting()
            Call gsInit()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub Controls_Setting()
        Try
            Me.WindowState = FormWindowState.Maximized
            Me.Left = 0
            Me.Top = 0

            txtName2.MaxLength = 20
            txtId.MaxLength = 20
            txtName.MaxLength = 20
            txtPW.MaxLength = 50
            txtWorkTelNo1.MaxLength = 4
            txtWorkTelNo2.MaxLength = 4
            txtWorkTelNo3.MaxLength = 4
            cboHP.MaxLength = 3
            txtHP1.MaxLength = 4
            txtHP2.MaxLength = 4
            txtWP1.MaxLength = 3
            txtWP2.MaxLength = 3
            txtExt.MaxLength = 10
            txtAddress.MaxLength = 120
            txtEmail.MaxLength = 30

            txtName2.ImeMode = Windows.Forms.ImeMode.Hangul
            txtAddress.ImeMode = Windows.Forms.ImeMode.Hangul
            txtName.ImeMode = Windows.Forms.ImeMode.Hangul

            DPDate1.Value = Now
            DPDate2.Value = Now

            '직급
            temp = "SELECT '' S_MENU_CD, '-' S_MENU_NM UNION " & _
                    "SELECT S_MENU_CD, S_MENU_NM FROM t_s_code Where COM_CD='" & gsCOM_CD & "' and L_MENU_CD='002' Order By S_MENU_CD "
            CB_Set(gsConString, temp, cboPosition, "S_MENU_NM", "S_MENU_CD", "")
            '등급
            temp = "SELECT '' S_MENU_CD, '-' S_MENU_NM UNION " & _
                    "SELECT S_MENU_CD, S_MENU_NM FROM t_s_code Where COM_CD='" & gsCOM_CD & "' and L_MENU_CD='011' Order By S_MENU_CD "
            CB_Set(gsConString, temp, cboGrade, "S_MENU_NM", "S_MENU_CD", "")

            '팀명
            temp = "SELECT '' S_MENU_CD, '-' S_MENU_NM UNION " & _
                    "SELECT S_MENU_CD, S_MENU_NM FROM t_s_code Where COM_CD='" & gsCOM_CD & "' and L_MENU_CD='010' Order By S_MENU_CD "
            CB_Set(gsConString, temp, cboTeam, "S_MENU_NM", "S_MENU_CD", "")

            Call Controls_Setting2("")

        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub Controls_Setting2(ByVal username As String)
        Try
            'DataGridView1
            temp = "SELECT a.COM_CD, a.USER_ID, a.USER_NM, a.TEAM_CD, a.TEAM_NM " & _
                  ", (select COM_NM from t_company where COM_CD='" & gsCOM_CD & "') COM_NM " & _
                  "From t_user a " & _
                  "Where a.COM_CD='" & gsCOM_CD & "' "

            If username.Trim = "" Then
                temp2 = "order by a.COM_CD, a.TEAM_NM, a.USER_ID, a.USER_NM "
            Else
                temp2 = "and a.USER_NM like '%" & username & "%' " & _
                "order by a.COM_CD, a.TEAM_NM, a.USER_ID, a.USER_NM "
            End If

            GV_DataBind(gsConString, temp & temp2, DataGridView1)

        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If e.RowIndex < 0 Then Exit Try
            Dim i As Integer = e.RowIndex
            Dim info As String = ""
            With DataGridView1.Rows(i)
                info = .Cells("COM_CD").Value.ToString & "^" & .Cells("USER_ID").Value.ToString
            End With
            TabPage1_Setting(info)
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub TabPage1_Setting(ByVal info As String)
        Dim dt As DataTable
        Dim parameters As Hashtable = New Hashtable

        Try
            'info = .Cells("COM_CD").ToString & "^" & .Cells("USER_ID").ToString 
            If info.Trim = "" OrElse info.Contains("^") = False Then Exit Try
            Dim tmp() As String = info.Split("^")

            temp = "SELECT a.COM_CD, a.USER_ID, a.USER_NM, a.USER_PWD, a.H_TELNO, a.USR_HP " & _
                  "       ,if (length(a.WOO_NO) = 6, substring(a.WOO_NO,1,3),'') WOO_NO1, if (length(a.WOO_NO) = 6, substring(a.WOO_NO,4,3),'') WOO_NO2 " & _
                  "       ,a.EXTENSION_NO, a.ADDR1, a.USER_EMAIL, a.DEPART_CD, a.DEPART_NM, a.GRADE, a.WORK_AREA, a.TEAM_CD " & _
                  "       ,if (length(a.ENTERING_DD) = 8, CONCAT(SUBSTRING(a.ENTERING_DD,1,4) , '-' , SUBSTRING(a.ENTERING_DD,5,2) , '-' , SUBSTRING(a.ENTERING_DD,7,2)),'') ENTERING_DD " & _
                  "       ,if (length(a.RETIRE_DD) = 8, CONCAT(SUBSTRING(a.RETIRE_DD,1,4) , '-' , SUBSTRING(a.RETIRE_DD,5,2) , '-' , SUBSTRING(a.RETIRE_DD,7,2)),'') RETIRE_DD " & _
                  "       ,IFNULL(MOBILE_USE_YN,'N') MOBILE_USE_YN ,IFNULL(EXCEL_USE_YN,'N') EXCEL_USE_YN " & _
                  "  From t_user a " & _
                  " Where a.COM_CD = @gsComCd " & _
                  "   and a.USER_ID = @gsUserId "

            parameters.Add("@gsComCd", tmp(0).Trim)
            parameters.Add("@gsUserId", tmp(1).Trim)

            dt = MiniCTI.DoQuery(temp, parameters)

            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    txtId.Text = .Item("USER_ID").ToString
                    txtName.Text = .Item("USER_NM").ToString
                    txtPW.Text = .Item("USER_PWD").ToString
                    'txtTel.Text = Get_TELNO(.Item("H_TELNO").ToString)
                    'txtHP.Text = Get_TELNO(.Item("USR_HP").ToString)
                    txtWP1.Text = .Item("WOO_NO1").ToString
                    txtWP2.Text = .Item("WOO_NO2").ToString
                    txtExt.Text = .Item("EXTENSION_NO").ToString
                    txtAddress.Text = .Item("ADDR1").ToString
                    txtEmail.Text = .Item("USER_EMAIL").ToString
                    cboPosition.SelectedValue = .Item("GRADE").ToString
                    cboGrade.SelectedValue = .Item("WORK_AREA").ToString
                    cboTeam.SelectedValue = .Item("TEAM_CD").ToString
                    ckbMobileUser.Checked = (.Item("MOBILE_USE_YN").ToString = "Y")
                    ckbExcelUseYN.Checked = (.Item("EXCEL_USE_YN").ToString = "Y")

                    If (.Item("H_TELNO").ToString.Trim.Replace("-", "").Length < 9) Then
                        txtWorkTelNo1.Text = ""
                        txtWorkTelNo2.Text = ""
                        txtWorkTelNo3.Text = ""
                    Else
                        Dim telno() As String = gfTelNoTransReturn(.Item("H_TELNO").ToString.Trim.Replace("-", "")).Split("-")

                        txtWorkTelNo1.Text = telno(0)
                        txtWorkTelNo2.Text = telno(1)
                        txtWorkTelNo3.Text = telno(2)
                    End If


                    If (.Item("USR_HP").ToString.Replace("-", "").Length < 9) Then
                        cboHP.SelectedItem = ""
                        txtHP1.Text = ""
                        txtHP2.Text = ""
                    Else
                        Dim txthp() As String = gfTelNoTransReturn(.Item("USR_HP").ToString.Trim.Replace("-", "")).Split("-")
                        cboHP.SelectedItem = txthp(0).Trim
                        txtHP1.Text = txthp(1).Trim
                        txtHP2.Text = txthp(2).Trim
                    End If

                    If .Item("ENTERING_DD").ToString = "" Then
                        DPDate1.Value = Now
                    Else
                        DPDate1.Value = CDate(.Item("ENTERING_DD").ToString)
                    End If

                    If .Item("RETIRE_DD").ToString.Trim = "" Then
                        ckbRetire.Checked = False
                        DPDate2.Value = Now
                    Else
                        ckbRetire.Checked = True
                        DPDate2.Value = CDate(.Item("RETIRE_DD").ToString)
                    End If

                End With
            End If
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub

    Public Sub gsSelect()
        Call Controls_Setting2(txtName2.Text.Trim)
    End Sub

    Public Sub gsSave()
        Dim dt As DataTable
        Dim dt2 As DataTable

        Try
            If txtId.Text.Trim = "" Then
                MsgBox("사원번호를 입력하십시오.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            ElseIf txtName.Text.Trim = "" Then
                MsgBox("성명을 입력하십시오.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            ElseIf txtPW.Text.Trim = "" Then
                MsgBox("비밀번호를 입력하십시오.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            ElseIf txtId.Text.Contains(",") = True OrElse txtId.Text.Contains("^") = True OrElse txtId.Text.Contains("!") = True _
                OrElse txtId.Text.Contains("@") = True OrElse txtId.Text.Contains("#") = True OrElse txtId.Text.Contains("$") = True _
                OrElse txtId.Text.Contains("%") = True OrElse txtId.Text.Contains("&") = True OrElse txtId.Text.Contains("*") = True _
                OrElse txtId.Text.Contains(".") = True OrElse txtId.Text.Contains("?") = True OrElse txtName.Text.Contains("'") = True _
                OrElse txtName.Text.Contains("""") = True Then
                MsgBox("! @ # $ % ^ & * , . ? ' "" 특수문자는 사용하실 수 없습니다.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            ElseIf txtName.Text.Contains(",") = True OrElse txtName.Text.Contains("^") = True OrElse txtName.Text.Contains("!") = True _
                OrElse txtName.Text.Contains("@") = True OrElse txtName.Text.Contains("#") = True OrElse txtName.Text.Contains("$") = True _
                OrElse txtName.Text.Contains("%") = True OrElse txtName.Text.Contains("&") = True OrElse txtName.Text.Contains("*") = True _
                OrElse txtId.Text.Contains(".") = True OrElse txtId.Text.Contains("?") = True OrElse txtName.Text.Contains("'") = True _
                OrElse txtName.Text.Contains("""") = True Then
                MsgBox("! @ # $ % ^ & * , . ? ' "" 특수문자는 사용하실 수 없습니다.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            End If

            ''처리
            temp = "SELECT count(*) From t_user a " & _
                  "Where a.COM_CD= @comCd and a.USER_ID=@userId "

            Dim paramCount As Hashtable = New Hashtable

            paramCount.Add("@comCd", gsCOM_CD)
            paramCount.Add("@userId", txtId.Text.Trim)

            dt = MiniCTI.DoQuery(temp, paramCount)

            Dim hpNo As String = cboHP.Text.Trim & txtHP1.Text & txtHP2.Text
            Dim telNo As String = txtWorkTelNo1.Text.Trim & txtWorkTelNo2.Text.Trim & txtWorkTelNo3.Text.Trim

            '모바일사용자인 경우 동일 핸드폰번호가 중복이면 에러
            temp = "SELECT count(a.USER_ID) From t_user a " & _
                  "Where a.COM_CD= @comCd and a.USR_HP=@userHP and a.USER_ID<> @userId "

            Dim paramCountByHP As Hashtable = New Hashtable

            paramCountByHP.Add("@comCd", gsCOM_CD)
            paramCountByHP.Add("@userHP", hpNo)
            paramCountByHP.Add("@userId", txtId.Text.Trim)

            dt2 = MiniCTI.DoQuery(temp, paramCountByHP)

            Dim userCount As Integer = Integer.Parse(dt.Rows(0).Item(0).ToString.Trim)
            Dim hpCount As Integer = Integer.Parse(dt2.Rows(0).Item(0).ToString.Trim)
            Dim isMobileUser As Boolean = ckbMobileUser.Checked
            Dim useExcel As Boolean = ckbExcelUseYN.Checked

            Dim paramTrnx As Hashtable = New Hashtable

            If (userCount = 0) Then ' Insert
                If (Not isMobileUser Or hpCount = 0) Then
                    'temp = "Insert into t_user(COM_CD,USER_ID,USER_NM,USR_HP,ADDR1,WOO_NO,H_TELNO,GRADE,EXTENSION_NO,WORK_TYPE,ENTERING_DD,RETIRE_DD,USER_EMAIL,USER_PWD,WORK_AREA,TEAM_CD,TEAM_NM, MOBILE_USE_YN, EXCEL_USE_YN) " & _
                    '       " values('" & gsCOM_CD & "','" & txtId.Text.Trim & "','" & txtName.Text.Trim & "','" & hpNo & "','" & txtAddress.Text.Trim & "','" & txtWP1.Text.Trim & txtWP2.Text.Trim & _
                    '       "','" & telNo & "','" & cboPosition.SelectedValue.ToString.Trim & "','" & txtExt.Text.Trim & "','','" & _
                    '       DPDate1.Text.Replace("-", "").Replace("/", "").Trim & "','" & If(ckbRetire.Checked = False, "", DPDate2.Text.Replace("-", "").Replace("/", "").Trim) & "','" & txtEmail.Text.Trim & _
                    '       "','" & txtPW.Text.Trim & "','" & cboGrade.SelectedValue.ToString.Trim & "','" & cboTeam.SelectedValue.ToString.Trim & _
                    '       "','" & If(cboTeam.Text.Trim = "-", "", cboTeam.Text.Trim) & "','" & If(isMobileUser, "Y", "N") & "','" & If(useExcel, "Y", "N") & "') "
                    temp = "Insert into t_user(COM_CD,USER_ID,USER_NM,USR_HP,ADDR1" & _
                            "     ,WOO_NO,H_TELNO,GRADE,EXTENSION_NO,WORK_TYPE           " & _
                            "     ,ENTERING_DD,RETIRE_DD,USER_EMAIL                      " & _
                            "     ,USER_PWD,WORK_AREA,TEAM_CD,TEAM_NM                    " & _
                            "     ,MOBILE_USE_YN, EXCEL_USE_YN)                          " & _
                            " values(@gsComCd,@userId, @userNm, @userHP, @addr1    " & _
                            "     ,@wooNo, @hTelNo, @grade, @extensionNo,@workType      " & _
                            "     ,@enteringDD, @retireDD, @userEmail                   " & _
                            "     ,@userPwd, @workArea,@teamCd,@teamNm                  " & _
                            "     ,@mobileUseYn, @excelUseYn)                           "

                    paramTrnx.Add("@gsComCd", gsCOM_CD)
                    paramTrnx.Add("@userId", txtId.Text.Trim)
                    paramTrnx.Add("@userNm", txtName.Text.Trim)
                    paramTrnx.Add("@userHP", hpNo)
                    paramTrnx.Add("@addr1", txtAddress.Text.Trim)
                    paramTrnx.Add("@wooNo", txtWP1.Text.Trim & txtWP2.Text.Trim)
                    paramTrnx.Add("@hTelNo", telNo)
                    paramTrnx.Add("@grade", cboPosition.SelectedValue.ToString.Trim)
                    paramTrnx.Add("@extensionNo", txtExt.Text.Trim)
                    paramTrnx.Add("@workType", "")
                    paramTrnx.Add("@enteringDD", DPDate1.Text.Replace("-", "").Replace("/", "").Trim)
                    paramTrnx.Add("@retireDD", If(ckbRetire.Checked = False, "", DPDate2.Text.Replace("-", "").Replace("/", "").Trim))
                    paramTrnx.Add("@userEmail", txtEmail.Text.Trim)
                    paramTrnx.Add("@userPwd", txtPW.Text.Trim)
                    paramTrnx.Add("@workArea", cboGrade.SelectedValue.ToString.Trim)
                    paramTrnx.Add("@teamCd", cboTeam.SelectedValue.ToString.Trim)
                    paramTrnx.Add("@teamNm", If(cboTeam.Text.Trim = "-", "", cboTeam.Text.Trim))
                    paramTrnx.Add("@mobileUseYn", If(isMobileUser, "Y", "N"))
                    paramTrnx.Add("@excelUseYn", If(useExcel, "Y", "N"))

                Else
                    MsgBox("이미 등록된 핸드폰 번호입니다." & vbCrLf & "모바일앱사용자는 다른 사용자와 핸드폰번호를 중복등록할 수 없습니다.", MsgBoxStyle.Critical, "정보")
                    Return
                End If
            ElseIf (userCount = 1) Then
                If (Not isMobileUser Or hpCount = 0) Then

                    'temp = "Update t_user set USER_ID='" & txtId.Text.Trim & "',USER_NM='" & txtName.Text.Trim & "',USR_HP='" & hpNo & "',ADDR1='" & txtAddress.Text.Trim & "',WOO_NO='" & txtWP1.Text.Trim & txtWP2.Text.Trim & _
                    '       "',H_TELNO='" & telNo & "',GRADE='" & cboPosition.SelectedValue.ToString.Trim & "',EXTENSION_NO='" & txtExt.Text.Trim & _
                    '       "',ENTERING_DD='" & DPDate1.Text.Replace("-", "").Replace("/", "").Trim & "',RETIRE_DD='" & If(ckbRetire.Checked = False, "", DPDate2.Text.Replace("-", "").Replace("/", "").Trim) & _
                    '       "',USER_EMAIL='" & txtEmail.Text.Trim & "',USER_PWD='" & txtPW.Text.Trim & _
                    '       "',WORK_AREA='" & cboGrade.SelectedValue.ToString.Trim & "',TEAM_CD='" & cboTeam.SelectedValue.ToString.Trim & _
                    '       "',TEAM_NM='" & If(cboTeam.Text.Trim = "-", "", cboTeam.Text.Trim) & _
                    '       "',MOBILE_USE_YN='" & If(isMobileUser, "Y", "N") & _
                    '       "',EXCEL_USE_YN='" & If(useExcel, "Y", "N") & _
                    '       "' Where COM_CD='" & gsCOM_CD & "' and USER_ID='" & txtId.Text.Trim & "' "

                    temp = "Update t_user set USER_ID=@userId  ,USER_NM=@userNm ,USR_HP=@usrHP ,ADDR1=@addr1 ,WOO_NO=@wooNo " & _
                           " ,H_TELNO=@hTelNo ,GRADE=@grade ,EXTENSION_NO=@extensionNo " & _
                           " ,ENTERING_DD=@enteringDD ,RETIRE_DD=@retireDD" & _
                           " ,USER_EMAIL=@userEmail ,USER_PWD=@userPwd " & _
                           " ,WORK_AREA=@workArea ,TEAM_CD=@teamCd " & _
                           " ,TEAM_NM=@teamNm " & _
                           " ,MOBILE_USE_YN=@mobileUseYn " & _
                           " ,EXCEL_USE_YN=@excelUseYn " & _
                           "  Where COM_CD=@gsComCd and USER_ID=@userId "

                    paramTrnx.Add("@userId", txtId.Text.Trim)
                    paramTrnx.Add("@userNm", txtName.Text.Trim)
                    paramTrnx.Add("@usrHP", hpNo)
                    paramTrnx.Add("@addr1", txtAddress.Text.Trim)
                    paramTrnx.Add("@wooNo", txtWP1.Text.Trim & txtWP2.Text.Trim)
                    paramTrnx.Add("@hTelNo", telNo)
                    paramTrnx.Add("@grade", cboPosition.SelectedValue.ToString.Trim)
                    paramTrnx.Add("@extensionNo", txtExt.Text.Trim)
                    paramTrnx.Add("@enteringDD", DPDate1.Text.Replace("-", "").Replace("/", "").Trim)
                    paramTrnx.Add("@retireDD", If(ckbRetire.Checked = False, "", DPDate2.Text.Replace("-", "").Replace("/", "").Trim))
                    paramTrnx.Add("@userEmail", txtEmail.Text.Trim)
                    paramTrnx.Add("@userPwd", txtPW.Text.Trim)
                    paramTrnx.Add("@workArea", cboGrade.SelectedValue.ToString.Trim)
                    paramTrnx.Add("@teamCd", cboTeam.SelectedValue.ToString.Trim)
                    paramTrnx.Add("@teamNm", If(cboTeam.Text.Trim = "-", "", cboTeam.Text.Trim))
                    paramTrnx.Add("@mobileUseYn", If(isMobileUser, "Y", "N"))
                    paramTrnx.Add("@excelUseYn", If(useExcel, "Y", "N"))
                    paramTrnx.Add("@gsComCd", gsCOM_CD)

                Else
                    MsgBox("이미 등록된 핸드폰 번호입니다." & vbCrLf & "모바일앱사용자는 다른 사용자와 핸드폰번호를 중복등록할 수 없습니다.", MsgBoxStyle.Critical, "정보")
                    Return
                End If
            End If

            Dim iReturn As Integer = DoExecuteNonQuery(temp, paramTrnx)

            If iReturn > 0 Then
                If temp.StartsWith("Insert") Then
                    Audit_Log(AUDIT_TYPE.USER_ADD, "ID:" & txtId.Text.Trim & ", Name:" & txtName.Text.Trim)
                ElseIf temp.StartsWith("Update") Then
                    Audit_Log(AUDIT_TYPE.USER_MOD, "ID:" & txtId.Text.Trim & ", Name:" & txtName.Text.Trim)
                End If

                MsgBox("처리되었습니다.", MsgBoxStyle.OkOnly, "정보")
            Else
                MsgBox("등록에 실패했습니다.", MsgBoxStyle.Critical, "정보")
            End If
            Controls_Setting2("")

        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
            MsgBox("등록에 실패했습니다.", MsgBoxStyle.Critical, "정보")
        Finally
            dt = Nothing
        End Try

    End Sub

    Public Sub gsDelete()
        Dim dt As DataTable
        Dim parameters As Hashtable = New Hashtable

        Try
            If txtId.Text.Trim = "" Then
                MsgBox("삭제할 사용자를 선택하십시오.", MsgBoxStyle.OkOnly, "정보")
                Exit Try
            End If

            MsgBox(txtId.Text.Trim & "." & txtName.Text.Trim & " 사용자를 삭제하시겠습니까?", MsgBoxStyle.YesNo, "확인")

            temp = "Delete from t_user Where COM_CD=@gsComCd and USER_ID=@gsUserId "

            parameters.Add("@gsUserId", txtId.Text.Trim)
            parameters.Add("@gsComCd", gsCOM_CD)

            Dim iReturn As Integer = DoExecuteNonQuery(temp, parameters)

            If iReturn > 0 Then
                Call Audit_Log(AUDIT_TYPE.USER_DEL, "ID:" & txtId.Text.Trim & ", Name:" & txtName.Text.Trim)

                MsgBox("처리되었습니다.", MsgBoxStyle.OkOnly, "정보")
            Else
                MsgBox("등록에 실패했습니다.", MsgBoxStyle.Critical, "정보")
            End If

            Controls_Setting2("")
            gsInit()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub

    Public Sub gsFormExit()
        Me.Close()
    End Sub

    Public Sub gsInit()
        Try
            txtId.Text = ""
            txtName.Text = ""
            txtPW.Text = ""
            cboHP.SelectedIndex = 0
            txtHP1.Text = ""
            txtHP2.Text = ""
            txtWorkTelNo1.Text = ""
            txtWorkTelNo2.Text = ""
            txtWorkTelNo3.Text = ""
            txtExt.Text = ""
            txtWP1.Text = ""
            txtWP2.Text = ""
            txtAddress.Text = ""
            txtEmail.Text = ""
            cboGrade.SelectedValue = ""
            cboPosition.SelectedValue = ""
            cboTeam.SelectedValue = ""
            DPDate1.Value = Now
            DPDate2.Value = Now
            ckbRetire.Checked = False
            ckbMobileUser.Checked = False
            ckbExcelUseYN.Checked = False
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Call gsSelect()
    End Sub

    Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call gsSave()
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Call gsDelete()
    End Sub

    Private Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInit.Click
        Call gsInit()
    End Sub

    Private Sub btnZipCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZipCode.Click
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
            Dim tmp As String() = Str.Split("^")
            If tmp.Length < 3 Then Exit Try
            txtWP1.Text = tmp(0).Substring(0, 3)
            txtWP2.Text = tmp(0).Substring(4, 3)
            txtAddress.Text = tmp(1).ToString.Trim & IIf(tmp(2).ToString.Trim = "", "", " " & tmp(2).ToString.Trim)
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

End Class