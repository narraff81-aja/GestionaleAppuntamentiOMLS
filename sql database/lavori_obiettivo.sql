CREATE TABLE IF NOT EXISTS `lavori_obiettivo` (
`id_lavoro` INT NOT NULL AUTO_INCREMENT,
`lavoro` VARCHAR(130) NOT NULL UNIQUE,
PRIMARY KEY (`id_lavoro`)
) DEFAULT CHARSET=utf8 COMMENT 'tabella di supporto';
