CREATE TABLE IF NOT EXISTS `log` (
`id_log` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
`data_ora` TIMESTAMP NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
`id_utente` INT NOT NULL,
`ip` VARCHAR(45) NULL COMMENT 'ok per IPv4 e IPv6',
`nome_tabella` VARCHAR(100) NOT NULL COMMENT 'tabella che verrà modificata',
`nome_campo` VARCHAR(100) NOT NULL COMMENT 'campo della tabella che verrà modificato',
`valore_vecchio` VARCHAR(255) NOT NULL,
`valore_nuovo` VARCHAR(255) NOT NULL,
`azione` VARCHAR(20) NOT NULL
) DEFAULT CHARSET=utf8;
