CREATE TABLE IF NOT EXISTS `corsi` (
`id_corso` int(50) NOT NULL AUTO_INCREMENT,
`nome` VARCHAR(255) NOT NULL,
`percorso` VARCHAR(100) NULL,
`ore_corso` mediumint(9) NULL,
`titolo_studio` VARCHAR(255) NULL,
`codice_corso` VARCHAR(255) NULL,
`ore_tirocinio` mediumint(9) NULL,
`tipologia_qualifica` VARCHAR(255) NULL,
PRIMARY KEY (`id_corso`)
) DEFAULT CHARSET=utf8 COMMENT 'tabella di supporto';
