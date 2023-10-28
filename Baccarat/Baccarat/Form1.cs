namespace Baccarat
{
    public partial class Form1 : Form
    {
        //1. config���Ѽ�
        //2

       

        int Deckers = 1;//�X�T���J�P
        Card[] Cards = new Card[52* 1];
        int IndexOfCard = 0; //�ĴX�i�P
        
        enum CardFlower
        {
            RedHeart,//����
            RedDiamond,//���
            BlackSpade,//�®�
            BlackClub//����
        }

        struct Card
        {
            public int Number;
            public CardFlower Flower;
        }

        public Form1()
        {
            InitializeComponent();
            InitialCards(Cards,Deckers);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shuffle(Cards, Deckers);
        }

        private void InitialCards(Card[] cards,int deckers)
        {

            //�ĴX��porkers
            for (int i = 0; i < deckers; i++)
            {
                // 1��13��l�ƥd�P
                for (int j = 1; j <= 13; j++)
                {
                    // 4�ت��
                    for (int k = 0; k < 4; k++)
                    {
                        cards[IndexOfCard] = new Card();
                        cards[IndexOfCard].Number = j;
                        cards[IndexOfCard].Flower = (CardFlower)k;
                        IndexOfCard++;
                        
                    }
                }
            }



        }//InitialCards()

        private void Shuffle(Card[] cards, int deckers)
        {
            Random ran = new Random();
            int a, b;
            Card temp;
            for (int i = 0; i < deckers * 52; i++)
            {
                a = ran.Next(51);
                b = ran.Next(51);

                temp = cards[a];
                cards[a] = cards[b];
                cards[b] = temp;
            }
        }//Shuffle()
    }
}