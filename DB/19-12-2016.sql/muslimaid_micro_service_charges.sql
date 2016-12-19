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
-- Table structure for table `micro_service_charges`
--

DROP TABLE IF EXISTS `micro_service_charges`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_service_charges` (
  `idmicro_service_charges` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `document_amount` decimal(10,2) DEFAULT NULL,
  `insurance_amount` decimal(10,2) DEFAULT NULL,
  `city_code` varchar(4) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `payment_status` varchar(1) DEFAULT 'D',
  `total_amount_text` varchar(255) DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `welfair_fee` decimal(10,2) DEFAULT NULL,
  `registration_fee` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idmicro_service_charges`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_service_charges`
--

LOCK TABLES `micro_service_charges` WRITE;
/*!40000 ALTER TABLE `micro_service_charges` DISABLE KEYS */;
INSERT INTO `micro_service_charges` VALUES (1,'PL/MF/000002/1',500.00,0.00,'PL','123456789V','123.231.124.4','2016-06-01','D','ONE THOUSAND FIVE Hundred',1500.00,500.00,500.00),(2,'PL/MF/000003/1',500.00,0.00,'PL','123456789V','123.231.124.4','2016-06-01','D','ONE THOUSAND FIVE Hundred',1500.00,500.00,500.00),(3,'PL/MF/000005/1',500.00,0.00,'PL','123456789V','123.231.124.4','2016-06-01','D','ONE THOUSAND FIVE Hundred',1500.00,500.00,500.00),(4,'KD/MF/000001/1',500.00,0.00,'KD','123456789V','123.231.124.4','2016-06-01','D','ONE THOUSAND FIVE Hundred',1500.00,500.00,500.00),(5,'KD/MF/000006/1',400.00,0.00,'KD','123456789V','123.231.124.4','2016-06-01','D','ONE THOUSAND FOUR Hundred',1400.00,500.00,500.00);
/*!40000 ALTER TABLE `micro_service_charges` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:37
