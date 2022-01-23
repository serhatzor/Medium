using System.IO;
using System.Text;

namespace IDisposableExample
{
    public class UserProcessor : IDisposable
    {
        private FileStream _fileStream;
        private readonly string _path;
        public UserProcessor()
        {
            _path = "users.txt";
        }
        public void OpenUserProcessor(bool append)
        {
            _fileStream = new FileStream(_path, append ? FileMode.Append : FileMode.Open);
        }

        public string ReadUsers()
        {
            byte[] bytes = new byte[_fileStream.Length];
            _fileStream.Read(bytes, 0, (int)_fileStream.Length);
            return Encoding.UTF8.GetString(bytes);
        }

        public void InsertUser(string user)
        {
            _fileStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine + user));
        }

        public void Dispose()
        {
            _fileStream.Close();
            _fileStream.Dispose();

        }
    }
}