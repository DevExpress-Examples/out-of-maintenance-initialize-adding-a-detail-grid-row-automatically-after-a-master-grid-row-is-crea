Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public NotInheritable Class Helper
	Private Shared _Data As List(Of MasterObject)
	Private Sub New()
	End Sub
	Public Shared Property Data() As List(Of MasterObject)
		Get
			If _Data Is Nothing Then
				_Data = New List(Of MasterObject)()
				FillData()
			End If
			Return _Data
		End Get
		Set(ByVal value As List(Of MasterObject))
			_Data = value
		End Set
	End Property
	Private Shared Sub FillData()
		_Data.Add(New MasterObject(0, "foo"))
		_Data(0).Items.Add(New DetailObject(0, "foo1"))
		_Data(0).Items.Add(New DetailObject(1, "foo2"))
		_Data(0).Items.Add(New DetailObject(2, "foo3"))

		_Data.Add(New MasterObject(1, "bar"))
		_Data(1).Items.Add(New DetailObject(0, "bar1"))
		_Data(1).Items.Add(New DetailObject(1, "bar2"))
		_Data(1).Items.Add(New DetailObject(2, "bar3"))
	End Sub

	Public Shared Function GetMasterData() As List(Of MasterObject)
		Return Data
	End Function
	Public Shared Function AddItem(ByVal key As Integer, ByVal value As String) As Boolean
		Data.Add(New MasterObject(key, value))
		Return True
	End Function
	Public Shared Function EditItem(ByVal key As Integer, ByVal value As String) As Boolean
		Dim item As MasterObject = Find(key)
		If item Is Nothing Then
			Return False
		End If
		item.Value = value
		Return True
	End Function
	Public Shared Function DeleteItem(ByVal key As Integer) As Boolean
		Dim item As MasterObject = Find(key)
		If item Is Nothing Then
			Return False
		End If
		Data.Remove(item)
		Return True
	End Function

	Private Shared Function Find(ByVal key As Integer) As MasterObject
		Return Data.Find(Function(d) d.Key = key)
	End Function

	Public Shared Function GetDetailData(ByVal masterKey As Integer) As List(Of DetailObject)
		Return Find(masterKey).Items
	End Function

	Public Shared Function AddDetailItem(ByVal masterKey As Integer, ByVal key As Integer, ByVal value As String) As Boolean
		Find(masterKey).Items.Add(New DetailObject(key, value))
		Return True
	End Function

	Public Shared Function EditDetailItem(ByVal masterKey As Integer, ByVal key As Integer, ByVal value As String) As Boolean
		Dim item As DetailObject = Find(masterKey).Items.Find(Function(d) d.Key = key)
		If item Is Nothing Then
			Return False
		End If
		item.Value = value
		Return True
	End Function

	Public Shared Function DeleteDetailItem(ByVal masterKey As Integer, ByVal key As Integer) As Boolean
		Dim masterItem As MasterObject = Find(masterKey)
		If masterItem Is Nothing Then
			Return False
		End If
		Dim item As DetailObject = masterItem.Items.Find(Function(d) d.Key = key)
		If item Is Nothing Then
			Return False
		End If
		masterItem.Items.Remove(item)
		Return True
	End Function
End Class