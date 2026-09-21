# Gestionale Apppuntamenti per OMLS

**Versione:** 0.3.0 - sanificazione dati e aggiornamento bozza delle istruzioni sql del DB MySql

**Author:** Raffaele N.

## 📝 Descrizione
L'ente erogatore del corso di programmazione che ho frequentato ha proposto come progetto di gruppo, di creare un gestionale degli appuntamenti degli OMLS con i cittadini che seguivano il percorso GOL dall'ente stesso. 
A me é stato dato il compito di creare il DB basandomi sui loro fogli excel pieni di dati sensibili non-normalizzati.
Nonostante nei excel fonte-dati originali ci siano dati sensibili dove quasi mai non c'era la corrispondenza nome-cognome-codice fiscale, per poterli pubblicare qui su GitHub i dati sensibili sono stati CANCELLATI! 

## 🏗️ Struttura del Progetto
- `fonte dati/` cartella con i file excel dati dall'ente per creare il gestinale
- `fonte dati/regionali/` cartella con i file excel della Regione per l'Input/Output
- `normalizzazione appuntamenti/` cartella con i 6file excel con i dati sanificati e normalizzati il più possibile. 
Ad ogni appuntamento ho assegnato un id_utente (utente = cittadino) e un id_omls.
- `php/` cartella con i primi file php del back-end
- `sql database/` istruzioni sql per MySql (phpmyadmin) per la creazione delle entità con le loro relazioni
- `/DIAGRAMMA-ER-PROGETTO .drawio.png` Prima bozza del diagramma ER creato dal gruppo
- `/Gestionale_Diagramma ER_Raff.drawio.png` Bozza n° 3 del diagramma ER creato da me

## 📝 Note di Sviluppo
A causa delle incertezze dell'ente su quale server specifico eseguire l'host del gestionale completo (front-end + back-end + database), il progetto stesso è caduto in rovina!

## 🚧 Limitazioni Conosciute
Lo stop al progetto non ha permesso di concedere il tempo al front-end di collegarsi bene col back-end e quindi di trovare ulteriori falle nel DB.

Non sono stato completamente libero di applicare la normalizzazione dei dati, quindi c'è un po' di denormalizzazione voluta nelle entità.

Non sono previsti aggiornamenti, ma forse una riscrittura completa di tutto!
## 📄 License & Copyright

This project is licensed under the **MIT License**. You are free to use, modify, and distribute it, provided that the original copyright notice and permission notice are included. 

*The software is provided **"as is"**, without warranty of any kind.*