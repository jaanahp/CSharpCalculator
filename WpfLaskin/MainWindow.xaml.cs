using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
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

namespace WpfLaskin
{
    public partial class MainWindow : Window
    {

        //Toteuta laskin wpf-sovelluksena
        //ikkunassa painikkeet 1 - 9 ja =, sekä tuloksen näyttö
        //laskee yhteen 2 lukua(arvoltaan 1-9)
        //(optional: myös - *ja / )
        //Käyttö: paina numeroa(tulee näyttöön), paina toista numeroa(tulee näyttöön) paina =, tulos näyttöön
        //Optional, lisätty - * ja /, käyttö toteutettu seuraavasti mukaillen yllä annettua: paina ensimmäistä numeroa (tulee näyttöön),
        //paina toista numeroa (tulee näyttöön), paina haluttua operaattoria (tulee näyttöön), paina "=" ja tulos tulee näyttöön
        public MainWindow()
        {
            InitializeComponent();
        }

        //variables needed in more than one method
        List<double> numbers = new List<double>();
        double result = 0;
        
        //method for buttons 1-9
        private void numberBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string value = btn.Content.ToString();
            numbers.Add(Double.Parse(value));
            outputBox.Text = value;
        }
        //method for operator buttons + - * /
        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            Button opBtn = (Button)sender;
            string opValue = opBtn.Content.ToString();
            outputBox.Text = opValue;
            if (numbers.Count() == 2)
            {
                switch(opValue)
                {
                    case "+":
                        result = numbers[0] + numbers[1];
                        numbers.Clear();
                        break;
                    case "-":
                        result = numbers[0] - numbers[1];
                        numbers.Clear();
                        break;
                    case "*":
                        result = numbers[0] * numbers[1];
                        numbers.Clear();
                        break;
                    case"/":
                        result = numbers[0] / numbers[1];
                        numbers.Clear();
                        break;
                }
            }
            else
            {
                outputBox.Text = "Give only two numbers";
                numbers.Clear();
            }
        }


        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = result.ToString();
        }
    }
}
