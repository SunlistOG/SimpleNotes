using System;

namespace Simple_Notes_App
{
    class MessageImage : IPageable
    {
        private PageData pageData;
        private string asciiImage;

        public PageData MyData
        {
            get => pageData;
            set => pageData = value;
        }

        public IPageable Input()
        {
            Console.WriteLine("Please, input your name:");
            pageData.author = Console.ReadLine();
            Console.WriteLine("Please, input the message title");
            pageData.title = Console.ReadLine();

            Console.WriteLine("Start inputting your image press to create as many lines as you like.");
            Console.WriteLine("Press Ctrl + E and then enter on a single line to stop creating your image");

            bool finishedImage = false;

            while (!finishedImage)
            {
                string input = Console.ReadLine();

                if ((input.Length > 0) && (input[0] == 5)) // E letter - 5th in the alphabet
                    finishedImage = true;
                else
                    asciiImage += "\t" + input + "\n";
            }

            return this;
        }

        public void Output()
        {
            string space = new string('-', 50);

            Console.WriteLine();
            Console.WriteLine("(" + space + " My Image " + space + ")");
            Console.WriteLine("Title: " + pageData.title);
            Console.WriteLine("Author: " + pageData.author);
            Console.WriteLine();
            Console.WriteLine(asciiImage);
            Console.WriteLine("(" + space + space + new string('-', 10) + ")");
        }
    }
}
