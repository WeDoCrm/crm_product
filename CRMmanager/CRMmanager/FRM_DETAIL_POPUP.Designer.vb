<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_DETAIL_POPUP
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_DETAIL_POPUP))
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtCustomerName = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.txtTongDD = New System.Windows.Forms.TextBox
        Me.txtTongTime = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTongContents = New System.Windows.Forms.TextBox
        Me.txtTongTel = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label46
        '
        Me.Label46.Image = CType(resources.GetObject("Label46.Image"), System.Drawing.Image)
        Me.Label46.Location = New System.Drawing.Point(20, 79)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(13, 12)
        Me.Label46.TabIndex = 322
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(89, 75)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(96, 21)
        Me.txtCustomerName.TabIndex = 325
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(33, 79)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(41, 12)
        Me.Label47.TabIndex = 321
        Me.Label47.Text = "고객명"
        '
        'txtTongDD
        '
        Me.txtTongDD.Location = New System.Drawing.Point(89, 19)
        Me.txtTongDD.Name = "txtTongDD"
        Me.txtTongDD.ReadOnly = True
        Me.txtTongDD.Size = New System.Drawing.Size(71, 21)
        Me.txtTongDD.TabIndex = 323
        Me.txtTongDD.Text = "2013-08-19"
        Me.txtTongDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTongTime
        '
        Me.txtTongTime.Location = New System.Drawing.Point(163, 19)
        Me.txtTongTime.Name = "txtTongTime"
        Me.txtTongTime.ReadOnly = True
        Me.txtTongTime.Size = New System.Drawing.Size(57, 21)
        Me.txtTongTime.TabIndex = 324
        Me.txtTongTime.Text = "23:59:58"
        Me.txtTongTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.Image = CType(resources.GetObject("Label41.Image"), System.Drawing.Image)
        Me.Label41.Location = New System.Drawing.Point(20, 23)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(13, 12)
        Me.Label41.TabIndex = 320
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(33, 23)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(53, 12)
        Me.Label40.TabIndex = 319
        Me.Label40.Text = "통화일자"
        '
        'Label39
        '
        Me.Label39.Image = CType(resources.GetObject("Label39.Image"), System.Drawing.Image)
        Me.Label39.Location = New System.Drawing.Point(20, 135)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(13, 12)
        Me.Label39.TabIndex = 318
        '
        'Label36
        '
        Me.Label36.Image = CType(resources.GetObject("Label36.Image"), System.Drawing.Image)
        Me.Label36.Location = New System.Drawing.Point(20, 51)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(13, 12)
        Me.Label36.TabIndex = 317
        '
        'Label34
        '
        Me.Label34.Image = CType(resources.GetObject("Label34.Image"), System.Drawing.Image)
        Me.Label34.Location = New System.Drawing.Point(20, 106)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(13, 12)
        Me.Label34.TabIndex = 316
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(33, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 315
        Me.Label15.Text = "상담결과"
        '
        'txtTongContents
        '
        Me.txtTongContents.Location = New System.Drawing.Point(89, 132)
        Me.txtTongContents.Multiline = True
        Me.txtTongContents.Name = "txtTongContents"
        Me.txtTongContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTongContents.Size = New System.Drawing.Size(345, 136)
        Me.txtTongContents.TabIndex = 328
        '
        'txtTongTel
        '
        Me.txtTongTel.Location = New System.Drawing.Point(89, 47)
        Me.txtTongTel.Name = "txtTongTel"
        Me.txtTongTel.ReadOnly = True
        Me.txtTongTel.Size = New System.Drawing.Size(132, 21)
        Me.txtTongTel.TabIndex = 326
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(33, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 314
        Me.Label12.Text = "전화번호"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(33, 135)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 313
        Me.Label13.Text = "상담정보"
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(364, 19)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(70, 25)
        Me.btnConfirm.TabIndex = 330
        Me.btnConfirm.Text = "완료"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(364, 50)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 25)
        Me.btnCancel.TabIndex = 329
        Me.btnCancel.Text = "취소"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(90, 102)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.Size = New System.Drawing.Size(96, 21)
        Me.txtResult.TabIndex = 331
        '
        'FRM_DETAIL_POPUP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 274)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.txtTongDD)
        Me.Controls.Add(Me.txtTongTime)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtTongContents)
        Me.Controls.Add(Me.txtTongTel)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Name = "FRM_DETAIL_POPUP"
        Me.ShowIcon = False
        Me.Text = "FRM_DETAIL_POPUP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtTongDD As System.Windows.Forms.TextBox
    Friend WithEvents txtTongTime As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTongContents As System.Windows.Forms.TextBox
    Friend WithEvents txtTongTel As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
End Class
