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
-- Table structure for table `micro_family_appraisal`
--

DROP TABLE IF EXISTS `micro_family_appraisal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_family_appraisal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `salary_n_wages` decimal(10,2) DEFAULT NULL,
  `rentIncome` decimal(10,2) DEFAULT NULL,
  `rent_income_other` decimal(10,2) DEFAULT NULL,
  `net_Income_business` decimal(10,2) DEFAULT NULL,
  `other_income` decimal(10,2) DEFAULT NULL,
  `food_ex` decimal(10,2) DEFAULT NULL,
  `education_ex` decimal(10,2) DEFAULT NULL,
  `wet_ex` decimal(10,2) DEFAULT NULL,
  `health_n_sanitation` decimal(10,2) DEFAULT NULL,
  `rent_ex` decimal(10,2) DEFAULT NULL,
  `other_facility_ex` decimal(10,2) DEFAULT NULL,
  `travel_n_transport` decimal(10,2) DEFAULT NULL,
  `clothes_ex` decimal(10,2) DEFAULT NULL,
  `other_ex` decimal(10,2) DEFAULT NULL,
  `amount_opex` decimal(10,2) DEFAULT NULL,
  `amount_fex` decimal(10,2) DEFAULT NULL,
  `fr_period` int(11) DEFAULT NULL,
  `mad` decimal(10,2) DEFAULT NULL,
  `mdaaip` decimal(10,2) DEFAULT NULL,
  `rapsa` decimal(10,2) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `create_user` int(11) DEFAULT NULL,
  `update_user` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`,`contract_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_family_appraisal`
--

LOCK TABLES `micro_family_appraisal` WRITE;
/*!40000 ALTER TABLE `micro_family_appraisal` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_family_appraisal` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:38
