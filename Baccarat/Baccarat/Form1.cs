namespace Baccarat
{
    public partial class Form1 : Form
    {
        int Deckers = 1;//幾幅撲克牌
        enum CardFlower
        {
            RedHeart,//紅心
            RedDiamond,//方塊
            BlackSpade,//黑桃
            BlackClub//梅花
        }

        struct Card
        {
            public int Number;
            public CardFlower Flower;
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InitialCards()
        {
            Card[] cards = new Card[52];

            int index = 0;

            // 1到13初始化卡牌
            for (int i = 1; i <= 13; i++)
            {
                // 4種花色
                for (int j = 0; j < 4; j++)
                {
                    cards[index] = new Card();
                    cards[index].Number = i;
                    cards[index].Flower = (CardFlower)j;
                    index++;
                }
            }

        }//InitialCards()
    }
}