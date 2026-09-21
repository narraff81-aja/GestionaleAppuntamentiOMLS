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

    $sql = "INSERT INTO `gestioni_appuntamenti`(`id_omls`, `id_cittadino`, `attivita`, `link`, `data`, `orario_inizio`, `durata`, `tipologia_orientamento`) 
        VALUES (:id_omls, :id_cittadino, :attivita, :link, :data, :orario_inizio, :durata, :tipologia_orientamento)";
    $stmt = $conn->prepare($sql);
    $stmt->bindParam(':id_omls', $idDaUsare);
    $stmt->bindParam(':id_cittadino',  $dataInput['id_cittadino']);
    $stmt->bindParam(':attivita', trim($dataInput['attivita']));
    $stmt->bindParam(':link', trim($dataInput['link']));
    $stmt->bindParam(':data', $dataInput['data']);
    $stmt->bindParam(':orario_inizio', $dataInput['orario_inizio']);
    $stmt->bindParam(':durata', $dataInput['durata']);
    $stmt->bindParam(':tipologia_orientamento', trim($dataInput['tipologia_orientamento']));
    $stmt->execute();
    $data['successo'] = true;
    $data['messaggio'] = 'Appuntamento fissato con successo!';
} catch (Exception $e) {
    $data['successo'] = false;
    $data['messaggio'] = 'Errore: ' . $e->getMessage();
}

echo json_encode($data);
