using System;

namespace Simple_Notes_App
{
    class MessageList : MessageText
    {
        private enum MarkerType { Dashed, Numbered, Star };
        private MarkerType markerType;

        public override IPageable Input()
        {
            Console.WriteLine("Please, input your name:");
            pageData.author = Console.ReadLine();
            Console.WriteLine("Please, input the message title");
            pageData.title = Console.ReadLine();
            Console.WriteLine("What type of marker point would you like to use?");
            Console.WriteLine("Please, enter dashed, numbered or star!");

            bool rightInput = false;

            while (!rightInput)
            {
                rightInput = true;
                switch (Console.ReadLine())
                {
                    case "dashed":
                        markerType = MarkerType.Dashed;
                        break;

                    case "numbered":
                        markerType = MarkerType.Numbered;
                        break;

                    case "star":
                        markerType = MarkerType.Star;
                        break;

                    default:
                        Console.WriteLine("Please, enter dashed, numbered or star!");
                        rightInput = false;
                        break;
                }
            }


            Console.WriteLine("Start typing your list. Every time you press enter a new item will be created.");
            Console.WriteLine("Press enter with a blank list item to end your list input.");

            // write list
            bool finishedList = false;
            int i = 1;  // numbered marker            

            while (!finishedList)
            {
                string input = Console.ReadLine();

                // if they enter nothing our list is finished
                if (input == "")
                    finishedList = true;
                else
                {
                    switch (markerType)
                    {
                        case MarkerType.Dashed:
                            message += "- " + input + " \n";
                            break;

                        case MarkerType.Numbered:
                            message += $"{i}. " + input + " \n";
                            break;

                        case MarkerType.Star:
                            message += "* " + input + " \n";
                            break;
                    }
                }
            }

            return this;
        }
    }
}
