Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data.Filtering

Namespace DetailCollectionChanged

    Public Class Parent
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        <Association("ParentChildren")>
        Public ReadOnly Property Children As XPCollection(Of Child)
            Get
                Return GetCollection(Of Child)("Children")
            End Get
        End Property

        Protected Overrides Function CreateCollection(Of T)(ByVal [property] As Metadata.XPMemberInfo) As XPCollection(Of T)
            Dim col As XPCollection(Of T) = CreateCollection(Of T)([property])
            If Equals([property].Name, "Children") Then AddHandler col.CollectionChanged, New XPCollectionChangedEventHandler(AddressOf col_CollectionChanged)
            Return col
        End Function

        Private Sub col_CollectionChanged(ByVal sender As Object, ByVal e As XPCollectionChangedEventArgs)
        ' call TotalsChanged if the grid is not the only control that modifies the Children collection 
        End Sub

        ' non-persistent
        ' TODO cache calculated values if performance is affected
        Public ReadOnly Property Totals As Decimal?
            Get
                If Not Children.IsLoaded Then Return CType(Session.Evaluate(Of Child)(CriteriaOperator.Parse("Sum(Amount)"), New OperandProperty("Parent") Is New OperandValue(Me)), Decimal?)
                Dim total As Decimal = 0
                For Each c As Child In Children
                    total += c.Amount
                Next

                Return total
            End Get
        End Property

        Friend Sub TotalsChanged()
            OnChanged("Totals")
        End Sub
    End Class

    Public Class Child
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private fParent As Parent

        <Association("ParentChildren")>
        Public Property Parent As Parent
            Get
                Return fParent
            End Get

            Set(ByVal value As Parent)
                SetPropertyValue("Parent", fParent, value)
            End Set
        End Property

        Private fAmount As Decimal

        Public Property Amount As Decimal
            Get
                Return fAmount
            End Get

            Set(ByVal value As Decimal)
                If fAmount <> value Then
                    fAmount = value
                    OnChanged("Amount")
                    If Not IsLoading AndAlso Parent IsNot Nothing Then
                        CType(Parent, IEditableObject).EndEdit()
                        Parent.TotalsChanged()
                    End If
                End If
            End Set
        End Property
    End Class
End Namespace
