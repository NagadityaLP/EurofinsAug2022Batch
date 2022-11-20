
namespace IndexersDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rainbow rainbow = new Rainbow();
            //System.Console.WriteLine(rainbow.GetColor(4));

            //using indexer
            System.Console.WriteLine(rainbow[4]);
        }
    }
    class Rainbow
    {
        private string[] colors = { "violet", "indigo", "blue", "green", "yellow", "orange", "red" };

        /*public string GetColor(int i)
        {
            return colors[i];
        }*/
        public string this[int i]
        {
            get { return colors[i]; }
        }
    }
}
