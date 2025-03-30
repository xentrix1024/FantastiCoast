Imports System.Threading
Imports System.IO
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.PixelFormats

Public Class Form1

    Dim ProcessThread As Thread
    Dim Cancel As Boolean
    Dim PicWidth, PicHeight, PicHRes, PicVRes As Integer
    Dim ElevationBottom As Integer
    Dim MinSlopeFactor, MaxSlopeFactor

    '************************************** IMAGE HANDLING begin ************************************************
    Private Function CloneImage(ByVal SourceImage As Bitmap) As Bitmap
        CloneImage = New Bitmap(SourceImage.Width, SourceImage.Height, Imaging.PixelFormat.Format24bppRgb)
        CloneImage.SetResolution(SourceImage.HorizontalResolution, SourceImage.VerticalResolution)
        Dim TempGraphics As Graphics
        TempGraphics = Graphics.FromImage(CloneImage)
        TempGraphics.DrawImage(SourceImage, 0, 0)
        TempGraphics.Dispose()
    End Function

    Private Function Bitmap2Array(ByVal theBitmap As Bitmap) As Byte()
        Dim theArray(theBitmap.Height * theBitmap.Width * 4) As Byte
        Dim theMemoryStream As New MemoryStream
        theBitmap.Save(theMemoryStream, Imaging.ImageFormat.Bmp)
        With New BitmapImage
            .BeginInit()
            .StreamSource = New MemoryStream(theMemoryStream.ToArray())
            .EndInit()
            .CopyPixels(theArray, theBitmap.Width * 4, 0)
        End With
        theMemoryStream.Dispose()
        Return theArray
    End Function

    Private Function Array2Bitmap(ByVal theArray() As Byte) As Bitmap
        Dim theMemoryStream As New MemoryStream
        With New BmpBitmapEncoder
            .Frames.Add(BitmapFrame.Create(BitmapSource.Create(PicWidth, PicHeight, PicHRes, PicVRes, Bgr32, Nothing, theArray, PicWidth * 4)))
            .Save(theMemoryStream)
        End With
        Array2Bitmap = New Bitmap(theMemoryStream)
        theMemoryStream.Dispose()
    End Function
    '************************************** IMAGE HANDLING end ************************************************

    '************************************** FORM EVENTS begin ************************************************
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With My.Settings
            .Reload()
            If Directory.GetCurrentDirectory = "" Then Directory.SetCurrentDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        End With
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        My.Settings.Save()
        If ProcessThread IsNot Nothing Then ProcessThread.Abort()
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.O
                If ButtonOpen.Enabled Then ButtonOpen_Click(sender, e)
            Case Keys.L
                If ButtonLaunch.Enabled Then ButtonLaunch_Click(sender, e)
            Case Keys.C
                If ButtonCancel.Enabled Then ButtonCancel_Click(sender, e)
            Case Keys.S
                If ButtonSave.Enabled Then ButtonSave_Click(sender, e)
            Case Keys.G
                If ButtonConfig.Enabled Then ButtonConfig_Click(sender, e)
            Case Keys.A
                If ButtonAbout.Enabled Then ButtonAbout_Click(sender, e)
        End Select
    End Sub
    '************************************** FORM EVENTS end ************************************************

    Private Sub ButtonAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAbout.Click
        AboutBox1.ShowDialog(Me)
        AboutBox1.Dispose()
    End Sub

    Private Sub ButtonConfig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonConfig.Click
        Dialog1.ShowDialog(Me)
        Dialog1.Dispose()
    End Sub

    '************************************** FILE OPEN begin ************************************************
    Private Sub ButtonOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpen.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ToolStripStatusLabelStatus.Text = "Opening file"
            Me.Refresh()
            Me.Cursor = Cursors.WaitCursor

            Try
                Select Case Strings.LCase(Path.GetExtension(OpenFileDialog1.FileName))
                    Case ".bmp"
                        ThePic.Image = OpenBMPFile(OpenFileDialog1.FileName)
                    Case ".png"
                        ThePic.Image = OpenPNGFile(OpenFileDialog1.FileName)
                    Case ".asc"
                        ThePic.Image = OpenAscFile(OpenFileDialog1.FileName)
                    Case Else
                        Err.Raise(513, , "Invalid file extension")
                End Select

                'UI specific
                PicWidth = ThePic.Image.Width
                PicHeight = ThePic.Image.Height
                PicHRes = ThePic.Image.HorizontalResolution
                PicVRes = ThePic.Image.VerticalResolution
                ToolStripStatusLabelWidth.Text = "Width: " & PicWidth & " pixels"
                ToolStripStatusLabelHeight.Text = "Height: " & PicHeight & " pixels"
                ButtonLaunch.Enabled = True
                ButtonSave.Enabled = True
            Catch TheError As Exception
                MsgBox(TheError.Message, MsgBoxStyle.Critical, "File open error")
            End Try

            Me.Cursor = Cursors.Default
            ToolStripStatusLabelStatus.Text = "Idle"
        End If
    End Sub

    Private Function OpenBMPFile(ByVal FileName As String) As Bitmap
        Dim bitmapSource As BitmapSource = New BmpBitmapDecoder(New Uri(FileName), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default).Frames(0)

        If bitmapSource.Format.BitsPerPixel = 24 Or bitmapSource.Format.BitsPerPixel = 32 Then
            OpenBMPFile = Bitmap.FromFile(FileName)
            If bitmapSource.Format.BitsPerPixel = 32 Then
                OpenBMPFile = CloneImage(OpenBMPFile)
            End If
        Else
            Err.Raise(513, , "Wrong pixel format.Valid formats are:" & vbCrLf & "• 24 bit RGB" & vbCrLf & "• 32 bit RGB" & vbCrLf & "• 32 bit aRGB")
            Return Nothing
        End If
    End Function

    Private Function OpenPNGFile(ByVal FileName As String) As Bitmap
        Dim bitmapSource As BitmapSource = New PngBitmapDecoder(New Uri(FileName), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default).Frames(0)
        PicWidth = bitmapSource.PixelWidth
        PicHeight = bitmapSource.PixelHeight
        PicHRes = bitmapSource.DpiX
        PicVRes = bitmapSource.DpiY

        Select Case bitmapSource.Format
            Case Gray8, Gray16
                Dim GrayStride As Integer = PicWidth * IIf(bitmapSource.Format = Gray8, 1, 2)
                Dim GrayPixels(PicHeight * GrayStride) As Byte
                bitmapSource.CopyPixels(GrayPixels, GrayStride, 0)
                Dim ColorPixels() As Byte = Bitmap2Array(New Bitmap(PicWidth, PicHeight, Imaging.PixelFormat.Format24bppRgb))

                If bitmapSource.Format = Gray8 Then
                    For y = 0 To PicHeight - 1
                        For x = 0 To PicWidth - 1
                            SetPixelElevation(ColorPixels, x, y, Gray82RGBElevation(GrayPixels(y * GrayStride + x)))
                        Next x
                    Next y
                Else
                    For y = 0 To PicHeight - 1
                        For x = 0 To PicWidth - 1
                            SetPixelElevation(ColorPixels, x, y, GrayPixels(y * GrayStride + x * 2 + 1) * 256 + GrayPixels(y * GrayStride + x * 2))
                        Next x
                    Next y
                End If
                OpenPNGFile = Array2Bitmap(ColorPixels)

            Case Else
                If bitmapSource.Format.BitsPerPixel = 24 Or bitmapSource.Format.BitsPerPixel = 32 Then
                    OpenPNGFile = Bitmap.FromFile(FileName)
                    If bitmapSource.Format.BitsPerPixel = 32 Then
                        OpenPNGFile = CloneImage(OpenPNGFile)
                    End If
                Else
                    Err.Raise(513, , "Wrong pixel format.Valid formats are:" & vbCrLf & "• 8 bit Grayscale" & vbCrLf & "• 16 bit Grayscale" & vbCrLf & "• 24 bit RGB" & vbCrLf & "• 32 bit RGB" & vbCrLf & "• 32 bit aRGB")
                    Return Nothing
                End If
        End Select
    End Function

    Private Function OpenAscFile(ByVal FileName As String) As Bitmap
        Dim NextLine() As String
        Dim ncols, nrows, NODATA_value As Integer
        Dim Elevation As Integer

        Dim InputFile As New StreamReader(FileName)

        Try
            For i = 1 To 6
                NextLine = Split(InputFile.ReadLine, " ", 2)
                Select Case NextLine(0)
                    Case "ncols"
                        ncols = NextLine(1)
                    Case "nrows"
                        nrows = NextLine(1)
                    Case "NODATA_value"
                        NODATA_value = NextLine(1)
                End Select
            Next

            PicWidth = ncols
            PicHeight = nrows
            Dim ColorPixels() As Byte = Bitmap2Array(New Bitmap(PicWidth, PicHeight, Imaging.PixelFormat.Format24bppRgb))

            '*** Read asc altitude data ***
            For y = 0 To nrows - 1
                Dim NextLineCols = Split(InputFile.ReadLine)
                For x = 0 To UBound(NextLineCols) - 1
                    Elevation = NextLineCols(x)
                    If Elevation < 0 Or Elevation = NODATA_value Then Elevation = 0
                    If Elevation > 0 Then Elevation = (Elevation + 250) * 10
                    SetPixelElevation(ColorPixels, x, y, Elevation)
                Next
            Next

            OpenAscFile = Array2Bitmap(ColorPixels)

        Catch
            Err.Raise(513, , "File format error")
            Return Nothing
        End Try

        InputFile.Close()

    End Function
    '************************************** FILE OPEN end ************************************************

    '************************************** FILE SAVE begin ************************************************
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        SaveFileDialog1.Reset()
        SaveFileDialog1.Filter = "Bmp color picture for SC4T/SC4M (*.bmp)|*.bmp|PNG color picture for SC4T/SC4M (*.png)|*.png|Png grayscale 16 bit for SC4T/SC4M (*.png)|*.png|Png grayscale 8 bit for SimCity 4 (Low quality) (*.png)|*.png"
        SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName) & "_smoothed"
        Select Case Strings.LCase(Path.GetExtension(OpenFileDialog1.FileName))
            Case ".bmp", ".asc"
                SaveFileDialog1.FilterIndex = 1
            Case ".png"
                SaveFileDialog1.FilterIndex = 2
        End Select

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            ToolStripStatusLabelStatus.Text = "Saving file"
            Me.Refresh()
            Me.Cursor = Cursors.WaitCursor

            If SaveFileDialog1.FilterIndex = 1 Then
                If Strings.LCase(Strings.Right(SaveFileDialog1.FileName, 4)) <> ".bmp" Then SaveFileDialog1.FileName = SaveFileDialog1.FileName & ".bmp"
            Else
                If Strings.LCase(Strings.Right(SaveFileDialog1.FileName, 4)) <> ".png" Then SaveFileDialog1.FileName = SaveFileDialog1.FileName & ".png"
            End If

            Try
                Select Case SaveFileDialog1.FilterIndex
                    Case 1
                        ThePic.Image.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Bmp)
                    Case 2
                        ThePic.Image.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Png)
                    Case 3
                        SaveGrayscalePNG(SaveFileDialog1.FileName, 16)
                    Case 4
                        SaveGrayscalePNG(SaveFileDialog1.FileName, 8)
                    Case Else
                        Err.Raise(513, , "Bad file extension")
                End Select
            Catch TheError As Exception
                MsgBox(TheError.Message, MsgBoxStyle.Critical, "File save error")
            End Try

            Me.Cursor = Cursors.Default
            ToolStripStatusLabelStatus.Text = "Idle"
        End If
    End Sub

    Private Sub SaveGrayscalePNG(ByVal FilePath As String, ByVal bits As Integer)
        Dim Elevation As Integer
        Dim GrayStride As Integer = PicWidth * (bits / 8)
        Dim GrayPixels(PicHeight * GrayStride) As Byte
        Dim myPixelFormat As Windows.Media.PixelFormat
        Dim myBitmapPalette As BitmapPalette = Nothing
        Dim ColorPixels() As Byte = Bitmap2Array(ThePic.Image)

        Select Case bits
            Case 8
                Dim MinElevation, MaxElevation, Decrease As Integer
                Dim CFactor As Decimal
                Dim CompressMode As Integer = 0

                myPixelFormat = Windows.Media.PixelFormats.Gray8
                myBitmapPalette = BitmapPalettes.Gray256

                ToolStripStatusLabelStatus.Text = "Calculating elevation"
                Me.Refresh()
                GetMapProperties(ColorPixels, MinElevation, MaxElevation)

                If MaxElevation > Gray82RGBElevation(255) Then 'Exceeds maximum 8bit elevation
                    If MaxElevation - MinElevation > Gray82RGBElevation(255) - Gray82RGBElevation(84) Then 'Needs compression
                        MsgBox("Land elevation exceeds possible maximum. The terrain will be scaled.", MsgBoxStyle.Exclamation)
                        CompressMode = 2
                        CFactor = (Gray82RGBElevation(255) - Gray82RGBElevation(84)) / (MaxElevation - IIf(MinElevation >= 2500, MinElevation, 2500))
                        Decrease = IIf(MinElevation >= 2500, MinElevation, 2500) * CFactor - Gray82RGBElevation(84)
                    Else 'Needs elevation decrease
                        CompressMode = 1
                        Decrease = MaxElevation - Gray82RGBElevation(255)
                    End If
                End If

                ToolStripStatusLabelStatus.Text = "Saving file"
                Me.Refresh()

                For y = 0 To PicHeight - 1
                    For x = 0 To PicWidth - 1
                        Elevation = GetPixelElevation(ColorPixels, x, y)
                        Select Case CompressMode
                            Case 0 'Normal conversion
                                GrayPixels(y * GrayStride + x) = Elevation2Gray8(Elevation)
                            Case 1 'Decrease elevation for the whole map
                                GrayPixels(y * GrayStride + x) = Elevation2Gray8(Elevation - Decrease)
                            Case 2 'Scale map and decrease elevation as needed
                                GrayPixels(y * GrayStride + x) = Elevation2Gray8((Elevation * CFactor) - Decrease)
                        End Select
                    Next x
                Next y
            Case 16
                myPixelFormat = Windows.Media.PixelFormats.Gray16
                For y = 0 To PicHeight - 1
                    For x = 0 To PicWidth - 1
                        Elevation = GetPixelElevation(ColorPixels, x, y)
                        GrayPixels(y * GrayStride + x * 2) = Elevation Mod 256
                        GrayPixels(y * GrayStride + x * 2 + 1) = Elevation \ 256
                    Next x
                Next y
        End Select

        Dim PngImage As BitmapSource = BitmapSource.Create(PicWidth, PicHeight, PicHRes, PicVRes, myPixelFormat, myBitmapPalette, GrayPixels, GrayStride)

        Dim stream As New FileStream(FilePath, FileMode.Create)
        Dim encoder As New PngBitmapEncoder With {.Interlace = PngInterlaceOption.Off}
        encoder.Frames.Add(BitmapFrame.Create(PngImage))
        encoder.Save(stream)
        stream.Close()
    End Sub

    Private Function Elevation2Gray8(ByVal Elevation As Integer) As Byte
        If Elevation < 274 Then Elevation = 274
        If Elevation > 7032 Then Elevation = 7032
        Elevation2Gray8 = Decimal.Round((Elevation - 274) / 26.5)
    End Function

    Private Function Gray82RGBElevation(ByVal Gray8 As Byte) As Integer
        Gray82RGBElevation = Decimal.Round(Gray8 * 26.5) + 274
    End Function

    Private Sub GetMapProperties(ByVal BmpArray() As Byte, ByRef MinElevation As Integer, ByRef MaxElevation As Integer)
        Dim Elevation As Integer
        MinElevation = GetPixelElevation(BmpArray, 0, 0)
        MaxElevation = MinElevation
        For y = 0 To PicHeight - 1
            For x = 0 To PicWidth - 1
                Elevation = GetPixelElevation(BmpArray, x, y)
                If Elevation < MinElevation Then MinElevation = Elevation
                If Elevation > MaxElevation Then MaxElevation = Elevation
            Next x
        Next y
    End Sub
    '************************************** FILE SAVE end ************************************************

    '************************************** THE PROCESS begin ************************************************
    Private Sub ButtonLaunch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLaunch.Click
        ButtonOpen.Enabled = False
        ButtonLaunch.Enabled = False
        ButtonCancel.Enabled = True
        ButtonSave.Enabled = False
        ButtonConfig.Enabled = False
        ButtonAbout.Enabled = False

        Cancel = False

        Me.Cursor = Cursors.WaitCursor

        ProcessThread = New Thread(AddressOf Process)
        ProcessThread.Start()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Cancel = True
    End Sub

    Private Sub Process()
        On Error GoTo ErrorHandler
        Dim BmpArray() As Byte
        Dim Changed As New ArrayList
        Dim x, y As Integer
        Dim Pass As Integer
        Dim Elevation, n As Integer
        Dim BottomOnly As Boolean

        'Black pixel alpha channel = 0
        'Color pixel alpha channel = 255

        'Set variables
        ElevationBottom = (250 - My.Settings.SeaDepth) * 10
        MinSlopeFactor = My.Settings.MinSlope * 10
        MaxSlopeFactor = My.Settings.MaxSlope * 10

        'Copy the image to an array
        BmpArray = Bitmap2Array(Me.ThePic.Invoke(New GetPicDelegate(AddressOf GetPic)))

        'Preliminary pass to mark black pixels with 0 in Alpha channel
        Me.StatusStrip1.Invoke(New SetStatusStripTextDelegate(AddressOf SetStatusStripText), New Object() {"Preliminary pass"})
        For y = 0 To PicHeight - 1
            If Cancel Then GoTo LoopCancelled
            For x = 0 To PicWidth - 1
                If GetPixelElevation(BmpArray, x, y) = 0 Then BmpArray((x + y * PicWidth) * 4 + 3) = 0
            Next
        Next

        Do
            Pass += 1
            Me.StatusStrip1.Invoke(New SetStatusStripTextDelegate(AddressOf SetStatusStripText), New Object() {"Pass " & Pass})
            Changed.Clear()
            BottomOnly = True

            'Find black pixels neighbouring to colored and calculate their elevation
            For y = 0 To PicHeight - 1
                If Cancel Then GoTo LoopCancelled
                For x = 0 To PicWidth - 1
                    If BmpArray((x + y * PicWidth) * 4 + 3) = 0 Then
                        If GetColoredNeighbours(BmpArray, x, y) > 2 Then
                            Elevation = 0
                            n = 0

                            'Vertical components
                            If GetPixelAlpha(BmpArray, x + 1, y) + GetPixelAlpha(BmpArray, x + 2, y) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x + 1, y), GetPixelElevation(BmpArray, x + 2, y)) : n += 1
                            If GetPixelAlpha(BmpArray, x - 1, y) + GetPixelAlpha(BmpArray, x - 2, y) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x - 1, y), GetPixelElevation(BmpArray, x - 2, y)) : n += 1
                            If GetPixelAlpha(BmpArray, x, y + 1) + GetPixelAlpha(BmpArray, x, y + 2) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x, y + 1), GetPixelElevation(BmpArray, x, y + 2)) : n += 1
                            If GetPixelAlpha(BmpArray, x, y - 1) + GetPixelAlpha(BmpArray, x, y - 2) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x, y - 1), GetPixelElevation(BmpArray, x, y - 2)) : n += 1
                            'Diagonal components
                            If GetPixelAlpha(BmpArray, x + 1, y + 1) + GetPixelAlpha(BmpArray, x + 2, y + 2) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x + 1, y + 1), GetPixelElevation(BmpArray, x + 2, y + 2)) : n += 1
                            If GetPixelAlpha(BmpArray, x + 1, y - 1) + GetPixelAlpha(BmpArray, x + 2, y - 2) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x + 1, y - 1), GetPixelElevation(BmpArray, x + 2, y - 2)) : n += 1
                            If GetPixelAlpha(BmpArray, x - 1, y + 1) + GetPixelAlpha(BmpArray, x - 2, y + 2) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x - 1, y + 1), GetPixelElevation(BmpArray, x - 2, y + 2)) : n += 1
                            If GetPixelAlpha(BmpArray, x - 1, y - 1) + GetPixelAlpha(BmpArray, x - 2, y - 2) = 510 Then Elevation += CalculateComponent(GetPixelElevation(BmpArray, x - 1, y - 1), GetPixelElevation(BmpArray, x - 2, y - 2)) : n += 1

                            If n > 0 Then
                                Elevation \= n
                                If Elevation > ElevationBottom Then
                                    SetPixelElevation(BmpArray, x, y, Elevation)
                                    BottomOnly = False
                                Else
                                    SetPixelElevation(BmpArray, x, y, ElevationBottom)
                                End If
                                Changed.Add(x)
                                Changed.Add(y)
                            End If
                        End If
                    End If
                Next x
            Next y

            'Mark calculated pixels as colored
            For i = 0 To Changed.Count - 1 Step 2
                BmpArray((Changed(i) + Changed(i + 1) * PicWidth) * 4 + 3) = 255
            Next i

            'Decide when to start applying only sea bottom elevation
            If BottomOnly Then
                Me.StatusStrip1.Invoke(New SetStatusStripTextDelegate(AddressOf SetStatusStripText), New Object() {"Finishing bottom"})
                Changed.Clear()
                For y = 0 To PicHeight - 1
                    If Cancel Then GoTo LoopCancelled
                    For x = 0 To PicWidth - 1
                        If BmpArray((x + y * PicWidth) * 4 + 3) = 0 Then SetPixelElevation(BmpArray, x, y, ElevationBottom)
                    Next x
                Next y
            End If

            'Copy the image to the UI
            Me.ThePic.Invoke(New RefreshPicDelegate(AddressOf RefreshPic), New Object() {Array2Bitmap(BmpArray)})

        Loop Until Changed.Count = 0 Or Cancel

LoopCancelled:
        If Cancel Then
            Me.ToolStrip1.Invoke(New SetToolStripButtonsDelegate(AddressOf SetToolStripButtons), New Object() {True, True, False, True, True, True})
            Me.StatusStrip1.Invoke(New SetStatusStripTextDelegate(AddressOf SetStatusStripText), New Object() {"Cancelled"})
        Else
            Me.ToolStrip1.Invoke(New SetToolStripButtonsDelegate(AddressOf SetToolStripButtons), New Object() {True, False, False, True, True, True})
            Me.StatusStrip1.Invoke(New SetStatusStripTextDelegate(AddressOf SetStatusStripText), New Object() {"Finished"})
        End If

        Me.Invoke(New SetCursorDelegate(AddressOf SetCursor), New Object() {Cursors.Default})

        Exit Sub

ErrorHandler:
        Me.Invoke(New SetCursorDelegate(AddressOf SetCursor), New Object() {Cursors.Default})
        MsgBox(Err.Description & vbCrLf & "Error Number: " & Err.Number & vbCrLf & "Source: " & Err.Source & vbCrLf & "Line: " & Err.Erl & vbCrLf & "LastDllError: " & Err.LastDllError, MsgBoxStyle.Critical, "Process failed")

        Me.ToolStrip1.Invoke(New SetToolStripButtonsDelegate(AddressOf SetToolStripButtons), New Object() {True, True, False, True, True, True})
        Me.StatusStrip1.Invoke(New SetStatusStripTextDelegate(AddressOf SetStatusStripText), New Object() {"Failed"})
    End Sub

    Private Function CalculateComponent(ByVal ElevationNear As Integer, ByVal ElevationFar As Integer) As Integer
        Dim ElevationDifference As Integer

        If ElevationFar > ElevationNear Then
            CalculateComponent = 2 * ElevationNear - ElevationFar
        Else
            CalculateComponent = ElevationFar
        End If

        'Slope correction
        ElevationDifference = ElevationNear - CalculateComponent
        If ElevationDifference < MinSlopeFactor Then
            CalculateComponent = ElevationNear - MinSlopeFactor
        ElseIf ElevationDifference > MaxSlopeFactor Then
            CalculateComponent = ElevationNear - MaxSlopeFactor
        End If

        'Normalize near bottom areas
        If CalculateComponent - ElevationBottom < (ElevationNear - ElevationBottom) / 1.5 Then
            CalculateComponent = ((ElevationNear - ElevationBottom) \ 1.5) + ElevationBottom
        End If
    End Function

    Private Function GetColoredNeighbours(ByVal BmpArray() As Byte, ByVal x As Integer, ByVal y As Integer) As Integer
        GetColoredNeighbours = 0
        Dim x1, x2, y1, y2 As Integer
        x1 = x - 1
        x2 = x + 1
        y1 = y - 1
        y2 = y + 1
        If x1 = -1 Then x1 = 0
        If y1 = -1 Then y1 = 0
        If x2 = PicWidth Then x2 = x
        If y2 = PicHeight Then y2 = y
        For i = x1 To x2
            For j = y1 To y2
                If BmpArray((i + j * PicWidth) * 4 + 3) <> 0 Then GetColoredNeighbours += 1
            Next j
        Next i
    End Function

    Private Function GetPixelElevation(ByVal BmpArray() As Byte, ByVal x As Integer, ByVal y As Integer) As Integer
        Dim offset As Integer = (x + y * PicWidth) * 4
        Return (BmpArray(offset + 2) \ 16) * 4096 + (BmpArray(offset + 1) \ 16) * 256 + BmpArray(offset)
    End Function

    Private Sub SetPixelElevation(ByRef BmpArray() As Byte, ByVal x As Integer, ByVal y As Integer, ByVal Elevation As Integer)
        Dim offset As Integer = (x + y * PicWidth) * 4
        BmpArray(offset + 2) = ((Elevation \ 4096) Mod 16) * 16
        BmpArray(offset + 1) = ((Elevation \ 256) Mod 16) * 16
        BmpArray(offset) = Elevation Mod 256
    End Sub

    Private Function GetPixelAlpha(ByVal BmpArray() As Byte, ByVal x As Integer, ByVal y As Integer) As Integer
        If x < 0 Or x > PicWidth - 1 Or y < 0 Or y > PicHeight - 1 Then Return 0
        Return BmpArray((y * PicWidth + x) * 4 + 3)
    End Function
    '************************************** THE PROCESS end ************************************************

    '************************************** MULTITHREADING  begin ************************************************
    Delegate Function GetPicDelegate() As Bitmap
    Public Function GetPic() As Bitmap
        GetPic = CloneImage(ThePic.Image)
    End Function

    Delegate Sub RefreshPicDelegate(ByVal newBitmap As Bitmap)
    Public Sub RefreshPic(ByVal newBitmap As Bitmap)
        ThePic.Image = CloneImage(newBitmap)
        ThePic.Refresh()
    End Sub

    Delegate Sub SetCursorDelegate(ByVal newCursor As Cursor)
    Public Sub SetCursor(ByVal newCursor As Cursor)
        Me.Cursor = newCursor
    End Sub

    Delegate Sub SetStatusStripTextDelegate(ByVal newText As String)
    Public Sub SetStatusStripText(ByVal newText As String)
        ToolStripStatusLabelStatus.Text = newText
    End Sub

    Delegate Sub SetToolStripButtonsDelegate(ByVal ButtonOpenEnable As Boolean, ByVal ButtonLaunchEnable As Boolean, ByVal ButtonCancelEnable As Boolean, ByVal ButtonSaveEnable As Boolean, ByVal ButtonConfigEnable As Boolean, ByVal ButtonAboutEnable As Boolean)
    Public Sub SetToolStripButtons(ByVal ButtonOpenEnable As Boolean, ByVal ButtonLaunchEnable As Boolean, ByVal ButtonCancelEnable As Boolean, ByVal ButtonSaveEnable As Boolean, ByVal ButtonConfigEnable As Boolean, ByVal ButtonAboutEnable As Boolean)
        ButtonOpen.Enabled = ButtonOpenEnable
        ButtonLaunch.Enabled = ButtonLaunchEnable
        ButtonCancel.Enabled = ButtonCancelEnable
        ButtonSave.Enabled = ButtonSaveEnable
        ButtonConfig.Enabled = ButtonConfigEnable
        ButtonAbout.Enabled = ButtonAboutEnable
    End Sub
    '************************************** MULTITHREADING  end ************************************************

End Class
