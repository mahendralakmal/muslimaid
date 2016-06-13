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
-- Table structure for table `target_detail`
--

DROP TABLE IF EXISTS `target_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `target_detail` (
  `idtarget_detail` int(11) NOT NULL AUTO_INCREMENT,
  `t_year` varchar(10) DEFAULT NULL,
  `t_month` varchar(15) DEFAULT NULL,
  `branch_code` varchar(5) DEFAULT NULL,
  `b_module` varchar(10) DEFAULT NULL,
  `b_target` decimal(12,2) DEFAULT NULL,
  `b_archi` decimal(12,2) DEFAULT NULL,
  `live_status` varchar(1) DEFAULT 'L',
  `create_user_nic` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idtarget_detail`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `target_detail`
--

LOCK TABLES `target_detail` WRITE;
/*!40000 ALTER TABLE `target_detail` DISABLE KEYS */;
INSERT INTO `target_detail` VALUES (1,'2016','5','KD','CS',6000000.00,270000.00,'L','234567891V','123.231.124.4','2016-05-27'),(2,'2016','6','PL','CS',6000000.00,225000.00,'L','123456789V','123.231.124.4','2016-06-01');
/*!40000 ALTER TABLE `target_detail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-13 19:39:06
