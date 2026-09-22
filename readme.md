\# Gestionale Appuntamenti OMLS - DB Design \& Data Cleansing



\*\*Versione:\*\* 0.3.0 (Data Cleansing \& Schema MySQL)  

\*\*Author:\*\* Raffaele N.  

\*\*Status:\*\* Archiviato / PoC (Proof of Concept)



\## 📝 Descrizione del Progetto

Sviluppato come progetto di gruppo nell'ambito del corso di programmazione CQP, il sistema è nato per gestire l'agenda degli appuntamenti tra gli OMLS e i cittadini aderenti al percorso GOL.



Il mio contributo si è focalizzato su:

1\. \*\*Database Architecture:\*\* Progettazione dello schema ER e creazione dello script DDL in MySQL.

2\. \*\*Data Cleansing \& Normalizzazione:\*\* Bonifica di un dataset disomogeneo e privo di vincoli relazionali distribuito su fogli Excel.



> ⚠️ \*\*Nota sulla Privacy:\*\* Tutti i dati sensibili reali presenti nei fogli di calcolo originali sono stati interamente rimossi o anonimizzati prima della pubblicazione su GitHub.



\## 🏗️ Struttura del Repository

\- `fonte dati/`: Documentazione e strutture dati di input/output (Regionali e Interni).

\- `normalizzazione appuntamenti/`: Dataset sanificato con assegnazione automatica dei dati di integrità referenziale (`id\_utente`, `id\_omls`).

\- `src/UtentiPerGestionale/`: Utility in C# (.NET) sviluppata per il parsing dei CSV, il matching delle terne anagrafiche e la bonifica.

\- `php/`: Moduli iniziali di integrazione Back-End.

\- `sql database/`: Script SQL (DDL/DML) per la creazione dell'architettura RDBMS su MySQL/phpMyAdmin.

\- `diagrammi/`: Diagrammi ER del DB (dalla prima bozza di gruppo alla versione finale BCNF/3NF).



\## ⚙️ Scelte Architetturali e Trade-off

\- \*\*Denormalizzazione controllata:\*\* Alcune entità presentano una denormalizzazione intenzionale per agevolare le query di reportistica richieste dalle specifiche dell'ente.

\- \*\*Integrazione C# per Validation:\*\* Per la verifica incrociata dei dati e la risoluzione dei refusi sui Codici Fiscali è stata integrata una logica di matching in C#.



\## 📄 Licenza e Crediti

Il progetto è rilasciato sotto licenza \*\*MIT\*\*.



Per la logica di calcolo e validazione del Codice Fiscale in C# (classe `VerificaCF`), si ringrazia \*\*Matteo Pillon\*\* (\[mtpi/CodiceFiscale](https://github.com/mtpi/CodiceFiscale)), il cui codice è incluso sotto licenza BSD 2-Clause:

```text

Copyright (c) 2016, Matteo Pillon <matteo.pillon@gmail.com>

All rights reserved.

