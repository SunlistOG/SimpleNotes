using System;
using System.Collections.Generic;

namespace Simple_Notes_App
{
    class Note
    {
        public const string INTRO_MESSAGE = "Hi, there! Welcome to Simple Notes program v1.0";
        public const string OUTRO_MESSAGE = "Dear user, thank you for using Simple Notes!";

        List<IPageable> pages = new List<IPageable>();

        public delegate void SimpleFunction(string command);
        public delegate void BooleanFunction(bool isOn);

        public event SimpleFunction ItemAdded, ItemRemoved, InputBadCommand;
        public event BooleanFunction LoggingToggled;

        private Dictionary<string, SimpleFunction> commandLineArgs =
            new Dictionary<string, SimpleFunction>();

        // created commands
        public readonly string show = "show";
        public readonly string @new = "new";
        public readonly string delete = "delete";
        public readonly string logger = "log";

        public SimpleFunction this[string command]
        {
            get => commandLineArgs[command];
        }

        public Note()
        {
            commandLineArgs.Add(show, Show);
            commandLineArgs.Add(@new, New);
            commandLineArgs.Add(delete, Delete);
            commandLineArgs.Add(logger, Log);

        }

        /// <summary>
        /// Create a new note with input keywords for commands instead of default ones
        /// </summary>
        /// <param name="commandLineKeywords"> index 0 = show, 1 = new, 2 = delete</param>
        public Note(params string[] commandLineKeywords) : this()
        {
            for (int i = 0; i < commandLineKeywords.Length; ++i)
            {
                // if input is empty, jump to new iteration
                if (commandLineKeywords[i] == "")
                {
                    continue;
                }

                switch (i)
                {
                    // show command
                    case 0:
                        commandLineArgs.Remove(show);
                        commandLineArgs.Add(show = commandLineKeywords[i], Show);
                        break;

                    // new command
                    case 1:
                        commandLineArgs.Remove(@new);
                        commandLineArgs.Add(@new = commandLineKeywords[i], New);
                        break;

                    // delete command
                    case 2:
                        commandLineArgs.Remove(delete);
                        commandLineArgs.Add(delete = commandLineKeywords[i], Delete);
                        break;
                }

            }
        }

        #region New command
        private void New(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("New commands:");
                    Console.WriteLine("message          create a new message page");
                    Console.WriteLine("list             create a new list page");
                    Console.WriteLine("image            create a new image page");
                    break;

                case "message":
                    pages.Add(new MessageText().Input());
                    ItemAdded?.Invoke("Message Text");
                    break;

                case "list":
                    pages.Add(new MessageList().Input());
                    ItemAdded?.Invoke("Message List");
                    break;

                case "image":
                    pages.Add(new MessageImage().Input());
                    ItemAdded?.Invoke("Message Image");
                    break;

                default:
                    InputBadCommand?.Invoke("You didn't enter message, list, or image! Please, try again");
                    break;
            }
        }
        #endregion

        #region Show command
        private void Show(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Show commands:");
                    Console.WriteLine("pages            list of all created pages");
                    Console.WriteLine("id of page       display that page");
                    break;
                case "pages":
                    string space = new string('-', 50);
                    Console.WriteLine("(" + space + " My Pages " + space + ")");

                    for (int i = 0; i < pages.Count; ++i)
                    {
                        Console.WriteLine("ID: " + i + " " + pages[i].MyData.title);
                    }

                    break;

                default:
                    int number;

                    if (int.TryParse(command, out number))
                    {
                        Console.WriteLine("Showing page " + number);

                        if (number < pages.Count)
                            pages[number].Output();
                        else
                            InputBadCommand?.Invoke("Your number was outside of the range of pages! Please, try again");
                    }
                    else
                    {
                        InputBadCommand?.Invoke("You didn't enter pages or a valid number! Please, try again");
                    }
                    break;
            }
        }
        #endregion

        #region Delete command
        private void Delete(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Delete commands:");
                    Console.WriteLine("all              delete all created pages");
                    Console.WriteLine("id of page       delete that page");
                    break;

                case "all":
                    pages.Clear();
                    ItemRemoved?.Invoke("");
                    break;

                default:
                    int number;

                    if (int.TryParse(command, out number))
                    {

                        if (number < pages.Count)
                        {
                            pages.RemoveAt(number);
                            ItemRemoved?.Invoke(number + "");
                        }
                        else
                        {
                            InputBadCommand?.Invoke("Your number was outside of the range of pages! Please, try again");
                        }
                    }
                    else
                    {
                        InputBadCommand?.Invoke("Yout didn't input all, or your number was outside of the range of pages! Please, try again");
                    }
                    break;
            }
        }
        #endregion

        private void Log(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Logger commands:");
                    Console.WriteLine("on               turn logger on");
                    Console.WriteLine("of               turn logger off");
                    break;

                case "on":
                    LoggingToggled?.Invoke(true);
                    break;

                case "off":
                    LoggingToggled?.Invoke(false);
                    break;

                default:
                    InputBadCommand?.Invoke("Please, enter on or off arter inputting the log command");
                    break;
            }
        }
    }
}
