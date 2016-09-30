using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int[] aPrimes = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73 };

        public Form1()
        {
            InitializeComponent();
            AcceptButton = this.btnInput;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            int inputValue;
            bool error = false;

            ArrayList lResults = new ArrayList();

            if (!int.TryParse(input.Text, out inputValue))
            {
                output.Text = "Sorry dude, I can't work with that.  Try a number.";
                error = true;
            }
            else {

                //int inputValue = Convert.ToInt16(input.Text);
                string tempOutput = "";

                //check for incorrect input
                // not allowed: negative & 0
                if (inputValue <= 0)
                {
                    output.Text = "-inf";
                    error = true;
                }

                    int subtotal = inputValue;
                    int divider = 2; //start with the lowest prime

                    // get hightest prime < input
                    int highestPrime = getHighestPrime(inputValue);
                    int highestIndex = Array.IndexOf(aPrimes, highestPrime);

                    lResults.Add(0);
                    lResults.Add(0);

                while (divider <= highestPrime && subtotal > 1)
                    {
                    int tempresult = (subtotal % divider);

                       if (subtotal % divider == 0)
                        { //valid divider found. add it to output and restart the loop
                            subtotal = subtotal / divider;

                            tempOutput = tempOutput + "p" + Array.IndexOf(aPrimes, divider) + " ";

                            int tempResult = 1 + (int) lResults[Array.IndexOf(aPrimes, divider)] ;
                            
                            lResults.RemoveAt(lResults.Count - 1);
                            lResults.Add(tempResult);    
                            
                        }
                        else
                        { //input not dividable by this divider, chose the next divider
                            divider = getNextPrime(divider);
                            lResults.Add(0);
                    }
                    }


                if (!error)
                {
                    //cleanup result: remove all highest keys with 0 value
                    lResults = cleanupResult(lResults);

                    //reformat result: write the resulting array in format: p(..,4,3,2,1)
                    output.Text = formatResult(lResults);
                    //output.Text = Convert.ToString(tempOutput);
                }

                input.Clear();
            }
        }

        public int getHighestPrime(int matchValue)
        {
            int maxVal = 0;
            int index = -1;

            for (int i = 0; i < aPrimes.Length; i++)
            {
                int thisNum = aPrimes[i];
                if ((thisNum > maxVal) && thisNum <= matchValue)
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

        public ArrayList cleanupResult(ArrayList resultList)
        {

           for (int i = resultList.Count - 1; i > 1; i--)
            {
                int thisVal = (int) resultList[i];
                if (thisVal == 0)
                {
                    resultList.RemoveAt(i);
                }
                else break;
            }
            

            resultList.Reverse();
            resultList.RemoveAt(resultList.Count - 1);

            return resultList;
        }

        public string formatResult(ArrayList resultList)
        {
            string result = string.Join(",", resultList.ToArray());

            return result;
        }

        
    }
}
