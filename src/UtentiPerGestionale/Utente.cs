using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtentiPerGestionale {
    public class Utente {
        public int ID { get; set; } 
        public DateOnly Foglio { get; set; }
        public int Riga { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public DateOnly DataApp { get; set; }
        public TimeOnly OrarioInizio { get; set; }
        public int ID_Utente { get; set; }
        public string Note { get; set; }
        public Utente(int id, string[] pezzi) {
            this.ID = id;
            this.Foglio = DateOnly.Parse(pezzi[0]);
            this.Riga = int.Parse(pezzi[1]);
            this.Nome = pezzi[2];
            this.Cognome = pezzi[3];
            this.CodiceFiscale = pezzi[4];
            //if (!string.IsNullOrWhiteSpace(pezzi[5]))
            this.DataApp=DateOnly.Parse(pezzi[5]);
            if (!string.IsNullOrWhiteSpace(pezzi[6]))
                this.OrarioInizio = TimeOnly.Parse(pezzi[6]);
            else
                this.OrarioInizio = new TimeOnly();
        }

        public override string ToString() {
            return $"{ID} - {Foglio} - {Riga} - {Nome} - {Cognome} - {CodiceFiscale} - {DataApp} - {OrarioInizio}";
        }
        public string ToCSV1() {
            if (!String.IsNullOrWhiteSpace(Note) && Note.StartsWith("; "))
                Note = Note.Substring(2).Replace(";", " -");
            return $"{ID};{Foglio.ToString("MMM-yy")};{Riga};{Nome};{Cognome};{CodiceFiscale};{DataApp.ToString()};{OrarioInizio.ToString()};{Note}";
        }
        public string ToCSV() {
            if (!String.IsNullOrWhiteSpace(Note) && Note.StartsWith("; "))
                Note = Note.Substring(2).Replace(";"," -");
            return $"{ID};{Foglio.ToString("MMM-yy")};{Riga};{Nome};{Cognome};{CodiceFiscale};{ID_Utente};{Note}";
        }

    }
    public class UtenteDict {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }//Key
        public int ID_Utente { get; set; }
        public List<int> IDS { get; set; } = new();
        public UtenteDict(int id_Utente, string nome, string cognome, string codiceFiscale, int id) {
            this.ID_Utente = id_Utente;
            this.Nome = nome;
            this.Cognome = cognome;
            this.CodiceFiscale= codiceFiscale;
            this.IDS.Add(id);
        }
        public UtenteDict(Utente u):this(u.ID_Utente,u.Nome,u.Cognome,u.CodiceFiscale,u.ID) {

        }
    }
}
