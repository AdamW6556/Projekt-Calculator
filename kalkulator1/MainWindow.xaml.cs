using System;
using System.Collections.Generic;
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


namespace kalkulator1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        double wynik = 0;

        string dzialanie = "";

        bool wykonanie = true;
        
       
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((wykonanie==true))
            {
                textbox.Clear();
            }
            wykonanie = false;
            Button button = (Button)sender;



            if(button.Content.ToString()==",")
            {

               
                if(!textbox.Text.Contains(","))
                {

                    //textbox.Text =","+ textbox.Text;
                    textbox.Text =  textbox.Text+button.Content ;
                    
                }
            }

            else
            {
                textbox.Text = textbox.Text + button.Content ;
               // textbox.Text += button.Content;
            }
            
          
        }

        private void Operklik(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            dzialanie = (button.Content.ToString());

            try
            {
                wynik = Double.Parse(textbox.Text);
            }
            catch(FormatException)
            {
                textbox.Text = "!Zle wpisanie liczby";              
            }
            wykonanie = true;
        }


        private void czyscekran(object sender, RoutedEventArgs e)
        {
            
            textbox.Clear();          
        }

        private void zerowanie(object sender, RoutedEventArgs e)
        {
            textbox.Text = "0";
        }

        private void rownasie(object sender, RoutedEventArgs e)
        {

            try
            {
                switch (dzialanie)
                {

                    case "+":
                        textbox.Text = (wynik + Double.Parse(textbox.Text)).ToString();
                        break;

                    case "-":
                       
                        textbox.Text = (wynik - Double.Parse(textbox.Text)).ToString();
                        break;

                    case "*":
                        textbox.Text = (wynik * Double.Parse(textbox.Text)).ToString();
                        break;

                    case "/":
                       
                        if (Double.Parse(textbox.Text).ToString() == "0")
                        {
                            textbox.Text = "Blad dzielenia przez 0";
                        }
                        else
                        {
                            
                            textbox.Text = (wynik / Double.Parse(textbox.Text)).ToString();
                        }
                                              
                    break;

                default:
                    break;

                }

            }
            catch(FormatException)
            {
                textbox.Text = "!Zle wpisanie liczby";
            }
            wykonanie = true;
        }
    }
}
