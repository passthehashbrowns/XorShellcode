using System;
using System.IO;
using System.Text;

namespace XorShellcode
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = args[0];
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            byte[] shellcode = File.ReadAllBytes(args[1]);
            byte[] encoded = xor(shellcode, keyBytes);
            Console.Write("Encoded: {");
            for(int i = 0; i < encoded.Length; i++)
            {
                Console.Write(String.Format("0x{0:X}", encoded[i]));
                if (i < encoded.Length - 1)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine("};");
        }
        public static byte[] xor(byte[] source, byte[] key)
        {
            byte[] decrypted = new byte[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                decrypted[i] = (byte)(source[i] ^ key[i % key.Length]);
            }

            return decrypted;
        }
        
    }
}
