CREATE TABLE IF NOT EXISTS `omls` (
`id_omls` INT NOT NULL AUTO_INCREMENT,
`nome` VARCHAR(255) NOT NULL,
`cognome` VARCHAR(255) NOT NULL,
`email` VARCHAR(255) NULL COMMENT 'alcuni non hanno indicato la mail',
`stato` text NULL,
`colore_css` VARCHAR(100) NULL COMMENT 'colore distintivo nel front-end es: yellow, #ff0000, rgb(0,255,0)',
`link` VARCHAR(255) NULL COMMENT 'se è individuale, link di meet oppure "IN PRESENZA"',
`compenso_orario` DECIMAL(5,2) NULL,
`contatore_ore_rendicontazione` INT NULL DEFAULT 0 COMMENT 'si azzera a ogni rendicontazione',
PRIMARY KEY (`id_omls`)
) DEFAULT CHARSET=utf8;
