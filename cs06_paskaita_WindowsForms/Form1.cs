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
                calc += item; // <-- šitas kintamasis yra skirtas sumai visų pažymių gauti
                counter++;    // <-- šitas kintamasis yra skirtas pažymių (kaip atskirų vienetų) skaičiui gauti
            }                 //     aišku galima tiesiog paskui būtų list1Sem.Count()+list2Sem.Count()+list2Sem.Count() naudoti

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
                richTextBox12.AppendText($"\rĮvesties #{KMI.IndexOf(index) + 1} KMI:"); // <-- čia tiesiog mandras būdas foreach'e nusitaikyti į index'ą list'e. For'e tiesiog [i] būtų
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
        }


        // Listbox
        private void button12_Click(object sender, EventArgs e) // <-- Mygtuko paspaudimas ideda reikšmę į listą'.
        {
            listBox1.Items.Add(int.Parse(richTextBox14.Text)); // <-- Būtinas parse naudojimas, nes by default priimamas stringo tipo variable);
        }                                                      //     Galbūt verta atkreipti dėmesį, kad listo jokio nebekuriu
                                                               //     Listbox'as kaip funkcija viską jau turi savyje
        private void button13_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
        }// listBox1.Items.Remove <-- nurodo ką mes darysime / kuo ar kokiu objektu manipuliuojame


        //                      (listBox1.Items <-- nurodo iš kur trinsime
        //                                     [listBox1.SelectedIndex]); <-- nurodo, kad trinsime pažymėta index'ą (Formoje pačioje)
        // alternatyviai stackoverflow sprendimai, galima ir su if tą daryti ir su while ir foreach.
        // https://stackoverflow.com/questions/13149486/delete-selected-items-from-listbox
        // Ne iki galo suprantu alternatyvius sprendimus trynimui;


        // Temperatūros skaičiuoklės
        private void button14_Click(object sender, EventArgs e)
        {
            double CtoF = double.Parse(richTextBox15.Text); // <-- Susukuriu kintąjį ir sakau, kad box'e15 daiktas yra jo value (parse'inu, su stringu matematika negalima)
            CtoF = CtoF * 1.8 + 32;                         // <-- tą value konfertuoju pagal formulę ir priskiriu naują reikšmę
            richTextBox16.Text = CtoF.ToString();           // <-- konvertuoju double į string'ą ir spausdinu box16
                                                            //     nenaudoju AppendText, kad nesikauptų langelyje skaičiai
            // C° to F°: Celsius to Fahrenheit Conversion Formula
            // To convert temperatures in degrees Celsius to Fahrenheit
            // multiply by 1.8(or 9 / 5) and add 32.
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Čia aprašysiu labiau supresuotu būdu tą patį kaip ir prieš tai (tik formulė kita)
            richTextBox16.Text = (double.Parse(richTextBox15.Text) + 273.15).ToString(); // <-- nieko neinicijuoju tik pasakau, kaip pakeisti ir spausdinti
                                                                                         //     (ta prasme rankiniu būdu; pagal nutylėjimą tikriausiai vistiek kažkas inicializuojasi)
            //According to the Celsius to Kelvin formula, by adding 273.15,
            //the temperature in Celsius can be converted to the temperature in Kelvin.
            //Thus, 0°C = 0 + 273.15 = 273.15 K.
        }

        private void button16_Click(object sender, EventArgs e)
        {
            richTextBox16.Text = (double.Parse(richTextBox15.Text) * 0.8).ToString();
            // iš rečiau naudojamų skalių pažymėtina Reomūrio skalė
            // R = 0.8 * C
        }
    }
}
