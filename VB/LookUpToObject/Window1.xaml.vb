Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Editors.Settings

Namespace LookUpToObject
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()

			Dim JohnDoe As New Person() With {.FirstName = "John", .LastName = "Doe"}
			Dim JohnSmith As New Person() With {.FirstName = "John", .LastName = "Smith"}
			Dim colPersons As New ObservableCollection(Of Person)()
			colPersons.Add(JohnDoe)
			colPersons.Add(JohnSmith)
			CType(gridControl1.Columns("Owner").EditSettings, ComboBoxEditSettings).ItemsSource = colPersons

			Dim colTasks As New ObservableCollection(Of Task)()
			colTasks.Add(New Task() With {.TaskID = 1, .Owner = JohnDoe})
			colTasks.Add(New Task() With {.TaskID = 2, .Owner = JohnDoe})

			gridControl1.ItemsSource = colTasks
		End Sub
	End Class

	Public Class Task
		Public Sub New()
		End Sub
		Private privateTaskID As Integer
		Public Property TaskID() As Integer
			Get
				Return privateTaskID
			End Get
			Set(ByVal value As Integer)
				privateTaskID = value
			End Set
		End Property
		Private privateOwner As Person
		Public Property Owner() As Person
			Get
				Return privateOwner
			End Get
			Set(ByVal value As Person)
				privateOwner = value
			End Set
		End Property
	End Class

	Public Class Person
		Public Sub New()
		End Sub
		Private privateFirstName As String
		Public Property FirstName() As String
			Get
				Return privateFirstName
			End Get
			Set(ByVal value As String)
				privateFirstName = value
			End Set
		End Property
		Private privateLastName As String
		Public Property LastName() As String
			Get
				Return privateLastName
			End Get
			Set(ByVal value As String)
				privateLastName = value
			End Set
		End Property

		Public Overrides Function ToString() As String
			Return String.Format("{0} {1}", FirstName, LastName)
		End Function
	End Class
End Namespace
