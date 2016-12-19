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
-- Table structure for table `bank_tbl`
--

DROP TABLE IF EXISTS `bank_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bank_tbl` (
  `BankCode` int(11) NOT NULL,
  `BankName` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`BankCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bank_tbl`
--

LOCK TABLES `bank_tbl` WRITE;
/*!40000 ALTER TABLE `bank_tbl` DISABLE KEYS */;
INSERT INTO `bank_tbl` VALUES (7010,'Bank of Ceylon'),(7038,'Standard Chartered Bank'),(7047,'Citi Bank'),(7056,'Commercial Bank PLC'),(7074,'Habib Bank Ltd'),(7083,'Hatton National Bank PLC'),(7092,'Hongkong   Shanghai Bank'),(7108,'Indian Bank'),(7117,'Indian Overseas Bank'),(7135,'Peoples Bank'),(7144,'State Bank of India'),(7162,'Nations Trust Bank PLC'),(7205,'Deutsche Bank'),(7214,'National Development Bank PLC'),(7269,'MCB Bank Ltd'),(7278,'Sampath Bank PLC'),(7287,'Seylan Bank PLC'),(7296,'Public Bank'),(7302,'Union Bank of Colombo PLC'),(7311,'Pan Asia Banking Corporation PLC'),(7384,'ICICI Bank Ltd'),(7454,'DFCC Vardhana Bank Ltd'),(7463,'Amana Bank'),(7472,'Axis Bank'),(7719,'National Savings Bank'),(7728,'Sanasa Development Bank'),(7737,'HDFC Bank'),(7746,'Citizen Development Business Finance PLC'),(7755,'Regional Development Bank'),(7764,'State Mortgage & Investment Bank'),(7773,'LB Finance PLC'),(8004,'Central Bank of Sri Lanka');
/*!40000 ALTER TABLE `bank_tbl` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:36
