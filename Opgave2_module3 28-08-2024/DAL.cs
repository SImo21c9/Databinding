using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Twoway_databinding;
using Opgave2_module3_28_08_2024;
using System.ComponentModel;
namespace SimpelDAL
{
    public class DAL : INotifyPropertyChanged
    {
        // Da vi ikke har adgang til en database, simulerer vi med denne private liste....
        private ObservableCollection<Person> DataBase;

        // Dette er objektet med elementer vi "deler ud" til brugeren af vores class.
        public ObservableCollection<Person> PublicListe 
        {
            get
            { 
                return new ObservableCollection<Person>(DataBase); // there is a problem with this part because usualy the change i make on the publicListe should effect the database but since they interconnected somehow.
                                                                   // When i make a change on the Publicliste which is a copy of the real database. After asking ChatGPT the solution is also the variables Id. Fornavn osv. 
            } 
            set
            { 
                _publicListe = value; 
            } 
        }
        private ObservableCollection<Person> _publicListe; // we're making a copy of the real database 

        //Constructoren genererer data til vores falske database
        public DAL()
        {
            DataBase = new ObservableCollection<Person>();
            DataBase.Add(new Person(0, "Svend", "Bendt", 1234));
            DataBase.Add(new Person(1, "Bein", "Stagge", -987654321));
            DataBase.Add(new Person(2, "Turt", "Khorsen", 0));
            DataBase.Add(new Person(3, "Gill", "Bates", int.MaxValue));
            _publicListe = new ObservableCollection<Person>(DataBase);
        }
        // Get henter data fra databasen og kopierer det over i den lokale kopi
        public ObservableCollection<Person> Get()
        {
            _publicListe.Clear(); //Først tømmes den lokale kopi
                                  //Så løber vi alle elementerne igennem i databasen og overfører til lokal kopi
            foreach (Person p in DataBase)
            {
                _publicListe.Add(p);
            }
            return _publicListe;
        }

        public int Delete(Person person)
        {
            int returværdi = 0;
            for (int i = _publicListe.Count - 1; i >= 0; i--)
            {
                if (_publicListe[i].Id == person.Id)
                {
                    _publicListe.RemoveAt(i);
                    returværdi++;
                }
            }
            return returværdi;
        }


        public int Update(int ID, string Fornavn, string Efternavn, int Formue)
        {
            // Vi laver en returværdi, så hvis vi ikke finder noget, returnerer vi 0
            int returværdi = 0;
            //Løber igennem listen en efter en, for at sammenligne ID
            foreach (Person p in _publicListe)
            {
                if (p.Id == ID)
                {
                    p.Fornavn = Fornavn;
                    p.Efternavn = Efternavn;
                    p.Formue = Formue;
                    returværdi++;
                }
            }
            return returværdi;

        }

        // Commit indsætter vores lokale kopi af data, i databasen
        public void Commit()
        {
            DataBase = new ObservableCollection<Person>(_publicListe);
            OnPropertyChanged("PublicListe");
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