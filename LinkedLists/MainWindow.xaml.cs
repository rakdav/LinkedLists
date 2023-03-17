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
        private OurLinkedList<int> ints;
        private DoublyLinkedList<int> intDoubly;
        
        public MainWindow()
        {
            InitializeComponent();
            ints = new OurLinkedList<int>();
            intDoubly=new DoublyLinkedList<int>();
            btnClear.IsEnabled=false;
            btnDelete.IsEnabled=false;
            btnContains.IsEnabled=false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (one.IsChecked == true)
                {
                    ints.Add(int.Parse(txtNumber.Text));
                }
                else 
                {
                    intDoubly.Add(int.Parse(txtNumber.Text));
                }
                updateList();
                txtNumber.Clear();
                btnClear.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnContains.IsEnabled = true;
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
            if (one.IsChecked==true)
            {
                foreach (int i in ints)
                {
                    listBoxList.Items.Add(i);
                }
            }
            else
            {
                foreach (int i in intDoubly)
                {
                    listBoxList.Items.Add(i);
                }
            }
        }

        private void btnAddFirst_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (one.IsChecked == true)
                    ints.AddFirst(int.Parse(txtNumber.Text));
                else
                    intDoubly.AddFirst(int.Parse(txtNumber.Text));
                updateList();
                txtNumber.Clear();
                btnClear.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnContains.IsEnabled = true;
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
                if(MessageBox.Show("Вы действительно хотите удалить "+
                    listBoxList.SelectedItem.ToString()+"?", "Внимание",
                    MessageBoxButton.OKCancel,MessageBoxImage.Question)==MessageBoxResult.OK)
                {
                    if (one.IsChecked == true)
                        ints.Remove(int.Parse(listBoxList.SelectedItem.ToString()));
                    else
                        intDoubly.Remove(int.Parse(listBoxList.SelectedItem.ToString()));
                    updateList();
                    if(ints.Count==0)
                    {
                        btnClear.IsEnabled = false;
                        btnDelete.IsEnabled = false;
                        btnContains.IsEnabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент из списка",
                    "Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите очистить список?",
                "Вопрос", MessageBoxButton.OKCancel, MessageBoxImage.Question) ==
                MessageBoxResult.OK)
            {
                if (one.IsChecked == true)
                    ints.Clear();
                else
                    intDoubly.Clear();
                updateList();
                btnClear.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnContains.IsEnabled = false;
            }
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
