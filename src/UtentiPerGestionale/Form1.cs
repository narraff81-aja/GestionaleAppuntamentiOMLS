using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using System.Diagnostics;
namespace UtentiPerGestionale {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
           /* string cf = "BSOSMC77A70E020E";
            string nome = "SARA MICAELA";
            string cognome = "BOSIO";
            Debug.WriteLine(VerificaCF.VerificaNomeCognome(cf,nome, cognome));
            Debug.WriteLine(VerificaCF.VerificaCognome(cf, cognome));
            Debug.WriteLine(VerificaCF.VerificaNome(cf, nome));
            nome = "SARA";
            Debug.WriteLine(VerificaCF.VerificaNome(cf, nome));
            string cf = "VNCNLC04M59H501M";
            string cognome = "VENCATACHELLUM";
            Debug.WriteLine(VerificaCF.VerificaCognome(cf, cognome));*/
        }

        private void btnCaricaUtenti0_Click(object sender, EventArgs e) {
            /*string[] righe = File.ReadAllLines("link_utenti.csv", Encoding.UTF8);
            List<string> ris = new();
            for (int i = 0; i < righe.Length; i++) {
                string[] pezzi = righe[i].Split(';');
                // controllo formato errato delle righe
                if (pezzi.Length != 5) {
                    MessageBox.Show((i + 1) + "\t" + righe[i] + "\t" + pezzi.Length);
                    return;
                }
                if (i == 0) {
                    ris.Add("ID;VerNome;VerCognome;VerNomeR;VerCognomeR");
                    continue;
                }
                StringBuilder sb = new StringBuilder("" + i);
                string Nome = pezzi[2];
                string Cognome = pezzi[3];
                string CodiceFiscale = pezzi[4];
                if (string.IsNullOrWhiteSpace(CodiceFiscale)) {
                    sb.Append(";-;-;-;-");
                } else {
                    sb.Append(";").Append(VerificaCF.VerificaNome(CodiceFiscale, Nome));
                    sb.Append(";").Append(VerificaCF.VerificaCognome(CodiceFiscale, Cognome));
                    sb.Append(";").Append(VerificaCF.VerificaNome(CodiceFiscale, Cognome));
                    sb.Append(";").Append(VerificaCF.VerificaCognome(CodiceFiscale, Nome));
                }
                ris.Add(sb.ToString());
            }
            File.WriteAllLines("link_utenti.ris.csv", ris, Encoding.UTF8);
            MessageBox.Show("link_utenti.ris.csv creato!");*/

            /*string[] righe = File.ReadAllLines("utenti.csv", Encoding.UTF8);
            List<string> ris = new();
            for (int i = 0; i < righe.Length; i++) {
                string[] pezzi = righe[i].Split(';');
                // controllo formato errato delle righe
                if (pezzi.Length != 7) {
                    MessageBox.Show((i + 1) + "\t" + righe[i] + "\t" + pezzi.Length);
                    return;
                }
                if (i == 0) {
                    ris.Add("ID;VerNome;VerCognome;VerNomeR;VerCognomeR");
                    continue;
                }
                StringBuilder sb = new StringBuilder("" + i);
                string Nome = pezzi[2];
                string Cognome = pezzi[3];
                string CodiceFiscale = pezzi[4];
                if (string.IsNullOrWhiteSpace(CodiceFiscale)) {
                    sb.Append(";-;-;-;-");
                } else {
                    sb.Append(";").Append(VerificaCF.VerificaNome(CodiceFiscale,Nome));
                    sb.Append(";").Append(VerificaCF.VerificaCognome(CodiceFiscale, Cognome));
                    sb.Append(";").Append(VerificaCF.VerificaNome(CodiceFiscale,Cognome));
                    sb.Append(";").Append(VerificaCF.VerificaCognome(CodiceFiscale, Nome));
                }
                ris.Add(sb.ToString());
            }
            File.WriteAllLines("utenti.ris.csv", ris, Encoding.UTF8);
            MessageBox.Show("utenti.ris.csv creato!");
            */

            /*string[] righe = File.ReadAllLines("omls_utenti.csv", Encoding.UTF8);
            List<string> ris = new();
            for (int i = 0; i < righe.Length; i++) {
                string[] pezzi = righe[i].Split(';');
                // controllo formato errato delle righe
                if (pezzi.Length != 5) {
                    MessageBox.Show((i + 1) + "\t" + righe[i] + "\t" + pezzi.Length);
                    return;
                }
                if (i == 0) {
                    ris.Add("ID;VerNome;VerCognome;VerNomeR;VerCognomeR");
                    continue;
                }
                StringBuilder sb = new StringBuilder("" + i);
                string Nome = pezzi[2];
                string Cognome = pezzi[3];
                string CodiceFiscale = pezzi[4];
                if (string.IsNullOrWhiteSpace(CodiceFiscale)) {
                    sb.Append(";-;-;-;-");
                } else {
                    sb.Append(";").Append(VerificaCF.VerificaNome(CodiceFiscale, Nome));
                    sb.Append(";").Append(VerificaCF.VerificaCognome(CodiceFiscale, Cognome));
                    sb.Append(";").Append(VerificaCF.VerificaNome(CodiceFiscale, Cognome));
                    sb.Append(";").Append(VerificaCF.VerificaCognome(CodiceFiscale, Nome));
                }
                ris.Add(sb.ToString());
            }
            File.WriteAllLines("omls_utenti.ris.csv", ris, Encoding.UTF8);
            MessageBox.Show("omls_utenti.ris.csv creato!");*/

            string[] righe = File.ReadAllLines("utenti2.csv", Encoding.UTF8);
            List<string> ris = new();
            Dictionary<string, int> dict = new();
            int cont = 0;
            for (int i = 0; i < righe.Length; i++) {
                string[] pezzi = righe[i].Split(';');
                // controllo formato errato delle righe
                if (pezzi.Length != 6) {
                    MessageBox.Show((i + 1) + "\t" + righe[i] + "\t" + pezzi.Length);
                    return;
                }
                if (i == 0) {
                    ris.Add("ID;id_utente");
                    continue;
                }

                string CodiceFiscale = pezzi[4];
                if (CodiceFiscale!="**") {
                    // cf =key
                    if (!dict.ContainsKey(CodiceFiscale)) {
                        cont++;
                        dict.Add(CodiceFiscale, cont);
                    }
                    ris.Add($"{pezzi[5]};{dict[CodiceFiscale]}");
                } else {
                    // cognome|nome = key
                    string Nome = pezzi[2];
                    string Cognome = pezzi[3];
                    string key = $"{Cognome}|{Nome}";
                    if (!dict.ContainsKey(key)) {
                        cont++;
                        dict.Add(key, cont);
                    }
                    ris.Add($"{pezzi[5]};{dict[key]}");
                }                
            }
            File.WriteAllLines("utenti2.ris.csv", ris, Encoding.UTF8);
            MessageBox.Show("utenti2.ris.csv creato!");/**/
        }

        private void tentativo3() {
            /*
            // 1° analisi CF
            int count = 0;
            while (count < utenti.Count) {
                Utente u = utenti[count];

                if (string.IsNullOrWhiteSpace(u.CodiceFiscale) && !string.IsNullOrWhiteSpace(u.Note)) {
                    u.Note = "CF vuoto";
                } else {
                    var utentiF = utenti.Where(x => x.CodiceFiscale == u.CodiceFiscale).ToArray();
                    if (utentiF.Length == 1) {
                        try {
                            // è unico e quindi è == u
                            bool ok = false;
                            if (!string.IsNullOrWhiteSpace(u.Nome) && !string.IsNullOrWhiteSpace(u.Cognome)) {
                                if (VerificaCF.VerificaNomeCognome(u.CodiceFiscale, u.Nome, u.Cognome)) {
                                    // ok nome-cognome-cf
                                    u.Note = "ok";
                                    ok = true;
                                } else if (VerificaCF.VerificaNomeCognome(u.CodiceFiscale, u.Cognome, u.Nome)) {
                                    // ok nome-""-cf
                                    (u.Nome, u.Cognome) = (u.Cognome, u.Nome);
                                    u.Note = "Scambio Nome - Cognome";
                                    ok = true;
                                }
                            } else if (string.IsNullOrWhiteSpace(u.Nome) && !string.IsNullOrWhiteSpace(u.Cognome)) {
                                if (VerificaCF.VerificaCognome(u.CodiceFiscale, u.Cognome)) {
                                    // ok ""-cognome-cf
                                    u.Note = "manca Nome";
                                    ok = true;
                                } else if (VerificaCF.VerificaNome(u.CodiceFiscale, u.Cognome)) {
                                    // ok nome-""-cf
                                    u.Nome = u.Cognome;
                                    u.Cognome = "";
                                    u.Note = "Nome al posto del Cognome null";
                                    ok = true;
                                }
                            } else if (!string.IsNullOrWhiteSpace(u.Nome) && string.IsNullOrWhiteSpace(u.Cognome)) {
                                if (VerificaCF.VerificaNome(u.CodiceFiscale, u.Nome)) {
                                    // ok nome-""-cf
                                    u.Note = "manca Cognome";
                                    ok = true;
                                } else if (VerificaCF.VerificaCognome(u.CodiceFiscale, u.Nome)) {
                                    // ok ""-cognome-cf
                                    u.Cognome = u.Nome;
                                    u.Nome = "";
                                    u.Note = "Cognome al posto del Nome null";
                                    ok = true;
                                }
                            }
                            if (!ok) {
                                // cf errato!
                                u.Note = "CF errato";
                                u.CodiceFiscale = "";
                            }
                        } catch (Exception ex) {
                            Debug.WriteLine($"{u.Foglio} {u.Riga} - {ex.Message}");
                        }
                    } else {
                        try {
                            // esiste un conflitto?
                            if (utentiF.All(x => x.Cognome.ToLower() == u.Cognome.ToLower()) &&
                                utentiF.All(x => x.Nome.ToLower() == u.Nome.ToLower())) {
                                // no conflitti
                                foreach (Utente item in utentiF) {
                                    Utente ut = utenti[item.ID - 1];
                                    ut.Note = "ok";
                                }
                            } else {
                                // devi aprire Form2
                                Form2 form2 = new Form2($"cont: {count} - CF: {u.CodiceFiscale}", utentiF);
                                if (form2.ShowDialog() == DialogResult.OK) {
                                    var selez = form2.Selezionati;
                                    for (var i = 0; i < selez.Count; i++) {
                                        //Debug.WriteLine(item);
                                        Utente ut = utenti[utentiF[i].ID - 1];
                                        if (selez[i].DaScambioNC) {
                                            // cambio nome-cognome

                                            (ut.Nome, ut.Cognome) = (utentiF[i].Cognome, utentiF[i].Nome);
                                            ut.Note = "scambio nome-cognome";
                                            if (!string.IsNullOrWhiteSpace(selez[i].Note)) {
                                                ut.Note += " - " + selez[i].Note;
                                            }
                                        } else if (selez[i].DaScartare) {
                                            // scartare 
                                            ut.CodiceFiscale = "";
                                            ut.Note = "CF errato";
                                            if (!string.IsNullOrWhiteSpace(selez[i].Note)) {
                                                ut.Note += " - " + selez[i].Note;
                                            }
                                        } else {
                                            ut.Note = "ok";
                                            if (!string.IsNullOrWhiteSpace(selez[i].Note)) {
                                                ut.Note += " - " + selez[i].Note;
                                            }
                                        }
                                    }
                                }
                            }
                        } catch (Exception ex) {
                            utentiF.ToList().ForEach(x => Debug.WriteLine($"{x.Foglio} {x.Riga} - {ex.Message}"));
                        }
                    }
                }
                count++;
            }
            // ora c'è il problema di verificare gli utenti senza CF


            string[] stringOutput = utenti.Select(u => u.ToCSV1()).ToArray();
            File.WriteAllLines("utenti1.csv", stringOutput, Encoding.UTF8);
            MessageBox.Show("utenti1.csv creato!");*/

        }
        private void btnCaricaUtenti1_Click(object sender, EventArgs e) {
            List<int> interi = new List<int>();
            interi.Add(10);
            interi.Add(2);
            interi.Add(7);
            interi.Add(4);
            interi.Add(5);
            interi.Add(6);
            Debug.WriteLine(interi.Any(i => i > 2));
            Debug.WriteLine(interi.All(i => i > 2));

            string[] righe = File.ReadAllLines("utenti3.csv", Encoding.UTF8);
            List<string> ris = new();
            foreach (string r in righe) {
                string[] pezzi = r.Split(';');
                CodiceFiscaleUtility.CodiceFiscale cf = new CodiceFiscaleUtility.CodiceFiscale(pezzi[1]);
                StringBuilder sb = new(pezzi[0]);
                sb.Append(';').Append(cf.Nascita.ToShortDateString());
                sb.Append(';').Append(cf.Sesso);
                sb.Append(';').Append(cf.Comune);
                sb.Append(';').Append(cf.Provincia);
                ris.Add(sb.ToString());               
            }
            File.WriteAllLines("utenti3.ris.csv", ris, Encoding.UTF8);
            MessageBox.Show("utenti3.ris.csv creato!");
            // 2° analisi CF

            /*
                if (string.IsNullOrWhiteSpace(u.CodiceFiscale)) {
                    u.Note = "CF vuoto";
                } else {
                    string seiChar = calcolaNome(u.Cognome, true) + calcolaNome(u.Nome, false);
                    string seiCharRev = calcolaNome(u.Nome, true) + calcolaNome(u.Cognome, false);
                    if (string.IsNullOrWhiteSpace(u.Nome) && !string.IsNullOrWhiteSpace(u.Cognome)) {
                        string treChar = calcolaNome(u.Cognome, true);
                        if (u.CodiceFiscale.StartsWith(treChar)) {
                            // OK ""-cognome-cf
                            u.Note += "manca nome";
                        } else {
                            // possibile che sia il nome al posto del cognome
                            if (u.CodiceFiscale.Substring(3, 3) == treChar) {

                            } else {

                            }
                        }
                    } else if (u.CodiceFiscale.StartsWith(seiChar)) {
                        // OK nome-cognome-cf
                        u.Note += "ok";
                    } else if (u.CodiceFiscale.StartsWith(seiCharRev)) {
                        // OK cognome-nome-cf -> nome-cognome-cf
                        u.Note += "scambio nome-cognome";
                        (u.Nome, u.Cognome) = (u.Cognome, u.Nome);
                    } else {
                        // eliminazione CF ->  nome-cognome-""
                        u.CodiceFiscale = "";
                        u.Note += "CF errato";
                    }
                }
            // 2° analisi CF
            var UtentiConCF = utenti.Where(u => !string.IsNullOrWhiteSpace(u.CodiceFiscale)).ToList();
            var UtentiSenzaCF = utenti.Where(u => string.IsNullOrWhiteSpace(u.CodiceFiscale));
            while (UtentiSenzaCF.Count() > 0) {
                Utente u = UtentiSenzaCF.First();


            }*/

            //File.WriteAllLines("utenti.risultati.csv", stringOutput, Encoding.UTF8);
            //MessageBox.Show("Ciao!\n" + righe.Length);
        }




        private void tentativo1() {
            // 
            /*int id_curr = 0;
            for (int c = 0; c < utenti.Count; c++) {
                if (utenti[c].ID_Utente > 0) {
                    // ha ID_Utente assegnato!
                    continue;
                }
                id_curr++;
                if (string.IsNullOrWhiteSpace(utenti[c].CodiceFiscale)) {
                    // assegna ID_Utente e no può fare confronti!
                    utenti[c].ID_Utente = id_curr;
                    if(!string.IsNullOrWhiteSpace(utenti[c].Note) && !utenti[c].Note.Contains("; CF vuoto"))
                        utenti[c].Note += "; CF vuoto";
                    continue;
                }
                var uFiltrati = utenti.Where(u => u.CodiceFiscale == utenti[c].CodiceFiscale);
                foreach (Utente u in uFiltrati) {
                    string seiChar = calcolaNome(u.Cognome, true) + calcolaNome(u.Nome, false);
                    if (u.CodiceFiscale.StartsWith(seiChar)) {
                        // OK nome-cognome-cf
                        u.ID_Utente = id_curr;
                        u.Note += "; ok";
                        if (utentiDict.ContainsKey(u.CodiceFiscale)) {
                            utentiDict[u.CodiceFiscale].IDS.Add(u.ID);
                        } else {
                            utentiDict.Add(u.CodiceFiscale, new UtenteDict(u));
                        }
                        continue;
                    }
                    seiChar = calcolaNome(u.Nome, true) + calcolaNome(u.Cognome, false);
                    if (u.CodiceFiscale.StartsWith(seiChar)) {
                        // OK cognome-nome-cf -> nome-cognome-cf
                        u.ID_Utente = id_curr;
                        u.Note += "; scambio nome-cognome";
                        (u.Nome, u.Cognome) = (u.Cognome, u.Nome);
                        if (utentiDict.ContainsKey(u.CodiceFiscale)) {
                            utentiDict[u.CodiceFiscale].IDS.Add(u.ID);
                        } else {
                            utentiDict.Add(u.CodiceFiscale, new UtenteDict(u));
                        }
                        continue;
                    }
                    // eliminazione CF ->  nome-cognome-""
                    u.CodiceFiscale = "";
                    u.ID_Utente = id_curr;
                    if (!string.IsNullOrWhiteSpace(utenti[c].Note) && !utenti[c].Note.Contains("; cf errato"))
                        u.Note += "; cf errato";
                }
            }*/
            // rimangono i senza CF ma con id assegnato
        }
        private void tentativo2() {
            /*
              for (int i = 0; i < righe.Length; i++) {
                string[] pezzi = righe[i].Split(';');
                // controllo formato errato delle righe
                if (pezzi.Length != 7) {
                    MessageBox.Show((i + 1) + "\t" + righe[i] + "\t" + pezzi.Length);
                    return;
                }
                if (i == 0)
                    continue;
                Utente u = new Utente(i, pezzi);
                // 1° analisi CF
                if (string.IsNullOrWhiteSpace(u.CodiceFiscale)) {
                    u.Note = "CF vuoto";
                } else {
                    string seiChar = calcolaNome(u.Cognome, true) + calcolaNome(u.Nome, false);
                    string seiCharRev = calcolaNome(u.Nome, true) + calcolaNome(u.Cognome, false);
                    if (string.IsNullOrWhiteSpace(u.Nome) && !string.IsNullOrWhiteSpace(u.Cognome)) {
                        string treChar = calcolaNome(u.Cognome, true);
                        if (u.CodiceFiscale.StartsWith(treChar)) {
                            // OK ""-cognome-cf
                            u.Note += "manca nome";
                        } else {
                            // possibile che sia il nome al posto del cognome
                            if (u.CodiceFiscale.Substring(3, 3) == treChar) {

                            } else {

                            }
                        }
                    } else if (u.CodiceFiscale.StartsWith(seiChar)) {
                        // OK nome-cognome-cf
                        u.Note += "ok";
                    } else if (u.CodiceFiscale.StartsWith(seiCharRev)) {
                        // OK cognome-nome-cf -> nome-cognome-cf
                        u.Note += "scambio nome-cognome";
                        (u.Nome, u.Cognome) = (u.Cognome, u.Nome);
                    } else {
                        // eliminazione CF ->  nome-cognome-""
                        u.CodiceFiscale = "";
                        u.Note += "CF errato";
                    }
                }
                utenti.Add(u);
            }
            // 2° analisi CF
            var UtentiConCF = utenti.Where(u => !string.IsNullOrWhiteSpace(u.CodiceFiscale)).ToList();
            var UtentiSenzaCF = utenti.Where(u => string.IsNullOrWhiteSpace(u.CodiceFiscale));
            while (UtentiSenzaCF.Count() > 0) {
                Utente u = UtentiSenzaCF.First();


            }
             */

        }


    }
}