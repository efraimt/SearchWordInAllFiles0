// See https://aka.ms/new-console-template for more information
using SearchWordInAllFiles0;

Console.ForegroundColor = ConsoleColor.Gray;
Console.BackgroundColor = ConsoleColor.Black;

var sw = new SearchWord() { SearchTerm = "Efraim" };

await sw.ProccessDirectory(@"D:\");
   // .ContinueWith(t =>
   //{
       Console.BackgroundColor = ConsoleColor.Cyan;
       Console.ForegroundColor = ConsoleColor.White;
       foreach (var item in sw.FilesFound)
       {
           Console.BackgroundColor = ConsoleColor.White;
           Console.ForegroundColor = ConsoleColor.DarkGray;

           Console.WriteLine(item);
       }

       Console.WriteLine("*******************************");
   //}
   // );

