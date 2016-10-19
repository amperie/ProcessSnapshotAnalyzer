Imports System.IO
Imports WinControls.ListView.EventArgClasses
Imports WinControls.ListView

Public Class Form1

    Private sM As SnapshotManager

    Private Sub btnSearchMethod_Click(sender As Object, e As EventArgs) Handles btnSearchMethod.Click

        Dim methods As List(Of MethodNode) = sM.FindMethodNodes(txtSearchMethod.Text)
        PopulateMethodSearchListBox(methods)

    End Sub

    Private Sub PopulateMethodSearchListBox(methods As List(Of MethodNode))
        lstMethodSearch.Items.Clear()
        For Each node As MethodNode In methods
            lstMethodSearch.Items.Add(node)
        Next
    End Sub

    Private Sub btnReRoot_Click(sender As Object, e As EventArgs) Handles btnReRoot.Click
        Dim newRoot As MethodNode
        newRoot = lstMethodSearch.SelectedItem()

        sM.ReRootMainMethodTree(lstMethods, newRoot)
    End Sub

    Private Sub btnResetRoot_Click(sender As Object, e As EventArgs) Handles btnResetRoot.Click
        sM.UpdateMainMethodTree(lstMethods)
    End Sub

    Private Sub lstMethods_AfterSelect(sender As Object, e As ContainerListViewEventArgs) Handles lstMethods.AfterSelect
        txtSearchMethod.Text = lstMethods.SelectedItems.Item(0).Text
        Dim MethodList As List(Of MethodNode)
        MethodList = sM.FindMethodNodes(lstMethods.SelectedItems.Item(0).Text)
        Dim MethodSummarized As MethodSummary = MethodSummary.SummarizeMethodList(MethodList)
        txtMethodSummary.Text = MethodSummarized.ToString()
    End Sub

    Private Sub lstMethodSearch_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstMethodSearch.SelectedValueChanged
        Try
            Dim tmpNode As MethodNode = lstMethodSearch.SelectedItem
            txtSearchMethod.Text = tmpNode.AssociatedTreeViewNode.Text
            Dim MethodList As List(Of MethodNode)
            MethodList = sM.FindMethodNodes(tmpNode.AssociatedTreeViewNode.Text)
            Dim MethodSummarized As MethodSummary = MethodSummary.SummarizeMethodList(MethodList)
            txtMethodSummary.Text = MethodSummarized.ToString()
        Catch ex As Exception
            MsgBox("Minor Exception: " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub btnSlowMethods_Click(sender As Object, e As EventArgs) Handles btnSlowMethods.Click
        'Dim node As TreeListNode
        'node = procSnapshot.FindTreeListNodeByID("Root1-10", lstMethods)
        'node.Expand()
        lstMethods.CollapseAll()
        Dim newRoot As MethodNode
        newRoot = lstMethodSearch.SelectedItem()
        ExpandFromNodeToTop(newRoot.AssociatedTreeViewNode)
    End Sub

    Private Sub ExpandFromNodeToTop(treeNode As TreeListNode)
        Dim tmpNode As TreeListNode = treeNode
        While Not IsNothing(tmpNode)
            tmpNode.Expand()
            tmpNode = tmpNode.ParentNode
        End While
    End Sub

    Private Sub btnFindSlowMethods_Click(sender As Object, e As EventArgs) Handles btnFindSlowMethods.Click
        Dim criteria As New MethodSearchCriteria
        criteria.LowerPctBound = txtLower.Text
        criteria.UpperPctBound = txtUpper.Text
        criteria.MinSelfTime = txtMinSelfTime.Text
        criteria.MinTotalTimeThreshold = txtMinTimeThreshold.Text
        Dim methods As List(Of MethodNode) = sM.FindSlowMethods(criteria)
        methods.Sort(AddressOf MethodNode.CompareByTotalTime)
        PopulateMethodSearchListBox(methods)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim criteria As New ProcessSnapshotSearchCriteria()
        criteria.firstInChain = False
        criteria.rangeSpecifier = New RangeSpecifier("BEFORE_NOW", CInt(cmbLast.Text))
        criteria.applicationIds = New List(Of Integer)
        criteria.applicationIds.Add(CInt(txtAppID.Text))
        criteria.applicationComponentIds = New List(Of Integer)
        criteria.applicationComponentIds.Add(CInt(txtTierID.Text))
        criteria.maxRows = CInt(txtMaxRows.Text)
        criteria.executionTimeInMilis = CInt(txtExeTime.Text)

        sM.SearchSnapshots(criteria)
        sM.UpdateSMTreeViews(lstSnapshots, lstLoadedSnaps)

    End Sub

    Private Sub btnLoadSnapshots_Click(sender As Object, e As EventArgs) Handles btnLoadSnapshots.Click
        For Each snap As TreeListNode In lstSnapshots.SelectedItems
            sM.LoadSnapshotFromServer(snap.Text)
        Next
        sM.UpdateSMTreeViews(lstSnapshots, lstLoadedSnaps)
    End Sub

    Private Sub btnLoadInTree_Click(sender As Object, e As EventArgs) Handles btnLoadInTree.Click
        For Each snap As TreeListNode In lstLoadedSnaps.SelectedItems
            sM.AddSnapshotsToAnalyze(snap.Text)
        Next
        sM.UpdateMainMethodTree(lstMethods)
        tabMain.SelectTab(0)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dateStart.Value = Date.Today.AddDays(-1)
        dateEnd.Value = Date.Today

        Dim c As New ControllerInfo
        c.URL = txtControllerURL.Text
        c.User = txtUsername.Text
        c.Pass = txtPassword.Text
        c.AccountName = txtAccountName.Text
        sM = New SnapshotManager(c)

    End Sub

    Private Sub cmbLast_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbLast.SelectedValueChanged
        dateStart.Value = Date.Today.AddMinutes(CInt(-cmbLast.Text))
        dateEnd.Value = Date.Today
    End Sub

    Private Sub btnAuthenticate_Click(sender As Object, e As EventArgs) Handles btnAuthenticate.Click
        Dim c As New ControllerInfo
        c.URL = txtControllerURL.Text
        c.User = txtUsername.Text
        c.Pass = txtPassword.Text
        c.AccountName = txtAccountName.Text
        sM.Authenticate(c)
    End Sub

End Class
