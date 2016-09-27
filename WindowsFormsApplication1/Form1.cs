using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int[] aPrimes = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73 };
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            int inputValue;
            if (!int.TryParse(input.Text, out inputValue))
            {
                output.Text = "Sorry dude, I can't work with that.  Try a number.";
            }
            else {

                //int inputValue = Convert.ToInt16(input.Text);
                string tempOutput = "";

                //check for incorrect input
                // not allowed: negative & 0
                if (inputValue <= 0) output.Text = "Sorry dude, I can only work with positive numbers.  Try a different number.";

                // check if input is in table & return
                int index = Array.IndexOf(aPrimes, inputValue);
                if (index >= 0) tempOutput = "(" + Convert.ToString(index) + ")";

                //else, start building the value
                else
                {
                    int subtotal = inputValue;
                    int divider = 2; //start with the lowest prime

                    // get hightest prime < input
                    int highestPrime = getHighestPrime(inputValue);

                    while (divider < highestPrime && subtotal > 1)
                    {
                        if (subtotal % divider == 0)
                        {
                            subtotal = subtotal / divider;
                            tempOutput = tempOutput + "(" + divider + ")";
                        }
                        else divider = getNextPrime(divider);
                    }
                }


                output.Text = Convert.ToString(tempOutput);
            }
        }

        public int getHighestPrime(int matchValue)
        {
            int maxVal = 0;
            int index = -1;

            for (int i = 0; i < aPrimes.Length; i++)
            {
                int thisNum = aPrimes[i];
                if ((thisNum > maxVal) && thisNum < matchValue)
                {
                    maxVal = thisNum;
                    index = i;
                }
            }

            return maxVal;
        }

        public int getNextPrime(int matchValue)
        {
            int index = Array.IndexOf(aPrimes, matchValue);
            //TODO: opvangen, als de volgende niet bestaat.
            return aPrimes[index + 1];
        }
    }
}
