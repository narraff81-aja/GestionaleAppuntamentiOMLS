<?php
include_once('db_config.php');
header('Content-Type: application/json');
//recupera tutte le informazioni dell'utente e le visualizza
$data = [];
try {
    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $dataInput = json_decode(file_get_contents('php://input'), true);
        $id_utente = $dataInput['id_utente'];
        $conn = getConnection();
        $sql = "SELECT * FROM `utenti` WHERE `id_utente` = :id_utente";
        $stmt = $conn->prepare($sql);
        $stmt->bindParam(':id_utente', $id_utente);
        $stmt->execute();
        $utente = $stmt->fetch(PDO::FETCH_ASSOC);
        $data['successo'] = true;
        $data['messaggio'] = 'Informazioni utente recuperate con successo!';
        $data['utente'] = $utente;
    }
} catch (Exception $e) {
    // Cattura sia eccezioni PDO che eccezioni generiche
    $data['successo'] = false;
    $data['messaggio'] = 'Errore del server: ' . $e->getMessage();
}
echo json_encode($data);
