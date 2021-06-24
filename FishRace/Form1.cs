using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishRace
{
    public partial class Form1 : Form
    {
        private readonly GuyCls[] currentPunter = new GuyCls[3];
        private readonly FishCls[] myFish = new FishCls[4];
        public int SelectedFishNumber;
        public Form1()
        {
            InitializeComponent();
        }

        private void FishRun() //Makes The Fish Move
        {
            myFish[0] = new FishCls { Name = "Fish 1", mypb = pictureBox1 };
            myFish[1] = new FishCls { Name = "Fish 2", mypb = pictureBox2 };
            myFish[2] = new FishCls { Name = "Fish 3", mypb = pictureBox3 };
            myFish[3] = new FishCls { Name = "Fish 4", mypb = pictureBox4 };

            var myrnd = new Random();
            var End = false;


            while (End == false)
            {
                for (var i = 0; i < 4; i++)
                {
                    myFish[i].mypb.Top += myrnd.Next(6, 12);
                    if (myFish[i].mypb.Top > 400)
                    {
                        End = true;

                        for (var j = 0; j < currentPunter.Length; j++)
                        {
                            currentPunter[j].Collect(i + 1); // dending on which kayaker won, the winning bettor collects his/her money

                            if (currentPunter[j].Cash == 0)
                            {
                                currentPunter[j].MyLabel.Text = currentPunter[j].PlayerName + " Is BANKRUPT!";
                            }


                        }
                        RadioButton[] rbs = { rbAniket, rbRaghuveer, rbNirmal };
                        for (int x = 0; x < rbs.Length; x++)
                            if (rbs[x].Checked)
                            {
                                lblMaxBet.Text = currentPunter[x].Cash.ToString();
                                break;
                            }
                        MessageBox.Show(myFish[i].Name + " Won!"); // displays in a label which kayaker won
                        ResetFish();
                        break;
                    }
                }

                Application.DoEvents();
                Invalidate();
            }
        }

        private void ResetFish() // resets the Fishes & bettors labels so they can keep betting
        {
            for (var i = 0; i < 4; i++)
            {
                myFish[i].mypb.Top = 105;
            }
            foreach (var guy in currentPunter)
                if (guy.Cash > 0)
                    guy.MyLabel.Text = guy.PlayerName + " Has Not Yet Placed A Bet!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRace.Enabled = false;
            for (int i = 0; i < currentPunter.Length; i++)
            {
                currentPunter[i] = GuyInfo.GetBettorInfo(i);
            }
            currentPunter[0].MyLabel = lblAniketResult;
            currentPunter[1].MyLabel = lblRaghuveerResult;
            currentPunter[2].MyLabel = lblNirmalResult;
            // generates new bettors each time to store data & idenifies which label belongs to which bettor
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            currentPunter[SelectedFishNumber].MyBet.Amount = Convert.ToInt16(numericUpDownBet.Value);
            currentPunter[SelectedFishNumber].MyBet.Fish = Convert.ToInt16(numericUpDownFish.Value);


            for (int i = 0; i < currentPunter.Length; i++)
            {
                if (currentPunter[i].Cash == 0) continue;
                currentPunter[i].MyLabel.Text = currentPunter[i].PlayerName + " Bet $" + currentPunter[i].MyBet.Amount + " On Fish " + currentPunter[i].MyBet.Fish;
            }

            btnRace.Enabled = true;
        }

        

        private void btnRace_Click(object sender, EventArgs e)
        {
            FishRun(); // makes the fish move from this method when button is clicked
        }

        private void rbAniket_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;

            if (rb.Checked)
            {
                switch (rb.Text)

                {
                    case "Aniket":
                        SelectedFishNumber = 0;
                        lblMaxBet.Text = currentPunter[0].Labelmax.Text;
                        numericUpDownBet.Maximum = Convert.ToDecimal(currentPunter[0].Labelmax.Text);
                        break;
                    case "Raghuveer":
                        SelectedFishNumber = 1;
                        lblMaxBet.Text = currentPunter[1].Labelmax.Text;
                        numericUpDownBet.Maximum = Convert.ToDecimal(currentPunter[1].Labelmax.Text);
                        break;
                    case "Nirmal":
                        SelectedFishNumber = 2;
                        lblMaxBet.Text = currentPunter[2].Labelmax.Text;
                        numericUpDownBet.Maximum = Convert.ToDecimal(currentPunter[2].Labelmax.Text);
                        break;
                }


                if (Convert.ToInt16(lblMaxBet.Text) == 0) // if a player has no money there label shows they are bankrupt
                {
                    rb.Enabled = false;

                }
            }
        }
    }
}
