namespace CSharp.Activity.Collections
{
    public class CustomerInfoCollection<CustomerInfo>
    {
        List<CustomerInfo> informationBase;
        public int defaultSize = 20;
        public int count { get; protected set; }
        public CustomerInfoCollection()
        {
            informationBase = new List<CustomerInfo>(defaultSize);
        }

        public int Add(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Object is null!");
            }
            if (informationBase.Contains(info))
            {
                return -1;
            }
            informationBase.Add(info);
            count++;

            return informationBase.IndexOf(info);
        }

        public void Insert(int index, CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Object is null!");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out of the boundaries!");
            }

            if (!Contains(info))
            {
                informationBase.Insert(index, info);
                count++;
            }
        }

        public void Remove(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Argument is null!");
            }

            RemoveAt(IndexOf(info));
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Removing is not possible!");
            }

            for (int i = index; i < count - 1; i++)
            {
                informationBase[i] = informationBase[i + 1];
            }

            informationBase.RemoveAt(count - 1);
            count--;
        }

        public bool Contains(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Object is null!");
            }

            if (!informationBase.Contains(info))
            {
                return false;
            }

            return true;
        }

        public int IndexOf(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Collection does not contain indicated object!");
            }

            if (!informationBase.Contains(info))
            {
                return -1;
            }

            return informationBase.IndexOf(info);
        }

        public CustomerInfo this[int index]
        {
            get
            {
                if (index < 0 || index >= informationBase.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of the boundaries!");
                }

                return informationBase[index];
            }
            set
            {
                informationBase[index] = value;
            }
        }
    }
}
