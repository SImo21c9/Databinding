using System.ComponentModel;

namespace Opgave2_module3_28_08_2024
{
    public class Person : INotifyPropertyChanged
    {
        private int id;
        private string fornavn;
        private string efternavn;
        private int formue;

        public int Id
        {
            get { return id; }
            set { id = value; 
                OnPropertyChanged("Id"); }
        }

        public string Fornavn
        {
            get { return fornavn; }
            set { fornavn = value; 
                OnPropertyChanged("Fornavn"); }
        }

        public string Efternavn
        {
            get { return efternavn; }
            set { efternavn = value;
                OnPropertyChanged("Efternavn"); }
        }

        public int Formue
        {
            get { return formue; }
            set { formue = value;
                OnPropertyChanged("Formue"); }
        }

        public Person(int id, string fornavn, string efternavn, int formue)
        {
            this.id = id;
            this.fornavn = fornavn;
            this.efternavn = efternavn;
            this.formue = formue;
        }

       


        public event PropertyChangedEventHandler PropertyChanged;
       
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

         
    }
}
