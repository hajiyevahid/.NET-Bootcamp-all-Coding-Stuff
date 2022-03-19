namespace CSharp.Activity.Collections
{
    public class FileHandling
    {
        string Path { get; set; }

        public FileHandling(string path)
        {
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
            string line = string.Empty;
            string contents = string.Empty;
            using (StreamReader reader = new StreamReader(Path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    contents += line + Environment.NewLine;
                }
                Console.WriteLine(contents);
            }

            return contents;
        }
    }
}

