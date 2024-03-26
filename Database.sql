-- tutorat database

## Création de la base de donnée ##

DROP DATABASE IF EXISTS tutorat;
CREATE DATABASE tutorat;

USE tutorat;


## Création de la table de donnée TblUser ##
DROP TABLE if EXISTS tutorat.user;
CREATE TABLE IF NOT EXISTS tutorat.user(

Id					INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
Username 		varchar(20) NOT NULL,
Email				VARCHAR(50) NOT NULL,
Role				VARCHAR(20) # admin, ...
);
## Insération des données  de TblUser ##

INSERT INTO user( username, Email, Role)
VALUES('JohnDoe', 'JohnDoe@gmail.com', NULL);
INSERT INTO user( username, Email, Role)
VALUES('JohnSmith', 'JohnSmith@gmail.com', NULL);

## Création de la table de donnée TblPassword ##
DROP TABLE if EXISTS tutorat.password;
CREATE TABLE IF NOT EXISTS tutorat.password(

Id					INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
Passwd 			VARCHAR(255) NOT NULL,
FOREIGN KEY(Id) REFERENCES user(Id)
);
## Insération des données  de TblPassword ##

INSERT INTO password( Passwd)
VALUES(MD5('Pass12345!')); # md5 hash motDePasse
INSERT INTO password( Passwd)
VALUES(SHA2('Pass12345!', 256)); # another hash motDePasse

## Création de la table de donnée TblHoraire ##
  
DROP TABLE if EXISTS tutorat.horaire;
CREATE TABLE IF NOT EXISTS Tutorat.horaire(

Id					INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
Dispo1			VARCHAR(20),  # Choix numéro1(préférable) fromat : Lundi 12h-15h
Dispo2			VARCHAR(20),  # Si 1 pas possible
Dispo3			VARCHAR(20)	  # Si 1 et 2 pas possible
);
## Insération des données  de TblHoraire ##

INSERT INTO horaire(Dispo1, Dispo2, Dispo3)
VALUES('Lundi 12h-13h', 'Jeudi 14h-15h','Vendredi 10h-11h');


## Création de la table de donnée élève  ##

DROP TABLE if EXISTS tutorat.eleve;
CREATE TABLE IF NOT EXISTS tutorat.eleve(

DEA 			INT NOT NULL PRIMARY KEY,
Nom 			varchar(20) NOT NULL,
Prenom		varchar(20) NOT NULL,
Programme 			VARCHAR(30),
CoursFrancais 			INT, #1234
Antidote 		BOOL DEFAULT FALSE, # ou BOOL
InfosPertinentes 		VARCHAR(100), #problèmes d'apprentissage, maladies ...
ResultatTexte			INT, # nombre de fautes ou resultats
HoraireId  	INT,
FOREIGN KEY(HoraireId) REFERENCES horaire(Id),
UserId 	INT,
FOREIGN KEY(UserId) REFERENCES user(Id)
);
## Insération des données  de TblEleve  ##

INSERT INTO eleve
VALUES(2159290, 'Sam', 'Doe', 'Science de la nature', 3, TRUE, NULL, 19, NULL, NULL);


## Création de la table de donnée TblTuteur ##
  
DROP TABLE if EXISTS tutorat.tuteur;
CREATE TABLE IF NOT EXISTS tutorat.tuteur(

Id 			INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
Nom 			varchar(20) NOT NULL,
Prenom		varchar(20) NOT NULL,
Anciennete 			DATE,
TypeTuteur 			varchar(20), #débutant, moyen, méga, enseignant
HoraireId  	INT,
FOREIGN KEY(HoraireId) REFERENCES horaire(Id),
UserId 	INT,
FOREIGN KEY(UserId) REFERENCES user(Id)
);
## Insération des données  de Tbltuteur ##

INSERT INTO tuteur(Nom, Prenom, Anciennete, TypeTuteur, HoraireId, UserId)
VALUES('John', 'Doe', NULL, 'moyen', NULL, NULL);


## Création de la table de donnée TblSessionTutorat ##
DROP TABLE if EXISTS tutorat.sessionTutorat;
CREATE TABLE IF NOT EXISTS tutorat.sessionTutorat(

Id					INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
DateSession		DATE,
HeureDebut		VARCHAR(10), # format : 12:00
eleveDEA			INT NOT NULL,
FOREIGN KEY(eleveDEA) REFERENCES eleve(DEA),
TuteurId			INT NOT NULL,
FOREIGN KEY(TuteurId) REFERENCES tuteur(Id),
NoteRencontreEleve	INT, # note/20
NoteRencontreTuteur	INT, # note/20
InfosRencontre			VARCHAR(200)
);
## Insération des données  de TblSessionTutorat ##

INSERT INTO sessionTutorat(DateSession, HeureDebut, eleveDEA, TuteurId)
VALUES(CURDATE(), '12:00', 2159290, 1);
