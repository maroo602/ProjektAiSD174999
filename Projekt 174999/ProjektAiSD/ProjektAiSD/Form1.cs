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
            MessageBox.Show("Marceli Budny 174999");
            pictureBox2.Image = Image.FromFile("karty.png");
            pictureBox1.Image = Image.FromFile("zeton.png");
            
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
            if (!int.TryParse(textBox1.Text, out int liczbaG) || liczbaG < 1)
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
            for (int i = 0; i < receG.Count; i++)
            {
                listBox1.Items.Add("Gracz " + (i + 1) + ": " + ToString(receG[i]));
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (receG.Count == 0)
            {
                MessageBox.Show("Rozdaj karty.");
                return;
            }
            listBox1.Items.Add(" ");
            for(int i=0; i < receG.Count; i++)
            {
                string uklad = UkladPokerowy(receG[i]);
                listBox1.Items.Add("Gracz " + (i+1)+": "+uklad);
            }
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
                    talia.Add(figura + " " + kolor + ";");
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
            for (int i = 0; i < liczbaG; i++)
            {
                List<string> Reka = new List<string>();
                for (int j = 0; j < liczbaKart; j++)
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
                        writer.WriteLine("Gracz " + (i + 1) + ": " + ToString(receG[i])+" Uk³ad pokerowy: "+ UkladPokerowy(receG[i])+".");
                        writer.WriteLine();
                    }
                }
                MessageBox.Show("Zapisano.");
                MessageBox.Show("Œcie¿ka: " + Path.GetFullPath(sciezka));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wyst¹pi³ b³¹d: " + ex.Message);
            }
        }

        private string UkladPokerowy(List<string> reka)
        {
            var figury = new List<string>();
            var kolory = new List<string>();

            foreach (var karta in reka)
            {
                var split = karta.Split(' ');
                figury.Add(split[0]);
                kolory.Add(split[1]);
            }
            var liczbaF = new Dictionary<string, int>();
            var liczbaK = new Dictionary<string, int>();
            foreach (var figura in figury)
            {
                if (liczbaF.ContainsKey(figura))
                {
                    liczbaF[figura]++;
                }
                else
                {
                    liczbaF[figura] = 1;
                }
            }
            foreach (var kolor in kolory)
            {
                if (liczbaK.ContainsKey(kolor))
                {
                    liczbaK[kolor]++;
                }
                else
                {
                    liczbaK[kolor] = 1;
                }
            }
            bool Kolor = false;
            foreach (var kolor in liczbaK)
            {
                if (kolor.Value == 5)
                {
                    Kolor = true;
                    break;
                }
            }
            var wartoscF = new List<int>();
            var slownikF = new Dictionary<string, int>
            {
                { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 }, { "Walet", 11 }, { "Królowa", 12 }, { "Król", 13 }, { "As", 14 }
            };
            foreach(var figura in figury)
            {
                wartoscF.Add(slownikF[figura]);
            }
            wartoscF.Sort();

            bool Strit = true;
            for(int i = 1; i < wartoscF.Count; i++)
            {
                if (wartoscF[i] != wartoscF[i - 1] + 1)
                {
                    Strit = false;
                    break;
                }
            }
            if(Kolor && Strit && wartoscF.SequenceEqual(new List<int> { 10, 11, 12, 13, 14 }))
            {
                return "Poker Królewski";
            }
            if(Kolor && Strit)
            {
                return "Poker";
            }
            if (liczbaF.Values.Contains(4))
            {
                return "Kareta";
            }
            if (liczbaF.Values.Contains(3) && liczbaF.Values.Contains(2))
            {
                return "Full";
            }
            if (Kolor)
            {
                return "Kolor";
            }
            if (Strit)
            {
                return "Strit";
            }
            if (liczbaF.Values.Contains(3))
            {
                return "Trójka";
            }
            int liczbaP = 0;
            foreach (var liczba in liczbaF.Values)
            {
                if (liczba == 2)
                {
                    liczbaP++;
                }
            }
                if (liczbaP == 2)
                {
                    return "Dwie Pary";
                }
                if(liczbaP == 1)
                {
                    return "Para";
                }
                return "Wysoka Karta";

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

