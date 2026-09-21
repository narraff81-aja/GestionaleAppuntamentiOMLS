CREATE TABLE IF NOT EXISTS `gestioni_attivita` (
`id_ga` INT NOT NULL AUTO_INCREMENT,
`id_omls` INT NOT NULL,
`id_cittadino` INT NOT NULL,
`data_potenziale_1_app` VARCHAR(100) NULL COMMENT 'data  potenziale 1°  appuntamento',
`cosa_fatto` VARCHAR(50) NULL COMMENT  'cosa è stato fatto: "non risponde alla mail", "non risponde al telefono", "irreperibile", "non presente all\'appuntamento", "appuntamento non completato", "appuntamento effettuato"',
`stato finale` VARCHAR(30) NULL COMMENT '"interrotto", "chiuso in pll", "da interrompere"', 
`note` VARCHAR(255) NULL,
`annotazioni` VARCHAR(255) NULL COMMENT 'annotazioni per sostituire la formattazione celle e, a quanto pare, `note` non basta!',
PRIMARY KEY (`id_gsa`)
) DEFAULT CHARSET=utf8 COMMENT 'fogli: OMLS, file: "APPUNTAMENTI OR_ACC (1).xlsx"';
