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
-- Table structure for table `micro_payme_summery`
--

DROP TABLE IF EXISTS `micro_payme_summery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_payme_summery` (
  `idcons_payme_summery` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `nic` varchar(15) NOT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `capital` decimal(10,2) DEFAULT NULL,
  `interest` decimal(10,2) DEFAULT NULL,
  `debit` decimal(10,2) DEFAULT NULL,
  `c_default` decimal(10,2) DEFAULT NULL,
  `rcp_no` varchar(45) DEFAULT NULL,
  `p_type` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `payment_type` varchar(4) DEFAULT NULL,
  `chq_No` varchar(10) DEFAULT NULL,
  `chq_bank` varchar(45) DEFAULT NULL,
  `curr_balance` decimal(12,2) DEFAULT '0.00',
  `p_status` varchar(1) DEFAULT 'D',
  PRIMARY KEY (`idcons_payme_summery`,`contra_code`,`nic`),
  KEY `contra_code` (`contra_code`,`amount`,`p_type`,`p_status`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_payme_summery`
--

LOCK TABLES `micro_payme_summery` WRITE;
/*!40000 ALTER TABLE `micro_payme_summery` DISABLE KEYS */;
INSERT INTO `micro_payme_summery` VALUES (1,'PL/MF/000002/1','748640630V',100.00,0.00,100.00,0.00,0.00,'1','WI','2016-06-01 12:24:26','Cash','','',-100.00,'D'),(2,'PL/MF/000003/1','776152340v',100.00,0.00,100.00,0.00,0.00,'2','WI','2016-06-01 12:24:26','Cash','','',-100.00,'D'),(3,'PL/MF/000005/1','858354374V',100.00,0.00,100.00,0.00,0.00,'3','WI','2016-06-01 12:24:26','Cash','','',-100.00,'D'),(4,'KD/MF/000001/1','867340300V',1333.33,805.19,528.14,0.00,0.00,'6','WI','2016-06-08 08:43:25','Cash','','',-1333.33,'D'),(5,'KD/MF/000001/1','867340300V',1333.33,805.19,528.14,0.00,0.00,'7','WI','2016-06-08 08:44:34','Cash','','',-2666.66,'D');
/*!40000 ALTER TABLE `micro_payme_summery` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:35
