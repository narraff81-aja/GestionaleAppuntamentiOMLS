CREATE TABLE IF NOT EXISTS `utenti` (
`id_utente` INT NOT NULL AUTO_INCREMENT,
`id_omls` INT NOT NULL, 
`username` VARCHAR(100) NOT NULL UNIQUE,
`password` VARCHAR(255) NOT NULL COMMENT 'hash password',
`ruolo` TINYINT(1) NOT NULL COMMENT '1=OMLS, 2= Admin, 3= Super Admin',
`stato` VARCHAR(20) NOT NULL COMMENT 'Attivo, Non attivo',
`colore_css` VARCHAR(100) NULL COMMENT 'colore distintivo nel front-end es: yellow, #ff0000, rgb(0,255,0)',
PRIMARY KEY (`id_utente`)
) DEFAULT CHARSET=utf8 COMMENT 'Utenti del sito web';
