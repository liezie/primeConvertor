using System;
using System.Collections;
using System.Windows.Forms;
using WindowsFormsApplication1.Bll;

namespace WindowsFormsApplication1.UI
{
    public partial class Form1 : Form
    {
        public int[] aPrimes = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73 };

        private BasePrimeConvertor _convertor = new BasePrimeConvertor();

        public Form1()
        {
            InitializeComponent();
            AcceptButton = this.btnInput;

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            int inputValue;

            ArrayList lResults = new ArrayList();

            if (!int.TryParse(input.Text, out inputValue))
            {
                output.Text = "Sorry dude, I can't work with that.  Try a number.";
            }
            else
            {
                // calculate 
                var result = _convertor.GetDividers(inputValue);


                if (result.Success)
                {
                    output.Text = formatResult(result.Dividers);
                }
                else
                {
                    output.Text = result.ErrorText;
                }

                input.Clear();
            }
        }

        public string formatResult(int[] resultList)
        {
            string result = string.Join(",", resultList);
            return result;
        }


    }
}
