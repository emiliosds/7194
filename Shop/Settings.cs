using System.Text;

namespace Shop 
{
    public static class Settings 
    {
        private const string SECRET = "b2b92399-1ebe-42dd-bac0-359aea8c74cc";
        public static byte[] ByteSecretKey { get { return Encoding.ASCII.GetBytes(SECRET); }}
    }
}