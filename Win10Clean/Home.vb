﻿Imports Microsoft.Win32

Public Class Home

    'Win10Clean - Cleanup your Windows 10 enviroment
    'Copyright (C) 2016 Hawaii_Beach

    'This program Is free software: you can redistribute it And/Or modify
    'it under the terms Of the GNU General Public License As published by
    'the Free Software Foundation, either version 3 Of the License, Or
    '(at your option) any later version.

    'This program Is distributed In the hope that it will be useful,
    'but WITHOUT ANY WARRANTY; without even the implied warranty Of
    'MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
    'GNU General Public License For more details.

    'You should have received a copy Of the GNU General Public License
    'along with this program.  If Not, see <http://www.gnu.org/licenses/>.

    Dim LibGUID() As String = {"{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", "{7d83ee9b-2244-4e70-b1f5-5393042af1e4}", "{f42ee2d3-909f-4907-8871-4c22fc0bf756}", "{0ddd015d-b06c-45d5-8c4c-f59713854639}", "{a0c69a99-21c8-4671-8703-7934162fcf1d}", "{35286a68-3c57-41a1-bbb1-0eae73d76c95}"}
    Dim LibVal As String = "Hide"

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Application.Exit()
    End Sub

    Private Sub MeteroBtn_Click(sender As Object, e As EventArgs) Handles MeteroBtn.Click
        Metero.Show()
        Close()
    End Sub

    Private Sub DelLibBtn_Click(sender As Object, e As EventArgs) Handles DelLibBtn.Click
        Enabled = False

        Static LibReg As RegistryKey
        Static LibKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\"
        For Each key As String In LibGUID
            Dim FinalKey = LibKey + key + "\PropertyBag"
            Console.WriteLine("key='" + FinalKey + "',val='" + LibVal + "'")
            LibReg = Registry.LocalMachine.OpenSubKey(FinalKey, True)



            LibReg.SetValue("ThisPCPolicy", LibVal)

            LibReg.Close()
        Next

        Enabled = True

    End Sub
End Class
