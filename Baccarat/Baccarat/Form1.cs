namespace Baccarat
{
    public partial class Form1 : Form
    {
        int Deckers = 1;//�X�T���J�P
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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InitialCards()
        {
            Card[] cards = new Card[52];

            int index = 0;

            // 1��13��l�ƥd�P
            for (int i = 1; i <= 13; i++)
            {
                // 4�ت��
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