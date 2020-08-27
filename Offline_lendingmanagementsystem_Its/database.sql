/*
SQLyog - Free MySQL GUI v5.02
Host - 5.5.8 : Database - its_lendingsystem
*********************************************************************
Server version : 5.5.8
*/


create database if not exists `its_lendingsystem`;

USE `its_lendingsystem`;

/*Table structure for table `activitylog` */

DROP TABLE IF EXISTS `activitylog`;

CREATE TABLE `activitylog` (
  `userid` varchar(50) NOT NULL DEFAULT '''',
  `userprocess` varchar(50) NOT NULL DEFAULT '''',
  `userdescription` varchar(50) NOT NULL DEFAULT '''',
  `dateofprocess` varchar(50) NOT NULL,
  `timeofprocess` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `activitylog` */

insert into `activitylog` values 
('102','Login','admin','2019-09-02','11:43 PM'),
('102','Logout','admin','2019-09-02','11:43 PM'),
('107','Login','clerk','2019-09-02','11:43 PM'),
('107','Logout','clerk','2019-09-02','11:43 PM'),
('101','Login','admin','2019-09-02','11:43 PM'),
('101','Logout','admin','2019-09-02','11:44 PM'),
('107','Login','clerk','2019-09-02','11:44 PM'),
('107','Login','clerk','2019-09-02','11:45 PM'),
('102','Login','admin','2019-09-02','11:49 PM'),
('101','Login','admin','2019-09-02','11:52 PM'),
('101','Add User','Dela Cruz Macky Araojo As admin','2019-09-02','11:56 PM'),
('101','Login','admin','2019-09-03','12:11 AM'),
('101','Login','admin','2019-09-03','12:13 AM'),
('101','Login','admin','2019-09-03','12:16 AM'),
('101','Login','admin','2019-09-03','12:20 AM'),
('101','Login','admin','2019-09-03','12:21 AM'),
('101','Login','admin','2019-09-03','12:22 AM'),
('101','Login','admin','2019-09-03','12:23 AM'),
('101','Login','admin','2019-09-03','12:24 AM'),
('101','Login','admin','2019-09-03','12:25 AM'),
('101','Login','admin','2019-09-03','12:32 AM'),
('101','Login','admin','2019-09-03','12:33 AM'),
('101','Login','admin','2019-09-03','12:33 AM'),
('101','Login','admin','2019-09-03','12:34 AM'),
('101','Login','admin','2019-09-03','12:35 AM'),
('101','Login','admin','2019-09-03','12:36 AM'),
('101','Login','admin','2019-09-03','12:40 AM'),
('101','Login','admin','2019-09-03','10:27 AM'),
('101','Logout','admin','2019-09-03','10:41 AM'),
('101','Login','admin','2019-09-03','10:41 AM'),
('101','Logout','admin','2019-09-03','10:41 AM'),
('109','Login','clerk','2019-09-03','10:41 AM'),
('109','Logout','clerk','2019-09-03','10:42 AM'),
('101','Login','admin','2019-09-03','10:42 AM'),
('101','Logout','admin','2019-09-03','10:42 AM'),
('109','Login','clerk','2019-09-03','10:42 AM'),
('109','Logout','clerk','2019-09-03','10:43 AM'),
('101','Login','admin','2019-09-03','9:05 PM'),
('101','Logout','admin','2019-09-03','9:05 PM'),
('109','Login','clerk','2019-09-03','9:05 PM'),
('109','Logout','clerk','2019-09-03','9:05 PM'),
('101','Login','admin','2019-09-03','9:26 PM'),
('101','Login','admin','2019-09-03','9:27 PM'),
('101','Login','admin','2019-09-03','9:32 PM'),
('101','Login','admin','2019-09-03','9:34 PM'),
('101','Login','admin','2019-09-03','9:34 PM'),
('101','Login','admin','2019-09-03','9:36 PM'),
('101','Login','admin','2019-09-03','9:37 PM'),
('101','Login','admin','2019-09-03','9:42 PM'),
('101','Login','admin','2019-09-03','9:44 PM'),
('101','Login','admin','2019-09-03','9:48 PM'),
('101','Add Borrower','Delos Santos Mack Jaygee Villatiqui','2019-09-03','9:49 PM'),
('101','Login','admin','2019-09-03','9:53 PM'),
('101','Login','admin','2019-09-03','9:53 PM'),
('101','Login','admin','2019-09-03','9:54 PM'),
('101','Login','admin','2019-09-03','9:56 PM'),
('101','Login','admin','2019-09-03','9:56 PM'),
('101','Login','admin','2019-09-03','9:57 PM'),
('101','Login','admin','2019-09-03','10:00 PM'),
('101','Login','admin','2019-09-03','10:07 PM'),
('101','Login','admin','2019-09-03','10:09 PM'),
('101','Login','admin','2019-09-03','10:09 PM'),
('101','Login','admin','2019-09-03','10:26 PM'),
('101','Login','admin','2019-09-03','10:28 PM'),
('101','Login','admin','2019-09-03','10:30 PM'),
('101','Login','admin','2019-09-03','10:37 PM'),
('101','Login','admin','2019-09-03','10:39 PM'),
('101','Login','admin','2019-09-03','10:44 PM'),
('101','Login','admin','2019-09-03','10:44 PM'),
('101','Login','admin','2019-09-03','10:45 PM'),
('101','Login','admin','2019-09-03','10:45 PM'),
('101','Login','admin','2019-09-03','10:47 PM'),
('101','Login','admin','2019-09-03','10:48 PM'),
('101','Login','admin','2019-09-03','10:50 PM'),
('101','Login','admin','2019-09-03','10:52 PM'),
('101','Login','admin','2019-09-03','11:02 PM'),
('101','Login','admin','2019-09-03','11:04 PM'),
('101','Login','admin','2019-09-03','11:05 PM'),
('101','Login','admin','2019-09-03','11:10 PM'),
('101','Login','admin','2019-09-03','11:13 PM'),
('101','Login','admin','2019-09-03','11:13 PM'),
('101','Login','admin','2019-09-03','11:23 PM'),
('101','Login','admin','2019-09-03','11:26 PM'),
('101','Login','admin','2019-09-03','11:32 PM'),
('101','Login','admin','2019-09-03','11:35 PM'),
('101','Login','admin','2019-09-03','11:37 PM'),
('101','Login','admin','2019-09-03','11:37 PM'),
('101','Login','admin','2019-09-03','11:38 PM'),
('101','Login','admin','2019-09-03','11:53 PM'),
('101','Login','admin','2019-09-03','11:54 PM'),
('101','Login','admin','2019-09-03','11:54 PM'),
('101','Login','admin','2019-09-03','11:55 PM'),
('101','Login','admin','2019-09-04','6:54 PM'),
('101','Logout','admin','2019-09-04','6:54 PM'),
('109','Login','clerk','2019-09-04','6:54 PM'),
('109','Logout','clerk','2019-09-04','6:57 PM'),
('101','Login','admin','2019-09-04','6:57 PM'),
('101','Login','admin','2019-09-04','9:35 PM'),
('101','Login','admin','2019-09-04','9:55 PM'),
('101','Login','admin','2019-09-04','9:56 PM'),
('101','Login','admin','2019-09-04','9:58 PM'),
('101','Login','admin','2019-09-04','10:02 PM'),
('101','Login','admin','2019-09-04','10:03 PM'),
('101','Login','admin','2019-09-04','10:03 PM'),
('101','Login','admin','2019-09-04','10:05 PM'),
('101','Login','admin','2019-09-04','10:06 PM'),
('101','Login','admin','2019-09-04','10:13 PM'),
('101','Login','admin','2019-09-04','10:17 PM'),
('101','Login','admin','2019-09-04','10:18 PM'),
('101','Login','admin','2019-09-04','10:18 PM'),
('101','Login','admin','2019-09-04','10:20 PM'),
('101','Login','admin','2019-09-04','10:25 PM'),
('101','Login','admin','2019-09-04','10:33 PM'),
('101','Login','admin','2019-09-04','10:38 PM'),
('101','Login','admin','2019-09-04','10:39 PM'),
('101','Login','admin','2019-09-04','10:41 PM'),
('101','Login','admin','2019-09-04','10:52 PM'),
('101','Login','admin','2019-09-04','10:57 PM'),
('101','Login','admin','2019-09-04','11:00 PM'),
('101','Login','admin','2019-09-04','11:04 PM'),
('101','Login','admin','2019-09-04','11:06 PM'),
('101','Login','admin','2019-09-04','11:07 PM'),
('101','Login','admin','2019-09-04','11:08 PM'),
('101','Login','admin','2019-09-04','11:11 PM'),
('101','Login','admin','2019-09-04','11:17 PM'),
('101','Login','admin','2019-09-04','11:18 PM'),
('101','Login','admin','2019-09-04','11:21 PM'),
('109','Login','clerk','2019-09-04','11:26 PM'),
('109','Logout','clerk','2019-09-04','11:26 PM'),
('101','Login','admin','2019-09-04','11:28 PM'),
('101','Logout','admin','2019-09-04','11:28 PM'),
('101','Login','admin','2019-09-04','11:28 PM'),
('101','Login','admin','2019-09-04','11:30 PM'),
('101','Login','admin','2019-09-04','11:36 PM'),
('101','Login','admin','2019-09-05','12:16 AM'),
('101','Login','admin','2019-09-05','12:19 AM'),
('101','Login','admin','2019-09-05','12:21 AM'),
('101','Login','admin','2019-09-05','12:24 AM'),
('109','Login','clerk','2019-09-05','12:24 AM'),
('109','Logout','clerk','2019-09-05','12:24 AM'),
('101','Login','admin','2019-09-05','12:45 AM'),
('101','Login','admin','2019-09-05','12:51 AM'),
('101','Login','admin','2019-09-05','12:54 AM'),
('101','Login','admin','2019-09-05','1:06 AM'),
('101','Login','admin','2019-09-05','1:07 AM'),
('101','Login','admin','2019-09-05','1:15 AM'),
('101','Login','admin','2019-09-05','1:16 AM'),
('101','Login','admin','2019-09-05','1:22 AM'),
('101','Login','admin','2019-09-05','1:32 AM'),
('101','Login','admin','2019-09-05','1:37 AM'),
('101','Logout','admin','2019-09-05','1:38 AM');

/*Table structure for table `attachments` */

DROP TABLE IF EXISTS `attachments`;

CREATE TABLE `attachments` (
  `No` int(10) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `filename` varchar(200) DEFAULT NULL,
  `comment` varchar(500) DEFAULT NULL,
  `id` int(10) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `attachments` */

insert into `attachments` values 
(10001,'Collateral','C:*Users*HP*Pictures*2017072900395_0.jpg','Crush ko',3);

/*Table structure for table `comakerinfo` */

DROP TABLE IF EXISTS `comakerinfo`;

CREATE TABLE `comakerinfo` (
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

/*Data for the table `comakerinfo` */

insert into `comakerinfo` values 
(1001,'Delos Santos','Mack Jaygee','Grande','Bulacan','September 3, 2019','Male','dmackjaygee@yahoo.com','098172981','Apple','Janitor','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg','10000'),
(1002,'Delos Santos','Jericho','Grande','Bulacan','September 3, 2019','Male','dmackjaygee','123123','Sadasd','Asd','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg','1000'),
(1003,'Tan','Jenica','Gestala','Bulacan','September 3, 2019','Female','qweqkwehjwe','123138109','Ajsdkajdl','Kasjdlakdj','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg','1000');

/*Table structure for table `customerinfo` */

DROP TABLE IF EXISTS `customerinfo`;

CREATE TABLE `customerinfo` (
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
  `maxloan` varchar(50) NOT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `customerinfo` */

insert into `customerinfo` values 
(10001,'Delos Santos','Mack Jaygee','Villatiqui','Bulacan','September 3, 2019','Male','dmackjaygee@yahoo.com','019231283791','Apple','Janitor',1003,'C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg',101,'2019-09-03 9:49:01 PM','10000','10000');

/*Table structure for table `customersched` */

DROP TABLE IF EXISTS `customersched`;

CREATE TABLE `customersched` (
  `No` int(10) NOT NULL,
  `per` int(10) NOT NULL,
  `acctno` int(10) NOT NULL,
  `date` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `customersched` */

insert into `customersched` values 
(10001,4,0,'October 5, 2019'),
(10001,4,0,'November 5, 2019'),
(10001,4,0,'December 5, 2019'),
(10001,4,0,'January 5, 2020');

/*Table structure for table `emergencyloan` */

DROP TABLE IF EXISTS `emergencyloan`;

CREATE TABLE `emergencyloan` (
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

/*Data for the table `emergencyloan` */

/*Table structure for table `loan` */

DROP TABLE IF EXISTS `loan`;

CREATE TABLE `loan` (
  `No` int(10) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `BorrowedMoney` double(20,2) NOT NULL,
  `Accid` int(10) NOT NULL,
  `Processby` int(10) NOT NULL,
  `LendDate` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `loan` */

insert into `loan` values 
(10001,'Personal Loan',1000.00,0,101,'September 5, 2019');

/*Table structure for table `loanmaintenance` */

DROP TABLE IF EXISTS `loanmaintenance`;

CREATE TABLE `loanmaintenance` (
  `pinterest` varchar(50) NOT NULL,
  `pminamount` varchar(50) NOT NULL,
  `pminterm` varchar(50) NOT NULL,
  `pmaxterm` varchar(50) NOT NULL,
  `ginterest` varchar(50) NOT NULL,
  `gminamount` varchar(50) NOT NULL,
  `gminterm` varchar(50) NOT NULL,
  `gmaxterm` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `loanmaintenance` */

insert into `loanmaintenance` values 
('10.00','5000','1','12','10.00','1000','1','4');

/*Table structure for table `personalloan` */

DROP TABLE IF EXISTS `personalloan`;

CREATE TABLE `personalloan` (
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

/*Data for the table `personalloan` */

insert into `personalloan` values 
(10001,10.00,'Monthly','4 Months',500.00,500.00,2000.00,7000.00,0),
(10001,10.00,'Monthly','5 Months',100.00,100.00,500.00,1500.00,0),
(10001,10.00,'Monthly','5 Months',100.00,100.00,500.00,1500.00,1),
(10001,10.00,'Monthly','5 Months',100.00,100.00,500.00,1500.00,0),
(10001,10.00,'Monthly','10 Months',100.00,100.00,1000.00,2000.00,0),
(10001,10.00,'Monthly','4 Months',100.00,100.00,400.00,1400.00,0);

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` int(10) NOT NULL,
  `lname` varchar(50) DEFAULT NULL,
  `fname` varchar(50) DEFAULT NULL,
  `mname` varchar(50) DEFAULT NULL,
  `userlevel` varchar(50) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `profile` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `user` */

insert into `user` values 
(101,'delos santos','mack jaygee','villastiqui','admin','pass','pass','C:*Users*HP*Pictures*koy1.jpg'),
(109,'Dela Cruz','Macky','Araojo','clerk','qweqwe','qweqwe','C:*Users*HP*Pictures*29386408_1655810421165616_2834128414732976128_n.jpg');

/*Table structure for table `userlevel` */

DROP TABLE IF EXISTS `userlevel`;

CREATE TABLE `userlevel` (
  `id` int(10) NOT NULL,
  `usertype` varchar(50) NOT NULL,
  `monitoring` varchar(3) NOT NULL,
  `borrowing` varchar(3) NOT NULL,
  `transaction` varchar(3) NOT NULL,
  `reports` varchar(3) NOT NULL,
  `lending` varchar(3) NOT NULL,
  `assets` varchar(3) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `userlevel` */

insert into `userlevel` values 
(0,'admin','yes','yes','yes','yes','yes','yes'),
(2,'clerk','no','yes','yes','no','no','no'),
(3,'Credit Invistigator','no','no','no','no','no','yes');

/*Table structure for table `usersettings` */

DROP TABLE IF EXISTS `usersettings`;

CREATE TABLE `usersettings` (
  `Username` varchar(10) NOT NULL DEFAULT '''',
  `Password` varchar(10) NOT NULL DEFAULT '''',
  `No` int(100) NOT NULL,
  `WP` varchar(100) NOT NULL DEFAULT '''',
  `cono` int(100) NOT NULL,
  `userlvlno` int(100) NOT NULL,
  `userno` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `usersettings` */

insert into `usersettings` values 
('mack','mack',10002,'\'',1005,4,110);
