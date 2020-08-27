-- MySqlBackup.NET 2.3
-- Dump Time: 2020-02-05 16:01:28
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
) ENGINE=InnoDB AUTO_INCREMENT=708 DEFAULT CHARSET=latin1;

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
('129','View Account Reports','System Maintenance','2020-02-04','4:40 PM',447),
('129','Update Personal Loan','Interest is update to 3%','2020-02-04','4:44 PM',448),
('129','Login','System Maintenance','2020-02-05','8:21 AM',449),
('129','Delete User Previledge','Mage','2020-02-05','8:22 AM',450),
('129','Delete User Previledge','Pg','2020-02-05','8:22 AM',451),
('129','Delete User Previledge','Mechanic','2020-02-05','8:22 AM',452),
('129','Delete User Previledge','Guard','2020-02-05','8:22 AM',453),
('129','Delete User Previledge','Supervisor','2020-02-05','8:22 AM',454),
('129','Delete User Previledge','Center','2020-02-05','8:22 AM',455),
('129','Delete User Previledge','Accountant','2020-02-05','8:22 AM',456),
('129','Delete User Previledge','Power Forward','2020-02-05','8:23 AM',457),
('129','Delete User Previledge','Shooting G','2020-02-05','8:23 AM',458),
('129','Delete User Previledge','Fluffer','2020-02-05','8:23 AM',459),
('129','Delete User Previledge','Blocker','2020-02-05','8:23 AM',460),
('129','Delete User Previledge','Kanor','2020-02-05','8:23 AM',461),
('129','Delete User Previledge','Atabs','2020-02-05','8:23 AM',462),
('129','Delete User Previledge','Ceo','2020-02-05','8:23 AM',463),
('129','Delete User Previledge','Manager','2020-02-05','8:23 AM',464),
('129','Delete User Previledge','Kahitano','2020-02-05','8:23 AM',465),
('129','Delete User Previledge','Student','2020-02-05','8:23 AM',466),
('129','Delete User Previledge','Player','2020-02-05','8:23 AM',467),
('129','Delete User Previledge','Boss','2020-02-05','8:23 AM',468),
('129','View Master List Reports','System Maintenance','2020-02-05','8:24 AM',469),
('129','Logout','System Maintenance','2020-02-05','9:01 AM',470),
('129','Login','System Maintenance','2020-02-05','9:15 AM',471),
('129','Add User Type','Treasurer','2020-02-05','9:16 AM',472),
('129','Add User','Valdeavilla Elijah Portento As Treasurer','2020-02-05','9:18 AM',473),
('129','Deactivate User','Valdeavilla Elijah Portento','2020-02-05','9:19 AM',474),
('129','Activate User','Valdeavilla Elijah Portento','2020-02-05','9:19 AM',475),
('129','Logout','System Maintenance','2020-02-05','9:19 AM',476),
('153','Login','Treasurer','2020-02-05','9:19 AM',477),
('153','Update Emergency Loan','Interest is update to 10%','2020-02-05','9:22 AM',478),
('153','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','9:23 AM',479),
('153','Logout','Treasurer','2020-02-05','9:23 AM',480),
('129','Login','System Maintenance','2020-02-05','9:24 AM',481),
('129','View Activity Log','System Maintenance','2020-02-05','9:24 AM',482),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','9:25 AM',483),
('129','Logout','System Maintenance','2020-02-05','9:25 AM',484),
('129','Login','System Maintenance','2020-02-05','9:25 AM',485),
('129','Logout','System Maintenance','2020-02-05','9:26 AM',486),
('129','Login','System Maintenance','2020-02-05','9:27 AM',487),
('129','Delete User Previledge','Janitor','2020-02-05','9:28 AM',488),
('129','Add User Type','Janitor','2020-02-05','9:28 AM',489),
('129','Add User','Suarez Daryl Pogi As System Maintenance','2020-02-05','9:30 AM',490),
('129','Update User Information','Suarez Daryl Pogi','2020-02-05','9:31 AM',491),
('129','Logout','System Maintenance','2020-02-05','9:31 AM',492),
('154','Login','Janitor','2020-02-05','9:31 AM',493),
('154','Logout','Janitor','2020-02-05','9:32 AM',494),
('129','Login','System Maintenance','2020-02-05','9:32 AM',495),
('129','Update User Previledge','Janitor','2020-02-05','9:32 AM',496),
('129','Logout','System Maintenance','2020-02-05','9:32 AM',497),
('154','Login','Janitor','2020-02-05','9:33 AM',498),
('154','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','9:36 AM',499),
('154','View Activity Log','Janitor','2020-02-05','9:36 AM',500),
('154','Logout','Janitor','2020-02-05','9:37 AM',501),
('129','Login','System Maintenance','2020-02-05','9:37 AM',502),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','9:37 AM',503),
('129','View Borrower Reports','System Maintenance','2020-02-05','9:38 AM',504),
('129','Logout','System Maintenance','2020-02-05','9:39 AM',505),
('129','Login','System Maintenance','2020-02-05','9:39 AM',506),
('129','Add User Type','Secretary','2020-02-05','9:41 AM',507),
('129','Add User','Baculot Pakboy Monter As Secretary','2020-02-05','9:43 AM',508),
('129','Deactivate User','Baculot Pakboy Monter','2020-02-05','9:43 AM',509),
('129','Activate User','Baculot Pakboy Monter','2020-02-05','9:44 AM',510),
('129','Logout','System Maintenance','2020-02-05','9:44 AM',511),
('129','Login','System Maintenance','2020-02-05','9:45 AM',512),
('129','Logout','System Maintenance','2020-02-05','9:45 AM',513),
('155','Login','Secretary','2020-02-05','9:46 AM',514),
('155','View Activity Log','Secretary','2020-02-05','9:48 AM',515),
('155','Logout','Secretary','2020-02-05','9:48 AM',516),
('129','Login','System Maintenance','2020-02-05','9:48 AM',517),
('129','View Borrower Reports','System Maintenance','2020-02-05','9:50 AM',518),
('129','View Account Reports','System Maintenance','2020-02-05','9:50 AM',519),
('129','View Master List Reports','System Maintenance','2020-02-05','9:50 AM',520),
('129','Logout','System Maintenance','2020-02-05','9:51 AM',521),
('129','Login','System Maintenance','2020-02-05','9:55 AM',522),
('129','Add User Type','Encoder','2020-02-05','9:58 AM',523),
('129','Add User','Paculba Jefferson Deloso As System Maintenance','2020-02-05','10:02 AM',524),
('129','Deactivate User','Paculba Jefferson Deloso','2020-02-05','10:02 AM',525),
('129','Update User Information','Paculba Jefferson Deloso','2020-02-05','10:03 AM',526),
('129','Logout','System Maintenance','2020-02-05','10:03 AM',527),
('129','Login','System Maintenance','2020-02-05','10:03 AM',528),
('129','Update User Information','Paculba Jefferson Deloso','2020-02-05','10:04 AM',529),
('129','Activate User','Paculba Jefferson Deloso','2020-02-05','10:04 AM',530),
('129','Logout','System Maintenance','2020-02-05','10:04 AM',531),
('156','Login','Encoder','2020-02-05','10:04 AM',532),
('156','View Activity Log','Encoder','2020-02-05','10:05 AM',533),
('156','Logout','Encoder','2020-02-05','10:08 AM',534),
('129','Login','System Maintenance','2020-02-05','10:08 AM',535),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','10:09 AM',536),
('129','View Borrower Reports','System Maintenance','2020-02-05','10:10 AM',537),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','10:13 AM',538),
('129','Logout','System Maintenance','2020-02-05','10:14 AM',539),
('129','Login','System Maintenance','2020-02-05','10:15 AM',540),
('129','Logout','System Maintenance','2020-02-05','10:17 AM',541),
('129','Login','System Maintenance','2020-02-05','10:19 AM',542),
('129','Add User Type','Janitoorr','2020-02-05','10:21 AM',543),
('129','Add User','Awa Mack Koy As Janitoorr','2020-02-05','10:22 AM',544),
('129','Logout','System Maintenance','2020-02-05','10:23 AM',545),
('157','Login','Janitoorr','2020-02-05','10:23 AM',546),
('157','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','10:27 AM',547),
('157','View Activity Log','Janitoorr','2020-02-05','10:27 AM',548),
('157','View Borrower Reports','Janitoorr','2020-02-05','10:27 AM',549),
('157','View Account Reports','Janitoorr','2020-02-05','10:28 AM',550),
('157','View Borrower Information','Aromin Daniel Troy Davad','2020-02-05','10:29 AM',551),
('157','View Borrower Information','Aromin Daniel Troy Davad','2020-02-05','10:30 AM',552),
('157','Logout','Janitoorr','2020-02-05','10:31 AM',553),
('129','Login','System Maintenance','2020-02-05','10:36 AM',554),
('129','View Borrower Reports','System Maintenance','2020-02-05','10:38 AM',555),
('129','View Account Reports','System Maintenance','2020-02-05','10:38 AM',556),
('129','View Account Reports','System Maintenance','2020-02-05','10:38 AM',557),
('129','View Master List Reports','System Maintenance','2020-02-05','10:38 AM',558),
('129','View Master List Reports','System Maintenance','2020-02-05','10:38 AM',559),
('129','Logout','System Maintenance','2020-02-05','10:40 AM',560),
('129','Login','System Maintenance','2020-02-05','10:43 AM',561),
('129','Update User Previledge','Secretary','2020-02-05','10:44 AM',562),
('129','Add User','Mack Mack Mack As Secretary','2020-02-05','10:45 AM',563),
('129','Logout','System Maintenance','2020-02-05','10:46 AM',564),
('158','Login','Secretary','2020-02-05','10:46 AM',565),
('158','View Activity Log','Secretary','2020-02-05','10:47 AM',566),
('158','Logout','Secretary','2020-02-05','10:47 AM',567),
('129','Login','System Maintenance','2020-02-05','10:47 AM',568),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','10:49 AM',569),
('129','View Borrower Reports','System Maintenance','2020-02-05','10:50 AM',570),
('129','View Account Reports','System Maintenance','2020-02-05','10:51 AM',571),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','10:53 AM',572),
('129','Logout','System Maintenance','2020-02-05','10:55 AM',573),
('129','Login','System Maintenance','2020-02-05','11:00 AM',574),
('129','Update User Previledge','Encoder','2020-02-05','11:01 AM',575),
('129','Add User','Banuag Rocel Gamale As Secretary','2020-02-05','11:03 AM',576),
('129','Deactivate User','Banuag Rocel Gamale','2020-02-05','11:03 AM',577),
('129','Activate User','Banuag Rocel Gamale','2020-02-05','11:03 AM',578),
('129','Update User Information','Banuag Rocel Gamale','2020-02-05','11:03 AM',579),
('129','Logout','System Maintenance','2020-02-05','11:03 AM',580),
('159','Login','Secretary','2020-02-05','11:04 AM',581),
('159','View Activity Log','Secretary','2020-02-05','11:04 AM',582),
('159','Logout','Secretary','2020-02-05','11:06 AM',583),
('129','Login','System Maintenance','2020-02-05','11:06 AM',584),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','11:07 AM',585),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-05','11:08 AM',586),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','11:09 AM',587),
('129','View Activity Log','System Maintenance','2020-02-05','11:10 AM',588),
('129','View Borrower Reports','System Maintenance','2020-02-05','11:10 AM',589),
('129','View Account Reports','System Maintenance','2020-02-05','11:11 AM',590),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-05','11:12 AM',591),
('129','Logout','System Maintenance','2020-02-05','11:27 AM',592),
('129','Login','System Maintenance','2020-02-05','12:58 PM',593),
('129','Add User Type','Manager','2020-02-05','12:59 PM',594),
('129','Add User','Nicole Landa Italia As Manager','2020-02-05','1:02 PM',595),
('129','Logout','System Maintenance','2020-02-05','1:02 PM',596),
('160','Login','Manager','2020-02-05','1:02 PM',597),
('160','Logout','Manager','2020-02-05','1:03 PM',598),
('129','Login','System Maintenance','2020-02-05','1:03 PM',599),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','1:04 PM',600),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','1:06 PM',601),
('129','View Activity Log','System Maintenance','2020-02-05','1:06 PM',602),
('129','View Borrower Reports','System Maintenance','2020-02-05','1:08 PM',603),
('129','View Account Reports','System Maintenance','2020-02-05','1:10 PM',604),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-05','1:14 PM',605),
('129','Logout','System Maintenance','2020-02-05','1:16 PM',606),
('129','Login','System Maintenance','2020-02-05','1:20 PM',607),
('129','Delete User Previledge','Manager','2020-02-05','1:21 PM',608),
('129','Add User Type','Manager','2020-02-05','1:21 PM',609),
('129','Add User','Arevalo Dominic Miranda As Manager','2020-02-05','1:24 PM',610),
('129','Deactivate User','Arevalo Dominic Miranda','2020-02-05','1:24 PM',611),
('129','Logout','System Maintenance','2020-02-05','1:25 PM',612),
('129','Login','System Maintenance','2020-02-05','1:25 PM',613),
('129','Activate User','Arevalo Dominic Miranda','2020-02-05','1:26 PM',614),
('129','Logout','System Maintenance','2020-02-05','1:26 PM',615),
('161','Login','Manager','2020-02-05','1:26 PM',616),
('161','Logout','Manager','2020-02-05','1:27 PM',617),
('129','Login','System Maintenance','2020-02-05','1:27 PM',618),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','1:29 PM',619),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-05','1:30 PM',620),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','1:31 PM',621),
('129','View Borrower Reports','System Maintenance','2020-02-05','1:34 PM',622),
('129','View Account Reports','System Maintenance','2020-02-05','1:35 PM',623),
('129','View Activity Log','System Maintenance','2020-02-05','1:37 PM',624),
('129','Logout','System Maintenance','2020-02-05','1:41 PM',625),
('129','Login','System Maintenance','2020-02-05','1:41 PM',626),
('129','Delete User Previledge','Manager','2020-02-05','1:42 PM',627),
('129','Add User Type','Manager','2020-02-05','1:44 PM',628),
('129','Add User','Lagumbay Cherry Mangaron As Manager','2020-02-05','1:47 PM',629),
('129','Logout','System Maintenance','2020-02-05','1:48 PM',630),
('129','Login','System Maintenance','2020-02-05','1:49 PM',631),
('129','Logout','System Maintenance','2020-02-05','1:50 PM',632),
('162','Login','Manager','2020-02-05','1:51 PM',633),
('162','Logout','Manager','2020-02-05','1:51 PM',634),
('129','Login','System Maintenance','2020-02-05','1:52 PM',635),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','1:54 PM',636),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-05','1:56 PM',637),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','1:57 PM',638),
('129','View Activity Log','System Maintenance','2020-02-05','2:00 PM',639),
('129','View Borrower Reports','System Maintenance','2020-02-05','2:01 PM',640),
('129','View Account Reports','System Maintenance','2020-02-05','2:03 PM',641),
('129','Logout','System Maintenance','2020-02-05','2:09 PM',642),
('129','Login','System Maintenance','2020-02-05','2:09 PM',643),
('129','Update User Previledge','Manager','2020-02-05','2:11 PM',644),
('129','Add User','Bryant James Tumlos As Manager','2020-02-05','2:14 PM',645),
('129','Deactivate User','Bryant James Tumlos','2020-02-05','2:14 PM',646),
('129','Activate User','Bryant James Tumlos','2020-02-05','2:15 PM',647),
('129','Update User Information','Bryant James Tumlos','2020-02-05','2:15 PM',648),
('129','Logout','System Maintenance','2020-02-05','2:15 PM',649),
('163','Login','Manager','2020-02-05','2:15 PM',650),
('163','View Activity Log','Manager','2020-02-05','2:16 PM',651),
('163','Logout','Manager','2020-02-05','2:17 PM',652),
('129','Login','System Maintenance','2020-02-05','2:17 PM',653),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','2:19 PM',654),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-05','2:20 PM',655),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','2:23 PM',656),
('129','View Borrower Reports','System Maintenance','2020-02-05','2:24 PM',657),
('129','View Account Reports','System Maintenance','2020-02-05','2:26 PM',658),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-05','2:28 PM',659),
('129','Logout','System Maintenance','2020-02-05','2:37 PM',660),
('129','Login','System Maintenance','2020-02-05','2:38 PM',661),
('129','Delete User Previledge','Manager','2020-02-05','2:40 PM',662),
('129','Add User Type','Manager','2020-02-05','2:40 PM',663),
('129','Add User','Lorenzo Ceballos Viajedor As Manager','2020-02-05','2:44 PM',664),
('129','Logout','System Maintenance','2020-02-05','2:45 PM',665),
('164','Login','Manager','2020-02-05','2:45 PM',666),
('164','Logout','Manager','2020-02-05','2:46 PM',667),
('129','Login','System Maintenance','2020-02-05','2:46 PM',668),
('129','Deactivate User','Lorenzo Ceballos Viajedor','2020-02-05','2:46 PM',669),
('129','Activate User','Lorenzo Ceballos Viajedor','2020-02-05','2:46 PM',670),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','2:49 PM',671),
('129','Set Max loan','Aromin Daniel Troy Davad','2020-02-05','2:50 PM',672),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','2:53 PM',673),
('129','View Activity Log','System Maintenance','2020-02-05','2:55 PM',674),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-05','2:56 PM',675),
('129','View Borrower Reports','System Maintenance','2020-02-05','2:57 PM',676),
('129','Logout','System Maintenance','2020-02-05','3:26 PM',677),
('129','Login','System Maintenance','2020-02-05','3:32 PM',678),
('129','Add User','Regidor Nico Gerard Besoro As Manager','2020-02-05','3:35 PM',679),
('129','Update User Information','Regidor Nico Gerard Besoro','2020-02-05','3:36 PM',680),
('129','Deactivate User','Regidor Nico Gerard Besoro','2020-02-05','3:36 PM',681),
('129','Activate User','Regidor Nico Gerard Besoro','2020-02-05','3:36 PM',682),
('129','Logout','System Maintenance','2020-02-05','3:36 PM',683),
('129','Login','System Maintenance','2020-02-05','3:37 PM',684),
('129','Update User Information','Regidor Nico Gerard Besoro','2020-02-05','3:38 PM',685),
('129','Logout','System Maintenance','2020-02-05','3:38 PM',686),
('165','Login','Manager','2020-02-05','3:38 PM',687),
('165','Logout','Manager','2020-02-05','3:39 PM',688),
('129','Login','System Maintenance','2020-02-05','3:39 PM',689),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','3:40 PM',690),
('129','Borrow Transaction','Aromin Daniel Troy Davad Borrow 1000','2020-02-05','3:43 PM',691),
('129','View Borrower Reports','System Maintenance','2020-02-05','3:44 PM',692),
('129','View Account Reports','System Maintenance','2020-02-05','3:45 PM',693),
('129','View Borrower Information','Aromin Daniel Troy Davad','2020-02-05','3:47 PM',694),
('129','View Activity Log','System Maintenance','2020-02-05','3:48 PM',695),
('129','Logout','System Maintenance','2020-02-05','3:52 PM',696),
('129','Login','System Maintenance','2020-02-05','3:52 PM',697),
('129','Add User','Odtohan Coleen Morauda As Manager','2020-02-05','3:55 PM',698),
('129','Deactivate User','Odtohan Coleen Morauda','2020-02-05','3:56 PM',699),
('129','Activate User','Odtohan Coleen Morauda','2020-02-05','3:56 PM',700),
('129','Logout','System Maintenance','2020-02-05','3:56 PM',701),
('166','Login','Manager','2020-02-05','3:56 PM',702),
('166','Login','Manager','2020-02-05','3:58 PM',703),
('166','View Activity Log','Manager','2020-02-05','3:58 PM',704),
('166','Logout','Manager','2020-02-05','3:58 PM',705),
('129','Login','System Maintenance','2020-02-05','3:59 PM',706),
('129','Add Attachment','Aromin Daniel Troy Davad','2020-02-05','4:00 PM',707);
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
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

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
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',18),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',19),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',20),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',21),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',22),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',23),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',24),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',25),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',26),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',27),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',28),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',29),
(10085,'Requirements','C:*Users*HP*Desktop*ALTERED birth certificate.jpg','',30);
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
(10085,100,'Weekly','2 Weeks',1000,2000,3000,'Tuesday, February 18, 2020',11),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',12),
(10085,10,'Weekly','2 Weeks',100,200,1200,'Wednesday, February 19, 2020',13),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',14),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',15),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',16),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',17),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',18),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',19),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',20),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',21),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',22),
(10085,10,'Weekly','4 Weeks',100,400,1400,'Wednesday, March 4, 2020',23);
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
(10085,'Emergency Loan',1000,11,129,'Tuesday, February 4, 2020'),
(10085,'Emergency Loan',1000,12,153,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,13,154,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,14,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,15,157,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,16,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,17,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,18,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,19,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,20,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,21,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,22,129,'Wednesday, February 5, 2020'),
(10085,'Emergency Loan',1000,23,129,'Wednesday, February 5, 2020');
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
('3','5000','1','12','10','1000','2','4','10','1','5','8000',20);
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
(10085,'Tuesday, March 3, 2020','Tuesday, February 4, 2020','Early Payment',800,1000,0,0,10,'Tuesday, March 3, 2020',129),
(10085,'Tuesday, February 18, 2020','Wednesday, February 5, 2020','Early Payment',2000,1000,0,0,11,'Tuesday, February 18, 2020',153),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,12,'Wednesday, March 4, 2020',154),
(10085,'Wednesday, February 19, 2020','Wednesday, February 5, 2020','Early Payment',200,1000,0,0,13,'Wednesday, February 19, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,14,'Wednesday, March 4, 2020',157),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,15,'Wednesday, March 4, 2020',157),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,16,'Wednesday, March 4, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,17,'Wednesday, March 4, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,18,'Wednesday, March 4, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,19,'Wednesday, March 4, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,20,'Wednesday, March 4, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,21,'Wednesday, March 4, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,22,'Wednesday, March 4, 2020',129),
(10085,'Wednesday, March 4, 2020','Wednesday, February 5, 2020','Early Payment',400,1000,0,0,23,'Wednesday, March 4, 2020',129);
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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

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
('10085','Early Payment','11','800.00','1,000.00','0.00','1,800.00','Admin Admin A.',15,'Tuesday, March 3, 2020','Tuesday, February 4, 2020'),
('10085','Early Payment','12','2,000.00','1,000.00','0.00','3,000.00','Valdeavilla Elijah P.',16,'Tuesday, February 18, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','13','400.00','1,000.00','0.00','1,400.00','Suarez Daryl P.',17,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','14','200.00','1,000.00','0.00','1,200.00','Admin Admin A.',18,'Wednesday, February 19, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','15','400.00','1,000.00','0.00','1,400.00','Awa Mack K.',19,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','16','400.00','1,000.00','0.00','1,400.00','Awa Mack K.',20,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','17','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',21,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','18','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',22,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','19','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',23,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','20','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',24,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','21','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',25,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','22','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',26,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','23','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',27,'Wednesday, March 4, 2020','Wednesday, February 5, 2020'),
('10085','Early Payment','24','400.00','1,000.00','0.00','1,400.00','Admin Admin A.',28,'Wednesday, March 4, 2020','Wednesday, February 5, 2020');
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
('mack','mack',10086,'''',1013,49,167);
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
(131,'Almirol','Jershon','Grande','Null','almi','Almi_123','C:*Users*HP*Desktop*requirements*download (3).jpg',1),
(132,'Dayon','Kikiamotithy','Temots','Null','temots23','Boss_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(133,'Geronimo','Nicolas','Ortega','Null','nikolas','Nikolas1_','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(134,'Caberto','Cedric','Arellano','Null','ced123','Nuffcedd_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(135,'Mingoy','Jofel','Tumlos','Null','jofel123','Jofel_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(136,'Qwe','Qwe','Qwe','Null','qwe','Qwee_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(137,'Patriico','Manuel','Zamora','Null','admin1','Admin_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(138,'Ugking','Norhana','Mamaluba','Null','Hana','Hana_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(139,'Lore','Lexi','Khalifa','Null','lexilore','Lexi_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(140,'Marcos','Jacob','Yanga','Null','marcosjacob','MarcosJacob_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(141,'Kanor','Kanor','Kanor','Null','kanor','Kanor_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(142,'Malaza','Jinno','Masarap','Null','jinnocuti3','Jinnobebe_1','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(143,'Ausa','Carlo','Bading','Null','ausakawaiidesu','meluvLM@0','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(144,'Sularan','Vencent Paul','Caadan','Null','shootingguardako69','Shooting_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(145,'Brylle','Berdico','Berere','Null','Breel','_aSqwe132','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',0),
(146,'Geraldo','Pogi','Gwapo','Null','geraldopogi','Qw34rt67#gwapo','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(147,'Smith','Jeff','Hunt','Null','jeff.smith_hunt@gmail.com','Haha15_20','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(148,'Namocatcat','Jayrald','Robas','Null','jay','Rald_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(149,'Fajardo','Ronel','Cajocson','Null','FajardoRonel','Formula_1','C:*Users*HP*Pictures*Camera Roll*Night-Stars-Wallpaper.jpg',1),
(150,'Rique','Charlene','Coderis','Null','charlenemae','Chacha_12345','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(151,'Almero','Kenneth','Mas','Null','steven','Clopino_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(152,'Isipbata','Kimbiebie','Toyo','Null','kimbie','Zaaa_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(153,'Valdeavilla','Elijah','Portento','Treasurer','Elijah00','Elijah_00','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(154,'Suarez','Daryl','Pogi','Janitor','DarylPogi','Pangetako_69','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(155,'Baculot','Pakboy','Monter','Secretary','mrwright','Mrwight_132','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(156,'Paculba','Jefferson','Deloso','Encoder','jeff','Jeff123_2020','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(157,'Awa','Mack','Koy','Janitoorr','awa123','Awaaa_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(158,'Mack','Mack','Mack','Secretary','mackmack123','Mack_123','C:*Users*HP*Desktop*BT702P-GROUP2*school-building_23-2147521232.jpg',1),
(159,'Banuag','Rocel','Gamale','Secretary','rocel','Rocel_12','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(160,'Nicole','Landa','Italia','Null','nicole.italia2','Nicole_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(161,'Arevalo','Dominic','Miranda','Null','dominic07','Dominic_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(162,'Lagumbay','Cherry','Mangaron','Null','cherrylagumbay131','Chfygk_123','C:*Users*HP*Pictures*2012-03*DSCF0417.JPG',1),
(163,'Bryant','James','Tumlos','Null','ygtrece12','Lonerpg_1234','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(164,'Lorenzo','Ceballos','Viajedor','Manager','lpviajedor','Lpppp_123','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(165,'Regidor','Nico Gerard','Besoro','Manager','dalugs','Ilovedalugs_69','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1),
(166,'Odtohan','Coleen','Morauda','Manager','coleen21','Coleen_21','C:*Users*HP*Pictures*Camera Roll*SHAREit*98.jpg',1);
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
(40,'Treasurer','yes','no','yes','no','yes','no','no','no','no'),
(41,'Janitor','no','no','yes','yes','no','no','yes','no','no'),
(42,'Secretary','no','no','yes','no','no','no','yes','no','no'),
(43,'Encoder','no','no','yes','yes','no','no','yes','no','no'),
(44,'Janitoorr','yes','no','yes','yes','no','no','yes','no','no'),
(48,'Manager','yes','no','yes','no','no','no','yes','no','no');
/*!40000 ALTER TABLE `userlevel` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2020-02-05 16:01:28
-- Total time: 0:0:0:0:199 (d:h:m:s:ms)
