'
'Copyright (C) 2018 Raisy Clutch
'raisycltch@gmail.com

'Created by Raisy Clutch

'   This program is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.

'    This program is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.

'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <http://www.gnu.org/licenses/>.
'
'
Imports FastColoredTextBoxNS
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports DarkUI.Forms
Imports System.IO

Public Class Form1
    Private KeywordsStyle As Style = New TextStyle(Brushes.CornflowerBlue, Nothing, FontStyle.Regular)
    Private FunctionNameStyle As Style = New TextStyle(Brushes.MediumSeaGreen, Nothing, FontStyle.Bold)
    Private mportsStyle As Style = New TextStyle(Brushes.GreenYellow, Nothing, FontStyle.Regular)
    Private popupMenu As AutocompleteMenu
    Dim Webfiles = "HTML (*.htm;*.html)|*.htm;*.html;*.xhtml|CSS (*.css;*.less;*.sass)|*.css;*.less;*.sass|Javascript (*.js)|*.js|Text Document(*.txt)|*.txt|HTML Apps(*.hta)|*.hta|All Files(*.*)|*.*"
    Dim pyfiles = "python (*.py;*.pyc)|*.py"


    ' snippet from pavel's Fast coloured Textbox examples
    Private Sub BuildAutocompleteMenu()
        Dim items As New List(Of AutocompleteItem)()

        'For Each item As String In snippets
        'items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
        ' Next
        For Each item As String In bpy.declarationSnippets
            items.Add(New DeclarationSnippet(item) With {.ImageIndex = 0})
        Next
        '     For Each item As String In methods
        'items.Add(New MethodAutocompleteItem(item) With {.ImageIndex = 2})
        ' Next

        For Each item As String In bpy.sources02
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources01
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources00
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources03
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources6
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources7
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources8
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources9
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources5
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources3
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources2
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.sources4
            items.Add(New MethodAutocompleteItem2(item))
        Next

        For Each item As String In bpy.keywords
            items.Add(New AutocompleteItem(item))
        Next

        items.Add(New InsertSpaceSnippet())
        items.Add(New InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
        items.Add(New InsertEnterSnippet())

        'set as autocomplete source
        popupMenu.Items.SetAutocompleteItems(items)
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        DocumentMap1.Target = Me.fctb
        ' Add any initialization after the InitializeComponent() call.
        popupMenu = New AutocompleteMenu(fctb)
        popupMenu.SearchPattern = "[\w\.:=!<>]"
        '
        popupMenu.AutoSize = True
        popupMenu.MinFragmentLength = 1
        popupMenu.HoveredColor = Color.DeepSkyBlue
        popupMenu.BackColor = Color.FromArgb(40, 40, 40)
        popupMenu.SelectedColor = Color.FromArgb(60, 60, 60)
        popupMenu.ForeColor = Color.Silver
        popupMenu.Width = 400

        BuildAutocompleteMenu()
    End Sub

    Public Class MethodAutocompleteItem2
        Inherits MethodAutocompleteItem
        Private firstPart As String
        Private lastPart As String

        Public Sub New(text As String)
            MyBase.New(text)
            Dim i = text.LastIndexOf("."c)
            If i < 0 Then
                firstPart = text
            Else
                firstPart = text.Substring(0, i)
                lastPart = text.Substring(i + 1)
            End If
        End Sub
        Public Overrides Function Compare(fragmentText As String) As CompareResult
            Dim i As Integer = fragmentText.LastIndexOf("."c)

            If i < 0 Then
                If firstPart.StartsWith(fragmentText) AndAlso String.IsNullOrEmpty(lastPart) Then
                    Return CompareResult.VisibleAndSelected
                End If

            Else
                Dim fragmentFirstPart = fragmentText.Substring(0, i)
                Dim fragmentLastPart = fragmentText.Substring(i + 1)


                If firstPart <> fragmentFirstPart Then
                    Return CompareResult.Hidden
                End If

                If Not lastPart Is Nothing AndAlso lastPart.StartsWith(fragmentLastPart) Then
                    Return CompareResult.VisibleAndSelected
                End If

                If Not lastPart Is Nothing AndAlso lastPart.ToLower().Contains(fragmentLastPart.ToLower()) Then
                    Return CompareResult.Visible
                End If

            End If

            Return CompareResult.Hidden
        End Function

        Public Overrides Function GetTextForReplace() As String
            If lastPart Is Nothing Then
                Return firstPart
            End If

            Return firstPart + "." + lastPart
        End Function

        Public Overrides Function ToString() As String
            If lastPart Is Nothing Then
                Return firstPart
            End If

            Return lastPart
        End Function
    End Class
    ''' <summary>
    ''' This item appears when any part of snippet text is typed
    ''' </summary>
    Private Class DeclarationSnippet
        Inherits SnippetAutocompleteItem
        Public Sub New(ByVal snippet As String)
            MyBase.New(snippet)
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim pattern = Regex.Escape(fragmentText)
            If Regex.IsMatch(Text, "\b" & pattern, RegexOptions.IgnoreCase) Then
                Return CompareResult.Visible
            End If
            Return CompareResult.Hidden
        End Function
    End Class

    ''' <summary>
    ''' Divides numbers and words: "123AND456" -> "123 AND 456"
    ''' Or "i=2" -> "i = 2"
    ''' </summary>
    Private Class InsertSpaceSnippet
        Inherits AutocompleteItem
        Private pattern As String

        Public Sub New(ByVal pattern As String)
            MyBase.New("")
            Me.pattern = pattern
        End Sub


        Public Sub New()
            Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            If Regex.IsMatch(fragmentText, pattern) Then
                Text = InsertSpaces(fragmentText)
                If Text <> fragmentText Then
                    Return CompareResult.Visible
                End If
            End If
            Return CompareResult.Hidden
        End Function

        Public Function InsertSpaces(ByVal fragment As String) As String
            Dim m = Regex.Match(fragment, pattern)
            If m Is Nothing Then
                Return fragment
            End If
            If m.Groups(1).Value = "" AndAlso m.Groups(3).Value = "" Then
                Return fragment
            End If
            Return (m.Groups(1).Value & " " & m.Groups(2).Value & " " & m.Groups(3).Value).Trim()
        End Function

        Public Overrides Property ToolTipTitle() As String
            Get
                Return Text
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Inerts line break after '}'
    ''' </summary>
    Private Class InsertEnterSnippet
        Inherits AutocompleteItem
        Private enterPlace As Place = Place.Empty

        Public Sub New()
            MyBase.New("[Line break]")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim r = Parent.Fragment.Clone()
            While r.Start.iChar > 0
                If r.CharBeforeStart = ":"c Then
                    enterPlace = r.Start
                    Return CompareResult.Visible
                End If

                r.GoLeftThroughFolded()
            End While

            Return CompareResult.Hidden
        End Function

        Public Overrides Function GetTextForReplace() As String
            'extend range
            Dim r As Range = Parent.Fragment
            Dim [end] As Place = r.[End]
            r.Start = enterPlace
            r.[End] = r.[End]
            'insert line break
            Return Environment.NewLine + r.Text
        End Function

        Public Overrides Sub OnSelected(ByVal popupMenu As AutocompleteMenu, ByVal e As SelectedEventArgs)
            MyBase.OnSelected(popupMenu, e)
            If Parent.Fragment.tb.AutoIndent Then
                Parent.Fragment.tb.DoAutoIndent()
            End If
        End Sub

        Public Overrides Property ToolTipTitle() As String
            Get
                Return "Insert line break after '}'"
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class


    Private Sub fctb_TextChangedDelayed(sender As Object, e As TextChangedEventArgs) Handles fctb.TextChangedDelayed
        Dim items As New List(Of AutocompleteItem)()
        Me.fctb.Range.ClearStyle(New Style() {Me.KeywordsStyle, Me.FunctionNameStyle})
        Me.fctb.Range.SetStyle(Me.KeywordsStyle, "\b(elif|else||if|self|or|set|def|import|true|false|os)\b", RegexOptions.IgnoreCase)
        For Each found As Range In Me.fctb.GetRanges("\b(def|DEF|class)\s+(?<range>\w+)\b")
            Me.fctb.Range.SetStyle(Me.FunctionNameStyle, "\b" + found.Text + "\b")
        Next
        For Each found As Range In Me.fctb.GetRanges("\b(import|IMPORT)\b")
            Me.fctb.Range.SetStyle(Me.KeywordsStyle, "\b" + found.Text + "\b")
        Next
        For Each found As Range In Me.fctb.GetRanges("\b(mesh|data|try|except|props|types|object|utils|scene|material|operator|text=|icon=|label|self|context|utils|path|bgl|bmesh|blf|in|ops|app|objects|bpy_extras)\b")
            Me.fctb.Range.SetStyle(Me.KeywordsStyle, "\b" + found.Text + "\b")
        Next
        For Each found As Range In Me.fctb.GetRanges("\b(import|IMPORT)\s+(?<range>\w+)\b")
            Me.fctb.Range.SetStyle(Me.mportsStyle, " \ B" + found.Text + "\b")
        Next

    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileToolStripMenuItem.Click
        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim file = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
                fctb.Text = file
            End If
        Catch ex As Exception
            DarkMessageBox.ShowWarning("File Not Found Exception", "Error", DarkDialogButton.AbortRetryIgnore)
        End Try

    End Sub

    Private Sub TextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextToolStripMenuItem.Click
        fctb.InsertText(My.Resources.header)
    End Sub

    Private Sub ButtonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonToolStripMenuItem.Click
        fctb.InsertText(My.Resources.text)
    End Sub

    Private Sub InputBoxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputBoxToolStripMenuItem.Click
        fctb.InsertText(My.Resources.inputbox)
    End Sub

    Private Sub TrackbarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackbarToolStripMenuItem.Click
        fctb.InsertText(My.Resources.range)
    End Sub

    Private Sub DropDownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownToolStripMenuItem.Click
        fctb.InsertText(My.Resources.paneldrop)
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        fctb.InsertText(My.Resources.columns)
    End Sub

    Private Sub ColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColumnToolStripMenuItem.Click
        fctb.InsertText(My.Resources.button)
    End Sub

    Private Sub RowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RowToolStripMenuItem.Click
        fctb.InsertText(My.Resources.buttonrows)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Filter = pyfiles
        Try
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, fctb.Text, False)
            End If
        Catch ex As Exception
            DarkMessageBox.ShowWarning("Sorry i cant complete that operation, try another location", "Error", DarkDialogButton.AbortRetryIgnore)
        End Try

    End Sub

    Private Sub HTMLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HTMLToolStripMenuItem.Click
        SaveFileDialog1.Filter = Webfiles

        Try
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName & ".html", "<body style='background: rgb(30,30,30)'>" & fctb.Html, False)
                Process.Start(SaveFileDialog1.FileName & ".html")
            End If
        Catch ex As Exception
            DarkMessageBox.ShowWarning("Invalid File Exception, Access Denied", "Error", DarkDialogButton.AbortRetryIgnore)
        End Try

    End Sub

    Private Sub RTFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fctb.ForeColor = Color.Black
        Try
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName & ".rtf", fctb.Rtf, False)
                Process.Start(SaveFileDialog1.FileName & ".rtf")
                fctb.ForeColor = Color.DimGray
            End If
        Catch ex As Exception
            DarkMessageBox.ShowWarning("Invalid File Exception, Access Denied", "Error", DarkDialogButton.AbortRetryIgnore)
        End Try
    End Sub

    Private Sub PanelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelToolStripMenuItem.Click

    End Sub

    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        fctb.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        fctb.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem2.Click
        fctb.Paste()
    End Sub

    Private Sub SaveToClipbaordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToClipbaordToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(fctb.Text)
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        fctb.findForm.Show()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        fctb.replaceForm.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        fctb.InsertText(My.Resources.info)
    End Sub

    Private Sub RegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterToolStripMenuItem.Click
        fctb.InsertText(My.Resources.regunreg)
    End Sub

    Private Sub TabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabToolStripMenuItem.Click
        fctb.InsertText(My.Resources.tab)
    End Sub

    Private Sub ButtonOperatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOperatorToolStripMenuItem.Click
        fctb.InsertText(My.Resources.opera)
    End Sub

    Private Sub RegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterToolStripMenuItem1.Click
        fctb.InsertText(My.Resources.regunreg)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(fctb.Text)
    End Sub

    Private Sub NewScriptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewScriptToolStripMenuItem.Click
        SaveFileDialog1.Filter = pyfiles
        If DarkMessageBox.ShowWarning("Are you sure, All your Unsaved work will be lost, Do you want to save?", "Save First", DarkDialogButton.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, fctb.Text, False)
                End If
            Catch ex As Exception
                DarkMessageBox.ShowWarning("File Not Found Exception", "Error", DarkDialogButton.AbortRetryIgnore)
            End Try
        Else
            fctb.Text = "import bpy"
        End If

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub PythonConsoleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PythonConsoleToolStripMenuItem.Click
        Try
            Process.Start("python")
        Catch ex As Exception
            DarkMessageBox.ShowWarning("Python not installed maybe outdated try upgrading or install python", "Python not detected", DarkDialogButton.Ok)
            Process.Start("http://www.python.org")
        End Try
    End Sub

    Private Sub ContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.Click
        Process.Start("http://facebook.com/raisyfreeiz")
    End Sub

    Private Sub WebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebsiteToolStripMenuItem.Click
        Process.Start("http://raisyclutch.wordpress.com")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        DarkMessageBox.ShowInformation("Bacutor is a Blender Addon Creator Programmed By Raisy Clutch For Developing Blender Addons Easier and Faster" & vbCrLf & "Version: 1.0" & vbCrLf & "© Raisy Clutch" & vbCrLf & "" & vbCrLf & "All rights Reserved", "About Bacutor", DarkDialogButton.Ok)
    End Sub

    Private Sub RunToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem1.Click
        Dim temp = My.Computer.FileSystem.SpecialDirectories.Temp
        My.Computer.FileSystem.WriteAllText(temp & "\test.py", fctb.Text, False)
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Blender Foundation\blender.exe") = True Or File.Exists("C:\Program Files\Blender Foundation\Blender\blender.exe") = True Then
            Process.Start("C:\Program Files\Blender Foundation\Blender\blender.exe", "-y --python " & temp & "\test.py")
            Clipboard.SetText(fctb.Text)
            DarkMessageBox.ShowInformation("Text Copied To Clipboard", "Saved To Clipbaord", DarkDialogButton.Ok)
        Else
            DarkMessageBox.ShowError("Blender Not Found, please install a 64 bit version on the C Drive and continue", "Error", DarkDialogButton.Ok)
        End If
    End Sub

    Private Sub MakeRunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeRunToolStripMenuItem.Click
        fctb.InsertText(My.Resources.mk)
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Process.Start("http://facebook.com/raisyfreeiz")
    End Sub

    Private Sub GPLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GPLToolStripMenuItem.Click
        fctb.InsertText(My.Resources.gpl)
    End Sub

    Private Sub AddonWizardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddonWizardToolStripMenuItem.Click
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Blender Foundation\blender.exe") = True Or File.Exists("C:\Program Files\Blender Foundation\Blender\blender.exe") = True Then
            Process.Start("C:\Program Files\Blender Foundation\Blender\blender.exe", "--background --python-console")

        Else
            DarkMessageBox.ShowError("Blender Not Found, please install a 64 bit version and continue", "Error", DarkDialogButton.Ok)
        End If
    End Sub

    Private Sub Base64ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Base64ToolStripMenuItem.Click
        Dim aset = fctb.SelectedText
        Dim fino = mlib.ConvertBase64(aset)
        fctb.InsertText(fino)
    End Sub

    Private Sub Base64ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Base64ToolStripMenuItem1.Click
        Dim aset = fctb.SelectedText
        Dim fino = mlib.DecodeBase64(aset)
        fctb.InsertText(fino)
    End Sub

    Private Sub ArrayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrayToolStripMenuItem.Click
        Dim aset = fctb.SelectedText
        Dim fino = mlib.StringToBinary(aset)
        fctb.InsertText(fino)
    End Sub
    Private proc As New ProcessStartInfo
    Private pro As New Process
    Private red As StreamReader
    Private green As StreamReader
    Private str As String
    Private stre As String
    Private Sub RunPythonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunPythonToolStripMenuItem.Click
        Try
            Dim temp = My.Computer.FileSystem.SpecialDirectories.Temp
            My.Computer.FileSystem.WriteAllText(temp & "\tes.py", fctb.Text, False)
            proc.Arguments = Chr(34) & temp & "\tes.py" & Chr(34)
            proc.FileName = "python"
            proc.UseShellExecute = False
            pro.StartInfo = proc
            pro.Start()


        Catch ex As Exception
            DarkMessageBox.ShowWarning("Python not installed maybe outdated try upgrading or install python", "Python not detected", DarkDialogButton.Ok)
            Process.Start("http://www.python.org")
        End Try
    End Sub

    Private Sub ToolsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem1.Click
        fctb.InsertText(My.Resources.pt)
    End Sub

    Private Sub RenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenderToolStripMenuItem.Click
        fctb.InsertText(My.Resources.pr)
    End Sub

    Private Sub SceneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SceneToolStripMenuItem.Click
        fctb.InsertText(My.Resources.ps)
    End Sub

    Private Sub ObjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObjectToolStripMenuItem.Click
        fctb.InsertText(My.Resources.po)
    End Sub

    Private Sub MaterialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialToolStripMenuItem.Click
        fctb.InsertText(My.Resources.pm)
    End Sub

    Private Sub WorldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorldToolStripMenuItem.Click
        fctb.InsertText(My.Resources.pw)
    End Sub

    Private Sub RunPythonGUIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunPythonGUIToolStripMenuItem.Click
        Try
            Dim temp = My.Computer.FileSystem.SpecialDirectories.Temp
            My.Computer.FileSystem.WriteAllText(temp & "\tes.py", fctb.Text, False)
            proc.Arguments = Chr(34) & temp & "\tes.py" & Chr(34)
            proc.FileName = "python"
            proc.UseShellExecute = False
            proc.RedirectStandardOutput = True
            proc.RedirectStandardError = True
            pro.StartInfo = proc
            pro.Start()
            red = pro.StandardError
            green = pro.StandardOutput
            str = red.ReadToEnd
            stre = green.ReadToEnd
            If str.Length > 2 Then
                DarkMessageBox.ShowError(str.ToString, "Python Error", DarkDialogButton.Ok)
            ElseIf stre.Length > 2 Then
                DarkMessageBox.ShowInformation(stre.ToString, "Python Output", DarkDialogButton.Ok)

            End If

        Catch ex As Exception
            DarkMessageBox.ShowWarning("Python not installed maybe outdated try upgrading to python 3.7", "Python not detected", DarkDialogButton.Ok)
            Process.Start("http://www.python.org")
        End Try
    End Sub
End Class
