Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports WinControls.ListView

Public Class MethodNode
    Public Property methodType As String
    Public Property name As String
    Public Property className As String
    Public Property methodName As String
    Public Property lineNumber As Integer
    Public Property looping As Boolean
    Public Property loopcount As Integer
    Public Property timeSpentInMilliSec As Integer
    Public selfTime As Integer
    Public childrenTime As Integer
    Public Property children As List(Of MethodNode)
    Public Property blockTime As Integer
    Public Property waitTime As Integer
    Public Property cpuTime As Integer
    Public ParentProcessSnapshot As ProcessSnapshot
    Public ID As String
    Public AssociatedTreeViewNode As TreeListNode = Nothing
    Private IDCounter As Integer = 1

    Public Shared Function CompareByTotalTime(Left As MethodNode, right As MethodNode) As Integer
        If Left.timeSpentInMilliSec < right.timeSpentInMilliSec Then Return -1
        If Left.timeSpentInMilliSec > right.timeSpentInMilliSec Then Return 1
        Return 0
    End Function

    Public Sub CalculateTimings()
        childrenTime = 0
        If Not IsNothing(children) Then
            For Each childNode As MethodNode In children
                childNode.CalculateTimings()
                childrenTime += childNode.timeSpentInMilliSec
            Next
        End If
        selfTime = timeSpentInMilliSec - childrenTime
    End Sub

    Public Sub SetNodeIDs(prefix As String)
        Me.ID = prefix + Me.IDCounter.ToString()
        Dim rootNode As MethodNode = Me
        SetNodeIDsInternal(prefix, rootNode, rootNode)
    End Sub

    Private Function GetNextID(rootNode As MethodNode) As Integer
        rootNode.IDCounter += 1
        Return rootNode.IDCounter
    End Function

    Private Sub SetNodeIDsInternal(prefix As String, rootNode As MethodNode, node As MethodNode)
        If Not IsNothing(node.children) Then
            For Each childNode As MethodNode In node.children
                childNode.ID = prefix + GetNextID(rootNode).ToString()
                SetNodeIDsInternal(prefix, rootNode, childNode)
            Next
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return className + "::" + methodName + "    Self: " + selfTime.ToString + "    Total: " + timeSpentInMilliSec.ToString
    End Function

End Class

Public Class MethodSummary
    Public Property className As String
    Public Property methodName As String
    Public Property CallCount As Integer = 0
    Public Property AvgSelfTime As Double = 0
    Public Property AvgTotalTime As Double = 0
    Public Property MinSelfTime As Integer = 0
    Public Property MinTotalTime As Integer = 0
    Public Property MaxSelfTime As Integer = 0
    Public Property MaxTotalTime As Integer = 0
    Public Property TotalTime As Integer = 0
    Public Property TotalSelfTime As Integer = 0
    Public Property TotalTimeStdDev As Double = 0

    Public Shared Function SummarizeMethodList(methods As List(Of MethodNode)) As MethodSummary
        Dim retVal As New MethodSummary
        If methods.Count = 0 Then Return retVal
        retVal.className = methods(0).className
        retVal.methodName = methods(0).methodName

        For Each method As MethodNode In methods
            retVal.CallCount += 1
            retVal.TotalTime += method.timeSpentInMilliSec
            retVal.TotalSelfTime += method.selfTime
            retVal.MaxTotalTime = Math.Max(retVal.MaxTotalTime, method.timeSpentInMilliSec)
            retVal.MaxSelfTime = Math.Max(retVal.MaxSelfTime, method.selfTime)
            retVal.MinTotalTime = Math.Min(retVal.MinTotalTime, method.timeSpentInMilliSec)
            retVal.MinSelfTime = Math.Min(retVal.MinSelfTime, method.selfTime)
        Next
        If retVal.CallCount = 0 Then Return retval
        retVal.AvgSelfTime = retVal.TotalSelfTime / retVal.CallCount
        retVal.AvgTotalTime = Math.Round(retVal.TotalTime / retVal.CallCount)

        Dim summation As Integer = 0
        For Each method As MethodNode In methods
            summation += (method.timeSpentInMilliSec - retVal.AvgTotalTime) ^ 2
        Next
        retVal.TotalTimeStdDev = Math.Round(Math.Sqrt(summation / retVal.CallCount))
        Return retVal

    End Function

    Public Overrides Function ToString() As String
        Return "Method: " + className + "::" + methodName + vbCrLf +
            "CallCount: " + CallCount.ToString() + vbCrLf +
            "TotalTime: " + TotalTime.ToString() + vbCrLf +
            "AvgTotalTime: " + AvgTotalTime.ToString() + vbCrLf +
            "TotalTimeStdDev: " + TotalTimeStdDev.ToString() + vbCrLf +
            "MaxTime: " + MaxTotalTime.ToString() + vbCrLf +
            "MinTime: " + MinTotalTime.ToString() + vbCrLf
    End Function

End Class

Public Class ProcessSnapshot
    Public Property Roots As New List(Of MethodNode)
    Public Property GUID As String = "000"
    Public MethodDictionary As Dictionary(Of String, List(Of MethodNode))

    Public Sub New(json As String)
        Dim jArray As JArray = JArray.Parse(json)

        For Each node As JObject In jArray
            Dim tmpNode As MethodNode = node.ToObject(GetType(MethodNode))
            Roots.Add(tmpNode)
        Next
        PostProcess()

    End Sub

    Private Sub PostProcess()

        CalculateTimings()
        SetNodeIDs()
        BuildMethodDictionary()
        SetParentSnapshot()

    End Sub

    Private Sub CalculateTimings()

        For Each node As MethodNode In Roots
            node.CalculateTimings()
        Next

    End Sub

    Private Sub SetNodeIDs()

        Dim RootID As Integer = 1
        For Each node As MethodNode In Roots
            node.SetNodeIDs("Root" + RootID.ToString() + "-")
            RootID += 1
        Next

    End Sub

    Private Sub BuildMethodDictionary()
        MethodDictionary = New Dictionary(Of String, List(Of MethodNode))

        For Each node As MethodNode In Roots
            BuildMethodDictionaryInternal(node)
        Next

    End Sub

    Private Sub BuildMethodDictionaryInternal(node As MethodNode)
        Dim key As String

        If Not IsNothing(node.children) Then
            For Each childNode As MethodNode In node.children
                key = GenerateClassMethodName(childNode)
                If Not MethodDictionary.ContainsKey(key) Then
                    MethodDictionary.Add(key, New List(Of MethodNode))
                End If
                MethodDictionary(key).Add(childNode)
                BuildMethodDictionaryInternal(childNode)
            Next
        End If
    End Sub

    Public Sub SetParentSnapshot()
        For Each tmpNode As MethodNode In Roots
            tmpNode.ParentProcessSnapshot = Me
            SetParentSnapshotInternal(tmpNode)
        Next
    End Sub

    Public Sub SetParentSnapshotInternal(node As MethodNode)
        If Not IsNothing(node.children) Then
            For Each childNode As MethodNode In node.children
                childNode.ParentProcessSnapshot = Me
                SetParentSnapshotInternal(childNode)
            Next
        End If
    End Sub

    Public Sub PopulateTreeListView(treeView As TreeListView)
        treeView.Nodes.Clear()
        For Each root In Roots
            Dim tmpTreeViewNode As New TreeListNode
            GenerateTreeViewNode(tmpTreeViewNode, root)
            treeView.Nodes.Add(tmpTreeViewNode)
        Next
    End Sub

    Public Function GenerateTreeViewNode(treeViewNode As TreeListNode, currentMethodNode As MethodNode) As TreeListNode
        treeViewNode.Text = GenerateClassMethodName(currentMethodNode)
        treeViewNode.SubItems.Add(currentMethodNode.methodName)
        treeViewNode.SubItems.Add(currentMethodNode.selfTime)
        treeViewNode.SubItems.Add(currentMethodNode.timeSpentInMilliSec)
        treeViewNode.SubItems.Add(currentMethodNode.ID)

        If Not IsNothing(currentMethodNode.children) Then
            For Each childNode In currentMethodNode.children
                Dim tmpTreeViewNode As TreeListNode
                tmpTreeViewNode = GenerateTreeViewNode(New TreeListNode(), childNode)
                treeViewNode.Nodes.Add(tmpTreeViewNode)
                childNode.AssociatedTreeViewNode = tmpTreeViewNode
            Next
        End If
        Return treeViewNode
    End Function

    Public Sub ReRootTreeView(treeView As TreeListView, rootNode As MethodNode)
        Dim newRoot As TreeListNode = GenerateReRootedTreeView(rootNode)
        treeView.Nodes.Clear()
        treeView.Nodes.Add(newRoot)
    End Sub

    Public Function GenerateReRootedTreeView(rootNode As MethodNode) As TreeListNode
        Dim retVal As New TreeListNode
        GenerateTreeViewNode(retVal, rootNode)
        Return retVal
    End Function

    Public Function FindMethodNodes(ClassMethod As String) As List(Of MethodNode)
        If MethodDictionary.ContainsKey(ClassMethod) Then
            Return MethodDictionary(ClassMethod)
        Else
            Return New List(Of MethodNode)
        End If
    End Function

    Public Function FindMethodNodes(className As String, methodName As String) As List(Of MethodNode)
        Dim key As String = GenerateClassMethodName(className, methodName)
        Return FindMethodNodes(key)
    End Function

    Private Function GenerateClassMethodName(node As MethodNode) As String
        Return GenerateClassMethodName(node.className, node.methodName)
    End Function

    Private Function GenerateClassMethodName(className As String, methodName As String) As String
        Return className + "::" + methodName
    End Function

    Public Function FindSlowMethods(criteria As MethodSearchCriteria) As List(Of MethodNode)

        Dim retVal As New List(Of MethodNode)
        For Each root As MethodNode In Roots
            FindSlowMethodRecursive(root, criteria, retVal)
        Next
        Return retVal

    End Function

    Public Sub FindSlowMethodRecursive(method As MethodNode, criteria As MethodSearchCriteria,
                                            SlowMethodList As List(Of MethodNode))

        'find longest child and test that criteria
        If Not IsNothing(method.children) Then
            Dim LongestChildTotal As Integer = 0
            For Each childNode In method.children
                LongestChildTotal = Math.Max(LongestChildTotal, childNode.timeSpentInMilliSec)
            Next
            If LongestChildTotal / method.timeSpentInMilliSec * 100 < CDbl(criteria.LowerPctBound) And
                                        method.timeSpentInMilliSec > criteria.MinTotalTimeThreshold Then
                SlowMethodList.Add(method)
            End If
        End If

        If Not IsNothing(method.children) Then
            For Each childNode In method.children
                'test criteria 
                'if we're at the lowest level and method self time is high
                If IsNothing(childNode.children) And childNode.selfTime > criteria.MinSelfTime Then
                    SlowMethodList.Add(childNode)
                End If
                FindSlowMethodRecursive(childNode, criteria, SlowMethodList)
            Next
        End If

    End Sub

End Class

Public Class MethodSearchCriteria
    Public Property MinSelfTime As Integer
    Public Property UpperPctBound As Integer
    Public Property LowerPctBound As Integer
    Public Property MinTotalTimeThreshold As Integer
End Class