using System;

namespace Simple_Notes_App
{
    class NoteLogger
    {
        private Note trackedNote;
        private bool logging = true;

        public NoteLogger(Note trackedNote)
        {
            this.trackedNote = trackedNote;
            Attach();

            trackedNote.LoggingToggled += ToggleLogging;
        }

        private void PrintAdded(string typeItemAdded)
        {
            Console.WriteLine(typeItemAdded + " was added to the notes.");
        }

        private void PrintDeleted(string idOfDeleted)
        {
            if (idOfDeleted != "")
                Console.WriteLine("Item " + idOfDeleted + " was deleted from the notes.");
            else
                Console.WriteLine("Everything was deleted from the notes.");
        }

        private void IncorrectCommand(string messageToPrint)
        {
            Console.WriteLine("Bad Command: " + messageToPrint);
        }

        private void Attach()
        {
            trackedNote.ItemAdded += PrintAdded;
            trackedNote.ItemRemoved += PrintDeleted;
            trackedNote.InputBadCommand += IncorrectCommand;
        }

        private void Detach()
        {
            trackedNote.ItemAdded -= PrintAdded;
            trackedNote.ItemRemoved -= PrintDeleted;
            trackedNote.InputBadCommand -= IncorrectCommand;
        }

        public void ToggleLogging(bool isTurnOn)
        {
            string output = "Logger already " + ((isTurnOn) ? "on" : "off") + ".";

            if (logging)
            {
                if (!isTurnOn)
                {
                    Detach();
                    logging = false;
                    output = "Logger turn off.";
                }
            }
            else
            {
                if (isTurnOn)
                {
                    Attach();
                    logging = true;
                    output = "Logger turn on.";
                }
            }

            Console.WriteLine(output);
        }
    }
}
