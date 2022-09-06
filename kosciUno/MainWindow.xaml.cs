using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kosciUno
{
    public partial class MainWindow : Window
    {
        public ObservableCollection <Dice> results { get; set; }
        public ObservableCollection <Score> scores { get; set; }
        public int NumberOfDice { get; set; }
        private int NumberOfTries;
        private int NumberOfTriesW = 3;
        private int SumOfPunkty = 0;
        private int aktualnePointsy = 0;

        public MainWindow()
        {
            InitializeComponent();
            results = new ObservableCollection <Dice>();
            scores = new ObservableCollection <Score>();
            DataContext = this;
            NumberOfDice = 5;
            preparegame();
        }

        private void preparegame()
        {
            NumberOfTries = NumberOfTriesW;
            scores.Add(new Score("jedynki"));
            scores.Add(new Score("dwójki"));
            scores.Add(new Score("trójki"));
            scores.Add(new Score("czwórki"));
            scores.Add(new Score("piątki"));
            scores.Add(new Score("szóstki"));
            
            scores.Add(new Score("para"));
            scores.Add(new Score("dwie pary"));
            scores.Add(new Score("trójka"));
            scores.Add(new Score("full (2+3)"));
            scores.Add(new Score("kareta"));
            scores.Add(new Score("poker"));
            scores.Add(new Score("mały street"));
            scores.Add(new Score("duży street"));
            scores.Add(new Score("szansa"));
        }

        private void showPoint()
        {
            for(int i = 0; i < 6; i++)
            {
                if(scores[i].IsSet == false)
                { scores[i].Points = sumaGorna(results, i + 1); }
            }

            if (scores[6].IsSet == false) //para
            { scores[6].Points = sumPara(results, 2); }

            if (scores[7].IsSet == false) //dwie pary
            { scores[7].Points = sumDwiePary(results); }

            if (scores[8].IsSet == false) //trójka
            { scores[8].Points = sumPara(results, 3); }

            if (scores[9].IsSet == false) //full
            { scores[9].Points = sumFull(results); }

            if (scores[10].IsSet == false) //kareta
            {
                if(sumPara(results, 4) != 0)
                { scores[10].Points = sumPara(results, 4) + 20; }
            }

            if (scores[11].IsSet == false) //poker, czyli 5 takich samych kości
            { 
                if (sumPara(results, 5) != 0)
                { scores[11].Points = sumPara(results, 5) + 50; }
            }

            if (scores[12].IsSet == false) //mały strit, czyli 12345 z nagrodą 15 pkt
            { scores[12].Points = sumStrit(results, 1, 5); }

            if (scores[13].IsSet == false) //duży strit, czyli 12345 z nagrodą 15 pkt
            { scores[13].Points = sumStrit(results, 2, 6); }

            if (scores[14].IsSet == false) //szansa, czyli po prostu suma kości
            { scores[14].Points = sumAll(results); }
        }

        private int sumaGorna(ObservableCollection<Dice> tablica, int wartosc)
        {
            int s = 0, licznik = 0;
            foreach(Dice dice in tablica)
            {
                if(dice.Value == wartosc)
                { licznik++; }
            }
            s = (licznik - 3) * wartosc;
            return s;
        }

        private int sumAll(ObservableCollection<Dice> tablica)
        {
            int s = 0;
            foreach (Dice d in tablica)
            { s = s + d.Value; }
            if(NumberOfTries == NumberOfTriesW - 1)
            { s *= 2; }
            return s;
        }

        private int sumPara(ObservableCollection<Dice> tablica, int ile)
        {
            int s = 0;
            for(int i = 6; i > 0; i--)
            { 
                if(tablica.Count(x => x.Value == i) >= ile)
                { return i * ile; }
            }
            return s;
        }

        private int sumDwiePary(ObservableCollection<Dice> tablica)
        {
            int s = 0, ds = 0, licznik = 0, znalezione = 0;
            for (int i = 6; i > 0; i--)
            {
                znalezione = tablica.Count(x => x.Value == i);
                while (znalezione >= 2)
                {
                    ds += i * 2;
                    licznik++;
                    znalezione -= 2;
                    if (licznik == 2)
                    { return ds; }
                }
            }
            return s;
        }

        private int sumFull(ObservableCollection<Dice> tablica)
        {
            int s = 0, ds = 0, znalezione = 0, dwójki = 0, trójki = 0;
            for (int i = 6; i > 0; i--)
            {
                znalezione = tablica.Count(x => x.Value == i);
                if (znalezione == 5)
                { return (i * 5) + 10; }
                if (znalezione == 3)
                {
                    ds += i * 3;
                    trójki++;
                }
                if(znalezione == 2)
                {
                    ds += i * 2;
                    dwójki++;
                }
                if(trójki >= 1 && dwójki >= 1)
                { return ds + 10; }
            }
            return s;
        }

        private int sumStrit(ObservableCollection<Dice> tablica, int od, int doIlu)
        {
            var lista = new List<int>();
            var potrzebne = new List<int>();

            for (int i = 0; i < tablica.Count; i++)
            { lista.Add(tablica[i].Value); }

            for(int i = od; i <= doIlu; i++)
            { potrzebne.Add(i); }

            if(lista.Contains(potrzebne[0]) && lista.Contains(potrzebne[1]) && lista.Contains(potrzebne[2]) && lista.Contains(potrzebne[3]) && lista.Contains(potrzebne[4]))
            {
                if (od == 1)
                { return 15; }
                if(od == 2)
                { return 20; }
            }
            return 0;
        }


        private void rollbtn_Click(object sender, RoutedEventArgs e)
        {
            if(NumberOfTries > 0)
            {
                var random = new Random();
                foreach (var item in results)
                {
                    if (!item.IsSelected)
                    { item.Value = random.Next(1, 7); } //Będzie 1,2,3,4,5 lub 6 (od pierwszej do liczby przed drugą)
                }
                NumberOfTries--;
            }
            else
            { rollbtn.IsEnabled = false; }
            showPoint();
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            results.Clear();
            for (i = 0; i < NumberOfDice; i++)
            { results.Add(new Dice()); }
            wynik.Text = "0";
            rollbtn.IsEnabled = true;
            scores.Clear();
            preparegame();
        }

        private void dicebtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dice = button.DataContext as Dice;
            dice.IsSelected = ! dice.IsSelected;
        }

        private void zatwierdzbtn_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczone = 0;
            foreach (Score score in scores)
            {
                if (score.IsSet == true && score.IsEnabled == true)
                { zaznaczone++; }
            }
            if(zaznaczone == 1)
            {
                foreach (Score score in scores)
                {
                    if (score.IsSet == true && score.IsEnabled == true)
                    {
                        score.IsEnabled = false;
                        aktualnePointsy = score.Points;
                        if (NumberOfTries == 2)
                        { aktualnePointsy *= 2; }
                        SumOfPunkty += aktualnePointsy;
                    }
                    if(score.IsSet == false)
                    { score.Points = 0; }
                }
                wynik.Text = SumOfPunkty.ToString();
                NumberOfTries = NumberOfTriesW;
                rollbtn.IsEnabled = true;
                results.Clear();
                for (int i = 0; i < NumberOfDice; i++)
                { results.Add(new Dice()); }
            }
            else if(zaznaczone == 0)
            { MessageBox.Show("Aby zatwierdzić zaznacz którąkolwiek kategorię."); }
            else
            { MessageBox.Show("Możesz wybrać tylko jedną kategorię."); }
        }

        private void ukryj(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "IsEnabled")
            { e.Column.Visibility = Visibility.Collapsed; }
        }
    }
}
