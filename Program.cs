using System;
using System.IO;
using TagLib;

namespace musicname
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the destination of the music file");
            string input = Console.ReadLine();
            string filePath = input.Replace(@"\", @"/");
            int extensionIndex = filePath.IndexOf(".");
            string extension = filePath.Substring(extensionIndex);


            var tfile = TagLib.File.Create(@filePath);
            int index = filePath.LastIndexOf("/");


            string newFilePath = filePath.Remove(index);
            Console.WriteLine($"new filepath = {newFilePath}");

            string newName = $"/{tfile.Tag.Performers[0]} - {tfile.Tag.Album} - {tfile.Tag.Title}{extension}";
            string newPath = $"{newFilePath}{newName}";
            System.IO.File.Move(filePath, newPath);

            Console.WriteLine("File has been renamed");
        }
    }
}
