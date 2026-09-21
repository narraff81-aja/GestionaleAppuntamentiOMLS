<?php

function createUtente($conn, $codice_fiscale, $nome, $cognome, $sesso,
$data_nascita,$comune_nascita,$nazionalita,$indirizzo_residenza, 
$cap_residenza,$citta_residenza,$provincia_residenza,$email,
$telefono1,$telefono2,$id_titoli_studio,$id_beneficio) {
    $sql = "INSERT INTO `utenti` (`codice_fiscale`, `nome`, `cognome`, `sesso`,
        `data_nascita`,`comune_nascita`,`nazionalita`,`indirizzo_residenza`, 
        `cap_residenza`,`citta_residenza`,`provincia_residenza`,`email`,
        `telefono1`,`telefono2`,`id_titoli_studio`,`id_beneficio`) 
        VALUES (:codice_fiscale, :nome, :cognome, :sesso,
         :data_nascita,:comune_nascita,:nazionalita,:indirizzo_residenza, 
         :cap_residenza,:citta_residenza,:provincia_residenza,:email,
         :telefono1,:telefono2,:id_titoli_studio,:id_beneficio)";
    $stmt = $conn->prepare($sql);    
    $stmt->bindParam(':codice_fiscale', $codice_fiscale); 
    $stmt->bindParam(':nome', $nome);
    $stmt->bindParam(':cognome', $cognome); 
    $stmt->bindParam(':sesso', $sesso);
    $stmt->bindParam(':data_nascita',$data_nascita);
    $stmt->bindParam(':comune_nascita',$comune_nascita);
    $stmt->bindParam(':nazionalita',$nazionalita);
    $stmt->bindParam(':indirizzo_residenza', $indirizzo_residenza);
    $stmt->bindParam(':cap_residenza',$cap_residenza);
    $stmt->bindParam(':citta_residenza',$citta_residenza);
    $stmt->bindParam(':provincia_residenza',$provincia_residenza);
    $stmt->bindParam(':email',$email);
    $stmt->bindParam(':telefono1',$telefono1);
    $stmt->bindParam(':telefono2',$telefono2);
    $stmt->bindParam(':id_titoli_studio',$id_titoli_studio);
    $stmt->bindParam(':id_beneficio',$id_beneficio);
    return $stmt->execute();
}






function drop_utenti($conn){
    $sql="DELETE FROM `utenti`";
    $stmt = $conn->prepare($sql); 
    $stmt->execute();
}

function caricaUtenti($conn) {
    $dati=[];
    $dati[]=['Luca','Ferrari','M','1995-12-13','FERLUC95T13H501Z','+39 3269927173'];
    $dati[]=['Marco','Bianchi','M','1970-10-07','BIAMAR70R07H501Z','+39 3243921971'];
    $dati[]=['Alessandro','Verdi','M','1987-09-11','VERALE87P11H501Z','+39 3802459663'];
    $dati[]=['Giuseppe','Gallo','M','1976-02-28','GALGIU76B28H501Z','+39 3582152353'];
    $dati[]=['Francesca','Gallo','F','1992-10-09','GALFRA92R49H501Z','+39 3949643737'];
    $dati[]=['Alessandro','Rossi','M','1995-05-04','ROSALE95E04H501Z','+39 3527515322'];
    $dati[]=['Alessandro','Verdi','M','2004-12-18','VERALE04T18H501Z','+39 3493563214'];
    $dati[]=['Elena','Fontana','F','1991-01-13','FONELE91A53H501Z','+39 3307937799'];
    $dati[]=['Marco','Esposito','M','1982-04-02','ESPMAR82D02H501Z','+39 3385392366'];
    $dati[]=['Elena','Ferrari','F','1987-10-30','FERELE87R70H501Z','+39 3404747173'];

    $sqlU = "INSERT INTO utenti (codice_fiscale, nome, cognome, sesso, data_nascita, email, telefono1, telefono2) 
            VALUES (:cf, :nome, :cognome, :sesso, :dn, :email, :tel1, :tel2)";
    $stmtU = $conn->prepare($sqlU);        

    foreach ($dati as $row) {
        $conn->beginTransaction();
        try {
            // 1. Inseriamo l'utente
            $stmtU->execute([
                ':cf' => $row[4],
                ':nome' => $row[0],
                ':cognome' => $row[1],
                ':sesso' => $row[2],
                ':dn' => $row[3],
                ':email'  => "$row[0]-$row[1]@gmail.com",
                ':tel1' => $row[5],
                ':tel2' => ''
            ]);                
            $conn->commit();
        } catch (Exception $e) {
            // Se una riga fallisce (es. CF duplicato), la saltiamo e scriviamo l'errore
            error_log("Errore rigaS: " . $e->getMessage());
            $conn->rollBack();
            continue; 
        }
    }
}


?>