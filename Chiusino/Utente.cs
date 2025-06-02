using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiusino
{
    public class Utente
    {
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public int Punti { get; set; } = 0;
        public DateTime DataCreazione { get; set; } = DateTime.Now;
        public List<string> Ruoli = new List<string>();
        public Utente()
        {
            Ruoli=ManageRuoli.GetRuoli();
        }
        public void AddRandomRole()
        {
            Ruoli.Add(ManageRuoli.GetSingleRole(this));
        }
        public override string ToString()
        {
            return Nome;
        }
        public override bool Equals(object obj)
        {
            if (obj is Utente other)
            {
                return Nome == other.Nome && Descrizione == other.Descrizione;
            }
            return false;
        }
    }
}
