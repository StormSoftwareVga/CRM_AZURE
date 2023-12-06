using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Storm.Tecnologia.Commom
{
    public interface IListItemValue
    {
        int Value { get; }
    }

    [DebuggerDisplay("{Index},{Description}")]
    public class ListItems<T> : IListItemValue where T : ListItems<T>, new()
    {
        private static IList<T> _items = new List<T>();

        public int Index { get; set; }

        public string Description { get; set; }

        int IListItemValue.Value => Index;

        public static ListItems<T> None => new ListItems<T>
        {
            Index = 0,
            Description = "None"
        };

        protected static IList<T> Items => _items;

        public static bool operator ==(ListItems<T> x, ListItems<T> y)
        {
            if ((object)x == y)
            {
                return true;
            }

            if ((object)x == null || (object)y == null)
            {
                return false;
            }

            return x.Index == y.Index;
        }

        public static bool operator !=(ListItems<T> x, ListItems<T> y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            ListItems<T> listItems = obj as ListItems<T>;
            if (obj == null)
            {
                return false;
            }

            return Index == listItems.Index;
        }

        public override int GetHashCode()
        {
            return Index;
        }

        public static T GetByIndex(int index)
        {
            T result = new T
            {
                Index = index,
                Description = string.Empty
            };
            T val = Items.FirstOrDefault((T x) => x.Index == index);
            if ((ListItems<T>)val == (ListItems<T>)null)
            {
                return result;
            }

            return val;
        }

        public static T GetByDescription(string description)
        {
            T result = new T
            {
                Index = 0,
                Description = description
            };
            T val = Items.FirstOrDefault((T x) => x.Description == description);
            if ((ListItems<T>)val == (ListItems<T>)null)
            {
                return result;
            }

            return val;
        }
    }
}
