using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Data.Filtering;

namespace DetailCollectionChanged {
    public class Parent : XPObject {

        public Parent(Session session)
            : base(session) {
        }

        [Association("ParentChildren")]
        public XPCollection<Child> Children {
            get { return GetCollection<Child>("Children"); }
        }

        protected override XPCollection<T> CreateCollection<T>(DevExpress.Xpo.Metadata.XPMemberInfo property) {
            XPCollection<T> col = base.CreateCollection<T>(property);
            if(property.Name == "Children")
                col.CollectionChanged += new XPCollectionChangedEventHandler(col_CollectionChanged);
            return col;
        }

        void col_CollectionChanged(object sender, XPCollectionChangedEventArgs e) {
            // call TotalsChanged if the grid is not the only control that modifies the Children collection 
        }

        // non-persistent
        // TODO cache calculated values if performance is affected
        public decimal? Totals {
            get {
                if(!Children.IsLoaded)
                    return (decimal?)Session.Evaluate<Child>(CriteriaOperator.Parse("Sum(Amount)"), new OperandProperty("Parent") == new OperandValue(this));

                decimal total = 0;
                foreach (Child c in Children)
                    total += c.Amount;
                return total;
            }
        }

        internal void TotalsChanged() {
            OnChanged("Totals");
        }
    }


    public class Child : XPObject {

        public Child(Session session)
            : base(session) {
        }

        Parent fParent;
        [Association("ParentChildren")]
        public Parent Parent {
            get {
                return fParent;
            }
            set {
                SetPropertyValue("Parent", ref fParent, value);
            }
        }

        private decimal fAmount;
        public decimal Amount {
            get { return fAmount; }
            set {
                if(fAmount != value) {
                    fAmount = value;
                    OnChanged("Amount");

                    if(!IsLoading && Parent != null) {
                        ((IEditableObject)Parent).EndEdit();
                        Parent.TotalsChanged();
                    }
                }
            }
        }
    }
}