
/*remove volgorde 
koppel,
eindstage. stage, bedrijfbegleider, bedrijf, 
docent, student, coordinator,  
opleiding, acedemie, 
algemeen, webkey, persoon, adres, kennisgebied*/
DELETE FROM `kennisgebieddocentset`;
DELETE FROM `kennisgebiedstageset`;
DELETE FROM `opleidingdocentset`;

DELETE FROM `eindstagesets`;
DELETE FROM `stagesets`;
DELETE FROM `bedrijfsbegeleidersets`;
DELETE FROM `bedrijfsets`;

DELETE FROM `docentsets`;
DELETE FROM `studentsets`;
DELETE FROM `coordinator`;

DELETE FROM `opleidingsets`;
DELETE FROM `academiesets`;

DELETE FROM `algemeensets`;
DELETE FROM `webkeysets`;
DELETE FROM `persoonsets`;
DELETE FROM `adressets`;
DELETE FROM `kennisgebiedset`;

LOCK TABLES `algemeensets` WRITE;
DELETE FROM `algemeensets` ;
INSERT INTO `algemeensets` VALUES (1, 2012, 1659, 4);
INSERT INTO `algemeensets` VALUES (2, 2012, 2000, 4);
INSERT INTO `algemeensets` VALUES (3, 2012, 1500, 4);
INSERT INTO `algemeensets` VALUES (4, 2012, 1659, 5);
INSERT INTO `algemeensets` VALUES (5, 2012, 2000, 5);
INSERT INTO `algemeensets` VALUES (6, 2012, 1500, 5);
INSERT INTO `algemeensets` VALUES (7, 2013, 1659, 4);
INSERT INTO `algemeensets` VALUES (8, 2014, 1659, 4);
INSERT INTO `algemeensets` VALUES (9, 2016, 1659, 4);
INSERT INTO `algemeensets` VALUES (10, 2011, 500, 2);
UNLOCK TABLES;

LOCK TABLES `academiesets` WRITE;
DELETE FROM `academiesets` ;
INSERT INTO `academiesets` VALUES (1, 'AI&I');
INSERT INTO `academiesets` VALUES (2, 'AAFM');
INSERT INTO `academiesets` VALUES (3, 'B&M');
INSERT INTO `academiesets` VALUES (4, 'ABCT');
INSERT INTO `academiesets` VALUES (5, 'TvG&M');
INSERT INTO `academiesets` VALUES (6, 'AMBM');
INSERT INTO `academiesets` VALUES (7, 'AFM');
INSERT INTO `academiesets` VALUES (8, 'Gez');
INSERT INTO `academiesets` VALUES (9, 'HR&B');
INSERT INTO `academiesets` VALUES (10, 'Jur');

UNLOCK TABLES;

LOCK TABLES `opleidingsets` WRITE;

DELETE FROM `opleidingsets` ;
INSERT INTO `opleidingsets` VALUES (1, 'Informatica', 1);
INSERT INTO `opleidingsets` VALUES (2, 'Informatica SO', 1);
INSERT INTO `opleidingsets` VALUES (3, 'Informatica IBIS', 1);
INSERT INTO `opleidingsets` VALUES (4, 'Elektro techniek', 1);
INSERT INTO `opleidingsets` VALUES (5, 'Werktuig bouwkunde', 1);
INSERT INTO `opleidingsets` VALUES (6, 'Commerciële Economie', 6);
INSERT INTO `opleidingsets` VALUES (7, 'Bestuurdskunde en Overheidsmanagement', 10);
INSERT INTO `opleidingsets` VALUES (8, 'Recht', 10);
INSERT INTO `opleidingsets` VALUES (9, 'communicatie', 6);
INSERT INTO `opleidingsets` VALUES (10, 'Bedrijfswiskunde', 6);

UNLOCK TABLES;

LOCK TABLES `kennisgebiedset` WRITE;

DELETE FROM `kennisgebiedset` ;
INSERT INTO `kennisgebiedset` VALUES (1, 'html');
INSERT INTO `kennisgebiedset` VALUES (2, 'css');
INSERT INTO `kennisgebiedset` VALUES (3, 'C#');
INSERT INTO `kennisgebiedset` VALUES (4, 'Java');
INSERT INTO `kennisgebiedset` VALUES (5, 'UML');
INSERT INTO `kennisgebiedset` VALUES (6, 'Presenteren');
INSERT INTO `kennisgebiedset` VALUES (7, 'Word');
INSERT INTO `kennisgebiedset` VALUES (8, 'Excel');
INSERT INTO `kennisgebiedset` VALUES (9, 'Economie');
INSERT INTO `kennisgebiedset` VALUES (10, 'XML');

UNLOCK TABLES;

LOCK TABLES `adressets` WRITE;

DELETE FROM `adressets` ;
INSERT INTO `adressets` VALUES (1, 'Geffen', 'trudostraat', '4', '5386 BH');
INSERT INTO `adressets` VALUES (2, 'Geffen', 'trudostraat', '9', '5386 BH');
INSERT INTO `adressets` VALUES (3, 'Apeldoorn', 'Boogschutterstraat', '7b', '7324 AE');
INSERT INTO `adressets` VALUES (4, 'Vianen', 'Lange Dreef', '17', '4130 EB');
INSERT INTO `adressets` VALUES (5, 'Nieuwegein', 'Coltbaan', '4', '3439 NH');
INSERT INTO `adressets` VALUES (6, 'Breda', 'Mozartlaan', '7', '4837 EH');
INSERT INTO `adressets` VALUES (7, 'Haarlem', 'Wilhelminastraat', '18', '2011 VM');
INSERT INTO `adressets` VALUES (8, 'Rotterdam', 'Blaak', '40', '3011 TA');
INSERT INTO `adressets` VALUES (9, 'Roosendaal', 'Vlierwerf', '3', '4704 SB');
INSERT INTO `adressets` VALUES (10, 'Den Haag', 'koningskade', '30', '2596 AA');

UNLOCK TABLES;

LOCK TABLES `bedrijfsets` WRITE;

DELETE FROM `bedrijfsets` ;
INSERT INTO `bedrijfsets` VALUES (1, 'Sogeti', null, 'www.sogeti.nl', 4);
INSERT INTO `bedrijfsets` VALUES (2, 'Thinkwise', 61638, 'www.thinkwisesoftware.com', 3);
INSERT INTO `bedrijfsets` VALUES (3, 'Smartproginc', 07353333, null, 1);
INSERT INTO `bedrijfsets` VALUES (4, 'microsoft', null, 'microsoft.com', 2);
INSERT INTO `bedrijfsets` VALUES (5, 'dell', null, 'dell.nl', 5);
INSERT INTO `bedrijfsets` VALUES (6, 'ictexpert', null, null, 6);
INSERT INTO `bedrijfsets` VALUES (7, 'bioware', 432432424, 'bioware.com', 7);
INSERT INTO `bedrijfsets` VALUES (8, 'apple', null, 'apple.nl', 8);
INSERT INTO `bedrijfsets` VALUES (9, 'mirabeau', 324344566, 'mirabeau.com',  9);
INSERT INTO `bedrijfsets` VALUES (10, 'SCH', 5423829843, null, 10);

UNLOCK TABLES;


/*personen 30*/
LOCK TABLES `persoonsets` WRITE;

DELETE FROM `persoonsets` ;
INSERT INTO `persoonsets` VALUES (1, 'Leon', 'van Tuijl', 'lpjtuijl@avans.nl', '06253464532');
INSERT INTO `persoonsets` VALUES (2, 'Bart', 'Schut', 'bschut1@avans.nl', null);
INSERT INTO `persoonsets` VALUES (3, 'Henk', 'de Vries', 'henkv@hotmail.com', null);
INSERT INTO `persoonsets` VALUES (4, 'Pieter', 'Hogendijk', 'pietertje@gmail.com', null);
INSERT INTO `persoonsets` VALUES (5, 'Frans', 'Spijkerman', 'fspijk@avans.nl', null);
INSERT INTO `persoonsets` VALUES (6, 'Ger', 'Saris', 'gsaris@avans.nl', null);
INSERT INTO `persoonsets` VALUES (7, 'Robert', 'bovenkamp', 'bovenkamp@gmail.com', null);
INSERT INTO `persoonsets` VALUES (8, 'Gerard', 'Eikendoorn', 'programmer123@hotmail.com', null);
INSERT INTO `persoonsets` VALUES (9, 'Theo', 'Maasdonk', 'Theomasen@home.nl', null);
INSERT INTO `persoonsets` VALUES (10, 'Katinka', 'Jansen', 'kjansen@avans.nl', null);
INSERT INTO `persoonsets` VALUES (11, 'Eric', 'Apeldoorn', 'mgnrn@home.nl', '0614235243');

UNLOCK TABLES;

/*webkeys 20*/
LOCK TABLES `webkeysets` WRITE;

DELETE FROM `webkeysets` ;
INSERT INTO `webkeysets` VALUES (1, '00001', 'actief');
INSERT INTO `webkeysets` VALUES (2, '00002', 'actief');
INSERT INTO `webkeysets` VALUES (3, '00003', 'inactief');
INSERT INTO `webkeysets` VALUES (4, '00004', 'actief');
INSERT INTO `webkeysets` VALUES (5, '00005', 'actief');
INSERT INTO `webkeysets` VALUES (6, '00006', 'actief');
INSERT INTO `webkeysets` VALUES (7, '00007', 'actief');
INSERT INTO `webkeysets` VALUES (8, '00008', 'actief');
INSERT INTO `webkeysets` VALUES (9, '00009', 'actief');
INSERT INTO `webkeysets` VALUES (10, '00010', 'actief');


UNLOCK TABLES;

/*docenten*/

LOCK TABLES `docentsets` WRITE;

DELETE FROM `docentsets` ;
INSERT INTO `docentsets` VALUES (5, 0.65, 1, 1, 0.23, 1, 4,1, 'Openbaar vervoer');
INSERT INTO `docentsets` VALUES (6, 0.65, 1, 1, 1, 1, 7,2, 'Auto');
INSERT INTO `docentsets` VALUES (7, 1, 1, 1, 1, 7, 3,3, 'Fiets');

UNLOCK TABLES;

/*studenten*/

LOCK TABLES `studentsets` WRITE;

DELETE FROM `studentsets` ;
INSERT INTO `studentsets` VALUES (205170, 1, 2, 1, 4);
INSERT INTO `studentsets` VALUES (205120, 0, 2, 2, 5);
INSERT INTO `studentsets` VALUES (206120, 0, 1, 3, 6);
INSERT INTO `studentsets` VALUES (209199, 0, 10, 4, 7);


UNLOCK TABLES;

/*bedrijf begeleiders*/

LOCK TABLES `bedrijfsbegeleidersets` WRITE;

DELETE FROM `bedrijfsbegeleidersets` ;
INSERT INTO `bedrijfsbegeleidersets` VALUES ('Software Engineer', 'HBO', 1, 8, 2);
INSERT INTO `bedrijfsbegeleidersets` VALUES ('Architect', 'WO', 1, 9, 3);
INSERT INTO `bedrijfsbegeleidersets` VALUES ('Architect', 'HBO', 0, 11, 1);
UNLOCK TABLES;

/*coordinatoren*/
LOCK TABLES `coordinator` WRITE;

DELETE FROM `coordinator` ;
INSERT INTO `coordinator` VALUES (10, 'katinka', 'avans1', 1);

UNLOCK TABLES;

/*stage*/
LOCK TABLES `stagesets` WRITE;

DELETE FROM `stagesets` ;
INSERT INTO `stagesets` VALUES (1, '2014-10-20', '2015-3-20', 'In mijn opdracht zal ik een website maken via php. Dit zal in opdracht zijn van het bedrijf en ik zal zelf een klant interviewen.', null, 3, null);
INSERT INTO `stagesets` VALUES (2, '2016-8-25', '2017-1-15', 'C# project', 8, 2, null);
INSERT INTO `stagesets` VALUES (3, '2016-8-25', '2017-1-15', 'Afstudeerstage waarbij een management systeem gemaakt moet worden', 8, 4, 7);
INSERT INTO `stagesets` VALUES (4, '2012-8-25', '2013-1-15', 'Afstudeerstage java', 8, 1, null);

UNLOCK TABLES;

LOCK TABLES `eindstagesets` WRITE;

DELETE FROM `eindstagesets` ;
INSERT INTO `eindstagesets` VALUES (3, 6);
INSERT INTO `eindstagesets` VALUES (4, null);

UNLOCK TABLES;


/*koppel*/

LOCK TABLES `kennisgebieddocentset` WRITE;

DELETE FROM `kennisgebieddocentset` ;
INSERT INTO `kennisgebieddocentset` VALUES (5, 4);
INSERT INTO `kennisgebieddocentset` VALUES (5, 5);
INSERT INTO `kennisgebieddocentset` VALUES (5, 10);
INSERT INTO `kennisgebieddocentset` VALUES (5, 7);
INSERT INTO `kennisgebieddocentset` VALUES (5, 3);
INSERT INTO `kennisgebieddocentset` VALUES (7, 1);
INSERT INTO `kennisgebieddocentset` VALUES (7, 2);
INSERT INTO `kennisgebieddocentset` VALUES (7, 3);
INSERT INTO `kennisgebieddocentset` VALUES (7, 10);
INSERT INTO `kennisgebieddocentset` VALUES (6, 6);
INSERT INTO `kennisgebieddocentset` VALUES (6, 7);
INSERT INTO `kennisgebieddocentset` VALUES (6, 9);

UNLOCK TABLES;

LOCK TABLES `kennisgebiedstageset` WRITE;

DELETE FROM `kennisgebiedstageset` ;
INSERT INTO `kennisgebiedstageset` VALUES (1, 1);
INSERT INTO `kennisgebiedstageset` VALUES (1, 2);
INSERT INTO `kennisgebiedstageset` VALUES (1, 6);
INSERT INTO `kennisgebiedstageset` VALUES (1, 7);
INSERT INTO `kennisgebiedstageset` VALUES (1, 9);
INSERT INTO `kennisgebiedstageset` VALUES (2, 3);
INSERT INTO `kennisgebiedstageset` VALUES (2, 5);
INSERT INTO `kennisgebiedstageset` VALUES (2, 10);
INSERT INTO `kennisgebiedstageset` VALUES (3, 1);
INSERT INTO `kennisgebiedstageset` VALUES (3, 5);
INSERT INTO `kennisgebiedstageset` VALUES (3, 10);
INSERT INTO `kennisgebiedstageset` VALUES (4, 7);
INSERT INTO `kennisgebiedstageset` VALUES (4, 8);
INSERT INTO `kennisgebiedstageset` VALUES (4, 4);
INSERT INTO `kennisgebiedstageset` VALUES (4, 5);

UNLOCK TABLES;

LOCK TABLES `opleidingdocentset` WRITE;

DELETE FROM `opleidingdocentset` ;
INSERT INTO `opleidingdocentset` VALUES (5, 1);
INSERT INTO `opleidingdocentset` VALUES (5, 2);
INSERT INTO `opleidingdocentset` VALUES (7, 1);
INSERT INTO `opleidingdocentset` VALUES (7, 2);
INSERT INTO `opleidingdocentset` VALUES (7, 3);
INSERT INTO `opleidingdocentset` VALUES (6, 4);
INSERT INTO `opleidingdocentset` VALUES (6, 5);
INSERT INTO `opleidingdocentset` VALUES (6, 6);
INSERT INTO `opleidingdocentset` VALUES (6, 7);

UNLOCK TABLES;