namespace ProjektAiSD
{
    public partial class Form1 : Form
    {
        private List<string> taliaK = new List<string>();
        private List<List<string>> receG = new List<List<string>>();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Gra w karty";
        }


        private void button5_Click(object sender, EventArgs e)
        {
            taliaK = UtworzTalie();
            listBox1.Items.Clear();
            listBox1.Items.Add("Talia zosta³a utworzona.");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (taliaK.Count == 0)
            {
                MessageBox.Show("Talia kart nie zosta³a utworzona.");
                return;
            }
            TasujTalie(taliaK);
            listBox1.Items.Clear();
            listBox1.Items.Add("Talia zosta³a potasowana.");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int liczbaG)|| liczbaG<1 || liczbaG > 10)
            {
                MessageBox.Show("Podaj poprawn¹ liczbê graczy. Maksymalna liczba = 10.");
                return;
            }
            if (taliaK.Count < liczbaG * 5)
            {
                MessageBox.Show("Za ma³o kart w talii, aby rozdaæ ka¿demu graczowi 5 kart.");
                return;
            }
            receG = rozdajK(taliaK, liczbaG, 5);
            listBox1.Items.Clear();
            for(int i = 0; i < receG.Count; i++)
            {
                listBox1.Items.Add("Gracz "+ (i+1)+": "+ ToString(receG[i]) );
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sciezka = "wylosowanekarty.txt";
            if (receG.Count == 0)
            {
                MessageBox.Show("Rozdaj karty.");
                return;
            }
            ZapiszTXT(sciezka, receG);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private List<string> UtworzTalie()
        {
            string[] figury = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Walet", "Królowa", "Król", "As" };
            string[] kolory = { "Kier", "Karo", "Pik", "Trefl" };
            List<String> talia = new List<string>();
            foreach (var kolor in kolory)
            {
                foreach (var figura in figury)
                {
                    talia.Add(figura + " " + kolor +";");
                }
            }
            return talia;
        }
        private void TasujTalie(List<string> talia)
        {
            Random random = new Random();
            for (int i = 0; i < talia.Count; i++)
            {
                int j = random.Next(i, talia.Count);
                string xd = talia[i];
                talia[i] = talia[j];
                talia[j] = xd;
            }
        }

        private List<List<string>> rozdajK(List<string> talia, int liczbaG, int liczbaKart)
        {
            List<List<string>> Rece = new List<List<string>>();
            for(int i = 0; i < liczbaG; i++)
            {
                List<string> Reka = new List<string>();
                for(int j=0;j< liczbaKart; j++)
                {
                    Reka.Add(talia[0]);
                    talia.RemoveAt(0);
                }
                Rece.Add(Reka);
            }
            return Rece;
        }
        private void ZapiszTXT(string sciezka, List<List<string>> receG)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(sciezka))
                {
                    for (int i = 0; i < receG.Count; i++)
                    {
                        writer.WriteLine("Gracz " + (i + 1) + ": " + ToString(receG[i]));
                        writer.WriteLine();
                    }
                }
                MessageBox.Show("Zapisano.");
                MessageBox.Show("Œcie¿ka: "+ Path.GetFullPath(sciezka));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wyst¹pi³ b³¹d: " + ex.Message);
            }
        }
        private string ToString(List<string> tab1)
        {
            string wynik = "";
            for (int i = 0; i < tab1.Count; i++)
            {
                wynik += tab1[i] + " ";
            }
            return wynik;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

