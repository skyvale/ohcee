# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.7.23)
# Database: Ohcee
# Generation Time: 2019-03-28 23:58:03 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table fandoms
# ------------------------------------------------------------

DROP TABLE IF EXISTS `fandoms`;

CREATE TABLE `fandoms` (
  `fandomId` int(11) NOT NULL AUTO_INCREMENT,
  `fandomName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`fandomId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `fandoms` WRITE;
/*!40000 ALTER TABLE `fandoms` DISABLE KEYS */;

INSERT INTO `fandoms` (`fandomId`, `fandomName`)
VALUES
	(1,'Adventure Time'),
	(2,'Attack on Titan'),
	(3,'Assassination Classroom'),
	(4,'Avatar the Last Airbender'),
	(5,'BTS'),
	(6,'Bleach'),
	(7,'Camp Camp'),
	(8,'Code Geass'),
	(9,'Creepypasta'),
	(10,'Cuphead'),
	(11,'DC'),
	(12,'Danganronpa'),
	(13,'Disney'),
	(14,'Divergent'),
	(15,'Dragon Ball'),
	(16,'Doctor Who'),
	(17,'Dont Starve'),
	(18,'Fairy Tale'),
	(19,'Fear Mythos'),
	(20,'Fire Emblem'),
	(21,'Final Fantasy'),
	(22,'Five Nights at Freddys'),
	(23,'Game of Thrones'),
	(24,'Gravity Falls'),
	(25,'Happy Tree Friends'),
	(26,'Harry Potter'),
	(27,'Hamilton'),
	(28,'Homestuck'),
	(29,'How to Train Your Dragon'),
	(30,'Inuyasha'),
	(31,'Invader Zim'),
	(32,'League of Legends'),
	(33,'Lord of the Rings'),
	(34,'Marvel'),
	(35,'Marble Hornets'),
	(36,'Miraculous Ladybug'),
	(37,'Minecraft'),
	(38,'My Hero Academia'),
	(39,'My Little Pony'),
	(40,'Naruto'),
	(41,'One Piece'),
	(42,'One Punch Man'),
	(43,'Osomatsu'),
	(44,'Overwatch'),
	(45,'Percy Jackson'),
	(46,'Pokemon'),
	(47,'RWBY'),
	(48,'SCP'),
	(49,'Sherlock Holmes'),
	(50,'She-ra'),
	(51,'Silent Hill'),
	(52,'Star Trek'),
	(53,'Star Wars'),
	(54,'Star vs the Forces of Evil'),
	(55,'Supernatural'),
	(56,'Sword Art Online'),
	(57,'The Dragon Prince'),
	(58,'The Elder Scrolls'),
	(59,'The Simpsons'),
	(60,'Teen Wolf'),
	(61,'Tokyo Ghoul'),
	(62,'Twilight'),
	(63,'Undertale'),
	(64,'Vampire Knight'),
	(65,'Vocaloid'),
	(66,'Voltron'),
	(67,'Warrior Cats'),
	(68,'Welcome to Night Vale'),
	(69,'Winx Club'),
	(70,'Yu-Gi-Oh'),
	(71,'Youtube'),
	(72,'Horror');

/*!40000 ALTER TABLE `fandoms` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table gender
# ------------------------------------------------------------

DROP TABLE IF EXISTS `gender`;

CREATE TABLE `gender` (
  `genderId` int(11) NOT NULL AUTO_INCREMENT,
  `genderName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`genderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `gender` WRITE;
/*!40000 ALTER TABLE `gender` DISABLE KEYS */;

INSERT INTO `gender` (`genderId`, `genderName`)
VALUES
	(1,'Male'),
	(2,'Female'),
	(3,'Transgender'),
	(4,'Non-binary'),
	(5,'Genderless');

/*!40000 ALTER TABLE `gender` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table ocs
# ------------------------------------------------------------

DROP TABLE IF EXISTS `ocs`;

CREATE TABLE `ocs` (
  `characterId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `age` varchar(100) DEFAULT NULL,
  `genderId` int(11) DEFAULT NULL,
  `speciesId` int(11) DEFAULT NULL,
  `fandomId` int(11) DEFAULT NULL,
  `about` text,
  `ogDesigner` varchar(100) DEFAULT NULL,
  `prevOwner` varchar(100) DEFAULT NULL,
  `createdDate` datetime DEFAULT NULL,
  PRIMARY KEY (`characterId`),
  KEY `speciesid` (`speciesId`),
  KEY `genderId` (`genderId`),
  KEY `fandomId` (`fandomId`),
  KEY `index_ocs` (`name`),
  KEY `index_designers` (`ogDesigner`),
  KEY `index_owners` (`prevOwner`),
  CONSTRAINT `ocs_ibfk_1` FOREIGN KEY (`speciesId`) REFERENCES `species` (`speciesId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ocs_ibfk_2` FOREIGN KEY (`genderId`) REFERENCES `gender` (`genderId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ocs_ibfk_3` FOREIGN KEY (`fandomId`) REFERENCES `fandoms` (`fandomId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `ocs` WRITE;
/*!40000 ALTER TABLE `ocs` DISABLE KEYS */;

INSERT INTO `ocs` (`characterId`, `name`, `age`, `genderId`, `speciesId`, `fandomId`, `about`, `ogDesigner`, `prevOwner`, `createdDate`)
VALUES
	(1,'Noah Harren','15',1,1,9,'Premature death ran in Noah\'s family, whether it was by sickness or by accident. When Noah was born, his mother died in childbirth, and his father went into a deep, drunken depression-- which resulted in Noah having a somewhat neglected childhood.\n\nBefore Noah turned six, he would have night terrors of various people dying. However, on his sixth birthday, he saw a vision of his father dying in a car accident. The vision came true later that day, leaving Noah to live with his godparents, Matt and Jocelyn.\n\nThe visions continued, becoming more and more frequent until Noah saw the fates of everyone near him without his control. Normally, the accidents would be minor, but too often he would see visions of people\'s lives cut short and terrible disasters that would soon strike. He tried to warn his peers and at first, he was sneered at and called out for his so-called anxiety disorder and psychosis. After predicting the sudden cardiac arrest of his aunt, people began to fear him. Wherever he went, death would occur, and he began to believe that his mere presence was bad luck, that HE was the sole carrier of his family\'s curse. The people around him began to think this too and ostracized him-- calling him \'bad luck\' and \'an omen of death\'. Eventually, they nicknamed him “The Black Cat of the family” and he was scorned.\n\nNoah, not wanting to hurt his family or friends, decided it was best to run away. He\'s 15 years old and has been living on the streets since he was 13. He tries his best to avoid contact with people, but he has no choice if he wants to survive. Whenever someone dies, he takes what belongings they have in order to live, although he feels absolute guilt for doing so. ','marshmerry',NULL,'2019-03-24 17:00:19'),
	(2,'Cynder','young adult',2,9,39,'Cynder is positive, patient, and empathetic- unlike her counterpart. She loves making art for other ponies and helping in general just to see them smile. She has a sweet, but docile persona and is not easily angered. She has many friends.','marshmerry',NULL,'2019-03-24 17:00:19'),
	(3,'Cr0wn','23',2,1,72,'As a civilian, she is a friendly, yet distant person. There is always something vaguely off about it, but people don\'t know quite what. She doesn\'t let people become close to her and avoids relationships.\n\nAs Cr0wn, she is manic and calculating. She meticulously plans all of her kills and enjoys the thrill of catching her victims in their vulnerable moments. Cr0wn is a cautious person and cruel towards her targets-- but she will not target an \"innocent\" person.','marshmerry',NULL,'2019-03-24 17:00:19'),
	(4,'Somniculous','immortal',5,12,NULL,NULL,'Drathemeir','Drathemeir','2019-03-24 17:00:19'),
	(5,'Gallant','adult',1,9,NULL,NULL,'Gauche Bobbes','KonnyArt','2019-03-24 17:00:19'),
	(6,'Bee','17',2,1,46,'A timid, kind trainer whose starter was a Minun.\nHer goal is to take over her parent’s Pokemon Daycare when she is older, but she goes on a journey around Hoenn since her parents insisted she go see the world and gain experience to make her a stronger person.','marshmerry',NULL,'2019-03-24 17:00:19');

/*!40000 ALTER TABLE `ocs` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table species
# ------------------------------------------------------------

DROP TABLE IF EXISTS `species`;

CREATE TABLE `species` (
  `speciesId` int(11) NOT NULL AUTO_INCREMENT,
  `speciesName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`speciesId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `species` WRITE;
/*!40000 ALTER TABLE `species` DISABLE KEYS */;

INSERT INTO `species` (`speciesId`, `speciesName`)
VALUES
	(1,'Human'),
	(2,'Feline'),
	(3,'Canine'),
	(4,'Bird'),
	(5,'Lizard'),
	(6,'Aquatic'),
	(7,'Dinosaur'),
	(8,'Anthro'),
	(9,'Mythical'),
	(10,'Monster'),
	(11,'Canon Species'),
	(12,'Original Species'),
	(13,'Other');

/*!40000 ALTER TABLE `species` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table users
# ------------------------------------------------------------

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `passwordEncrypted` varchar(50) DEFAULT NULL,
  `createdDate` datetime DEFAULT NULL,
  `userTypeId` int(50) DEFAULT NULL,
  PRIMARY KEY (`userId`),
  KEY `userTypeId` (`userTypeId`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`userTypeId`) REFERENCES `userTypes` (`userTypeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;

INSERT INTO `users` (`userId`, `username`, `password`, `passwordEncrypted`, `createdDate`, `userTypeId`)
VALUES
	(1,'skyvale','password','5f4dcc3b5aa765d61d8327deb882cf99','2019-03-20 16:12:26',1);

/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table userTypes
# ------------------------------------------------------------

DROP TABLE IF EXISTS `userTypes`;

CREATE TABLE `userTypes` (
  `userTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `userType` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `userTypes` WRITE;
/*!40000 ALTER TABLE `userTypes` DISABLE KEYS */;

INSERT INTO `userTypes` (`userTypeId`, `userType`)
VALUES
	(1,'Owner'),
	(2,'Admin'),
	(3,'Regular');

/*!40000 ALTER TABLE `userTypes` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
