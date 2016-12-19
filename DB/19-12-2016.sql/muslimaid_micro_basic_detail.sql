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
-- Table structure for table `micro_basic_detail`
--

DROP TABLE IF EXISTS `micro_basic_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_basic_detail` (
  `idmicro_basic_detail` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `ca_code` varchar(12) NOT NULL,
  `nic` varchar(12) DEFAULT NULL,
  `city_code` varchar(10) DEFAULT NULL,
  `society_id` varchar(6) DEFAULT NULL,
  `province` varchar(20) DEFAULT NULL,
  `gs_ward` varchar(45) DEFAULT NULL,
  `full_name` varchar(100) DEFAULT NULL,
  `initial_name` varchar(100) DEFAULT NULL,
  `other_name` varchar(45) DEFAULT NULL,
  `marital_status` varchar(1) DEFAULT NULL,
  `education` varchar(45) DEFAULT NULL,
  `land_no` varchar(10) DEFAULT NULL,
  `mobile_no` varchar(10) DEFAULT NULL,
  `p_address` varchar(255) DEFAULT NULL,
  `team_id` varchar(3) DEFAULT NULL,
  `client_id` varchar(2) DEFAULT NULL,
  `inspection_date` varchar(45) DEFAULT NULL,
  `create_user_id` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `promisers_id` varchar(12) DEFAULT NULL,
  `village` varchar(45) DEFAULT NULL,
  `company_code` varchar(3) DEFAULT 'OA',
  `root_id` varchar(4) DEFAULT '1',
  `cli_photo` varchar(400) DEFAULT NULL,
  `bb_photo` varchar(400) DEFAULT NULL,
  `promiser_id_2` varchar(12) DEFAULT NULL,
  `nic_issue_date` varchar(45) DEFAULT NULL,
  `dob` varchar(45) DEFAULT NULL,
  `gender` varchar(1) DEFAULT NULL,
  `r_address` varchar(255) DEFAULT NULL,
  `income_source` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idmicro_basic_detail`,`contract_code`,`ca_code`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_basic_detail`
--

LOCK TABLES `micro_basic_detail` WRITE;
/*!40000 ALTER TABLE `micro_basic_detail` DISABLE KEYS */;
INSERT INTO `micro_basic_detail` VALUES (1,'CO/MB/000001/1','CO/2/1','852210583V','CO','2','WP','qwerty','Mahendra Karanduwawala','M Karanduwawala','-','S','P','772604480','772604480','22/163, Walawwatta,\r\nKalugalla Mawatha,',NULL,'1','29-08-2016','123456789V','127.0.0.1','2016-08-25 23:03:30',NULL,'Colombo 01','OA','2','cs_client_ph\\1-1.jpg','cs_client_ph\\1-2.jpg',NULL,'01-10-2001','08-08-1985','1','22/163, Walawwatta,\r\nKalugalla Mawatha,','business'),(2,'CO/MB/000002/1','CO/3/1','123456789V','CO','3','WP','QWERTY','QWERTYUIOP','QASWEDFRTGHYJUKIOLP','-','M','U','1234567890','1234567890','qWERTYUICVBNMHJKL',NULL,'1','25-12-2016','123456789V','127.0.0.1','2016-12-02 11:58:19',NULL,'Akarawita','OA','1','cs_client_ph\\2-1.JPG','cs_client_ph\\2-2.JPG',NULL,'15-12-2016','08-08-1985','1','ZWEXRCBYHUNJ','business');
/*!40000 ALTER TABLE `micro_basic_detail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:31
