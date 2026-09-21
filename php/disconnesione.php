<?php
include_once('db_config.php');
header('Content-Type: application/json');
$username = $_SESSION['username'];
$_SESSION = array();
session_destroy();
// Opzionale: elimina anche il cookie nel browser
//setcookie(session_name(), '', time() - 3600, '/');
header("Location: login.php");
echo json_encode(["successo" => true, "messaggio" => "Utente " . $username . " disconnesso"]);
