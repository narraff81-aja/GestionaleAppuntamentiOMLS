CREATE TABLE IF NOT EXISTS `faq` (
`id_faq` INT NOT NULL AUTO_INCREMENT,
`argomento` VARCHAR(10) NULL COMMENT 'or, acc, corsi, varie',
`domanda` TEXT NOT NULL COMMENT 'supera i 255 caratteri',
`risposta` TEXT NULL COMMENT 'supera i 255 caratteri',
`data` DATE NULL,
`richiesta` VARCHAR(10) NULL COMMENT 'fonte richiesta: "wapp", "mail", "diretta"',
`note_chiarimento` TEXT NULL COMMENT 'note ulteriori a chiarimento',
`rif_normativi` TEXT NULL COMMENT 'url di riferimenti normativi',
`operatore` VARCHAR(255) NOT NULL,
PRIMARY KEY (`id_faq`)
) DEFAULT CHARSET=utf8 COMMENT 'foglio: "FAQ", file: "APPUNTAMENTI OR_ACC (1).xlsx"';
