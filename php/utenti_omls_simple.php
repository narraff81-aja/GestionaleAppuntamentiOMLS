<?php
require_once 'db_config.php';
header('Content-Type: application/json');
$dataInput = json_decode(file_get_contents('php://input'), true);

try {
    $idRichiesto = $dataInput['id_omls'];
    $idDaUsare = null;
    $conn = getConnection();
    // RUOLI: 1 = OMLS semplice, 2 = Admin, 3 = Super Admin
    $idDaUsare = omlsDaRuolo($conn, $idRichiesto);
    if ($idDaUsare == null) {
        session_destroy(); // Lo cacciamo di prepotenza
        echo json_encode(['successo' => false, 'messaggio' => 'Violazione permessi. Sessione terminata.']);
        exit;
    }

    $sql = "SELECT * FROM `cittadini` WHERE `id_omls`=:id_omls";
    $stmt = $conn->prepare($sql);
    $stmt->bindParam(':id_omls', $idDaUsare);
    $stmt->execute();
    /*$risultato = $stmt->fetchAll();
    $data['successo'] = true;
    $data['messaggio'] = 'Informazioni dei cittadini recuperate con successo!';
    $data['cittadini'] = $risultato;*/
    $data = $stmt->fetchAll(PDO::FETCH_ASSOC);
} catch (Exception $e) {
    $data['successo'] = false;
    $data['messaggio'] = 'Errore: ' . $e->getMessage();
}

echo json_encode($data);
