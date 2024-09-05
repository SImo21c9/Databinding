using Opgave2_module3_28_08_2024;
using SimpelDAL;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Twoway_databinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Person Model { get; set; } = new(0, "", "", 0);
        DAL dal = new DAL();

        public MainWindow()
        {
            DataContext = dal;

            InitializeComponent();

        }


        private void VisData_Update(object sender, RoutedEventArgs e)
        {
            dal.Update(Model.Id, Model.Fornavn, Model.Efternavn, Model.Formue);
            Model = new(0, "", "", 0);
        }
        private void Update_Update_1(object sender, RoutedEventArgs e)
        {
            
            Person m = dg1.SelectedItem as Person;

            if (m != null)
            {
                m.Formue++;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Person m = dg1.SelectedItem as Person;
            if (m != null)
            {
                dal.Delete(m); 
                dal.Commit();   
            }
            else
            {
                MessageBox.Show("You're not clicking on any object");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dal.Commit();
        }



        //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Person p = e.AddedItems[0] as Person;

        //    if (p != null)
        //    {
        //        MessageBox.Show($"Du har valgt {p.Fornavn} {p.Efternavn}", "Du fangede en!" );

        //    }
        //}

    }
}
