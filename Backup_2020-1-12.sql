-- MySqlBackup.NET 2.3
-- Dump Time: 2020-01-12 17:36:19
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
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;

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
('129','Login','System Maintenance','2020-01-12','5:35 PM',36);
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table attachments
-- 

/*!40000 ALTER TABLE `attachments` DISABLE KEYS */;
INSERT INTO `attachments`(`No`,`description`,`filename`,`comment`,`id`) VALUES
(10078,'Requirements','C:*Users*HP*Desktop*requirements*download (3).jpg','',2);
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
(10078,'Delos Santos','Mack Jaygee','Grande','Bulacan','Friday, January 12, 2001','Male','dmackjaygee@gmail.com','09123812983','Apple','Janitor',0,'C:*Users*HP*Desktop*requirements*download (3).jpg','C:*Users*HP*Desktop*requirements*download (3).jpg',129,'2020-01-12 12:23:41 PM','8000','0',0,0,'0');
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
('1','5000','3','12','10','1000','1','4','10','1','5','8000',20);
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table revenuew
-- 

/*!40000 ALTER TABLE `revenuew` DISABLE KEYS */;

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
('mack','mack',10079,'''',1013,20,132);
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
(131,'Almirol','Jershon','Grande','Janitor','almi','Almi_123','C:*Users*HP*Desktop*requirements*download (3).jpg',1);
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
(19,'Janitor','no','no','no','no','no','no','yes','no','no');
/*!40000 ALTER TABLE `userlevel` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2020-01-12 17:36:20
-- Total time: 0:0:0:0:985 (d:h:m:s:ms)
