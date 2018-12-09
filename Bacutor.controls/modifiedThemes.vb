Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D

' Functions by AeonHack
' Controls from MonoFlatTheme by Vengfull@OwnerCore.com, Login GDI+ Theme by Xerts (HF), iTalkTheme By AeonHack and FlatUI Theme by isynthesis (HF)
Module Helpers
#Region " Variables"
    Friend G As Graphics, B As Bitmap
    Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
#End Region

#Region " Functions"



    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Public Function RoundRect(ByVal x!, ByVal y!, ByVal w!, ByVal h!, Optional ByVal r! = 0.3, Optional ByVal TL As Boolean = True, Optional ByVal TR As Boolean = True, Optional ByVal BR As Boolean = True, Optional ByVal BL As Boolean = True) As GraphicsPath
        Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
        RoundRect = New GraphicsPath

        With RoundRect
            If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
            If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
            If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
            If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

            .CloseFigure()
        End With
    End Function

    '-- Credit: AeonHack
    Public Function DrawArrow(ByVal x As Integer, ByVal y As Integer, ByVal flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 12
        Dim H As Integer = 6

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

#End Region

End Module

#Region " Mouse States"


#End Region

Module ConversionFunctions
    Function ToBrush(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(A, R, G, B))
    End Function
    Function ToBrush(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(R, G, B))
    End Function
    Function ToBrush(ByVal A As Integer, ByVal C As Color) As Brush
        Return New SolidBrush(Color.FromArgb(A, C))
    End Function
    Function ToBrush(ByVal Pen As Pen) As Brush
        Return New SolidBrush(Pen.Color)
    End Function
    Function ToBrush(ByVal Color As Color) As Brush
        Return New SolidBrush(Color)
    End Function
    Function ToPen(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, R, G, B)))
    End Function
    Function ToPen(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(R, G, B)))
    End Function
    Function ToPen(ByVal A As Integer, ByVal C As Color) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, C)))
    End Function
    Function ToPen(ByVal Brush As SolidBrush) As Pen
        Return New Pen(Brush)
    End Function
    Function ToPen(ByVal Color As Color) As Pen
        Return New Pen(New SolidBrush(Color))
    End Function
End Module
Module RRM
    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
End Module
Module Shapes
    Public Function Triangle(ByVal Location As Point, ByVal Size As Size) As Point()
        Dim ReturnPoints(0 To 3) As Point
        ReturnPoints(0) = Location
        ReturnPoints(1) = New Point(Location.X + Size.Width, Location.Y)
        ReturnPoints(2) = New Point(Location.X + Size.Width \ 2, Location.Y + Size.Height)
        ReturnPoints(3) = Location
        Return ReturnPoints
    End Function
End Module
Module funcs

#Region "Functions"

    Public Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Public Function RoundRect(ByVal x!, ByVal y!, ByVal w!, ByVal h!, Optional ByVal r! = 0.3, Optional ByVal TL As Boolean = True, Optional ByVal TR As Boolean = True, Optional ByVal BR As Boolean = True, Optional ByVal BL As Boolean = True) As GraphicsPath
        Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
        RoundRect = New GraphicsPath

        With RoundRect
            If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
            If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
            If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
            If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

            .CloseFigure()
        End With
    End Function

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#End Region

End Module
Class RoundCustomForm
    ' Copied From The MonoFlatTheme by Creator: Vengfull @ OwnedCore.com
    Inherits ContainerControl

#Region " Enums "

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#End Region
#Region " Variables "

    Private HeaderRect As Rectangle
    Protected State As MouseState
    Private MoveHeight As Integer
    Private MouseP As Point = New Point(0, 0)
    Private Cap As Boolean = False
    Private HasShown As Boolean

#End Region
#Region " Properties "
    Private Barcolor As Color = Color.FromArgb(45, 45, 45)
    Private BGColor As Color = Color.FromArgb(54, 54, 54)
    Private TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _Sizable As Boolean = True

    <Category("Colors")>
    Property TitleBarColor As Color
        Get
            Return Barcolor
        End Get
        Set(ByVal value As Color)
            Barcolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property TxtColor As Color
        Get
            Return TextColor
        End Get
        Set(ByVal value As Color)
            TextColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property BacColor As Color
        Get
            Return BGColor
        End Get
        Set(ByVal value As Color)
            BGColor = value
            Invalidate()
            Update()
        End Set
    End Property

    Property reizable() As Boolean
        Get
            Return _Sizable
        End Get
        Set(ByVal value As Boolean)
            _Sizable = value
        End Set
    End Property

    Private _SmartBounds As Boolean = True
    Property AddBounds() As Boolean
        Get
            Return _SmartBounds
        End Get
        Set(ByVal value As Boolean)
            _SmartBounds = value
            Invalidate()
            Update()
        End Set
    End Property

    Private _RoundCorners As Boolean = True
    Property RoundCorners() As Boolean
        Get
            Return _RoundCorners
        End Get
        Set(ByVal value As Boolean)
            _RoundCorners = value
            Invalidate()
            Update()
        End Set
    End Property

    Private _IsParentForm As Boolean
    Protected ReadOnly Property FormParent As Boolean
        Get
            Return _IsParentForm
        End Get
    End Property

    Protected ReadOnly Property MakeMdiForm As Boolean
        Get
            If Parent Is Nothing Then Return False
            Return Parent.Parent IsNot Nothing
        End Get
    End Property

    Private _ControlMode As Boolean

    Private _StartPosition As FormStartPosition
    Property StartPosition As FormStartPosition
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.StartPosition Else Return _StartPosition
        End Get
        Set(ByVal value As FormStartPosition)
            _StartPosition = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.StartPosition = value
            End If
        End Set
    End Property

#End Region
#Region " EventArgs "

    Protected NotOverridable Overrides Sub OnParentChanged(ByVal e As EventArgs)
        MyBase.OnParentChanged(e)

        If Parent Is Nothing Then Return
        _IsParentForm = TypeOf Parent Is Form

        If Not _ControlMode Then
            InitializeMessages()

            If _IsParentForm Then
                Me.ParentForm.FormBorderStyle = FormBorderStyle.None
                Me.ParentForm.TransparencyKey = Color.Fuchsia

                If Not DesignMode Then
                    AddHandler ParentForm.Shown, AddressOf FormShown
                End If
            End If
            Parent.BackColor = BackColor
            '   Parent.MinimumSize = New Size(261, 65)
        End If
    End Sub

    Protected NotOverridable Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Not _ControlMode Then HeaderRect = New Rectangle(0, 0, Width - 14, MoveHeight - 7)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Focus()
        If e.Button = Windows.Forms.MouseButtons.Left Then SetState(MouseState.Down)
        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized OrElse _ControlMode) Then
            If HeaderRect.Contains(e.Location) Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(0))
            ElseIf _Sizable AndAlso Not Previous = 0 Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(Previous))
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        Cap = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized) Then
            If _Sizable AndAlso Not _ControlMode Then InvalidateMouse()
        End If
        If Cap Then
            Parent.Location = MousePosition - MouseP
        End If
    End Sub

    Protected Overrides Sub OnInvalidated(ByVal e As System.Windows.Forms.InvalidateEventArgs)
        MyBase.OnInvalidated(e)

    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Private Sub FormShown(ByVal sender As Object, ByVal e As EventArgs)
        If _ControlMode OrElse HasShown Then Return

        If _StartPosition = FormStartPosition.CenterParent OrElse _StartPosition = FormStartPosition.CenterScreen Then
            Dim SB As Rectangle = Screen.PrimaryScreen.Bounds
            Dim CB As Rectangle = ParentForm.Bounds
            ParentForm.Location = New Point(SB.Width \ 2 - CB.Width \ 2, SB.Height \ 2 - CB.Width \ 2)
        End If
        HasShown = True
    End Sub

#End Region
#Region " Mouse & Size "

    Private Sub SetState(ByVal current As MouseState)
        State = current
        Invalidate()
    End Sub

    Private GetIndexPoint As Point
    Private B1x, B2x, B3, B4 As Boolean
    Private Function GetIndex() As Integer
        GetIndexPoint = PointToClient(MousePosition)
        B1x = GetIndexPoint.X < 7
        B2x = GetIndexPoint.X > Width - 7
        B3 = GetIndexPoint.Y < 7
        B4 = GetIndexPoint.Y > Height - 7

        If B1x AndAlso B3 Then Return 4
        If B1x AndAlso B4 Then Return 7
        If B2x AndAlso B3 Then Return 5
        If B2x AndAlso B4 Then Return 8
        If B1x Then Return 1
        If B2x Then Return 2
        If B3 Then Return 3
        If B4 Then Return 6
        Return 0
    End Function

    Private Current, Previous As Integer
    Private Sub InvalidateMouse()
        Current = GetIndex()
        If Current = Previous Then Return

        Previous = Current
        Select Case Previous
            Case 0
                Cursor = Cursors.Default
            Case 6
                Cursor = Cursors.SizeNS
            Case 8
                Cursor = Cursors.SizeNWSE
            Case 7
                Cursor = Cursors.SizeNESW
        End Select
    End Sub

    Private Messages(8) As Message
    Private Sub InitializeMessages()
        Messages(0) = Message.Create(Parent.Handle, 161, New IntPtr(2), IntPtr.Zero)
        For I As Integer = 1 To 8
            Messages(I) = Message.Create(Parent.Handle, 161, New IntPtr(I + 9), IntPtr.Zero)
        Next
    End Sub

    Private Sub CorrectBounds(ByVal bounds As Rectangle)
        If Parent.Width > bounds.Width Then Parent.Width = bounds.Width
        If Parent.Height > bounds.Height Then Parent.Height = bounds.Height

        Dim X As Integer = Parent.Location.X
        Dim Y As Integer = Parent.Location.Y

        If X < bounds.X Then X = bounds.X
        If Y < bounds.Y Then Y = bounds.Y

        Dim Width As Integer = bounds.X + bounds.Width
        Dim Height As Integer = bounds.Y + bounds.Height

        If X + Parent.Width > Width Then X = Width - Parent.Width
        If Y + Parent.Height > Height Then Y = Height - Parent.Height

        Parent.Location = New Point(X, Y)
    End Sub

    Private WM_LMBUTTONDOWN As Boolean
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If WM_LMBUTTONDOWN AndAlso m.Msg = 513 Then
            WM_LMBUTTONDOWN = False

            SetState(MouseState.Over)
            If Not _SmartBounds Then Return

            If MakeMdiForm Then
                CorrectBounds(New Rectangle(Point.Empty, Parent.Parent.Size))
            Else
                CorrectBounds(Screen.FromControl(Parent).WorkingArea)
            End If
        End If
    End Sub

#End Region

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
    End Sub

    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
        BackColor = Color.FromArgb(50, 50, 50)
        Padding = New Padding(10, 70, 10, 9)
        DoubleBuffered = True
        Dock = DockStyle.Fill
        MoveHeight = 66
        Font = New Font("Segoe UI", 9)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        G.Clear(BGColor)
        G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(0, 0, Width, 60))

        If _RoundCorners = True Then
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1)

            G.FillRectangle(New SolidBrush(Barcolor), 1, 3, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 1, 2, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 2, 1, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 3, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1)

            G.FillRectangle(New SolidBrush(Barcolor), Width - 2, 3, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 2, 2, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 3, 1, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 4, 1, 1, 1)

            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 2, 1, 1)

            G.FillRectangle(New SolidBrush(BGColor), 1, Height - 3, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 1, Height - 4, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 3, Height - 2, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 2, Height - 2, 1, 1)


            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 4, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 2, 1, 1)

            G.FillRectangle(New SolidBrush(BGColor), Width - 2, Height - 3, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 2, Height - 4, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 4, Height - 2, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 3, Height - 2, 1, 1)
        End If

        G.DrawString(Text, New Font("Segoe UI", 10, FontStyle.Bold), New SolidBrush(TextColor), New Rectangle(20, 20, Width - 1, Height), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
    End Sub
End Class

Public Class LogInNormalTextBox
    Inherits Control

#Region "Declarations"
    Private State As MouseState = MouseState.None
    Private WithEvents TB As Windows.Forms.TextBox
    Private _BaseColor As Color = Color.FromArgb(42, 42, 42)
    Private _TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _Style As Styles = Styles.NotRounded
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _UseSystemPasswordChar As Boolean
    Private _Multiline As Boolean
#End Region

#Region "TextBox Properties"

    Enum Styles
        Rounded
        NotRounded
    End Enum

    <Category("Options")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub

    Public Property Style As Styles
        Get
            Return _Style
        End Get
        Set(ByVal value As Styles)
            _Style = value
        End Set
    End Property

    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
    End Sub


#End Region

#Region "Color Properties"

    <Category("Colors")>
    Public Property BackgroundColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        TB = New Windows.Forms.TextBox
        TB.Height = 190
        TB.Font = New Font("Segoe UI", 10)
        TB.Text = Text
        TB.BackColor = Color.FromArgb(42, 42, 42)
        TB.ForeColor = Color.FromArgb(255, 255, 255)
        TB.MaxLength = _MaxLength
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 5)
        TB.Width = Width - 35
        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP As GraphicsPath
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            TB.BackColor = Color.FromArgb(42, 42, 42)
            TB.ForeColor = Color.FromArgb(255, 255, 255)
            Select Case _Style
                Case Styles.Rounded
                    GP = RoundRec(Base, 6)
                    .FillPath(New SolidBrush(Color.FromArgb(42, 42, 42)), GP)
                    .DrawPath(New Pen(New SolidBrush(Color.FromArgb(35, 35, 35)), 2), GP)
                Case Styles.NotRounded
                    .FillRectangle(New SolidBrush(Color.FromArgb(42, 42, 42)), New Rectangle(0, 0, Width - 1, Height - 1))
                    .DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(35, 35, 35)), 2), New Rectangle(0, 0, Width, Height))
            End Select

        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub



#End Region

End Class


Public Class DarkTabControl
    Inherits TabControl

#Region "Declarations"

    Private _TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _BackTabColor As Color = Color.FromArgb(45, 45, 45)
    Private _BaseColor As Color = Color.FromArgb(35, 35, 35)
    Private _ActiveColor As Color = Color.FromArgb(47, 47, 47)
    Private _BorderColor As Color = Color.FromArgb(30, 30, 30)
    Private _UpLineColor As Color = Color.FromArgb(0, 160, 199)
    Private _HorizLineColor As Color = Color.FromArgb(23, 119, 151)
    Private CenterSF As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}

#End Region

#Region "Properties"

    <Category("Colors")> _
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property LineColor As Color
        Get
            Return _UpLineColor
        End Get
        Set(ByVal value As Color)
            _UpLineColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property TabColor As Color
        Get
            Return _BackTabColor
        End Get
        Set(ByVal value As Color)
            _BackTabColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property BgColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property ActiveColor As Color
        Get
            Return _ActiveColor
        End Get
        Set(ByVal value As Color)
            _ActiveColor = value
            Invalidate()
            Update()
        End Set
    End Property

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 8)
        SizeMode = TabSizeMode.Normal
        ItemSize = New Size(240, 32)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .Clear(_BaseColor)
            Try : SelectedTab.BackColor = _BackTabColor : Catch : End Try
            Try : SelectedTab.BorderStyle = BorderStyle.None : Catch : End Try
            .DrawRectangle(New Pen(_BorderColor, 1), New Rectangle(0, 0, Width, Height))
            For i = 0 To TabCount - 1
                Dim Base As New Rectangle(New Point(GetTabRect(i).Location.X, GetTabRect(i).Location.Y), New Size(GetTabRect(i).Width, GetTabRect(i).Height))
                Dim BaseSize As New Rectangle(Base.Location, New Size(Base.Width, Base.Height))
                If i = SelectedIndex Then
                    .FillRectangle(New SolidBrush(_BaseColor), BaseSize)
                    .FillRectangle(New SolidBrush(_ActiveColor), New Rectangle(Base.X, Base.Y + 5, Base.Width, Base.Height + 6))
                    .DrawString(TabPages(i).Text, Font, New SolidBrush(_TextColor), New Rectangle(Base.X, Base.Y, Base.Width, Base.Height), CenterSF)
                    .DrawLine(New Pen(_UpLineColor, 2), New Point(Base.X, Base.Y), New Point(Base.X, Base.Height))
                Else
                    .DrawString(TabPages(i).Text, Font, New SolidBrush(_TextColor), BaseSize, CenterSF)
                End If
            Next
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class

Public Class DarkWinForm
    Inherits ContainerControl

#Region "Declarations"
    Private _AllowClose As Boolean = True
    Private _AllowMinimize As Boolean = True
    Private _AllowMaximize As Boolean = True
    Private _FontSize As Integer = 9
    Private ReadOnly _Font As Font = New Font("Segoe UI", _FontSize)
    Private _ShowIcon As Boolean = False
    Private State As MouseState = MouseState.None
    Private MouseXLoc As Integer
    Private MouseYLoc As Integer
    Private CaptureMovement As Boolean = False
    Private Const MoveHeight As Integer = 35
    Private MouseP As Point = New Point(0, 0)
    Private _FontColor As Color = Color.FromArgb(255, 255, 255)
    Private _BaseColor As Color = Color.FromArgb(35, 35, 35)
    Private _ContainerColor As Color = Color.FromArgb(46, 46, 46)
    Private _BorderColor As Color = Color.FromArgb(60, 60, 60)
    Private _HoverColor As Color = Color.DeepSkyBlue
#End Region

#Region "Properties & Events"

    <Category("Control")>
    Public Property FontSize As Integer
        Get
            Return _FontSize
        End Get
        Set(ByVal value As Integer)
            _FontSize = value
        End Set
    End Property

    <Category("Control")>
    Public Property AllowMinimize As Boolean
        Get
            Return _AllowMinimize
        End Get
        Set(ByVal value As Boolean)
            _AllowMinimize = value
        End Set
    End Property

    <Category("Control")>
    Public Property AllowMaximize As Boolean
        Get
            Return _AllowMaximize
        End Get
        Set(ByVal value As Boolean)
            _AllowMaximize = value
        End Set
    End Property

    <Category("Control")>
    Public Property ShowIcon As Boolean
        Get
            Return _ShowIcon
        End Get
        Set(ByVal value As Boolean)
            _ShowIcon = value
        End Set
    End Property

    <Category("Control")>
    Public Property CloseIcon As Boolean
        Get
            Return _AllowClose
        End Get
        Set(ByVal value As Boolean)
            _AllowClose = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(ByVal value As Color)
            _HoverColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BGColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BaseColor As Color
        Get
            Return _ContainerColor
        End Get
        Set(ByVal value As Color)
            _ContainerColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property FontColor As Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Color)
            _FontColor = value
        End Set
    End Property

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureMovement = False
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        MouseXLoc = e.Location.X
        MouseYLoc = e.Location.Y
        Invalidate()
        If CaptureMovement Then
            Parent.Location = MousePosition - MouseP
        End If
        If e.X < Width - 90 AndAlso e.Y > 35 Then Cursor = Cursors.Arrow Else Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If MouseXLoc > Width - 39 AndAlso MouseXLoc < Width - 16 AndAlso MouseYLoc < 22 Then
            If _AllowClose Then
                Environment.Exit(0)
            End If
        ElseIf MouseXLoc > Width - 64 AndAlso MouseXLoc < Width - 41 AndAlso MouseYLoc < 22 Then
            If _AllowMaximize Then
                Select Case FindForm.WindowState
                    Case FormWindowState.Maximized
                        FindForm.WindowState = FormWindowState.Normal
                    Case FormWindowState.Normal
                        FindForm.WindowState = FormWindowState.Maximized
                End Select
            End If
        ElseIf MouseXLoc > Width - 89 AndAlso MouseXLoc < Width - 66 AndAlso MouseYLoc < 22 Then
            If _AllowMinimize Then
                Select Case FindForm.WindowState
                    Case FormWindowState.Normal
                        FindForm.WindowState = FormWindowState.Minimized
                    Case FormWindowState.Maximized
                        FindForm.WindowState = FormWindowState.Minimized
                End Select
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width - 90, MoveHeight).Contains(e.Location) Then
            CaptureMovement = True
            MouseP = e.Location
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(Width - 90, 22, 75, 13).Contains(e.Location) Then
            CaptureMovement = True
            MouseP = e.Location
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(Width - 15, 0, 15, MoveHeight).Contains(e.Location) Then
            CaptureMovement = True
            MouseP = e.Location
        Else
            Focus()
        End If
        State = MouseState.Down
        Invalidate()
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.DoubleBuffered = True
        Me.BackColor = _BaseColor
        Me.Dock = DockStyle.Fill
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ParentForm.FormBorderStyle = FormBorderStyle.None
        ParentForm.AllowTransparency = False
        ParentForm.TransparencyKey = Color.White
        ParentForm.FindForm.StartPosition = FormStartPosition.CenterScreen
        Dock = DockStyle.Fill
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .FillRectangle(New SolidBrush(_BaseColor), New Rectangle(0, 0, Width, Height))
            .FillRectangle(New SolidBrush(_ContainerColor), New Rectangle(2, 45, Width - 4, Height - 45))

            Dim ControlBoxPoints() As Point = {New Point(Width - 90, 0), New Point(Width - 90, 22), New Point(Width - 15, 22), New Point(Width - 15, 0)}
            Select Case State
                Case MouseState.Over
                    If MouseXLoc > Width - 39 AndAlso MouseXLoc < Width - 16 AndAlso MouseYLoc < 22 Then
                        .FillRectangle(New SolidBrush(_HoverColor), New Rectangle(Width - 39, 0, 23, 22))
                    ElseIf MouseXLoc > Width - 64 AndAlso MouseXLoc < Width - 41 AndAlso MouseYLoc < 22 Then
                        .FillRectangle(New SolidBrush(_HoverColor), New Rectangle(Width - 64, 0, 23, 22))
                    ElseIf MouseXLoc > Width - 89 AndAlso MouseXLoc < Width - 66 AndAlso MouseYLoc < 22 Then
                        .FillRectangle(New SolidBrush(_HoverColor), New Rectangle(Width - 89, 0, 23, 22))
                    End If
            End Select
            .DrawLine(New Pen(_BorderColor), Width - 40, 0, Width - 40, 22)
            ''Close Button
            .DrawLine(New Pen(_FontColor), Width - 33, 6, Width - 22, 16)
            .DrawLine(New Pen(_FontColor), Width - 33, 16, Width - 22, 6)
            ''Minimize Button
            .DrawLine(New Pen(_FontColor), Width - 83, 16, Width - 72, 16)
            ''Maximize Button
            .DrawLine(New Pen(_FontColor), Width - 58, 16, Width - 47, 16)
            .DrawLine(New Pen(_FontColor), Width - 58, 16, Width - 58, 6)
            .DrawLine(New Pen(_FontColor), Width - 47, 16, Width - 47, 6)
            .DrawLine(New Pen(_FontColor), Width - 58, 6, Width - 47, 6)
            .DrawLine(New Pen(_FontColor), Width - 58, 7, Width - 47, 7)
            If _ShowIcon Then
                .DrawIcon(FindForm.Icon, New Rectangle(6, 6, 22, 22))
                .DrawString(Text, _Font, New SolidBrush(_FontColor), New RectangleF(31, 0, Width - 110, 35), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            Else
                .DrawString(Text, _Font, New SolidBrush(_FontColor), New RectangleF(3, 0, Width - 110, 35), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            End If
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'DarkWinForm
        '
        Me.ResumeLayout(False)

    End Sub
End Class

Class KnobTrackBar : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private Val As Integer
    Private Bool As Boolean
    Private Track As Rectangle
    Private Knob As Rectangle
    Private Style_ As _Style

#End Region

#Region " Properties"

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
            Track = New Rectangle(Val, 0, 10, 20)

            Bool = Track.Contains(e.Location)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Bool AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
            Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e) : Bool = False
    End Sub

#End Region

#Region " Styles"

    <Flags()> _
    Enum _Style
        Slider
        Knob
    End Enum

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property SpillColor As Color
        Get
            Return _TrackColor
        End Get
        Set(ByVal value As Color)
            _TrackColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property KnobColor As Color
        Get
            Return SliderColor
        End Get
        Set(ByVal value As Color)
            SliderColor = value
        End Set
    End Property

#End Region

    Event Scroll(ByVal sender As Object)
    Private _Minimum As Integer
    Public Property Minimum As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
            End If

            _Minimum = value

            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property
    Private _Maximum As Integer = 10
    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property
    Private _Value As Integer
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
            End If

            _Value = value
            Invalidate()
            RaiseEvent Scroll(Me)
        End Set
    End Property
    Private _ShowValue As Boolean = True

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Subtract Then
            If Value = 0 Then Exit Sub
            Value -= 1
        ElseIf e.KeyCode = Keys.Add Then
            If Value = _Maximum Then Exit Sub
            Value += 1
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Height = 23
    End Sub

#End Region

#Region " Colors"

    Private BaseColor As Color = Color.FromArgb(45, 47, 49)
    Private _TrackColor As Color = Color.FromArgb(55, 55, 55)
    Private SliderColor As Color = Color.DimGray
    Private _HatchColor As Color = Color.FromArgb(23, 148, 92)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Height = 18
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(1, 6, W - 2, 8)
        Dim GP, GP2 As New GraphicsPath

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 5
            .Clear(BackColor)

            '-- Value
            Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (W - 10))
            Track = New Rectangle(Val, 0, 10, 20)
            Knob = New Rectangle(Val, 4, 13, 13)

            '-- Base
            GP.AddRectangle(Base)
            .SetClip(GP)
            .FillRectangle(New SolidBrush(BaseColor), New Rectangle(10, 7, W, 8))
            .FillRectangle(New SolidBrush(_TrackColor), New Rectangle(0, 7, Track.X + Track.Width, 6))
            .ResetClip()

            '-- Hatch Brush


            '-- Slider/Knob


            GP2.AddEllipse(Knob)
            .FillPath(New SolidBrush(SliderColor), GP2)


            '-- Show the value 

        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class


#Region " NotificationBox "

Class NotificationBox
    Inherits Control

#Region " Variables "

    Private CloseCoordinates As Point
    Private IsOverClose As Boolean
    Private _BorderCurve As Integer = 8
    Private CreateRoundPath As GraphicsPath
    Private NotificationText As String = Nothing
    Private _NotificationType As Type
    Private _RoundedCorners As Boolean
    Private _ShowCloseButton As Boolean
    Private _Image As Image
    Private _ImageSize As Size
    Private setngz As Array = {Color.DimGray, Color.DarkSlateGray, Color.White}

    Dim customTex As String = "CUSTOM"

#End Region
#Region " Enums "

    ' Create a list of Notification Types
    Enum Type
        [Normal]
        [Success]
        [Warning]
        [Error]
        [Custom]
    End Enum

#End Region
#Region " Custom Properties "

    ' Create a NotificationType property and add the Type enum to it
    Public Property NotificationType As Type
        Get
            Return _NotificationType
        End Get
        Set(ByVal value As Type)
            _NotificationType = value
            Invalidate()
        End Set
    End Property
    ' Boolean value to determine whether the control should use border radius
    Public Property RoundCorners As Boolean
        Get
            Return _RoundedCorners
        End Get
        Set(ByVal value As Boolean)
            _RoundedCorners = value
            Invalidate()
        End Set
    End Property
    ' Boolean value to determine whether the control should draw the close button
    Public Property AllowClose As Boolean
        Get
            Return _ShowCloseButton
        End Get
        Set(ByVal value As Boolean)
            _ShowCloseButton = value
            Invalidate()
        End Set
    End Property

    Public Property CustomNotification As Array
        Get
            Return setngz
        End Get
        Set(ByVal value As Array)
            setngz = value
            Invalidate()
        End Set
    End Property

    Public Property CustomText As String
        Get
            Return customTex
        End Get
        Set(ByVal value As String)
            customTex = value
            Invalidate()
        End Set
    End Property

    ' Integer value to determine the curve level of the borders
    Public Property Radius As Integer
        Get
            Return _BorderCurve
        End Get
        Set(ByVal value As Integer)
            _BorderCurve = value
            Invalidate()
        End Set
    End Property
    ' Image value to determine whether the control should draw an image before the header
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            If value Is Nothing Then
                _ImageSize = Size.Empty
            Else
                _ImageSize = value.Size
            End If

            _Image = value
            Invalidate()
        End Set
    End Property
    ' Size value - returns the image size
    Protected ReadOnly Property ImageSize() As Size
        Get
            Return _ImageSize
        End Get
    End Property

#End Region
#Region " EventArgs "

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)

        ' Decides the location of the drawn ellipse. If mouse is over the correct coordinates, "IsOverClose" boolean will be triggered to draw the ellipse
        If e.X >= Width - 19 AndAlso e.X <= Width - 10 AndAlso e.Y > CloseCoordinates.Y AndAlso e.Y < CloseCoordinates.Y + 12 Then
            IsOverClose = True
        Else
            IsOverClose = False
        End If
        ' Updates the control
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        ' Disposes the control when the close button is clicked
        If _ShowCloseButton = True Then
            If IsOverClose Then
                Dispose()
            End If
        End If
    End Sub

#End Region

    Friend Function CreateRoundRect(ByVal r As Rectangle, ByVal curve As Integer) As GraphicsPath
        ' Draw a border radius
        Try
            CreateRoundPath = New GraphicsPath(FillMode.Winding)
            CreateRoundPath.AddArc(r.X, r.Y, curve, curve, 180.0F, 90.0F)
            CreateRoundPath.AddArc(r.Right - curve, r.Y, curve, curve, 270.0F, 90.0F)
            CreateRoundPath.AddArc(r.Right - curve, r.Bottom - curve, curve, curve, 0.0F, 90.0F)
            CreateRoundPath.AddArc(r.X, r.Bottom - curve, curve, curve, 90.0F, 90.0F)
            CreateRoundPath.CloseFigure()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & vbNewLine & "value can't be 0, must be higher", "Invalid Integer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' Return to the default border curve if the parameter is less than "1"
            _BorderCurve = 8
            Radius = 8
        End Try
        Return CreateRoundPath
    End Function

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                 ControlStyles.UserPaint Or _
                 ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.ResizeRedraw, True)

        Font = New Font("Tahoma", 9)
        Me.MinimumSize = New Size(100, 40)
        RoundCorners = False
        AllowClose = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        ' Declare Graphics to draw the control
        Dim GFX As Graphics = e.Graphics
        ' Declare Color to paint the control's Text, Background and Border
        Dim ForeColor, BackgroundColor, BorderColor As Color
        ' Determine the header Notification Type font
        Dim TypeFont As New Font(Font.FontFamily, Font.Size, FontStyle.Bold)
        ' Decalre a new rectangle to draw the control inside it
        Dim MainRectangle As New Rectangle(0, 0, Width - 1, Height - 1)
        ' Declare a GraphicsPath to create a border radius
        Dim CrvBorderPath As GraphicsPath = CreateRoundRect(MainRectangle, _BorderCurve)

        GFX.SmoothingMode = SmoothingMode.HighQuality
        GFX.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        GFX.Clear(Parent.BackColor)

        Select Case _NotificationType
            Case Type.Normal
                BackgroundColor = Color.FromArgb(90, 160, 160)
                BorderColor = Color.Transparent
                ForeColor = Color.White
            Case Type.Success
                BackgroundColor = Color.FromArgb(91, 195, 162)
                BorderColor = Color.FromArgb(91, 195, 162)
                ForeColor = Color.White
            Case Type.Warning
                BackgroundColor = Color.FromArgb(254, 209, 108)
                BorderColor = Color.FromArgb(254, 209, 108)
                ForeColor = Color.DimGray
            Case Type.Error
                BackgroundColor = Color.FromArgb(217, 103, 93)
                BorderColor = Color.FromArgb(217, 103, 93)
                ForeColor = Color.White
            Case Type.Custom
                BackgroundColor = setngz(0)
                BorderColor = setngz(1)
                ForeColor = setngz(2)
        End Select

        If _RoundedCorners = True Then
            GFX.FillPath(New SolidBrush(BackgroundColor), CrvBorderPath)
            GFX.DrawPath(New Pen(BorderColor), CrvBorderPath)
        Else
            GFX.FillRectangle(New SolidBrush(BackgroundColor), MainRectangle)
            GFX.DrawRectangle(New Pen(BorderColor), MainRectangle)
        End If

        Select Case _NotificationType
            Case Type.Normal
                NotificationText = "Notification"
            Case Type.Success
                NotificationText = "SUCCESS"
            Case Type.Warning
                NotificationText = "WARNING"
            Case Type.Error
                NotificationText = "ERROR"
            Case Type.Custom
                NotificationText = customTex
        End Select

        If IsNothing(Image) Then
            GFX.DrawString(NotificationText, TypeFont, New SolidBrush(ForeColor), New Point(10, 5))
            GFX.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(10, 21, Width - 17, Height - 5))
        Else
            GFX.DrawImage(_Image, 12, 4, 16, 16)
            GFX.DrawString(NotificationText, TypeFont, New SolidBrush(ForeColor), New Point(30, 5))
            GFX.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(10, 21, Width - 17, Height - 5))
        End If

        CloseCoordinates = New Point(Width - 26, 4)

        If _ShowCloseButton = True Then
            ' Draw the close button
            GFX.DrawString("r", New Font("Marlett", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(130, 130, 130)), New Rectangle(Width - 20, 10, Width, Height), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        End If

        CrvBorderPath.Dispose()
    End Sub
End Class

#End Region

Public Class NormalComboBox : Inherits ComboBox
#Region " Control Help - Properties & Flicker Control "
    Enum ColorSchemes
        Light
        Dark
    End Enum
    Private _ColorScheme As ColorSchemes
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            Invalidate()
        End Set
    End Property
    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            Invalidate()
        End Set
    End Property
    Private _StartIndex As Integer = 0
    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property
    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_AccentColor), e.Bounds)
            Else
                Select Case ColorScheme
                    Case ColorSchemes.Dark
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), e.Bounds)
                    Case ColorSchemes.Light
                        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
                End Select
            End If
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.White, e.Bounds)
                Case ColorSchemes.Light
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.Black, e.Bounds)
            End Select
        Catch
        End Try
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray())
    End Sub
#End Region
    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.White
        AccentColor = Color.DodgerBlue
        ColorScheme = ColorSchemes.Dark
        DropDownStyle = ComboBoxStyle.DropDownList
        Font = New Font("Segoe UI Semilight", 9.75F)
        StartIndex = 0
        DoubleBuffered = True
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Curve As Integer = 2
        G.SmoothingMode = SmoothingMode.HighQuality
        Select Case ColorScheme
            Case ColorSchemes.Dark
                G.Clear(Color.FromArgb(50, 50, 50))
                G.DrawLine(New Pen(Color.White, 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                G.DrawLine(New Pen(Color.White, 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                G.DrawLine(New Pen(Color.White), New Point(Width - 14, 15), New Point(Width - 14, 14))
            Case ColorSchemes.Light
                G.Clear(Color.White)
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100), 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100), 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100)), New Point(Width - 14, 15), New Point(Width - 14, 14))
        End Select
        G.DrawRectangle(New Pen(Color.FromArgb(100, 100, 100)), New Rectangle(0, 0, Width - 1, Height - 1))
        Try
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    G.DrawString(Text, Font, Brushes.White, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                Case ColorSchemes.Light
                    G.DrawString(Text, Font, Brushes.Black, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            End Select
        Catch
        End Try
        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class


Class VerticalTabControl
    'Credit ItalkTheme by HazelDev
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                 ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or _
                 ControlStyles.DoubleBuffer, True)

        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(44, 135)
        DrawMode = TabDrawMode.OwnerDrawFixed

        For Each Page As TabPage In Me.TabPages
            Page.BackColor = tabpagecolor
        Next
    End Sub
    Private tabpagecolor As Color = Color.FromArgb(50, 50, 50)
    Private linecolor As Color = Color.FromArgb(25, 26, 28)
    Private Activecolor As Color = Color.FromArgb(50, 50, 50)
    Private tabgcolor As Color = Color.FromArgb(45, 45, 45)
    Private hoverColor As Color = Color.DeepSkyBlue
    Private txtco As Color = Color.FromArgb(254, 255, 255)
    Private fant As Font = New Font("Segoe UI", 8)

    <Category("Colors")>
    Property PageColor As Color
        Get
            Return tabpagecolor
        End Get
        Set(ByVal value As Color)
            tabpagecolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property SelectedColor As Color
        Get
            Return Activecolor
        End Get
        Set(ByVal value As Color)
            Activecolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property MenuColor As Color
        Get
            Return tabgcolor
        End Get
        Set(ByVal value As Color)
            tabgcolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property VLineColor As Color
        Get
            Return linecolor
        End Get
        Set(ByVal value As Color)
            linecolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property TextColor As Color
        Get
            Return txtco
        End Get
        Set(ByVal value As Color)
            txtco = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Font")>
    Property TabFont As Font
        Get
            Return fant
        End Get
        Set(ByVal value As Font)
            fant = value
            Invalidate()
            Update()
        End Set
    End Property


    Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
        MyBase.OnControlAdded(e)
        If TypeOf e.Control Is TabPage Then
            For Each i As TabPage In Me.Controls
                i = New TabPage
            Next
            e.Control.BackColor = tabpagecolor
        End If
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()

        MyBase.DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        Appearance = TabAppearance.Normal
        Alignment = TabAlignment.Left
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        With G

            .Clear(tabpagecolor)
            .SmoothingMode = SmoothingMode.HighSpeed
            .CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            .CompositingMode = Drawing2D.CompositingMode.SourceOver

            ' Draw tab selector background
            .FillRectangle(New SolidBrush(tabgcolor), New Rectangle(-5, 0, ItemSize.Height + 5, Height))
            ' Draw vertical line at the end of the tab selector rectangle
            .DrawLine(New Pen(linecolor), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height)

            For TabIndex As Integer = 0 To TabCount - 1
                If TabIndex = SelectedIndex Then
                    Dim TabRect As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), New Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8))

                    ' Draw background of the selected tab
                    .FillRectangle(New SolidBrush(Activecolor), TabRect.X, TabRect.Y, TabRect.Width - 4, TabRect.Height + 3)
                    ' Draw a tab highlighter on the background of the selected tab
                    Dim TabHighlighter As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).X - 2, GetTabRect(TabIndex).Location.Y - IIf(TabIndex = 0, 1, 1)), New Size(4, GetTabRect(TabIndex).Height - 7))
                    .FillRectangle(New SolidBrush(hoverColor), TabHighlighter)
                    ' Draw tab text
                    .DrawString(TabPages(TabIndex).Text, fant, New SolidBrush(txtco), New Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), New StringFormat With {.Alignment = StringAlignment.Near})

                    If Me.ImageList IsNot Nothing Then
                        Dim Index As Integer = TabPages(TabIndex).ImageIndex
                        If Not Index = -1 Then
                            .DrawImage(Me.ImageList.Images.Item(TabPages(TabIndex).ImageIndex), TabRect.X + 9, TabRect.Y + 6, 24, 24)
                        End If
                    End If

                Else

                    Dim TabRect As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), New Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8))
                    ' Draw tab text
                    .DrawString(TabPages(TabIndex).Text, fant, New SolidBrush(txtco), New Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), New StringFormat With {.Alignment = StringAlignment.Near})

                    If Me.ImageList IsNot Nothing Then
                        Dim Index As Integer = TabPages(TabIndex).ImageIndex
                        If Not Index = -1 Then
                            .DrawImage(Me.ImageList.Images.Item(TabPages(TabIndex).ImageIndex), TabRect.X + 9, TabRect.Y + 6, 24, 24)
                        End If
                    End If

                End If
            Next
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality
            e.Graphics.DrawImage(B.Clone, 0, 0)
            G.Dispose()
            B.Dispose()
        End With
    End Sub
End Class

Class StylishTabControl : Inherits TabControl
    ' Credits:  Flat UI theme by Creator: iSynthesis (HF)
#Region " Variables"

    Private W, H As Integer

#End Region

#Region " Properties"

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ActiveColor As Color
        Get
            Return _ActiveColor
        End Get
        Set(ByVal value As Color)
            _ActiveColor = value
        End Set
    End Property

#End Region

#End Region

#Region " Colors"

    Private BGColor As Color = Color.FromArgb(45, 45, 45)
    Private _BaseColor As Color = Color.FromArgb(55, 55, 55)
    Private _ActiveColor As Color = Color.DeepSkyBlue

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(35, 35, 35)

        Font = New Font("Segoe UI", 9)
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(120, 40)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        With G
            .SmoothingMode = 3
            .PixelOffsetMode = 2
            .TextRenderingHint = 5
            .Clear(_BaseColor)

            Try : SelectedTab.BackColor = BGColor : Catch : End Try

            For i = 0 To TabCount - 1
                Dim Base As New Rectangle(New Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), New Size(GetTabRect(i).Width, GetTabRect(i).Height))
                Dim BaseSize As New Rectangle(Base.Location, New Size(Base.Width, Base.Height))

                If i = SelectedIndex Then
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                    '-- Gradian2
                    '.fill
                    .FillRectangle(New SolidBrush(_ActiveColor), BaseSize)

                    '-- ImageList
                    If ImageList IsNot Nothing Then
                        Try
                            If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                '-- Image
                                .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                                '-- Text
                                .DrawString("      " & TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                            Else
                                '-- Text
                                .DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    Else
                        '-- Text
                        .DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                    End If
                Else
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                    '-- ImageList
                    If ImageList IsNot Nothing Then
                        Try
                            If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                '-- Image
                                .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                                '-- Text
                                .DrawString("      " & TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            Else
                                '-- Text
                                .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    Else
                        '-- Text
                        .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End If
                End If
            Next
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FormControlBox
    ' Credits: The MonoFlatTheme by Creator: Vengfull @ OwnedCore.com
    Inherits Control

#Region " Enums "

    Enum ButtonHoverState
        Minimize
        Maximize
        Close
        None
    End Enum

#End Region
#Region " Variables "

    Private ButtonHState As ButtonHoverState = ButtonHoverState.None

#End Region
#Region " Properties "
    Private Barcolor As Color = Color.FromArgb(45, 45, 45)
    Private BGColor As Color = Color.FromArgb(54, 54, 54)
    Private FormSignColor As Color = Color.FromArgb(250, 250, 250)
    <Category("Colors")>
    Property ButtonsColor As Color
        Get
            Return Barcolor
        End Get
        Set(ByVal value As Color)
            Barcolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property FormSignColors As Color
        Get
            Return FormSignColor
        End Get
        Set(ByVal value As Color)
            FormSignColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property BacColor As Color
        Get
            Return BGColor
        End Get
        Set(ByVal value As Color)
            BGColor = value
            Invalidate()
            Update()
        End Set
    End Property
    Private _EnableMaximize As Boolean = True
    Property AllowMaximize() As Boolean
        Get
            Return _EnableMaximize
        End Get
        Set(ByVal value As Boolean)
            _EnableMaximize = value
            Invalidate()
        End Set
    End Property

    Private _EnableMinimize As Boolean = True
    Property AllowMinimize() As Boolean
        Get
            Return _EnableMinimize
        End Get
        Set(ByVal value As Boolean)
            _EnableMinimize = value
            Invalidate()
        End Set
    End Property

    Private _EnableHoverHighlight As Boolean = False
    Property EnableHover() As Boolean
        Get
            Return _EnableHoverHighlight
        End Get
        Set(ByVal value As Boolean)
            _EnableHoverHighlight = value
            Invalidate()
            Update()
        End Set
    End Property

#End Region
#Region " EventArgs "

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(100, 25)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim X As Integer = e.Location.X
        Dim Y As Integer = e.Location.Y
        If Y > 0 AndAlso Y < (Height - 2) Then
            If X > 0 AndAlso X < 34 Then
                ButtonHState = ButtonHoverState.Minimize
            ElseIf X > 33 AndAlso X < 65 Then
                ButtonHState = ButtonHoverState.Maximize
            ElseIf X > 64 AndAlso X < Width Then
                ButtonHState = ButtonHoverState.Close
            Else
                ButtonHState = ButtonHoverState.None
            End If
        Else
            ButtonHState = ButtonHoverState.None
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        Select Case ButtonHState
            Case ButtonHoverState.Close
                Parent.FindForm().Close()
                Me.Hide()
            Case ButtonHoverState.Minimize
                If _EnableMinimize = True Then
                    Parent.FindForm().WindowState = FormWindowState.Minimized
                End If
            Case ButtonHoverState.Maximize
                If _EnableMaximize = True Then
                    If Parent.FindForm().WindowState = FormWindowState.Normal Then
                        Parent.FindForm().WindowState = FormWindowState.Maximized
                    Else
                        Parent.FindForm().WindowState = FormWindowState.Normal
                    End If
                End If
        End Select
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        ButtonHState = ButtonHoverState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Focus()
    End Sub

#End Region

    Sub New()
        MyBase.New()
        DoubleBuffered = True
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Try
            Location = New Point(Parent.Width - 112, 15)
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics
        G.Clear(Barcolor)

        If _EnableHoverHighlight = True Then
            Select Case ButtonHState
                Case ButtonHoverState.None
                    G.Clear(Barcolor)
                Case ButtonHoverState.Minimize
                    If _EnableMinimize = True Then
                        G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(3, 0, 30, Height))
                    End If
                Case ButtonHoverState.Maximize
                    If _EnableMaximize = True Then
                        G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(35, 0, 30, Height))
                    End If
                Case ButtonHoverState.Close
                    G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(66, 0, 35, Height))
            End Select
        End If

        'Close
        G.DrawString("r", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(Width - 16, 8), New StringFormat With {.Alignment = StringAlignment.Center})

        'Maximize
        Select Case Parent.FindForm().WindowState
            Case FormWindowState.Maximized
                If _EnableMaximize = True Then
                    G.DrawString("2", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                Else
                    G.DrawString("2", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                End If
            Case FormWindowState.Normal
                If _EnableMaximize = True Then
                    G.DrawString("1", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                Else
                    G.DrawString("1", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                End If
        End Select

        'Minimize
        If _EnableMinimize = True Then
            G.DrawString("0", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(20, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        Else
            G.DrawString("0", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(20, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        End If
    End Sub
End Class

Public Class TrackBar
    ' Credits: LoginTheme by Xerts (HF)
    Inherits UserControl
    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#Region "Declaration"
    Private _Maximum As Integer = 100
    Private _Value As Integer = 0
    Private CaptureMovement As Boolean = False
    Private Bar As Rectangle = New Rectangle(0, 10, Width - 21, Height - 21)
    Private Track As Size = New Size(28, 18)
    Private _TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _BarBaseColor As Color = Color.FromArgb(40, 40, 40)
    Private _StripColor As Color = Color.FromArgb(50, 50, 50)
    Private _StripAmountColor As Color = Color.DeepSkyBlue
#End Region

#Region "Properties"

    <Category("Colors")> _
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TrackColor As Color
        Get
            Return _BarBaseColor
        End Get
        Set(ByVal value As Color)
            _BarBaseColor = value
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property BGColor As Color
        Get
            Return _StripColor
        End Get
        Set(ByVal value As Color)
            _StripColor = value
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property AmountColor As Color
        Get
            Return _StripAmountColor
        End Get
        Set(ByVal value As Color)
            _StripAmountColor = value
        End Set
    End Property

    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _Maximum = value
            If value < _Value Then _Value = value
            Invalidate()
        End Set
    End Property

    Event ValueChanged()

    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < 0
                    _Value = 0
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select
            Invalidate()
            RaiseEvent ValueChanged()
        End Set
    End Property

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        BackColor = Color.Transparent
        MyBase.OnHandleCreated(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim MovementPoint As New Rectangle(New Point(e.Location.X, e.Location.Y), New Size(1, 1))
        Dim Bar As New Rectangle(10, 10, Width - 21, Height - 21)
        If New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2 - 1), 0), New Size(Track.Width, Height)).IntersectsWith(MovementPoint) Then
            CaptureMovement = True
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureMovement = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If CaptureMovement Then
            Dim MovementPoint As New Point(e.X, e.Y)
            Dim Bar As New Rectangle(10, 10, Width - 21, Height - 21)
            Value = CInt(Maximum * ((MovementPoint.X - Bar.X) / Bar.Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e) : CaptureMovement = False
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                    ControlStyles.UserPaint Or ControlStyles.Selectable Or _
                    ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            Bar = New Rectangle(13, 11, Width - 27, Height - 21)

            .SmoothingMode = SmoothingMode.AntiAlias
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .FillRectangle(New SolidBrush(_StripColor), New Rectangle(3, CInt((Height / 2) - 4), Width - 5, 8))
            .DrawRectangle(New Pen(_BorderColor, 2), New Rectangle(4, CInt((Height / 2) - 4), Width - 5, 8))
            .FillRectangle(New SolidBrush(_StripAmountColor), New Rectangle(4, CInt((Height / 2) - 4), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8))
            .FillRectangle(New SolidBrush(_BarBaseColor), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width, Track.Height)
            .DrawRectangle(New Pen(_BorderColor, 2), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width, Track.Height)
            .DrawString(_Value, New Font("Segoe UI", 6.5, FontStyle.Regular), New SolidBrush(_TextColor), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width - 1, Track.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region
End Class

Public Class TabButton
    ' Credits: LoginTheme by Xerts (HF)
    Inherits Control
    Public Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Public Function RoundRect(ByVal x!, ByVal y!, ByVal w!, ByVal h!, Optional ByVal r! = 0.3, Optional ByVal TL As Boolean = True, Optional ByVal TR As Boolean = True, Optional ByVal BR As Boolean = True, Optional ByVal BL As Boolean = True) As GraphicsPath
        Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
        RoundRect = New GraphicsPath

        With RoundRect
            If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
            If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
            If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
            If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

            .CloseFigure()
        End With
    End Function
    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum
#Region "Declarations"
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _Font As New Font("Segoe UI", 9)
    Private _ProgressColor As Color = Color.FromArgb(0, 191, 255)
    Private _BorderColor As Color = Color.FromArgb(25, 25, 25)
    Private _FontColor As Color = Color.FromArgb(255, 255, 255)
    Private _MainColor As Color = Color.FromArgb(42, 42, 42)
    Private _HoverColor As Color = Color.FromArgb(60, 52, 60)
    Private _PressedColor As Color = Color.FromArgb(47, 47, 47)
    Private State As New MouseState
    Private texta As String = "TabButton"
#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Properties"

    <Category("Colors")>
    Public Property LoadingColor As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            _ProgressColor = value
        End Set
    End Property

    <Category("Control")>
    Public Property Caption As String
        Get
            Return texta
        End Get
        Set(ByVal value As String)
            texta = value
            Invalidate()
            Update()

        End Set
    End Property

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Invalidate()
            Update()

        End Set
    End Property

    <Category("Colors")>
    Public Property FontColor As Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Color)
            _FontColor = value
            Invalidate()
            Update()

        End Set
    End Property

    <Category("Colors")>
    Public Property BGColor As Color
        Get
            Return _MainColor
        End Get
        Set(ByVal value As Color)
            _MainColor = value
            Invalidate()
            Update()

        End Set
    End Property

    <Category("Colors")>
    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(ByVal value As Color)
            _HoverColor = value
            Invalidate()
            Update()

        End Set
    End Property

    <Category("Colors")>
    Public Property TapColor As Color
        Get
            Return _PressedColor
        End Get
        Set(ByVal value As Color)
            _PressedColor = value
            Invalidate()
            Update()

        End Set
    End Property

    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0

                Case Else
                    Return _Value

            End Select
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
              ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
              ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(75, 30)
        BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP, GP1 As New GraphicsPath
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Select Case State
                Case MouseState.None
                    .FillRectangle(New SolidBrush(_MainColor), New Rectangle(0, 0, Width, Height - 4))
                    .DrawRectangle(New Pen(_BorderColor, 2), New Rectangle(0, 0, Width, Height - 4))
                    .DrawString(texta, _Font, Brushes.White, New Point(Width / 2, Height / 2 - 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Over
                    .FillRectangle(New SolidBrush(_HoverColor), New Rectangle(0, 0, Width, Height - 4))
                    .DrawRectangle(New Pen(_BorderColor, 1), New Rectangle(1, 1, Width - 2, Height - 5))
                    .DrawString(texta, _Font, Brushes.White, New Point(Width / 2, Height / 2 - 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Down
                    .FillRectangle(New SolidBrush(_PressedColor), New Rectangle(0, 0, Width, Height - 4))
                    .DrawRectangle(New Pen(_BorderColor, 1), New Rectangle(1, 1, Width - 2, Height - 5))
                    .DrawString(texta, _Font, Brushes.White, New Point(Width / 2, Height / 2 - 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
            Select Case _Value
                Case 0
                Case _Maximum
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, Height - 4, Width, Height - 4))
                    .DrawRectangle(New Pen(_BorderColor, 2), New Rectangle(0, 0, Width, Height))
                Case Else
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, Height - 4, Width / _Maximum * _Value, Height - 4))
                    .DrawRectangle(New Pen(_BorderColor, 2), New Rectangle(0, 0, Width, Height))
            End Select
        End With
        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region
End Class


Public Class CircularProgress
    Inherits Control
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _BaseColor As Color = Color.FromArgb(42, 42, 42)
    Private _ProgressColor As Color = Color.FromArgb(0, 160, 199)
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _StartingAngle As Integer = 168
    Private _RotationAngle As Integer = 360
    Private ReadOnly _Font As Font = New Font("Segoe UI", 20)
    Private txtcolor As Color = Color.Black



    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                Case Else
                    Return _Value
            End Select
        End Get

        Set(ByVal V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("Colors")>
    Public Property ProgressColor As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            _ProgressColor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("Colors")>
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("Colors")>
    Public Property TextColor As Color
        Get
            Return txtcolor
        End Get
        Set(ByVal value As Color)
            txtcolor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("ControlAngel")>
    Public Property StartAngle As Integer
        Get
            Return _StartingAngle
        End Get
        Set(ByVal value As Integer)
            _StartingAngle = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("ControlAngel")>
    Public Property RotationAngle As Integer
        Get
            Return _RotationAngle
        End Get
        Set(ByVal value As Integer)
            _RotationAngle = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(78, 78)
        BackColor = Color.Transparent
    End Sub

    Private Sub CustomRadialProgress_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(Color.Transparent)
            Select Case _Value
                Case 0
                    .DrawArc(New Pen(New SolidBrush(_BorderColor), 1 + 5), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawString(_Value, _Font, ToBrush(txtcolor), New Point(Width / 2, Height / 2 - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case _Maximum
                    .DrawArc(New Pen(New SolidBrush(_BorderColor), 1 + 5), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawArc(New Pen(New SolidBrush(_ProgressColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawString(_Value, _Font, ToBrush(txtcolor), New Point(Width / 2, Height / 2 - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case Else
                    .DrawArc(New Pen(New SolidBrush(_BorderColor), 1 + 5), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawArc(New Pen(New SolidBrush(_ProgressColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, CInt((_RotationAngle / _Maximum) * _Value))
                    .DrawString(_Value, _Font, ToBrush(txtcolor), New Point(Width / 2, Height / 2 - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
        End With
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Public Class LogInSeperator
    Inherits Control

#Region "Declarations"
    Private _SeperatorColor As Color = Color.FromArgb(35, 35, 35)
    Private _Alignment As Style = Style.Horizontal
    Private _Thickness As Single = 1
#End Region

#Region "Properties"

    Enum Style
        Horizontal
        Verticle
    End Enum

    <Category("Control")>
    Public Property Thickness As Single
        Get
            Return _Thickness
        End Get
        Set(ByVal value As Single)
            _Thickness = value
        End Set
    End Property

    <Category("Control")>
    Public Property Alignment As Style
        Get
            Return _Alignment
        End Get
        Set(ByVal value As Style)
            _Alignment = value
        End Set
    End Property

    <Category("Colors")>
    Public Property SeperatorColor As Color
        Get
            Return _SeperatorColor
        End Get
        Set(ByVal value As Color)
            _SeperatorColor = value
        End Set
    End Property

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Size = New Size(20, 20)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim Base As New Rectangle(0, 0, Width - 1, Height - 1)
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            Select Case _Alignment
                Case Style.Horizontal
                    .DrawLine(New Pen(_SeperatorColor, _Thickness), New Point(0, Height / 2), New Point(Width, Height / 2))
                Case Style.Verticle
                    .DrawLine(New Pen(_SeperatorColor, _Thickness), New Point(Width / 2, 0), New Point(Width / 2, Height))
            End Select
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
#End Region

End Class


Public Class LogInColorTable
    Inherits ProfessionalColorTable

#Region "Declarations"

    Private _BackColor As Color = Color.FromArgb(42, 42, 42)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _SelectedColor As Color = Color.FromArgb(47, 47, 47)

#End Region

#Region "Properties"

    <Category("Colors")>
    Public Property SelectedColor As Color
        Get
            Return _SelectedColor
        End Get
        Set(ByVal value As Color)
            _SelectedColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BackColor As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            _BackColor = value
        End Set
    End Property

    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckPressedBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckSelectedBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return _BorderColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return _SelectedColor
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return _BorderColor
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

#End Region

End Class

Public Class StylishProgressBar
    Inherits Control
    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

    Private _ProgressColor As Color = Color.FromArgb(80, 80, 80)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _BaseColor As Color = Color.FromArgb(42, 42, 42)
    Private _FontColor As Color = Color.FromArgb(50, 50, 50)
    Private _SecondColor As Color = Color.FromArgb(64, 64, 64)
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _TwoColor As Boolean = True


#Region "Properties"

    <Category("Colors")>
    Public Property SecColor As Color
        Get
            Return _SecondColor
        End Get
        Set(ByVal value As Color)
            _SecondColor = value
            Me.Update()
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Stylish As Boolean
        Get
            Return _TwoColor
        End Get
        Set(ByVal value As Boolean)
            _TwoColor = value
            Me.Update()
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property Color As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            _ProgressColor = value
            Me.Update()
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property BGColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
            Me.Update()
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Me.Update()
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property FontColor As Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Color)
            _FontColor = value
            Me.Update()
            Invalidate()
        End Set
    End Property

#End Region

#Region "Events"

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Height = 25
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Height = 25
    End Sub

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
    End Sub

    Private Sub StylishProgressBar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim B = New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Dim ProgVal As Integer = CInt(_Value / _Maximum * Width)
            Select Case Value
                Case 0
                    .FillRectangle(New SolidBrush(_BaseColor), Base)
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 0, ProgVal - 1, Height))
                    .DrawRectangle(New Pen(_BorderColor, 3), Base)
                Case _Maximum
                    .FillRectangle(New SolidBrush(_BaseColor), Base)
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 0, ProgVal - 1, Height))
                    If _TwoColor Then
                        G.SetClip(New Rectangle(0, -10, Width * _Value / _Maximum - 1, Height - 5))
                        For i = 0 To (Width - 1) * _Maximum / _Value Step 25
                            G.DrawLine(New Pen(New SolidBrush(_SecondColor), 7), New Point(i, 0), New Point(i - 15, Height))
                        Next
                        G.ResetClip()
                    Else
                    End If
                    .DrawRectangle(New Pen(_BorderColor, 3), Base)
                Case Else
                    .FillRectangle(New SolidBrush(_BaseColor), Base)
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 0, ProgVal - 1, Height))
                    If _TwoColor Then
                        .SetClip(New Rectangle(0, 0, Width * _Value / _Maximum - 1, Height - 1))
                        For i = 0 To (Width - 1) * _Maximum / _Value Step 25
                            .DrawLine(New Pen(New SolidBrush(_SecondColor), 7), New Point(i, 0), New Point(i - 10, Height))
                        Next
                        .ResetClip()
                    Else
                    End If
                    .DrawRectangle(New Pen(_BorderColor, 3), Base)
            End Select
        End With
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()

    End Sub
End Class

<DefaultEvent("Scroll")>
Public Class LogInVerticalScrollBar
    Inherits Control

#Region "Declarations"

    Private ThumbMovement As Integer
    Private TSA As Rectangle
    Private BSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle
    Private ShowThumb As Boolean
    Private ThumbPressed As Boolean
    Private _ThumbSize As Integer = 45
    Public _Minimum As Integer = 0
    Public _Maximum As Integer = 100
    Public _Value As Integer = 0
    Public _SmallChange As Integer = 1
    Private _ButtonSize As Integer = 16
    Public _LargeChange As Integer = 10
    Private _ThumbBorder As Color = Color.FromArgb(35, 35, 35)
    Private _LineColor As Color = Color.FromArgb(60, 60, 60)
    Private _ArrowColor As Color = Color.FromArgb(37, 37, 37)
    Private _BaseColor As Color = Color.FromArgb(47, 47, 47)
    Private _ThumbColor As Color = Color.FromArgb(60, 60, 60)
    Private _ThumbSecondBorder As Color = Color.FromArgb(65, 65, 65)
    Private _FirstBorder As Color = Color.FromArgb(55, 55, 55)
    Private _SecondBorder As Color = Color.FromArgb(35, 35, 35)

#End Region

#Region "Properties & Events"

    <Category("Colors")> _
    Public Property ThumbBorder As Color
        Get
            Return _ThumbBorder
        End Get
        Set(ByVal value As Color)
            _ThumbBorder = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property LineColor As Color
        Get
            Return _LineColor
        End Get
        Set(ByVal value As Color)
            _LineColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ArrowColor As Color
        Get
            Return _ArrowColor
        End Get
        Set(ByVal value As Color)
            _ArrowColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ThumbColor As Color
        Get
            Return _ThumbColor
        End Get
        Set(ByVal value As Color)
            _ThumbColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ThumbSecondBorder As Color
        Get
            Return _ThumbSecondBorder
        End Get
        Set(ByVal value As Color)
            _ThumbSecondBorder = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property FirstBorder As Color
        Get
            Return _FirstBorder
        End Get
        Set(ByVal value As Color)
            _FirstBorder = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property SecondBorder As Color
        Get
            Return _SecondBorder
        End Get
        Set(ByVal value As Color)
            _SecondBorder = value
        End Set
    End Property

    Event Scroll(ByVal sender As Object)

    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            InvalidateLayout()
        End Set
    End Property

    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
        End Set
    End Property

    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < _Minimum
                    _Value = _Minimum
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select
            InvalidatePosition()
            RaiseEvent Scroll(Me)
        End Set
    End Property

    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Is >
                    _SmallChange = value
            End Select
        End Set
    End Property

    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Else
                    _LargeChange = value
            End Select
        End Set
    End Property

    Public Property ButtonSize As Integer
        Get
            Return _ButtonSize
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 16
                    _ButtonSize = 16
                Case Else
                    _ButtonSize = value
            End Select
        End Set
    End Property

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        TSA = New Rectangle(0, 1, Width, 0)
        Shaft = New Rectangle(0, TSA.Bottom - 1, Width, Height - 3)
        ShowThumb = ((_Maximum - _Minimum))
        If ShowThumb Then
            Thumb = New Rectangle(1, 0, Width - 3, _ThumbSize)
        End If
        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.Y = CInt(((_Value - _Minimum) / (_Maximum - _Minimum)) * (Shaft.Height - _ThumbSize) + 1)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If TSA.Contains(e.Location) Then
                ThumbMovement = _Value - _SmallChange
            ElseIf BSA.Contains(e.Location) Then
                ThumbMovement = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbPressed = True
                    Return
                Else
                    If e.Y < Thumb.Y Then
                        ThumbMovement = _Value - _LargeChange
                    Else
                        ThumbMovement = _Value + _LargeChange
                    End If
                End If
            End If
            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbPressed AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.Y - TSA.Height - (_ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Height - _ThumbSize
            ThumbMovement = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum
            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbPressed = False
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                            ControlStyles.UserPaint Or ControlStyles.Selectable Or _
                            ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(24, 50)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Height, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(_BaseColor)
            Dim P() As Point = {New Point(Width / 2, 5), New Point(Width / 4, 13), New Point(Width / 2 - 2, 13), New Point(Width / 2 - 2, Height - 13), _
                                New Point(Width / 4, Height - 13), New Point(Width / 2, Height - 5), New Point(Width - Width / 4 - 1, Height - 13), New Point(Width / 2 + 2, Height - 13), _
                                New Point(Width / 2 + 2, 13), New Point(Width - Width / 4 - 1, 13)}
            .FillRectangle(New SolidBrush(_ThumbColor), Thumb)
            .DrawRectangle(New Pen(_ThumbBorder), Thumb)
            .DrawLine(New Pen(_LineColor, 2), New Point(CInt(Thumb.Width / 2 + 1), Thumb.Y + 4), New Point(CInt(Thumb.Width / 2 + 1), Thumb.Bottom - 4))
            .DrawRectangle(New Pen(_FirstBorder), 0, 0, Width - 1, Height - 1)
            .DrawRectangle(New Pen(_SecondBorder), 1, 1, Width - 3, Height - 3)
        End With
        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class

<DefaultEvent("Scroll")> _
Public Class LogInHorizontalScrollBar
    Inherits Control

#Region "Declarations"

    Private ThumbMovement As Integer
    Private LSA As Rectangle
    Private RSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle
    Private ShowThumb As Boolean
    Private ThumbPressed As Boolean
    Private _ThumbSize As Integer = 45
    Public _Minimum As Integer = 0
    Public _Maximum As Integer = 100
    Public _Value As Integer = 0
    Public _SmallChange As Integer = 1
    Private _ButtonSize As Integer = 16
    Public _LargeChange As Integer = 10
    Private _ThumbBorder As Color = Color.FromArgb(35, 35, 35)
    Private _LineColor As Color = Color.FromArgb(23, 119, 151)
    Private _ArrowColor As Color = Color.FromArgb(37, 37, 37)
    Private _BaseColor As Color = Color.FromArgb(47, 47, 47)
    Private _ThumbColor As Color = Color.FromArgb(55, 55, 55)
    Private _ThumbSecondBorder As Color = Color.FromArgb(65, 65, 65)
    Private _FirstBorder As Color = Color.FromArgb(55, 55, 55)
    Private _SecondBorder As Color = Color.FromArgb(35, 35, 35)
    Private ThumbDown As Boolean = False
#End Region

#Region "Properties & Events"

    <Category("Colors")> _
    Public Property ThumbBorder As Color
        Get
            Return _ThumbBorder
        End Get
        Set(ByVal value As Color)
            _ThumbBorder = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property LineColor As Color
        Get
            Return _LineColor
        End Get
        Set(ByVal value As Color)
            _LineColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ArrowColor As Color
        Get
            Return _ArrowColor
        End Get
        Set(ByVal value As Color)
            _ArrowColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ThumbColor As Color
        Get
            Return _ThumbColor
        End Get
        Set(ByVal value As Color)
            _ThumbColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ThumbSecondBorder As Color
        Get
            Return _ThumbSecondBorder
        End Get
        Set(ByVal value As Color)
            _ThumbSecondBorder = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property FirstBorder As Color
        Get
            Return _FirstBorder
        End Get
        Set(ByVal value As Color)
            _FirstBorder = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property SecondBorder As Color
        Get
            Return _SecondBorder
        End Get
        Set(ByVal value As Color)
            _SecondBorder = value
        End Set
    End Property

    Event Scroll(ByVal sender As Object)

    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            InvalidateLayout()
        End Set
    End Property

    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
        End Set
    End Property

    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < _Minimum
                    _Value = _Minimum
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select
            InvalidatePosition()
            RaiseEvent Scroll(Me)
        End Set
    End Property

    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Is >
                    _SmallChange = value
            End Select
        End Set
    End Property

    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Else
                    _LargeChange = value
            End Select
        End Set
    End Property

    Public Property ButtonSize As Integer
        Get
            Return _ButtonSize
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 16
                    _ButtonSize = 16
                Case Else
                    _ButtonSize = value
            End Select
        End Set
    End Property

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        LSA = New Rectangle(0, 1, 0, Height)
        Shaft = New Rectangle(LSA.Right + 1, 0, Width - 3, Height)
        ShowThumb = ((_Maximum - _Minimum))
        Thumb = New Rectangle(0, 1, _ThumbSize, Height - 3)
        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.X = CInt(((_Value - _Minimum) / (_Maximum - _Minimum)) * (Shaft.Width - _ThumbSize) + 1)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If LSA.Contains(e.Location) Then
                ThumbMovement = _Value - _SmallChange
            ElseIf RSA.Contains(e.Location) Then
                ThumbMovement = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    Return
                Else
                    If e.X < Thumb.X Then
                        ThumbMovement = _Value - _LargeChange
                    Else
                        ThumbMovement = _Value + _LargeChange
                    End If
                End If
            End If
            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.X - LSA.Width - (_ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Width - _ThumbSize

            ThumbMovement = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                           ControlStyles.UserPaint Or ControlStyles.Selectable Or _
                           ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Height = 18
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Height, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(_BaseColor)
            Dim P() As Point = {New Point(Width / 2, 5), New Point(Width / 4, 13), New Point(Width / 2 - 2, 13), New Point(Width / 2 - 2, Height - 13), _
                                New Point(Width / 4, Height - 13), New Point(Width / 2, Height - 5), New Point(Width - Width / 4 - 1, Height - 13), New Point(Width / 2 + 2, Height - 13), _
                                New Point(Width / 2 + 2, 13), New Point(Width - Width / 4 - 1, 13)}
            .FillRectangle(New SolidBrush(_ThumbColor), Thumb)
            .DrawRectangle(New Pen(_ThumbBorder), Thumb)
            .DrawLine(New Pen(_LineColor, 2), New Point(CInt(Thumb.Width / 2 + 1), Thumb.Y + 4), New Point(CInt(Thumb.Width / 2 + 1), Thumb.Bottom - 4))
            .DrawRectangle(New Pen(_FirstBorder), 0, 0, Width - 1, Height - 1)
            .DrawRectangle(New Pen(_SecondBorder), 1, 1, Width - 3, Height - 3)
        End With
        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class

Public Class LogInTitledListBoxWBuiltInScrollBar
    Inherits Control

#Region "Declarations"

    Private _Items As New List(Of LogInListBoxItem)
    Private ReadOnly _SelectedItems As New List(Of LogInListBoxItem)
    Private _MultiSelect As Boolean = True
    Private ItemHeight As Integer = 24
    Private ReadOnly VerticalScrollbar As LogInVerticalScrollBar
    Private _BaseColor As Color = Color.FromArgb(55, 55, 55)
    Private _SelectedItemColor As Color = Color.FromArgb(50, 50, 50)
    Private _NonSelectedItemColor As Color = Color.FromArgb(47, 47, 47)
    Private _TitleAreaColor As Color = Color.FromArgb(42, 42, 42)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _TextColor As Color = Color.FromArgb(255, 255, 255)

#End Region

#Region "Properties & Events"

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property SelectedItemColor As Color
        Get
            Return _SelectedItemColor
        End Get
        Set(ByVal value As Color)
            _SelectedItemColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property NonSelectedItemColor As Color
        Get
            Return _NonSelectedItemColor
        End Get
        Set(ByVal value As Color)
            _NonSelectedItemColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TitleAreaColor As Color
        Get
            Return _TitleAreaColor
        End Get
        Set(ByVal value As Color)
            _TitleAreaColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    Private Sub HandleScroll(ByVal sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        VerticalScrollbar.Maximum = (_Items.Count * ItemHeight)
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VerticalScrollbar.Location = New Point(Width - VerticalScrollbar.Width - 2, 25)
        VerticalScrollbar.Size = New Size(10, Height - 27)
        Invalidate()
    End Sub

    Public Class LogInListBoxItem
        Property Text As String
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    <System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)> _
    Public Property Items() As LogInListBoxItem()
        Get
            Return _Items.ToArray()
        End Get
        Set(ByVal value As LogInListBoxItem())
            _Items = New List(Of LogInListBoxItem)(value)
            InvalidateScroll()
        End Set
    End Property

    Public ReadOnly Property SelectedItems() As LogInListBoxItem()
        Get
            Return _SelectedItems.ToArray()
        End Get
    End Property

    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value

            If _SelectedItems.Count > 1 Then
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1)
            End If

            Invalidate()
        End Set
    End Property

    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            ItemHeight = CInt(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6
            If VerticalScrollbar IsNot Nothing Then
                VerticalScrollbar.SmallChange = ItemHeight
                VerticalScrollbar.LargeChange = ItemHeight
            End If
            MyBase.Font = value
            InvalidateLayout()
        End Set
    End Property

    Public Sub AddItem(ByVal Items As String)
        Dim Item As New LogInListBoxItem()
        Item.Text = Items
        _Items.Add(Item)
        InvalidateScroll()
    End Sub

    Public Sub AddItems(ByVal Items() As String)
        For Each I In Items
            Dim Item As New LogInListBoxItem()
            Item.Text = I
            _Items.Add(Item)
        Next
        InvalidateScroll()
    End Sub

    Public Sub RemoveItemAt(ByVal index As Integer)
        _Items.RemoveAt(index)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItem(ByVal item As LogInListBoxItem)
        _Items.Remove(item)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItems(ByVal items As LogInListBoxItem())
        For Each I As LogInListBoxItem In items
            _Items.Remove(I)
        Next
        InvalidateScroll()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub Vertical_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Focus()

        If e.Button = MouseButtons.Left Then
            Dim Offset As Integer = CInt(VerticalScrollbar.Value * (VerticalScrollbar.Maximum - (Height - (ItemHeight * 2))))
            Dim Index As Integer = ((e.Y + Offset - ItemHeight) \ ItemHeight)

            If Index > _Items.Count - 1 Then Index = -1

            If Not Index = -1 Then

                If ModifierKeys = Keys.Control AndAlso _MultiSelect Then
                    If _SelectedItems.Contains(_Items(Index)) Then
                        _SelectedItems.Remove(_Items(Index))
                    Else
                        _SelectedItems.Add(_Items(Index))
                    End If
                Else
                    _SelectedItems.Clear()
                    _SelectedItems.Add(_Items(Index))
                End If
            End If

            Invalidate()
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 120) * (ItemHeight \ 2))
        Dim Value As Integer = Math.Max(Math.Min(VerticalScrollbar.Value + Move, VerticalScrollbar.Maximum), VerticalScrollbar.Minimum)
        VerticalScrollbar.Value = Value
        MyBase.OnMouseWheel(e)
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                    ControlStyles.UserPaint Or ControlStyles.Selectable Or _
                    ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        VerticalScrollbar = New LogInVerticalScrollBar
        VerticalScrollbar.SmallChange = ItemHeight
        VerticalScrollbar.LargeChange = ItemHeight
        AddHandler VerticalScrollbar.Scroll, AddressOf HandleScroll
        AddHandler VerticalScrollbar.MouseDown, AddressOf Vertical_MouseDown
        Controls.Add(VerticalScrollbar)
        InvalidateLayout()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Width)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(_BaseColor)
            Dim AllItems As LogInListBoxItem
            Dim Offset As Integer = CInt(VerticalScrollbar.Value * (VerticalScrollbar.Maximum - (Height - (ItemHeight * 2))))
            Dim StartIndex As Integer
            If Offset = 0 Then StartIndex = 0 Else StartIndex = (Offset \ ItemHeight)
            Dim EndIndex As Integer = Math.Min(StartIndex + (Height \ ItemHeight), _Items.Count - 1)
            For I As Integer = StartIndex To EndIndex
                AllItems = Items(I)
                Dim Y As Integer = (ItemHeight + (I * ItemHeight) + 1 - Offset) + CInt((ItemHeight / 2) - 8)
                If _SelectedItems.Contains(AllItems) Then
                    .FillRectangle(New SolidBrush(_SelectedItemColor), New Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1))
                Else
                    .FillRectangle(New SolidBrush(_NonSelectedItemColor), New Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1))
                End If
                .DrawLine(New Pen(_BorderColor), 0, (ItemHeight + (I * ItemHeight) + 1 - Offset) + ItemHeight - 1, Width - 18, (ItemHeight + (I * ItemHeight) + 1 - Offset) + ItemHeight - 1)
                .DrawString(AllItems.Text, New Font("Segoe UI", 8), New SolidBrush(_TextColor), 9, Y)
                .ResetClip()
            Next
            .FillRectangle(New SolidBrush(_TitleAreaColor), New Rectangle(0, 0, Width, ItemHeight))
            .DrawRectangle(New Pen(Color.FromArgb(35, 35, 35)), 1, 1, Width - 3, ItemHeight - 2)
            .DrawString(Text, New Font("Segoe UI", 10, FontStyle.Bold), New SolidBrush(_TextColor), New Rectangle(0, 0, Width, ItemHeight + 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            .DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), 1, 0, Width - 2, Height - 1)
            .DrawLine(New Pen(_BorderColor), 0, ItemHeight, Width, ItemHeight)
            .DrawLine(New Pen(_BorderColor, 2), VerticalScrollbar.Location.X - 1, ItemHeight, VerticalScrollbar.Location.X - 1, Height)
        End With
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class

Public Class LogInListBoxWBuiltInScrollBar
    Inherits Control

#Region "Declarations"

    Private _Items As New List(Of LogInListBoxItem)
    Private ReadOnly _SelectedItems As New List(Of LogInListBoxItem)
    Private _MultiSelect As Boolean = True
    Private ItemHeight As Integer = 24
    Private ReadOnly VerticalScrollbar As LogInVerticalScrollBar
    Private _BaseColor As Color = Color.FromArgb(55, 55, 55)
    Private _SelectedItemColor As Color = Color.FromArgb(50, 50, 50)
    Private _NonSelectedItemColor As Color = Color.FromArgb(47, 47, 47)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _SelectedHeight As Integer = 1
#End Region

#Region "Properties"

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
        End Set
    End Property

    <Category("Control")> _
    Public Property SelectedHeight As Integer
        Get
            Return _SelectedHeight
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                _SelectedHeight = Height
            Else
                _SelectedHeight = value
            End If
            InvalidateScroll()
        End Set
    End Property

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property SelectedItemColor As Color
        Get
            Return _SelectedItemColor
        End Get
        Set(ByVal value As Color)
            _SelectedItemColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property NonSelectedItemColor As Color
        Get
            Return _NonSelectedItemColor
        End Get
        Set(ByVal value As Color)
            _NonSelectedItemColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property


    Private Sub HandleScroll(ByVal sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        Debug.Print(CStr(Height))
        If CInt(Math.Round(((_Items.Count) * ItemHeight) / _SelectedHeight)) < CDbl((((_Items.Count) * ItemHeight) / _SelectedHeight)) Then
            VerticalScrollbar._Maximum = CInt(Math.Ceiling(((_Items.Count) * ItemHeight) / _SelectedHeight))
        ElseIf CInt(Math.Round(((_Items.Count) * ItemHeight) / _SelectedHeight)) = 0 Then
            VerticalScrollbar._Maximum = 1
        Else
            VerticalScrollbar._Maximum = CInt(Math.Round(((_Items.Count) * ItemHeight) / _SelectedHeight))
        End If
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VerticalScrollbar.Location = New Point(Width - VerticalScrollbar.Width - 2, 2)
        VerticalScrollbar.Size = New Size(18, Height - 4)
        Invalidate()
    End Sub

    Public Class LogInListBoxItem
        Property Text As String
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    <System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)> _
    Public Property Items() As LogInListBoxItem()
        Get
            Return _Items.ToArray()
        End Get
        Set(ByVal value As LogInListBoxItem())
            _Items = New List(Of LogInListBoxItem)(value)
            Invalidate()
            InvalidateScroll()
        End Set
    End Property

    Public ReadOnly Property SelectedItems() As LogInListBoxItem()
        Get
            Return _SelectedItems.ToArray()
        End Get
    End Property

    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value

            If _SelectedItems.Count > 1 Then
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1)
            End If

            Invalidate()
        End Set
    End Property

    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            ItemHeight = CInt(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height)
            If VerticalScrollbar IsNot Nothing Then
                VerticalScrollbar._SmallChange = 1
                VerticalScrollbar._LargeChange = 1

            End If
            MyBase.Font = value
            InvalidateLayout()
        End Set
    End Property

    Public Sub AddItem(ByVal Items As String)
        Dim Item As New LogInListBoxItem()
        Item.Text = Items
        _Items.Add(Item)
        Invalidate()
        InvalidateScroll()
    End Sub

    Public Sub AddItems(ByVal Items() As String)
        For Each I In Items
            Dim Item As New LogInListBoxItem()
            Item.Text = I
            _Items.Add(Item)
        Next
        Invalidate()
        InvalidateScroll()
    End Sub

    Public Sub RemoveItemAt(ByVal index As Integer)
        _Items.RemoveAt(index)
        Invalidate()
        InvalidateScroll()
    End Sub

    Public Sub RemoveItem(ByVal item As LogInListBoxItem)
        _Items.Remove(item)
        Invalidate()
        InvalidateScroll()
    End Sub

    Public Sub RemoveItems(ByVal items As LogInListBoxItem())
        For Each I As LogInListBoxItem In items
            _Items.Remove(I)
        Next
        Invalidate()
        InvalidateScroll()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub Vertical_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Focus()
        If e.Button = MouseButtons.Left Then
            Dim Offset As Integer = CInt(VerticalScrollbar.Value * (VerticalScrollbar.Maximum + (Height - (ItemHeight))))

            Dim Index As Integer = ((e.Y + Offset) \ ItemHeight)

            If Index > _Items.Count - 1 Then Index = -1

            If Not Index = -1 Then

                If ModifierKeys = Keys.Control AndAlso _MultiSelect Then
                    If _SelectedItems.Contains(_Items(Index)) Then
                        _SelectedItems.Remove(_Items(Index))
                    Else
                        _SelectedItems.Add(_Items(Index))
                    End If
                Else
                    _SelectedItems.Clear()
                    _SelectedItems.Add(_Items(Index))
                End If
                Debug.Print(CStr(_SelectedItems(0).Text))
            End If

            Invalidate()
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 120) * (2 \ 2))
        Dim Value As Integer = Math.Max(Math.Min(VerticalScrollbar.Value + Move, VerticalScrollbar.Maximum), VerticalScrollbar.Minimum)
        VerticalScrollbar.Value = Value
        MyBase.OnMouseWheel(e)
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                    ControlStyles.UserPaint Or ControlStyles.Selectable Or _
                    ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        VerticalScrollbar = New LogInVerticalScrollBar
        VerticalScrollbar._SmallChange = 1
        VerticalScrollbar._LargeChange = 1
        AddHandler VerticalScrollbar.Scroll, AddressOf HandleScroll
        AddHandler VerticalScrollbar.MouseDown, AddressOf Vertical_MouseDown
        Controls.Add(VerticalScrollbar)
        InvalidateLayout()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Width)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(_BaseColor)
            Dim AllItems As LogInListBoxItem
            Dim Offset As Integer = CInt(VerticalScrollbar.Value * (VerticalScrollbar.Maximum + (Height - (ItemHeight))))
            Dim StartIndex As Integer
            If Offset = 0 Then StartIndex = 0 Else StartIndex = CInt(Offset \ ItemHeight \ VerticalScrollbar.Maximum)
            Dim EndIndex As Integer = Math.Min(StartIndex + (Height \ ItemHeight), _Items.Count - 1)
            .DrawLine(New Pen(_BorderColor, 2), VerticalScrollbar.Location.X - 1, 0, VerticalScrollbar.Location.X - 1, Height)

            For I As Integer = StartIndex To _Items.Count - 1
                AllItems = Items(I)
                Dim Y As Integer = ((I * ItemHeight) + 1 - Offset) + CInt((ItemHeight / 2) - 8)
                If _SelectedItems.Contains(AllItems) Then
                    .FillRectangle(New SolidBrush(_SelectedItemColor), New Rectangle(0, (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1))
                Else
                    .FillRectangle(New SolidBrush(_NonSelectedItemColor), New Rectangle(0, (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1))
                End If
                .DrawLine(New Pen(_BorderColor), 0, ((I * ItemHeight) + 1 - Offset) + ItemHeight - 1, Width - 18, ((I * ItemHeight) + 1 - Offset) + ItemHeight - 1)
                .DrawString(AllItems.Text, New Font("Segoe UI", 8), New SolidBrush(_TextColor), 9, Y)
                .ResetClip()
            Next
            .DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), 1, 1, Width - 2, Height - 2)
            '   .DrawLine(New Pen(_BorderColor), 0, ItemHeight, Width, ItemHeight)
            .DrawLine(New Pen(_BorderColor, 2), VerticalScrollbar.Location.X - 1, 0, VerticalScrollbar.Location.X - 1, Height)
        End With
        G.Dispose()
        e.Graphics.InterpolationMode = CType(7, InterpolationMode)
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

    Private Sub LogInListBoxWBuiltInScrollBar1_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        _SelectedHeight = Height
        InvalidateScroll()
    End Sub

End Class

Public Class LogInContextMenu
    Inherits ContextMenuStrip

#Region "Declarations"

    Private _FontColor As Color = Color.FromArgb(55, 255, 255)

#End Region

#Region "Properties"

    Public Property FontColor As Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Color)
            _FontColor = value
        End Set
    End Property

#End Region

#Region "Draw Control"

    Sub New()
        Renderer = New ToolStripProfessionalRenderer(New LogInColorTable())
        ShowCheckMargin = False
        ShowImageMargin = False
        ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        MyBase.OnPaint(e)
    End Sub

#End Region

End Class

Public Class LogInColorTab
    Inherits ProfessionalColorTable

#Region "Declarations"

    Private _BackColor As Color = Color.FromArgb(42, 42, 42)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _SelectedColor As Color = Color.FromArgb(47, 47, 47)

#End Region

#Region "Properties"

    <Category("Colors")>
    Public Property SelectedColor As Color
        Get
            Return _SelectedColor
        End Get
        Set(ByVal value As Color)
            _SelectedColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BackColor As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            _BackColor = value
        End Set
    End Property

    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckPressedBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckSelectedBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return _BorderColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return _SelectedColor
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return _BorderColor
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

#End Region

End Class




