CREATE TABLE IF NOT EXISTS `stato_intervento` (
`id_stato_intervento` INT NOT NULL AUTO_INCREMENT,
`stato` VARCHAR(50) NULL UNIQUE,
PRIMARY KEY (`id_stato_intervento`)
) DEFAULT CHARSET=utf8 COMMENT 'tabella di supporto';