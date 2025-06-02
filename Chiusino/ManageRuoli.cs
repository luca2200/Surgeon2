using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Chiusino
{
    public static class ManageRuoli
    {
        public static List<string> ruoli = new List<string>
        {
 "Cacciatore di alieni",
                "Addestratore di draghi",
                "Esperto di fenomeni paranormali",
            "Domatore di leoni marini",
            "Archeologo subacqueo",
            "Costruttore di razzi spaziali",
            "Sommozzatore di profondità estreme",
            "Capitano di un'astronave",
            "Creatore di realtà virtuali",
            "Custode di un vulcano attivo","Astronauta", "Avventuriero", "Esploratore", "Guerriero", "Mangiafuoco",
            "Domatore", "Trapezista", "Illusionista", "Prestigiatore", "Pioniere",
            "Lama", "Guru", "Sciamano", "Papa", "Cardinale",
            "Missionario", "Frate", "Arcivescovo", "Vescovo", "Filosofo",
            "Imam", "Rabbino", "Predicatore", "Scenografo", "Coreografo",
            "Acrobata", "Clown", "Ballerino", "Produttore", "Regista",
            "Poeta", "Scrittore", "Artista", "Cantante", "Compositore",
           "Attore", "Musicista", "Psichiatra", "Psicologo", "Ornitologo",
           "Paleontologo", "Erpetologo", "Antropologo", "Zoologo", "Storico dell'arte",
           "Curatore", "Conservatore", "Restauratore", "Numismatico", "Epigrafista",
           "Archeologo", "Chimico", "Fisico", "Biologo", "Astronomo",
            "Matematico", "Scienziato", "Storico", "Critico", "Editore",
           "Editore musicale", "Accordatore", "Liutaio", "Tecnico del suono", "Foniatra",
           "Broker", "Detective", "Investigatore", "Assicuratore", "Agente immobiliare",
          "Veterano", "Psicanalista", "Dietologo", "Coach", "Personal Trainer",
          "Psicopedagogista", "Consigliere spirituale", "Mentore", "Tutor", "Formatore",
           "Educatore", "Maestra d'asilo", "Assistente", "Consulente", "Dietologo",
          "Radiologo", "Oculista", "Neurologo", "Dermatologo", "Cardiologo",
          "Pediatra", "Ginecologo", "Chirurgo", "Ortopedico", "Dentista",
           "Medico Veterinario", "Erborista", "Fisioterapista", "Osteopata", "Farmacista",
         "Programmatore", "Sviluppatore", "Analista", "Webmaster", "Designer",
         "Fotografo", "Videomaker", "Montatore", "Grafico", "Traduttore",
          "Interprete", "Giornalista", "Reporter", "Macchinista", "Tecnico",
          "Meccanico", "Riparatore", "Calzolaio", "Orologiaio", "Sarto",
           "Stilista", "Modellista", "Estetista", "Parrucchiere", "Barbiere",
          "Manicure", "Tatuatore", "Piercer", "Guida", "Alpinista",
          "Speleologo", "Capocantiere", "Caposquadra", "Direttore di produzione", "Gestore",
           "Impiegato", "Segretario", "Bibliotecario", "Direttore", "Amministratore",
          "Sindaco", "Assessore", "Consigliere", "Senatore", "Deputato",
         "Presidente", "Ministro", "Governatore", "Console", "Ambasciatore",
          "Giudice", "Magistrato", "Questore", "Ispettore", "Agente",
           "Vigile", "Pompiere", "Guardiano", "Custode", "Sacerdote",
         "Don", "Parroco", "Notaio", "Monaco", "Dottore",
            "Avvocato", "Ingegnere", "Maestro", "Professore", "Preside",
            "Capitano", "Tenente", "Colonnello", "Sergente", "Comandante",
           "Medico", "Infermiere", "Architetto", "Geometra", "Pasticcere",
         "Macellaio", "Pescatore", "Venditore", "Mercante", "Imprenditore",
           "Commercialista", "Banchiere", "Operaio", "Carpentiere", "Fabbro",
           "Idraulico", "Mastro", "Giardiniere", "Allevatore", "Contadino",
         "Pastore", "Cuoco", "Autista", "Conducente", "Narratore",
         "Oratore", "Volontario", "Difensore dei diritti", "Moderatore", "Commentatore",
          "Creatore di contenuti",    "Postino",
          "Tecnico delle caldaie",
         "Fioraio",
         "Addetto alle pulizie",
         "Fruttivendolo",
          "Parroco",
          "Tassista",
         "Corriere",
          "Idraulico",
          "Maestro di scuola"
        };
        public static List<string> GetRuoli()
        {
            List<string> getruoli = new List<string>();
            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                int g = r.Next(ruoli.Count);
                if (!getruoli.Contains(ruoli[g])){
                    getruoli.Add(ruoli[g]);
                }
            }
            return getruoli;
        }
        public static string GetSingleRole(Utente utente)
        {
            Random r = new Random();
            int g = r.Next(ruoli.Count);
            if (!utente.Ruoli.Contains(ruoli[g])){
                return ruoli[g];
            }
            else return GetSingleRole(utente);
        }
    }
}
