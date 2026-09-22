using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtentiPerGestionale;
public class VerificaCF {
    private const string VOCALI = "AEIOU";
    private const string CONSONANTI = "BCDFGHJKLMNPQRSTVWXYZ";
    /// <summary>
    /// Funzione copiata da CodiceFiscaleUtility.CodiceFiscale di 
    /// Copyright (c) 2016, Matteo Pillon <matteo.pillon@gmail.com>
    /// </summary>
    /// <param name="Nome"></param>
    /// <param name="isCognome"></param>
    /// <returns></returns>
    private static string CalcolaNome(string Nome, bool isCognome = false) {
        bool consonanteRimossa = false;
        StringBuilder tmpCodice = new StringBuilder(4);
        foreach (char c in Nome.ToUpper()) {
            if (CONSONANTI.IndexOf(c) >= 0) {
                tmpCodice.Append(c);
                if (!consonanteRimossa && !isCognome && tmpCodice.Length == 4) {
                    tmpCodice.Remove(1, 1);
                    consonanteRimossa = true;
                }
            }
        }
        if (tmpCodice.Length > 3)
            tmpCodice.Remove(3, tmpCodice.Length - 3);
        if (tmpCodice.Length < 3) {
            foreach (char c in Nome.ToUpper()) {
                if (VOCALI.IndexOf(c) >= 0)
                    tmpCodice.Append(c);
                if (tmpCodice.Length == 3)
                    break;
            }
        }
        if (tmpCodice.Length < 3) {
            int missingChars = 3 - tmpCodice.Length;
            tmpCodice.Append(new string('X', missingChars));
        }
        return tmpCodice.ToString();
    }
    public static bool VerificaNomeCognome(string codiceFiscale, string nome, string cognome) {
        string nome3Char = CalcolaNome(nome, false);
        string cognome3Char = CalcolaNome(cognome, true);
        return codiceFiscale.StartsWith(cognome3Char + nome3Char);
    }
    public static bool VerificaCognome(string codiceFiscale, string cognome) {
        string cognome3Char = CalcolaNome(cognome, true);
        return codiceFiscale.StartsWith(cognome3Char);
    }
    public static bool VerificaNome(string codiceFiscale, string nome) {
        string nome3Char = CalcolaNome(nome, false);
        return codiceFiscale.Substring(3,3)== nome3Char;
    }
}
