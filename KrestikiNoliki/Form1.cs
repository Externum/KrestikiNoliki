using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrestikiNoliki
{
    public partial class Form1 : Form
    {
        private const int buttonSize = 85;
        private const int areaSize = 3;
        private int startCoords = 12;
        private int locationX;
        private int locationY;
        private int cnt = 0;

        Game game = new Game();

        public Form1()
        {
            InitializeComponent();
            GenerateButtons();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button buttonSender = sender as Button;

            buttonSender.Text = game.Turn;
            buttonSender.Enabled = false;
            game.SaveTurn((int)buttonSender.Tag, buttonSender.Text);
            if (game.CheckResult())
            {
                MessageBox.Show("Победили " + game.Turn);
                Application.Exit();
            }
            else if (game.CheckFullArea())
            {
                MessageBox.Show("Ходов больше нет!");
                Application.Exit();
            }
            else
            {
                game.ChangeTurn();
            }
        }

        public void GenerateButtons()
        {
            locationX = startCoords;
            locationY = startCoords;
            for (int x = 0; x < areaSize; x++)
            {
                for (int y = 0; y < areaSize; y++)
                {
                    Button button = new Button();
                    button.Tag = cnt;
                    button.Location = new Point(locationX, locationY);
                    button.Size = new Size(buttonSize, buttonSize);
                    button.Font = new Font(FontFamily.GenericSansSerif, 50.0F, FontStyle.Bold);
                    buttonPanel.Controls.Add(button);
                    button.Click += new EventHandler(Button_Click);
                    cnt++;
                    locationX += buttonSize;
                }
                locationY += buttonSize;
                locationX = startCoords;
            }
        }
    }
}
