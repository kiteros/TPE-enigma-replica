namespace RSAllocation
{
    public partial class calculer : Form
    {
		private int pgcd(int a, int b)
        {
            while( a != b)
            {
                if(a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }
		
		private int factoriser(int n)
		{
			int b = 2;
			
			while(b)
			{
				b++;
			}
			
			if((n / b) == 1)
			{
				//afficher 'p=b'
				public static int p = b;
				break;
			}
			
			// afficher q=b
			public static int q = b;
			n = n / b;

        public calculer()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
		
        private void button1_Click(object sender, EventArgs e)
        {
			//On recupere n 
			int n = Int32.Parse(textBox?.Text);
			factoriser(n);
			int phiden = (p - 1) * (q - 1);
			
			int compteur = 0;
			int PGCD1 = 0;
			int e = 0;
			
			while(PGCD1 != 1)
			{
				while(compteur == 0)
				{
					if((p < e) && (q < e) && (e < phiden))
					{
						compteur = 1;
					}
					
					e++;
					
				}
				
				PGCD1 = pgcd(e,n);
			}
			
			int d = 0;
			compteur = 0;
			
			while(compteur == 0)
			{
				if((e * d % phiden == 1) && (p < d) && (q < d) && (d < phiden))
				{
					compteur = 1;
				}
				
				d++;
			}
			
			d = d - 1;
			
			//afficher 'd'
        }

    }
}
