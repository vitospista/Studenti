using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Interfaces2Library
{
    public class Person
    {
        public Person(ICompleteNameListener listener)
        {
            _listener = listener;
        }

        private ICompleteNameListener _listener;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; _listener.SetNewCompleteName(CompleteName); }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; _listener.SetNewCompleteName(CompleteName); }
        }

        public string CompleteName
        {
            get { return $"{Name} {Surname}"; }
        }
    }

    public interface ICompleteNameListener
    {
        void SetNewCompleteName(string completeName);
    }
}
