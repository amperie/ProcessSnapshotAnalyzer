<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lstMethods = New WinControls.ListView.TreeListView()
        Me.className = New WinControls.ListView.ContainerColumnHeader()
        Me.methodName = New WinControls.ListView.ContainerColumnHeader()
        Me.SelfTime = New WinControls.ListView.ContainerColumnHeader()
        Me.TotalTime = New WinControls.ListView.ContainerColumnHeader()
        Me.ID = New WinControls.ListView.ContainerColumnHeader()
        Me.lstMethodSearch = New System.Windows.Forms.ListBox()
        Me.txtSearchMethod = New System.Windows.Forms.TextBox()
        Me.btnSearchMethod = New System.Windows.Forms.Button()
        Me.btnReRoot = New System.Windows.Forms.Button()
        Me.btnResetRoot = New System.Windows.Forms.Button()
        Me.txtMethodSummary = New System.Windows.Forms.TextBox()
        Me.btnSlowMethods = New System.Windows.Forms.Button()
        Me.txtUpper = New System.Windows.Forms.TextBox()
        Me.txtLower = New System.Windows.Forms.TextBox()
        Me.btnFindSlowMethods = New System.Windows.Forms.Button()
        Me.txtMinSelfTime = New System.Windows.Forms.TextBox()
        Me.txtMinTimeThreshold = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabMethodGraph = New System.Windows.Forms.TabPage()
        Me.tabSnapshotManager = New System.Windows.Forms.TabPage()
        Me.txtExeTime = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTierID = New System.Windows.Forms.TextBox()
        Me.txtAppID = New System.Windows.Forms.TextBox()
        Me.txtMaxRows = New System.Windows.Forms.TextBox()
        Me.lstLoadedSnaps = New WinControls.ListView.TreeListView()
        Me.ContainerColumnHeader5 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader6 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader7 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader8 = New WinControls.ListView.ContainerColumnHeader()
        Me.btnLoadInTree = New System.Windows.Forms.Button()
        Me.lstSnapshots = New WinControls.ListView.TreeListView()
        Me.ContainerColumnHeader1 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader2 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader3 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader4 = New WinControls.ListView.ContainerColumnHeader()
        Me.btnLoadSnapshots = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbLast = New System.Windows.Forms.ComboBox()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.btnAuthenticate = New System.Windows.Forms.Button()
        Me.txtControllerURL = New System.Windows.Forms.TextBox()
        Me.txtAccountName = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.tabMain.SuspendLayout()
        Me.tabMethodGraph.SuspendLayout()
        Me.tabSnapshotManager.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstMethods
        '
        Me.lstMethods.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMethods.Columns.AddRange(New WinControls.ListView.ContainerColumnHeader() {Me.className, Me.methodName, Me.SelfTime, Me.TotalTime, Me.ID})
        Me.lstMethods.Location = New System.Drawing.Point(3, 6)
        Me.lstMethods.Name = "lstMethods"
        Me.lstMethods.Size = New System.Drawing.Size(954, 537)
        Me.lstMethods.TabIndex = 0
        Me.lstMethods.VisualStyles = False
        '
        'className
        '
        Me.className.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.className.Text = "className"
        Me.className.Width = 662
        '
        'methodName
        '
        Me.methodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.methodName.Text = "methodName"
        Me.methodName.Width = 140
        '
        'SelfTime
        '
        Me.SelfTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelfTime.Text = "SelfTime"
        Me.SelfTime.Width = 75
        '
        'TotalTime
        '
        Me.TotalTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalTime.Text = "TotalTime"
        Me.TotalTime.Width = 75
        '
        'ID
        '
        Me.ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ID.Text = "ID"
        Me.ID.Width = 75
        '
        'lstMethodSearch
        '
        Me.lstMethodSearch.FormattingEnabled = True
        Me.lstMethodSearch.Location = New System.Drawing.Point(6, 582)
        Me.lstMethodSearch.Name = "lstMethodSearch"
        Me.lstMethodSearch.ScrollAlwaysVisible = True
        Me.lstMethodSearch.Size = New System.Drawing.Size(624, 251)
        Me.lstMethodSearch.TabIndex = 3
        '
        'txtSearchMethod
        '
        Me.txtSearchMethod.Location = New System.Drawing.Point(6, 556)
        Me.txtSearchMethod.Name = "txtSearchMethod"
        Me.txtSearchMethod.Size = New System.Drawing.Size(624, 20)
        Me.txtSearchMethod.TabIndex = 4
        Me.txtSearchMethod.Text = "lib::logCalEvent"
        '
        'btnSearchMethod
        '
        Me.btnSearchMethod.Location = New System.Drawing.Point(636, 583)
        Me.btnSearchMethod.Name = "btnSearchMethod"
        Me.btnSearchMethod.Size = New System.Drawing.Size(96, 24)
        Me.btnSearchMethod.TabIndex = 5
        Me.btnSearchMethod.Text = "Search Method"
        Me.btnSearchMethod.UseVisualStyleBackColor = True
        '
        'btnReRoot
        '
        Me.btnReRoot.Location = New System.Drawing.Point(636, 613)
        Me.btnReRoot.Name = "btnReRoot"
        Me.btnReRoot.Size = New System.Drawing.Size(96, 24)
        Me.btnReRoot.TabIndex = 6
        Me.btnReRoot.Text = "Set To Root"
        Me.btnReRoot.UseVisualStyleBackColor = True
        '
        'btnResetRoot
        '
        Me.btnResetRoot.Location = New System.Drawing.Point(636, 643)
        Me.btnResetRoot.Name = "btnResetRoot"
        Me.btnResetRoot.Size = New System.Drawing.Size(96, 24)
        Me.btnResetRoot.TabIndex = 7
        Me.btnResetRoot.Text = "Reset Root"
        Me.btnResetRoot.UseVisualStyleBackColor = True
        '
        'txtMethodSummary
        '
        Me.txtMethodSummary.Location = New System.Drawing.Point(636, 702)
        Me.txtMethodSummary.Multiline = True
        Me.txtMethodSummary.Name = "txtMethodSummary"
        Me.txtMethodSummary.Size = New System.Drawing.Size(175, 133)
        Me.txtMethodSummary.TabIndex = 8
        '
        'btnSlowMethods
        '
        Me.btnSlowMethods.Location = New System.Drawing.Point(636, 673)
        Me.btnSlowMethods.Name = "btnSlowMethods"
        Me.btnSlowMethods.Size = New System.Drawing.Size(96, 23)
        Me.btnSlowMethods.TabIndex = 9
        Me.btnSlowMethods.Text = "Find In Tree"
        Me.btnSlowMethods.UseVisualStyleBackColor = True
        '
        'txtUpper
        '
        Me.txtUpper.Location = New System.Drawing.Point(829, 571)
        Me.txtUpper.Name = "txtUpper"
        Me.txtUpper.Size = New System.Drawing.Size(23, 20)
        Me.txtUpper.TabIndex = 10
        Me.txtUpper.Text = "97"
        '
        'txtLower
        '
        Me.txtLower.Location = New System.Drawing.Point(829, 597)
        Me.txtLower.Name = "txtLower"
        Me.txtLower.Size = New System.Drawing.Size(23, 20)
        Me.txtLower.TabIndex = 11
        Me.txtLower.Text = "85"
        '
        'btnFindSlowMethods
        '
        Me.btnFindSlowMethods.Location = New System.Drawing.Point(738, 671)
        Me.btnFindSlowMethods.Name = "btnFindSlowMethods"
        Me.btnFindSlowMethods.Size = New System.Drawing.Size(128, 25)
        Me.btnFindSlowMethods.TabIndex = 12
        Me.btnFindSlowMethods.Text = "Search Slow Methods"
        Me.btnFindSlowMethods.UseVisualStyleBackColor = True
        '
        'txtMinSelfTime
        '
        Me.txtMinSelfTime.Location = New System.Drawing.Point(829, 623)
        Me.txtMinSelfTime.Name = "txtMinSelfTime"
        Me.txtMinSelfTime.Size = New System.Drawing.Size(23, 20)
        Me.txtMinSelfTime.TabIndex = 13
        Me.txtMinSelfTime.Text = "10"
        '
        'txtMinTimeThreshold
        '
        Me.txtMinTimeThreshold.Location = New System.Drawing.Point(829, 649)
        Me.txtMinTimeThreshold.Name = "txtMinTimeThreshold"
        Me.txtMinTimeThreshold.Size = New System.Drawing.Size(23, 20)
        Me.txtMinTimeThreshold.TabIndex = 14
        Me.txtMinTimeThreshold.Text = "55"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(776, 576)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Upper %"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(776, 600)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Lower %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(752, 626)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Min Self Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(746, 652)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Min Total Time"
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabMethodGraph)
        Me.tabMain.Controls.Add(Me.tabSnapshotManager)
        Me.tabMain.Controls.Add(Me.tabSettings)
        Me.tabMain.Location = New System.Drawing.Point(8, 12)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(968, 1011)
        Me.tabMain.TabIndex = 21
        '
        'tabMethodGraph
        '
        Me.tabMethodGraph.Controls.Add(Me.Label4)
        Me.tabMethodGraph.Controls.Add(Me.Label3)
        Me.tabMethodGraph.Controls.Add(Me.Label2)
        Me.tabMethodGraph.Controls.Add(Me.Label1)
        Me.tabMethodGraph.Controls.Add(Me.lstMethods)
        Me.tabMethodGraph.Controls.Add(Me.txtMinTimeThreshold)
        Me.tabMethodGraph.Controls.Add(Me.txtSearchMethod)
        Me.tabMethodGraph.Controls.Add(Me.txtMinSelfTime)
        Me.tabMethodGraph.Controls.Add(Me.lstMethodSearch)
        Me.tabMethodGraph.Controls.Add(Me.btnFindSlowMethods)
        Me.tabMethodGraph.Controls.Add(Me.txtMethodSummary)
        Me.tabMethodGraph.Controls.Add(Me.txtLower)
        Me.tabMethodGraph.Controls.Add(Me.btnSearchMethod)
        Me.tabMethodGraph.Controls.Add(Me.txtUpper)
        Me.tabMethodGraph.Controls.Add(Me.btnReRoot)
        Me.tabMethodGraph.Controls.Add(Me.btnSlowMethods)
        Me.tabMethodGraph.Controls.Add(Me.btnResetRoot)
        Me.tabMethodGraph.Location = New System.Drawing.Point(4, 22)
        Me.tabMethodGraph.Name = "tabMethodGraph"
        Me.tabMethodGraph.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMethodGraph.Size = New System.Drawing.Size(960, 985)
        Me.tabMethodGraph.TabIndex = 0
        Me.tabMethodGraph.Text = "Method Graph"
        Me.tabMethodGraph.UseVisualStyleBackColor = True
        '
        'tabSnapshotManager
        '
        Me.tabSnapshotManager.Controls.Add(Me.txtExeTime)
        Me.tabSnapshotManager.Controls.Add(Me.Label10)
        Me.tabSnapshotManager.Controls.Add(Me.lbl)
        Me.tabSnapshotManager.Controls.Add(Me.Label9)
        Me.tabSnapshotManager.Controls.Add(Me.Label8)
        Me.tabSnapshotManager.Controls.Add(Me.dateEnd)
        Me.tabSnapshotManager.Controls.Add(Me.dateStart)
        Me.tabSnapshotManager.Controls.Add(Me.Label7)
        Me.tabSnapshotManager.Controls.Add(Me.Label6)
        Me.tabSnapshotManager.Controls.Add(Me.Label5)
        Me.tabSnapshotManager.Controls.Add(Me.txtTierID)
        Me.tabSnapshotManager.Controls.Add(Me.txtAppID)
        Me.tabSnapshotManager.Controls.Add(Me.txtMaxRows)
        Me.tabSnapshotManager.Controls.Add(Me.lstLoadedSnaps)
        Me.tabSnapshotManager.Controls.Add(Me.btnLoadInTree)
        Me.tabSnapshotManager.Controls.Add(Me.lstSnapshots)
        Me.tabSnapshotManager.Controls.Add(Me.btnLoadSnapshots)
        Me.tabSnapshotManager.Controls.Add(Me.btnSearch)
        Me.tabSnapshotManager.Controls.Add(Me.cmbLast)
        Me.tabSnapshotManager.Location = New System.Drawing.Point(4, 22)
        Me.tabSnapshotManager.Name = "tabSnapshotManager"
        Me.tabSnapshotManager.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSnapshotManager.Size = New System.Drawing.Size(960, 985)
        Me.tabSnapshotManager.TabIndex = 1
        Me.tabSnapshotManager.Text = "Snapshot Manager"
        Me.tabSnapshotManager.UseVisualStyleBackColor = True
        '
        'txtExeTime
        '
        Me.txtExeTime.Location = New System.Drawing.Point(729, 170)
        Me.txtExeTime.Name = "txtExeTime"
        Me.txtExeTime.Size = New System.Drawing.Size(208, 20)
        Me.txtExeTime.TabIndex = 26
        Me.txtExeTime.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(649, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Exe Time"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(649, 146)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(27, 13)
        Me.lbl.TabIndex = 23
        Me.lbl.Text = "Last"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(650, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "End"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(650, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Start"
        '
        'dateEnd
        '
        Me.dateEnd.Enabled = False
        Me.dateEnd.Location = New System.Drawing.Point(729, 117)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(208, 20)
        Me.dateEnd.TabIndex = 20
        '
        'dateStart
        '
        Me.dateStart.Enabled = False
        Me.dateStart.Location = New System.Drawing.Point(729, 91)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(208, 20)
        Me.dateStart.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(650, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Tier ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(650, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Application ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(650, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Max Rows"
        '
        'txtTierID
        '
        Me.txtTierID.Location = New System.Drawing.Point(729, 65)
        Me.txtTierID.Name = "txtTierID"
        Me.txtTierID.Size = New System.Drawing.Size(208, 20)
        Me.txtTierID.TabIndex = 12
        Me.txtTierID.Text = "14314"
        '
        'txtAppID
        '
        Me.txtAppID.Location = New System.Drawing.Point(729, 39)
        Me.txtAppID.Name = "txtAppID"
        Me.txtAppID.Size = New System.Drawing.Size(208, 20)
        Me.txtAppID.TabIndex = 11
        Me.txtAppID.Text = "5196"
        '
        'txtMaxRows
        '
        Me.txtMaxRows.Location = New System.Drawing.Point(729, 13)
        Me.txtMaxRows.Name = "txtMaxRows"
        Me.txtMaxRows.Size = New System.Drawing.Size(208, 20)
        Me.txtMaxRows.TabIndex = 10
        Me.txtMaxRows.Text = "20"
        '
        'lstLoadedSnaps
        '
        Me.lstLoadedSnaps.Columns.AddRange(New WinControls.ListView.ContainerColumnHeader() {Me.ContainerColumnHeader5, Me.ContainerColumnHeader6, Me.ContainerColumnHeader7, Me.ContainerColumnHeader8})
        Me.lstLoadedSnaps.DefaultImageIndex = -1
        Me.lstLoadedSnaps.DefaultSelectedImageIndex = -1
        Me.lstLoadedSnaps.Location = New System.Drawing.Point(6, 382)
        Me.lstLoadedSnaps.MultiSelect = True
        Me.lstLoadedSnaps.Name = "lstLoadedSnaps"
        Me.lstLoadedSnaps.Size = New System.Drawing.Size(634, 353)
        Me.lstLoadedSnaps.TabIndex = 9
        Me.lstLoadedSnaps.VisualStyles = False
        '
        'ContainerColumnHeader5
        '
        Me.ContainerColumnHeader5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader5.Text = "GUID"
        '
        'ContainerColumnHeader6
        '
        Me.ContainerColumnHeader6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader6.Text = "Date"
        '
        'ContainerColumnHeader7
        '
        Me.ContainerColumnHeader7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader7.Text = "Time Spent"
        '
        'ContainerColumnHeader8
        '
        Me.ContainerColumnHeader8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader8.Text = "Status"
        '
        'btnLoadInTree
        '
        Me.btnLoadInTree.Location = New System.Drawing.Point(646, 307)
        Me.btnLoadInTree.Name = "btnLoadInTree"
        Me.btnLoadInTree.Size = New System.Drawing.Size(87, 35)
        Me.btnLoadInTree.TabIndex = 8
        Me.btnLoadInTree.Text = "Load in main Tree"
        Me.btnLoadInTree.UseVisualStyleBackColor = True
        '
        'lstSnapshots
        '
        Me.lstSnapshots.Columns.AddRange(New WinControls.ListView.ContainerColumnHeader() {Me.ContainerColumnHeader1, Me.ContainerColumnHeader2, Me.ContainerColumnHeader3, Me.ContainerColumnHeader4})
        Me.lstSnapshots.DefaultImageIndex = -1
        Me.lstSnapshots.DefaultSelectedImageIndex = -1
        Me.lstSnapshots.Location = New System.Drawing.Point(6, 6)
        Me.lstSnapshots.MultiSelect = True
        Me.lstSnapshots.Name = "lstSnapshots"
        Me.lstSnapshots.Size = New System.Drawing.Size(634, 353)
        Me.lstSnapshots.TabIndex = 0
        Me.lstSnapshots.VisualStyles = False
        '
        'ContainerColumnHeader1
        '
        Me.ContainerColumnHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader1.Text = "GUID"
        '
        'ContainerColumnHeader2
        '
        Me.ContainerColumnHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader2.Text = "Date"
        '
        'ContainerColumnHeader3
        '
        Me.ContainerColumnHeader3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader3.Text = "Time Spent"
        '
        'ContainerColumnHeader4
        '
        Me.ContainerColumnHeader4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerColumnHeader4.Text = "Status"
        '
        'btnLoadSnapshots
        '
        Me.btnLoadSnapshots.Location = New System.Drawing.Point(646, 256)
        Me.btnLoadSnapshots.Name = "btnLoadSnapshots"
        Me.btnLoadSnapshots.Size = New System.Drawing.Size(87, 45)
        Me.btnLoadSnapshots.TabIndex = 7
        Me.btnLoadSnapshots.Text = "Load Selected Snapshots"
        Me.btnLoadSnapshots.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(646, 213)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 37)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbLast
        '
        Me.cmbLast.FormattingEnabled = True
        Me.cmbLast.Items.AddRange(New Object() {"15", "30", "60", "180", "1440", "2880", "5760", "11520", "20160"})
        Me.cmbLast.Location = New System.Drawing.Point(729, 143)
        Me.cmbLast.Name = "cmbLast"
        Me.cmbLast.Size = New System.Drawing.Size(208, 21)
        Me.cmbLast.TabIndex = 5
        Me.cmbLast.Text = "20160"
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.btnAuthenticate)
        Me.tabSettings.Controls.Add(Me.txtControllerURL)
        Me.tabSettings.Controls.Add(Me.txtAccountName)
        Me.tabSettings.Controls.Add(Me.txtUsername)
        Me.tabSettings.Controls.Add(Me.txtPassword)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSettings.Size = New System.Drawing.Size(960, 985)
        Me.tabSettings.TabIndex = 2
        Me.tabSettings.Text = "Settings"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'btnAuthenticate
        '
        Me.btnAuthenticate.Location = New System.Drawing.Point(15, 122)
        Me.btnAuthenticate.Name = "btnAuthenticate"
        Me.btnAuthenticate.Size = New System.Drawing.Size(77, 29)
        Me.btnAuthenticate.TabIndex = 5
        Me.btnAuthenticate.Text = "Authenticate"
        Me.btnAuthenticate.UseVisualStyleBackColor = True
        '
        'txtControllerURL
        '
        Me.txtControllerURL.Location = New System.Drawing.Point(15, 18)
        Me.txtControllerURL.Name = "txtControllerURL"
        Me.txtControllerURL.Size = New System.Drawing.Size(310, 20)
        Me.txtControllerURL.TabIndex = 4
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(15, 44)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Size = New System.Drawing.Size(147, 20)
        Me.txtAccountName.TabIndex = 1
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(15, 70)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(147, 20)
        Me.txtUsername.TabIndex = 2
        Me.txtUsername.Text = "psalanova"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(15, 96)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(147, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 876)
        Me.Controls.Add(Me.tabMain)
        Me.Name = "Form1"
        Me.Text = "Snapshot Analyzer"
        Me.tabMain.ResumeLayout(False)
        Me.tabMethodGraph.ResumeLayout(False)
        Me.tabMethodGraph.PerformLayout()
        Me.tabSnapshotManager.ResumeLayout(False)
        Me.tabSnapshotManager.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.tabSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstMethods As WinControls.ListView.TreeListView
    Friend WithEvents className As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents methodName As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents SelfTime As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents TotalTime As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ID As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents lstMethodSearch As ListBox
    Friend WithEvents txtSearchMethod As TextBox
    Friend WithEvents btnSearchMethod As Button
    Friend WithEvents btnReRoot As Button
    Friend WithEvents btnResetRoot As Button
    Friend WithEvents txtMethodSummary As TextBox
    Friend WithEvents btnSlowMethods As Button
    Friend WithEvents txtUpper As TextBox
    Friend WithEvents txtLower As TextBox
    Friend WithEvents btnFindSlowMethods As Button
    Friend WithEvents txtMinSelfTime As TextBox
    Friend WithEvents txtMinTimeThreshold As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabMethodGraph As TabPage
    Friend WithEvents tabSnapshotManager As TabPage
    Friend WithEvents lstSnapshots As WinControls.ListView.TreeListView
    Friend WithEvents tabSettings As TabPage
    Friend WithEvents txtControllerURL As TextBox
    Friend WithEvents txtAccountName As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLoadInTree As Button
    Friend WithEvents btnLoadSnapshots As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents cmbLast As ComboBox
    Friend WithEvents ContainerColumnHeader1 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader2 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader3 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader4 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents lstLoadedSnaps As WinControls.ListView.TreeListView
    Friend WithEvents ContainerColumnHeader5 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader6 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader7 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader8 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTierID As TextBox
    Friend WithEvents txtAppID As TextBox
    Friend WithEvents txtMaxRows As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dateEnd As DateTimePicker
    Friend WithEvents dateStart As DateTimePicker
    Friend WithEvents lbl As Label
    Friend WithEvents txtExeTime As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnAuthenticate As Button
End Class
