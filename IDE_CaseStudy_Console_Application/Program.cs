using System;
using System.Collections.Generic;

namespace IDE_CaseStudy_Console_Application
{
   
    internal class Program  // : IDE   -  is a relationship
    {
        //IDE ide = new IDE(); // has - a relationship holds when instance is created here
        static void Main(string[] args)
        {
            IDE ide = new IDE(); // uses relationship holds when instance is created inside the Main method
            ide.languages.Add(new LangCSharp());
            ide.languages.Add(new LangJava());
            ide.languages.Add(new LangC());
            ide.DoWork();
        }
    }

    class IDE
    {
        //has a  relationship
        //has C#
        //LangCSharp cs = new LangCSharp();
        //has java
        //LangJava java = new LangJava();
        //has C
        //LangC c = new LangC();
        //ILanguage[] languages = new ILanguage[3];

        public List<ILanguage> languages = new List<ILanguage>();

        public void DoWork()
        {
            foreach (ILanguage lang in languages)
            {
                Console.WriteLine($"Working with {lang.GetName()}");
                Console.WriteLine(lang.GetUnit());
                Console.WriteLine(lang.GetParadigm());
                Console.WriteLine("------------------------");
            }

            /*Console.WriteLine("------------------------");
            Console.WriteLine("Working with Java");
            Console.WriteLine(java.GetName());
            Console.WriteLine(java.GetUnit());
            Console.WriteLine(java.GetParadigm());

            Console.WriteLine("------------------------");
            Console.WriteLine("Working with C");
            Console.WriteLine(c.GetName());
            Console.WriteLine(c.GetUnit());
            Console.WriteLine(c.GetParadigm());*/
        }
    }

    interface ILanguage
    {
        //by defult - access modifier is public
        string GetName();
        string GetUnit();
        string GetParadigm();
    }

    abstract class OOLanguage : ILanguage
    {
        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "Object Oriented";
        }
        abstract public string GetName();
    }
    class LangCSharp : OOLanguage
    {
        public override string GetName()
        {
            return "CSharp";
        }
        
    }
    class LangJava : OOLanguage
    {
        public override string GetName()
        {
            return "Java";
        }
    }
    class LangC : ILanguage
    {
        public string GetName()
        {
            return "C";
        }
        public string GetUnit()
        {
            return "Function";
        }
        public string GetParadigm()
        {
            return "Procedure Oriented";
        }
    }
}
