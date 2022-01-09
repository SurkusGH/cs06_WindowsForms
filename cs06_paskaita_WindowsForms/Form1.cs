using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs06_paskaita_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Vardas negali būti tuščias");
                return;
            }
            richTextBox2.Text = $"Sveikas {richTextBox1.Text}";
            richTextBox2.AppendText($"\r\nMalonu tave matyti");
        }

        // Paspaudus mygtuką parodyti savo vardą ir šiandienos datą
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = $"Vardas {richTextBox1.Text}";
            richTextBox3.AppendText($"\r\n{DateTime.Now}");
        }
        //paspaudus mygtuką išvesti savo vardą 10 kartų
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                richTextBox3.AppendText($"\r\n{i+1} {richTextBox1.Text}");
            }
        }
        // padaryti įvedimo langą "Skaičius"
        // Mygtuko paspaudimu parodyti ar tai lyginis ar nelygnis skaičius
        private void button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(richTextBox5.Text) %2 == 0)
            {    
                richTextBox4.Text = $"Skaičius {richTextBox5.Text} yra lyginis";
                return;
            }
            else
            {
                richTextBox4.Text = $"Skaičius {richTextBox5.Text} yra nelyginis";
            }
        }

        // Sukurti 3 įvedimo laukus "Pirmas semestras", "antras semestras", "trečias semestras",
        // Išvedimo lange parodyti semestrų pažymius ir metinį vidurkį

        List<int> list1Sem = new List<int>();
        List<int> list2Sem = new List<int>();
        List<int> list3Sem = new List<int>();

        double calc = 0;
        Double counter = 0;

        private void button6_Click(object sender, EventArgs e)
        {

            richTextBox9.AppendText($"\nPirmas semestras: ");
            foreach (var item in list1Sem)
            {
                richTextBox9.AppendText($"\n{item}");
                calc += item;
                counter++;
            }

            richTextBox9.AppendText($"\nAntras semestras: ");
            foreach (var item in list2Sem)
            {
                richTextBox9.AppendText($"\n{item}");
                calc += item;
                counter++;
            }

            richTextBox9.AppendText($"\nTrečias semestras: ");
            foreach (var item in list3Sem)
            {
                richTextBox9.AppendText($"\n{item}");
                calc += item;
                counter++;
            }

            richTextBox9.AppendText($"\nVidurkis: {calc/counter}");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            list1Sem.Add(int.Parse(richTextBox6.Text));
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            list2Sem.Add(int.Parse(richTextBox7.Text));
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            list3Sem.Add(int.Parse(richTextBox8.Text));
        }


        //Globalūs kintamieji <-- iš esmės reiškia, kad kintamieji yra pasiekiami uš betkurios vietos programoje

        List<double> Weight = new List<double>();
        List<double> Height = new List<double>();

        private void button1_Click(object sender, EventArgs e)
        {
            Height.Add(double.Parse(richTextBox10.Text));
            Weight.Add(double.Parse(richTextBox11.Text));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Weight.Count(); i++)
            {
                richTextBox12.AppendText($"\rĮvestis #{i+1}"); // <--kadangi indeksacija nuo nulio, vartotojui rodome nuo 1
                richTextBox12.AppendText($"\n   Ūgis {Height[i]}");
                richTextBox12.AppendText($"\n Svoris {Weight[i]}");
            }
        }
        // KMI skaičiuoklė
        // KMI = masė (Kg)/ (ūgis(m)pow(ūgis,2)
        // 18,5 > KMI asmuo yra nusilpęs ir svoris per mažas
        // 18,5 - 25  - idealus kūno masės indeksas
        // 25 - 30 asmuo turi antsvorį
        // 30 < KMI - asmuo yra nutukęs

        //Kadangi ankstenio pavyzdžio pusė yra analogiška daliai šito uždavinio, nebesikartoju
        List<double> KMI = new List<double>();

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Weight.Count(); i++)
            {
                KMI.Add(Weight[i] / Math.Pow((Height[i]/100), 2)); // <-- Čia mes susimetame KMI reikšmes į KMI list'ą
            }
            // Tuomet mes su if'u foreach'e pasidarome skirstytuvą:
            foreach (var index in KMI)
            {
                if (index < 18.5) richTextBox13.AppendText($"\nSvorio - {Weight[KMI.IndexOf(index)]}" +
                    $"\n ir ūgio - {Height[KMI.IndexOf(index)]} " +
                    $"\nKMI yra {index}," +
                    $"\n kategorizacija: 18,5 > KMI asmuo yra nusilpęs ir svoris per mažas");
                if (index >= 18.5 && index <25) richTextBox13.AppendText($"\nSvorio {Weight[KMI.IndexOf(index)]}" +
                    $"\n ir ūgio {Height[KMI.IndexOf(index)]} " +
                    $"\nKMI yra {index}," +
                    $"\nkategorizacija: 18,5 < KMI < 25  - idealus kūno masės indeksas");
                if (index >= 25 && index <= 30) richTextBox13.AppendText($"\nSvorio {Weight[KMI.IndexOf(index)]}" +
                     $"\n ir ūgio {Height[KMI.IndexOf(index)]} " +
                     $"\nKMI yra {index}," +
                     $"\nkategorizacija: 25 < KMI < 30 asmuo turi antsvorį");
                if (index > 30) richTextBox13.AppendText($"\nSvorio {Weight[KMI.IndexOf(index)]}" +
                     $"\n ir ūgio {Height[KMI.IndexOf(index)]} " +
                     $"\nKMI yra {index}," +
                     $"\nkategorizacija: 30 < KMI - asmuo yra nutukęs");
            }

            // richTextBox13.AppendText
        }
    }
}
