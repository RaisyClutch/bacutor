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
Imports System.Text
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Bitmap
Imports System.Xml.Serialization
Imports System.Windows
Imports System.Collections.ObjectModel

Module mlib
    Public autosavemode As Boolean = False
    Dim TS, sIn, sOut, Arg, IfEncode, OFil, LSize, LRet
    Public FSO = CreateObject("Scripting.FileSystemObject")
    Public Function BinaryToString(ByVal Binary As String) As String
        Dim Characters As String = System.Text.RegularExpressions.Regex.Replace(Binary, "[^01 ]", "")
        Dim ByteArray((Characters.Length / 8) - 1) As Byte
        For Index As Integer = 0 To ByteArray.Length - 1
            ByteArray(Index) = Convert.ToByte(Characters.Substring(Index * 8, 8), 2)
        Next
        Return System.Text.ASCIIEncoding.ASCII.GetString(ByteArray)
    End Function


    Public Function StringToBinary(ByVal Text As String, Optional ByVal Separator As String = " ") As String
        Dim oReturn As New System.Text.StringBuilder()
        For Each Character As Byte In
        System.Text.ASCIIEncoding.ASCII.GetBytes(Text)
            oReturn.Append(Convert.ToString(Character, 2).PadLeft(8, "0 "))
            oReturn.Append(Separator)
        Next
        Return oReturn.ToString
    End Function

    Public Function GetByteFromString(ByVal Strng As String, ByVal showzeros As Boolean, ByVal secbyte As Boolean)
        Dim iLen, iA, iLen2, A2()
        iLen2 = 0
        ReDim A2(Len(Strng))
        If (secbyte = False) Then
            For iLen = 1 To Len(Strng)
                iA = Asc(Mid(Strng, iLen, 1))
                If (showzeros = True) Then
                    If iA = 0 Then iA = 42
                End If
                If (iA <> 0) Then
                    A2(iLen2) = Chr(iA)
                    iLen2 = iLen2 + 1
                End If
            Next
        Else
            For iLen = 1 To Len(Strng) Step 2
                iA = Asc(Mid(Strng, iLen, 1))
                If (showzeros = True) Then
                    If iA = 0 Then iA = 42 '-- converts 0-byte to *
                End If
                If (iA <> 0) Then
                    A2(iLen2) = Chr(iA)
                    iLen2 = iLen2 + 1
                End If
            Next
        End If
        ReDim Preserve A2(iLen2 - 1)
        GetByteFromString = Join(A2, "")
    End Function

    Function GetArray(ByVal Strng As String, ByVal SecByte As Boolean)
        Dim iA, Len1, Len2, AStr()
        On Error Resume Next
        Len1 = Len(Strng)
        If (SecByte = True) Then
            ReDim AStr((Len1 \ 2) - 1)
        Else
            ReDim AStr(Len1 - 1)
        End If

        If (SecByte = True) Then
            For iA = 1 To Len1 Step 2
                AStr(iA - 1) = Asc(Mid(Strng, iA, 1))
            Next
        Else
            For iA = 1 To Len1
                AStr(iA - 1) = Asc(Mid(Strng, iA, 1))
            Next
        End If
        GetArray = AStr
    End Function

    Function ConvertBase64(ByVal Bytes As String, Optional ByVal AddReturns As Boolean = True)
        Dim B2(), B76(), ABytes()
        Dim i1, i2, i3, LenA, NumReturns, sRet
        On Error Resume Next
        Dim ANums As Array = {65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 43, 47}

        LenA = Len(Bytes)

        ReDim ABytes(LenA - 1)
        For i1 = 1 To LenA
            ABytes(i1 - 1) = Asc(Mid(Bytes, i1, 1))
        Next

        ReDim Preserve ABytes(((LenA - 1) \ 3) * 3 + 2)
        ReDim Preserve B2((UBound(ABytes) \ 3) * 4 + 3)
        i2 = 0
        For i1 = 0 To (UBound(ABytes) - 1) Step 3
            B2(i2) = ANums(ABytes(i1) \ 4)
            i2 = i2 + 1
            B2(i2) = ANums((ABytes(i1 + 1) \ 16) Or (ABytes(i1) And 3) * 16)
            i2 = i2 + 1
            B2(i2) = ANums((ABytes(i1 + 2) \ 64) Or (ABytes(i1 + 1) And 15) * 4)
            i2 = i2 + 1
            B2(i2) = ANums(ABytes(i1 + 2) And 63)
            i2 = i2 + 1
        Next
        For i1 = 1 To i1 - LenA
            B2(UBound(B2) - i1 + 1) = 61
        Next



        If (AddReturns = True) And (LenA > 76) Then
            NumReturns = ((UBound(B2) + 1) \ 76)
            LenA = (UBound(B2) + (NumReturns * 2))
            ReDim B76(LenA)
            i2 = 0
            i3 = 0
            For i1 = 0 To UBound(B2)
                B76(i2) = B2(i1)
                i2 = i2 + 1
                i3 = i3 + 1
                If (i3 = 76) And (i2 < (LenA - 2)) Then
                    B76(i2) = 13
                    B76(i2 + 1) = 10
                    i2 = i2 + 2
                    i3 = 0
                End If
            Next
            For i1 = 0 To UBound(B76)
                B76(i1) = Chr(B76(i1))
            Next
            sRet = Join(B76, "")
        Else
            For i1 = 0 To UBound(B2)
                B2(i1) = Chr(B2(i1))
            Next
            sRet = Join(B2, "")
        End If
        ConvertBase64 = sRet
    End Function

    Function base64File(ByVal filepath As String)
        OFil = FSO.GetFile(filepath)
        LSize = OFil.Size
        OFil = Nothing
        TS = FSO.OpenTextFile(filepath)
        sIn = TS.Read(LSize)
        TS = Nothing
        sOut = binConvertToBase64(sIn, True)
        Return sOut
    End Function

    Function binConvertToBase64(ByVal sBytes, ByVal AddReturns)
        Dim B2(), B76(), ABytes()
        Dim i1, i2, i3, LenA, NumReturns, sRet
        On Error Resume Next
        Dim ANums As Array = {65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 43, 47}

        LenA = Len(sBytes)
        '-- convert each string character to ASCII value.
        ReDim ABytes(LenA - 1)
        For i1 = 1 To LenA
            ABytes(i1 - 1) = Asc(Mid(sBytes, i1, 1))
        Next
        '-- generate base 64 equivalent in array B2.
        ReDim Preserve ABytes(((LenA - 1) \ 3) * 3 + 2)
        ReDim Preserve B2((UBound(ABytes) \ 3) * 4 + 3)
        i2 = 0
        For i1 = 0 To (UBound(ABytes) - 1) Step 3
            B2(i2) = ANums(ABytes(i1) \ 4)
            i2 = i2 + 1
            B2(i2) = ANums((ABytes(i1 + 1) \ 16) Or (ABytes(i1) And 3) * 16)
            i2 = i2 + 1
            B2(i2) = ANums((ABytes(i1 + 2) \ 64) Or (ABytes(i1 + 1) And 15) * 4)
            i2 = i2 + 1
            B2(i2) = ANums(ABytes(i1 + 2) And 63)
            i2 = i2 + 1
        Next
        For i1 = 1 To i1 - LenA
            B2(UBound(B2) - i1 + 1) = 61 ' add = signs at end if necessary.
        Next

        '-- Most email programs use a maximum of 76 characters per line when encoding
        '-- binary files as base 64. This next function achieves that by generating another
        '--- array big enough for the added vbCrLfs, then copying the base 64 array over.

        If (AddReturns = True) And (LenA > 76) Then
            NumReturns = ((UBound(B2) + 1) \ 76)
            LenA = (UBound(B2) + (NumReturns * 2)) '--make B76 B2 plus 2 spots for each vbcrlf.
            ReDim B76(LenA)
            i2 = 0
            i3 = 0
            For i1 = 0 To UBound(B2)
                B76(i2) = B2(i1)
                i2 = i2 + 1
                i3 = i3 + 1
                If (i3 = 76) And (i2 < (LenA - 2)) Then   '--extra check. make sure there are still
                    B76(i2) = 13                 '-- 2 spots left for return if at end.
                    B76(i2 + 1) = 10
                    i2 = i2 + 2
                    i3 = 0
                End If
            Next
            For i1 = 0 To UBound(B76)
                B76(i1) = Chr(B76(i1))
            Next
            sRet = Join(B76, "")
        Else
            For i1 = 0 To UBound(B2)
                B2(i1) = Chr(B2(i1))
            Next
            sRet = Join(B2, "")
        End If
        binConvertToBase64 = sRet
    End Function

    Function DecodeBase64(ByVal Strng64 As String)
        Dim B1(), B2()
        Dim i1, i2, i3, LLen, UNum, s2, sRet
        Dim A255(255)
        On Error Resume Next
        Dim ANums As Array = {65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 43, 47}

        For i1 = 0 To 255
            A255(i1) = 64
        Next
        For i1 = 0 To 63
            A255(ANums(i1)) = i1
        Next
        s2 = Replace(Strng64, vbCrLf, "")
        s2 = Trim(s2)
        LLen = Len(s2)
        ReDim B1(LLen - 1)
        For i1 = 1 To LLen
            B1(i1 - 1) = Asc(Mid(s2, i1, 1))
        Next

        '--B1 is now in-string as array.
        ReDim B2((LLen \ 4) * 3 - 1)
        i2 = 0
        For i1 = 0 To UBound(B1) Step 4
            B2(i2) = (A255(B1(i1)) * 4) Or (A255(B1(i1 + 1)) \ 16)
            i2 = i2 + 1
            B2(i2) = (A255(B1(i1 + 1)) And 15) * 16 Or (A255(B1(i1 + 2)) \ 4)
            i2 = i2 + 1
            B2(i2) = (A255(B1(i1 + 2)) And 3) * 64 Or A255(B1(i1 + 3))
            i2 = i2 + 1
        Next
        If B1(LLen - 2) = 61 Then
            i2 = 2
        ElseIf B1(LLen - 1) = 61 Then
            i2 = 1
        Else
            i2 = 0
        End If
        UNum = UBound(B2) - i2
        ReDim Preserve B2(UNum)
        For i1 = 0 To UBound(B2)
            B2(i1) = Chr(B2(i1))
        Next
        DecodeBase64 = Join(B2, "")
    End Function

    Public Sub EncodeFile(ByVal source As String, ByVal destin As String, ByVal append As Boolean)
        Dim fileContents As String
        fileContents = My.Computer.FileSystem.ReadAllText(source)
        Dim rf = ConvertBase64(fileContents, True)
        My.Computer.FileSystem.WriteAllText(destin, rf, append)
    End Sub

    Public Sub DecodeFile(ByVal source As String, ByVal destin As String, ByVal append As Boolean)
        Dim fileContents As String
        fileContents = My.Computer.FileSystem.ReadAllText(source)
        Dim rf = DecodeBase64(fileContents)
        My.Computer.FileSystem.WriteAllText(destin, rf, append)
    End Sub

    Function ConvertStringToByte(ByVal string2conv As String)
        Dim bytes As Byte() = Encoding.Unicode.GetBytes(string2conv)
        Return bytes
    End Function


    Function ConvertByteToString(ByVal byteArray As Byte()) As String
        Dim enc As Encoding = Encoding.UTF8
        Dim text As String = enc.GetString(byteArray)
        Return text
    End Function


    Public Function GetByteArrayFromImage(ByVal img As Bitmap) As Byte()
        Dim ms As New System.IO.MemoryStream
        img.Save(ms, Imaging.ImageFormat.Bmp)
        Dim outBytes(CInt(ms.Length - 1)) As Byte
        ms.Seek(0, System.IO.SeekOrigin.Begin)
        ms.Read(outBytes, 0, CInt(ms.Length))
        Return outBytes
    End Function


    Public Function GetImageFromByteArray(ByVal bytes As Byte()) As Bitmap
        Return CType(Bitmap.FromStream(New IO.MemoryStream(bytes)), Bitmap)
    End Function

    Function ByteFromFile(ByVal filepath As String) As Byte
        Dim file1Reader As New FileStream(filepath, FileMode.Open)
        Dim byte1 As Integer = file1Reader.ReadByte()
        Return byte1
    End Function

    Function WriteByteFile(ByVal filepath As String, ByVal content As Byte) As Byte
        Dim file1Reader As New FileStream(filepath, FileMode.Open)
        file1Reader.WriteByte(content)
        Return content
    End Function

    Public Sub WriteBytesTofile(ByVal filepath As String, ByVal contents As Byte(), ByVal append As Boolean)
        Dim fileContents() As Byte = contents
        My.Computer.FileSystem.WriteAllBytes(filepath, fileContents, append)

    End Sub

    Function ReadFileBytes(ByVal filepath As String)
        Dim fileContents As Byte()
        fileContents = My.Computer.FileSystem.ReadAllBytes(filepath)
        Return fileContents
    End Function

    Public Sub WriteFile(ByVal filepath As String, ByVal contents As String, ByVal Append As Boolean)
        Try
            My.Computer.FileSystem.WriteAllText(filepath, contents, Append)
        Catch ex As Exception
            MsgBox("Access Denied")
        End Try

    End Sub

    Function ReadFile(ByVal filepath As String)
        Dim fileContents As String
        fileContents = My.Computer.FileSystem.ReadAllText(filepath)
        Return fileContents
    End Function

    Enum infotype
        Extension
        Path
        Name
        size
    End Enum
    Function GetFileInfo(ByVal filepath As String, ByVal information As infotype)

        Dim fileData As FileInfo = My.Computer.FileSystem.GetFileInfo(filepath)
        If information = infotype.Extension Or information = "extension" Then
            Return fileData.Extension
        ElseIf information = infotype.Path Or information = "path" Then
            Return fileData.FullName
        ElseIf information = infotype.Name Or information = "name" Then
            Return fileData.Name
        ElseIf information = infotype.size Or information = "size" Then
            Return fileData.Length
        Else
            Return fileData
        End If

    End Function

    Const KB As Long = 1024
    Const MB As Long = KB * 1024
    Const GB As Long = MB * 1024
    Const TB As Long = GB * 1024
    Const M As Long = 60
    Const H As Long = M * 60
    Const D As Long = H * 24
    Dim intTemp
    Function FormatFileSize(ByVal filesize As Integer)
        If filesize <= KB Then
            Return filesize.ToString & " Byte"
        ElseIf filesize > KB And filesize <= MB Then
            filesize = Math.Round(filesize / KB, 0)
            Return filesize.ToString & " KB"
        ElseIf filesize > MB And filesize <= GB Then
            intTemp = Math.Round(filesize / MB, 0)
            Return intTemp.ToString & " MB"
        ElseIf filesize > GB And filesize <= TB Then
            intTemp = Math.Round(filesize / GB, 0)
            Return intTemp.ToString & " GB"
        ElseIf filesize >= TB Then
            intTemp = Math.Round(filesize / TB, 0)
            Return intTemp.ToString & " TB"
        Else
            Return intTemp

        End If
    End Function

    Private Function CompareFiles(ByVal file1 As String, ByVal file2 As String) As Boolean
        ' Set to true if the files are equal; false otherwise
        Dim filesAreEqual As Boolean = False

        With My.Computer.FileSystem
            ' Ensure that the files are the same length before comparing them line by line.
            If .GetFileInfo(file1).Length = .GetFileInfo(file2).Length Then
                Using file1Reader As New FileStream(file1, FileMode.Open), _
                      file2Reader As New FileStream(file2, FileMode.Open)
                    Dim byte1 As Integer = file1Reader.ReadByte()
                    Dim byte2 As Integer = file2Reader.ReadByte()
                    ' If byte1 or byte2 is a negative value, we have reached the end of the file.
                    While byte1 >= 0 AndAlso byte2 >= 0
                        If (byte1 <> byte2) Then
                            filesAreEqual = False
                            Exit While
                        Else
                            filesAreEqual = True
                        End If
                        ' Read the next byte.
                        byte1 = file1Reader.ReadByte()
                        byte2 = file2Reader.ReadByte()
                    End While
                End Using
            End If
        End With

        Return filesAreEqual
    End Function


End Module


