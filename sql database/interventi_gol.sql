CREATE TABLE IF NOT EXISTS `interventi_gol` (
`id_intervento` INT NOT NULL AUTO_INCREMENT,
`id_cittadino` INT NOT NULL,
`intervento` VARCHAR(100) NOT NULL COMMENT '(perc.1,2,3) ORIENTAMENTO SPECIALISTICO GOL',
`id_patto` VARCHAR(100) NOT NULL,
`stato_intervento` VARCHAR(255) NOT NULL DEFAULT 'ISCRIZIONE ASSEGNATA',
`data_iscrizione` DATE NOT NULL,
`data_chiusura` DATE NULL,
`data_stato` DATE NULL,
`corso_scelto` VARCHAR(100) NULL,
`percorso` VARCHAR(100) NOT NULL COMMENT 'Reinserimento lavorativo (1); Upskilling (2); Reskilling (3); Lavoro e Inclusione (4); Ricollocazione Collettiva (5)',
`cpi` text NOT NULL,
`id_omls` INT NULL COMMENT 'omls da essegnare',
PRIMARY KEY (`id_intervento`)
) DEFAULT CHARSET=utf8 COMMENT 'Dati ottenuti dalla regione, file: "1_STRUTTURA FILE EXCEL_PLL.xlsx"';