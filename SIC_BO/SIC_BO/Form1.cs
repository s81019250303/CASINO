using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIC_BO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Coins = 0;//放入總金額
        int BetCoins = 0;//下注的總金額
        string GameMode = string.Empty;//所選擇的遊戲模式
        int DiceMode = 0;//骰子出現的狀況 //1:big 2:small 4:odd 8:even
        int Dice1 = 0;
        int Dice2 = 0;
        int Dice3 = 0;
        private void btn_START_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var length = Convert.ToInt32(txt_total.Text);//全部的局數
            var eachGameBet = Convert.ToInt32(txt_eachGameBet.Text);
            txt_AllBets.Text = Convert.ToString(eachGameBet * length);
            var profit = 0;
            int banker = 0;
            int player = 0;
            int total = 0;
            int big = 0;
            int small = 0;
            int allTriples = 0;
            int Unconti = 0;
            int maxUnconti = 0;
            int smallCounti = 0;
            int maxSmallCounti = 0;
            int bigCounti = 0;
            int maxBigCounti = 0;
            string condi = string.Empty;
            rtxt_log.Clear();

            for (int i = 0; i < length; i++)
            {
                profit = profit - eachGameBet;
                Dice1 = random.Next(1, 7);
                Dice2 = random.Next(1, 7);
                Dice3 = random.Next(1, 7);

                total = Dice1 + Dice2 + Dice3;
                if (total > 3 && total < 11)
                {
                    //rtxt_log.SelectionColor = Color.Red;
                    bigCounti = 0;
                    condi = "小";
                    if (Dice1 == 2 && Dice2 == 2 && Dice3 == 2)
                    {
                        smallCounti = 0;
                    }
                    else if (Dice1 == 3 && Dice2 == 3 && Dice3 == 3)
                    {
                        smallCounti = 0;
                    }
                    else
                    {
                        small++;
                        smallCounti++;
                        if(smallCounti > maxSmallCounti)
                        {
                            maxSmallCounti = smallCounti;   
                        }
                    }

                }
                if (total > 10 && total < 18)
                {
                    smallCounti = 0;
                    //rtxt_log.SelectionColor = Color.Green;
                    condi = "大";

                    if (Dice1 == 4 && Dice2 == 4 && Dice3 == 4)
                    {
                        bigCounti = 0;
                    }
                    else if (Dice1 == 5 && Dice2 == 5 && Dice3 == 5)
                    {
                        bigCounti = 0;
                    }
                    else
                    {
                        big++;
                        bigCounti++;
                        if (bigCounti > maxBigCounti)
                        {
                            maxBigCounti = bigCounti;
                        }
                    }
                }

                if(Dice1 - Dice2 == 0 && Dice2 - Dice3 == 0)
                {
                    allTriples++;
                    Unconti = 0;
                    //rtxt_log.SelectionColor = Color.Blue;
                    profit = profit + eachGameBet + 36*eachGameBet;
                    condi = "全圍";
                }
                else
                {
                    Unconti++;
                    if(Unconti> maxUnconti)
                    {
                        maxUnconti = Unconti;   
                    }
                }

                if (length < 2000)
                {
                    rtxt_log.AppendText(Dice1.ToString() + " " + Dice2.ToString() + "  " + Dice3.ToString() + "  " + condi + Environment.NewLine);

                }

            }

            txt_total.Text = Convert.ToString(length);  
            txt_bigCount.Text = Convert.ToString(big);
            txt_bigRate.Text = Convert.ToString( Convert.ToDouble((double)big / (double)length)  );
            txt_smallCount.Text = Convert.ToString(small);
            txt_smallRate.Text = Convert.ToString(Convert.ToDouble((double)small / (double)length));
            txt_anyTriplesCount.Text = Convert.ToString(allTriples);
            txt_allTriplesRate.Text = Convert.ToString((double)allTriples / length);
            txt_maxUnConti.Text = Convert.ToString(maxUnconti);

            txt_bigContiCount.Text = Convert.ToString(maxBigCounti);
            txt_smallContiCount.Text = Convert.ToString(maxSmallCounti);
            txt_avgAllTriples.Text = Convert.ToString((double)length/ allTriples);
            txt_profit.Text = Convert.ToString(profit);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Coins = Coins + Convert.ToInt32(btn.Tag) ;
            txt_coins.Text = Coins.ToString();
        }

        private void btn_bet10_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(BetCoins + Convert.ToInt32(btn.Tag) <= Coins)
            {
                BetCoins = BetCoins + Convert.ToInt32(btn.Tag);
                txt_bet.Text = BetCoins.ToString();
            }
            else
            {
                MessageBox.Show("投注的金額不足");
            }

        }

        private void btn_big_Click(object sender, EventArgs e)
        {
            GameMode = "BIG";
            btn_big.BackColor = Color.Green;
            btn_small.BackColor = Control.DefaultBackColor;
            btn_allTriples.BackColor = Control.DefaultBackColor;
        }

        private void btn_small_Click(object sender, EventArgs e)
        {
            GameMode = "SMALL";
            btn_big.BackColor = Control.DefaultBackColor;
            btn_small.BackColor = Color.Green;
            btn_allTriples.BackColor = Control.DefaultBackColor;
        }

        private void btn_allTriples_Click(object sender, EventArgs e)
        {
            GameMode = "ALLTRIPLES";
            btn_big.BackColor = Control.DefaultBackColor;
            btn_small.BackColor = Control.DefaultBackColor;
            btn_allTriples.BackColor = Color.Green;

        }

        private void btn_useDice_Click(object sender, EventArgs e)
        {
            var random = new Random();
            int total = 0;
            Dice1 = random.Next(1, 7);
            Dice2 = random.Next(1, 7);
            Dice3 = random.Next(1, 7);

            total = Dice1 + Dice2 + Dice3;

            if(BetCoins == 0)
            {
                MessageBox.Show("沒有下注！");
                return;
            }

            switch (GameMode)
            {
                case "BIG":
                    if (total > 3 && total < 11)
                    {
                        MessageBox.Show("LOSS");
                        Coins = Coins - BetCoins;
                        //DiceMode = "SMALL";
                    }
                    if (total > 10 && total < 18)
                    {
                        if (Dice1 == 4 && Dice2 == 4 && Dice3 == 4)
                        {
                            MessageBox.Show("LOSS");
                            Coins = Coins - BetCoins;
                            //DiceMode = "ALLTRIPLES";
                        }
                        else if (Dice1 == 5 && Dice2 == 5 && Dice3 == 5)
                        {
                            MessageBox.Show("LOSS");
                            Coins = Coins - BetCoins;
                            //DiceMode = "ALLTRIPLES";
                        }
                        else
                        {
                            MessageBox.Show("WIN");
                            Coins = Coins + BetCoins * 2;
                            //DiceMode = "BIG";
                        }

                    }
                    break;

                case "SMALL":
                    if (total > 3 && total < 11)
                    {
                        if (Dice1 == 2 && Dice2 == 2 && Dice3 == 2)
                        {
                            MessageBox.Show("LOSS");
                            Coins = Coins - BetCoins;
                            //DiceMode = "ALLTRIPLES";
                        }
                        else if (Dice1 == 3 && Dice2 == 3 && Dice3 == 3)
                        {
                            MessageBox.Show("LOSS");
                            Coins = Coins - BetCoins;
                            //DiceMode = "ALLTRIPLES";
                        }
                        else
                        {
                            MessageBox.Show("WIN");
                            Coins = Coins + BetCoins * 2;
                            //DiceMode = "SMALL";
                        }
                    }
                    if (total > 10 && total < 18)
                    {
                        MessageBox.Show("LOSS");
                        Coins = Coins - BetCoins;
                        //DiceMode = "BIG";
                    }
                    break;

                case "ALLTRIPLES":

                    if (Dice1 - Dice2 == 0 && Dice2 - Dice3 == 0)
                    {
                        MessageBox.Show("WIN");
                        Coins = Coins + BetCoins * 24;
                        //DiceMode = "ALLTRIPLES";
                    }
                    else
                    {
                        MessageBox.Show("LOSS");
                        Coins = Coins - BetCoins;
                        if(total > 3 && total < 11)
                        {
                            //DiceMode = "SMALL";
                        }

                        if(total > 10 && total < 18)
                        {
                            //DiceMode = "BIG";
                        }
                    }
                    break;
            }

            txt_coins.Text = Coins.ToString();
            BetCoins = 0;
            txt_bet.Text = BetCoins.ToString();

            //switch (DiceMode)
            //{
            //    case "SMALL":
            //        rtxt_log.SelectionColor = Color.Red;
            //        break;
            //    case "BIG":
            //        rtxt_log.SelectionColor = Color.Green;
            //        break;
            //    case "ALLTRIPLS":
            //        rtxt_log.SelectionColor = Color.Blue;
            //        break;
            //}
            rtxt_log.AppendText(Dice1.ToString() + " " + Dice2.ToString() + "  " + Dice3.ToString() + "  " + DiceMode + Environment.NewLine);


        }

        private void rtxt_log_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            rtxt_log.SelectionStart = rtxt_log.Text.Length;
            // scroll it automatically
            rtxt_log.ScrollToCaret();
        }


    }
}
