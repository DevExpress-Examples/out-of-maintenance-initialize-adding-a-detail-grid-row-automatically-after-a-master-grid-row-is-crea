Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class MasterObject
	Public Sub New(ByVal key As Integer, ByVal value As String)
		Key = key
		Value = value
		Items = New List(Of DetailObject)()
	End Sub
	Private privateKey As Integer
	Public Property Key() As Integer
		Get
			Return privateKey
		End Get
		Set(ByVal value As Integer)
			privateKey = value
		End Set
	End Property
	Private privateValue As String
	Public Property Value() As String
		Get
			Return privateValue
		End Get
		Set(ByVal value As String)
			privateValue = value
		End Set
	End Property
	Private privateItems As List(Of DetailObject)
	Public Property Items() As List(Of DetailObject)
		Get
			Return privateItems
		End Get
		Set(ByVal value As List(Of DetailObject))
			privateItems = value
		End Set
	End Property

End Class