using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
           {
               string inputFilePath = @"..\..\..\copyMe.png";
               string outputFilePath = @"..\..\..\copyMe-copy.png";
                
               CopyFile(inputFilePath, outputFilePath);
               Console.ReadKey();
           }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            const int bufferSize = 4096;
            
            using (FileStream sourceStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream =
                   new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
   
}