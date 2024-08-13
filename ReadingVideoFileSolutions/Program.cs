using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingVideoFileSolutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\longp\OneDrive\Hình ảnh\Ảnh chụp màn hình\Screenshot 2024-08-03 160717.png";
            var desFilePath = @"C:\Users\longp\OneDrive\Hình ảnh\Ảnh chụp màn hình\Screenshot 2024-08-03 160717 Copy.png";
            string[] allowExtensions = new string[] { ".jpg", ".peg" , ".png"};
            var isValidate = allowExtensions.Any(e => filePath.Contains(e));
            if(!isValidate)
            {
                Console.WriteLine($"{filePath} must be image file");
                return;
            }
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} does not exist");
                return;
            }
            FileStream reader = new FileStream(filePath, FileMode.Open);
            long byteRead = 0;
            FileStream writer = new FileStream(desFilePath, FileMode.Create);
            int data = 0;
            long size = reader.Length;
            while(data != -1)
            {
               data = reader.ReadByte();
               writer.WriteByte((byte)data);
            }

        }
    }
}
