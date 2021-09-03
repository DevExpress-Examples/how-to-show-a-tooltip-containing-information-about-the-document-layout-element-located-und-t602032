Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Layout
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DXRichEditHitTest
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DXRibbonWindow

		Public Sub New()
			InitializeComponent()
			richEditControl1.LoadDocument("Documents//Grimm.docx")
		End Sub
		Private toolTip As New ToolTip()
		Private Sub RichEditControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
'			#Region "#HitTest"
			'Obtain the mouse cursor's layout position on the page and the current page index:
			Dim wPoint As Point = e.GetPosition(richEditControl1)

			Dim pageLayoutPosition As PageLayoutPosition = richEditControl1.ActiveView.GetDocumentLayoutPosition(New System.Drawing.Point(CInt(Math.Truncate(wPoint.X)), CInt(Math.Truncate(wPoint.Y))))
			If pageLayoutPosition Is Nothing Then
				Return
			End If

			Dim point As System.Drawing.Point = pageLayoutPosition.Position
			Dim pageIndex As Integer = pageLayoutPosition.PageIndex
			Dim layoutPage As LayoutPage = richEditControl1.DocumentLayout.GetPage(pageIndex)

			'Create a HitTestManager instance: 
			Dim hitTest As New HitTestManager(richEditControl1.DocumentLayout)

			'Perform the hit test and pass the result to the RichEditHitTestResult object:
			Dim result As RichEditHitTestResult = hitTest.HitTest(layoutPage, point)
			If result IsNot Nothing Then
				'Retrieve the current layout element type:
				Dim element As LayoutElement = result.LayoutElement
				Dim text As String = element.Type.ToString()

				'Obtain the the text character and its bounds under the mouse position              
				If element.Type = LayoutType.CharacterBox Then
					text &= String.Format(" : ""{0}""", (TryCast(element, CharacterBox)).Text)
					text &= GetBounds(element)
					If element.Parent.Type = LayoutType.PlainTextBox Then
						text &= String.Format(vbCrLf & "PlainTextBox : ""{0}""", (TryCast(element.Parent, PlainTextBox)).Text)
						text &= GetBounds(element.Parent)
					End If
				Else
					'Get the hovered element's bounds:
					text &= GetBounds(element)
				End If

				'Get the element's location:
				Dim title As String = GetLocation(element)

				'Display all retrieved information in the tooltip:
				toolTip.IsOpen = True
				toolTip.Content = text &vbCrLf & title

			End If
'			#End Region ' #HitTest
		End Sub
		Private Function GetBounds(ByVal element As LayoutElement) As String
			Return String.Format(vbCrLf & "Bounds : {0}", element.Bounds)
		End Function
		Private Function GetLocation(ByVal element As LayoutElement) As String
			Do While element IsNot Nothing
				Select Case element.Type
					Case LayoutType.CommentsArea
						Return "Comments Area Location"
					Case LayoutType.Header
						Return "Header Location"
					Case LayoutType.Footer
						Return "Footer Location"
				End Select
				element = element.Parent
			Loop
			Return "Page Location"
		End Function
	End Class
End Namespace