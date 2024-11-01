namespace Loggers
{
    
    public class Logger
    {
        public readonly string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()).ToString() + "Log.txt";
        public void Write(string msg) 
        {
            File.AppendAllText(path, msg);
        }

        public void WriteLine(string msg)
        {
            File.AppendAllText(path, msg + "\n");
        }
        public string[] Read()
        {
            return File.ReadAllLines(path);
        }

        public void RemoveLogs()
        {
            File.Delete(path);
            File.Create(path);
        }
    }
}
