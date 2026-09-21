<?php
session_start();
if ($_SERVER['HTTP_HOST'] == 'localhost' || $_SERVER['REMOTE_ADDR'] == '127.0.0.1') {
    // --- CONFIGURAZIONE LOCALE ---
    define('DB_HOST', 'localhost');
    define('DB_NAME', 'gestionale_meschini');
    define('DB_USER', 'root');
    define('DB_PASS', '');
} else {
    // --- CONFIGURAZIONE REMOTE (INFINITY FREE) ---
    define('DB_HOST', 'sql100.infinityfree.com');
    define('DB_NAME', 'if0_41475221_meschini');
    define('DB_USER', 'if0_41475221');
    define('DB_PASS', 'UqcI26Omsbv1r3O');
}

function getConnection()
{
    static $conn = null;
    if ($conn === null) {
        $charset = 'utf8mb4';
        $port = 3306;
        $dsn = "mysql:host=" . DB_HOST . ";dbname=" . DB_NAME . ";charset=$charset";
        try {
            $conn = new PDO($dsn, DB_USER, DB_PASS);
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $conn->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
            $conn->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
        } catch (\PDOException $e) {
            throw new \PDOException($e->getMessage(), (int)$e->getCode());
        }
    }
    return $conn;
}

function scriviLog($id_omls, $nome_tabella, $nome_campo, $valore_vecchio, $valore_nuovo, $azione)
{
    try {
        $conn = getConnection();
        $sql = "INSERT INTO `log` (`id_omls`, `nome_tabella`, `nome_campo`, `valore_vecchio`, `valore_nuovo`, `azione`) VALUES
        (:id_omls, :nome_tabella, :nome_campo, :valore_vecchio, :valore_nuovo, :azione)";
        $stmt = $conn->prepare($sql);
        $stmt->bindParam(':id_omls', $id_omls);
        $stmt->bindParam(':nome_tabella', $nome_tabella);
        $stmt->bindParam(':nome_campo', $nome_campo);
        $stmt->bindParam(':valore_vecchio', $valore_vecchio);
        $stmt->bindParam(':valore_nuovo', $valore_nuovo);
        $stmt->bindParam(':azione', $azione);
        $stmt->execute();
    } catch (Exception $e) {
        throw new Exception($e->getMessage(), (int)$e->getCode());
    }
}

function omlsDaRuolo($conn, $idOMLSRichiesto)
{
    // RUOLI: 1 = OMLS semplice, 2 = Admin, 3 = Super Admin
    if ($_SESSION['ruolo'] == 1) {
        // OMLS semplice: può vedere SOLO se stesso
        return $_SESSION['id_omls'];
    } else if ($_SESSION['ruolo'] == 2) {
        // Admin: possono vedere chi vogliono purché non sia Admin
        $sql = "SELECT `ruolo` FROM `utenti` WHERE `id_omls`=:id_omls";
        $stmt = $conn->prepare($sql);
        $stmt->bindParam(':id_omls', $idOMLSRichiesto);
        $stmt->execute();
        $utenteRichiesto = $stmt->fetch(PDO::FETCH_ASSOC);
        if ($utenteRichiesto['ruolo'] > 1 && $idOMLSRichiesto !== $_SESSION['id_omls']) {
            return $_SESSION['id_omls'];
        } else {
            return $idOMLSRichiesto;
        }
    } else if ($_SESSION['ruolo'] == 3) {
        //Super Admin: possono vedere chi vogliono
        return $idOMLSRichiesto;
    } else {
        return null;
    }
}
