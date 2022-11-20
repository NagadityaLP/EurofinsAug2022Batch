

namespace UnitTestLabLibrary
{
    public class SimpleLoopTest
    {
        private int[] numbers = { 5, -77, 8, -11, 4, 1, -20, 6, 2, 10 };

        /** Compute total of positive numbers in the array 
         *  @param numItems number of items to total.
         */

        public int findSum(int numItems)
        {
            int total = 0;
            if (numItems <= 10)
            {
                for (int count = 0; count < numItems; count = count + 1)
                {
                    if (numbers[count] > 0)
                    {
                        total = total + numbers[count];
                    }
                }
            }
            return total;
        }

    }
}
