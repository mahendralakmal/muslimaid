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
-- Table structure for table `center_details`
--

DROP TABLE IF EXISTS `center_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `center_details` (
  `auto_id` int(11) NOT NULL AUTO_INCREMENT,
  `idcenter_details` int(11) DEFAULT NULL,
  `center_name` varchar(45) DEFAULT NULL,
  `city_code` varchar(10) DEFAULT NULL,
  `villages` varchar(45) DEFAULT NULL,
  `leader_name` varchar(100) DEFAULT NULL,
  `conta_no` varchar(10) DEFAULT NULL,
  `create_userID` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `center_day` varchar(10) DEFAULT NULL,
  `Latitude` varchar(45) NOT NULL DEFAULT '0.00000000',
  `Longitude` varchar(45) NOT NULL DEFAULT '0.00000000',
  `exective` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`auto_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `center_details`
--

LOCK TABLES `center_details` WRITE;
/*!40000 ALTER TABLE `center_details` DISABLE KEYS */;
INSERT INTO `center_details` VALUES (26,1,'Ashoka','CO','Katubedda','Pathmawathi','0710000789','902554203V','127.0.0.1','2016-07-25 12:27:51','WE','0000','0000','1'),(27,2,'Shashi','CO','Colombo 01','Shashi','0112650987','902554203V','127.0.0.1','2016-08-09 11:38:24','WE','0000','0000','2'),(28,3,'QWERTY','CO','Akarawita','Ravi','123456789','123456789V','127.0.0.1','2016-12-02 11:55:37','MO','7.095617','79.966654','1');
/*!40000 ALTER TABLE `center_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:34
