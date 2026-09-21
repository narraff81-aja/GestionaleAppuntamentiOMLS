CREATE TABLE IF NOT EXISTS `titoli_studio` (
`id_titolo_studio` INT NOT NULL AUTO_INCREMENT,
`titolo_studio` VARCHAR(50) NULL UNIQUE,
PRIMARY KEY (`id_titolo_studio`)
) DEFAULT CHARSET=utf8 COMMENT 'tabella di supporto';
