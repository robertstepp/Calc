// Robert Stepp
// TINFO 200
// Calc
//////////////////////
// Change History
// Date         Developer   Description
// 01212020     rstepp      File creation and initial implementation of the application
//
// References Used
// Tutor, B. (2016, December 26). Tutor Icons. 
//      Retrieved January 21, 2020, from https://www.iconfinder.com/iconsets/tutor-icon-set
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Resets the output after use
            if (calculatorData.SecondNumber != 0)
            {
                calculatorData.FirstNumber = 0;
                calculatorData.SecondNumber = 0;
                calcDisplay.Text = "0";
            } 

            Button button = (Button)sender;
            string str = button.Text;

            // Clears the placeholder 0 from the display
            if (calcDisplay.Text == "0")
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
            if (calcDisplay.Text == "0")
            {
                calcDisplay.Text = str;
            }
            else // Appends the decimal to a number
            {
                calcDisplay.Text += str;
            }
        }

        // Clear to the last operand.
        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            // TODO: Clear last entered full number
        }

        // Clear all data.
        private void clearBtn_Click(object sender, EventArgs e)
        {
            calcDisplay.Text = "";
            // TODO: Code the clearing of the result
        }


        // Remove last digit/operand clicked/added.
        private void backspaceBtn_Click(object sender, EventArgs e)
        {
            calcDisplay.Text = calcDisplay.Text.Substring(0, calcDisplay.Text.Length - 1);
        }

        // Takes the operand and first number and set them in the calculator object
        private void operandBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char operand = Char.Parse(button.Text);
            calculatorData.FirstNumber = Double.Parse(calcDisplay.Text);
            calculatorData.Operand = operand;
        }

        // Negation of the number. Flips between positive and negative.
        private void negateBtn_Click(object sender, EventArgs e)
        {
            // COMPLETE: Create negate click activity
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
            calculatorData.SecondNumber = Double.Parse(calcDisplay.Text);
            switch (calculatorData.Operand)
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
                    calcDisplay.Text = (calculatorData.FirstNumber / calculatorData.SecondNumber).ToString();
                    break;
            }
        }
    }
}
