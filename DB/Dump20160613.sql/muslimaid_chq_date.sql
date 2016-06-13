-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: muslimaid
-- ------------------------------------------------------
-- Server version	5.6.12-log

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
-- Table structure for table `chq_date`
--

DROP TABLE IF EXISTS `chq_date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chq_date` (
  `idchq_date` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `amount` decimal(12,2) DEFAULT NULL,
  `chq_name` varchar(100) DEFAULT NULL,
  `day1` varchar(1) DEFAULT NULL,
  `day2` varchar(1) DEFAULT NULL,
  `month1` varchar(1) DEFAULT NULL,
  `month2` varchar(1) DEFAULT NULL,
  `year1` varchar(1) DEFAULT NULL,
  `year2` varchar(1) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `chq_status` varchar(1) DEFAULT 'A',
  `descriptions` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idchq_date`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chq_date`
--

LOCK TABLES `chq_date` WRITE;
/*!40000 ALTER TABLE `chq_date` DISABLE KEYS */;
INSERT INTO `chq_date` VALUES (1,'KD/MF/000001/1',50000.00,'N.K.G.S. Bhagya Rathnayake 867340300V','2','7','0','5','1','6','234567891V','123.231.124.4','2016-05-27 18:29:04','A',NULL),(2,'KD/MF/000004/1',50000.00,'H.T. Mallika Perera 598460760V','2','7','0','5','1','6','234567891V','123.231.124.4','2016-05-27 18:29:27','A',NULL),(3,'KD/MF/000006/1',40000.00,'S. Dahanayake 836084675V','2','7','0','5','1','6','234567891V','123.231.124.4','2016-05-27 18:29:41','A',NULL),(4,'KD/MF/000007/1',40000.00,'N. Geetha Sudarshani Perera 787070841V','2','7','0','5','1','6','234567891V','123.231.124.4','2016-05-27 18:29:58','A',NULL),(5,'KD/MF/000008/1',40000.00,'U. Sriyani Perera 715371189V','2','7','0','5','1','6','234567891V','123.231.124.4','2016-05-27 18:30:20','A',NULL),(6,'KD/MF/000009/1',50000.00,'P.V. Dilani Wasana 888571051V','2','7','0','5','1','6','234567891V','123.231.124.4','2016-05-27 18:30:40','A',NULL),(7,'PL/MF/000002/1',50000.00,'K.K. Weerakkodi 748640630V','0','1','0','6','1','6','123456789V','123.231.124.4','2016-06-01 12:07:04','A',NULL),(8,'PL/MF/000003/1',50000.00,'A.H.M. Malkanthi 776152340v','0','1','0','6','1','6','123456789V','123.231.124.4','2016-06-01 12:13:02','A',NULL),(9,'PL/MF/000005/1',50000.00,'G.P.T.D. Weerawansha 858354374V','0','1','0','6','1','6','123456789V','123.231.124.4','2016-06-01 12:19:32','A',NULL),(10,'PL/MF/000010/1',75000.00,'S.H.D. Erandi 878311787V','0','8','0','6','1','6','123456789V','127.0.0.1','2016-06-08 12:26:39','A',NULL);
/*!40000 ALTER TABLE `chq_date` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-13 19:39:09
