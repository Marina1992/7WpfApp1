using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;

            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void cmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            // за шрифт отвещает свойство  FontFamily
            if (textBox != null)
            {
                double fontSize1 = Convert.ToDouble(fontSize);
                textBox.FontSize = fontSize1;
            }
        }




        private void boldButton_Click_1(object sender, RoutedEventArgs e)

        {
            // выделение текста жирным  

            if (textBox.FontWeight == FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }



        }

        // курсив
        private void italicButton_Click(object sender, RoutedEventArgs e)

        {
            if (textBox.FontStyle == FontStyles.Normal)


            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;

            }
        }


        private void Underline_Click(object sender, RoutedEventArgs e)
        {

            // подчеркивание текста 
            if (textBox.TextDecorations == null)

            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                textBox.TextDecorations = null;
            }

        }

        // красный цвет текста  
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }
        // черный цвет текста
        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

       
        


        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt;*.doc|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                textBox.Text = File.ReadAllText(openFileDialog.FileName);

            }

        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt;*.doc|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {

                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void ExitCanExecute(object sender, CanExecuteRoutedEventArgs e) 
        {
            
            if (textBox != null && textBox.Text.Length == 0) 
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }



    }


}
