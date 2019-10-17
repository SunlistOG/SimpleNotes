namespace Simple_Notes_App
{
    public struct PageData
    {
        public string title;
        public string author;
    }


    public interface IPageable
    {
        PageData MyData { get; set; }

        // input our item
        IPageable Input();

        // output our item
        void Output();
    }

}
