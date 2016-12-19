-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: muslimaid
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.13-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `micro_family_details`
--

DROP TABLE IF EXISTS `micro_family_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_family_details` (
  `idmicro_family_details` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `spouse_nic` varchar(12) DEFAULT NULL,
  `spouse_name` varchar(100) DEFAULT NULL,
  `occupation` varchar(45) DEFAULT NULL,
  `no_of_fami_memb` varchar(2) DEFAULT NULL,
  `education` varchar(45) DEFAULT NULL,
  `dependers` varchar(2) DEFAULT NULL,
  `spouse_income` decimal(10,2) DEFAULT NULL,
  `other_fami_mem_income` decimal(10,2) DEFAULT NULL,
  `moveable_property` decimal(10,2) DEFAULT NULL,
  `immoveable_property` decimal(10,2) DEFAULT NULL,
  `saving` decimal(10,2) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `spouse_nic_issued_date` varchar(10) DEFAULT NULL,
  `spouse_dob` varchar(10) DEFAULT NULL,
  `spouse_gender` varchar(1) DEFAULT NULL,
  `spouse_contact_no` varchar(15) DEFAULT NULL,
  `spouse_relationship_with_applicant` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmicro_family_details`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_family_details`
--

LOCK TABLES `micro_family_details` WRITE;
/*!40000 ALTER TABLE `micro_family_details` DISABLE KEYS */;
INSERT INTO `micro_family_details` VALUES (1,'CO/CS/000004','861515253V','Tharindu SAjeewanie','Profession','4','Primary','2',4500.00,1000.00,1000.00,1000.00,5000.00,'123456789V','127.0.0.1','2016-08-29 09:50:49','02-02-2001','6-22-1986','1','0714867518','Wife'),(2,'CO/CS/000004','861515253V','Tharindu SAjeewanie','Profession','4','Primary','2',4500.00,1000.00,1000.00,1000.00,5000.00,'123456789V','127.0.0.1','2016-08-29 09:54:19','02-02-2001','6-22-1986','1','0714867518','Wife'),(3,'CO/CS/000004','123456789V','QWERTY L','Self','4','Undergraduate','2',5000.00,0.00,0.00,300000.00,50000.00,'123456789V','127.0.0.1','2016-12-02 12:39:37','01-01-2015','05-05-1986','1','123456789','WIFE');
/*!40000 ALTER TABLE `micro_family_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:40
