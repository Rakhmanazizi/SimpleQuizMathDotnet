using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleQuizMath
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer
        // to generate random numbers.
        Random randomizer = new Random();

        // these integer variables store the numbers
        // for the addition problem.
        int addend1;
        int addend2;

        // these integer variables stor the numbers
        // for the substraction problem
        int minuend;
        int subtrahend;

        // these integer variables store the numbers
        // for the multiplication problem
        int multipicand;
        int multiplier;

        // these integer variables store the numbers
        // for the division problem
        int dividend;
        int divisior;

        // This integer variable keeps track of the
        // remaining time.
        int timeLeft;

        public void StartTheQuiz()
        {
            // fill in the addition problem
            // generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name if the NumericUpDown control.
            // this step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Fill in the substraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiple problem
            multipicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timeLeftLabel.Text = multipicand.ToString();
            timeRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem
            divisior = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisior * temporaryQuotient;
            devidedLeftLabel.Text = dividend.ToString();
            devidedeRightLabel.Text = divisior.ToString();
            quotient.Value = 0;

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = timeLeft + " seconds";
            timer1.Start();
            timeLabel.BackColor = Color.Red;
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) 
                && (minuend - subtrahend == difference.Value)
                && (multipicand * multiplier == product.Value)
                && (dividend / divisior == quotient.Value))
                return true;
            else 
                return false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButtonQuiz_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButtonQuiz.Enabled = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // if CheckTheAnswer() return true, then the user
                // got the answer right. Stop the timer
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButtonQuiz.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // if CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by on esecond
                // and display the new time left by updating the 
                // Time left label
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // if the user ran out the time, stop the timer, show
                // a messagesBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multipicand * multiplier;
                quotient.Value = dividend / divisior;
                startButtonQuiz.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
