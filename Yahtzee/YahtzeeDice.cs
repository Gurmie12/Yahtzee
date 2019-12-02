// Author: Gurman Brar
// Date: Nov, 3, 2019
// BME 121 pa2

using System;
using static System.Console;
using System.Text;

namespace Bme121
{
    public static void Main()
	{

	}

    public class YahtzeeDice
    {


        //The to string method wich displays the dice in a neat manner for the user.

        public override string ToString()
		{
			string dice = "";
            for (int i = 0; i < dieFaceValues.Length; i++)
			{
				dice = dice + " " + dieFaceValues[i] + " ";
			}
			return dice;
		}

        
        // Random number generator for the dice and declaring the dice face value array.

        Random rGen = new Random();

        int[] dieFaceValues = new int[5];


        // Rolls the dice by looping through each index in the face value array and assigning it a random number between 1 and 6.

        public void Roll()
        {

            for(int i = 0; i < dieFaceValues.Length; i++)
            {
                if(dieFaceValues[i] == 0)
                {
                    dieFaceValues[i] = rGen.Next(1, 7);
                }
            }
        }


        // Unrolls the dice either based on the faces passed in, checking which index's are equal to that value and changing those index's
        // to zero or if all face values are changed then loops through the array and makes all index's equal to zero.

        public void Unroll(string faces)
        {
            if (faces != "all")
            {
                for (int i = 0; i < faces.Length; i++)
                {
                    int temp = int.Parse(faces.Substring(i, 1));

                    for(int j = 0; j < dieFaceValues.Length; j++)
                    {
                        if(dieFaceValues[j] == temp)
                        {
                            dieFaceValues[j] = 0;
                        }
                    }
                }
            }
            else
            {
                for(int i = 0; i < dieFaceValues.Length; i++)
                {
                    dieFaceValues[i] = 0;
                }
            }
        }   


        // Sums all of the index values within the array that have the corosponding face value via a loop and simple iterative addition.

        public int Sum(int face)
        {
            int sum = 0;
            for(int i = 0; i < dieFaceValues.Length; i++)
            {

                if(dieFaceValues[i] == face)
                {
                    sum = sum + dieFaceValues[i];
                    
                }
            }
            return sum;
        }

        // Adds all of the values at each given index of the face value array for final score. loops through each index adding previous to the next.

        public int sum()
        {
            int sum = 0;
            for(int i = 0; i< dieFaceValues.Length; i++)
            {
                sum = sum + dieFaceValues[i];
            }
            return sum;
        }


        // This method checks if the face values from a sequence. We use the counter and temp variables as placeholders and index locators.
        // The method loops through the face values seeing if the previous is value is one less than the next and adds one to the counter.
        // If the previous is equal to the next it shouldnt stop the sequence and therfore we use a continue.
        // In the case that temp is lower than counter (12456), we want to set temp = counter.

        public bool isRunOf(int length)
        {
			sort();
			int counter = 0;
			int temp = 0;

            for(int i = 0; i< dieFaceValues.Length; i++)
			{
				if (dieFaceValues[i] + 1 == dieFaceValues[i + 1]) counter++;
				else if (dieFaceValues[i] == dieFaceValues[i + 1]) continue;
				else
				{
					temp = counter;
					counter = 0;
				}
				if (counter > temp) temp = counter;
			}
			if (temp + 1 >= length) return true;
			else return false;
        }


        // The is set of method checks if the same value is reocouring. Here we also use the counter and temp variables in a similar way.
        // if the current value is the same as the next we add one to the counter.
        // if the counter does not equal zero and the current index does not equal the next we set temp = counter and reset our counter so we have a storage for the
        // number of reocourances.
        // if the counter is greater than or equal to the size or the temp is, we can conclude there is a set.

        public bool isSetOf(int size)
        {
			sort();
			int counter = 0;
			int temp = 0;
            for(int i = 0; i < dieFaceValues.Length - 1; i++)
			{
                if( dieFaceValues[i] == dieFaceValues[i + 1])
				{
					counter++;
				}
				if (counter != 0 && dieFaceValues[i] != dieFaceValues[i + 1])
				{
					temp = counter;
					counter = 0;
				}
			}
			if (counter + 1 >= size || temp + 1 >= size) return true;
			else return false;
        }


        // Is full house method checks if you have 2 of the same values and 3 of the same values in a row by dhecking the two cases.
        // Either the first two are the same and the last 3 are the same.
        // Or the first 3 are the same and the last two are the same.

        public bool isFullHouse()
        {
			sort();
			if (dieFaceValues[0] == dieFaceValues[1] && (dieFaceValues[2] == dieFaceValues[3] && dieFaceValues[3] == dieFaceValues[4]))
			{
				return true;
			}
			else if (dieFaceValues[3] == dieFaceValues[4] && (dieFaceValues[0] == dieFaceValues[1] && dieFaceValues[1] == dieFaceValues[2]))
			{
				return true;
			}
			else return false;
        }


        // This method was created to make the last 3 logic methods easier by sorting the array from lowest to greatest.
        // If the current index value is less than the one before then you can replace the two using a temp variable and turning
        // the bool variable to true. This will let the while loop continue to run. If the array is sorted then the bool will never go true
        // and you know your array is sorted.

        public void sort()
		{
			int temp;
			bool isSwap = true;

			while(isSwap)
			{
				isSwap = false;
                for(int i = 1; i< dieFaceValues.Length; i++)
				{
                    if(dieFaceValues[i] < dieFaceValues[i - 1])
					{
						temp = dieFaceValues[i - 1];
						dieFaceValues[i - 1] = dieFaceValues[i];
						dieFaceValues[i] = temp;
						isSwap = true;
					}
				}
			}
		}

    }

}

