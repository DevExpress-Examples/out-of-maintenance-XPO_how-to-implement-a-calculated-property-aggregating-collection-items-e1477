Namespace DetailCollectionChanged

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim gridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
            Me.gridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colOid1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colAmount = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.xpCollection1 = New DevExpress.Xpo.XPCollection()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colOid = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colTotals = New DevExpress.XtraGrid.Columns.GridColumn()
            CType((Me.gridView2), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.xpCollection1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridView2
            ' 
            Me.gridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOid1, Me.colAmount})
            Me.gridView2.GridControl = Me.gridControl1
            Me.gridView2.Name = "gridView2"
            Me.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            Me.gridView2.OptionsView.ShowGroupPanel = False
            ' 
            ' colOid1
            ' 
            Me.colOid1.FieldName = "Oid"
            Me.colOid1.Name = "colOid1"
            Me.colOid1.Visible = True
            Me.colOid1.VisibleIndex = 0
            ' 
            ' colAmount
            ' 
            Me.colAmount.FieldName = "Amount"
            Me.colAmount.Name = "colAmount"
            Me.colAmount.Visible = True
            Me.colAmount.VisibleIndex = 1
            ' 
            ' gridControl1
            ' 
            Me.gridControl1.DataSource = Me.xpCollection1
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            gridLevelNode1.LevelTemplate = Me.gridView2
            gridLevelNode1.RelationName = "Children"
            Me.gridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {gridLevelNode1})
            Me.gridControl1.Location = New System.Drawing.Point(0, 0)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.ShowOnlyPredefinedDetails = True
            Me.gridControl1.Size = New System.Drawing.Size(622, 413)
            Me.gridControl1.TabIndex = 0
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1, Me.gridView2})
            ' 
            ' xpCollection1
            ' 
            Me.xpCollection1.DisplayableProperties = "This;Oid;Children;Totals"
            Me.xpCollection1.ObjectType = GetType(DetailCollectionChanged.Parent)
            ' 
            ' gridView1
            ' 
            Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOid, Me.colTotals})
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            Me.gridView1.OptionsDetail.AllowExpandEmptyDetails = True
            Me.gridView1.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
            Me.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            Me.gridView1.OptionsView.ShowGroupPanel = False
            ' 
            ' colOid
            ' 
            Me.colOid.FieldName = "Oid"
            Me.colOid.Name = "colOid"
            Me.colOid.Visible = True
            Me.colOid.VisibleIndex = 0
            ' 
            ' colTotals
            ' 
            Me.colTotals.FieldName = "Totals"
            Me.colTotals.Name = "colTotals"
            Me.colTotals.OptionsColumn.[ReadOnly] = True
            Me.colTotals.Visible = True
            Me.colTotals.VisibleIndex = 1
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(622, 413)
            Me.Controls.Add(Me.gridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.gridView2), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.xpCollection1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private gridControl1 As DevExpress.XtraGrid.GridControl

        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView

        Private xpCollection1 As DevExpress.Xpo.XPCollection

        Private gridView2 As DevExpress.XtraGrid.Views.Grid.GridView

        Private colOid1 As DevExpress.XtraGrid.Columns.GridColumn

        Private colAmount As DevExpress.XtraGrid.Columns.GridColumn

        Private colOid As DevExpress.XtraGrid.Columns.GridColumn

        Private colTotals As DevExpress.XtraGrid.Columns.GridColumn
    End Class
End Namespace
