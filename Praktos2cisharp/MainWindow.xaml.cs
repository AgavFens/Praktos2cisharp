using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Threading;

namespace Praktos2cisharp
{
    public partial class MainWindow : Window
    {
        Zametki zametkich = new Zametki();
        List<Zametki> zametkichlistochek = new List<Zametki>();
        public MainWindow()
        {
            InitializeComponent();
            DatePickerka.Text = DateTime.Now.ToString();
            ListovalkaShow();
        }
        public void MySerialize()
        {
            MyConvert.MySerialize(zametkichlistochek);
        }
        public void CheckFile()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!File.Exists(desktop + "\\agavtop.json"))
            {
                File.Create(desktop + "\\agavtop.json");
                MessageBox.Show("Жэйсон файл создан перезайдите пж");
            }
        }
        public void MyDeserialize()
        {
            CheckFile();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.ReadAllText(desktop + "\\agavtop.json") != "")
            {
                zametkichlistochek = MyConvert.MyDeserialize<List<Zametki>>();
            }
        }
        private void Button_Click_Sozdavalka(object sender, RoutedEventArgs e)
        {
            MyDeserialize();
            zametkich.Data = DatePickerka.Text;
            zametkich.Name = Nazvanie.Text;
            zametkich.Opisanie = Opisanie.Text;
            zametkichlistochek.Add(zametkich);
            MySerialize();
            ListovalkaShow();
            MessageBox.Show("создана заметка жиес");
        }
        public void ListovalkaShow()
        {
            MyDeserialize();
            Listovalka.ItemsSource = zametkichlistochek.Select(item => item.Name);
        }

        private void Listovalka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listovalka.SelectedItem != null)
            {
                string selectedItem = Listovalka.SelectedItem.ToString();
                Zametki selectedNotebook = zametkichlistochek.FirstOrDefault(item => item.Name == selectedItem);
                if (selectedNotebook != null)
                {
                    Nazvanie.Text = selectedNotebook.Name;
                    Opisanie.Text = selectedNotebook.Opisanie;
                }
            }
        }


        private void Udalyalka_Click(object sender, RoutedEventArgs e)
        {
            if (Listovalka.SelectedItem != null)
            {
                string selectedItem = Listovalka.SelectedItem.ToString();
                Zametki zametkatoudalyte = zametkichlistochek.FirstOrDefault(item => item.Name == selectedItem);
                if (zametkatoudalyte != null)
                {
                    zametkichlistochek.Remove(zametkatoudalyte);
                    MySerialize();
                    MessageBox.Show("Заметка удалена жиес");
                    ListovalkaShow();
                }
            }
        }

        private void Sohranyalka_Click(object sender, RoutedEventArgs e)
        {
            if (Listovalka.SelectedItem != null)
            {
                string selectedItem = Listovalka.SelectedItem.ToString();
                Zametki selectedNotebook = zametkichlistochek.FirstOrDefault(item => item.Name == selectedItem);
                if (selectedNotebook != null)
                {
                    selectedNotebook.Name = Nazvanie.Text;
                    selectedNotebook.Opisanie = Opisanie.Text;
                    MySerialize();
                    MessageBox.Show("Изменения сохранены");
                    ListovalkaShow();
                }
            }
        }

    }
}