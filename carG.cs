//First, create a new Windows Forms project in Visual Studio.

//In the form designer, add a PictureBox control named "car" and set its Image property to an image of a car. Also, add a Timer control named "gameTimer" and set its Interval property to 20 (this will be used to update the position of the car on the screen).

//Then, add the following code to the form's code-behind file:




using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRacingGame
{
    public partial class Form1 : Form
    {
        private int roadSpeed = 5;
        private int carSpeed = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the road
            road1.Top += roadSpeed;
            road2.Top += roadSpeed;

            if (road1.Top >= this.Height)
            {
                road1.Top = -road1.Height;
            }

            if (road2.Top >= this.Height)
            {
                road2.Top = -road2.Height;
            }

            // Move the car
            if (car.Left >= 20 && car.Left <= 470)
            {
                if (Keys.Left == true)
                {
                    car.Left -= carSpeed;
                }

                if (Keys.Right == true)
                {
                    car.Left += carSpeed;
                }
            }

            // Check for collision with other cars
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && (string)control.Tag == "car")
                {
                    if (car.Bounds.IntersectsWith(control.Bounds))
                    {
                        gameTimer.Enabled = false;
                        MessageBox.Show("Game Over!");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the game timer
            gameTimer.Enabled = true;

            // Create other cars
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                PictureBox car = new PictureBox();
                car.Tag = "car";
                car.Image = Properties.Resources.car;
                car.SizeMode = PictureBoxSizeMode.StretchImage;
                car.Left = random.Next(20, 440);
                car.Top = -(i + 1) * 150;
                car.Width = 50;
                car.Height = 100;
                this.Controls.Add(car);
            }
        }
    }
}



