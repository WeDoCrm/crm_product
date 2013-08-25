Imports System.Xml

Public Class FRM_CONFIG

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        SaveXmlFile()

        Me.Close()

    End Sub

    Private Sub FRM_CONFIG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ckbUseTongUser.Checked = gbUseTongUser
        ckbUseUserDef.Checked = gbUseUserDef
        ckbNoCloseOnSave.Checked = gbNoCloseOnSave
        ckbUseAlarm.Checked = gbAlarmInfo.Enabled
        ''알림시작시간: 10분전, 30분전, 1시간전, 2시간전, 3시간전, 6시간전, 12시간전
        ''알림주기: 5분, 10분, 15분, 30분, 1시간, 2시간, 3시간, 6시간
        With cbxAlarmPeriod
            .Items.Clear()
            .Items.Add(New CommObj.CListItem("5분", 5))
            .Items.Add(New CommObj.CListItem("10분", 10))
            .Items.Add(New CommObj.CListItem("15분", 15))
            .Items.Add(New CommObj.CListItem("30분", 30))
            .Items.Add(New CommObj.CListItem("1시간", 60))
            .Items.Add(New CommObj.CListItem("2시간", 120))
            .Items.Add(New CommObj.CListItem("3시간", 180))
            .Items.Add(New CommObj.CListItem("6시간", 360))
        End With

        With cbxAlarmStart
            .Items.Clear()
            .Items.Add(New CommObj.CListItem("10분전", 10))
            .Items.Add(New CommObj.CListItem("30분전", 30))
            .Items.Add(New CommObj.CListItem("1시간전", 60))
            .Items.Add(New CommObj.CListItem("2시간전", 120))
            .Items.Add(New CommObj.CListItem("3시간전", 180))
            .Items.Add(New CommObj.CListItem("6시간전", 360))
            .Items.Add(New CommObj.CListItem("12시간전", 720))
        End With

        cbxAlarmPeriod.SelectedIndex = cbxAlarmPeriod.Items.IndexOf(gbAlarmInfo.AlarmPeriod)
        cbxAlarmStart.SelectedIndex = cbxAlarmStart.Items.IndexOf(gbAlarmInfo.AlarmStart)

        gbxUseAlarm.Enabled = gbAlarmInfo.Enabled

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ckbUseAlarm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbUseAlarm.CheckedChanged
        gbxUseAlarm.Enabled = ckbUseAlarm.Checked
    End Sub

    Private Sub SaveXmlFile()
        ''1.write  xml
        Dim doc As XmlDocument = New XmlDocument()
        'Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode

        doc.Load(file_path & config_file)
        Dim environmentNode As XmlNode = doc.SelectSingleNode("/environment")

        Dim customerEl As XmlElement

        customerEl = doc.SelectSingleNode("/environment/customer")
        If customerEl Is Nothing Then
            customerEl = doc.CreateElement("customer")
            environmentNode.AppendChild(customerEl)
        End If

        'useTongUser
        Dim useTongUser As XmlElement
        useTongUser = customerEl.SelectSingleNode("useTongUser")
        If useTongUser Is Nothing Then
            useTongUser = doc.CreateElement("useTongUser")
        End If
        useTongUser.InnerText = If(ckbUseTongUser.Checked, "Y", "N")
        customerEl.AppendChild(useTongUser)

        'useUserDef
        Dim useUserDef As XmlElement
        useUserDef = customerEl.SelectSingleNode("useUserDef")
        If useUserDef Is Nothing Then
            useUserDef = doc.CreateElement("useUserDef")
        End If
        useUserDef.InnerText = If(ckbUseUserDef.Checked, "Y", "N")
        customerEl.AppendChild(useUserDef)

        'noCloseOnSave
        Dim noCloseOnSave As XmlElement
        noCloseOnSave = customerEl.SelectSingleNode("noCloseOnSave")
        If noCloseOnSave Is Nothing Then
            noCloseOnSave = doc.CreateElement("noCloseOnSave")
        End If
        noCloseOnSave.InnerText = If(ckbNoCloseOnSave.Checked, "Y", "N")
        customerEl.AppendChild(noCloseOnSave)

        'useAlarm
        Dim useAlarm As XmlElement
        useAlarm = customerEl.SelectSingleNode("useAlarm")
        If useAlarm Is Nothing Then
            useAlarm = doc.CreateElement("useAlarm")
        End If
        useAlarm.SetAttribute("enabled", If(ckbUseAlarm.Checked, "Y", "N"))
        gbAlarmInfo.Enabled = ckbUseAlarm.Checked
        'alarmTime
        Dim selectedAlarmStart As Integer = CType(cbxAlarmStart.SelectedItem(), CommObj.CListItem).Value

        Dim alarmStart As XmlElement
        alarmStart = useAlarm.SelectSingleNode("alarmStart")
        If alarmStart Is Nothing Then
            alarmStart = doc.CreateElement("alarmStart")
        End If
        alarmStart.InnerText = selectedAlarmStart

        useAlarm.AppendChild(alarmStart)

        'alarmPeriod
        Dim selectedAlarmPeriod As Integer = CType(cbxAlarmPeriod.SelectedItem(), CommObj.CListItem).Value
        Dim alarmPeriod As XmlElement
        alarmPeriod = useAlarm.SelectSingleNode("alarmPeriod")
        If alarmPeriod Is Nothing Then
            alarmPeriod = doc.CreateElement("alarmPeriod")
        End If
        alarmPeriod.InnerText = selectedAlarmPeriod

        useAlarm.AppendChild(alarmPeriod)
        customerEl.AppendChild(useAlarm)

        doc.Save(file_path & config_file)

        '2. refresh global 
        gbUseTongUser = ckbUseTongUser.Checked
        gbUseUserDef = ckbUseUserDef.Checked
        gbNoCloseOnSave = ckbNoCloseOnSave.Checked

        gbAlarmInfo.AlarmStart = selectedAlarmStart
        gbAlarmInfo.AlarmPeriod = selectedAlarmPeriod
    End Sub
End Class