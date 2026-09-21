<?php
include_once('db_config.php');
header('Content-Type: application/json');
//form per creare profilo omls con nome, cognome, email, username, password
function createUser($conn, $id_omls, $username, $psw, $ruolo, $stato, $colore_css) {
    $sql = "INSERT INTO `users` (`id_omls`, `username`, `password`, `ruolo`, `stato`, `colore_css`) 
            VALUES (:id_omls, :username, :psw, :ruolo, :stato, :colore_css)";
    $stmt = $conn->prepare($sql);    
    $stmt->bindParam(':id_omls', $id_omls); 
    $stmt->bindParam(':username', $username); 
    $stmt->bindParam(':psw', $psw);
    $stmt->bindParam(':ruolo', $ruolo);
    $stmt->bindParam(':stato', $stato); 
    $stmt->bindParam(':colore_css', $colore_css);
    return $stmt->execute();
}
$data = [];
if($_SERVER['REQUEST_METHOD'] === 'POST'){
    $id_omls = $_POST['id_omls'];
    $username = $_POST['username'];
    $psw = $_POST['psw'];
    $ruolo = $_POST['ruolo'];
    $stato = $_POST['stato'];
    $colore_css = $_POST['colore_css'];
    if(createUser($conn, $id_omls, $username, $psw, $ruolo, $stato, $colore_css)){
        $data['success'] = true;
        $data['message'] = "User creato con successo";
    }else{
        $data['success'] = false;
        $data['message'] = "Errore nella creazione dell'User";
    }
}
echo json_encode($data);
?>