using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Chiusino
{
    

    public static class UserManager
    {
        public static ObservableCollection<Utente> Users { get; } = new ObservableCollection<Utente>();

        static UserManager()
        {
            // Dati iniziali di esempio
        }

        public static void AddUser(Utente name)
        {
            if (!Users.Contains(name))
            {
                Users.Add(name);
            }
        }
        public static void UpdateUser(Utente user)
        {
            for(int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Equals(user))
                {
                    Users[i] = user;
                    return;
                }
            }
        }
    }
}
