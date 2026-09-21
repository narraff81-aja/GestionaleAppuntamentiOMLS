<?php
require __DIR__ . '/../vendor/autoload.php';

use PhpOffice\PhpSpreadsheet\Spreadsheet;
use PhpOffice\PhpSpreadsheet\Writer\Xlsx;
//lettura file excel ed estrazione informazioni da visualizzare, 
// modificabili e dopo conferma da inviare al db (include funzione per decifrare il codice catastale)
header('Content-Type: application/json');

function righeDaCSV($pathfile)
{
    try {
        $file = fopen($pathfile, 'r');
        if ($file === false)
            throw new Exception("il file $pathfile non può essere aperto!");
        $rows = [];
        while (($data = fgetcsv($file, 1000, ';')) !== false) {
            $rows[] = $data;
        }
        fclose($file);
        return $rows;
    } catch (Exception $e) {
        throw $e;
    }
}
function righeDaXLSX($pathfile)
{
    $cartellaExcel = \PhpOffice\PhpSpreadsheet\IOFactory::load($pathfile);
    $foglio = $cartellaExcel->getAllSheets()[0]; // ->getActiveSheet();
    $rows = $foglio->toArray();
    return $rows;
}


$data = [];
$maxSize = 5 * 1024 * 1024; // 5 Megabyte in byte
$mimeAmmessi = [
    'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', // xlsx
    'application/vnd.ms-excel', // xls e csv
    'text/csv', // csv standard
    'text/plain' // csv semplice
];

try {
    //var_dump($_FILES); 
    if (is_array($_FILES['file_excel']['name'])) {
        throw new Exception('Ci sono più file da leggere!');
    }
    $countFiles = count($_FILES['file_excel']['name']);
    $name = $_FILES['file_excel']['name'];
    $type = $_FILES['file_excel']['type'];
    $tmpName = $_FILES['file_excel']['tmp_name'];
    $error = $_FILES['file_excel']['error'];
    $size = $_FILES['file_excel']['size'];
    $finfo = new finfo(FILEINFO_MIME_TYPE);
    $realMimeType = $finfo->file($tmpName);

    $data = [];
    $datiValidi = [];

    if ($size > $maxSize) {
        throw new Exception('Il file è troppo pesante. Massimo 5MB.');
    }
    if (!in_array($realMimeType, $mimeAmmessi)) {
        throw new Exception('MIME type non ammesso!');
    }
    $rows = null;
    if (in_array($realMimeType, [$mimeAmmessi[2], $mimeAmmessi[3]])) {
        // csv 
        $rows = righeDaCSV($tmpName);
    } else {
        // xslx o xsl
        $rows = righeDaXLSX($tmpName);
    }
    $testata = array_shift($rows); //'INTERVENTI GOL'
    if ($testata[0] != 'INTERVENTI GOL') {
        throw new Exception('Non è un file della Regione!');
    }
    $testata = array_shift($rows); //'Estrazione Interventi-gol'                      
    if (!str_starts_with($testata[0], 'Estrazione Interventi-gol')) {
        throw new Exception('Non è un file della Regione!');
    } else {
        $timestampEstrazione = str_ireplace('Estrazione Interventi-gol.xls del ', '', $testata[0]);
        $data['timestampEstrazione'] = $timestampEstrazione;
    }
    $testata = array_shift($rows); //intestazioni
    $idxCodiceEnte = array_search('Codice Ente Promotore', $testata);
    $idxNomeEnte   = array_search('Ente Promotore', $testata);
    $testataPulita = $testata;
    if ($idxCodiceEnte !== false) unset($testataPulita[$idxCodiceEnte]);
    if ($idxNomeEnte !== false)   unset($testataPulita[$idxNomeEnte]);
    $datiValidi[] = array_values($testataPulita); // perde le colonne inutili        

    foreach ($rows as $row) {
        $riga = [];
        if ($row[$idxCodiceEnte] === 'H501U355314') {
            for ($i = 0; $i < count($row); $i++) {
                if ($i === $idxCodiceEnte || $i === $idxNomeEnte) {
                    continue; // salta le colonne inutili
                }
                $riga[] = $row[$i];
            }
            $datiValidi[] = $riga;
        }
    }

    $data['cells'] = $datiValidi;

    echo json_encode($data);
    //var_dump($data);
} catch (Exception $e) {
    echo json_encode(["successo" => false, "messaggio" => "Errore: " . $e]);
}
