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
-- Table structure for table `micro_pais_history`
--

DROP TABLE IF EXISTS `micro_pais_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_pais_history` (
  `idpais_history` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `NIC` varchar(15) DEFAULT NULL,
  `paied_amount` decimal(9,2) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(20) DEFAULT NULL,
  `tra_description` varchar(3) DEFAULT NULL,
  `pay_status` varchar(1) DEFAULT NULL,
  `reson` varchar(45) DEFAULT NULL,
  `payment_type` varchar(4) DEFAULT NULL,
  `chq_No` varchar(10) DEFAULT NULL,
  `chq_bank` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idpais_history`,`contra_code`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_pais_history`
--

LOCK TABLES `micro_pais_history` WRITE;
/*!40000 ALTER TABLE `micro_pais_history` DISABLE KEYS */;
INSERT INTO `micro_pais_history` VALUES (1,'PL/MF/000002/1','748640630V',100.00,'2016-06-01 12:24:26','123456789V','123.231.124.4','WI','D','','Cash','',''),(2,'PL/MF/000003/1','776152340v',100.00,'2016-06-01 12:24:26','123456789V','123.231.124.4','WI','D','','Cash','',''),(3,'PL/MF/000005/1','858354374V',100.00,'2016-06-01 12:24:26','123456789V','123.231.124.4','WI','D','','Cash','',''),(4,'KD/MF/000001/1','867340300V',1333.33,'2016-06-08 08:31:39','123456789V','127.0.0.1','WI','D','','Cash','',''),(5,'KD/MF/000001/1','867340300V',1333.33,'2016-06-08 08:38:29','123456789V','127.0.0.1','WI','D','','Cash','',''),(6,'KD/MF/000001/1','867340300V',1333.33,'2016-06-08 08:43:25','123456789V','127.0.0.1','WI','D','','Cash','',''),(7,'KD/MF/000001/1','867340300V',1333.33,'2016-06-08 08:44:34','123456789V','127.0.0.1','WI','D','','Cash','','');
/*!40000 ALTER TABLE `micro_pais_history` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-13 19:39:05
