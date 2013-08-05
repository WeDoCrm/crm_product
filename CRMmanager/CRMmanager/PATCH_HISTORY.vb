Imports System.Xml

Public NotInheritable Class PATCH_HISTORY

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        SaveXmlFile()

        Me.Close()
    End Sub

    Private Sub SaveXmlFile()

        Dim doc As XmlDocument = New XmlDocument()

        doc.Load(file_path & config_file)
        Dim environmentNode As XmlNode = doc.SelectSingleNode("/environment")

        Dim patchVersionEl As XmlElement

        patchVersionEl = doc.SelectSingleNode("/environment/patchVersion")
        If patchVersionEl Is Nothing Then
            patchVersionEl = doc.CreateElement("patchVersion")
        End If
        patchVersionEl.InnerText = gsAppVersion
        environmentNode.AppendChild(patchVersionEl)
        WriteLog("file_path[" & file_path & "] config_file[" & config_file & "]patchVersion[" & patchVersionEl.InnerText & "]")

        doc.Save(file_path & config_file)

        gbIsPatchHistoryOpened = True
    End Sub
End Class
