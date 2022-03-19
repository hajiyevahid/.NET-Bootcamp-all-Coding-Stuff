--------------------customerInfo------------------
namespace CSharp.Activity.Collections
{
    public class CustomerInfo
    {
        public int ID { get; set; } 
        public string Name { get; set; }    
        public string Address { get; set; }    
        public string Email { get; set; }
        public CustomerInfo(int id, string name, string address, string email)
        {
            ID=id;
            Name = name;    
            Address = address;  
            Email = email;  
        }

    }
}
--------------------CustomerInfoCollection-----------

namespace CSharp.Activity.Collections
{
    public class CustomerInfoCollection
    {
        List<CustomerInfo> informationBase;

        public int Add(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Object is null !");
            }
            if (informationBase.Contains(info))
            {
                return -1;
            }
            informationBase.Add(info);

            return informationBase.IndexOf(info);
        }

        public void Insert(int index, CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Object is null!");
            }
            informationBase.Insert(index, info);
        }

        public void Remove(CustomerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Object is null!");
            }

            informationBase.Remove(info);
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
                if ((index < 0) || (index >= informationBase.Count))
                {
                    throw new IndexOutOfRangeException("Index is out of the boundaries !");

                }

                return informationBase[index];
            }
            protected set
            {
                informationBase[index] = value;
            }
        }
    }
}

------------------file handling--------------------
namespace CSharp.Activity.CoreUtilities
{
    internal class FileHandling
    {
        string fileName;
        string Path;
        string readedInfo;

        public FileHandling(string filename, string path)
        {
            fileName = filename;
            Path = path;
        }

        public void WriteToDisk(string text)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                Console.WriteLine(text);
                writer.WriteLine(text);
            }
        }

        public string ReadFromDisk()
        {
            var reader = new StreamReader(Path);
            try
            {
                using (reader)
                {
                    // Read the stream as a string, and write the string to the console.
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return reader.ReadToEnd();
        }
    }
}

