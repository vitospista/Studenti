using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Properties
{
    class FieldPerson
    {
        public readonly string Name;

        public FieldPerson(string name)
        {
            /*
             * Voglio un controllo per evitare che la stringa sia vuota.
             * Quando leggo il valore dall'esterno, voglio che
             * ci siano dei caratteri dentro.
             * 
             * if (name == null)
             *     throw new ArgumentNullException("name");
             * però potrei mettere stringa vuota "".
             * 
             * if (name == null || name == "")
             *     throw new ArgumentNullException("name");
             * però potrei mettere "    " con n spazi dentro 
             * 
             * if (name == null || name == "" || )
             *     throw new ArgumentNullException("name");
             * però potrei mettere "    " con n spazi dentro 
             *
             * if (name == null || name == new string(' ', name.Length)) 
             *     throw new ArgumentNullException("name");
             * però potrei inserire caratteri vuoti "speciali": \t, \r\n
             * 
             */

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            this.Name = name;
        }
    }

    class ExtendedPropertyPerson
    {
        public string Name
        {
            get { return this.name; }
        }
        private readonly string name;

        public ExtendedPropertyPerson(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            this.name = name;
        }
    }

    class ReducedPropertyPerson
    {
        public string Name { get; }

        public ReducedPropertyPerson(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            this.Name = name;
        }

        // se implemento il get, non posso usare il set auto-implementato
        // e viceversa.
        // Il codice sottostante NON compila.
        //public string Surname
        //{
        //    get { return this.surname; }
        //    set;
        //}
        //private string surname;
    }

    class PrivateSetPropertyPerson
    {
        public void SaveOnDatabase()
        {
            // ...
            // ... save on db
            // ...

            this.LastSave = DateTime.Now;
        }

        public void DeleteFromDatabase()
        {
            // ...
            // delete from db
            // ...

            this.LastSave = new DateTime();
        }

        // Se ho bisogno di modificare il valore all'interno della classe
        // più volte, non posso usare una only-get property.
        // posso usare proprietà + campo:
        //public DateTime LastSave
        //{
        //    get { return this.lastSave; }
        //}
        //private DateTime lastSave;

        // oppure uso le property auto-implementate,
        // con modificatori di accesso diversi tra get e set
        public DateTime LastSave { get; private set; }
    }
}
