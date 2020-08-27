-- MySqlBackup.NET 2.3
-- Dump Time: 2020-02-04 16:43:34
-- --------------------------------------
-- Server version 5.5.8 MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of activitylog
-- 

DROP TABLE IF EXISTS `activitylog`;
CREATE TABLE IF NOT EXISTS `activitylog` (
  `userid` varchar(50) NOT NULL DEFAULT '''',
  `userprocess` varchar(50) NOT NULL DEFAULT '''',
  `userdescription` varchar(150) NOT NULL,
  `dateofprocess` varchar(50) NOT NULL,
  `timeofprocess` varchar(50) NOT NULL,
  `number` int(10) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`number`)
) ENGINE=InnoDB AUTO_INCREMENT=448 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table activitylog
-- 

/*!40000 ALTER TABLE `activitylog` DISABLE KEYS */;
INSERT INTO `activitylog`(`userid`,`userprocess`,`userdescription`,`dateofprocess`,`timeofprocess`,`number`) VALUES
('129','Login','System Maintenance','2020-04-10','1:25 PM',1),
('129','Login','System Maintenance','2019-11-11','10:04 AM',2),
('129','Login','System Maintenance','2019-11-11','10:13 AM',3),
('129','Login','System Maintenance','2019-11-11','10:28 AM',4),
('129','Login','System Maintenance','2019-11-11','10:28 AM',5),
('129','Login','System Maintenance','2019-12-03','3:11 PM',6),
('129','Login','System Maintenance','2019-12-05','11:28 AM',7),
('129','View Activity Log','System Maintenance','2019-12-05','11:31 AM',8),
('129','View Master List Reports','System Maintenance','2019-12-05','11:32 AM',9),
('129','View Account Reports','System Maintenance','2019-12-05','11:32 AM',10),
('129','Add User Type','Admin','2019-12-05','11:33 AM',11),
('129','Add User','Delos Santos Mack Jaygee Grane As Admin','2019-12-05','11:36 AM',12),
('129','Update User Previledge','Admin','2019-12-05','11:37 AM',13),
('129','Logout','System Maintenance','2019-12-05','11:37 AM',14),
('130','Login','Admin','2019-12-05','11:37 AM',15),
('129','Login','System Maintenance','2020-01-12','12:19 PM',16),
('129','Add User Type','Janitor','2020-01-12','12:20 PM',17),
('129','Add User','Almirol Jershon Grande As System Maintenance','2020-01-12','12:21 PM',18),
('129','Logout','System Maintenance','2020-01-12','12:21 PM',19),
('131','Login','System Maintenance','2020-01-12','12:21 PM',20),
('131','Update User Information','Almirol Jershon Grande','2020-01-12','12:22 PM',21),
('131','Logout','System Maintenance','2020-01-12','12:22 PM',22),
('131','Login','Janitor','2020-01-12','12:22 PM',23),
('131','Logout','Janitor','2020-01-12','12:22 PM',24),
('129','Login','System Maintenance','2020-01-12','12:22 PM',25),
('129','Add Borrower','Delos Santos Mack Jaygee Grande','2020-01-12','12:23 PM',26),
('129','Login','System Maintenance','2020-01-12','12:24 PM',27),
('129','Add Attachment','Delos Santos Mack Jaygee Grande','2020-01-12','12:25 PM',28),
('129','Delete Attachment','Delos Santos Mack Jaygee Grande','2020-01-12','12:25 PM',29),
('129','View Activity Log','System Maintenance','2020-01-12','12:27 PM',30),
('129','View Borrower Reports','System Maintenance','2020-01-12','12:42 PM',31),
('129','View Master List Reports','System Maintenance','2020-01-12','12:42 PM',32),
('129','Add Attachment','Delos Santos Mack Jaygee Grande','2020-01-12','12:45 PM',33),
('129','Update Borrower Information','Delos Santos Mack Jaygee Grande','2020-01-12','12:47 PM',34),
('129','Logout','System Maintenance','2020-01-12','12:48 PM',35),
('129','Login','System Maintenance','2020-01-12','5:35 PM',36),
('129','Logout','System Maintenance','2020-01-12','5:36 PM',37),
('129','Login','System Maintenance','2020-02-04','8:39 AM',38),
('129','Logout','System Maintenance','2020-02-04','9:01 AM',39),
('129','Login','System Maintenance','2020-02-04','9:01 AM',40),
('129','Logout','System Maintenance','2020-02-04','9:01 AM',41),
('129','Login','System Maintenance','2020-02-04','9:01 AM',42),
('129','Logout','System Maintenance','2020-02-04','9:02 AM',43),
('130','Login','Admin','2020-02-04','9:02 AM',44),
('130','Logout','Admin','2020-02-04','9:03 AM',45),
('129','Login','System Maintenance','2020-02-04','9:05 AM',46),
('129','Add Borrower','Modrigo Joyce Ann S','2020-02-04','9:08 AM',47),
('129','Add Attachment','Modrigo Joyce Ann S','2020-02-04','9:10 AM',48),
('129','Set Max loan','Modrigo Joyce Ann S','2020-02-04','9:10 AM',49),
('129','View Activity Log','System Maintenance','2020-02-04','9:10 AM',50),
('129','View Borrower Reports','System Maintenance','2020-02-04','9:10 AM',51),
('129','Print Master List Reports','System Maintenance','2020-02-04','9:11 AM',52),
('129','Logout','System Maintenance','2020-02-04','9:13 AM',53),
('129','Login','System Maintenance','2020-02-04','9:14 AM',54),
('129','Add Attachment','Modrigo Joyce Ann S','2020-02-04','9:17 AM',55),
('129','View Borrower Reports','System Maintenance','2020-02-04','9:18 AM',56),
('129','View Account Reports','System Maintenance','2020-02-04','9:18 AM',57),
('129','Logout','System Maintenance','2020-02-04','9:22 AM',58),
('131','Login','Janitor','2020-02-04','9:22 AM',59),
('131','Logout','Janitor','2020-02-04','9:22 AM',60),
('129','Login','System Maintenance','2020-02-04','9:22 AM',61),
('129','View Activity Log','System Maintenance','2020-02-04','9:24 AM',62),
('129','Logout','System Maintenance','2020-02-04','9:24 AM',63),
('129','Login','System Maintenance','2020-02-04','9:24 AM',64),
('129','Add Attachment','Delos Santos Mack Jaygee Grande','2020-02-04','9:25 AM',65),
('129','View Borrower Reports','System Maintenance','2020-02-04','9:25 AM',66),
('129','View Account Reports','System Maintenance','2020-02-04','9:28 AM',67),
('129','View Master List Reports','System Maintenance','2020-02-04','9:29 AM',68),
('129','Print Master List Reports','System Maintenance','2020-02-04','9:30 AM',69),
('129','Logout','System Maintenance','2020-02-04','9:31 AM',70),
('129','Login','System Maintenance','2020-02-04','9:31 AM',71),
('129','Add Attachment','Delos Santos Mack Jaygee Grande','2020-02-04','9:32 AM',72),
('129','View Activity Log','System Maintenance','2020-02-04','9:35 AM',73),
('129','View Borrower Reports','System Maintenance','2020-02-04','9:36 AM',74),
('129','Logout','System Maintenance','2020-02-04','9:36 AM',75),
('131','Login','Janitor','2020-02-04','9:36 AM',76),
('131','Logout','Janitor','2020-02-04','9:37 AM',77),
('129','Login','System Maintenance','2020-02-04','9:37 AM',78),
('129','Add User Type','Boss','2020-02-04','9:38 AM',79),
('129','Add User','Dayon Kikiamotithy Temots As Boss','2020-02-04','9:39 AM',80),
('129','Logout','System Maintenance','2020-02-04','9:40 AM',81),
('129','Login','System Maintenance','2020-02-04','9:40 AM',82),
('129','Logout','System Maintenance','2020-02-04','9:41 AM',83),
('132','Login','Boss','2020-02-04','9:41 AM',84),
('132','Logout','Boss','2020-02-04','9:41 AM',85),
('129','Login','System Maintenance','2020-02-04','9:41 AM',86),
('129','Update User Previledge','Boss','2020-02-04','9:41 AM',87),
('129','Logout','System Maintenance','2020-02-04','9:42 AM',88),
('132','Login','Boss','2020-02-04','9:42 AM',89),
('132','Logout','Boss','2020-02-04','9:42 AM',90),
('129','Login','System Maintenance','2020-02-04','9:42 AM',91),
('129','View Activity Log','System Maintenance','2020-02-04','9:42 AM',92),
('129','Add User','Geronimo Nicolas Ortega As Boss','2020-02-04','9:46 AM',93),
('129','Logout','System Maintenance','2020-02-04','9:46 AM',94),
('133','Login','Boss','2020-02-04','9:47 AM',95),
('133','Logout','Boss','2020-02-04','9:47 AM',96),
('129','Login','System Maintenance','2020-02-04','9:47 AM',97),
('129','Logout','System Maintenance','2020-02-04','9:49 AM',98),
('129','Login','System Maintenance','2020-02-04','9:49 AM',99),
('129','Add Borrower','Agustino Arjay ','2020-02-04','9:52 AM',100),
('129','View Activity Log','System Maintenance','2020-02-04','9:52 AM',101),
('129','Add Attachment','Agustino Arjay ','2020-02-04','9:54 AM',102),
('129','Set Max loan','Agustino Arjay','2020-02-04','9:55 AM',103),
('129','Update Emergency Loan','Interest is update to 1%','2020-02-04','9:56 AM',104),
('129','Borrow Transaction','Agustino Arjay Borrow 1000','2020-02-04','9:58 AM',105),
('129','Logout','System Maintenance','2020-02-04','9:58 AM',106),
('129','Login','System Maintenance','2020-02-04','9:58 AM',107),
('129','View Activity Log','System Maintenance','2020-02-04','9:58 AM',108),
('129','Add Borrower','Lunzaga Jeremiah Valdesotto','2020-02-04','10:00 AM',109),
('129','Add Attachment','Lunzaga Jeremiah Valdesotto','2020-02-04','10:01 AM',110),
('129','Set Max loan','Lunzaga Jeremiah Valdesotto','2020-02-04','10:01 AM',111),
('129','Borrow Transaction','Lunzaga Jeremiah Valdesotto Borrow 1000','2020-02-04','10:02 AM',112),
('129','Logout','System Maintenance','2020-02-04','10:04 AM',113),
('129','Login','System Maintenance','2020-02-04','10:05 AM',114),
('129','Logout','System Maintenance','2020-02-04','10:06 AM',115),
('131','Login','Janitor','2020-02-04','10:06 AM',116),
('131','Logout','Janitor','2020-02-04','10:06 AM',117),
('129','Login','System Maintenance','2020-02-04','10:06 AM',118),
('129','Add User Type','Player','2020-02-04','10:07 AM',119),
('129','Add User','Caberto Cedric Arellano As Player','2020-02-04','10:08 AM',120),
('129','Logout','System Maintenance','2020-02-04','10:09 AM',121),
('134','Login','Player','2020-02-04','10:09 AM',122),
('134','Logout','Player','2020-02-04','10:10 AM',123),
('129','Login','System Maintenance','2020-02-04','10:10 AM',124),
('129','Update User Previledge','Player','2020-02-04','10:10 AM',125),
('129','Logout','System Maintenance','2020-02-04','10:10 AM',126),
('134','Login','Player','2020-02-04','10:10 AM',127),
('134','Logout','Player','2020-02-04','10:12 AM',128),
('129','Login','System Maintenance','2020-02-04','10:12 AM',129),
('129','View Activity Log','System Maintenance','2020-02-04','10:13 AM',130),
('129','Add Borrower','Bisnan Joan Lopez','2020-02-04','10:14 AM',131),
('129','Add Attachment','Bisnan Joan Lopez','2020-02-04','10:15 AM',132),
('129','Set Max loan','Bisnan Joan Lopez','2020-02-04','10:16 AM',133),
('129','Borrow Transaction','Bisnan Joan Lopez Borrow 1000','2020-02-04','10:17 AM',134),
('129','Logout','System Maintenance','2020-02-04','10:17 AM',135),
('131','Login','Janitor','2020-02-04','10:17 AM',136),
('131','Logout','Janitor','2020-02-04','10:17 AM',137),
('129','Login','System Maintenance','2020-02-04','10:17 AM',138),
('129','Add User Type','Student','2020-02-04','10:17 AM',139),
('129','Add User','Mingoy Jofel Tumlos As Student','2020-02-04','10:19 AM',140),
('129','Logout','System Maintenance','2020-02-04','10:19 AM',141),
('135','Login','Student','2020-02-04','10:20 AM',142),
('135','Logout','Student','2020-02-04','10:20 AM',143),
('129','Login','System Maintenance','2020-02-04','10:20 AM',144),
('129','Update User Previledge','Student','2020-02-04','10:21 AM',145),
('129','Logout','System Maintenance','2020-02-04','10:21 AM',146),
('135','Login','Student','2020-02-04','10:21 AM',147),
('135','Logout','Student','2020-02-04','10:21 AM',148),
('129','Login','System Maintenance','2020-02-04','10:21 AM',149),
('129','View Activity Log','System Maintenance','2020-02-04','10:21 AM',150),
('129','Logout','System Maintenance','2020-02-04','10:24 AM',151),
('129','Login','System Maintenance','2020-02-04','10:31 AM',152),
('129','Add Borrower','Mack Mack Mack','2020-02-04','10:33 AM',153),
('129','View Activity Log','System Maintenance','2020-02-04','10:33 AM',154),
('129','Logout','System Maintenance','2020-02-04','10:34 AM',155),
('131','Login','Janitor','2020-02-04','10:34 AM',156),
('131','Logout','Janitor','2020-02-04','10:34 AM',157),
('129','Login','System Maintenance','2020-02-04','10:34 AM',158),
('129','Update User Previledge','Janitor','2020-02-04','10:34 AM',159),
('129','Logout','System Maintenance','2020-02-04','10:34 AM',160),
('131','Login','Janitor','2020-02-04','10:34 AM',161),
('131','Logout','Janitor','2020-02-04','10:35 AM',162),
('129','Login','System Maintenance','2020-02-04','10:35 AM',163),
('129','Add User Type','Kahitano','2020-02-04','10:35 AM',164),
('129','Add User','Qwe Qwe Qwe As Kahitano','2020-02-04','10:36 AM',165),
('129','Logout','System Maintenance','2020-02-04','10:36 AM',166),
('136','Login','Kahitano','2020-02-04','10:36 AM',167),
('136','Logout','Kahitano','2020-02-04','10:37 AM',168),
('129','Login','System Maintenance','2020-02-04','10:37 AM',169),
('129','Add Attachment','Mack Mack Mack','2020-02-04','10:38 AM',170),
('129','Set Max loan','Mack Mack Mack','2020-02-04','10:39 AM',171),
('129','Borrow Transaction','Mack Mack Mack Borrow 1000','2020-02-04','10:40 AM',172),
('129','Update Emergency Loan','Interest is update to 10%','2020-02-04','10:42 AM',173),
('129','View Account Reports','System Maintenance','2020-02-04','10:43 AM',174),
('129','Logout','System Maintenance','2020-02-04','10:44 AM',175),
('129','Login','System Maintenance','2020-02-04','10:44 AM',176),
('129','View Activity Log','System Maintenance','2020-02-04','10:44 AM',177),
('129','Add User Type','Manager','2020-02-04','10:45 AM',178),
('129','Add User','Patriico Manuel Zamora As Manager','2020-02-04','10:46 AM',179),
('129','Logout','System Maintenance','2020-02-04','10:47 AM',180),
('137','Login','Manager','2020-02-04','10:47 AM',181),
('137','Logout','Manager','2020-02-04','10:47 AM',182),
('129','Login','System Maintenance','2020-02-04','10:47 AM',183),
('129','Update User Previledge','Manager','2020-02-04','10:47 AM',184),
('129','Logout','System Maintenance','2020-02-04','10:47 AM',185),
('137','Login','Manager','2020-02-04','10:48 AM',186),
('137','Logout','Manager','2020-02-04','10:48 AM',187),
('129','Login','System Maintenance','2020-02-04','10:48 AM',188),
('129','Borrow Transaction','Mack Mack Mack Borrow 1000','2020-02-04','10:49 AM',189),
('129','View Borrower Reports','System Maintenance','2020-02-04','10:52 AM',190),
('129','View Account Reports','System Maintenance','2020-02-04','10:52 AM',191),
('129','Update Emergency Loan','Interest is update to 20%','2020-02-04','10:53 AM',192),
('129','View Account Reports','System Maintenance','2020-02-04','10:53 AM',193),
('129','Borrow Transaction','Mack Mack Mack Borrow 1000','2020-02-04','10:54 AM',194),
('129','View Account Reports','System Maintenance','2020-02-04','10:54 AM',195),
('129','Logout','System Maintenance','2020-02-04','10:56 AM',196),
('129','Login','System Maintenance','2020-02-04','10:57 AM',197),
('129','Logout','System Maintenance','2020-02-04','10:57 AM',198),
('129','Login','System Maintenance','2020-02-04','10:58 AM',199),
('129','Logout','System Maintenance','2020-02-04','10:58 AM',200),
('131','Login','Janitor','2020-02-04','10:58 AM',201),
('131','Logout','Janitor','2020-02-04','10:58 AM',202),
('129','Login','System Maintenance','2020-02-04','10:58 AM',203),
('129','Delete User Previledge','Manager','2020-02-04','10:59 AM',204),
('129','Add User Type','Manager','2020-02-04','10:59 AM',205),
('129','Add User','Ugking Norhana Mamaluba As Manager','2020-02-04','11:01 AM',206),
('129','Logout','System Maintenance','2020-02-04','11:01 AM',207),
('138','Login','Manager','2020-02-04','11:01 AM',208),
('138','Update User Previledge','Manager','2020-02-04','11:01 AM',209),
('138','Logout','Manager','2020-02-04','11:01 AM',210),
('138','Login','Manager','2020-02-04','11:01 AM',211),
('138','Logout','Manager','2020-02-04','11:02 AM',212),
('129','Login','System Maintenance','2020-02-04','11:02 AM',213),
('129','Add Borrower','Qwe Qwe Qwe','2020-02-04','11:03 AM',214),
('129','Add Attachment','Qwe Qwe Qwe','2020-02-04','11:03 AM',215),
('129','Set Max loan','Qwe Qwe Qwe','2020-02-04','11:04 AM',216),
('129','Borrow Transaction','Qwe Qwe Qwe Borrow 1000','2020-02-04','11:06 AM',217),
('129','View Borrower Reports','System Maintenance','2020-02-04','11:06 AM',218),
('129','View Account Reports','System Maintenance','2020-02-04','11:06 AM',219),
('129','View Master List Reports','System Maintenance','2020-02-04','11:07 AM',220),
('129','View Activity Log','System Maintenance','2020-02-04','11:09 AM',221),
('129','Logout','System Maintenance','2020-02-04','11:10 AM',222),
('129','Login','System Maintenance','2020-02-04','11:11 AM',223),
('129','View Activity Log','System Maintenance','2020-02-04','11:11 AM',224),
('129','Add User Type','Atabs','2020-02-04','11:13 AM',225),
('129','Add User','Lore Lexi Khalifa As Atabs','2020-02-04','11:14 AM',226),
('129','Logout','System Maintenance','2020-02-04','11:14 AM',227),
('139','Login','Atabs','2020-02-04','11:15 AM',228),
('139','Logout','Atabs','2020-02-04','11:15 AM',229),
('129','Login','System Maintenance','2020-02-04','11:15 AM',230),
('129','Update User Previledge','Atabs','2020-02-04','11:16 AM',231),
('129','Logout','System Maintenance','2020-02-04','11:16 AM',232),
('139','Login','Atabs','2020-02-04','11:16 AM',233),
('139','View Activity Log','Atabs','2020-02-04','11:16 AM',234),
('139','Logout','Atabs','2020-02-04','11:17 AM',235),
('129','Login','System Maintenance','2020-02-04','11:17 AM',236),
('129','Logout','System Maintenance','2020-02-04','11:17 AM',237),
('129','Login','System Maintenance','2020-02-04','11:17 AM',238),
('129','Update User Previledge','System Maintenance','2020-02-04','11:18 AM',239),
('129','Logout','System Maintenance','2020-02-04','11:18 AM',240),
('129','Login','System Maintenance','2020-02-04','11:18 AM',241),
('129','Add User Type','Ceo','2020-02-04','11:19 AM',242),
('129','Add User','Marcos Jacob Yanga As Ceo','2020-02-04','11:21 AM',243),
('129','Deactivate User','Marcos Jacob Yanga','2020-02-04','11:21 AM',244),
('129','Activate User','Marcos Jacob Yanga','2020-02-04','11:21 AM',245),
('129','Logout','System Maintenance','2020-02-04','11:21 AM',246),
('140','Login','Ceo','2020-02-04','11:22 AM',247),
('140','Add Attachment','Qwe Qwe Qwe','2020-02-04','11:23 AM',248),
('140','Update Emergency Loan','Interest is update to 10%','2020-02-04','11:25 AM',249),
('140','Borrow Transaction','Qwe Qwe Qwe Borrow 1000','2020-02-04','11:26 AM',250),
('140','View Account Reports','Ceo','2020-02-04','11:27 AM',251),
('140','Logout','Ceo','2020-02-04','11:32 AM',252),
('129','Login','System Maintenance','2020-02-04','11:34 AM',253),
('129','Update User Previledge','System Maintenance','2020-02-04','11:35 AM',254),
('129','Logout','System Maintenance','2020-02-04','11:35 AM',255),
('129','Login','System Maintenance','2020-02-04','11:35 AM',256),
('129','View Account Reports','System Maintenance','2020-02-04','11:35 AM',257),
('129','Add Borrower','Aromin Daniel Troy Davad','2020-02-04','11:40 AM',258),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-04','11:41 AM',259),
('129','Delete Attachment','Aromin Daniel Troy Davad','2020-02-04','11:41 AM',260),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-04','11:42 AM',261),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-04','11:42 AM',262),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-04','11:42 AM',263),
('129','Logout','System Maintenance','2020-02-04','11:43 AM',264),
('129','Login','System Maintenance','2020-02-04','11:44 AM',265),
('129','Add User Type','Kanor','2020-02-04','11:46 AM',266),
('129','Add User','Kanor Kanor Kanor As Kanor','2020-02-04','11:47 AM',267),
('129','Logout','System Maintenance','2020-02-04','11:47 AM',268),
('141','Login','Kanor','2020-02-04','11:47 AM',269),
('141','View Borrower Reports','Kanor','2020-02-04','11:48 AM',270),
('141','View Account Reports','Kanor','2020-02-04','11:48 AM',271),
('141','View Activity Log','Kanor','2020-02-04','11:49 AM',272),
('129','Login','System Maintenance','2020-02-04','11:53 AM',273),
('129','Login','System Maintenance','2020-02-04','12:54 PM',274),
('129','Logout','System Maintenance','2020-02-04','1:06 PM',275),
('129','Login','System Maintenance','2020-02-04','1:08 PM',276),
('129','Add User Type','Blocker','2020-02-04','1:09 PM',277),
('129','Add User','Malaza Jinno Masarap As Blocker','2020-02-04','1:12 PM',278),
('129','Logout','System Maintenance','2020-02-04','1:12 PM',279),
('142','Login','Blocker','2020-02-04','1:12 PM',280),
('142','Logout','Blocker','2020-02-04','1:13 PM',281),
('129','Login','System Maintenance','2020-02-04','1:13 PM',282),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','1:14 PM',283),
('129','View Activity Log','System Maintenance','2020-02-04','1:14 PM',284),
('129','View Account Reports','System Maintenance','2020-02-04','1:15 PM',285),
('129','View Account Reports','System Maintenance','2020-02-04','1:17 PM',286),
('129','Logout','System Maintenance','2020-02-04','1:18 PM',287),
('129','Login','System Maintenance','2020-02-04','1:18 PM',288),
('129','Logout','System Maintenance','2020-02-04','1:19 PM',289),
('129','Login','System Maintenance','2020-02-04','1:19 PM',290),
('129','Add User Type','Fluffer','2020-02-04','1:20 PM',291),
('129','Add User','Ausa Carlo Bading As Fluffer','2020-02-04','1:22 PM',292),
('129','Logout','System Maintenance','2020-02-04','1:22 PM',293),
('143','Login','Fluffer','2020-02-04','1:22 PM',294),
('143','Logout','Fluffer','2020-02-04','1:22 PM',295),
('129','Login','System Maintenance','2020-02-04','1:22 PM',296),
('129','Update User Previledge','Fluffer','2020-02-04','1:22 PM',297),
('129','Logout','System Maintenance','2020-02-04','1:22 PM',298),
('143','Login','Fluffer','2020-02-04','1:23 PM',299),
('143','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','1:24 PM',300),
('143','View Activity Log','Fluffer','2020-02-04','1:25 PM',301),
('143','View Account Reports','Fluffer','2020-02-04','1:25 PM',302),
('143','Logout','Fluffer','2020-02-04','1:27 PM',303),
('129','Login','System Maintenance','2020-02-04','1:27 PM',304),
('129','Update Emergency Loan','Interest is update to 20%','2020-02-04','1:28 PM',305),
('129','Logout','System Maintenance','2020-02-04','1:28 PM',306),
('129','Login','System Maintenance','2020-02-04','1:31 PM',307),
('129','Add User Type','Shooting G','2020-02-04','1:32 PM',308),
('129','Add User','Sularan Vencent Paul Caadan As Shooting G','2020-02-04','1:34 PM',309),
('129','Deactivate User','Sularan Vencent Paul Caadan','2020-02-04','1:34 PM',310),
('129','Activate User','Sularan Vencent Paul Caadan','2020-02-04','1:34 PM',311),
('129','Logout','System Maintenance','2020-02-04','1:35 PM',312),
('144','Login','Shooting G','2020-02-04','1:35 PM',313),
('144','Logout','Shooting G','2020-02-04','1:36 PM',314),
('129','Login','System Maintenance','2020-02-04','1:36 PM',315),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','1:38 PM',316),
('129','View Activity Log','System Maintenance','2020-02-04','1:38 PM',317),
('129','View Borrower Reports','System Maintenance','2020-02-04','1:39 PM',318),
('129','Update Emergency Loan','Interest is update to 10%','2020-02-04','1:42 PM',319),
('129','Add Attachment','Delos Santos Mack Jaygee Grande','2020-02-04','1:43 PM',320),
('129','Update Personal Loan','Min Term is update to 1','2020-02-04','1:44 PM',321),
('129','Logout','System Maintenance','2020-02-04','1:45 PM',322),
('129','Login','System Maintenance','2020-02-04','1:45 PM',323),
('129','Add User Type','Power Forward','2020-02-04','1:47 PM',324),
('129','Add User','Brylle Berdico Berere As Power Forward','2020-02-04','1:49 PM',325),
('129','Logout','System Maintenance','2020-02-04','1:49 PM',326),
('145','Login','Power Forward','2020-02-04','1:49 PM',327),
('145','Logout','Power Forward','2020-02-04','1:50 PM',328),
('129','Login','System Maintenance','2020-02-04','1:50 PM',329),
('129','Deactivate User','Brylle Berdico Berere','2020-02-04','1:50 PM',330),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','1:53 PM',331),
('129','View Activity Log','System Maintenance','2020-02-04','1:53 PM',332),
('129','View Borrower Reports','System Maintenance','2020-02-04','1:54 PM',333),
('129','View Account Reports','System Maintenance','2020-02-04','1:55 PM',334),
('129','Logout','System Maintenance','2020-02-04','1:58 PM',335),
('129','Login','System Maintenance','2020-02-04','1:58 PM',336),
('129','Add User Type','Accountant','2020-02-04','1:59 PM',337),
('129','Logout','System Maintenance','2020-02-04','2:00 PM',338),
('129','Login','System Maintenance','2020-02-04','2:01 PM',339),
('129','Add User Type','Center','2020-02-04','2:02 PM',340),
('129','Update User Previledge','Center','2020-02-04','2:02 PM',341),
('129','Update User Previledge','Center','2020-02-04','2:02 PM',342),
('129','Add User','Geraldo Pogi Gwapo As Center','2020-02-04','2:05 PM',343),
('129','Update User Information','Geraldo Pogi Gwapo','2020-02-04','2:06 PM',344),
('129','Logout','System Maintenance','2020-02-04','2:06 PM',345),
('146','Login','Center','2020-02-04','2:07 PM',346),
('146','Logout','Center','2020-02-04','2:08 PM',347),
('129','Login','System Maintenance','2020-02-04','2:08 PM',348),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','2:10 PM',349),
('129','View Activity Log','System Maintenance','2020-02-04','2:10 PM',350),
('129','View Borrower Reports','System Maintenance','2020-02-04','2:11 PM',351),
('129','View Account Reports','System Maintenance','2020-02-04','2:12 PM',352),
('129','Logout','System Maintenance','2020-02-04','2:15 PM',353),
('129','Login','System Maintenance','2020-02-04','2:27 PM',354),
('129','Add User Type','Supervisor','2020-02-04','2:28 PM',355),
('129','Add User','Smith Jeff Hunt As Supervisor','2020-02-04','2:31 PM',356),
('129','Deactivate User','Smith Jeff Hunt','2020-02-04','2:32 PM',357),
('129','Activate User','Smith Jeff Hunt','2020-02-04','2:32 PM',358),
('129','Logout','System Maintenance','2020-02-04','2:32 PM',359),
('147','Login','Supervisor','2020-02-04','2:33 PM',360),
('147','Logout','Supervisor','2020-02-04','2:33 PM',361),
('129','Login','System Maintenance','2020-02-04','2:33 PM',362),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','2:37 PM',363),
('129','View Activity Log','System Maintenance','2020-02-04','2:38 PM',364),
('129','View Borrower Reports','System Maintenance','2020-02-04','2:39 PM',365),
('129','View Borrower Reports','System Maintenance','2020-02-04','2:39 PM',366),
('129','View Account Reports','System Maintenance','2020-02-04','2:41 PM',367),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-04','2:43 PM',368),
('129','Logout','System Maintenance','2020-02-04','2:46 PM',369),
('129','Login','System Maintenance','2020-02-04','3:01 PM',370),
('129','Add User Type','Guard','2020-02-04','3:02 PM',371),
('129','Add User','Namocatcat Jayrald Robas As Guard','2020-02-04','3:04 PM',372),
('129','Deactivate User','Namocatcat Jayrald Robas','2020-02-04','3:04 PM',373),
('129','Activate User','Namocatcat Jayrald Robas','2020-02-04','3:04 PM',374),
('129','Logout','System Maintenance','2020-02-04','3:04 PM',375),
('148','Login','Guard','2020-02-04','3:05 PM',376),
('148','Logout','Guard','2020-02-04','3:05 PM',377),
('129','Login','System Maintenance','2020-02-04','3:05 PM',378),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','3:09 PM',379),
('129','Update Emergency Loan','','2020-02-04','3:10 PM',380),
('129','View Activity Log','System Maintenance','2020-02-04','3:10 PM',381),
('129','View Borrower Reports','System Maintenance','2020-02-04','3:11 PM',382),
('129','View Account Reports','System Maintenance','2020-02-04','3:12 PM',383),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-04','3:14 PM',384),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-04','3:16 PM',385),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-04','3:19 PM',386),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-04','3:20 PM',387),
('129','Logout','System Maintenance','2020-02-04','3:27 PM',388),
('129','Login','System Maintenance','2020-02-04','3:28 PM',389),
('129','Add User Type','Mechanic','2020-02-04','3:30 PM',390),
('129','Update User Previledge','Mechanic','2020-02-04','3:30 PM',391),
('129','Add User','Fajardo Ronel Cajocson As Mechanic','2020-02-04','3:33 PM',392),
('129','Deactivate User','Fajardo Ronel Cajocson','2020-02-04','3:33 PM',393),
('129','Activate User','Fajardo Ronel Cajocson','2020-02-04','3:34 PM',394),
('129','Logout','System Maintenance','2020-02-04','3:34 PM',395),
('149','Login','Mechanic','2020-02-04','3:34 PM',396),
('149','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','3:37 PM',397),
('149','Logout','Mechanic','2020-02-04','3:37 PM',398),
('129','Login','System Maintenance','2020-02-04','3:37 PM',399),
('129','View Activity Log','System Maintenance','2020-02-04','3:37 PM',400),
('129','View Borrower Reports','System Maintenance','2020-02-04','3:38 PM',401),
('129','View Account Reports','System Maintenance','2020-02-04','3:39 PM',402),
('129','Logout','System Maintenance','2020-02-04','3:42 PM',403),
('129','Login','System Maintenance','2020-02-04','3:48 PM',404),
('129','Update User Previledge','Manager','2020-02-04','3:50 PM',405),
('129','Add User','Rique Charlene Coderis As Manager','2020-02-04','3:52 PM',406),
('129','Logout','System Maintenance','2020-02-04','3:52 PM',407),
('150','Login','Manager','2020-02-04','3:52 PM',408),
('150','Logout','Manager','2020-02-04','3:53 PM',409),
('129','Login','System Maintenance','2020-02-04','3:53 PM',410),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','3:57 PM',411),
('129','View Activity Log','System Maintenance','2020-02-04','3:57 PM',412),
('129','View Borrower Reports','System Maintenance','2020-02-04','3:58 PM',413),
('129','View Account Reports','System Maintenance','2020-02-04','3:59 PM',414),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-04','4:01 PM',415),
('129','Update Emergency Loan','Interest is update to 20%','2020-02-04','4:04 PM',416),
('129','Update Emergency Loan','Min Term is update to 2','2020-02-04','4:05 PM',417),
('129','Logout','System Maintenance','2020-02-04','4:05 PM',418),
('129','Login','System Maintenance','2020-02-04','4:06 PM',419),
('129','Add User Type','Pg','2020-02-04','4:08 PM',420),
('129','Add User','Almero Kenneth Mas As Pg','2020-02-04','4:09 PM',421),
('129','Deactivate User','Almero Kenneth Mas','2020-02-04','4:10 PM',422),
('129','Activate User','Almero Kenneth Mas','2020-02-04','4:10 PM',423),
('129','Logout','System Maintenance','2020-02-04','4:10 PM',424),
('151','Login','Pg','2020-02-04','4:11 PM',425),
('151','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','4:15 PM',426),
('151','View Activity Log','Pg','2020-02-04','4:15 PM',427),
('151','View Borrower Reports','Pg','2020-02-04','4:16 PM',428),
('151','Logout','Pg','2020-02-04','4:17 PM',429),
('129','Login','System Maintenance','2020-02-04','4:17 PM',430),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-04','4:17 PM',431),
('129','Update Emergency Loan','Interest is update to 1%','2020-02-04','4:19 PM',432),
('129','Logout','System Maintenance','2020-02-04','4:26 PM',433),
('129','Login','System Maintenance','2020-02-04','4:26 PM',434),
('129','Add User Type','Mage','2020-02-04','4:28 PM',435),
('129','Add User','Isipbata Kimbiebie Toyo As Mage','2020-02-04','4:31 PM',436),
('129','Logout','System Maintenance','2020-02-04','4:31 PM',437),
('152','Login','Mage','2020-02-04','4:32 PM',438),
('152','Logout','Mage','2020-02-04','4:32 PM',439),
('129','Login','System Maintenance','2020-02-04','4:32 PM',440),
('129','Update Emergency Loan','Interest is update to 100%','2020-02-04','4:34 PM',441),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-04','4:35 PM',442),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-04','4:36 PM',443),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-04','4:37 PM',444),
('129','View Activity Log','System Maintenance','2020-02-04','4:38 PM',445),
('129','View Borrower Reports','System Maintenance','2020-02-04','4:38 PM',446),
('129','View Account Reports','System Maintenance','2020-02-04','4:40 PM',447);
/*!40000 ALTER TABLE `activitylog` ENABLE KEYS */;

-- 
-- Definition of attachment_tbl
-- 

DROP TABLE IF EXISTS `attachment_tbl`;
CREATE TABLE IF NOT EXISTS `attachment_tbl` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `A_type` varchar(50) NOT NULL,
  `F_type` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table attachment_tbl
-- 

/*!40000 ALTER TABLE `attachment_tbl` DISABLE KEYS */;
INSERT INTO `attachment_tbl`(`ID`,`A_type`,`F_type`) VALUES
(2,'Requirements','Image'),
(4,'Birth Certificate','Image'),
(8,'Collateral',''),
(9,'NBI','');
/*!40000 ALTER TABLE `attachment_tbl` ENABLE KEYS */;

-- 
-- Definition of attachments
-- 

DROP TABLE IF EXISTS `attachments`;
CREATE TABLE IF NOT EXISTS `attachments` (
  `No` int(10) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `filename` varchar(200) DEFAULT NULL,
  `comment` varchar(500) DEFAULT NULL,
  `id` int(10) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table attachments
-- 

/*!40000 ALTER TABLE `attachments` DISABLE KEYS */;
INSERT INTO `attachments`(`No`,`description`,`filename`,`comment`,`id`) VALUES
(10078,'Requirements','C:*Users*HP*Desktop*requirements*download (3).jpg','',2),
(10079,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',3),
(10079,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',4),
(10078,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',5),
(10078,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',6),
(10080,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',7),
(10081,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',8),
(10082,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',9),
(10083,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',10),
(10084,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',11),
(10084,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',12),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',14),
(10078,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',15),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',16),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',17),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',18);
/*!40000 ALTER TABLE `attachments` ENABLE KEYS */;

-- 
-- Definition of borrower_deduction
-- 

DROP TABLE IF EXISTS `borrower_deduction`;
CREATE TABLE IF NOT EXISTS `borrower_deduction` (
  `ID` int(10) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `amount` varchar(50) DEFAULT NULL,
  `description` varchar(50) DEFAULT NULL,
  `no` int(10) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table borrower_deduction
-- 

/*!40000 ALTER TABLE `borrower_deduction` DISABLE KEYS */;

/*!40000 ALTER TABLE `borrower_deduction` ENABLE KEYS */;

-- 
-- Definition of comakerinfo
-- 

DROP TABLE IF EXISTS `comakerinfo`;
CREATE TABLE IF NOT EXISTS `comakerinfo` (
  `No` int(10) NOT NULL,
  `LastName` varchar(50) NOT NULL DEFAULT '''',
  `FirstName` varchar(50) NOT NULL DEFAULT '''',
  `MiddleName` varchar(50) NOT NULL DEFAULT '''',
  `Address` varchar(50) NOT NULL DEFAULT '''',
  `Birthday` varchar(50) NOT NULL DEFAULT '''',
  `Gender` varchar(50) NOT NULL DEFAULT '''',
  `EmailAddress` varchar(50) NOT NULL DEFAULT '''',
  `PhoneNumber` varchar(50) NOT NULL DEFAULT '''',
  `CompanyName` varchar(50) NOT NULL DEFAULT '''',
  `Ocupation` varchar(50) NOT NULL DEFAULT '''',
  `ProfilePic` varchar(100) NOT NULL DEFAULT '''',
  `Signiture` varchar(100) NOT NULL,
  `salary` varchar(50) NOT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table comakerinfo
-- 

/*!40000 ALTER TABLE `comakerinfo` DISABLE KEYS */;

/*!40000 ALTER TABLE `comakerinfo` ENABLE KEYS */;

-- 
-- Definition of customerinfo
-- 

DROP TABLE IF EXISTS `customerinfo`;
CREATE TABLE IF NOT EXISTS `customerinfo` (
  `No` int(10) NOT NULL,
  `LastName` varchar(50) NOT NULL DEFAULT '''',
  `FirstName` varchar(50) NOT NULL DEFAULT '''',
  `MiddleName` varchar(50) NOT NULL DEFAULT '''',
  `Address` varchar(50) NOT NULL DEFAULT '''',
  `Birthday` varchar(50) NOT NULL DEFAULT '''',
  `Gender` varchar(50) NOT NULL DEFAULT '''',
  `EmailAddress` varchar(50) NOT NULL DEFAULT '''',
  `PhoneNumber` varchar(50) NOT NULL DEFAULT '''',
  `CompanyName` varchar(50) NOT NULL DEFAULT '''',
  `Ocupation` varchar(50) NOT NULL DEFAULT '''',
  `Comaker` int(10) NOT NULL,
  `ProfilePic` varchar(100) NOT NULL DEFAULT '''',
  `Signiture` varchar(100) NOT NULL,
  `Processby` int(10) NOT NULL,
  `processdate` varchar(50) NOT NULL,
  `salary` varchar(50) NOT NULL,
  `maxloan_p` varchar(50) NOT NULL,
  `approved_p` int(1) NOT NULL,
  `approved_e` int(1) NOT NULL,
  `maxloan_e` varchar(50) NOT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table customerinfo
-- 

/*!40000 ALTER TABLE `customerinfo` DISABLE KEYS */;
INSERT INTO `customerinfo`(`No`,`LastName`,`FirstName`,`MiddleName`,`Address`,`Birthday`,`Gender`,`EmailAddress`,`PhoneNumber`,`CompanyName`,`Ocupation`,`Comaker`,`ProfilePic`,`Signiture`,`Processby`,`processdate`,`salary`,`maxloan_p`,`approved_p`,`approved_e`,`maxloan_e`) VALUES
(10078,'Delos Santos','Mack Jaygee','Grande','Bulacan','Friday, January 12, 2001','Male','dmackjaygee@gmail.com','09123812983','Apple','Janitor',0,'C:*Users*HP*Desktop*requirements*download (3).jpg','C:*Users*HP*Desktop*requirements*download (3).jpg',129,'2020-01-12 12:23:41 PM','8000','0',0,0,'0'),
(10079,'Modrigo','Joyce Ann','S','Sjdm Bulcan','Wednesday, February 4, 1998','Female','dmackjasd@gmail.com','09812187182','Sti','Student',0,'C:*Users*HP*Pictures*2012-03*DSCF0416.JPG','C:*Users*HP*Pictures*2012-03*DSCF0417.JPG',129,'2020-02-04 9:08:12 AM','10000','0',0,1,'1000'),
(10080,'Agustino','Arjay','','Maligaya','Sunday, February 4, 2001','Male','agustino.arjay@gm.com','09381002796','Sti','Student',0,'C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',129,'2020-02-04 9:52:09 AM','10000','0',0,1,'1000'),
(10081,'Lunzaga','Jeremiah','Valdesotto','Mars','Sunday, February 4, 2001','Female','jeremiahlunzaga@yahoo.com','09472526272','JVP','Programmer',0,'C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',129,'2020-02-04 10:00:57 AM','10000','0',0,1,'1000'),
(10082,'Bisnan','Joan','Lopez','Bulacan','Sunday, February 4, 2001','Female','bisnan@gm.com','09123871628','Sti','Student',0,'C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',129,'2020-02-04 10:14:59 AM','100000','0',0,1,'1000'),
(10083,'Mack','Mack','Mack','Bulacan','Sunday, February 4, 2001','Female','mack@gmail.com','09123123871','Sti','Student',0,'C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',129,'2020-02-04 10:33:09 AM','100000','0',0,1,'1000'),
(10084,'Qwe','Qwe','Qwe','Qwe','Sunday, February 4, 2001','Male','qwe@gm.com','12312312312','Sti','Student',0,'C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',129,'2020-02-04 11:03:21 AM','10000','0',0,1,'1000'),
(10085,'Aromin','Daniel Troy','Davad','Saint Mary','Thursday, March 1, 2001','Male','ysajsaj@gmail.com','29138748728','Bascocompany','None',0,'C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',129,'2020-02-04 11:40:22 AM','7772727','0',0,1,'1000');
/*!40000 ALTER TABLE `customerinfo` ENABLE KEYS */;

-- 
-- Definition of customersched
-- 

DROP TABLE IF EXISTS `customersched`;
CREATE TABLE IF NOT EXISTS `customersched` (
  `No` int(10) NOT NULL,
  `per` int(10) NOT NULL,
  `acctno` int(10) NOT NULL,
  `date` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table customersched
-- 

/*!40000 ALTER TABLE `customersched` DISABLE KEYS */;

/*!40000 ALTER TABLE `customersched` ENABLE KEYS */;

-- 
-- Definition of deduction_tbl
-- 

DROP TABLE IF EXISTS `deduction_tbl`;
CREATE TABLE IF NOT EXISTS `deduction_tbl` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) DEFAULT NULL,
  `comment` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table deduction_tbl
-- 

/*!40000 ALTER TABLE `deduction_tbl` DISABLE KEYS */;
INSERT INTO `deduction_tbl`(`id`,`type`,`comment`) VALUES
(3,'Pagibig','qweqwe');
/*!40000 ALTER TABLE `deduction_tbl` ENABLE KEYS */;

-- 
-- Definition of emergencyloan
-- 

DROP TABLE IF EXISTS `emergencyloan`;
CREATE TABLE IF NOT EXISTS `emergencyloan` (
  `No` int(10) NOT NULL,
  `Percent` double(20,2) NOT NULL,
  `Frequency` varchar(50) NOT NULL,
  `Term` varchar(50) NOT NULL,
  `WeeklyInterest` double(20,2) NOT NULL,
  `TotalInterest` double(20,2) NOT NULL,
  `TotalPayment` double(20,2) NOT NULL,
  `DueDate` varchar(50) NOT NULL,
  `Accid` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table emergencyloan
-- 

/*!40000 ALTER TABLE `emergencyloan` DISABLE KEYS */;
INSERT INTO `emergencyloan`(`No`,`Percent`,`Frequency`,`Term`,`WeeklyInterest`,`TotalInterest`,`TotalPayment`,`DueDate`,`Accid`) VALUES
(10080,1,'Weekly','4 Weeks',10,40,1040,'Tuesday, March 3, 2020',0),
(10081,1,'Weekly','4 Weeks',10,40,1040,'Tuesday, March 3, 2020',0),
(10082,1,'Weekly','4 Weeks',10,40,1040,'Tuesday, March 3, 2020',0),
(10083,1,'Weekly','4 Weeks',10,40,1040,'Tuesday, March 3, 2020',0),
(10083,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',1),
(10083,20,'Weekly','4 Weeks',200,800,1800,'Tuesday, March 3, 2020',2),
(10084,20,'Weekly','4 Weeks',200,800,1800,'Tuesday, March 3, 2020',0),
(10084,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',1),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',0),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',1),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',2),
(10085,20,'Weekly','4 Weeks',200,800,1800,'Tuesday, March 3, 2020',3),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',4),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',5),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',6),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',7),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',8),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Tuesday, March 3, 2020',9),
(10085,20,'Weekly','4 Weeks',200,800,1800,'Tuesday, March 3, 2020',10),
(10085,100,'Weekly','2 Weeks',1000,2000,3000,'Tuesday, February 18, 2020',11);
/*!40000 ALTER TABLE `emergencyloan` ENABLE KEYS */;

-- 
-- Definition of gmaxloanmaintenance
-- 

DROP TABLE IF EXISTS `gmaxloanmaintenance`;
CREATE TABLE IF NOT EXISTS `gmaxloanmaintenance` (
  `salary` double(10,2) DEFAULT NULL,
  `range` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table gmaxloanmaintenance
-- 

/*!40000 ALTER TABLE `gmaxloanmaintenance` DISABLE KEYS */;

/*!40000 ALTER TABLE `gmaxloanmaintenance` ENABLE KEYS */;

-- 
-- Definition of loan
-- 

DROP TABLE IF EXISTS `loan`;
CREATE TABLE IF NOT EXISTS `loan` (
  `No` int(10) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `BorrowedMoney` double(20,2) NOT NULL,
  `Accid` int(10) NOT NULL,
  `Processby` int(10) NOT NULL,
  `LendDate` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table loan
-- 

/*!40000 ALTER TABLE `loan` DISABLE KEYS */;
INSERT INTO `loan`(`No`,`Type`,`BorrowedMoney`,`Accid`,`Processby`,`LendDate`) VALUES
(10080,'Emergency Loan',1000,0,129,'Tuesday, February 4, 2020'),
(10081,'Emergency Loan',1000,0,129,'Tuesday, February 4, 2020'),
(10082,'Emergency Loan',1000,0,129,'Tuesday, February 4, 2020'),
(10083,'Emergency Loan',1000,0,129,'Tuesday, February 4, 2020'),
(10083,'Emergency Loan',1000,1,129,'Tuesday, February 4, 2020'),
(10083,'Emergency Loan',1000,2,129,'Tuesday, February 4, 2020'),
(10084,'Emergency Loan',1000,0,129,'Tuesday, February 4, 2020'),
(10084,'Emergency Loan',1000,1,140,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,0,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,1,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,2,143,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,3,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,4,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,5,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,6,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,7,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,8,149,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,9,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,10,151,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,11,129,'Tuesday, February 4, 2020');
/*!40000 ALTER TABLE `loan` ENABLE KEYS */;

-- 
-- Definition of loanmaintenance
-- 

DROP TABLE IF EXISTS `loanmaintenance`;
CREATE TABLE IF NOT EXISTS `loanmaintenance` (
  `pinterest` varchar(50) NOT NULL,
  `pminamount` varchar(50) NOT NULL,
  `pminterm` varchar(50) NOT NULL,
  `pmaxterm` varchar(50) NOT NULL,
  `ginterest` varchar(50) NOT NULL,
  `gminamount` varchar(50) NOT NULL,
  `gminterm` varchar(50) NOT NULL,
  `gmaxterm` varchar(50) NOT NULL,
  `ppenalty` varchar(50) NOT NULL,
  `pdaypenalty` varchar(50) NOT NULL,
  `gdaypenalty` varchar(50) NOT NULL,
  `pminsalary` varchar(50) DEFAULT NULL,
  `delinquent` double(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table loanmaintenance
-- 

/*!40000 ALTER TABLE `loanmaintenance` DISABLE KEYS */;
INSERT INTO `loanmaintenance`(`pinterest`,`pminamount`,`pminterm`,`pmaxterm`,`ginterest`,`gminamount`,`gminterm`,`gmaxterm`,`ppenalty`,`pdaypenalty`,`gdaypenalty`,`pminsalary`,`delinquent`) VALUES
('1','5000','1','12','100','1000','2','4','10','1','5','8000',20);
/*!40000 ALTER TABLE `loanmaintenance` ENABLE KEYS */;

-- 
-- Definition of payment
-- 

DROP TABLE IF EXISTS `payment`;
CREATE TABLE IF NOT EXISTS `payment` (
  `id` int(20) NOT NULL,
  `paymentsched` varchar(50) NOT NULL DEFAULT '''',
  `dateofpaid` varchar(50) NOT NULL DEFAULT '''',
  `typeofpayment` varchar(50) NOT NULL DEFAULT '''',
  `interestpayment` double(50,2) NOT NULL,
  `principalpayment` double(50,2) NOT NULL,
  `balance` double(50,2) NOT NULL,
  `penalty` double(50,2) NOT NULL,
  `acctid` int(10) NOT NULL,
  `datepenalty` varchar(50) NOT NULL,
  `processby` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table payment
-- 

/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment`(`id`,`paymentsched`,`dateofpaid`,`typeofpayment`,`interestpayment`,`principalpayment`,`balance`,`penalty`,`acctid`,`datepenalty`,`processby`) VALUES
(10083,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',40,1000,0,0,0,'Tuesday, March 3, 2020',129),
(10083,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,1,'Tuesday, March 3, 2020',129),
(10084,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',800,1000,0,0,0,'Tuesday, March 3, 2020',140),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,0,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,1,'Tuesday, March 3, 2020',143),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,2,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',800,1000,0,0,3,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,4,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,5,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,6,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,7,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,8,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',400,1000,0,0,9,'Tuesday, March 3, 2020',151),
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',800,1000,0,0,10,'Tuesday, March 3, 2020',129);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;

-- 
-- Definition of personalloan
-- 

DROP TABLE IF EXISTS `personalloan`;
CREATE TABLE IF NOT EXISTS `personalloan` (
  `No` int(10) NOT NULL,
  `Percent` double(20,2) NOT NULL,
  `Frequency` varchar(50) NOT NULL,
  `Term` varchar(50) NOT NULL,
  `MonthlyInterest` double(20,2) NOT NULL,
  `MonthlyPrincipal` double(20,2) NOT NULL,
  `TotalInterest` double(20,2) NOT NULL,
  `TotalGrandPayment` double(20,2) NOT NULL,
  `Accid` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table personalloan
-- 

/*!40000 ALTER TABLE `personalloan` DISABLE KEYS */;

/*!40000 ALTER TABLE `personalloan` ENABLE KEYS */;

-- 
-- Definition of pmaxloanmaintenance
-- 

DROP TABLE IF EXISTS `pmaxloanmaintenance`;
CREATE TABLE IF NOT EXISTS `pmaxloanmaintenance` (
  `salary` double(10,2) DEFAULT NULL,
  `range` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table pmaxloanmaintenance
-- 

/*!40000 ALTER TABLE `pmaxloanmaintenance` DISABLE KEYS */;

/*!40000 ALTER TABLE `pmaxloanmaintenance` ENABLE KEYS */;

-- 
-- Definition of revenuew
-- 

DROP TABLE IF EXISTS `revenuew`;
CREATE TABLE IF NOT EXISTS `revenuew` (
  `ID` varchar(50) NOT NULL,
  `actno` varchar(50) NOT NULL,
  `typeofpayment` varchar(50) NOT NULL,
  `interest` varchar(50) NOT NULL,
  `principal` varchar(50) NOT NULL,
  `penalty` varchar(50) NOT NULL,
  `totalpayment` varchar(50) NOT NULL,
  `processby` varchar(50) NOT NULL,
  `number` int(10) NOT NULL AUTO_INCREMENT,
  `sched` varchar(200) NOT NULL,
  `paymentdated` varchar(100) NOT NULL,
  PRIMARY KEY (`number`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table revenuew
-- 

/*!40000 ALTER TABLE `revenuew` DISABLE KEYS */;
INSERT INTO `revenuew`(`ID`,`actno`,`typeofpayment`,`interest`,`principal`,`penalty`,`totalpayment`,`processby`,`number`,`sched`,`paymentdated`) VALUES
('10083','Early Payment','1','0.00','0.00','0.00','0.00','Admin Admin A.',1,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10083','Early Payment','1','40.00','1,000.00','0.00','1,040.00','Admin Admin A.',2,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10083','Early Payment','2','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',3,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10084','Early Payment','1','800.00','1,000.00','0.00','1,800.00','Marcos Jacob Y.',4,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','1','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',5,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','2','400.00','1,000.00','0.00','1,400.00','Ausa Carlo B.',6,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','3','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',7,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','4','800.00','1,000.00','0.00','1,800.00','Admin Admin A.',8,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','5','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',9,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','6','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',10,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','7','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',11,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','8','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',12,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','9','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',13,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','10','400.00','1,000.00','0.00','1,400.00','Almero Kenneth M.',14,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','11','800.00','1,000.00','0.00','1,800.00','Admin Admin A.',15,'Tuesday, March 3, 2020','Tuesday, February 4, 2020');
/*!40000 ALTER TABLE `revenuew` ENABLE KEYS */;

-- 
-- Definition of usersettings
-- 

DROP TABLE IF EXISTS `usersettings`;
CREATE TABLE IF NOT EXISTS `usersettings` (
  `Username` varchar(10) NOT NULL DEFAULT '''',
  `Password` varchar(10) NOT NULL DEFAULT '''',
  `No` int(100) NOT NULL,
  `WP` varchar(100) NOT NULL DEFAULT '''',
  `cono` int(100) NOT NULL,
  `userlvlno` int(100) NOT NULL,
  `userno` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table usersettings
-- 

/*!40000 ALTER TABLE `usersettings` DISABLE KEYS */;
INSERT INTO `usersettings`(`Username`,`Password`,`No`,`WP`,`cono`,`userlvlno`,`userno`) VALUES
('mack','mack',10086,'''',1013,40,153);
/*!40000 ALTER TABLE `usersettings` ENABLE KEYS */;

-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(10) NOT NULL,
  `lname` varchar(50) DEFAULT NULL,
  `fname` varchar(50) DEFAULT NULL,
  `mname` varchar(50) DEFAULT NULL,
  `userlevel` varchar(50) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `profile` varchar(100) DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user`(`id`,`lname`,`fname`,`mname`,`userlevel`,`username`,`password`,`profile`,`status`) VALUES
(129,'Admin','Admin','Admin','System Maintenance','admin','admin','null',1),
(130,'Delos Santos','Mack Jaygee','Grane','Admin','mackmack','Mackmack_123','C:*Users*HP*Pictures*dolomites-mountain-range-is-located-in-the-northeast-of-italy-hd.jpg',1),
(131,'Almirol','Jershon','Grande','Janitor','almi','Almi_123','C:*Users*HP*Desktop*requirements*download (3).jpg',1),
(132,'Dayon','Kikiamotithy','Temots','Boss','temots23','Boss_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(133,'Geronimo','Nicolas','Ortega','Boss','nikolas','Nikolas1_','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(134,'Caberto','Cedric','Arellano','Player','ced123','Nuffcedd_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(135,'Mingoy','Jofel','Tumlos','Student','jofel123','Jofel_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(136,'Qwe','Qwe','Qwe','Kahitano','qwe','Qwee_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(137,'Patriico','Manuel','Zamora','Null','admin1','Admin_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(138,'Ugking','Norhana','Mamaluba','Manager','Hana','Hana_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(139,'Lore','Lexi','Khalifa','Atabs','lexilore','Lexi_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(140,'Marcos','Jacob','Yanga','Ceo','marcosjacob','MarcosJacob_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(141,'Kanor','Kanor','Kanor','Kanor','kanor','Kanor_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(142,'Malaza','Jinno','Masarap','Blocker','jinnocuti3','Jinnobebe_1','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(143,'Ausa','Carlo','Bading','Fluffer','ausakawaiidesu','meluvLM@0','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(144,'Sularan','Vencent Paul','Caadan','Shooting G','shootingguardako69','Shooting_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(145,'Brylle','Berdico','Berere','Power Forward','Breel','_aSqwe132','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',0),
(146,'Geraldo','Pogi','Gwapo','Center','geraldopogi','Qw34rt67#gwapo','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(147,'Smith','Jeff','Hunt','Supervisor','jeff.smith_hunt@gmail.com','Haha15_20','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(148,'Namocatcat','Jayrald','Robas','Guard','jay','Rald_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(149,'Fajardo','Ronel','Cajocson','Mechanic','FajardoRonel','Formula_1','C:*Users*HP*Pictures*Camera Roll*Night-Stars-Wallpaper.jpg',1),
(150,'Rique','Charlene','Coderis','Manager','charlenemae','Chacha_12345','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(151,'Almero','Kenneth','Mas','Pg','steven','Clopino_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(152,'Isipbata','Kimbiebie','Toyo','Mage','kimbie','Zaaa_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

-- 
-- Definition of userlevel
-- 

DROP TABLE IF EXISTS `userlevel`;
CREATE TABLE IF NOT EXISTS `userlevel` (
  `id` int(10) NOT NULL,
  `usertype` varchar(50) NOT NULL,
  `monitoring` varchar(3) NOT NULL,
  `borrowing` varchar(3) NOT NULL,
  `transaction` varchar(3) NOT NULL,
  `reports` varchar(3) NOT NULL,
  `lending` varchar(3) NOT NULL,
  `assets` varchar(3) NOT NULL,
  `b_r` varchar(3) NOT NULL,
  `user` varchar(3) NOT NULL,
  `a_d` varchar(3) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table userlevel
-- 

/*!40000 ALTER TABLE `userlevel` DISABLE KEYS */;
INSERT INTO `userlevel`(`id`,`usertype`,`monitoring`,`borrowing`,`transaction`,`reports`,`lending`,`assets`,`b_r`,`user`,`a_d`) VALUES
(17,'System Maintenance','yes','yes','yes','yes','yes','yes','yes','yes','yes'),
(18,'Admin','yes','yes','no','yes','yes','yes','yes','yes','yes'),
(19,'Janitor','yes','no','yes','no','no','no','yes','no','no'),
(20,'Boss','yes','no','yes','no','no','no','yes','no','no'),
(21,'Player','yes','yes','yes','yes','yes','yes','yes','yes','yes'),
(22,'Student','yes','no','yes','no','no','no','yes','no','no'),
(23,'Kahitano','no','no','yes','no','no','no','no','no','no'),
(25,'Manager','no','no','no','yes','no','no','yes','no','no'),
(26,'Atabs','yes','no','yes','yes','yes','no','yes','no','no'),
(27,'Ceo','yes','yes','yes','yes','yes','yes','yes','yes','yes'),
(28,'Kanor','yes','yes','yes','yes','yes','yes','yes','yes','yes'),
(29,'Blocker','yes','no','yes','no','no','no','yes','no','no'),
(30,'Fluffer','yes','yes','yes','yes','yes','yes','yes','yes','yes'),
(31,'Shooting G','no','no','yes','no','no','no','yes','no','no'),
(32,'Power Forward','yes','no','no','no','no','no','yes','yes','no'),
(33,'Accountant','no','yes','yes','yes','yes','no','no','no','no'),
(34,'Center','yes','no','no','no','no','no','no','no','no'),
(35,'Supervisor','yes','no','no','no','yes','no','yes','no','no'),
(36,'Guard','yes','no','no','no','yes','no','yes','no','no'),
(37,'Mechanic','no','no','yes','no','yes','no','no','yes','no'),
(38,'Pg','yes','no','yes','no','no','no','yes','no','no'),
(39,'Mage','no','no','yes','no','yes','no','no','no','no');
/*!40000 ALTER TABLE `userlevel` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2020-02-04 16:43:35
-- Total time: 0:0:0:0:219 (d:h:m:s:ms)
