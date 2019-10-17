using System;

namespace Simple_Notes_App
{
    class MessageText : IPageable
    {
        protected PageData pageData;
        protected string message;

        public PageData MyData
        {
            get => pageData;
            set => pageData = value;
        }

        public virtual IPageable Input()
        {
            Console.WriteLine("Please, input your name:");
            pageData.author = Console.ReadLine();
            Console.WriteLine("Please, input the message title");
            pageData.title = Console.ReadLine();
            Console.WriteLine("Please, input the message");
            message = Console.ReadLine();

            return this;
        }

        public void Output()
        {
            string space = new string('-', 50);

            Console.WriteLine();
            Console.WriteLine("(" + space + " My Message " + space + ")");
            Console.WriteLine("Title: " + pageData.title);
            Console.WriteLine("Author: " + pageData.author);
            Console.WriteLine("Message:  \n \n" + message);
            Console.WriteLine("(" + space + space + new string('-', 12) + ")");
        }
    }
}
