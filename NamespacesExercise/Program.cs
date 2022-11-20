using System;
using Photography;
using Works = Music.Works;
using TheAgent = Music.Business.Agent;

internal class NamespaceTest
{
    static void Main(string[] args)
    {
        Photo p;
        Album a;
        Works.Album ma;
        TheAgent ba;
        a = new Album();
        ma = new Works.Album();
        ma.print();
    }
}
namespace Photography
{
    class Photo
    {
        public string Title;
    }
    class Album
    {
        public Photo[] Photos = new Photo[10];
        public void print()
        {
            Console.WriteLine("Photography Album class");
        }
    }
}
namespace Music.Works
{
    class Album
    {
        public string Artist;
        public string Title;
        public void print()
        {
            Console.WriteLine("Music.Work Album class");
        }
    }
}
namespace Music.Business
{
    class Agent
    {
        public string Name;
        public double Commission;
    }
}
