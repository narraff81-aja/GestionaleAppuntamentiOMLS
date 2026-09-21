CREATE TABLE IF NOT EXISTS `tipo_beneficio` (
`id_beneficio` INT NOT NULL AUTO_INCREMENT,
`beneficio` VARCHAR(100) NOT NULL COMMENT 'Adi, Naspi, Sfl, ...',
PRIMARY KEY (`id_beneficio`)
) DEFAULT CHARSET=utf8 COMMENT 'tabella di supporto';