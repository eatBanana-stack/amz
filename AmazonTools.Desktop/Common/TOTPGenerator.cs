using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTools.Desktop.Common
{
    public class TOTPGenerator
    {
        public string GenerateCode(string secret)
        {
            byte[] key = Base32Decode(secret);
            long counter = GetCurrentCounter();

            byte[] data = BitConverter.GetBytes(counter);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            using (HMACSHA1 hmac = new HMACSHA1(key))
            {
                byte[] hash = hmac.ComputeHash(data);
                int offset = hash[hash.Length - 1] & 0x0F;

                int binaryCode = ((hash[offset] & 0x7F) << 24) |
                               ((hash[offset + 1] & 0xFF) << 16) |
                               ((hash[offset + 2] & 0xFF) << 8) |
                               (hash[offset + 3] & 0xFF);

                int otp = binaryCode % 1000000;
                return otp.ToString("D6");
            }
        }

        public int GetRemainingSeconds()
        {
            return 30 - (int)(DateTime.UtcNow.Ticks / TimeSpan.TicksPerSecond % 30);
        }

        private long GetCurrentCounter()
        {
            long unixTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerSecond - 62135596800;
            return unixTime / 30; // 30秒为一个时间窗口
        }

        private byte[] Base32Decode(string input)
        {
            // Base32解码实现
            var base32Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            input = input.TrimEnd('=').ToUpper();

            byte[] output = new byte[input.Length * 5 / 8];
            int buffer = 0;
            int bitsLeft = 0;
            int index = 0;

            foreach (char c in input)
            {
                int value = base32Alphabet.IndexOf(c);
                if (value < 0) continue;

                buffer = (buffer << 5) | value;
                bitsLeft += 5;

                if (bitsLeft >= 8)
                {
                    output[index++] = (byte)(buffer >> (bitsLeft - 8));
                    bitsLeft -= 8;
                }
            }

            return output;
        }
    }
}
