using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWordInAllFiles0
{
    internal class SearchWord
    {

        public string SearchTerm { get; set; }
        public IList FilesFound { get; set; } = ArrayList.Synchronized(new List<string>());
        IList tasks = ArrayList.Synchronized(new List<Task>());

        public async Task ProccessDirectory(string directoryPath)
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(directoryPath);


                Task t1 = Task.Run(() =>
                  {
                      List<string> directories = new List<string>();
                      try
                      {
                          directories = Directory.GetDirectories(directoryPath).ToList();
                          Parallel.ForEach(directories, (directory, ct) => { ProccessDirectory(directory); });
                      }
                      catch (System.UnauthorizedAccessException ex) { }

                      try
                      {
                          var fileNames = Directory.GetFiles(directoryPath);
                          Parallel.ForEach(fileNames, (file, ct) => ProccessFile(file));
                      }
                      catch (System.UnauthorizedAccessException ex) { }
                  });

                Task.WaitAll(t1);

            }
            catch (UnauthorizedAccessException)
            {
            }


        }

        private void ProccessFile(string fileName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(fileName);


            if (Path.GetExtension(fileName) == ".txt")
            {
                string content = "";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    try
                    {
                        content = sr.ReadToEnd();
                        if (content.Contains(SearchTerm))
                        {
                            FilesFound.Add(fileName);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
        }
    }
}
