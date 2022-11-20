using System;

namespace DelegatesExercise
{
    delegate void MessageHandler(string s);
    internal class Driver
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            publisher.MessageHandlerReference += subscriber.CallMe;
            publisher.MessageHandlerReference += subscriber.MeToo;
            publisher.MessageHandlerReference += new MessageHandler(Subscriber.AddMe);
            publisher.Dispatch("This is reference to MessageHandler delegate in Publisher class");
            //publisher.MessageHandlerReference("hello"); - error when event is used

            RandomSource rs = new RandomSource(5);
            RandomSource rs1 = new RandomSource(6);
            RandomSource rs2 = new RandomSource(7);

            Histogram histogram = new Histogram();
            histogram.hs += rs.Magnitude;
            histogram.hs += rs1.Magnitude;
            histogram.hs += rs2.Magnitude;

            histogram.Draw();
        }
    }
    class Publisher
    {
        //public MessageHandler MessageHandlerReference;
        public event MessageHandler MessageHandlerReference = null;
        public void Dispatch(string p_s)
        {
            if (MessageHandlerReference != null)
            {
                //MessageHandlerReference(p_s);   
                var delegates = MessageHandlerReference.GetInvocationList();
                foreach (Delegate item in delegates)
                {
                    MessageHandler m = (MessageHandler)item;
                    m(p_s);
                }

            }
        }
    }
    class Subscriber
    {
        public void CallMe(string s1_s)
        {
            Console.WriteLine(s1_s);

        }
        public void MeToo(string s2_s)
        {
            Console.WriteLine(s2_s);
        }
        public static void AddMe(string s3_s)
        {
            Console.WriteLine(s3_s);
        }
    }


    delegate int HistogramSource();

    class Histogram
    {
        public event HistogramSource hs = null;
        public void Draw()
        {
            if (hs != null)
            {

                var histogramSources = hs.GetInvocationList();
                
                foreach (var item in histogramSources)
                {
                    HistogramSource hs1 = (HistogramSource)item;
                    int histogramVal = hs1();
                    for(int i = 0; i < histogramVal; i++)
                        Console.Write("*");
                    Console.WriteLine();
                }
            }
                
        }
    }
    class RandomSource
    {
        private int max;
        private Random r;

        public RandomSource(int max)
        {
            this.max = max;
            r = new Random();
        }
        public int Magnitude()
        {
            return r.Next(max);
        }
    }


}
