using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string theoperator;
        double firstInteger, secondInteger;
        
        public MainPage()
        {
            InitializeComponent();
            clickedClear(this, null);
        }

        private void clickedClear(object sender, EventArgs e)
        {
            firstInteger = 0;
            secondInteger = 0;
            currentState = 1;
            this.displayNumber.Text = "0";
            this.displayResult.Text = "0";
        }

        //private void clickedRemainder(object sender, EventArgs e)
        //{
            //if ((currentState == -1) && (currentState == 1))
            //{
                //var result = Arithmetic.Remainder(firstInteger, theoperator);
                //var result = (firstInteger % secondInteger);
                //this.displayResult.Text = result.ToString();
                //firstInteger = result;
                //currentState = -1;
            //}
        //}
        
        private void clickedNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string selected = button.Text;
            
            if (this.displayNumber.Text == "0" || currentState < 0)
            {
                this.displayNumber.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.displayNumber.Text += button.Text;

            double number;

            if (double.TryParse(this.displayNumber.Text, out number))
            {
                this.displayNumber.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstInteger = number;
                }
                else
                {
                    secondInteger = number;
                }
            }
        }

        private void clickedCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Arithmetic.Calculate(firstInteger, secondInteger, theoperator);
                this.displayResult.Text = result.ToString();
                this.displayNumber.Text = "0";
                firstInteger = result;
                currentState = -1;
            }
        }

        private void clickedOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string selected = button.Text;
            theoperator = selected;
        }
    }
}
