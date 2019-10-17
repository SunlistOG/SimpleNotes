using System;
using System.Collections.Generic;

namespace Simple_Notes_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Simple Notes";

            const string EXIT_COMMAND_KEYWORD = "exit";

            // creating a new keywords for commands 
            Note note = new Note("see", "create", "remove");

            // logging
            NoteLogger noteLogger = new NoteLogger(note);

            string commandPrompt = $"Please, enter 1 of 3 commands: {note.@new}, {note.show}, {note.delete}, or {note.logger}";

            Console.WriteLine(Note.INTRO_MESSAGE);
            Console.WriteLine(commandPrompt);

            string input = "";

            do
            {
                input = Console.ReadLine();
                string[] commands = input.Split(' ');

                try
                {
                    // print the first commands: show, new, delete
                    // and pass the second command to the functions
                    note[commands[0]]((commands.Length > 1) ? commands[1] : "");
                }
                catch (KeyNotFoundException)
                {
                    if (input != EXIT_COMMAND_KEYWORD)
                        Console.WriteLine(commandPrompt);
                }

                // for spacing
                Console.WriteLine();


            } while (input != EXIT_COMMAND_KEYWORD);

            Console.WriteLine(Note.OUTRO_MESSAGE);
        }
    }
}
