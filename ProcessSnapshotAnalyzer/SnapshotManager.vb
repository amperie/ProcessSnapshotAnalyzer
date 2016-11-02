Imports WinControls.ListView
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class SnapshotManager

    Private cClient As ControllerClient
    Private cInfo As ControllerInfo
    Private LastSearch As ProcessSnapshotList
    Private LoadedSnapshots As New ProcessSnapshotList()
    Private AnalysisSnapshots As New ProcessSnapshotList()

    Public Sub New(ControllerInfo As ControllerInfo)
        cInfo = ControllerInfo
    End Sub

    Public Sub ConnectToController(ControllerInfo As ControllerInfo)
        cInfo = ControllerInfo
        ConnectToController()
    End Sub

    Public Sub ConnectToController()
        cClient = New ControllerClient(cInfo)
    End Sub

    Public Function IsAuthenticated() As Boolean
        Return cClient.IsAuthenticated()
    End Function

    Public Function RetrieveSnapshotList(criteria As ProcessSnapshotSearchCriteria) As ProcessSnapshotList
        LastSearch = cClient.GetProcessSnapshotList(criteria)
        Return LastSearch
    End Function

    Public Sub SearchSnapshots(criteria As ProcessSnapshotSearchCriteria)
        LastSearch = RetrieveSnapshotList(criteria)
        For Each procSnap As ProcessSnapshotDescriptor In LoadedSnapshots.results
            If LastSearch.resultDictionary.ContainsKey(procSnap.requestGUID) Then
                LastSearch.resultDictionary(procSnap.requestGUID).Status = "Loaded"
            End If
        Next
    End Sub

    Public Sub LoadSnapshotFromServer(guid As String)
        Dim descriptor As ProcessSnapshotDescriptor = LastSearch.resultDictionary.Item(guid)
        descriptor.ProcessSnapshotDetails = cClient.GetProcessSnapshot(descriptor)
        descriptor.Status = "Loaded"
        LoadedSnapshots.Add(descriptor)
    End Sub

    Public Sub UpdateSMTreeViews(SearchList As TreeListView, LoadedList As TreeListView)
        SearchList.Nodes.Clear()
        Dim tmpNode As TreeListNode
        For Each snap As ProcessSnapshotDescriptor In LastSearch.results
            tmpNode = New TreeListNode(snap.requestGUID)
            tmpNode.SubItems.Add(UnixTimeStampToDateTime(snap.serverStartTime).ToString())
            tmpNode.SubItems.Add(snap.timeTakenInMilliSecs.ToString())
            tmpNode.SubItems.Add(snap.Status)
            SearchList.Nodes.Add(tmpNode)
        Next

        LoadedList.Nodes.Clear()
        For Each snap As ProcessSnapshotDescriptor In LoadedSnapshots.results
            tmpNode = New TreeListNode(snap.requestGUID)
            tmpNode.SubItems.Add(snap.serverStartTime.ToString())
            tmpNode.SubItems.Add(UnixTimeStampToDateTime(snap.serverStartTime).ToString())
            tmpNode.SubItems.Add(snap.Status)
            LoadedList.Nodes.Add(tmpNode)
        Next
    End Sub

    Public Sub UpdateMainMethodTree(MainTree As TreeListView)
        MainTree.Nodes.Clear()
        For Each snap As ProcessSnapshotDescriptor In AnalysisSnapshots.results
            Dim rootNode As New TreeListNode(snap.requestGUID)
            For Each root As MethodNode In snap.ProcessSnapshotDetails.Roots
                rootNode.Nodes.Add(snap.ProcessSnapshotDetails.GenerateTreeViewNode(New TreeListNode(), root))
            Next
            MainTree.Nodes.Add(rootNode)
        Next
    End Sub

    Public Function SummarizeSnapshotsStatistics() As SnapshotsStatistics
        Dim retVal As New SnapshotsStatistics
        retVal.NumberOfSnapshots = 0
        retVal.TotalExeTime = 0
        For Each snap As ProcessSnapshotDescriptor In AnalysisSnapshots.results
            retVal.NumberOfSnapshots += 1
            retVal.TotalExeTime += snap.timeTakenInMilliSecs
        Next
        Return retVal
    End Function

    Public Sub ReRootMainMethodTree(MainTree As TreeListView, newRoot As MethodNode)
        MainTree.Nodes.Clear()
        MainTree.Nodes.Add(newRoot.ParentProcessSnapshot.GenerateReRootedTreeView(newRoot))
    End Sub

    Public Sub AddSnapshotsToAnalyze(guid As String)
        AnalysisSnapshots.Add(LoadedSnapshots.resultDictionary.Item(guid))
    End Sub

    Public Sub AddSnapshotsToAnalyze(snap As ProcessSnapshotDescriptor)
        AnalysisSnapshots.Add(snap)
    End Sub

    Public Sub ClearSnapshotsToAnalyze()
        AnalysisSnapshots = New ProcessSnapshotList()
    End Sub

    Public Sub LoadSnapshotsInMainTreeView(treeList As TreeListView)
        For Each snap As ProcessSnapshotDescriptor In LastSearch.results
            Dim root As New TreeListNode(snap.requestGUID)
            'root.Nodes.Add(snap.)
        Next
    End Sub

    Public Function FindMethodNodes(methodName As String, IsRegex As Boolean, Optional guids As List(Of String) = Nothing) As List(Of MethodNode)
        Dim retVal As New List(Of MethodNode)
        For Each snap As ProcessSnapshotDescriptor In AnalysisSnapshots.results
            If IsNothing(guids) Then
                If IsRegex Then
                    retVal.AddRange(snap.ProcessSnapshotDetails.FindMethodNodesRegex(methodName))
                Else
                    retVal.AddRange(snap.ProcessSnapshotDetails.FindMethodNodes(methodName))
                End If
            ElseIf guids.Contains(snap.requestGUID) Then
                If IsRegex Then
                    retVal.AddRange(snap.ProcessSnapshotDetails.FindMethodNodesRegex(methodName))
                Else
                    retVal.AddRange(snap.ProcessSnapshotDetails.FindMethodNodes(methodName))
                End If
            End If
        Next
        retVal.Sort(AddressOf MethodNode.CompareByTotalTime)
        Return retVal
    End Function

    Public Function FindSlowMethods(criteria As MethodSearchCriteria) As List(Of MethodNode)
        Dim retVal As New List(Of MethodNode)
        For Each snap As ProcessSnapshotDescriptor In AnalysisSnapshots.results
            retVal.AddRange(snap.ProcessSnapshotDetails.FindSlowMethods(criteria))
        Next
        retVal.Sort(AddressOf MethodNode.CompareByTotalTime)
        Return retVal
    End Function

    Public Function UnixTimeStampToDateTime(unixTS As Long) As DateTime
        Dim dt As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        dt = dt.AddSeconds(Math.Round(unixTS / 1000))
        dt.ToLocalTime()
        Return dt
    End Function

    Public Function test()
        Dim c As New ProcessSnapshotSearchCriteria
        cClient.Authenticate()
        c.firstInChain = False
        c.rangeSpecifier = New RangeSpecifier("BEFORE_NOW", 20160)
        c.applicationIds = New List(Of Integer)
        c.applicationIds.Add(5196)
        c.applicationComponentIds = New List(Of Integer)
        c.applicationComponentIds.Add(14314)
        c.maxRows = 5
        'MsgBox(c.toJSON())
        'MsgBox(cClient.GetProcessSnapshotListAsJSON(c))
        Dim res As ProcessSnapshotList = cClient.GetProcessSnapshotList(c)
        Dim s As ProcessSnapshot = cClient.GetProcessSnapshot(res.results(0))
    End Function

End Class


Public Class ProcessSnapshotSearchCriteria
    Public Property firstInChain As Boolean = True
    Public Property maxRows As Integer = 600
    Public Property applicationIds As List(Of Integer)
    Public Property businessTransactionIds As New List(Of Integer)
    Public Property applicationComponentIds As New List(Of Integer)
    Public Property applicationComponentNodeIds As New List(Of Integer)
    Public Property errorIDs As New List(Of Integer)
    Public Property errorOccured As String
    Public Property userExperience As New List(Of String)
    Public Property executionTimeInMilis As String
    Public Property endToEndLatency As String
    Public Property url As String
    Public Property sessionId As String
    Public Property userPrincipalId As String
    Public Property dataCollectorFilter As String
    Public Property archived As String
    Public Property guids As New List(Of String)
    Public Property diagnosticSnapshot As String
    Public Property badRequest As String
    Public Property deepDivePolicy As New List(Of String)
    Public Property rangeSpecifier As New RangeSpecifier("BEFORE_NOW", 20160)

    Public Function toJSON() As String
        Return (JsonConvert.SerializeObject(Me))
    End Function
End Class

Public Class RangeSpecifier
    Public Property type As String
    Public Property durationInMinutes As Integer
    Public Sub New(typeIn As String, duration As Integer)
        type = typeIn
        durationInMinutes = duration
    End Sub
End Class

Public Class ProcessSnapshotDescriptor
    Public Property hasDeepDiveData As Boolean
    Public Property timeTakenInMilliSecs As Integer
    Public Property summary As String
    Public Property requestGUID As String
    Public Property serverStartTime As Long
    Public Status As String = "Not Loaded"
    Public ProcessSnapshotDetails As ProcessSnapshot
End Class

Public Class ProcessSnapshotList
    Public Property results As New List(Of ProcessSnapshotDescriptor)
    Public resultDictionary As New Dictionary(Of String, ProcessSnapshotDescriptor)
    Public Sub New()

    End Sub
    Public Sub New(json As String)
        Dim jArray As JArray = JArray.Parse(json)
        For Each result As JObject In jArray
            Dim tmpSnap As ProcessSnapshotDescriptor = result.ToObject(GetType(ProcessSnapshotDescriptor))
            results.Add(tmpSnap)
            resultDictionary.Add(tmpSnap.requestGUID, tmpSnap)
        Next
    End Sub
    Public Sub Add(snap As ProcessSnapshotDescriptor)
        If Not resultDictionary.ContainsKey(snap.requestGUID) Then
            results.Add(snap)
            resultDictionary.Add(snap.requestGUID, snap)
        End If
    End Sub
End Class

Public Class SnapshotsStatistics
    Public Property NumberOfSnapshots As Integer
    Public Property TotalExeTime As Integer
    Public Overrides Function ToString() As String
        Return NumberOfSnapshots.ToString() + " Snapshots" + vbCrLf + TotalExeTime.ToString() + " Total Time"
    End Function
End Class