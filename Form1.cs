// Robert Stepp
// TINFO 200
// Calc
//////////////////////
// Change History
// Date         Developer   Description
// 01212020     rstepp      File creation and initial implementation of the application
// 01232020     rstepp      Added check for text in box (tryParse)
//                          Added handling for bksp 'out of bounds' error
//                          Added CE and C handling
//                          Removed reset for new number
//                          Changed font size of textbox and set min size of window
// References Used
// Tutor, B. (2016, December 26). Tutor Icons. 
//      Retrieved January 21, 2020, from https://www.iconfinder.com/iconsets/tutor-icon-set
// Double.TryParse Method (System). (n.d.). 
//      Retrieved January 23, 2020, from https://docs.microsoft.com/en-us/dotnet/api/system.double.tryparse?view=netframework-4.8

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        private Data calculatorData = new Data();

        public Form1()
        {
            InitializeComponent();
            
        }

        //  Buttons for the integer values.
        private void intBtn_Click(object sender, EventArgs e)
        {

            // This section resets the display after use.
            // It may be uncommented to readd this functionality ..
            // This allows user to use previous result as first number of new operation.
            /* 
            // Resets the output after use
            if (calculatorData.SecondNumber != 0)
            {
                calculatorData.FirstNumber = 0;
                calculatorData.SecondNumber = 0;
                calcDisplay.Text = "0";
            } 
            */

            Button button = (Button)sender;
            string str = button.Text;

            // Clears the placeholder 0 from the display
            if (calcDisplay.Text == "0" || calcDisplay.Text == "Invalid Result")
            {
                calcDisplay.Text = str;
            } 
            else if (calcDisplay.Text == calculatorData.FirstNumber.ToString()) // Allows the first number to be in place until second number is entered.
            {
                calcDisplay.Text = str;
            }
            else // Appends new numbers
            {
                calcDisplay.Text += str;
            }
        }

        // Button for the decimal.
        private void periodBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Text;

            // Changes the placeholder 0 to a decimal 
            if (calcDisplay.Text == "0" || calcDisplay.Text == "Invalid Result")
            {
                calcDisplay.Text = "0" + str;
            }
            else // Appends the decimal to a number
            {
                if (!calcDisplay.Text.Contains("."))
                calcDisplay.Text += str;
            }
        }

        // Clear to the last operand.
        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            // Clears the display text
            calcDisplay.Text = "0";
        }

        // Clear all data.
        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clears the display text and object data
            calcDisplay.Text = "0";
            calculatorData.FirstNumber = 0;
            calculatorData.SecondNumber = 0;
            calculatorData.Operator = ' ';
        }


        // Remove last digit/operand clicked/added.
        private void backspaceBtn_Click(object sender, EventArgs e)
        {
            // There was an `out of bounds` error when using backspace on empty field
            if (calcDisplay.Text != "0" && calcDisplay.Text.Length > 1)
            {
                calcDisplay.Text = calcDisplay.Text.Substring(0, calcDisplay.Text.Length - 1);
            } 
            else if (calcDisplay.Text.Length == 1)
            {
                calcDisplay.Text = "0";
            }
            
            
        }

        // Takes the operand and first number and set them in the calculator object
        private void operatorBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char currentOperator = Char.Parse(button.Text);
            if (Double.TryParse(calcDisplay.Text, out double val))
            {
                calculatorData.FirstNumber = val;
                calculatorData.Operator = currentOperator;
            }
            else
            {
                calcDisplay.Text = "0";
            }
        }

        // Negation of the number. Flips between positive and negative.
        private void negateBtn_Click(object sender, EventArgs e)
        {
            // TODO: Check if display is 0 and doesn't add minus
            // Prepends a minus sign to the display text.
            if (calcDisplay.Text[0] != '-') // Checks if number is positive
            {
                calcDisplay.Text = "-" + calcDisplay.Text;
            } else // Change number to positive
            {
                calcDisplay.Text = calcDisplay.Text.Substring(1);
            }
        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(calcDisplay.Text, out double val))
            {
                calculatorData.SecondNumber = Double.Parse(calcDisplay.Text);
                switch (calculatorData.Operator)
                {
                    case '+':
                        calcDisplay.Text = (calculatorData.FirstNumber + calculatorData.SecondNumber).ToString();
                        break;
                    case '-':
                        calcDisplay.Text = (calculatorData.FirstNumber - calculatorData.SecondNumber).ToString();
                        break;
                    case '*':
                        calcDisplay.Text = (calculatorData.FirstNumber * calculatorData.SecondNumber).ToString();
                        break;
                    case '/':
                        if (calculatorData.SecondNumber == 0)
                        {
                            calcDisplay.Text = "Invalid Result";
                        }
                        else
                        {
                            calcDisplay.Text = (calculatorData.FirstNumber / calculatorData.SecondNumber).ToString();
                        }
                        break;
                }
            }    
            else
            {
                calcDisplay.Text = "0";
            }
        }
    }
}
