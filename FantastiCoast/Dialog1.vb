Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If NumericUpDownMinSlope.Value > NumericUpDownMaxSlope.Value Then
            MsgBox("Minimum slope cannot be higher than maximum slope", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        My.Settings.SeaDepth = NumericUpDownSeaDepth.Value
        My.Settings.MinSlope = NumericUpDownMinSlope.Value
        My.Settings.MaxSlope = NumericUpDownMaxSlope.Value
        
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        NumericUpDownSeaDepth.Value = My.Settings.SeaDepth
        NumericUpDownMinSlope.Value = My.Settings.MinSlope
        NumericUpDownMaxSlope.Value = My.Settings.MaxSlope
    End Sub

    Private Sub ButtonReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReset.Click
        NumericUpDownSeaDepth.Value = 100
        NumericUpDownMinSlope.Value = 3
        NumericUpDownMaxSlope.Value = 30
    End Sub

End Class
