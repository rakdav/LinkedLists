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

namespace LinkedLists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinkedList<int> ints;
        public MainWindow()
        {
            InitializeComponent();
            ints = new LinkedList<int>();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ints.Add(int.Parse(txtNumber.Text));
                updateList();
                txtNumber.Clear();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void updateList()
        {
            listBoxList.Items.Clear();
            foreach (int i in ints)
            {
                listBoxList.Items.Add(i);
            }
        }

        private void btnAddFirst_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ints.AddFirst(int.Parse(txtNumber.Text));
                updateList();
                txtNumber.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxList.SelectedIndex >= 0)
            {
                ints.Remove(int.Parse(listBoxList.SelectedItem.ToString()));
                updateList();
            }
            else
            {
                MessageBox.Show("Выберите элемент из списка",
                    "Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ints.Clear();
            updateList();
        }

        private void btnContains_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ints.Count != 0)
                {
                    if (ints.Contains(int.Parse(txtNumber.Text)))
                    {
                        txbResult.Text = "Найден";
                        txbResult.Foreground = Brushes.Green;
                    }
                    else
                    {
                        txbResult.Text = "Не найден";
                        txbResult.Foreground = Brushes.Red;
                    }
                }
                else
                {
                    MessageBox.Show("Введите элементы списка",
                    "Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Введите элемент для поиска",
                    "Внимание", MessageBoxButton.OK, 
                MessageBoxImage.Warning);

            }
        }
    }
}
