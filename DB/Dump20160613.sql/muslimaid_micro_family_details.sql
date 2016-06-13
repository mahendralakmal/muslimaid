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
  PRIMARY KEY (`idmicro_family_details`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_family_details`
--

LOCK TABLES `micro_family_details` WRITE;
/*!40000 ALTER TABLE `micro_family_details` DISABLE KEYS */;
INSERT INTO `micro_family_details` VALUES (1,'KD/MF/000001/1','638364271V','R.R.P.W.S. Damayanthi Kumari','Profession','03','Primary','01',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 14:39:11'),(2,'PL/MF/000002/1','681610995V','Herath Mudiyanselage Saman Dammika Senarath','Self','4','Primary','2',72000.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 14:44:38'),(3,'PL/MF/000003/1','713130524V','Muthuthanthrige Charly Mahindasiri Cooray','Self','5','Primary','3',80000.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 16:37:22'),(4,'KD/MF/000004/1','590883077V','M.A. Nandanasiri','Business','02','Primary','01',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 16:10:27'),(5,'PL/MF/000005/1','802473354V','Hapuhennedige Gayal Suranga Fernando','Profession','4','Primary','2',72000.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 16:21:08'),(6,'KD/MF/000006/1','763032329V','Saman Dahanayake','Profession','03','Primary','0',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 16:21:11'),(7,'KD/MF/000007/1','780630914V','G.A.G. Chaminda Sudath','Profession','05','Primary','03',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 16:27:27'),(8,'KD/MF/000008/1','977642230V','M. Pramoda Madushani','Profession','04','Primary','03',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 16:31:38'),(9,'KD/MF/000009/1','872730133V','K. Sanka Perera','Profession','04','Primary','02',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-05-27 16:35:36'),(10,'PL/MF/000010/1','820722914v','K. Gihan Danushka','Business','5','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-03 12:13:40'),(11,'PL/MF/000011/1','861753620v','A.W.P.N. Chathuranga','Profession','5','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-03 12:31:09'),(12,'PL/MF/000012/1','801910491v','Weerakkodi Vajira Kumara Silva','Self','05','Primary','02',100000.00,20000.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-03 16:59:55'),(13,'PL/MF/000013/1','945561424v','K.K.M.Chamudika','Self','03','Primary','02',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 09:10:34'),(14,'PL/MF/000014/1','601361361v','D.G.D.Susil','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 09:35:42'),(15,'PL/MF/000015/1','620401692v','Gardhi Hewawasam Ganegoda Gamage Sunil','Profession','5','Primary','4',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 09:53:21'),(16,'PL/MF/000016/1','801041264v','M.A.S.Chamila','Profession','5','Primary','4',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 11:00:31'),(17,'PL/MF/000017/1','851980814v','K.A. Priyashantha','Profession','4','Primary','2',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 11:07:01'),(18,'PL/MF/000018/1','793225385v','K.A.A.Wijayantha','Profession','5','Primary','4',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 11:19:36'),(19,'PL/MF/000019/1','511563976v','K. Wijesinghe','Self','02','Primary','0',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 11:29:09'),(20,'PL/MF/000022/1','640232897v','G.Upali','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 11:29:59'),(21,'PL/MF/000023/1','782081039v','V.I.A.P.J. Thilakasiri','Self','04','Primary','02',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 11:48:00'),(22,'PL/MF/000024/1','965551840v','S.D.P.Kumari','Profession','5','Primary','4',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 11:49:38'),(23,'PL/MF/000026/1','582322430v','T.R.L.P. Fernando','Profession','03','Primary','01',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 12:01:02'),(24,'PL/MF/000025/1','703143849v','P.A.J.S.Palinda','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 12:03:01'),(25,'PL/MF/000027/1','690424886v','D.P.A.Pathirana','Profession','05','Primary','04',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 12:14:59'),(26,'PL/MF/000028/1','761980556v','H.Indika','Profession','3','Primary','2',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 12:18:17'),(27,'PL/MF/000029/1','662491535v','B.V.G.W.Wijerathna','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 12:49:01'),(28,'PL/MF/000030/1','792645984v','R.P.N.K.Somarathna','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 13:08:37'),(29,'PL/MF/000031/1','557060723v','I. K. Abesingha','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 13:28:15'),(30,'PL/MF/000032/1','710672008v','V.M.L,N.Kumara','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 13:41:38'),(31,'KD/MF/000033/1','833451430v','K.A.C. Kumara','Self','04','Primary','02',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 15:09:23'),(32,'PL/MF/000034/1','813084848v','G.D.A.Weerasingha','Profession','3','Primary','2',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 15:17:52'),(33,'PL/MF/000036/1','793210906v','S.E.Krishan','Profession','3','Primary','2',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 15:31:09'),(34,'KD/MF/000035/1','825660224v','Kalupathirannehelage Mangalika','Self','03','Primary','02',0.00,40000.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 15:32:15'),(35,'PL/MF/000037/1','732541381v','V.K.Weerasingha','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 15:40:14'),(36,'KD/MF/000038/1','711751483V','Undikkunda Arachchige Thusitha Gayan Nalinda','Self','04','Primary','02',30000.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 15:54:28'),(37,'KD/MF/000039/1','761942875V','Palpita Kankanamalage Sumith Pushpa Kumara','Self','04','Primary','02',20000.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 16:12:41'),(38,'PL/MF/000040/1','976000277v','Mahamarakkalage Lakshika Sapumali Madurangi','Profession','5','Primary','4',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 16:19:13'),(39,'KD/MF/000041/1','197261502454','Mullagoda Vidanage Don Nirosha','Business','04','Primary','02',60000.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 16:28:22'),(40,'PL/MF/000042/1','932810328v','N.T.Ruwan Pathirana','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 16:36:32'),(41,'KD/MF/000043/1','956871085V','Weerawickrama Samarasinghe Arachchige Ayesha Piumali','Business','06','Primary','03',50000.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 16:44:01'),(42,'PL/MF/000044/1','591171992v','V.R.Victer','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-06 16:47:31'),(43,'KD/MF/000045/1','752053260v','H. K.Somasiri','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:11:56'),(44,'KD/MF/000046/1','803305480v','B. Gunawardana','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:21:57'),(45,'KD/MF/000047/1','840102556v','A.G.V.Perera','Profession','3','Primary','2',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:30:41'),(46,'AV/MF/000048/1','750320759v','W.M.P.Kumara','Profession','5','Primary','4',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:42:15'),(47,'KD/MF/000049/1','693321999v','B.Jayasingha','Profession','5','Primary','4',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:42:22'),(48,'AV/MF/000050/1','950520035v','D.D.T.A.Dangalla','Profession','02','Primary','01',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:49:37'),(49,'AV/MF/000050/1','950520035v','D.D.T.A.Dangalla','Profession','02','Primary','01',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:49:38'),(50,'KD/MF/000051/1','771441521v','W.S.Samantha','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:50:52'),(51,'AV/MF/000053/1','962303307v','M.K.P.M.Makavita','Profession','06','Primary','04',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:58:35'),(52,'AV/MF/000053/1','962303307v','M.K.P.M.Makavita','Profession','06','Primary','04',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:58:36'),(53,'AV/MF/000053/1','962303307v','M.K.P.M.Makavita','Profession','06','Primary','04',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:58:36'),(54,'KD/MF/000052/1','783421704v','G.S.Kumara','Profession','4','Primary','3',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 09:58:49'),(55,'AV/MF/000054/1','683301744v','W.G.R.Wipulasiri','Profession','3','Primary','2',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 10:10:36'),(56,'AV/MF/000055/1','850623104v','B.Nisantha','Profession','3','Primary','2',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 10:19:59'),(57,'AV/MF/000056/1','825611746v','D.K.L.Rathnasili','Profession','2','Primary','1',0.00,0.00,0.00,0.00,0.00,'123456789V','123.231.124.4','2016-06-07 10:29:35');
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

-- Dump completed on 2016-06-13 19:39:11
