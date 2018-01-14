using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace learn20180109
{
    class DoubleLinks
    {
        public void Objects(int nums, string names, int count)
        {
            number = nums;
            Name = names;
            Counter = count;
        }

        public int number
        {
            get { return number; }
            set { number= value; }
        }
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }
        public int Counter
        {
            get { return Counter; }
            set { Counter = value; }
        }
    }

    public class ListNode
    {
        //构造函数
        public ListNode(Object bugs)
        {
            goods = bugs;
        }

        public ListNode Previous;
        public ListNode Next;

        public ListNode next
        {
            get
            {
                return Next;
            }
            set { Next = value; }
        }

        public Object goods;

        public Object Goods
        {
            get { return goods; }
            set { goods = value; }
        }
        //定义链表类的实现代码
        public void Clists()
        {
            ListCountValue = 0;
            Head = null;
            Tail = null;
        }

        private string clistname = "";//表名

        public string ClistName
        {
            get { return clistname; }
            set { clistname = value; }
        }

        private ListNode Head;
        private ListNode Tail;
        private ListNode Current;

        public ListNode current
        {
            get { return Current; }
            set { Current = value; }
        }

        private int ListCountValue;//链表中数据的个数

        /// <summary>
        /// 往链表中加入数据
        /// </summary>
        /// <param name="DataValue"></param>
        public void Append(Object DataValue)
        {
            ListNode NewNode=new ListNode(DataValue);
            if (IsNull())
            {
                Head = NewNode;
                Tail = NewNode;
            }
            else
            {
                Tail.next = NewNode;
                NewNode.Previous = Tail;
                Tail = NewNode;
            }
            Current = NewNode;
            ListCountValue += 1;
        }

        public void Delete()
        {
            if (!IsNull())
            {
                if (IsBof())
                {
                    Head = Current.next;
                    Current = Head;
                    ListCountValue -= 1;
                    return;
                }
            }
            if (IsBof())
            {
                Tail = Current.Previous;
                Tail.next = null;
                Current = Tail;
                ListCountValue -= 1;
                return;
            }
            Current.Previous.Next = Current.Next;
            Current = Current.Previous;
            ListCountValue -= 1;
            return;
        }

        public void MoveNext()
        {
            if (!IsEof()) Current = Current.Next;
        }

        public void MovePrevious()
        {
            if (!IsBof()) Current = Current.Previous;
        }

        public void MoveFirst()
        {
            Current = Head;
        }

        public void MoveLast()
        {
            Current = Tail;
        }

        public bool IsNull()
        {
            if (ListCountValue == 0)
                return true;
            else
            {
                return false;
            }

        }

        public bool IsEof()
        {
            if (Current == Tail)
                return true;
            else
            {
                return false;
            }
        }

        public bool IsBof()
        {
            if (Current == Head)
                return true;
            else
            {
                return false;
            }
        }

        public Object GetCurrentValue()
        {
            return Current.goods;
        }

        public int ListCount
        {
            get{return ListCountValue;}
        }
        //清空链表
        public void Clear()
        {
            MoveFirst();
            while (!IsNull())
            {
                Delete();
            }
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="DataValue">插入位置</param>
        public void Insert(Object DataValue)
        {
            ListNode NewNode=new ListNode(DataValue);
            if (IsNull())
            {
                Append(DataValue);
                return;
            }
            if (IsBof())
            {
                //头部插入
                NewNode.Next = Head;
                Head.Previous = NewNode;
                Head = NewNode;
                Current = Head;
                ListCountValue += 1;
                return;
            }
            NewNode.Next = Current;
            NewNode.Previous = Current.Previous;
            Current.Previous.Next = Current.Previous;
            Current.Previous = NewNode;
            Current = NewNode;
            ListCountValue += 1;
        }
        /// <summary>
        /// 升序插入
        /// </summary>
        /// <param name="InsertValue">插入的数据</param>
        public void InsertAscending(Object InsertValue)
        {
            if (IsNull())//空链表
            {
                Append(InsertValue);
                return;
            }
            MoveFirst();
            if ((InsertValue.GetHashCode() < GetCurrentValue().GetHashCode()))
            {
                Insert(InsertValue);
                return;
            }
            while (true)
            {
                if ((InsertValue.GetHashCode() < GetCurrentValue().GetHashCode()))
                {
                    Insert(InsertValue);
                    break;
                }
                if (IsEof())
                {
                    Append(InsertValue);
                    break;
                }
                MoveNext();
            }
        }

        public void InsertUnAscending(Object InsertValue)
        {
            if (IsNull())
            {
                Append(InsertValue);
                return;
            }
            MoveFirst();
            if ((InsertValue.GetHashCode() > GetCurrentValue().GetHashCode()))
            {
                Insert(InsertValue);
                return;
            }
            while (true)
            {
                if ((InsertValue.GetHashCode() > GetCurrentValue().GetHashCode()))
                {
                    Insert(InsertValue);
                    break;
                }
                if (IsEof())
                {
                    Append(InsertValue);
                    break;
                }
                MoveNext();
            }
        }
    }
    

}
