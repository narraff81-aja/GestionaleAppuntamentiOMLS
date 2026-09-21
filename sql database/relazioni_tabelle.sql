ALTER TABLE `utenti`
ADD CONSTRAINT `fk_utenti_omls`
FOREIGN KEY (`id_omls`) 
REFERENCES `omls`(`id_omls`);

ALTER TABLE `cittadini`
ADD CONSTRAINT `fk_cittadini_omls`
FOREIGN KEY (`id_omls`) 
REFERENCES `omls`(`id_omls`);


ALTER TABLE `cittadini`
ADD CONSTRAINT `fk_cittadini_beneficio`
FOREIGN KEY (`id_beneficio`) 
REFERENCES `tipo_beneficio`(`id_beneficio`);

ALTER TABLE `faq`
ADD CONSTRAINT `fk_faq_utenti`
FOREIGN KEY (`id_utente`) 
REFERENCES `utenti`(`id_utente`);

ALTER TABLE `cittadini`
ADD CONSTRAINT `fk_cittadini_stato_finale`
FOREIGN KEY (`id_stato_finale`) 
REFERENCES `stato_finale`(`id_stato_finale`);

ALTER TABLE `interventi_gol`
ADD CONSTRAINT `fk_gol_cittadino`
FOREIGN KEY (`id_cittadino`) 
REFERENCES `cittadini`(`id_cittadino`);

ALTER TABLE `interventi_gol`
ADD CONSTRAINT `fk_gol_omls`
FOREIGN KEY (`id_omls`) 
REFERENCES `omls`(`id_omls`);

ALTER TABLE `gestioni_sommarie_appuntamenti`
ADD CONSTRAINT `fk_gsa_cittadino`
FOREIGN KEY (`id_cittadino`) 
REFERENCES `cittadini`(`id_cittadino`);

ALTER TABLE `gestioni_sommarie_appuntamenti`
ADD CONSTRAINT `fk_gsa_omls`
FOREIGN KEY (`id_omls`) 
REFERENCES `omls`(`id_omls`);

ALTER TABLE `gestioni_appuntamenti`
ADD CONSTRAINT `fk_ga_cittadino`
FOREIGN KEY (`id_cittadino`) 
REFERENCES `cittadini`(`id_cittadino`);

ALTER TABLE `gestioni_appuntamenti`
ADD CONSTRAINT `fk_ga_omls`
FOREIGN KEY (`id_omls`) 
REFERENCES `omls`(`id_omls`);
