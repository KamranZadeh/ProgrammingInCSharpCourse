using System;
using System.IO;

namespace toDo1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string myPath = args[0];
            const string imgPath = @$"{myPath}\images\";
            const string videoPath = @$"{myPath}\videos\";
            const string docPath = @$"{myPath}\documents\";
            const string otherPath = @$"{myPath}\otherFiles\";

            string[] files = Directory.GetFiles(myPath);
            string[] directories = Directory.GetDirectories(myPath);

            foreach (var file in files)
            {
                if (Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".JPG")
                {
                    File.Move(file, $"{imgPath}{Path.GetFileName(file)}", true);
                }
                else if (Path.GetExtension(file) == ".doc" || Path.GetExtension(file) == ".docx" || Path.GetExtension(file) == ".pdf" || Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".pptx")
                {
                    File.Move(file, $"{docPath}{Path.GetFileName(file)}", true);
                }
                else if (Path.GetExtension(file) == ".mp4")
                {
                    File.Move(file, $"{videoPath}{Path.GetFileName(file)}", true);
                }
                else if (File.ReadAllText(file) == String.Empty)
                {
                    File.Delete(file);
                }
                else
                {
                    File.Move(file, $"{otherPath}{Path.GetFileName(file)}", true);
                }
            }

            foreach (var dir in directories)
            {
                if (Directory.GetFiles(dir).Length == 0)
                {
                    Directory.Delete(dir);
                }
            }
        }
    }
}
