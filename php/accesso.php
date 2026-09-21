<?php
include_once('db_config.php');
header('Content-Type: application/json');
//recupera credenziali di accesso e controlla il tipo di ruolo per determinare l'interfaccia dello user
$data = [];
try {
    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $dataInput = json_decode(file_get_contents('php://input'), true);
        $username = $dataInput['username'];
        $password = $dataInput['password'];

        $conn = getConnection();

        $sql = "SELECT * FROM `utenti` WHERE username = :username";
        $stmt = $conn->prepare($sql);
        $stmt->bindParam(':username', $username);
        $stmt->execute();
        $user = $stmt->fetch(PDO::FETCH_ASSOC);
        if ($user && $user['stato'] == 'Non attivo') {
            $data['successo'] = false;
            $data['messaggio'] = 'Account non attivo!';
            $_SESSION = array();
            session_destroy();
        } else if ($user && password_verify($password, $user['password'])) {
            $data['successo'] = true;
            $data['messaggio'] = 'Accesso consentito!';
            $data['ruolo'] = $user['ruolo'];
            $data['id_omls'] = $user['id_omls'];
            $_SESSION['id_omls'] = $user['id_omls'];
            $_SESSION['ruolo'] = $user['ruolo'];
            $_SESSION['username'] = $user['username'];
            //$data['colore_css'] = $user['colore_css'];
        } else {
            $data['successo'] = false;
            $data['messaggio'] = 'Accesso negato!';
            $_SESSION = array();
            session_destroy();
        }
    }
} catch (Exception $e) {
    // Cattura sia eccezioni PDO che eccezioni generiche
    $data['successo'] = false;
    $data['messaggio'] = 'Errore del server: ' . $e->getMessage();
    $_SESSION = array();
    session_destroy();
}
echo json_encode($data);
