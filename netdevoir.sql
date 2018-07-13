/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: étudiant
------------------------------------------------------------*/
CREATE TABLE etudiant(
	nom            VARCHAR (25)  ,
	id_etudiant    INT  NOT NULL ,
	tel            VARCHAR (25)  ,
	email          VARCHAR (25)  ,
	numero_nas     VARCHAR (25)  ,
	date_naissance VARCHAR (25)  ,
	lieu_de_naiss  VARCHAR (25)  ,
	gendre         VARCHAR (25)  ,
	img            VARBINARY(MAX)   ,
	CONSTRAINT prk_constraint_etudiant PRIMARY KEY NONCLUSTERED (id_etudiant)
);


/*------------------------------------------------------------
-- Table: professeur
------------------------------------------------------------*/
CREATE TABLE professeur(
	nom          VARCHAR (25)  ,
	id_prof      INT  NOT NULL ,
	tel          VARCHAR (25)  ,
	email        VARCHAR (25)  ,
	salaire_prof INT   ,
	img          VARBINARY(MAX)   ,
	CONSTRAINT prk_constraint_professeur PRIMARY KEY NONCLUSTERED (id_prof)
);


/*------------------------------------------------------------
-- Table: frais
------------------------------------------------------------*/
CREATE TABLE frais(
	id_frais      INT  NOT NULL ,
	type_frais    VARCHAR (25)  ,
	montant_frais INT   ,
	id_etudiant   INT   ,
	id_recu       INT   ,
	CONSTRAINT prk_constraint_frais PRIMARY KEY NONCLUSTERED (id_frais)
);


/*------------------------------------------------------------
-- Table: sale
------------------------------------------------------------*/
CREATE TABLE sale(
	id_sale  INT  NOT NULL ,
	capacite INT   ,
	CONSTRAINT prk_constraint_sale PRIMARY KEY NONCLUSTERED (id_sale)
);


/*------------------------------------------------------------
-- Table: matier
------------------------------------------------------------*/
CREATE TABLE matier(
	id_matier   INT  NOT NULL ,
	nom_matier  VARCHAR (25)  ,
	coef_matier INT   ,
	id_section  INT   ,
	CONSTRAINT prk_constraint_matier PRIMARY KEY NONCLUSTERED (id_matier)
);


/*------------------------------------------------------------
-- Table: horaire
------------------------------------------------------------*/
CREATE TABLE horaire(
	id_horaire   INT  NOT NULL ,
	date_horaire VARCHAR (25)  ,
	debut_h      VARCHAR (25)  ,
	fin_h        VARCHAR (25)  ,
	CONSTRAINT prk_constraint_horaire PRIMARY KEY NONCLUSTERED (id_horaire)
);


/*------------------------------------------------------------
-- Table: seance
------------------------------------------------------------*/
CREATE TABLE seance(
	id_seance   INT  NOT NULL ,
	id_prof     INT   ,
	id_horaire  INT   ,
	id_sale     INT   ,
	id_etudiant INT   ,
	id_matier   INT   ,
	id_type     INT   ,
	CONSTRAINT prk_constraint_seance PRIMARY KEY NONCLUSTERED (id_seance)
);


/*------------------------------------------------------------
-- Table: note
------------------------------------------------------------*/
CREATE TABLE note(
	id_note     INT  NOT NULL ,
	note_cc     FLOAT   ,
	note_ex     FLOAT   ,
	id_etudiant INT   ,
	id_sem      INT   ,
	id_matier   INT   ,
	CONSTRAINT prk_constraint_note PRIMARY KEY NONCLUSTERED (id_note)
);


/*------------------------------------------------------------
-- Table: trimestre
------------------------------------------------------------*/
CREATE TABLE trimestre(
	libelle    VARCHAR (25)  ,
	id_sem     INT  NOT NULL ,
	date_debut VARCHAR (25)  ,
	date_fin   VARCHAR (25)  ,
	CONSTRAINT prk_constraint_trimestre PRIMARY KEY NONCLUSTERED (id_sem)
);


/*------------------------------------------------------------
-- Table: section
------------------------------------------------------------*/
CREATE TABLE section(
	id_section  INT  NOT NULL ,
	nom_section VARCHAR (25)  ,
	id_etudiant INT   ,
	CONSTRAINT prk_constraint_section PRIMARY KEY NONCLUSTERED (id_section)
);


/*------------------------------------------------------------
-- Table: type
------------------------------------------------------------*/
CREATE TABLE type(
	id_type     INT  NOT NULL ,
	type_seance VARCHAR (25)  ,
	CONSTRAINT prk_constraint_type PRIMARY KEY NONCLUSTERED (id_type)
);


/*------------------------------------------------------------
-- Table: reçu
------------------------------------------------------------*/
CREATE TABLE recu(
	id_recu   INT  NOT NULL ,
	date_recu VARCHAR (25)  ,
	CONSTRAINT prk_constraint_recu PRIMARY KEY NONCLUSTERED (id_recu)
);



ALTER TABLE frais ADD CONSTRAINT FK_frais_id_etudiant FOREIGN KEY (id_etudiant) REFERENCES etudiant(id_etudiant);
ALTER TABLE frais ADD CONSTRAINT FK_frais_id_recu FOREIGN KEY (id_recu) REFERENCES recu(id_recu);
ALTER TABLE matier ADD CONSTRAINT FK_matier_id_section FOREIGN KEY (id_section) REFERENCES section(id_section);
ALTER TABLE seance ADD CONSTRAINT FK_seance_id_prof FOREIGN KEY (id_prof) REFERENCES professeur(id_prof);
ALTER TABLE seance ADD CONSTRAINT FK_seance_id_horaire FOREIGN KEY (id_horaire) REFERENCES horaire(id_horaire);
ALTER TABLE seance ADD CONSTRAINT FK_seance_id_sale FOREIGN KEY (id_sale) REFERENCES sale(id_sale);
ALTER TABLE seance ADD CONSTRAINT FK_seance_id_etudiant FOREIGN KEY (id_etudiant) REFERENCES etudiant(id_etudiant);
ALTER TABLE seance ADD CONSTRAINT FK_seance_id_matier FOREIGN KEY (id_matier) REFERENCES matier(id_matier);
ALTER TABLE seance ADD CONSTRAINT FK_seance_id_type FOREIGN KEY (id_type) REFERENCES type(id_type);
ALTER TABLE note ADD CONSTRAINT FK_note_id_etudiant FOREIGN KEY (id_etudiant) REFERENCES etudiant(id_etudiant);
ALTER TABLE note ADD CONSTRAINT FK_note_id_sem FOREIGN KEY (id_sem) REFERENCES trimestre(id_sem);
ALTER TABLE note ADD CONSTRAINT FK_note_id_matier FOREIGN KEY (id_matier) REFERENCES matier(id_matier);
ALTER TABLE section ADD CONSTRAINT FK_section_id_etudiant FOREIGN KEY (id_etudiant) REFERENCES etudiant(id_etudiant);
