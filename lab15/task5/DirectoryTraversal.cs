namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
            Console.ReadKey();
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();
            DirectoryInfo dirInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = dirInfo.GetFiles(); 

            foreach (FileInfo file in files)
            {
                string ext = file.Extension.ToLower();

                if (!filesByExtension.ContainsKey(ext))
                {
                    filesByExtension[ext] = new List<FileInfo>();
                }

                filesByExtension[ext].Add(file);
            }

            var sortedExtensions = filesByExtension
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key);

            List<string> reportLines = new List<string>();

            foreach (var kvp in sortedExtensions)
            {
                string ext = kvp.Key;
                reportLines.Add($".{ext.TrimStart('.')}");

                var sortedFiles = kvp.Value.OrderBy(f => f.Length);

                foreach (var file in sortedFiles)
                {
                    double sizeKb = file.Length / 1024.0;
                    reportLines.Add($"-- {file.Name} - {sizeKb:F3}kb");
                }
            }

            return string.Join(Environment.NewLine, reportLines);

        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(desktopPath, reportFileName);
            File.WriteAllText(fullPath, textContent);

        }
    }
}