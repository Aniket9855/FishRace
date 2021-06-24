using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishRace
{
    public abstract class GuyCls
    {
        public Label MyLabel = new Label(); // update bet result labels
                                            //     public  RadioButton MyRadioButton = new RadioButton();
        public Label Labelmax = new Label(); // sets each persons max bet

        public string PlayerName { get; set; }
        public BetCls MyBet = new BetCls();
        public int Cash { get; set; }



        public void Collect(int Winner) // get mybet to payout, clear the bet and update maxbet label
        {
            if (MyBet != null)
                Cash += Payout(Winner);
            Labelmax.Text = Cash.ToString();
        }

        public int Payout(int Winner) // How much money to payout
        {
            if (MyBet.Fish == Winner)
                return MyBet.Amount; // return the amount bet
            return -MyBet.Amount; // return the negitave of amount bet 
        }
    }
}
