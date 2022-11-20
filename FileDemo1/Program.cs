using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = "some data";
            //write into file
            StreamWriter sw = new StreamWriter("C:\\sample.txt",true); // writing to the buffer
            sw.WriteLine(data);
            sw.Close();

            //contents will be actually written to the physical file only when the buffer is full or when the stream buffer is closed explicitly

            //File should be present
            StreamReader sr = new StreamReader("C:\\sample.txt");
            try 
            { 
                string allData = sr.ReadToEnd(); //Read the entire file
                Console.WriteLine(allData);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }

            StreamReader sr1 = new StreamReader("C:\\sample.txt");
            while (!sr1.EndOfStream)
            {
                string lineData = sr1.ReadLine(); //Read the entire file
                Console.WriteLine(lineData);

            }
            sr.Close();


        }
    }
}
