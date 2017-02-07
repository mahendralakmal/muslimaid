-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: muslimaid
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.19-MariaDB

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
-- Table structure for table `approved_descr`
--

DROP TABLE IF EXISTS `approved_descr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `approved_descr` (
  `idapproved_descr` int(11) NOT NULL AUTO_INCREMENT,
  `sh_code` varchar(1) NOT NULL,
  `descri` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idapproved_descr`,`sh_code`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `approved_descr`
--

LOCK TABLES `approved_descr` WRITE;
/*!40000 ALTER TABLE `approved_descr` DISABLE KEYS */;
INSERT INTO `approved_descr` VALUES (1,'Y','Yes'),(2,'N','No'),(3,'P','pending'),(4,'D','Posted'),(5,'C','Cancel');
/*!40000 ALTER TABLE `approved_descr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bank_acc_no`
--

DROP TABLE IF EXISTS `bank_acc_no`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bank_acc_no` (
  `idbank_acc_no` int(11) NOT NULL AUTO_INCREMENT,
  `bank_code` varchar(4) NOT NULL,
  `branch_code` varchar(3) DEFAULT NULL,
  `acc_no` varchar(20) DEFAULT NULL,
  `user_id` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idbank_acc_no`,`bank_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bank_acc_no`
--

LOCK TABLES `bank_acc_no` WRITE;
/*!40000 ALTER TABLE `bank_acc_no` DISABLE KEYS */;
/*!40000 ALTER TABLE `bank_acc_no` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `bankbranch_tbl`
--

DROP TABLE IF EXISTS `bankbranch_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bankbranch_tbl` (
  `BankCode` int(11) NOT NULL,
  `BranchCode` int(11) NOT NULL,
  `BranchName` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`BankCode`,`BranchCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankbranch_tbl`
--

LOCK TABLES `bankbranch_tbl` WRITE;
/*!40000 ALTER TABLE `bankbranch_tbl` DISABLE KEYS */;
INSERT INTO `bankbranch_tbl` VALUES (7010,1,'City Office'),(7010,2,'Kandy'),(7010,3,'Galle Fort'),(7010,4,'Pettah'),(7010,5,'Jaffna'),(7010,6,'Trincomalee'),(7010,7,'Panadura'),(7010,9,'Kurunegala'),(7010,11,'Badulla'),(7010,12,'Batticaloa'),(7010,15,'Central Office'),(7010,16,'Kalutara S/G'),(7010,18,'Negombo'),(7010,20,'Chilaw'),(7010,21,'Ampara'),(7010,22,'Anuradhapura'),(7010,23,'Wellawatte'),(7010,24,'Matara'),(7010,26,'Main Street'),(7010,27,'Kegalle'),(7010,28,'Point Pedro'),(7010,29,'Nuwara Eliya'),(7010,30,'Katubedda'),(7010,31,'Ratnapura'),(7010,32,'Aluthkade'),(7010,34,'Kollupitiya'),(7010,35,'Haputale'),(7010,37,'Bambalapitiya'),(7010,38,'Borella S/G'),(7010,39,'Ja Ela'),(7010,40,'Hatton'),(7010,41,'Maradana'),(7010,42,'Peliyagoda'),(7010,43,'Union Place'),(7010,44,'Vavuniya'),(7010,45,'Gampaha S/G'),(7010,46,'Mannar'),(7010,47,'Ambalangoda'),(7010,48,'Puttalam'),(7010,49,'Nugegoda'),(7010,50,'Nattandiya'),(7010,51,'Dehiwala'),(7010,52,'Kuliyapitiya'),(7010,53,'Chunnakam'),(7010,54,'Horana'),(7010,55,'Maharagama'),(7010,56,'Tangalle'),(7010,57,'Eheliyagoda'),(7010,58,'Beruwala'),(7010,59,'Kadawatha'),(7010,60,'Fifth City'),(7010,61,'Idama-Moratuwa'),(7010,63,'Velanai'),(7010,68,'Matale'),(7010,82,'Monaragala'),(7010,83,'Polonnaruwa New Town'),(7010,85,'Hambantota'),(7010,87,'International Division'),(7010,88,'Mirigama'),(7010,89,'Galle Bazaar'),(7010,92,'Naula'),(7010,93,'Kilinochchi'),(7010,98,'Anuradhapura New Town'),(7010,99,'Primary Dealer Unit'),(7010,101,'Galaha'),(7010,102,'Bentota'),(7010,104,'Welpalla'),(7010,118,'Muttur'),(7010,122,'Galenbindunuwewa'),(7010,127,'Padavi Parakramapura'),(7010,135,'Imaduwa'),(7010,139,'Weeraketiya'),(7010,144,'Yatawatte'),(7010,152,'Pemaduwa'),(7010,157,'Tirappane'),(7010,162,'Medawachchiya'),(7010,167,'Rikillagaskada'),(7010,172,'Kobeigane'),(7010,183,'Sewagama'),(7010,217,'Horowpathana'),(7010,236,'Ipalogama'),(7010,238,'Medagama'),(7010,250,'Tawalama'),(7010,255,'Malkaduwawa'),(7010,256,'Thanthirimale'),(7010,257,'Mawathagama'),(7010,258,'Elakanda'),(7010,259,'Rathgama'),(7010,260,'Diyatalawa'),(7010,261,'Katuwana'),(7010,262,'Kekanadura'),(7010,263,'Kosmodera'),(7010,264,'Kudawella'),(7010,265,'Lunugamvehera'),(7010,266,'Maha-Edanda'),(7010,267,'Makandura - Matara'),(7010,268,'Malimbada'),(7010,270,'Morawaka'),(7010,271,'Pasgoda'),(7010,272,'Pitabeddara'),(7010,273,'Digana'),(7010,274,'Weli-Oya'),(7010,276,'Ahangama'),(7010,277,'Aluthwala'),(7010,278,'Barawakumbura'),(7010,280,'Karapitiya'),(7010,281,'Manipay'),(7010,282,'Kitulgala'),(7010,283,'Kolonna'),(7010,284,'Kotiyakumbura'),(7010,285,'Morontota'),(7010,287,'Pinnawala'),(7010,288,'Sabaragamuwa Provincial Council'),(7010,290,'Seethawakapura'),(7010,291,'Udawalawe'),(7010,292,'Weligepola'),(7010,293,'Dodangoda'),(7010,294,'Karawanella'),(7010,295,'Karawita'),(7010,297,'Kegalle Hospital'),(7010,298,'Urubokka'),(7010,299,'Makandura'),(7010,300,'Marawila'),(7010,301,'Palaviya'),(7010,302,'Pallama'),(7010,303,'Paragahadeniya'),(7010,305,'Thoduwawa'),(7010,306,'Udappuwa'),(7010,308,'Weerapokuna'),(7010,309,'Wellawa'),(7010,311,'Bulathkohupitiya'),(7010,312,'Embilipitiya City'),(7010,313,'Endana'),(7010,314,'Galigamuwa'),(7010,315,'Ratnapura Hospital'),(7010,316,'Gonagaldeniya'),(7010,317,'Kiriella'),(7010,318,'Potuvil'),(7010,319,'Mahawewa'),(7010,320,'Ballaketuwa'),(7010,322,'Thanamalwila'),(7010,323,'Kochchikade'),(7010,324,'Kumbukgete'),(7010,325,'Kuruwita'),(7010,326,'Thirumurukandi'),(7010,328,'Visuvamadu'),(7010,329,'Ambanpola'),(7010,330,'Anawilundawa'),(7010,331,'Dambadeniya'),(7010,332,'Katuneriya'),(7010,333,'Katupotha'),(7010,334,'Kirimetiyana'),(7010,335,'Mihintale'),(7010,336,'Thalaimannar Pier'),(7010,337,'Pussellawa'),(7010,338,'Savalkaddu'),(7010,339,'Sirupiddy'),(7010,340,'Wattegama'),(7010,341,'Puthukudieruppu'),(7010,342,'Puthukulam'),(7010,343,'Uva Paranagama'),(7010,344,'Pesalai'),(7010,345,'Poonagary'),(7010,346,'Poovarasankulam'),(7010,348,'Padiyatalawa'),(7010,349,'Mallavi'),(7010,351,'Manthikai'),(7010,353,'Mulankavil'),(7010,355,'Mulliyawalai'),(7010,356,'Murungan'),(7010,357,'Nainativu'),(7010,358,'Nallur'),(7010,359,'Nanatan'),(7010,360,'Nedunkerny'),(7010,361,'Oddusudan'),(7010,362,'Omanthai'),(7010,363,'Pallai'),(7010,364,'Paranthan'),(7010,366,'Jaffna Bus Stand'),(7010,368,'Jaffna Main Street'),(7010,369,'Jaffna University'),(7010,370,'Kaithady'),(7010,371,'Kalviyankadu'),(7010,372,'Karanavai'),(7010,373,'Kayts'),(7010,375,'Kodikamam'),(7010,376,'Kokuvil'),(7010,378,'Madhu'),(7010,379,'Wariyapola'),(7010,380,'Alaveddy'),(7010,381,'Andankulam'),(7010,382,'Cheddikulam'),(7010,384,'Meegahakiwula'),(7010,385,'Vavunathivu'),(7010,386,'Vellaveli'),(7010,388,'Diyabeduma'),(7010,389,'Diyasenpura'),(7010,390,'Doramadalawa'),(7010,391,'Galamuna'),(7010,392,'General Hospital, A\' pura'),(7010,393,'Habarana'),(7010,394,'Minneriya'),(7010,395,'Padaviya'),(7010,396,'Rajanganaya'),(7010,397,'Rajina Junction'),(7010,398,'Ranajayapura'),(7010,399,'Sevanapitiya'),(7010,400,'Thalawa'),(7010,401,'Ayagama'),(7010,402,'Oddamavady'),(7010,403,'Oluwil'),(7010,404,'Palugamam'),(7010,405,'Polwatte'),(7010,406,'Palmuddai'),(7010,407,'Sainthamarathu'),(7010,408,'Serunuwara'),(7010,409,'Thambiluvil'),(7010,410,'Thampalakamam'),(7010,411,'Thoppur'),(7010,413,'Uhana'),(7010,414,'Uppuvely'),(7010,415,'Vakarai'),(7010,416,'Siyambalanduwa'),(7010,417,'Mollipothana'),(7010,418,'Morawewa'),(7010,419,'Navithanvely'),(7010,420,'Nilavely'),(7010,421,'Seeduwa'),(7010,422,'Malwatte'),(7010,423,'Mamangama'),(7010,424,'Maruthamunai'),(7010,425,'Pundaluoya'),(7010,426,'Kallady'),(7010,427,'Kallar'),(7010,428,'Karadiyanaru'),(7010,429,'Karaitivu'),(7010,430,'Kiran'),(7010,431,'Kokkadicholai'),(7010,432,'Galewela'),(7010,433,'Divulapitiya'),(7010,434,'Wellawaya'),(7010,436,'China Bay'),(7010,438,'Gonagolla'),(7010,439,'Irakkamam'),(7010,440,'Samanthurai'),(7010,441,'Pujapitiya'),(7010,442,'Ragala'),(7010,443,'Sigiriya'),(7010,444,'Ukuwela'),(7010,446,'Upcott'),(7010,447,'Wilgamuwa'),(7010,448,'Addalachchenai'),(7010,449,'Alankerny'),(7010,451,'Araiyampathy'),(7010,452,'Batticaloa Town'),(7010,453,'Independent  Square'),(7010,455,'Kotagala'),(7010,456,'Marassana'),(7010,458,'Meepilimana'),(7010,459,'Menikhinna'),(7010,461,'Palapathwela'),(7010,462,'Botanical Gardens Peradeniya'),(7010,463,'Haldummulla'),(7010,465,'Bokkawala'),(7010,466,'Danture'),(7010,467,'Daulagala'),(7010,469,'Digana Village'),(7010,470,'Gampola City'),(7010,471,'Ginigathhena'),(7010,472,'Hatharaliyadda'),(7010,473,'Kandy City Centre'),(7010,474,'Court Complex Kandy'),(7010,476,'Ettampitiya'),(7010,477,'Yatiyantota'),(7010,487,'Adikarigama'),(7010,488,'Agarapathana'),(7010,489,'Akurana'),(7010,490,'Ankumbura'),(7010,491,'Bogawantalawa'),(7010,492,'Padiyapelella'),(7010,494,'Andiambalama'),(7010,497,'Dankotuwa'),(7010,498,'Alawwa'),(7010,499,'Wijerama Junction'),(7010,500,'Jaffna 2nd Branch'),(7010,501,'Chavakachcheri'),(7010,502,'Kaduruwela'),(7010,503,'Passara'),(7010,504,'Devinuwara'),(7010,505,'Wattala'),(7010,506,'Maskeliya'),(7010,507,'Kahawatte'),(7010,508,'Wennappuwa'),(7010,509,'Hingurana'),(7010,510,'Kalmunai'),(7010,511,'Mullaitivu'),(7010,512,'Thimbirigasyaya'),(7010,513,'Kurunegala Bazaar'),(7010,514,'Galnewa'),(7010,515,'Bandarawela'),(7010,516,'Thalawathugoda'),(7010,517,'Walasmulla'),(7010,518,'Middeniya'),(7010,520,'Sri Jayawardenapura Hospital'),(7010,521,'Hyde Park'),(7010,522,'Batapola'),(7010,524,'Geli Oya'),(7010,525,'Baddegama'),(7010,526,'Polgahawela'),(7010,527,'Welisara'),(7010,528,'Deniyaya'),(7010,529,'Kamburupitiya'),(7010,530,'Avissawella'),(7010,531,'Talawakelle'),(7010,532,'Ridigama'),(7010,533,'Pitakotte'),(7010,534,'Narammala'),(7010,535,'Embilipitiya'),(7010,536,'Kegalle Bazaar'),(7010,537,'Ambalantota'),(7010,538,'Tissamaharama'),(7010,539,'Beliatta'),(7010,540,'Badalkumbura'),(7010,541,'Pelawatte City Kalutara'),(7010,542,'Mahiyangana'),(7010,543,'Kiribathgoda'),(7010,544,'Madampe'),(7010,545,'Minuwangoda'),(7010,546,'Pannala'),(7010,547,'Nikaweratiya'),(7010,548,'Anamaduwa'),(7010,549,'Galgamuwa'),(7010,550,'Weligama'),(7010,551,'Anuradhapura Bazzar'),(7010,553,'Giriulla'),(7010,554,'Bingiriya'),(7010,555,'Melsiripura'),(7010,556,'Matugama'),(7010,557,'Moratumulla'),(7010,558,'Waikkal'),(7010,559,'Mawanella'),(7010,560,'Buttala'),(7010,561,'Dematagoda'),(7010,562,'Warakapola'),(7010,563,'Dharga Town'),(7010,564,'Maho'),(7010,565,'Madurankuliya'),(7010,566,'Aranayake'),(7010,567,'Dedicated Economic Centre - Meegoda'),(7010,568,'Homagama'),(7010,569,'Hiripitiya'),(7010,570,'Hettipola'),(7010,571,'Kirindiwela'),(7010,572,'Negombo Bazzar'),(7010,573,'Central Bus Stand'),(7010,574,'Mankulam'),(7010,575,'Gampola'),(7010,576,'Dambulla'),(7010,577,'Lunugala'),(7010,578,'Yakkalamulla'),(7010,579,'Bibile'),(7010,580,'Dummalasuriya'),(7010,581,'Madawala'),(7010,582,'Rambukkana'),(7010,583,'Mattegoda'),(7010,584,'Wadduwa'),(7010,585,'Ruwanwella'),(7010,587,'Pilimatalawa'),(7010,588,'Peradeniya'),(7010,589,'Kalpitiya'),(7010,590,'Akkaraipattu'),(7010,591,'Nintavur'),(7010,592,'Dikwella'),(7010,593,'Milagiriya'),(7010,594,'Rakwana'),(7010,595,'Kolonnawa'),(7010,596,'Talgaswela'),(7010,597,'Nivitigala'),(7010,598,'Nawalapitiya'),(7010,599,'Aralaganwila'),(7010,600,'Jayanthipura'),(7010,601,'Hingurakgoda'),(7010,602,'Kirulapana'),(7010,603,'Lanka Hospital'),(7010,604,'Ingiriya'),(7010,605,'Kankesanthurai'),(7010,606,'Uda Dumbara'),(7010,607,'Panadura Bazaar'),(7010,608,'Kaduwela'),(7010,609,'Hikkaduwa'),(7010,610,'Pitigala'),(7010,611,'Kaluwanchikudy'),(7010,612,'Lake View'),(7010,613,'Akuressa'),(7010,614,'Matara City'),(7010,615,'Galagedera'),(7010,616,'Kataragama'),(7010,617,'Keselwatte'),(7010,618,'Metropolitan'),(7010,619,'Elpitiya'),(7010,620,'Kesbewa'),(7010,621,'Kebithigollawa'),(7010,622,'Kahatagasdigiliya'),(7010,623,'Kantale Bazaar'),(7010,624,'Trincomalee Bazaar'),(7010,625,'Katukurunda'),(7010,626,'Valachchenai'),(7010,627,'Regent Street'),(7010,628,'Grandpass'),(7010,629,'Koslanda'),(7010,630,'Chenkalady'),(7010,633,'Kandapola'),(7010,634,'Dehiowita'),(7010,636,'Lake House'),(7010,638,'Nelliady'),(7010,639,'Rattota'),(7010,640,'Pallepola'),(7010,641,'Medirigiriya'),(7010,642,'Deraniyagala'),(7010,643,'Gonapola'),(7010,644,'Parliamentary Complex'),(7010,645,'Kalawana'),(7010,646,'Boralesgamuwa'),(7010,647,'Lunuwatte'),(7010,648,'Kattankudy'),(7010,649,'Kandy 2nd'),(7010,650,'Talatuoya'),(7010,651,'Bombuwela'),(7010,652,'Bakamuna'),(7010,653,'Galkiriyagama'),(7010,654,'Madatugama'),(7010,655,'Tambuttegama'),(7010,656,'Nochchiyagama'),(7010,657,'Agalawatta'),(7010,658,'Katunayake I.P.Z.'),(7010,660,'Corporate'),(7010,662,'Baduraliya'),(7010,663,'Kotahena'),(7010,664,'Pothuhera'),(7010,665,'Bandaragama'),(7010,666,'Katugastota'),(7010,667,'Neluwa'),(7010,668,'Borella  2nd'),(7010,669,'Girandurukotte'),(7010,670,'Kollupitiya 2nd'),(7010,672,'Central Super Market'),(7010,673,'Bulathsinhala'),(7010,674,'Enderamulla'),(7010,675,'Nittambuwa'),(7010,676,'Kekirawa'),(7010,677,'Weliweriya'),(7010,678,'Padukka'),(7010,679,'Battaramulla'),(7010,680,'Aluthgama'),(7010,681,'Personal'),(7010,682,'Veyangoda'),(7010,683,'Pelmadulla'),(7010,684,'Ratnapura Bazaar'),(7010,685,'Ward Place'),(7010,686,'Dehiattakandiya'),(7010,687,'Raddolugama'),(7010,688,'Balangoda'),(7010,689,'Ratmalana'),(7010,690,'Pelawatta'),(7010,691,'Hakmana'),(7010,692,'Eppawala'),(7010,693,'Ruhunu Campus'),(7010,699,'Bogahakumbura'),(7010,701,'Ella'),(7010,703,'Keppetipola'),(7010,708,'Batuwatte'),(7010,711,'Bopitiya'),(7010,713,'Asiri Central'),(7010,714,'Katuwellegama Courtaulds Clothing Lanka (Pvt) Ltd'),(7010,715,'Dalugama'),(7010,716,'Delgoda'),(7010,717,'Demanhandiya'),(7010,718,'Fish Market Peliyagoda'),(7010,720,'Ganemulla'),(7010,721,'Gothatuwa'),(7010,722,'Katana'),(7010,723,'Mulleriyawa New Town'),(7010,724,'Naiwala'),(7010,728,'Meegalewa'),(7010,729,'Badulla City'),(7010,730,'Welimada'),(7010,731,'CEYBANK Credit card centre'),(7010,732,'Biyagama'),(7010,735,'Kinniya'),(7010,736,'Piliyandala'),(7010,741,'Hanwella'),(7010,743,'Walapane'),(7010,744,'Walgama'),(7010,746,'Rajagiriya'),(7010,747,'Taprobane'),(7010,748,'Uragasmanhandiya'),(7010,749,'Karainagar'),(7010,750,'Koggala E.P.Z'),(7010,751,'Suriyawewa'),(7010,752,'Thihagoda'),(7010,753,'Udugama'),(7010,754,'Ahungalla'),(7010,757,'Athurugiriya'),(7010,760,'Treasury Division'),(7010,761,'Thirunelvely'),(7010,762,'Narahenpita'),(7010,763,'Malabe'),(7010,764,'Ragama'),(7010,765,'Pugoda'),(7010,766,'Mount Lavinia'),(7010,767,'Ranna'),(7010,768,'Alawathugoda'),(7010,769,'Yakkala'),(7010,770,'Ibbagamuwa'),(7010,771,'Kandana'),(7010,772,'Hemmathagama'),(7010,773,'Kottawa'),(7010,774,'Angunakolapelessa'),(7010,775,'Visakha'),(7010,776,'Islamic Banking Unit'),(7010,778,'Atchuvely'),(7010,779,'Norchcholei'),(7010,780,'Kadawatha 2nd City'),(7010,781,'Teldeniya'),(7010,782,'Rambewa'),(7010,783,'Polpithigama'),(7010,784,'Deiyandara'),(7010,785,'Hali ela'),(7010,786,'Godakawela'),(7010,787,'Kopay'),(7010,788,'BOC premier'),(7010,789,'Makola'),(7010,790,'Eravur'),(7010,791,'Valvettithurai'),(7010,792,'Chankanai'),(7010,793,'Vavuniya City'),(7010,794,'Urumpirai'),(7010,796,'Mattala Airport'),(7010,797,'Medawala'),(7010,800,'Wanduramba'),(7010,802,'Provincial Council Complex, Pallakelle'),(7010,803,'Welioya-Sampath Nuwara'),(7010,804,'Vaddukoddai'),(7010,805,'Madawakkulama'),(7010,806,'Mahaoya'),(7010,808,'Bogaswewa'),(7010,809,'Kurunduwatte'),(7010,810,'Ethimale'),(7010,811,'Central Camp'),(7010,812,'Aladeniya'),(7010,822,'Corporate 2nd'),(7010,999,'Head Office'),(7038,1,'Head Office'),(7038,2,'Bambalapitiya'),(7038,3,'Wellawatte'),(7038,4,'Kiribathgoda'),(7038,5,'Kirullapone'),(7038,6,'Moratuwa'),(7038,7,'Rajagiriya'),(7038,8,'Kollupitiya'),(7038,10,'Pettah'),(7038,11,'Union Place'),(7038,12,'Negombo'),(7038,14,'Wattala'),(7038,999,'Head Office'),(7047,0,'Head Office'),(7047,1,'Head Office'),(7047,100,'Cash Mgmt'),(7047,999,'Head Office'),(7056,0,'Head Office'),(7056,1,'Head Office'),(7056,2,'City Office'),(7056,3,'Foreign'),(7056,4,'Kandy'),(7056,5,'Galle Fort'),(7056,6,'Jaffna'),(7056,7,'Matara'),(7056,8,'Matale'),(7056,9,'Galewela'),(7056,10,'Wellawatte'),(7056,11,'Kollupitiya'),(7056,12,'Kotahena'),(7056,13,'Negombo'),(7056,14,'Hikkaduwa'),(7056,15,'Hingurakgoda'),(7056,16,'Kurunegala'),(7056,17,'Old Moor Street'),(7056,18,'Maharagama'),(7056,19,'Borella'),(7056,20,'Nugegoda'),(7056,21,'Kegalle'),(7056,22,'Narahenpita'),(7056,23,'Mutuwal'),(7056,24,'Pettah'),(7056,25,'Katunayake FTZ'),(7056,26,'Wennappuwa'),(7056,27,'Galle City'),(7056,28,'Koggala'),(7056,29,'Battaramulla'),(7056,30,'Embilipitiya'),(7056,31,'Kandana'),(7056,32,'Maradana'),(7056,33,'Minuwangoda'),(7056,34,'Nuwara Eliya'),(7056,35,'Akuressa'),(7056,36,'Kalutara'),(7056,37,'Trincomalee'),(7056,38,'Panchikawatte'),(7056,39,'Keyzer Street'),(7056,40,'Aluthgama'),(7056,41,'Panadura'),(7056,42,'Kaduwela'),(7056,43,'Chilaw'),(7056,44,'Gampaha'),(7056,45,'Katugastota'),(7056,46,'Ratmalana'),(7056,47,'Kirulapona'),(7056,48,'Union Place'),(7056,49,'Ratnapura'),(7056,50,'Colombo 7'),(7056,51,'Kuliyapitiya'),(7056,52,'Badulla'),(7056,53,'Anuradhapura'),(7056,54,'Dambulla'),(7056,55,'Nattandiya'),(7056,56,'Wattala'),(7056,57,'Grandpass'),(7056,58,'Dehiwala'),(7056,59,'Moratuwa'),(7056,60,'Narammala'),(7056,61,'Vavuniya'),(7056,62,'Rajagiriya'),(7056,63,'Ambalantota'),(7056,64,'Seeduwa'),(7056,65,'Nittambuwa'),(7056,66,'Mirigama'),(7056,67,'Kadawatha'),(7056,68,'Duplication Road'),(7056,69,'Kiribathgoda'),(7056,70,'Avissawella'),(7056,71,'Ekala  (CSP)'),(7056,72,'Pettah Main Street'),(7056,73,'Peradeniya  (CSP)'),(7056,74,'Kochchikade '),(7056,75,'Homagama'),(7056,76,'Horana'),(7056,77,'Piliyandala'),(7056,78,'Thalawathugoda (C.S.P.)'),(7056,79,'Mawanella'),(7056,80,'Bandarawela'),(7056,81,'Ja-Ela'),(7056,82,'Balangoda'),(7056,83,'Nikaweratiya'),(7056,84,'Bandaragama (C.S.P.)'),(7056,85,'Yakkala'),(7056,86,'Malabe (C.S.P.)'),(7056,87,'Kohuwala - (C.S.P.)'),(7056,88,'Kaduruwela'),(7056,89,'Nawalapitiya'),(7056,93,'Mount Lavinia(C.S.P.)'),(7056,96,'Mathugama'),(7056,97,'Ambalangoda'),(7056,98,'Baddegama'),(7056,100,'Ampara'),(7056,101,'Nawala  (C.S.P.)'),(7056,102,'Gampola'),(7056,103,'Elpitiya'),(7056,104,'Kamburupitiya'),(7056,105,'Batticaloa'),(7056,106,'Bambalapitiya'),(7056,107,'Chunakkam'),(7056,108,'Nelliady'),(7056,109,'Pilimathalawa'),(7056,110,'Kekirawa'),(7056,111,'Deniyaya'),(7056,112,'Weligama'),(7056,113,'Baseline '),(7056,114,'Katubedda'),(7056,115,'Hatton'),(7056,116,'Reid Avenue'),(7056,117,'Pitakotte CSP'),(7056,118,'Negombo Extension Office'),(7056,119,'Kotikawatta'),(7056,120,'Monaragala'),(7056,121,'Kottawa'),(7056,122,'Kurunegala City Office'),(7056,123,'Tangalle'),(7056,124,'Tissamaharama'),(7056,125,'Neluwa'),(7056,126,'Chavakachcheri'),(7056,127,'Stanley Road, Jaffna '),(7056,128,'Warakapola'),(7056,129,'Udugama'),(7056,130,'Athurugiriya'),(7056,131,'Raddolugama '),(7056,132,'Boralesgamuwa CSP'),(7056,133,'Kahawatta'),(7056,134,'Delkanda '),(7056,135,'karapitiya'),(7056,136,'Welimada'),(7056,137,'Mahiyanganaya'),(7056,138,'Kalawana'),(7056,139,'Kirindiwela'),(7056,140,'Digana'),(7056,141,'Polgahawela'),(7056,142,'Boralesgamuwa'),(7056,143,'Hanwella'),(7056,144,'Pannala'),(7056,145,'Ward Place'),(7056,146,'Wadduwa'),(7056,147,'Biyagama'),(7056,148,'Puttlam'),(7056,149,'Pelmadulla'),(7056,150,'Kandy City office'),(7056,151,'Matara City office'),(7056,152,'Kalmunai'),(7056,153,'Manipay'),(7056,154,'Mannar'),(7056,155,'Kilinochchi'),(7056,156,'Atchchuvely'),(7056,157,'Thirunelvely'),(7056,158,'Eheliyagoda'),(7056,159,'Valachchenai'),(7056,160,'Wellawaya'),(7056,161,'Mawathagama'),(7056,162,'Thambuttegama'),(7056,163,'Ruwanwella'),(7056,164,'Dankotuwa'),(7056,165,'Peliyagoda CSP'),(7056,166,'Hambantota'),(7056,167,'Katubedda CSP'),(7056,168,'Eravur'),(7056,169,'Priority Banking Centre'),(7056,170,'Velanai'),(7056,171,'Vavuniya Extension Office'),(7056,172,'Akkaraipattu'),(7056,173,'Kataragama'),(7056,174,'Wariyapola'),(7056,175,'Kuruwita'),(7056,176,'Middeniya'),(7056,177,'Ganemulla'),(7056,178,'World Trade Centre'),(7056,179,'Wellawatte 2nd'),(7056,180,'Divulapitiya'),(7056,181,'Beliatta'),(7056,182,'Giriulla'),(7056,183,'Marawila '),(7056,184,'Thalawakelle'),(7056,185,'Anuradhapura New Town'),(7056,186,'Passara'),(7056,187,'Padukka '),(7056,188,'Alawwa'),(7056,189,'Panadura Extention Office'),(7056,190,'Katunayake 24/7 Centre'),(7056,193,'Kattankudy'),(7056,194,'Pottuvil'),(7056,195,'Maskeliya'),(7056,196,'Liberty Plaza CSP'),(7056,197,'Godakawela CSP'),(7056,198,'Kodikamam'),(7056,199,'Makola '),(7056,200,'Medawachchiya'),(7056,204,'SLIC- CSP'),(7056,206,'Palavi '),(7056,208,'Nawala Service Point'),(7056,209,'Maharagama Minicom'),(7056,210,'Moratuwa Minicom'),(7056,212,'Kurunegala Service Point'),(7056,213,'Ratnapura (Laugfs Super)'),(7056,216,'Ramanayake Mawatha'),(7056,217,'Kirulapone Minicom'),(7056,218,'Gampaha CSP'),(7056,219,'Akurana Service Point '),(7056,220,'Beruwala CSP'),(7056,221,'Ragama '),(7056,222,'Matara Minicom Centre'),(7056,223,'Panadura CSP'),(7056,224,'Horana Service Point'),(7056,225,'Wattala Minicom'),(7056,226,'Bokundara CSP'),(7056,227,'Katukurunda CSP'),(7056,228,'Weliweria '),(7056,229,'Mulliyawalai'),(7056,230,'Ja - Ela (K-Zone)'),(7056,234,'Kadawatha (Arpico Super)'),(7056,251,'Dehiwala Arpico Super Centre'),(7056,252,'Batharamulla Arpico Super Centre'),(7056,253,'Hydepark Arpico Service Center'),(7056,254,'Anniwatte CSP'),(7056,255,'Kundasale (Dumbara Super CSP)'),(7056,256,'Negambo Arpico Super Centre'),(7056,257,'Kiribathgoda Service Point'),(7056,258,'Holiday Banking Centre - Majestic City'),(7056,259,'Nawam Mawatha '),(7056,260,'Wattala Arpico Super Center'),(7056,261,'Nittambuwa CSP'),(7056,262,'Pelawatte CSP'),(7056,263,'Balagolla CSP'),(7056,264,'Hendala Service Point'),(7056,265,'Gelioya Service Point'),(7056,266,'Kohuwala Service Point'),(7056,267,'Kalutara (Arpico Super)'),(7056,268,'Mattegoda (Laugfs Super)'),(7056,901,'Islamic Banking Unit'),(7056,999,'Head Office'),(7074,0,'Habib Bank Ltd'),(7074,1,'Main Branch'),(7074,2,'Lake View'),(7074,3,'Kalmunai'),(7074,999,'Head Office'),(7083,1,'Aluthkade'),(7083,2,'City Office'),(7083,3,'Head Office'),(7083,4,'Head Office'),(7083,5,'Green Path'),(7083,6,'Maligawatta'),(7083,7,'Pettah'),(7083,9,'Wellawatta'),(7083,10,'Anuradhapura'),(7083,11,'Badulla'),(7083,12,'Bandarawela'),(7083,13,'Galle'),(7083,14,'Gampola'),(7083,15,'Hatton'),(7083,16,'Jaffna Metro'),(7083,17,'Kahawatte'),(7083,18,'Kandy'),(7083,19,'Kurunegala'),(7083,20,'Mannar'),(7083,21,'Maskeliya'),(7083,22,'Moratuwa'),(7083,23,'Nawalapitiya'),(7083,24,'Negombo'),(7083,25,'Nittambuwa'),(7083,26,'Nochchiyagama'),(7083,27,'Nugegoda'),(7083,28,'Nuwara Eliya'),(7083,29,'Pussellawa'),(7083,30,'Ratnapura'),(7083,31,'Trincomalee'),(7083,32,'Vavuniya'),(7083,33,'Welimada'),(7083,34,'Kalutara'),(7083,35,'Wattala'),(7083,36,'Sri Jay\'awardanapura Kotte'),(7083,38,'Piliyandala'),(7083,39,'Bambalapitiya'),(7083,40,'Chilaw'),(7083,41,'Kegalle'),(7083,42,'Matara'),(7083,43,'Kirulapone'),(7083,44,'Polonnaruwa'),(7083,45,'Ambalantota'),(7083,46,'Grandpass'),(7083,47,'Biyagama'),(7083,48,'Dambulla'),(7083,49,'Katunayake'),(7083,50,'Embilipitiya'),(7083,51,'Gampaha'),(7083,52,'Horana'),(7083,53,'Monaragala'),(7083,54,'International Division'),(7083,55,'Borella'),(7083,56,'Kiribathgoda'),(7083,57,'Batticaloa'),(7083,58,'Ampara'),(7083,59,'Panchikawatta'),(7083,60,'Bogawanthalawa'),(7083,61,'Mount Lavinia'),(7083,63,'Hulftsdorp'),(7083,64,'Maharagama'),(7083,65,'Matale'),(7083,66,'Pinnawala'),(7083,67,'Suriyawewa'),(7083,68,'Hambantota'),(7083,69,'Panadura'),(7083,70,'Dankotuwa'),(7083,71,'Balangoda'),(7083,72,'Sea Street'),(7083,73,'Moratumulla'),(7083,74,'Kuliyapitiya'),(7083,75,'Buttala'),(7083,76,'Cinnamon Gardens'),(7083,77,'Homagama'),(7083,78,'Akkaraipattu'),(7083,79,'Marandagahamula'),(7083,80,'Marawila'),(7083,81,'Ambalangoda'),(7083,82,'Kaduwela'),(7083,83,'Puttalam'),(7083,84,'Kadawatha'),(7083,85,'Talangama'),(7083,86,'Tangalle'),(7083,87,'Ja-Ela'),(7083,88,'Thambuttegama'),(7083,89,'Mawanella'),(7083,90,'Tissamaharama'),(7083,91,'Kalmunai'),(7083,92,'Thimbirigasyaya'),(7083,93,'Dehiwala'),(7083,94,'Minuwangoda'),(7083,95,'Kantale'),(7083,96,'Kotahena'),(7083,97,'Mutwal'),(7083,98,'Kottawa'),(7083,99,'Kirindiwela'),(7083,100,'Katugastota'),(7083,101,'Pelmadulla'),(7083,102,'Ragama'),(7083,103,'Dematagoda'),(7083,104,'Narahenpita'),(7083,105,'Treasury Division'),(7083,106,'Wellawaya'),(7083,107,'Elpitiya'),(7083,108,'Maradana'),(7083,109,'Aluthgama'),(7083,110,'Wennappuwa'),(7083,111,'Avissawella'),(7083,112,'Boralesgamuwa'),(7083,113,'Card Centre'),(7083,114,'Central Colombo'),(7083,115,'Kollupitiya'),(7083,117,'Chunnakam'),(7083,118,'Nelliady'),(7083,119,'Kandana'),(7083,120,'Deniyaya Customer Centre'),(7083,121,'Nikaweratiya'),(7083,122,'Delgoda'),(7083,123,'Alawwa'),(7083,124,'Mahiyanganaya'),(7083,125,'Mathugama'),(7083,126,'Warakapola'),(7083,127,'Middeniya'),(7083,128,'Galgamuwa'),(7083,129,'Kohuwela'),(7083,130,'Weliweriya'),(7083,131,'Hendala'),(7083,132,'Point Pedro'),(7083,133,'Norochchole'),(7083,134,'Thirukovil'),(7083,135,'Eravur'),(7083,136,'Ganemulla'),(7083,137,'Chavakachcheri'),(7083,138,'Kelaniya'),(7083,139,'Hanwella'),(7083,140,'Padukka'),(7083,141,'Pilimatalawa'),(7083,142,'Thalawathugoda'),(7083,143,'Medawachchiya'),(7083,144,'Thirunelvely'),(7083,145,'Negombo Metro'),(7083,146,'Kilinochchi South'),(7083,147,'Nawala'),(7083,148,'Giriulla'),(7083,149,'Galewela'),(7083,150,'Manipay'),(7083,151,'Akuressa'),(7083,152,'Hettipola'),(7083,153,'Wariyapola'),(7083,154,'Athurugiriya'),(7083,155,'Kochchikade'),(7083,156,'Malabe'),(7083,157,'Chankanai'),(7083,158,'Pottuvil'),(7083,159,'Ninthavur'),(7083,160,'Beruwela'),(7083,161,'Velanai'),(7083,162,'Rikillagaskada'),(7083,163,'Yakkala'),(7083,164,'Thandenweli'),(7083,165,'Kaluwanchikudy'),(7083,166,'Pugoda'),(7083,167,'Valachchenai'),(7083,168,'Madampe'),(7083,169,'Kinniya'),(7083,170,'Siyabalanduwa'),(7083,171,'Udappuwa'),(7083,174,'Mullipothanai'),(7083,175,'Uppuvelli'),(7083,176,'Digana'),(7083,177,'Anamaduwa'),(7083,178,'Dikwella'),(7083,179,'Medirigiriya'),(7083,180,'Mirigama'),(7083,181,'Padavi Parakramapura'),(7083,182,'Uhana'),(7083,183,'Mullativu'),(7083,184,'Karaitive'),(7083,185,'Maruthamunai'),(7083,186,'Serunuwara'),(7083,187,'Pitigala'),(7083,188,'Kundasale'),(7083,189,'Atchchuvely'),(7083,190,'Kodikamam'),(7083,191,'Muthur'),(7083,192,'Kallady'),(7083,193,'Aralaganwila'),(7083,194,'Kolonnawa'),(7083,195,'Killinochchi North'),(7083,196,'Dehiattakandiya'),(7083,197,'Kalawana'),(7083,198,'Galaha'),(7083,199,'Urubokka'),(7083,200,'Hakmana'),(7083,201,'Bandaragama'),(7083,202,'Hikkaduwa'),(7083,203,'Wadduwa'),(7083,204,'Mirihana'),(7083,205,'Mulliyawalai'),(7083,206,'Kurumankadu'),(7083,207,'Jampettah Street'),(7083,208,'Ratmalana'),(7083,209,'Seeduwa'),(7083,210,'Pamunugama'),(7083,211,'Kattankudy'),(7083,212,'Mallavi'),(7083,213,'Weligama'),(7083,214,'Veyangoda'),(7083,215,'Batapola'),(7083,216,'Yakkalamulla'),(7083,217,'Walasmulla'),(7083,218,'Gelioya'),(7083,219,'Jaffna'),(7083,220,'Passara'),(7083,221,'Pamankada'),(7083,250,'Islamic Banking Unit'),(7092,0,'Hongkong & Shanghai Bank'),(7092,1,'Head Office'),(7092,2,'Kandy'),(7092,3,'Colpetty'),(7092,4,'Wellawatte'),(7092,5,'Nugegoda'),(7092,6,'World Trade Center'),(7092,7,'Bambalapitiya'),(7092,8,'Pelawatte'),(7092,12,'Union Place'),(7092,14,'Wattala'),(7092,15,'Premier Centre'),(7092,17,'Negombo'),(7092,18,'Moratuwa'),(7092,20,'kohuwela'),(7092,21,'Jaffna'),(7092,22,'Galle'),(7092,999,'Head Office'),(7108,0,'Head Office'),(7108,1,'Head Office'),(7108,2,'Jaffna'),(7108,999,'Head Office'),(7117,0,'Head Office'),(7117,1,'Matara'),(7117,999,'Head Office'),(7135,1,'Duke Street'),(7135,2,'Matale'),(7135,3,'Kandy'),(7135,4,'International Division'),(7135,5,'Polonnaruwa'),(7135,6,'Hingurakgoda'),(7135,7,'Hambantota'),(7135,8,'Anuradhapura'),(7135,9,'Puttalam'),(7135,10,'Badulla'),(7135,11,'Bibile'),(7135,12,'Kurunegala'),(7135,13,'Galle Fort'),(7135,14,'Union Place'),(7135,15,'Ampara'),(7135,16,'Welimada'),(7135,17,'Balangoda'),(7135,18,'Gampola'),(7135,19,'Dehiwala'),(7135,20,'Mulativu'),(7135,21,'Minuwangoda'),(7135,22,'Hanguranketha'),(7135,23,'Kalmunai'),(7135,24,'Chilaw'),(7135,25,'Hyde park Corner'),(7135,26,'Gampaha'),(7135,27,'Kegalle'),(7135,28,'Kuliyapitiya'),(7135,29,'Avissawella'),(7135,30,'Jaffna Stanley Road'),(7135,31,'Kankasanthurai'),(7135,32,'Matara Uyanwatta'),(7135,33,'Queens'),(7135,34,'Negombo'),(7135,35,'Ambalangoda'),(7135,36,'Ragala'),(7135,37,'Bandarawela'),(7135,38,'Talawakele'),(7135,39,'Kalutara'),(7135,40,'Vavuniya'),(7135,41,'Horana'),(7135,42,'Kekirawa'),(7135,43,'Padaviya'),(7135,44,'Mannar'),(7135,45,'Embilipitiya'),(7135,46,'Mudalige Mawatha'),(7135,47,'Yatiyantota'),(7135,48,'Kilinochchi'),(7135,49,'Homagama'),(7135,51,'Kahatagasdigiliya'),(7135,52,'Maho'),(7135,53,'Nawalapitiya'),(7135,54,'Warakapola'),(7135,55,'Kelaniya'),(7135,56,'Sri Sangaraja Mawatha'),(7135,57,'Peradeniya'),(7135,58,'Mahiyangana'),(7135,59,'Polgahawela'),(7135,60,'Morawaka'),(7135,61,'Tissamaharama'),(7135,62,'Wellawaya'),(7135,63,'Akkaraipattu'),(7135,64,'Samanthurai'),(7135,65,'Kattankudy'),(7135,66,'Trincomalee'),(7135,67,'Tangalle'),(7135,68,'Monaragala'),(7135,69,'Mawanella'),(7135,70,'Mathugama'),(7135,71,'Dematagoda'),(7135,72,'Ambalantota'),(7135,73,'Elpitiya'),(7135,74,'Wattegama'),(7135,75,'Batticaloa'),(7135,76,'Wennappuwa'),(7135,77,'Weligama'),(7135,78,'Borella'),(7135,79,'Veyangoda'),(7135,80,'Ratmalana'),(7135,81,'Ruwanwella'),(7135,82,'Narammala'),(7135,83,'Nattandiya'),(7135,84,'Aluthgama'),(7135,85,'Eheliyagoda'),(7135,86,'Thimbirigasyaya'),(7135,87,'Baddegama'),(7135,88,'Ratnapura'),(7135,89,'Katugastota'),(7135,90,'Kantale'),(7135,91,'Moratuwa'),(7135,92,'Giriulla'),(7135,93,'Pugoda'),(7135,94,'Kinniya'),(7135,95,'Muttur'),(7135,96,'Medawachchiya'),(7135,97,'Gangodawila'),(7135,98,'Kotikawatte'),(7135,100,'Marandagahamula'),(7135,101,'Rambukkana'),(7135,102,'Valaichechenai'),(7135,103,'Piliyandala'),(7135,104,'Jaffna Main Street'),(7135,105,'Kayts'),(7135,106,'Nelliady'),(7135,107,'Atchchuvely'),(7135,108,'Chankanai'),(7135,109,'Chunnakam'),(7135,110,'Chavakachcheri'),(7135,111,'Paranthan'),(7135,112,'Teldeniya'),(7135,113,'Batticaloa Town'),(7135,114,'Galagedera'),(7135,115,'Galewela'),(7135,116,'Passara'),(7135,117,'Akuressa'),(7135,118,'Delgoda'),(7135,119,'Narahenpita'),(7135,120,'Walasmulla'),(7135,121,'Bandaragama'),(7135,122,'Wilgamuwa'),(7135,123,'Eravur'),(7135,124,'Nikeweratiya'),(7135,125,'Kalpitiya'),(7135,126,'Grandpass'),(7135,127,'Nildandahinna.'),(7135,128,'Ratthota'),(7135,129,'Rakwana'),(7135,130,'Hakmana'),(7135,131,'Udugama'),(7135,132,'Deniyaya'),(7135,133,'Kamburupitiya'),(7135,134,'Nuwara Eliya'),(7135,135,'Dickwella'),(7135,136,'Hikkaduwa'),(7135,137,'Makandura'),(7135,138,'Dambulla'),(7135,139,'Pettah'),(7135,140,'Hasalaka'),(7135,141,'Velvetiturai'),(7135,142,'Kochchikade'),(7135,143,'Suduwella'),(7135,144,'Hettipola'),(7135,145,'Wellawatte'),(7135,146,'Naula'),(7135,147,'Buttala'),(7135,148,'Panadura'),(7135,149,'Alawwa'),(7135,150,'Kebithigollawa'),(7135,151,'Diyatalawa'),(7135,152,'Matara Dharmapala Mawatha'),(7135,153,'Akurana'),(7135,154,'Balapitiya'),(7135,155,'Kahawatte'),(7135,156,'Uva-Paranagama'),(7135,157,'Menikhinna'),(7135,158,'Senkadagala'),(7135,159,'Kadugannawa'),(7135,160,'Pelmadulla'),(7135,161,'Bulathsinhala'),(7135,162,'Jaffna University'),(7135,163,'Wariyapola'),(7135,164,'Potuvil'),(7135,165,'Mankulam'),(7135,166,'Murunkan'),(7135,167,'Town Hall, Colombo'),(7135,168,'Kataragama'),(7135,169,'Galle Main Street'),(7135,170,'Eppawela'),(7135,171,'Nochchiyagama'),(7135,172,'Bingiriya'),(7135,173,'Pundaluoya'),(7135,174,'Nugegoda'),(7135,175,'Kandana'),(7135,176,'Mid City'),(7135,177,'Galenbindunuwewa'),(7135,178,'Maskeliya'),(7135,179,'Galnewa'),(7135,180,'Deraniyagala'),(7135,181,'Maha - Oya'),(7135,183,'Ankumbura'),(7135,184,'Galgamuwa'),(7135,185,'Galigamuwa'),(7135,186,'Hatton'),(7135,188,'Ahangama'),(7135,189,'Uhana'),(7135,190,'Kaluwanchikudy'),(7135,191,'Malwana'),(7135,192,'Nivitigala'),(7135,193,'Ridigama'),(7135,194,'Kolonnawa'),(7135,195,'Haldummulla'),(7135,196,'Kaduwela'),(7135,197,'Uragasmanhandiya'),(7135,198,'Mirigama'),(7135,199,'Mawathagama'),(7135,200,'Majestic City'),(7135,201,'Ukuwela'),(7135,202,'Kirindiwela'),(7135,203,'Habarana'),(7135,204,'Head Quarters'),(7135,205,'Angunakolapalessa'),(7135,206,'Davulagala'),(7135,207,'Ibbagamuwa'),(7135,208,'Battaramulla'),(7135,209,'Boralanda'),(7135,210,'Kollupitiya Co-op House'),(7135,211,'Panwila'),(7135,214,'Mutuwal'),(7135,215,'Madampe'),(7135,216,'Haputale'),(7135,217,'Mahara'),(7135,218,'Horowpathana'),(7135,219,'Tambuttegama'),(7135,220,'Anuradhapura-Nuwarawewa'),(7135,221,'Hemmathagama'),(7135,222,'Wattala'),(7135,223,'Karaitivu'),(7135,224,'Thirukkovil'),(7135,225,'Haliela'),(7135,226,'Kurunegala Maliyadeva'),(7135,227,'Chenkalady'),(7135,228,'Addalachchene'),(7135,229,'Hanwella'),(7135,230,'Tanamalwila'),(7135,231,'Medirigiriya'),(7135,232,'Polonnaruwa Town'),(7135,233,'Serunuwara'),(7135,234,'Batapola'),(7135,235,'Kalawana'),(7135,236,'Maradana'),(7135,237,'Kiribathgoda'),(7135,238,'Gonagaldeniya'),(7135,239,'Ja Ela'),(7135,240,'Keppetipola'),(7135,241,'Pallepola'),(7135,242,'Bakamuna'),(7135,243,'Devinuwara'),(7135,244,'Beliatta'),(7135,245,'Godakawela'),(7135,246,'Meegalewa'),(7135,247,'Imaduwa'),(7135,248,'Aranayake'),(7135,249,'Neboda'),(7135,250,'Kandeketiya'),(7135,251,'Lunugala'),(7135,252,'Bulathkohupitiya'),(7135,253,'Aralaganwila'),(7135,254,'Welikanda'),(7135,255,'Trincomalee Town'),(7135,256,'Pilimatalawa'),(7135,257,'Deltota'),(7135,258,'Medagama'),(7135,259,'Kehelwatte'),(7135,260,'Koslanda'),(7135,261,'Pelawatte'),(7135,262,'Wadduwa'),(7135,263,'Kuruwita'),(7135,264,'Suriyawewa'),(7135,265,'Middeniya'),(7135,266,'Kiriella'),(7135,267,'Anamaduwa'),(7135,268,'Girandurukotte'),(7135,269,'Badulla-Muthiyangana'),(7135,270,'Thulhiriya'),(7135,271,'Urubokka'),(7135,272,'Talgaswela'),(7135,273,'Kadawatha'),(7135,274,'Pussellawa'),(7135,275,'Olcott Mawatha'),(7135,276,'Katunayake'),(7135,277,'Sea Street'),(7135,278,'Nittambuwa'),(7135,279,'Pitakotte'),(7135,280,'Pothuhera'),(7135,281,'Kobeigane'),(7135,282,'Maggona'),(7135,283,'Baduraliya'),(7135,284,'Jaffna Kannathiddy'),(7135,285,'Point Pedro'),(7135,288,'Kudawella'),(7135,289,'Kaltota'),(7135,290,'Moratumulla'),(7135,291,'Dankotuwa'),(7135,292,'Udapussellawa'),(7135,293,'Dehiowita'),(7135,294,'Alawathugoda'),(7135,295,'Udawalawe'),(7135,296,'Nintavur'),(7135,297,'Dam Street'),(7135,298,'Ginthupitiya'),(7135,299,'Kegalle Bazaar'),(7135,300,'Ingiriya'),(7135,301,'Galkiriyagama'),(7135,302,'Ginigathhena'),(7135,303,'Mahawewa'),(7135,304,'Walasgala'),(7135,306,'Maharagama'),(7135,307,'Gandara'),(7135,308,'Kotahena'),(7135,309,'Liberty Plaza'),(7135,310,'Bambalapitiya'),(7135,311,'Beruwala'),(7135,312,'Malwatta Road'),(7135,313,'Katubedda'),(7135,315,'Talawa'),(7135,316,'Ragama'),(7135,317,'Ratnapura Town'),(7135,318,'Pamunugama'),(7135,319,'Kirulapana'),(7135,320,'Borella Town'),(7135,321,'Panadura Town'),(7135,322,'Marawila'),(7135,324,'Seeduwa'),(7135,325,'Wanduramba'),(7135,326,'Capricon'),(7135,327,'Kesbewa'),(7135,328,'Kottawa'),(7135,329,'Koggala'),(7135,330,'Dehiattakandiya'),(7135,331,'Lucky Plaza'),(7135,332,'Ganemulla'),(7135,333,'Yakkala'),(7135,334,'Kurunegala-Ethugalpura'),(7135,335,'Nugegoda City'),(7135,336,'Mount Lavinia'),(7135,337,'Dehiwela (Galle Rd.)'),(7135,338,'Sainthamaruthu'),(7135,339,'Kallar'),(7135,340,'Oddamavady'),(7135,341,'Hataraliyadda'),(7135,342,'Kokkaddicholai'),(7135,343,'Karapitiya'),(7135,344,'Melsiripura'),(7135,345,'Ranna'),(7135,346,'Maruthamunai'),(7135,347,'Badalkubura'),(7135,348,'Boralesgamuwa'),(7135,349,'Pallebedda'),(7135,350,'Weeraketiya'),(7135,351,'Thambala'),(7135,352,'Pulmudai'),(7135,353,'Rikillagaskada'),(7135,354,'Bogawanthalawa'),(7135,355,'Kotiyakumbura'),(7135,356,'Cheddikulam'),(7135,357,'Kandy City Centre'),(7135,358,'Poojapitiya'),(7135,600,'Card Center'),(7135,796,'Overseas Customers Unit'),(7135,999,'CCD'),(7144,0,'Head Office'),(7144,1,'Head Office'),(7144,2,'Kandy'),(7144,3,'Jaffna'),(7144,32,'Kohuwala'),(7144,999,'Head Office'),(7162,0,'Central Clearing'),(7162,1,'NTB.Head Office,'),(7162,2,'Colpetty'),(7162,3,'Sri Sangharaja Mw.'),(7162,4,'Kandy'),(7162,5,'Wellawatte'),(7162,6,'Corporate'),(7162,7,'Negombo(C.S.P.)'),(7162,8,'Pettah'),(7162,9,'Mahabage'),(7162,10,'Battaramulla'),(7162,11,'Dharmapala Mawatha'),(7162,12,'Kurunegala'),(7162,13,'Maharagama'),(7162,14,'Moratuwa'),(7162,15,'Borella'),(7162,16,'Kiribathgoda'),(7162,17,'Panadura'),(7162,18,'Gampaha'),(7162,19,'Kotahena'),(7162,20,'Ward Place'),(7162,21,'Kadawatha'),(7162,22,'Crescat'),(7162,23,'Dehiwala'),(7162,24,'Nawam Mawatha'),(7162,25,'Havelock Town'),(7162,26,'Peradeniya'),(7162,27,'Nawala'),(7162,28,'Matara'),(7162,29,'Galle'),(7162,30,'Thalawathugoda'),(7162,31,'Homagama'),(7162,32,'Bandarawela'),(7162,33,'Vavuniya'),(7162,34,'Batticaloa'),(7162,35,'Jaffna'),(7162,36,'Horana'),(7162,37,'Kalmunai'),(7162,38,'Malabe'),(7162,39,'Anuradhapura'),(7162,40,'Piliyandala'),(7162,41,'Ratnapura'),(7162,42,'Nuwara Eliya'),(7162,43,'Chilaw'),(7162,44,'Nelliady'),(7162,45,'Kaduruwela'),(7162,46,'Pettah Second'),(7162,47,'Aluthgama'),(7162,48,'Wennappuwa'),(7162,49,'Trincomalee'),(7162,55,'Kuliyapitiya'),(7162,56,'Ambalangoda'),(7162,57,'Akkaraipattu'),(7162,58,'Hambantota'),(7162,59,'Badulla'),(7162,60,'Ja-Ela'),(7162,61,'Embilipitiya'),(7162,62,'Ambalantota'),(7162,63,'Akuressa'),(7162,64,'Balangoda'),(7162,65,'Deniyaya'),(7162,66,'Matugama'),(7162,69,'Katugastota'),(7162,71,'Old Moor Street'),(7162,72,'Bandaragama'),(7162,400,'Card Center'),(7162,500,'Liberty Plaza'),(7162,501,'Wattala'),(7162,502,'Mount Lavinia'),(7162,503,'Nugegoda'),(7162,504,'Kohuwala'),(7162,999,'Head Office'),(7205,0,'Head Office'),(7205,1,'Main Branch'),(7205,999,'Head Office'),(7214,0,'Head Office'),(7214,1,'Navam Mawatha'),(7214,2,'Kandy'),(7214,3,'Jawatta'),(7214,4,'Nugegoda'),(7214,5,'Rajagiriya'),(7214,6,'Matara'),(7214,7,'Kurunegala'),(7214,8,'Wellawatte'),(7214,9,'Negombo'),(7214,10,'Chilaw'),(7214,11,'Wattala'),(7214,12,'Maharagama'),(7214,13,'Ratnapura'),(7214,14,'Head Office'),(7214,15,'Moratuwa'),(7214,16,'Kalutara'),(7214,17,'Kegalle'),(7214,18,'Badulla'),(7214,19,'Anuradhapura'),(7214,20,'Mount Lavinia'),(7214,21,'Galle'),(7214,22,'Pelawatte'),(7214,23,'Piliyandala'),(7214,24,'Kotahena'),(7214,25,'Kiribathgoda'),(7214,26,'Kadawatha'),(7214,27,'Horana'),(7214,28,'Kandana'),(7214,29,'Gampaha'),(7214,30,'Homagama'),(7214,31,'Malabe'),(7214,32,'Kohuwala'),(7214,33,'Puttalam'),(7214,34,'Awissawella'),(7214,35,'Panadura'),(7214,36,'Wennappuwa'),(7214,37,'Jaffna'),(7214,38,'Trincomalee'),(7214,39,'Batticaloa'),(7214,40,'Ampara'),(7214,41,'Vavuniya'),(7214,42,'Kuliyapitiya'),(7214,43,'Pettah'),(7214,44,'Ja Ela'),(7214,45,'Matugama'),(7214,46,'Matale'),(7214,47,'Wariyapola'),(7214,48,'Ambalangoda'),(7214,49,'Ambalantota'),(7214,50,'Pilimatalawa'),(7214,51,'Gampola'),(7214,52,'Bandarawela'),(7214,53,'Borella'),(7214,54,'kalmunai'),(7214,55,'Nittambuwa'),(7214,56,'Kaduwela'),(7214,57,'Hambantota'),(7214,58,'Embilipitiya'),(7214,59,'Aluthgama'),(7214,60,'Kaduruwela'),(7214,61,'Nawalapitiya'),(7214,62,'Chunnakam'),(7214,63,'Minuwangoda'),(7214,64,'Dambulla'),(7214,65,'Akuressa'),(7214,66,'Nelliady'),(7214,67,'Elpitiya'),(7214,68,'Yakkala'),(7214,69,'Nikaweratiya'),(7214,70,'Monaragala'),(7214,71,'Athurugiriya'),(7214,72,'Boralesgamuwa'),(7214,73,'Ratmalana'),(7214,74,'Narahenpita'),(7214,75,'Mahiyangana'),(7214,76,'Nuwara Eliya'),(7214,78,'Eheliyagoda'),(7214,100,'Head Office(Retail)'),(7214,900,'Head Office(Corporare)'),(7214,999,'Head Office'),(7269,0,'Middle East Bank'),(7269,1,'Head Office'),(7269,2,'Pettah'),(7269,3,'Maradana'),(7269,4,'Islamic Banking Unit'),(7269,5,'Wellawatte'),(7269,6,'Kandy'),(7269,7,'Batticaloa'),(7269,8,'Galle'),(7269,999,'Head Office'),(7278,1,'City Office'),(7278,2,'Pettah'),(7278,3,'Nugegoda'),(7278,4,'Borella'),(7278,5,'Kiribathgoda'),(7278,6,'Kurunegala'),(7278,7,'Kandy'),(7278,8,'Wattala'),(7278,9,'Nawam Mawatha'),(7278,10,'Matara'),(7278,11,'Bambalapitiya'),(7278,12,'Fort'),(7278,13,'Maharagama'),(7278,14,'Deniyaya'),(7278,15,'Morawaka'),(7278,16,'Gampaha'),(7278,17,'Dehiwala'),(7278,18,'Ratmalana'),(7278,19,'Piliyandala'),(7278,20,'Eheliyagoda'),(7278,21,'Anuradhapura'),(7278,22,'Avissawella'),(7278,23,'Kuliyapitiya'),(7278,24,'Negombo'),(7278,25,'Matale'),(7278,26,'Panadura'),(7278,27,'Old Moor Street'),(7278,28,'Tissamaharama'),(7278,29,'Corporate'),(7278,30,'Wennappuwa'),(7278,31,'Moratuwa'),(7278,32,'Katugastota'),(7278,33,'Rathnapura'),(7278,34,'Thimbirigasyaya'),(7278,35,'Galle'),(7278,36,'Wellawatte Super'),(7278,37,'Kotahena'),(7278,38,'Kaduruwela'),(7278,39,'Malabe'),(7278,40,'Narahenpita'),(7278,41,'Kalawana'),(7278,42,'Main Street'),(7278,43,'Embilipitiya'),(7278,44,'Wariyapola (PBC)'),(7278,45,'Wellampitiya (PBC)'),(7278,46,'Bandarawela'),(7278,47,'Panadura Wekada'),(7278,48,'Thambuttegama (PBC)'),(7278,49,'Deraniyagala PBC'),(7278,50,'Kalutara'),(7278,51,'Peradeniya PBC'),(7278,52,'Kottawa PBC'),(7278,53,'Alawwa PBC'),(7278,54,'Neluwa PBC'),(7278,55,'Vavunia'),(7278,56,'Mahiyanganaya'),(7278,57,'Horana'),(7278,58,'Harbour-View PBC'),(7278,59,'Bandaragama'),(7278,60,'Kadawatha'),(7278,61,'Battaramulla'),(7278,62,'Ampara'),(7278,63,'Pelawatte PBC'),(7278,64,'Kegall'),(7278,65,'Minuwangoda'),(7278,66,'Trincomalee'),(7278,67,'Athurugiriya PBC'),(7278,68,'Yakkala PBC'),(7278,69,'Homagama'),(7278,70,'Gregorys Road PBC'),(7278,71,'Nittambuwa'),(7278,72,'Ambalongoda'),(7278,73,'Ragama PBC'),(7278,74,'Monaragala'),(7278,75,'Wadduwa PBC'),(7278,76,'Kandana'),(7278,77,'veyangoda PBC'),(7278,78,'Ganemulla PBC'),(7278,79,'Aluthgama'),(7278,80,'Hatton'),(7278,81,'Welimada'),(7278,82,'Nawala'),(7278,83,'Kirindiwela PBC'),(7278,84,'Nuwara Eliya'),(7278,85,'Digana PBC'),(7278,86,'Mirigama'),(7278,87,'Kottawa Laugfs Sun Up'),(7278,88,'Negombo 2nd'),(7278,89,'Attidiya'),(7278,90,'Dambulla'),(7278,91,'Pitakotte'),(7278,92,'Singer Mega-Maharagama'),(7278,93,'Badulla'),(7278,94,'Kohuwela'),(7278,95,'Giriulla'),(7278,96,'Hendala'),(7278,97,'Balangoda'),(7278,98,'Ja-Ela'),(7278,99,'Narammala'),(7278,100,'Kandy Metro'),(7278,101,'Gampola'),(7278,102,'Nikaweratiya'),(7278,103,'Pelmadulla'),(7278,104,'Ambalantota'),(7278,105,'Wattegama'),(7278,106,'Matugama'),(7278,107,'Batticaloa'),(7278,108,'Chilaw'),(7278,109,'Mawathagama'),(7278,110,'Hingurakgoda'),(7278,111,'Akkaraipattu'),(7278,112,'Kalmunai'),(7278,113,'Wellawaya'),(7278,114,'Embuldeniya'),(7278,115,'Kattankudy'),(7278,116,'Tangalle'),(7278,117,'Kirulapone'),(7278,118,'Baddegama'),(7278,119,'Mannar'),(7278,120,'Jaffna'),(7278,121,'Chenkalady'),(7278,122,'Rajagiriya'),(7278,123,'Kandy City Centre'),(7278,124,'Oddamavady'),(7278,125,'Kaluwanchikudy'),(7278,126,'Sainthamaruthu'),(7278,127,'Grandpass'),(7278,128,'Chunnakam'),(7278,129,'Nelliady'),(7278,130,'Pottuvil'),(7278,131,'Platinum Plus'),(7278,132,'Nattandiya'),(7278,133,'Kundasale'),(7278,134,'Kollupitiya'),(7278,135,'Gangodawila'),(7278,136,'Peliyagoda'),(7278,137,'Hanwella'),(7278,138,'Nochchiyagama'),(7278,139,'2nd Branch Batticaloa'),(7278,140,'Ingiriya'),(7278,141,'Karapitiya'),(7278,142,'Boralesgamuwa'),(7278,143,'Anamabuwa'),(7278,144,'Maradana'),(7278,145,'Buttala'),(7278,146,'Passara'),(7278,147,'Manipay'),(7278,148,'Kilinochchi'),(7278,149,'Kekirawa'),(7278,150,'Pilimatalawa'),(7278,151,'Keselwatta'),(7278,152,'Pussellawa'),(7278,153,'Matara Bazaar'),(7278,154,'Aralangawila'),(7278,155,'Moratumulla'),(7278,156,'Puttalam'),(7278,157,'Sooriyawewa'),(7278,158,'Middeniya'),(7278,159,'Galle Bazaar'),(7278,160,'Mawanella'),(7278,161,'Bibile'),(7278,162,'Kaduwela'),(7278,163,'Rikillagaskada'),(7278,164,'Chankanai'),(7278,165,'Kochchikade'),(7278,166,'Pannala'),(7278,167,'Dehiattakandiya'),(7278,168,'Anuradhapura New Town'),(7278,169,'Chavakachcheri'),(7278,170,'Vavuniya Super'),(7278,171,'Kayts'),(7278,172,'Kantale'),(7278,173,'Gothatuwa New Town'),(7278,174,'Mallavi'),(7278,175,'Colombo Super'),(7278,176,'Mattegoda'),(7278,177,'Kinniya'),(7278,178,'Thalawathugoda'),(7278,179,'Akuressa'),(7278,180,'Beliatta'),(7278,181,'Habaraduwa'),(7278,182,'Ahangama'),(7278,183,'Marandagahamula'),(7278,184,'Menikhinna'),(7278,185,'Ninthavur'),(7278,186,'Thirunelvely'),(7278,187,'Hettipola'),(7278,188,'Rambukkana'),(7278,189,'Madampe'),(7278,190,'Galewela'),(7278,191,'Maligawatte'),(7278,192,'Padukka'),(7278,193,'Mutwal'),(7278,194,'Marawila'),(7278,195,'Nawalapitiya'),(7278,196,'Dankotuwa'),(7278,197,'Maho'),(7278,198,'Divulapitiya'),(7278,199,'Mount Lavinia'),(7278,200,'Kiribathgoda'),(7278,201,'Ruwanwella'),(7278,202,'Delgoda'),(7278,203,'Kahatagasdigiliya'),(7278,204,'Elpitiya'),(7278,205,'Warakapola'),(7278,206,'Kaburupitiya'),(7278,207,'Makola'),(7278,208,'Muttur'),(7278,209,'Weligama'),(7278,210,'Karagampitiya'),(7278,224,'Kasbawa'),(7278,929,'Sampath Viswa'),(7278,993,'Central Clearing Department'),(7278,996,'Card Centre'),(7278,999,'Head Office'),(7287,0,'Seylan Bank Head Office'),(7287,1,'City Office'),(7287,2,'Matara'),(7287,3,'Mount Lavinia'),(7287,4,'Maharagama'),(7287,5,'Panadura'),(7287,6,'Kiribathgoda'),(7287,7,'Ratnapura'),(7287,8,'Kollupitiya'),(7287,9,'Moratuwa'),(7287,10,'Kegalle'),(7287,11,'Gampaha'),(7287,12,'Nugegoda'),(7287,13,'Negombo'),(7287,14,'Dehiwala'),(7287,15,'Chilaw'),(7287,16,'Galle'),(7287,17,'Kandy'),(7287,18,'Kurunegala'),(7287,19,'Nuwara Eliya'),(7287,20,'Balangoda'),(7287,21,'Anuradhapura'),(7287,22,'Grandpass'),(7287,23,'Horana'),(7287,24,'Ambalangoda'),(7287,25,'Gampola'),(7287,26,'Badulla'),(7287,27,'Ja-Ela'),(7287,28,'Kadawatha'),(7287,29,'Dehiattakandiya'),(7287,30,'Colombo Fort'),(7287,31,'Katunayaka'),(7287,32,'Cinnamon Gardens'),(7287,33,'Kottawa'),(7287,34,'Boralesgamuwa'),(7287,35,'Yakkala'),(7287,36,'Kalutara'),(7287,37,'Tissamaharama'),(7287,38,'Matale'),(7287,39,'Hatton'),(7287,40,'Sarikkamulla'),(7287,41,'Attidiya'),(7287,42,'Kalubowila'),(7287,43,'Homagama'),(7287,44,'Kuliyapitiya'),(7287,45,'Embilipitiya'),(7287,46,'Bandarawela'),(7287,47,'Maradana'),(7287,48,'Mawanella'),(7287,49,'Puttalam'),(7287,50,'Old Moor Street'),(7287,51,'Hingurakgoda'),(7287,52,'Nawala'),(7287,53,'Manampitiya'),(7287,54,'Bandaragama'),(7287,55,'Katuneriya'),(7287,56,'Koggala'),(7287,57,'Welimada'),(7287,58,'Kochchikade'),(7287,59,'Bogawanthalawa'),(7287,60,'Ganemulla'),(7287,61,'Kotagala Talawakale'),(7287,62,'Raddolugama'),(7287,63,'Weliveriya'),(7287,64,'Pettah'),(7287,65,'Beliatta'),(7287,66,'Mathugama'),(7287,67,'Malabe'),(7287,68,'Colombo South'),(7287,69,'Dam Street'),(7287,70,'Warakapola'),(7287,71,'Wattala'),(7287,72,'Vavuniya'),(7287,73,'Batticaloa'),(7287,74,'Kaththankudy'),(7287,75,'Awissawella'),(7287,76,'Nawalapitiya'),(7287,77,'Kekirawa'),(7287,78,'Mirigama'),(7287,79,'Soysapura'),(7287,80,'Kotiyakumbura'),(7287,81,'Hambantota'),(7287,82,'Borella'),(7287,83,'Havelock Town'),(7287,84,'Marandagahamula'),(7287,85,'Jaffna'),(7287,86,'Millenium'),(7287,87,'Ranpokunugama'),(7287,88,'Trincomalee'),(7287,89,'Meegoda'),(7287,90,'Pelmadulla.'),(7287,91,'Ampara'),(7287,92,'Nelliady'),(7287,93,'Kilinochchi'),(7287,94,'Mannar'),(7287,95,'Chavakachcheri'),(7287,96,'Mullativu'),(7287,97,'Kalmunai'),(7287,98,'Chenkalady'),(7287,99,'Piliyandala'),(7287,100,'Akuressa'),(7287,101,'Battaramulla'),(7287,102,'Kaduruwela'),(7287,103,'Dambulla'),(7287,104,'Monaragala'),(7287,105,'Ambalantota'),(7287,106,'Narammala'),(7287,107,'Mahiyanganaya'),(7287,108,'Veyangoda'),(7287,109,'Mawathagama'),(7287,110,'Pussellawa'),(7287,111,'Dummalasooriya'),(7287,112,'Godagama'),(7287,113,'Galenbidunuwewa'),(7287,114,'Pitakotte'),(7287,115,'Kanthale'),(7287,116,'Akkaraipatthu'),(7287,117,'Chankanai'),(7287,996,'Central Processing Unit'),(7287,997,'Seylan Card Centre (SCC)'),(7287,998,'Retail Remittance Center'),(7287,999,'Head Office'),(7296,0,'Head Office'),(7296,1,'Head Office'),(7296,999,'Head Office'),(7302,1,'Head Office'),(7302,999,'Head Office'),(7311,1,'Metro'),(7311,2,'Panchikawatte'),(7311,3,'Kollupitiya'),(7311,4,'Pettah'),(7311,5,'Kandy'),(7311,6,'Rajagiriya'),(7311,7,'Ratnapura'),(7311,8,'Nugegoda'),(7311,9,'Bambalapitiya'),(7311,10,'Negombo'),(7311,11,'Gampaha'),(7311,12,'Kurunegala'),(7311,13,'Matara'),(7311,14,'Kotahena'),(7311,15,'Dehiwela'),(7311,16,'Wattala'),(7311,17,'Panadura'),(7311,18,'Old Moor Street'),(7311,19,'Dam Street'),(7311,20,'Katugastota'),(7311,21,'Narahenpita'),(7311,22,'Kirulapana'),(7311,23,'Maharagama'),(7311,24,'Moratuwa'),(7311,25,'Galle'),(7311,26,'Kadawatha'),(7311,27,'Kegalle'),(7311,28,'Wennappuwa'),(7311,29,'Wellawatta'),(7311,30,'Gampola'),(7311,31,'Borella'),(7311,32,'Anuradhapura'),(7311,33,'Kalutara'),(7311,34,'Vavuniya'),(7311,35,'Malabe'),(7311,36,'Chilaw'),(7311,37,'Jaffna'),(7311,38,'Embilipitiya'),(7311,39,'Matale'),(7311,40,'Batticaloa'),(7311,41,'Ambalangoda'),(7311,42,'Kalmunai'),(7311,43,'Kilinochchi'),(7311,44,'Kandy City Centre'),(7311,45,'Badulla'),(7311,46,'Kuliyapitiya'),(7311,47,'Kalubowila'),(7311,48,'Bandarawela'),(7311,49,'Dambulla'),(7311,50,'Ratmalana'),(7311,51,'Peradeniya'),(7311,52,'Kaduruwela'),(7311,53,'Ambalanthota'),(7311,54,'Kiribathgoda'),(7311,55,'Piliyandala'),(7311,56,'Nelliady'),(7311,57,'Kanthankudy'),(7311,58,'Kundasale'),(7311,59,'Monaragala'),(7311,60,'Akkaraipaththu'),(7311,61,'Chunnakam'),(7311,62,'Balangoda'),(7311,63,'Battaramulla'),(7311,64,'Puttalama'),(7311,65,'Pilimathalawa'),(7311,66,'Ja-Ela'),(7311,67,'Kekirawa'),(7311,68,'Thalawathugoda'),(7311,69,'Minuwangoda'),(7311,70,'Warakapola'),(7311,71,'Galewela'),(7311,72,'Akuressa'),(7311,73,'Trincomalee'),(7311,74,'Tangalle'),(7311,75,'Hatton'),(7311,76,'Homagama'),(7311,77,'Horana'),(7311,999,'Head Office'),(7384,1,'Sri Lanka Branch'),(7454,1,'Head Office'),(7454,2,'Nugegoda'),(7454,3,'Malabe'),(7454,4,'Matara'),(7454,5,'Kurunegala'),(7454,6,'Katugastota'),(7454,7,'City Office'),(7454,8,'Rathnapura'),(7454,9,'Anuradhapura'),(7454,10,'Gampaha'),(7454,11,'Badulla'),(7454,12,'Borella'),(7454,14,'Kaduruwela'),(7454,15,'Bandaranayake Mawatha'),(7454,16,'Maharagama'),(7454,17,'Bandarawela'),(7454,18,'Negambo'),(7454,19,'Kottawa'),(7454,20,'Dambulla'),(7454,21,'Wattala'),(7454,22,'Kuliyapitiya'),(7454,23,'Panadura'),(7454,24,'Piliyandala'),(7454,25,'Deniyaya'),(7454,26,'Kaluthara'),(7454,27,'Kiribathgoda'),(7454,28,'Nawala'),(7454,29,'Kadawatha'),(7454,30,'Gampola'),(7454,31,'Matale'),(7454,32,'Chilaw'),(7454,33,'Wellawatte'),(7454,34,'Horana'),(7454,35,'Galle'),(7454,36,'Nuwara Eliya'),(7454,37,'Kalawana'),(7454,38,'Ambalangoda'),(7454,39,'Avissawella'),(7454,40,'Batticaloa'),(7454,41,'Ampara'),(7454,42,'Jaffna'),(7454,43,'Moratuwa'),(7454,44,'Trincomalee'),(7454,45,'Embilipitiya'),(7454,46,'Pettah'),(7454,47,'Vavuniya'),(7454,48,'Katugastota'),(7454,49,'Kegalle'),(7454,50,'Monaragala'),(7454,51,'Sainthamaruthu'),(7454,52,'Kilinochchi'),(7454,53,'Elpitiya'),(7454,54,'Akuressa'),(7454,55,'Kattankudy'),(7454,56,'Tangalle'),(7454,57,'Oddamavadi'),(7454,58,'Akkaraipattu'),(7454,59,'Chunnakam'),(7454,60,'Manipai'),(7454,61,'Nelliady'),(7454,62,'Hambantota'),(7454,63,'Ja Ela'),(7454,64,'Kotahena'),(7454,65,'Digana'),(7454,66,'Thambuttegama'),(7454,67,'Galewela'),(7454,501,'Southern Province SLP Units'),(7454,511,'Western  Province SLP Units'),(7454,521,'North Western Province SLP Units'),(7454,531,'Central Province SLP Units'),(7454,541,'Sabaragamuwa Province SLP Units'),(7454,551,'North Central  Province SLP Units'),(7454,561,'Eastern  Province SLP Units'),(7454,571,'Uva Province SLP Units'),(7454,700,'Premier Banking Centre'),(7454,999,'Head Office'),(7463,1,'Head Office'),(7463,2,'Pettah'),(7463,3,'Kandy'),(7463,4,'Kattankudy'),(7463,5,'Ladies'),(7463,6,'Kalmunai'),(7463,8,'Galle'),(7463,9,'Oddamavadi'),(7463,10,'Akurana'),(7463,11,'Gampola'),(7463,12,'Sammanthurai'),(7463,13,'Mawanella'),(7463,14,'Kurunegala'),(7463,15,'Akkaraipattu'),(7463,16,'Dehiwela'),(7463,17,'Nintavur'),(7463,18,'Kuliyapitiya'),(7463,19,'Eravur'),(7463,20,'Negombo'),(7463,21,'Badulla'),(7463,22,'Kaduruwela'),(7463,23,'Puttalam'),(7463,24,'Kinniya'),(7463,25,'Ratnapura'),(7472,2,'Colombo'),(7719,1,'Head Office'),(7719,2,'City'),(7719,3,'Galle'),(7719,4,'Matara'),(7719,5,'Anuradhapura'),(7719,6,'Jaffna'),(7719,7,'Chilaw'),(7719,8,'Kuliyapitiya'),(7719,9,'Negombo'),(7719,10,'Ratnapura'),(7719,11,'Ambalantota'),(7719,12,'Kalutara'),(7719,13,'Embilipitiya'),(7719,14,'Kekirawa'),(7719,15,'Kandy'),(7719,16,'Matale'),(7719,17,'kurunegala'),(7719,18,'Kegalle'),(7719,19,'Kilinochchi'),(7719,20,'Moratuwa'),(7719,21,'Batticaloa'),(7719,22,'Badulla'),(7719,23,'Bambalapitiya'),(7719,24,'Dehiwala'),(7719,25,'Peliyagoda'),(7719,26,'Nugegoda'),(7719,27,'Homagama'),(7719,28,'Beruwala'),(7719,29,'Wennappuwa'),(7719,30,'Ampara'),(7719,31,'Kochchikade'),(7719,32,'Point Pedro'),(7719,33,'Ambalangoda'),(7719,34,'Naththandiya'),(7719,35,'Ruwanwella'),(7719,36,'Ja-Ela'),(7719,37,'Gampaha'),(7719,39,'Devinuwara'),(7719,40,'Nikaweratiya'),(7719,41,'Mahiyanganaya'),(7719,42,'Warakapola'),(7719,43,'Panadura'),(7719,44,'Puttalama'),(7719,45,'Matugama'),(7719,46,'Monaragala'),(7719,47,'Kalmunai'),(7719,48,'Beliatta'),(7719,49,'Mannar'),(7719,50,'Nawalapitiya'),(7719,51,'Pettah'),(7719,52,'Katunayake'),(7719,53,'Maharagama'),(7719,54,'Deniyaya'),(7719,55,'Akuressa'),(7719,56,'Nuwara Eliya'),(7719,57,'Avissawella'),(7719,58,'Galnewa'),(7719,59,'Mawanella'),(7719,60,'Bandarawela'),(7719,61,'Borella'),(7719,62,'Hakmana'),(7719,63,'Horana'),(7719,64,'Narahenpita'),(7719,65,'Kollupitiya 2nd'),(7719,66,'Weligama'),(7719,67,'Kiribathgoda'),(7719,68,'Mount Lavinia'),(7719,69,'Marawila'),(7719,70,'Wellawatta'),(7719,71,'Piliyandala'),(7719,72,'Chunnakam'),(7719,73,'Chavakachcheri'),(7719,74,'Gampola'),(7719,75,'Kadawatha'),(7719,76,'Hingurakgoda'),(7719,77,'Maligawatta'),(7719,78,'Thalawakele'),(7719,79,'Mirigama'),(7719,80,'Battaramulla'),(7719,81,'Kandy 2nd'),(7719,82,'Dickwella'),(7719,83,'Mahabage'),(7719,84,'Pilimathalawa'),(7719,85,'Wattala'),(7719,86,'Kamburupitiya'),(7719,87,'Kotahena'),(7719,88,'Vavuniya'),(7719,89,'Trincomalee'),(7719,90,'Morawaka'),(7719,91,'Balangoda'),(7719,92,'Veyangoda'),(7719,93,'Katubedda'),(7719,94,'Elpitiya'),(7719,95,'Kaduwela'),(7719,96,'Divulapitiya'),(7719,97,'Tissamaharama'),(7719,98,'Minuwangoda'),(7719,99,'Kirindiwela'),(7719,100,'Nittambuwa'),(7719,101,'Welimada'),(7719,102,'Kottawa'),(7719,103,'Dambulla'),(7719,104,'Kahathuduwa'),(7719,105,'Aluthgama'),(7719,106,'Meegoda'),(7719,107,'Manipay'),(7719,108,'Thirunelvely'),(7719,109,'Chenkaladi'),(7719,110,'Uragasmanhandiya'),(7719,111,'Nawala'),(7719,112,'Deraniyagala'),(7719,113,'Hikkaduwa'),(7719,114,'Kalawanchikudy'),(7719,115,'Kalubowila'),(7719,116,'Hatton'),(7719,117,'Welikada'),(7719,118,'Samanthurai'),(7719,119,'Delkanda'),(7719,120,'Yakkala'),(7719,121,'Karapitiya'),(7719,122,'Kaduruwela'),(7719,123,'Malabe'),(7719,124,'Boralesgamuwa'),(7719,125,'Moratumulla'),(7719,126,'Bandaragama'),(7719,127,'Mulgampola'),(7719,701,'Ragama Piyasa'),(7719,702,'WTC Piyasa'),(7719,703,'Athurugiriya Piyasa'),(7719,704,'Neluwa Piyasa'),(7719,705,'Ganemulla Piyasa'),(7719,706,'Wellampitiya Piyasa'),(7719,707,'Narammala Piyasa'),(7719,708,'Bibile\"piyasa\"'),(7719,709,'Hettipola'),(7719,710,'Bulathkohupitiya'),(7719,711,'Kandy City Center'),(7719,712,'Weeraketiya NSB Piyasa'),(7719,713,'Tangalle NSB Piyasa'),(7719,714,'Walasmulla NSB Piyasa'),(7719,715,'Wadduwa NSB Piyasa'),(7719,716,'Kelaniya NSB Piyasa'),(7719,717,'Nelliady NSB Piyasa'),(7719,718,'Atchuvely NSB Piyasa'),(7719,719,'Puwakaramba Piyasa'),(7719,720,'Valaichenai Piyasa'),(7719,721,'Aranayake Piyasa'),(7719,722,'Rikillagaskada Piyasa'),(7719,723,'Katugastota Piyasa'),(7719,724,'Middeniya Piyasa'),(7719,725,'Chankanai Piyasa'),(7719,726,'Polgahawela'),(7719,727,'Arayampathy'),(7719,728,'Raddolugama'),(7719,729,'Galgamuwa'),(7719,730,'Kayts'),(7719,731,'Karainagar'),(7719,732,'Mutwal'),(7719,733,'Mulleriyawa New Town'),(7719,734,'Baddegama'),(7719,735,'Habaraduwa'),(7719,736,'Pelmadulla'),(7719,737,'Kahawatte'),(7719,738,'Bulathsinhala'),(7719,739,'Kalawana'),(7719,740,'Wellawaya'),(7719,741,'Buttala'),(7719,742,'Alawwa'),(7719,743,'Yatiyantota'),(7719,744,'Pundaluoya'),(7719,745,'Nochchiyagama'),(7719,746,'Anamaduwa'),(7719,747,'Delgoda'),(7719,748,'Digana'),(7719,749,'Mawathagama'),(7719,750,'Hanwella'),(7719,751,'Hali Ela'),(7719,752,'Akkaraipattu'),(7719,753,'Palugamam'),(7719,754,'Sooriyawewa'),(7719,755,'Galewela'),(7719,756,'Tambuttegama'),(7719,757,'Imaduwa'),(7719,758,'Passara'),(7719,759,'Kahatagasdigiliya'),(7719,760,'Angunakolapelessa'),(7719,761,'Madampe'),(7719,762,'Kantale'),(7719,763,'Medawachchiya'),(7719,764,'Ingiriya'),(7719,765,'Rambukkana'),(7719,766,'Wariyapola'),(7719,767,'Kebithigollawa'),(7719,768,'Wattegama'),(7719,769,'Pussellawa'),(7719,770,'Pothuvil'),(7719,771,'Ibbagamuwa'),(7719,772,'Kuruwita'),(7719,773,'Vankalai'),(7719,774,'Mallavi'),(7719,775,'Kekanadura'),(7719,776,'Medirigiriya'),(7719,777,'Nivithigala'),(7719,778,'Kiriella'),(7719,779,'Naula'),(7719,780,'Melsiripura'),(7719,781,'Hambantota'),(7719,782,'Rideegama'),(7719,783,'Deltota'),(7719,784,'Ginigathhena'),(7719,785,'Bingiriya'),(7719,786,'Baduraliya'),(7719,787,'Giriulla'),(7719,788,'Eppawala'),(7719,789,'Thalawathugoda'),(7719,790,'Pugoda'),(7719,791,'Gelioya'),(7719,901,'PBU - Head Office'),(7719,902,'PBU - Kandy'),(7719,903,'PBU - Galle'),(7719,904,'PBU - Matara'),(7719,905,'PBU - Kegalle'),(7719,906,'PBU - Anuradhapura'),(7719,907,'PBU - Kalutara'),(7719,908,'PBU - Gampaha'),(7719,909,'PBU - Ampara'),(7719,910,'Credit Division, (H.L Division)'),(7719,911,'IBU (NRFC)'),(7719,912,'Br. Management Division'),(7719,915,'PBU - Kurunegala'),(7719,916,'PBU - Jaffna'),(7719,917,'PBU - Eheliyagoda'),(7728,1,'1st Colombo City'),(7728,2,'Kegalle'),(7728,3,'Battaramulla'),(7728,4,'Embilipitiya'),(7728,5,'Horana'),(7728,6,'Kiribathgoda'),(7728,7,'Karapitiya'),(7728,8,'Akurassa'),(7728,9,'Matale'),(7728,10,'Kandy'),(7728,11,'Chilaw'),(7728,12,'Vavuniya'),(7728,13,'Manaragala'),(7728,14,'Ruwanwella'),(7728,15,'Rathnapura'),(7728,16,'Warakapola'),(7728,17,'Anuradhapura'),(7728,18,'Sahasapura'),(7728,19,'Rikillagaskada'),(7728,20,'Kurunegala'),(7728,21,'Trincomalle'),(7728,22,'Kalmuani'),(7728,23,'Ambalanthota'),(7728,25,'Kalutara'),(7728,26,'Kuliyapitiya'),(7728,27,'Negombo'),(7728,28,'Polonnaruwa'),(7728,29,'Batticaloa'),(7728,30,'Ambalangoda'),(7728,31,'Matara'),(7728,32,'Galle'),(7728,33,'Giriulla'),(7728,34,'Rambukkana'),(7728,35,'Dambulla'),(7728,36,'Thambuththegama'),(7728,37,'Maho'),(7728,38,'Wennappuwa'),(7728,39,'Ampara'),(7728,40,'Medawachchiya'),(7728,41,'Muthur'),(7728,42,'Jaffna'),(7728,43,'Nanatan'),(7728,44,'Badulla'),(7728,45,'Pottuvil'),(7728,46,'Mapalagama'),(7728,47,'Mathugama'),(7728,48,'Gampola'),(7728,49,'Deniyaya'),(7728,50,'Anamaduwa'),(7728,51,'Angunakolapalassa'),(7728,52,'Aralaganvila'),(7728,53,'Galenbidunuwewa'),(7728,54,'Wariyapola'),(7728,55,'Pilimathalawa'),(7728,56,'Kirulapona'),(7728,57,'Deraniyagala'),(7728,58,'Dehiattakandiya'),(7728,59,'Kalawanchikudi'),(7728,60,'Samanthurei'),(7728,61,'Siyabalanduwa'),(7728,62,'Buttala'),(7728,63,'Valachchena'),(7728,64,'Elpitiya'),(7728,65,'Nochchiyagama'),(7728,66,'Yakkalamulla'),(7728,67,'Katuwana'),(7728,68,'Mawanella'),(7728,69,'Kilinochchi'),(7728,70,'Padavi Parakramapura'),(7728,71,'Kekirawa'),(7728,72,'Uhana'),(7728,73,'Kanthale'),(7728,74,'Akkeripattu'),(7728,75,'Moratuwa'),(7728,76,'Hatharaliyadda'),(7728,77,'Hingurna'),(7728,78,'Kaduwela'),(7728,79,'Narammala'),(7728,80,'Aluthgama'),(7728,81,'Maharagama'),(7728,82,'Gampaha'),(7728,999,'Sanasa Development Bank Head Office'),(7737,1,'Head Office'),(7737,12,'Ratnapura'),(7737,260,'Piliyandala'),(7746,1,'Head Office'),(7746,2,'Moratuwa'),(7746,3,'Negombo'),(7746,4,'Kurunegala'),(7746,5,'Kelaniya'),(7746,6,'Kandy'),(7746,7,'Gampaha'),(7746,8,'Rathnapura'),(7746,9,'Badulla'),(7746,10,'Chilaw'),(7746,11,'Anuradhapura'),(7746,12,'Wellawatta'),(7746,13,'Wattala'),(7746,14,'Ja-Ela'),(7746,15,'Kaduwela'),(7746,16,'Kegalle'),(7746,17,'Nittambuwa'),(7746,18,'Wennappuwa'),(7746,19,'Mathugama'),(7746,20,'Kaluthara'),(7746,21,'Maharagama'),(7746,22,'Matara'),(7746,23,'Embilipitiya'),(7746,24,'Battaramulla'),(7746,25,'Tissamaharama'),(7746,26,'Mahara'),(7746,27,'Galle'),(7746,28,'Dambulla'),(7746,29,'Kaduruwela'),(7746,30,'Kotahena'),(7746,31,'Colombo Office'),(7746,32,'Jaffna'),(7746,33,'Vavuniya'),(7746,34,'Batticaloa'),(7746,35,'Trincomalee'),(7746,38,'Head Office'),(7746,39,'Kadana'),(7746,40,'Ragama'),(7746,41,'Ela Kanda'),(7746,42,'Eheliyagoda'),(7746,43,'Boralesgamuwa'),(7746,44,'Marawila'),(7746,45,'Kuliyapitiya'),(7746,46,'Ratmalana'),(7746,47,'Panadura'),(7755,1,'Head Office'),(7755,3,'Provincial Office - Central'),(7755,100,'Provincial Office - Western'),(7755,101,'Bulathsinghala'),(7755,102,'Walagedara'),(7755,103,'Agalawatte'),(7755,104,'Millaniya'),(7755,105,'Goonapola'),(7755,106,'Moranthuduwa'),(7755,107,'Beruwala'),(7755,108,'Panadura'),(7755,109,'Horana'),(7755,110,'Warakagoda'),(7755,111,'Ingiriya'),(7755,112,'Dodangoda'),(7755,113,'Meegahathenna'),(7755,114,'Baduraliya'),(7755,115,'Kalutara'),(7755,116,'Gampaha'),(7755,117,'Mawaramandiya'),(7755,118,'Minuwangoda'),(7755,119,'Meerigama'),(7755,120,'Moragahahena'),(7755,121,'Mathugama'),(7755,122,'Negombo'),(7755,123,'Divulapitiya'),(7755,124,'Nittambuwa'),(7755,125,'Homagama'),(7755,126,'Kolonnawa'),(7755,127,'Awissawella'),(7755,128,'Piliyandala'),(7755,129,'Ragama'),(7755,130,'Wadduwa'),(7755,131,'Kirindiwela'),(7755,132,'J-Ela'),(7755,133,'Miriswaththa'),(7755,134,'Kelaniya - Head Quarter'),(7755,198,'Gampaha District Office'),(7755,199,'Kalutara District Office'),(7755,200,'Provincial Office - Southern'),(7755,201,'Hakmana'),(7755,202,'Urubokka'),(7755,203,'Deiyandara'),(7755,204,'Akuressa'),(7755,205,'Weligama'),(7755,206,'Gandara'),(7755,207,'Kekanadura'),(7755,208,'Ambalantota'),(7755,209,'Angunukolapalassa'),(7755,210,'Katuwana'),(7755,211,'Beliatta'),(7755,212,'Elpitiya'),(7755,213,'Batapola'),(7755,214,'Pitigala'),(7755,215,'Gonagalapura'),(7755,216,'Imaduwa'),(7755,217,'Baddegama'),(7755,218,'Tissamaharama'),(7755,219,'Lunugamwehera'),(7755,220,'Pitabaddera'),(7755,221,'Thalgaswala'),(7755,222,'Akmeemana'),(7755,223,'Karandeniya'),(7755,224,'Sooriyawewa'),(7755,225,'Kamburugamuwa'),(7755,226,'Deniyaya'),(7755,227,'Kamburupitiya'),(7755,228,'Galle'),(7755,229,'Uragasmanhandiya'),(7755,230,'Yakkalamulla'),(7755,231,'Weerakatiya'),(7755,232,'Thihagoda'),(7755,233,'City - Matara'),(7755,234,'Tangalle'),(7755,235,'Neluwa'),(7755,236,'Mawarala'),(7755,237,'Morawaka'),(7755,238,'Hambantota'),(7755,239,'Walasmulla'),(7755,240,'Barawakumbuka'),(7755,241,'Udugama'),(7755,242,'Ranna'),(7755,243,'Ahangama'),(7755,244,'Hikkaduwa'),(7755,245,'Kirinda'),(7755,246,'Middeniya'),(7755,247,'Dikwella'),(7755,248,'Karapitiya'),(7755,249,'Balapitiya'),(7755,250,'Pamburana'),(7755,251,'Mirissa'),(7755,252,'Kaluwella'),(7755,253,'Warapitiya'),(7755,254,'Devinuwara'),(7755,297,'District Office - Hambantota'),(7755,298,'District Office - Galle'),(7755,299,'District Office - Matara'),(7755,300,'Wayamba Provincial Office'),(7755,301,'Kuliyapitiya'),(7755,302,'Pannala'),(7755,303,'Panduwasnuwara'),(7755,304,'Alawwa'),(7755,305,'Dummalasooriya'),(7755,306,'Pothuhera'),(7755,307,'Nikaweratiya'),(7755,308,'Rideegama'),(7755,309,'Mawathagama'),(7755,310,'Wariyapola'),(7755,311,'Kurunegala'),(7755,312,'Galgamuwa'),(7755,313,'Chilaw'),(7755,314,'Palakuda'),(7755,315,'Anamaduwa'),(7755,316,'Nattandiya'),(7755,317,'Kirimetiyana'),(7755,318,'Puttlam'),(7755,319,'Maho'),(7755,320,'Giriulla'),(7755,321,'Ibbagamuwa'),(7755,322,'Mundel'),(7755,323,'Nawagattegama'),(7755,324,'Mampuri'),(7755,325,'Mahawewa'),(7755,326,'Narammala'),(7755,327,'Polpithigama'),(7755,328,'Bowatte'),(7755,329,'HQB'),(7755,330,'Melsiripura'),(7755,331,'Ambanpola'),(7755,332,'Santha Anapura'),(7755,398,'Puttlam District Office'),(7755,399,'Kurunegala District Office'),(7755,400,'Provincial Office - North Central'),(7755,401,'Mihinthale'),(7755,402,'Town Branch - Anuradhapura'),(7755,403,'Thambuththegama'),(7755,404,'Kahatagasdigiliya'),(7755,405,'Galnewa'),(7755,406,'Thalawa'),(7755,407,'Medawachchiya'),(7755,408,'Thirappane'),(7755,409,'Rambewa'),(7755,410,'Polonnaruwa'),(7755,411,'Medirigiriya'),(7755,412,'Pulasthigama'),(7755,413,'Hingurakgoda'),(7755,414,'Bakamoona'),(7755,415,'Galenbindunuwewa'),(7755,416,'Gonapathirawa'),(7755,417,'Manampitiya'),(7755,418,'Galamuna'),(7755,419,'New Town - Anuradhapura'),(7755,420,'Siripura'),(7755,421,'Kaduruwela'),(7755,422,'Kekirawa'),(7755,423,'Aralaganwila'),(7755,424,'Economic Centre'),(7755,425,'Sevanapitiya'),(7755,498,'Dritrict Office Polonnaruwa'),(7755,500,'Provincial Office - Sabaragamuwa'),(7755,501,'Kegalle'),(7755,502,'Pitagaldeniya'),(7755,503,'Rambukkana'),(7755,504,'Mawanella'),(7755,505,'Warakapola'),(7755,506,'Aranayaka'),(7755,507,'Kithulgala'),(7755,508,'Ruwanwella'),(7755,509,'Dewalegama'),(7755,510,'Bulathkohupitiya'),(7755,511,'Deraniyagala'),(7755,512,'Rathnapura'),(7755,513,'Pelmadulla'),(7755,514,'Balangoda'),(7755,515,'Embilipitiya'),(7755,516,'Hemmathagama'),(7755,517,'Kolonna'),(7755,518,'Eheliyagoda'),(7755,519,'Nelumdeniya'),(7755,520,'Kalawana'),(7755,521,'Yatiyantota'),(7755,522,'Godakawela'),(7755,523,'Erathna'),(7755,524,'Kuruwita'),(7755,525,'Nivithigala'),(7755,526,'Kahawatta'),(7755,527,'Kotiyakumbura'),(7755,528,'Rakwana'),(7755,529,'Dehiovita'),(7755,530,'Kiriella'),(7755,531,'Pothupitiya'),(7755,532,'Weligepola'),(7755,533,'Sri Palabaddala'),(7755,534,'Pulungupitiya'),(7755,599,'Kegalle District Office'),(7755,600,'Provincial Office - Central'),(7755,601,'Gampola'),(7755,602,'Udawela'),(7755,603,'Hataraliyadda'),(7755,604,'Marassana'),(7755,605,'Danture'),(7755,606,'Wattegama'),(7755,607,'Morayaya'),(7755,608,'Teldeniya'),(7755,609,'Pujapitiya'),(7755,610,'Nuwara Eliya'),(7755,611,'Rikillagaskada'),(7755,612,'Kandy Marketing Centre'),(7755,613,'Ginigathena'),(7755,614,'Poondaluoya'),(7755,615,'Katugastota'),(7755,616,'Nildandahinna'),(7755,617,'Agarapathana'),(7755,618,'Ududumbara'),(7755,619,'Matale'),(7755,620,'Dambulla'),(7755,621,'Galewela'),(7755,622,'Laggala'),(7755,623,'Rattota'),(7755,624,'Kotagala'),(7755,625,'Menikhinna'),(7755,626,'Hanguranketha'),(7755,627,'Daulagala'),(7755,628,'Naula'),(7755,629,'Nawalapitiya'),(7755,630,'Hedeniya'),(7755,631,'Wilgamuwa'),(7755,632,'Kandy'),(7755,633,'Peradeniya'),(7755,700,'Provincial Office - Uva'),(7755,701,'Buttala'),(7755,702,'Medagama'),(7755,703,'Monaragala'),(7755,704,'Thanamalvila'),(7755,705,'Badulla'),(7755,706,'Passara'),(7755,707,'Welimada'),(7755,708,'Kandaketiya'),(7755,709,'Mahiyanganaya'),(7755,710,'wellawaya'),(7755,711,'Badalkumbura'),(7755,712,'Haputhale'),(7755,713,'Rideemaliyadda'),(7755,714,'Uvaparanagama'),(7755,715,'Bandarawela'),(7755,716,'Meegahakiula'),(7755,717,'Lunugala'),(7755,718,'Haldummulla'),(7755,719,'Girandurukotte'),(7755,720,'Bogahakumbura'),(7755,721,'Bibile'),(7755,722,'Uva Maligathenna'),(7755,723,'Siyambalanduwa'),(7755,724,'Diyathalawa'),(7755,725,'Sewanagala'),(7755,726,'Madulla'),(7755,801,'Ampara'),(7755,802,'Dehiatthakandiya'),(7755,803,'Sammanthurai'),(7755,804,'Hingurana'),(7755,805,'Akkaraipaththu'),(7755,806,'Kalmunai'),(7755,807,'Mahaoya'),(7755,808,'Pothuvil'),(7755,809,'Uhana'),(7755,810,'Nintavur'),(7755,811,'Batticaloa'),(7755,812,'Eraur'),(7755,813,'Chenkalady'),(7755,814,'Kanthale'),(7755,815,'Valachenai'),(7755,816,'Kathankudi'),(7755,817,'Trincomalee'),(7755,818,'Kalauwanchikudi'),(7755,819,'Kokkadichcholai'),(7755,820,'Muthtur'),(7755,901,'Vavuniya'),(7755,902,'Kanagarayankulam'),(7755,903,'Mannar'),(7755,904,'Chunnakam'),(7755,905,'Jaffna'),(7755,906,'Kilinochchi'),(7755,907,'Bogaswewa'),(7764,1,'Head Office City'),(7764,2,'Kandy'),(7764,3,'SMIB Finance Department'),(7764,4,'Gampaha'),(7764,5,'Galle'),(7764,6,'Kurunegala'),(7764,7,'Matugama'),(7764,8,'Chilaw'),(7764,9,'Matara'),(7764,10,'Battaramulla'),(7764,11,'Kiribathgoda'),(7764,12,'Kegalle'),(7764,13,'Horana'),(7764,14,'Ambalantota'),(7764,15,'Batticaloa'),(7764,16,'Jaffna'),(7764,18,'Ratnapura'),(7764,19,'Kaduruwela'),(7764,20,'Vavuniya'),(7773,1,'Head Office '),(7773,2,'Corporate Office '),(7773,3,'Nugegoda'),(7773,4,'Negambo'),(7773,5,'Kandy '),(7773,6,'Badulla '),(7773,7,'Panadura'),(7773,8,'Anuradhapura'),(7773,9,'Galle'),(7773,10,'Kiribathgoda'),(7773,11,'Kurunegala'),(7773,12,'Ratnapura'),(7773,13,'Matara'),(7773,14,'Kalutara'),(7773,15,'Ambalangoda'),(7773,16,'Ampara'),(7773,17,'Avissawella'),(7773,18,'Gampaha'),(7773,19,'Chilaw'),(7773,20,'Polonnaruwa'),(7773,21,'Piliyandala'),(7773,22,'Boralesgamuwa'),(7773,23,'Dambulla'),(7773,24,'Balangoda'),(7773,25,'Kegalle'),(7773,26,'Bandarawela'),(7773,27,'Dehiwala'),(7773,28,'Embilipitiya'),(7773,29,'Batticaloa'),(7773,30,'Elpitiya'),(7773,31,'Maradana'),(7773,32,'Kandana'),(7773,33,'Mahiyanganaya'),(7773,34,'Tissamaharama'),(7773,35,'Matale'),(7773,36,'Maharagama'),(7773,37,'Kuliyapitiya'),(7773,38,'Puttalam'),(7773,39,'Trincomalee'),(7773,40,'Gampola'),(7773,41,'Horana'),(7773,42,'Kadawatha'),(7773,43,'Jaffna'),(7773,44,'Chunnakam'),(7773,45,'Manipay '),(7773,46,'Chavakachcheri'),(7773,47,'Kilinochchi'),(7773,48,'Vavuniya'),(7773,49,'Nuwara Eliya'),(7773,50,'Hatton'),(7773,51,'Nelliady '),(7773,52,'Matugama'),(7773,53,'Wennappuwa'),(7773,54,'Thambuththegama'),(7773,55,'Akkaraipattu'),(7773,56,'Pothuvil'),(7773,57,'Kochchikade'),(7773,58,'Kotahena'),(7773,59,'Anuradhapura 02'),(7773,60,'Rajagiriya'),(7773,61,'Welimada'),(7773,62,'Pilimathalawa'),(7773,63,'Katugasthota'),(7773,64,'Kalmunai'),(7773,65,'Moratumulla'),(7773,66,'Kalawanchikudy'),(7773,67,'Sea Street'),(7773,68,'Matara City '),(7773,69,'Aluthgama'),(7773,70,'Kandy City '),(7773,71,'Warakapola'),(7773,72,'Malabe'),(7773,73,'Kaduwela'),(7773,74,'Nawalapitiya'),(7773,75,'Homagama'),(7773,76,'Kurunegala City '),(7773,77,'Maskeliya'),(7773,78,'Pitigala'),(7773,79,'Samanturei'),(7773,80,'Saindamarthu '),(7773,81,'Kotte'),(7773,82,'Badulla City '),(7773,83,'Ja Ela'),(7773,84,'Delkada'),(7773,85,'Kaththankudi'),(7773,86,'Dam Street'),(7773,87,'Akuressa '),(7773,88,'Monaragala'),(7773,89,'Tangalle'),(7773,90,'Mount Lavinia'),(7773,91,'Neluwa'),(7773,92,'Battaramulla'),(7773,93,'Kurunegala Premier Centre'),(7773,94,'Moratuwa'),(8004,1,'Head Office'),(8004,998,'CBSL-VB'),(8004,999,'Central Bank Of Sri Lanka');
/*!40000 ALTER TABLE `bankbranch_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch`
--

DROP TABLE IF EXISTS `branch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `branch` (
  `idbranch` int(11) NOT NULL AUTO_INCREMENT,
  `b_code` varchar(3) NOT NULL,
  `b_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idbranch`,`b_code`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch`
--

LOCK TABLES `branch` WRITE;
/*!40000 ALTER TABLE `branch` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=431 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `center_details`
--

LOCK TABLES `center_details` WRITE;
/*!40000 ALTER TABLE `center_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `center_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chequebook_registry`
--

DROP TABLE IF EXISTS `chequebook_registry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chequebook_registry` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cheq_no` varchar(45) DEFAULT NULL,
  `bank` varchar(45) DEFAULT NULL,
  `bank_branch` varchar(45) DEFAULT NULL,
  `create_date` varchar(45) DEFAULT NULL,
  `create_user` varchar(45) DEFAULT NULL,
  `status` varchar(1) DEFAULT NULL,
  `chq_status` varchar(1) DEFAULT NULL,
  `AccountNo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chequebook_registry`
--

LOCK TABLES `chequebook_registry` WRITE;
/*!40000 ALTER TABLE `chequebook_registry` DISABLE KEYS */;
/*!40000 ALTER TABLE `chequebook_registry` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chq_date`
--

LOCK TABLES `chq_date` WRITE;
/*!40000 ALTER TABLE `chq_date` DISABLE KEYS */;
/*!40000 ALTER TABLE `chq_date` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chqreg`
--

DROP TABLE IF EXISTS `chqreg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chqreg` (
  `idchqreg` int(11) NOT NULL AUTO_INCREMENT,
  `product` varchar(5) DEFAULT NULL,
  `contractcode` varchar(13) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `type` varchar(10) DEFAULT NULL,
  `ownership` varchar(15) DEFAULT NULL,
  `refno` varchar(15) DEFAULT NULL,
  `bank` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `ip` varchar(45) DEFAULT NULL,
  `create_id` varchar(10) DEFAULT NULL,
  `chq_status` varchar(10) DEFAULT NULL,
  `chq_date` varchar(10) DEFAULT NULL,
  `book_date` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idchqreg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chqreg`
--

LOCK TABLES `chqreg` WRITE;
/*!40000 ALTER TABLE `chqreg` DISABLE KEYS */;
/*!40000 ALTER TABLE `chqreg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `districts`
--

DROP TABLE IF EXISTS `districts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `districts` (
  `iddistricts` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`iddistricts`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `districts`
--

LOCK TABLES `districts` WRITE;
/*!40000 ALTER TABLE `districts` DISABLE KEYS */;
INSERT INTO `districts` VALUES (1,'Ampara'),(2,'Anuradhapura'),(3,'Badulla'),(4,'Batticaloa'),(5,'Colombo'),(6,'Galle'),(7,'Gampaha'),(8,'Hambantota'),(9,'Jaffna'),(10,'Kalutara'),(11,'Kandy'),(12,'Kegalle'),(13,'Kilinochchi'),(14,'Kurunegala'),(15,'Mannar'),(16,'Matale'),(17,'Matara'),(18,'Moneragala'),(19,'Mullaitivu'),(20,'Nuwara Eliya'),(21,'Polonnaruwa'),(22,'Puttalam'),(23,'Ratnapura'),(24,'Trincomalee'),(25,'Vavuniya');
/*!40000 ALTER TABLE `districts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `due_collection`
--

DROP TABLE IF EXISTS `due_collection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `due_collection` (
  `iddue_collection` int(11) NOT NULL AUTO_INCREMENT,
  `active_date` varchar(45) DEFAULT NULL,
  `hp_due` decimal(12,2) DEFAULT NULL,
  `hp_collection` decimal(12,2) DEFAULT NULL,
  `cs_due` decimal(12,2) DEFAULT NULL,
  `cs_collection` decimal(12,2) DEFAULT NULL,
  `rbf_due` decimal(12,2) DEFAULT NULL,
  `rbf_collection` decimal(12,2) DEFAULT NULL,
  `prbf_due` decimal(12,2) DEFAULT NULL,
  `prbf_collection` decimal(12,2) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `host_ip` varchar(45) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`iddue_collection`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `due_collection`
--

LOCK TABLES `due_collection` WRITE;
/*!40000 ALTER TABLE `due_collection` DISABLE KEYS */;
/*!40000 ALTER TABLE `due_collection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `due_history`
--

DROP TABLE IF EXISTS `due_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `due_history` (
  `id_due_history` int(11) NOT NULL AUTO_INCREMENT,
  `update_date` varchar(45) DEFAULT NULL,
  `cf` decimal(12,2) DEFAULT NULL,
  `rbf` decimal(12,2) DEFAULT NULL,
  `prbf` decimal(12,2) DEFAULT NULL,
  `micro` decimal(12,2) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `rbf_so` decimal(12,2) DEFAULT NULL,
  `rbf_be` decimal(12,2) DEFAULT NULL,
  `rbf_tm` decimal(12,2) DEFAULT NULL,
  `rbf_co` decimal(12,2) DEFAULT NULL,
  `rbf_nr` decimal(12,2) DEFAULT NULL,
  `rbf_rp` decimal(12,2) DEFAULT NULL,
  `prbf_so` decimal(12,2) DEFAULT NULL,
  `prbf_be` decimal(12,2) DEFAULT NULL,
  `prbf_tm` decimal(12,2) DEFAULT NULL,
  `prbf_co` decimal(12,2) DEFAULT NULL,
  `micro_so` decimal(12,2) DEFAULT NULL,
  `micro_tm` decimal(12,2) DEFAULT NULL,
  `micro_be` decimal(12,2) DEFAULT NULL,
  `micro_co` decimal(12,2) DEFAULT NULL,
  `micro_rp` decimal(12,2) DEFAULT NULL,
  `micro_nr` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_due_history`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `due_history`
--

LOCK TABLES `due_history` WRITE;
/*!40000 ALTER TABLE `due_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `due_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expen_type`
--

DROP TABLE IF EXISTS `expen_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expen_type` (
  `idexpen_type` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idexpen_type`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expen_type`
--

LOCK TABLES `expen_type` WRITE;
/*!40000 ALTER TABLE `expen_type` DISABLE KEYS */;
INSERT INTO `expen_type` VALUES (1,'Salary Advance'),(2,'Electricity Bill'),(3,'Water Bill'),(4,'Phone Bill'),(5,'Internet Bill'),(6,'Insurance'),(7,'Travelling Allowence'),(8,'Loan Payment'),(9,'Loan Settlement'),(10,'Hire Purchase Settlement'),(11,'Managers Allowence'),(12,'For Acquisition'),(13,'Arrears Salary'),(14,'Bonus'),(15,'Gift Voucher'),(16,'Petty Cash'),(17,'Cash Advance'),(18,'Branch visit Expenses'),(19,'Building Rent'),(20,'Bike Installment');
/*!40000 ALTER TABLE `expen_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `family_relationship_details`
--

DROP TABLE IF EXISTS `family_relationship_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `family_relationship_details` (
  `frd_ID` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `relationship` varchar(45) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `occupation` varchar(45) DEFAULT NULL,
  `income` decimal(10,2) DEFAULT NULL,
  `create_user_nic` varchar(12) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`frd_ID`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `family_relationship_details`
--

LOCK TABLES `family_relationship_details` WRITE;
/*!40000 ALTER TABLE `family_relationship_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `family_relationship_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `letters`
--

DROP TABLE IF EXISTS `letters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `letters` (
  `idletters` int(11) NOT NULL AUTO_INCREMENT,
  `ccode` varchar(12) NOT NULL,
  `cu_name` varchar(150) DEFAULT NULL,
  `loan_amount` decimal(12,2) DEFAULT NULL,
  `loan_bala` decimal(12,2) DEFAULT NULL,
  `arreas` decimal(12,2) DEFAULT NULL,
  `cato` varchar(45) DEFAULT NULL,
  `user_nic` varchar(12) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idletters`,`ccode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `letters`
--

LOCK TABLES `letters` WRITE;
/*!40000 ALTER TABLE `letters` DISABLE KEYS */;
/*!40000 ALTER TABLE `letters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loan_cancel`
--

DROP TABLE IF EXISTS `loan_cancel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `loan_cancel` (
  `idloan_cancel` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `comment` varchar(255) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `loan_amount` decimal(12,2) DEFAULT NULL,
  `ip` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idloan_cancel`,`contra_code`),
  UNIQUE KEY `contra_code_UNIQUE` (`contra_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loan_cancel`
--

LOCK TABLES `loan_cancel` WRITE;
/*!40000 ALTER TABLE `loan_cancel` DISABLE KEYS */;
/*!40000 ALTER TABLE `loan_cancel` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_basic_detail`
--

LOCK TABLES `micro_basic_detail` WRITE;
/*!40000 ALTER TABLE `micro_basic_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_basic_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_business_details`
--

DROP TABLE IF EXISTS `micro_business_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_business_details` (
  `idbusiness_details` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `business_name` varchar(100) DEFAULT NULL,
  `busi_duration` varchar(45) DEFAULT NULL,
  `busi_address` varchar(255) DEFAULT NULL,
  `busi_income` decimal(10,2) DEFAULT NULL,
  `other_income` decimal(10,2) DEFAULT NULL,
  `total_income` decimal(10,2) DEFAULT NULL,
  `direct_cost` decimal(10,2) DEFAULT NULL,
  `indirect_cost` decimal(10,2) DEFAULT NULL,
  `other_expenses` decimal(10,2) DEFAULT NULL,
  `total_expenses` decimal(10,2) DEFAULT NULL,
  `profit_lost` decimal(10,2) DEFAULT NULL,
  `family_expenses` decimal(10,2) DEFAULT NULL,
  `net_income` decimal(10,2) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idbusiness_details`,`contract_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_business_details`
--

LOCK TABLES `micro_business_details` WRITE;
/*!40000 ALTER TABLE `micro_business_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_business_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_cansel_receipt`
--

DROP TABLE IF EXISTS `micro_cansel_receipt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_cansel_receipt` (
  `idcansel_receipt` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `rec_no` varchar(10) NOT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `reson` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idcansel_receipt`,`contra_code`,`rec_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_cansel_receipt`
--

LOCK TABLES `micro_cansel_receipt` WRITE;
/*!40000 ALTER TABLE `micro_cansel_receipt` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_cansel_receipt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_exective_root`
--

DROP TABLE IF EXISTS `micro_exective_root`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_exective_root` (
  `idrbf_exective_root` int(11) NOT NULL AUTO_INCREMENT,
  `exe_id` varchar(2) DEFAULT NULL,
  `exe_name` varchar(100) DEFAULT NULL,
  `branch_code` varchar(10) DEFAULT NULL,
  `create_user_id` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `create_date_time` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idrbf_exective_root`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_exective_root`
--

LOCK TABLES `micro_exective_root` WRITE;
/*!40000 ALTER TABLE `micro_exective_root` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_exective_root` ENABLE KEYS */;
UNLOCK TABLES;

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
  `total_annual_family_in` decimal(10,2) DEFAULT NULL,
  `total_annual_family_ex` decimal(10,2) DEFAULT NULL,
  `net_annual_family_in` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_family_appraisal`
--

LOCK TABLES `micro_family_appraisal` WRITE;
/*!40000 ALTER TABLE `micro_family_appraisal` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_family_appraisal` ENABLE KEYS */;
UNLOCK TABLES;

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
  `spouse_nic_issued_date` varchar(10) DEFAULT NULL,
  `spouse_dob` varchar(10) DEFAULT NULL,
  `spouse_gender` varchar(1) DEFAULT NULL,
  `spouse_contact_no` varchar(15) DEFAULT NULL,
  `spouse_relationship_with_applicant` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmicro_family_details`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_family_details`
--

LOCK TABLES `micro_family_details` WRITE;
/*!40000 ALTER TABLE `micro_family_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_family_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_loan_details`
--

DROP TABLE IF EXISTS `micro_loan_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_loan_details` (
  `idloan_details` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `loan_amount` decimal(9,2) DEFAULT NULL,
  `current_loan_amount` decimal(9,2) DEFAULT NULL,
  `service_charges` decimal(9,2) DEFAULT NULL,
  `other_charges` decimal(9,2) DEFAULT NULL,
  `interest_rate` varchar(5) DEFAULT NULL,
  `interest_amount` decimal(9,2) DEFAULT NULL,
  `period` varchar(45) DEFAULT NULL,
  `monthly_instollment` decimal(9,2) DEFAULT NULL,
  `created_on` varchar(45) DEFAULT NULL,
  `created_user_nic` varchar(10) DEFAULT NULL,
  `created_user_ip` varchar(20) DEFAULT NULL,
  `chequ_no` varchar(20) DEFAULT NULL,
  `chequ_amount` decimal(9,2) DEFAULT NULL,
  `chequ_deta_on` varchar(45) DEFAULT NULL,
  `loan_approved` varchar(1) DEFAULT NULL,
  `loan_approved_user_nic` varchar(10) DEFAULT NULL,
  `loan_approved_on` varchar(45) DEFAULT NULL,
  `OtherDescription` varchar(200) DEFAULT NULL,
  `cheq_detai_app_nic` varchar(10) DEFAULT NULL,
  `due_date` varchar(45) DEFAULT NULL,
  `arres_amou` decimal(9,2) DEFAULT '0.00',
  `acc_name` varchar(45) DEFAULT NULL,
  `acc_branch` varchar(45) DEFAULT NULL,
  `acc_number` varchar(15) DEFAULT NULL,
  `bank_name` varchar(45) DEFAULT NULL,
  `def` decimal(10,2) DEFAULT '0.00',
  `over_payment` decimal(10,2) DEFAULT '0.00',
  `arres_count` varchar(3) DEFAULT '0',
  `loan_sta` varchar(1) DEFAULT 'P',
  `ser_char_sta` varchar(1) DEFAULT 'N',
  `closing_date` varchar(45) DEFAULT NULL,
  `maturity_date` varchar(45) DEFAULT NULL,
  `due_installment` varchar(2) DEFAULT '0',
  `reg_approval_nic` varchar(10) DEFAULT NULL,
  `reg_approval_on` varchar(45) DEFAULT NULL,
  `reg_approval_des` varchar(200) DEFAULT NULL,
  `reg_approval` varchar(1) DEFAULT NULL,
  `bank_code` varchar(4) DEFAULT NULL,
  `branch_code` varchar(3) DEFAULT NULL,
  `registration_fee` decimal(10,2) DEFAULT NULL,
  `walfare_fee` decimal(10,2) DEFAULT NULL,
  `product_category` varchar(45) DEFAULT NULL,
  `brand` varchar(45) DEFAULT NULL,
  `model_no` varchar(45) DEFAULT NULL,
  `selling_price` varchar(45) DEFAULT NULL,
  `down_payment` varchar(45) DEFAULT NULL,
  `micro_loan_detailscol` varchar(45) DEFAULT NULL,
  `reason_to_apply` varchar(45) DEFAULT NULL,
  `any_unsettled_loans` smallint(1) DEFAULT NULL,
  `micro_loan_detailscol1` varchar(45) DEFAULT NULL,
  `other_unsettled_facilities` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`idloan_details`,`contra_code`),
  UNIQUE KEY `contra_code_UNIQUE` (`contra_code`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_loan_details`
--

LOCK TABLES `micro_loan_details` WRITE;
/*!40000 ALTER TABLE `micro_loan_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_loan_details` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_pais_history`
--

LOCK TABLES `micro_pais_history` WRITE;
/*!40000 ALTER TABLE `micro_pais_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_pais_history` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_payme_summery`
--

LOCK TABLES `micro_payme_summery` WRITE;
/*!40000 ALTER TABLE `micro_payme_summery` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_payme_summery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_receipt_history`
--

DROP TABLE IF EXISTS `micro_receipt_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_receipt_history` (
  `idmicro_receipt_history` int(11) NOT NULL,
  `contract_code` varchar(15) NOT NULL,
  `rec_no` varchar(10) DEFAULT NULL,
  `city_code` varchar(10) DEFAULT NULL,
  `paied_amount` decimal(10,2) DEFAULT NULL,
  `curr_arres` decimal(10,2) DEFAULT NULL,
  `balance` decimal(10,2) DEFAULT NULL,
  `due_date` varchar(45) DEFAULT NULL,
  `invoice_date` varchar(45) DEFAULT NULL,
  `cash_nic` varchar(10) DEFAULT NULL,
  `amount_text` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_receipt_history`
--

LOCK TABLES `micro_receipt_history` WRITE;
/*!40000 ALTER TABLE `micro_receipt_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_receipt_history` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_service_charges`
--

LOCK TABLES `micro_service_charges` WRITE;
/*!40000 ALTER TABLE `micro_service_charges` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_service_charges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_slip_transfer`
--

DROP TABLE IF EXISTS `micro_slip_transfer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_slip_transfer` (
  `idmicro_slip_transfer` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `user_loagging` varchar(10) DEFAULT NULL,
  `ip` varchar(45) DEFAULT NULL,
  `transfer_id` int(11) DEFAULT NULL,
  `bank_code` varchar(4) DEFAULT NULL,
  `branch_code` varchar(3) DEFAULT NULL,
  `acc_no` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idmicro_slip_transfer`,`contra_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_slip_transfer`
--

LOCK TABLES `micro_slip_transfer` WRITE;
/*!40000 ALTER TABLE `micro_slip_transfer` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_slip_transfer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_slip_transfer_id`
--

DROP TABLE IF EXISTS `micro_slip_transfer_id`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_slip_transfer_id` (
  `idmicro_slip_transfer_id` int(11) NOT NULL AUTO_INCREMENT,
  `transfer_id` varchar(10) NOT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmicro_slip_transfer_id`,`transfer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_slip_transfer_id`
--

LOCK TABLES `micro_slip_transfer_id` WRITE;
/*!40000 ALTER TABLE `micro_slip_transfer_id` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_slip_transfer_id` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `micro_voucher_print`
--

DROP TABLE IF EXISTS `micro_voucher_print`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_voucher_print` (
  `voucher_no` int(11) NOT NULL,
  `contract_code` varchar(15) DEFAULT NULL,
  `voucher_date` varchar(45) DEFAULT NULL,
  `print_date` varchar(45) DEFAULT NULL,
  `print_user` varchar(45) DEFAULT NULL,
  `isPrint` int(1) DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  PRIMARY KEY (`voucher_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_voucher_print`
--

LOCK TABLES `micro_voucher_print` WRITE;
/*!40000 ALTER TABLE `micro_voucher_print` DISABLE KEYS */;
/*!40000 ALTER TABLE `micro_voucher_print` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `petty_cash_expenses_details`
--

DROP TABLE IF EXISTS `petty_cash_expenses_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `petty_cash_expenses_details` (
  `sys_id` int(11) NOT NULL AUTO_INCREMENT,
  `voucher_id` varchar(10) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `expences_type` varchar(45) DEFAULT NULL,
  `purpose` varchar(45) DEFAULT NULL,
  `date` varchar(20) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `approval_state` varchar(20) DEFAULT NULL,
  `branchcode` varchar(2) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `create_ip` varchar(15) DEFAULT NULL,
  `created_on` varchar(45) DEFAULT NULL,
  `approved_nic` varchar(10) DEFAULT NULL,
  `approved_on` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`sys_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `petty_cash_expenses_details`
--

LOCK TABLES `petty_cash_expenses_details` WRITE;
/*!40000 ALTER TABLE `petty_cash_expenses_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `petty_cash_expenses_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `province` (
  `idProvince` int(11) NOT NULL AUTO_INCREMENT,
  `id_province` varchar(3) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idProvince`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `province`
--

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES (1,'CP','Central Province'),(2,'EP','Eastern Province'),(3,'NP','Northern Province'),(4,'SP','Southern Province'),(5,'WP','Western Province'),(6,'NWP','North Western Province'),(7,'NCP','North Central Province'),(8,'UP','Uva Province'),(9,'SbP','Sabaragamuwa Province');
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rbf_chq_date`
--

DROP TABLE IF EXISTS `rbf_chq_date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rbf_chq_date` (
  `idchq_date` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(13) NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rbf_chq_date`
--

LOCK TABLES `rbf_chq_date` WRITE;
/*!40000 ALTER TABLE `rbf_chq_date` DISABLE KEYS */;
/*!40000 ALTER TABLE `rbf_chq_date` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rbf_pais_history`
--

DROP TABLE IF EXISTS `rbf_pais_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rbf_pais_history` (
  `idpais_history` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(13) NOT NULL,
  `NIC` varchar(15) NOT NULL,
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
  PRIMARY KEY (`idpais_history`,`contra_code`,`NIC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rbf_pais_history`
--

LOCK TABLES `rbf_pais_history` WRITE;
/*!40000 ALTER TABLE `rbf_pais_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `rbf_pais_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rbf_reson_hist`
--

DROP TABLE IF EXISTS `rbf_reson_hist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rbf_reson_hist` (
  `idrbf_reson_hist` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(13) DEFAULT NULL,
  `branch_code` varchar(2) DEFAULT NULL,
  `arreas_amount` decimal(10,2) DEFAULT NULL,
  `descrip` varchar(255) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idrbf_reson_hist`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rbf_reson_hist`
--

LOCK TABLES `rbf_reson_hist` WRITE;
/*!40000 ALTER TABLE `rbf_reson_hist` DISABLE KEYS */;
/*!40000 ALTER TABLE `rbf_reson_hist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rebate`
--

DROP TABLE IF EXISTS `rebate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rebate` (
  `idrebate` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `nic` varchar(10) NOT NULL,
  `arrears` decimal(10,2) DEFAULT NULL,
  `curr_balance` decimal(10,2) DEFAULT NULL,
  `in_rate` varchar(5) DEFAULT NULL,
  `in_amount` decimal(10,2) DEFAULT NULL,
  `prio` varchar(5) DEFAULT NULL,
  `new_inte_rate` varchar(5) DEFAULT NULL,
  `min_amount` decimal(10,2) DEFAULT NULL,
  `sta` varchar(1) DEFAULT NULL,
  `new_loan_bala` decimal(10,2) DEFAULT NULL,
  `descrip` varchar(200) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `auth_nic` varchar(10) DEFAULT NULL,
  `auth_date_time` varchar(45) DEFAULT NULL,
  `auth_ip` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idrebate`,`contra_code`,`nic`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rebate`
--

LOCK TABLES `rebate` WRITE;
/*!40000 ALTER TABLE `rebate` DISABLE KEYS */;
/*!40000 ALTER TABLE `rebate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recovery_holiday`
--

DROP TABLE IF EXISTS `recovery_holiday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recovery_holiday` (
  `idrecovery_holiday` int(11) NOT NULL AUTO_INCREMENT,
  `holiday_date` varchar(10) DEFAULT NULL,
  `date_sta` varchar(1) DEFAULT NULL,
  `user_nic` varchar(12) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `create_datetime` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idrecovery_holiday`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recovery_holiday`
--

LOCK TABLES `recovery_holiday` WRITE;
/*!40000 ALTER TABLE `recovery_holiday` DISABLE KEYS */;
/*!40000 ALTER TABLE `recovery_holiday` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_basic_detail`
--

DROP TABLE IF EXISTS `salam_basic_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_basic_detail` (
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_basic_detail`
--

LOCK TABLES `salam_basic_detail` WRITE;
/*!40000 ALTER TABLE `salam_basic_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_basic_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_business_details`
--

DROP TABLE IF EXISTS `salam_business_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_business_details` (
  `idbusiness_details` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `business_name` varchar(100) DEFAULT NULL,
  `busi_duration` varchar(45) DEFAULT NULL,
  `busi_address` varchar(255) DEFAULT NULL,
  `busi_income` decimal(10,2) DEFAULT NULL,
  `other_income` decimal(10,2) DEFAULT NULL,
  `total_income` decimal(10,2) DEFAULT NULL,
  `direct_cost` decimal(10,2) DEFAULT NULL,
  `indirect_cost` decimal(10,2) DEFAULT NULL,
  `other_expenses` decimal(10,2) DEFAULT NULL,
  `total_expenses` decimal(10,2) DEFAULT NULL,
  `profit_lost` decimal(10,2) DEFAULT NULL,
  `family_expenses` decimal(10,2) DEFAULT NULL,
  `net_income` decimal(10,2) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idbusiness_details`,`contract_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_business_details`
--

LOCK TABLES `salam_business_details` WRITE;
/*!40000 ALTER TABLE `salam_business_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_business_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_cansel_receipt`
--

DROP TABLE IF EXISTS `salam_cansel_receipt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_cansel_receipt` (
  `idcansel_receipt` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `rec_no` varchar(10) NOT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `reson` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idcansel_receipt`,`contra_code`,`rec_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_cansel_receipt`
--

LOCK TABLES `salam_cansel_receipt` WRITE;
/*!40000 ALTER TABLE `salam_cansel_receipt` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_cansel_receipt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_exective_root`
--

DROP TABLE IF EXISTS `salam_exective_root`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_exective_root` (
  `idrbf_exective_root` int(11) NOT NULL AUTO_INCREMENT,
  `exe_id` varchar(2) DEFAULT NULL,
  `exe_name` varchar(100) DEFAULT NULL,
  `branch_code` varchar(10) DEFAULT NULL,
  `create_user_id` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `create_date_time` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idrbf_exective_root`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_exective_root`
--

LOCK TABLES `salam_exective_root` WRITE;
/*!40000 ALTER TABLE `salam_exective_root` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_exective_root` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_family_appraisal`
--

DROP TABLE IF EXISTS `salam_family_appraisal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_family_appraisal` (
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
-- Dumping data for table `salam_family_appraisal`
--

LOCK TABLES `salam_family_appraisal` WRITE;
/*!40000 ALTER TABLE `salam_family_appraisal` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_family_appraisal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_family_details`
--

DROP TABLE IF EXISTS `salam_family_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_family_details` (
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
  `spouse_nic_issued_date` varchar(10) DEFAULT NULL,
  `spouse_dob` varchar(10) DEFAULT NULL,
  `spouse_gender` varchar(1) DEFAULT NULL,
  `spouse_contact_no` varchar(15) DEFAULT NULL,
  `spouse_relationship_with_applicant` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmicro_family_details`,`contract_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_family_details`
--

LOCK TABLES `salam_family_details` WRITE;
/*!40000 ALTER TABLE `salam_family_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_family_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_loan_details`
--

DROP TABLE IF EXISTS `salam_loan_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_loan_details` (
  `idloan_details` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `loan_amount` decimal(9,2) DEFAULT NULL,
  `current_loan_amount` decimal(9,2) DEFAULT NULL,
  `service_charges` decimal(9,2) DEFAULT NULL,
  `other_charges` decimal(9,2) DEFAULT NULL,
  `interest_rate` varchar(5) DEFAULT NULL,
  `interest_amount` decimal(9,2) DEFAULT NULL,
  `period` varchar(45) DEFAULT NULL,
  `monthly_instollment` decimal(9,2) DEFAULT NULL,
  `created_on` varchar(45) DEFAULT NULL,
  `created_user_nic` varchar(10) DEFAULT NULL,
  `created_user_ip` varchar(20) DEFAULT NULL,
  `chequ_no` varchar(20) DEFAULT NULL,
  `chequ_amount` decimal(9,2) DEFAULT NULL,
  `chequ_deta_on` varchar(45) DEFAULT NULL,
  `loan_approved` varchar(1) DEFAULT NULL,
  `loan_approved_user_nic` varchar(10) DEFAULT NULL,
  `loan_approved_on` varchar(45) DEFAULT NULL,
  `OtherDescription` varchar(200) DEFAULT NULL,
  `cheq_detai_app_nic` varchar(10) DEFAULT NULL,
  `due_date` varchar(45) DEFAULT NULL,
  `arres_amou` decimal(9,2) DEFAULT '0.00',
  `acc_name` varchar(45) DEFAULT NULL,
  `acc_branch` varchar(45) DEFAULT NULL,
  `acc_number` varchar(15) DEFAULT NULL,
  `bank_name` varchar(45) DEFAULT NULL,
  `def` decimal(10,2) DEFAULT '0.00',
  `over_payment` decimal(10,2) DEFAULT '0.00',
  `arres_count` varchar(3) DEFAULT '0',
  `loan_sta` varchar(1) DEFAULT 'P',
  `ser_char_sta` varchar(1) DEFAULT 'N',
  `closing_date` varchar(45) DEFAULT NULL,
  `maturity_date` varchar(45) DEFAULT NULL,
  `due_installment` varchar(2) DEFAULT '0',
  `reg_approval_nic` varchar(10) DEFAULT NULL,
  `reg_approval_on` varchar(45) DEFAULT NULL,
  `reg_approval_des` varchar(200) DEFAULT NULL,
  `reg_approval` varchar(1) DEFAULT NULL,
  `bank_code` varchar(4) DEFAULT NULL,
  `branch_code` varchar(3) DEFAULT NULL,
  `registration_fee` decimal(10,2) DEFAULT NULL,
  `walfare_fee` decimal(10,2) DEFAULT NULL,
  `product_category` varchar(45) DEFAULT NULL,
  `brand` varchar(45) DEFAULT NULL,
  `model_no` varchar(45) DEFAULT NULL,
  `selling_price` varchar(45) DEFAULT NULL,
  `down_payment` varchar(45) DEFAULT NULL,
  `micro_loan_detailscol` varchar(45) DEFAULT NULL,
  `reason_to_apply` varchar(45) DEFAULT NULL,
  `any_unsettled_loans` smallint(1) DEFAULT NULL,
  `micro_loan_detailscol1` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idloan_details`,`contra_code`),
  UNIQUE KEY `contra_code_UNIQUE` (`contra_code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_loan_details`
--

LOCK TABLES `salam_loan_details` WRITE;
/*!40000 ALTER TABLE `salam_loan_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_loan_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_pais_history`
--

DROP TABLE IF EXISTS `salam_pais_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_pais_history` (
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_pais_history`
--

LOCK TABLES `salam_pais_history` WRITE;
/*!40000 ALTER TABLE `salam_pais_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_pais_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_payme_summery`
--

DROP TABLE IF EXISTS `salam_payme_summery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_payme_summery` (
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_payme_summery`
--

LOCK TABLES `salam_payme_summery` WRITE;
/*!40000 ALTER TABLE `salam_payme_summery` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_payme_summery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_receipt_history`
--

DROP TABLE IF EXISTS `salam_receipt_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_receipt_history` (
  `idmicro_receipt_history` int(11) NOT NULL,
  `contract_code` varchar(15) NOT NULL,
  `rec_no` varchar(10) DEFAULT NULL,
  `city_code` varchar(10) DEFAULT NULL,
  `paied_amount` decimal(10,2) DEFAULT NULL,
  `curr_arres` decimal(10,2) DEFAULT NULL,
  `balance` decimal(10,2) DEFAULT NULL,
  `due_date` varchar(45) DEFAULT NULL,
  `invoice_date` varchar(45) DEFAULT NULL,
  `cash_nic` varchar(10) DEFAULT NULL,
  `amount_text` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_receipt_history`
--

LOCK TABLES `salam_receipt_history` WRITE;
/*!40000 ALTER TABLE `salam_receipt_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_receipt_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_repay`
--

DROP TABLE IF EXISTS `salam_repay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_repay` (
  `id_salam_repay` int(11) NOT NULL AUTO_INCREMENT,
  `ccode` varchar(45) DEFAULT NULL,
  `cacode` varchar(45) DEFAULT NULL,
  `incomesource1_1` varchar(45) DEFAULT NULL,
  `incomesource1_2` varchar(45) DEFAULT NULL,
  `incomesource1_3` varchar(45) DEFAULT NULL,
  `incomesource2_1` varchar(45) DEFAULT NULL,
  `incomesource2_2` varchar(45) DEFAULT NULL,
  `incomesource2_3` varchar(45) DEFAULT NULL,
  `areaofFarming` varchar(45) DEFAULT NULL,
  `typeofv1` varchar(45) DEFAULT NULL,
  `typeofv2` varchar(45) DEFAULT NULL,
  `ex_years` varchar(45) DEFAULT NULL,
  `total_harvest` varchar(45) DEFAULT NULL,
  `ex_price_per_unit` varchar(45) DEFAULT NULL,
  `annual_rate` varchar(45) DEFAULT NULL,
  `rate_for_period` varchar(45) DEFAULT NULL,
  `exp_profit` varchar(45) DEFAULT NULL,
  `exp_sale_price` varchar(45) DEFAULT NULL,
  `exp_unit` varchar(45) DEFAULT NULL,
  `harvesting_period` varchar(45) DEFAULT NULL,
  `seasons_for_year` varchar(45) DEFAULT NULL,
  `rain_water` varchar(1) DEFAULT NULL,
  `irrigation_water` varchar(1) DEFAULT NULL,
  `both` varchar(1) DEFAULT NULL,
  `min_expected_price` decimal(9,2) DEFAULT NULL,
  `max_expected_price` decimal(9,2) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `re_pay_period` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_salam_repay`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_repay`
--

LOCK TABLES `salam_repay` WRITE;
/*!40000 ALTER TABLE `salam_repay` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_repay` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_service_charges`
--

DROP TABLE IF EXISTS `salam_service_charges`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_service_charges` (
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_service_charges`
--

LOCK TABLES `salam_service_charges` WRITE;
/*!40000 ALTER TABLE `salam_service_charges` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_service_charges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_slip_transfer`
--

DROP TABLE IF EXISTS `salam_slip_transfer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_slip_transfer` (
  `idmicro_slip_transfer` int(11) NOT NULL AUTO_INCREMENT,
  `contra_code` varchar(15) NOT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `user_loagging` varchar(10) DEFAULT NULL,
  `ip` varchar(45) DEFAULT NULL,
  `transfer_id` int(11) DEFAULT NULL,
  `bank_code` varchar(4) DEFAULT NULL,
  `branch_code` varchar(3) DEFAULT NULL,
  `acc_no` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idmicro_slip_transfer`,`contra_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_slip_transfer`
--

LOCK TABLES `salam_slip_transfer` WRITE;
/*!40000 ALTER TABLE `salam_slip_transfer` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_slip_transfer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_slip_transfer_id`
--

DROP TABLE IF EXISTS `salam_slip_transfer_id`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_slip_transfer_id` (
  `idmicro_slip_transfer_id` int(11) NOT NULL AUTO_INCREMENT,
  `transfer_id` varchar(10) NOT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmicro_slip_transfer_id`,`transfer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_slip_transfer_id`
--

LOCK TABLES `salam_slip_transfer_id` WRITE;
/*!40000 ALTER TABLE `salam_slip_transfer_id` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_slip_transfer_id` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salam_voucher_print`
--

DROP TABLE IF EXISTS `salam_voucher_print`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salam_voucher_print` (
  `voucher_no` int(11) NOT NULL,
  `contract_code` varchar(15) DEFAULT NULL,
  `voucher_date` varchar(45) DEFAULT NULL,
  `print_date` varchar(45) DEFAULT NULL,
  `print_user` varchar(45) DEFAULT NULL,
  `isPrint` int(1) DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  PRIMARY KEY (`voucher_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salam_voucher_print`
--

LOCK TABLES `salam_voucher_print` WRITE;
/*!40000 ALTER TABLE `salam_voucher_print` DISABLE KEYS */;
/*!40000 ALTER TABLE `salam_voucher_print` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier_category`
--

DROP TABLE IF EXISTS `supplier_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `supplier_category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_category`
--

LOCK TABLES `supplier_category` WRITE;
/*!40000 ALTER TABLE `supplier_category` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier_details`
--

DROP TABLE IF EXISTS `supplier_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `supplier_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `supplier_category` int(11) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `tele` varchar(10) DEFAULT NULL,
  `mobile` varchar(10) DEFAULT NULL,
  `bank` int(11) DEFAULT NULL,
  `branch` int(11) DEFAULT NULL,
  `account_no` varchar(45) DEFAULT NULL,
  `account_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_details`
--

LOCK TABLES `supplier_details` WRITE;
/*!40000 ALTER TABLE `supplier_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `target_april`
--

DROP TABLE IF EXISTS `target_april`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `target_april` (
  `idtarget_april` int(11) NOT NULL AUTO_INCREMENT,
  `branch_code` varchar(2) DEFAULT NULL,
  `collection_target` decimal(10,2) DEFAULT NULL,
  `archev` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idtarget_april`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `target_april`
--

LOCK TABLES `target_april` WRITE;
/*!40000 ALTER TABLE `target_april` DISABLE KEYS */;
/*!40000 ALTER TABLE `target_april` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `target_detail`
--

LOCK TABLES `target_detail` WRITE;
/*!40000 ALTER TABLE `target_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `target_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tra_descri`
--

DROP TABLE IF EXISTS `tra_descri`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tra_descri` (
  `idtra_descri` int(11) NOT NULL AUTO_INCREMENT,
  `code_tra` varchar(3) DEFAULT NULL,
  `descr` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idtra_descri`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tra_descri`
--

LOCK TABLES `tra_descri` WRITE;
/*!40000 ALTER TABLE `tra_descri` DISABLE KEYS */;
INSERT INTO `tra_descri` VALUES (1,'MI','Installment Payment'),(2,'D','Default'),(3,'LP','Late Payment Fee'),(4,'R','Rebate'),(5,'DI','Daily Installment'),(6,'DB','Debit'),(7,'C','Cancel'),(8,'CR','Cheque Return'),(9,'WI','Weekly Installment'),(10,'RC','Receipt Cancel');
/*!40000 ALTER TABLE `tra_descri` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `idusers` int(11) NOT NULL AUTO_INCREMENT,
  `nic` varchar(10) NOT NULL,
  `user_password` varchar(10) DEFAULT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `user_type` varchar(20) DEFAULT NULL,
  `designation` varchar(45) DEFAULT NULL,
  `deleted` varchar(1) DEFAULT NULL,
  `current_status` varchar(1) DEFAULT NULL,
  `created_on` varchar(45) DEFAULT NULL,
  `last_accessed_on` varchar(45) DEFAULT NULL,
  `last_accessed_ip` varchar(45) DEFAULT NULL,
  `created_user_nic` varchar(10) DEFAULT NULL,
  `photo_path` varchar(100) DEFAULT NULL,
  `user_address` varchar(255) DEFAULT NULL,
  `date_of_birth` varchar(45) DEFAULT NULL,
  `user_title` varchar(10) DEFAULT NULL,
  `module_name` varchar(45) DEFAULT NULL,
  `branch_code` varchar(4) DEFAULT NULL,
  `company_code` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`idusers`,`nic`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'902554203V','cG1AMTI=','Kosala','Fernando','Top Managment','Admin','N','L','6/1/2014 2:16:18 PM','12/15/2016 3:41:54 PM','61.245.163.131',NULL,'User_Photos\\kosala.png',NULL,'1990-09-11','Mr.','A','CO','PCA'),(3,'123456789V','MTIzNDU=','Test','Test','Top Managment','Admin','N','L','2014-09-01 11:01:21','1/18/2017 11:51:02 AM','127.0.0.1','902554203V','User_Photos\\blank.png','test','2005-01-01','Mr.','A','CO','PCA'),(4,'234567891V','MTIzNDU=','V','A','Top Managment','FM','N','L','2016-04-20 10:23:55','1/13/2017 5:51:13 PM','123.231.10.206','123456789V','User_Photos\\234567891V-1.jpg','485/7A','1986-04-20','Mr.','A','CO','PCA'),(5,'860661446V','MTIzNDU=','Aravinth','Vijaya','Manager','FM','N','L','2016-04-26 11:50:48','10/18/2016 8:56:22 AM','123.231.10.206','234567891V','User_Photos\\860661446V-1.jpg','kfg','1986-03-06','Mr.','CS','CO','PCA'),(6,'908233743V','MTIzNDU=','Neshadi','Dikkumbura','Top Managment','Documentation Assistant','N','L','2016-06-14 11:36:48','1/17/2017 9:35:04 AM','123.231.10.206','123456789V','User_Photos\\908233743V-1.jpg','20, 5th Cross Road, Weragampita, Mathara.','1990-11-18','Miss','CS','CO','PCA'),(7,'918554424V','MTIzNDU=','Oshani','Wickramasinghe','Top Managment','Administration Assistant','N','L','2016-07-14 16:55:57','12/30/2016 2:40:00 PM','123.231.10.206','123456789V','User_Photos\\918554424V-1.jpg','\"Lak Niwasa\", Muwagama Lover Road, Rathnapura','1991-12-20','Miss','CS','CO','PCA'),(8,'918554424V','MTIzNDU=','Oshani','Wickramasinghe','Top Managment','Administration Assistant','N','L','2016-07-14 16:56:00','12/30/2016 2:40:00 PM','123.231.10.206','123456789V','User_Photos\\918554424V-1.jpg','\"Lak Niwasa\", Muwagama Lover Road, Rathnapura','1991-12-20','Miss','CS','CO','PCA'),(9,'937600887V','MTIz','Nadeesha','Kalpani','Top Managment','Admin. Assistant','N','L','2016-08-18 17:26:22','1/17/2017 8:46:37 AM','112.135.69.166','234567891V','User_Photos\\937600887V-1.jpg','Kosgama','1993-09-16','Miss','CS','AV','PCA'),(10,'937181132v','MTIzNDU=','Nashali','Darshika','Top Managment','Admin Assistant','N','L','2016-10-06 16:33:27','1/17/2017 10:01:55 AM','112.134.6.242','123456789V','User_Photos\\937181132v-1.jpg','13/2, Batewela, Ranala','1993-08-05','Miss','CS','KD','PCA'),(11,'878140311V','MTIzNDU=','Kumudu','Malika','Top Managment','Admin Assistant','N','L','2016-10-06 16:41:51','1/17/2017 9:21:16 AM','112.134.2.19','937600887V','User_Photos\\878140311V-1.jpg','AE/12/5, Ranpokunagama, Nittambuwa','1987-11-09','Miss','CS','NT','PCA'),(12,'957940803V','MTIzNDU=','Sanduni','Gunarathne','Top Managment','Accounts Assistant','N','L','2016-11-09 12:12:24','12/30/2016 12:41:11 PM','123.231.10.206','123456789V','User_Photos\\957940803V-1.jpg','538/B,\r\nArewwala,\r\nPannipitiya.','1995-10-20','Miss','CS','CO','PCA'),(13,'886612648V','ODg5OTQ=','Nimesha','Gnanasena','Top Managment','HOA','N','L','2016-11-10 13:06:13','1/17/2017 10:01:19 AM','123.231.10.206','123456789V','User_Photos\\886612648V-1.jpg','223/1 B,\r\nNathuduwa,\r\nKelaniya.','1988-06-09','Mrs.','CS','CO','PCA');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehiclecategory`
--

DROP TABLE IF EXISTS `vehiclecategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehiclecategory` (
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Unique number for category',
  `CategoryName` varchar(100) DEFAULT NULL COMMENT 'Category name',
  `Description` varchar(750) DEFAULT NULL COMMENT 'Description for the vehicle category',
  PRIMARY KEY (`CategoryID`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehiclecategory`
--

LOCK TABLES `vehiclecategory` WRITE;
/*!40000 ALTER TABLE `vehiclecategory` DISABLE KEYS */;
INSERT INTO `vehiclecategory` VALUES (1,'Car',''),(2,'Motor Bike',''),(3,'Van',''),(4,'Pick up',''),(5,'Double cab',''),(6,'SUV',''),(7,'Mini Van',''),(8,'Truck',''),(9,'Coach',''),(10,'Bus',''),(11,'Motor Lorry',''),(12,'Motor Boat',''),(13,'Cab',NULL),(14,'Three Wheeler',NULL),(15,'Jeep',NULL);
/*!40000 ALTER TABLE `vehiclecategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehiclemake`
--

DROP TABLE IF EXISTS `vehiclemake`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehiclemake` (
  `MakeID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Unique number for vehicle brand',
  `MakeName` varchar(100) DEFAULT NULL COMMENT 'Name of the vehicle brand',
  `Description` varchar(750) DEFAULT NULL COMMENT 'Description for the vehicle brand',
  PRIMARY KEY (`MakeID`)
) ENGINE=MyISAM AUTO_INCREMENT=46 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehiclemake`
--

LOCK TABLES `vehiclemake` WRITE;
/*!40000 ALTER TABLE `vehiclemake` DISABLE KEYS */;
INSERT INTO `vehiclemake` VALUES (1,'Alfa Romeo',''),(2,'Audi',''),(3,'Austin',''),(4,'BMW',''),(5,'Bajaj',''),(6,'Benz',''),(7,'CAL',''),(8,'Ceygra',''),(9,'Crysler',''),(10,'Daewoo',''),(11,'Daihatsu',''),(12,'Ducati',''),(13,'Electra',''),(14,'Fiat',''),(15,'Ford',''),(16,'Hero Honda',''),(17,'Honda',''),(18,'Honda',''),(19,'Hyundai',''),(20,'Isuzu',''),(21,'Kawasaki',''),(22,'Kia',''),(23,'Kinetic',''),(24,'Maruti',''),(25,'Mazda',''),(26,'Micro',''),(27,'Mitsubishi',''),(28,'Nissan',''),(29,'Perodua',''),(30,'Proton',''),(31,'Ssangyong',''),(32,'Suzuki',''),(33,'Suzuki',''),(34,'TVS',''),(35,'Toyota',''),(36,'Volkswagen',''),(37,'Yamaha',''),(38,'Tata',''),(39,'Land Rover',NULL),(40,'Leyland',NULL),(41,'Chevrolet',NULL),(42,'Peugeot',NULL),(43,'Others',NULL),(44,'Chery',NULL),(45,'SUBARU',NULL);
/*!40000 ALTER TABLE `vehiclemake` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `villages_name`
--

DROP TABLE IF EXISTS `villages_name`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `villages_name` (
  `idvillages_name` int(11) NOT NULL AUTO_INCREMENT,
  `city_code` varchar(45) DEFAULT NULL,
  `villages_name` varchar(45) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idvillages_name`)
) ENGINE=InnoDB AUTO_INCREMENT=352 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `villages_name`
--

LOCK TABLES `villages_name` WRITE;
/*!40000 ALTER TABLE `villages_name` DISABLE KEYS */;
INSERT INTO `villages_name` VALUES (1,'CO','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(2,'CO','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(3,'CO','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(4,'CO','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(5,'CO','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(6,'CO','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(7,'CO','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(8,'CO','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(9,'CO','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(10,'CO','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(11,'CO','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(12,'CO','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(13,'CO','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(14,'CO','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(15,'CO','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(16,'CO','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(17,'CO','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(18,'CO','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(19,'CO','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(20,'CO','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(21,'CO','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(22,'CO','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(23,'CO','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(24,'CO','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(25,'CO','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(26,'CO','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(27,'CO','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(28,'CO','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(29,'CO','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(30,'CO','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(31,'CO','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(32,'CO','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(33,'CO','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(34,'CO','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(35,'CO','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(36,'CO','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(37,'CO','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(38,'CO','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(39,'CO','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(40,'CO','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(41,'CO','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(42,'CO','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(43,'CO','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(44,'CO','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(45,'CO','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(46,'CO','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(47,'CO','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(48,'CO','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(49,'CO','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(50,'CO','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(51,'CO','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(52,'CO','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(53,'CO','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(54,'CO','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(55,'CO','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(56,'CO','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(57,'CO','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(58,'CO','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(59,'CO','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(60,'CO','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(61,'CO','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(62,'CO','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(63,'CO','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(64,'CO','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(65,'CO','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(66,'CO','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(67,'CO','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(68,'CO','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(69,'CO','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(70,'CO','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(71,'CO','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(72,'CO','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(73,'CO','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(74,'CO','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(75,'CO','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(76,'CO','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(77,'CO','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(78,'CO','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(79,'CO','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(80,'CO','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(81,'WP','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(82,'WP','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(83,'WP','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(84,'WP','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(85,'WP','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(86,'WP','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(87,'WP','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(88,'WP','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(89,'WP','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(90,'WP','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(91,'WP','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(92,'WP','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(93,'WP','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(94,'WP','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(95,'WP','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(96,'WP','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(97,'WP','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(98,'WP','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(99,'WP','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(100,'WP','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(101,'WP','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(102,'WP','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(103,'WP','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(104,'WP','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(105,'WP','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(106,'WP','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(107,'WP','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(108,'WP','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(109,'WP','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(110,'WP','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(111,'WP','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(112,'WP','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(113,'WP','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(114,'WP','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(115,'WP','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(116,'WP','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(117,'WP','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(118,'WP','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(119,'WP','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(120,'WP','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(121,'WP','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(122,'WP','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(123,'WP','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(124,'WP','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(125,'WP','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(126,'WP','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(127,'WP','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(128,'WP','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(129,'WP','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(130,'WP','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(131,'WP','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(132,'WP','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(133,'WP','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(134,'WP','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(135,'WP','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(136,'WP','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(137,'WP','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(138,'WP','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(139,'WP','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(140,'WP','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(141,'WP','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(142,'WP','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(143,'WP','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(144,'WP','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(145,'WP','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(146,'WP','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(147,'WP','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(148,'WP','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(149,'WP','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(150,'WP','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(151,'WP','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(152,'WP','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(153,'WP','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(154,'WP','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(155,'WP','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(156,'WP','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(157,'WP','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(158,'WP','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(159,'WP','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(160,'WP','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(161,'KD','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(162,'KD','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(163,'KD','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(164,'KD','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(165,'KD','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(166,'KD','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(167,'KD','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(168,'KD','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(169,'KD','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(170,'KD','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(171,'KD','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(172,'KD','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(173,'KD','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(174,'KD','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(175,'KD','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(176,'KD','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(177,'KD','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(178,'KD','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(179,'KD','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(180,'KD','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(181,'KD','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(182,'KD','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(183,'KD','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(184,'KD','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(185,'KD','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(186,'KD','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(187,'KD','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(188,'KD','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(189,'KD','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(190,'KD','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(191,'KD','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(192,'KD','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(193,'KD','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(194,'KD','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(195,'KD','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(196,'KD','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(197,'KD','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(198,'KD','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(199,'KD','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(200,'KD','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(201,'KD','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(202,'KD','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(203,'KD','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(204,'KD','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(205,'KD','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(206,'KD','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(207,'KD','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(208,'KD','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(209,'KD','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(210,'KD','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(211,'KD','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(212,'KD','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(213,'KD','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(214,'KD','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(215,'KD','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(216,'KD','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(217,'KD','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(218,'KD','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(219,'KD','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(220,'KD','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(221,'KD','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(222,'KD','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(223,'KD','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(224,'KD','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(225,'KD','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(226,'KD','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(227,'KD','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(228,'KD','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(229,'KD','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(230,'KD','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(231,'KD','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(232,'KD','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(233,'KD','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(234,'KD','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(235,'KD','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(236,'KD','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(237,'KD','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(238,'KD','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(239,'KD','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(240,'KD','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(241,'PL','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(242,'PL','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(243,'PL','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(244,'PL','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(245,'PL','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(246,'PL','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(247,'PL','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(248,'PL','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(249,'PL','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(250,'PL','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(251,'PL','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(252,'PL','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(253,'PL','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(254,'PL','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(255,'PL','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(256,'PL','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(257,'PL','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(258,'PL','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(259,'PL','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(260,'PL','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(261,'PL','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(262,'PL','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(263,'PL','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(264,'PL','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(265,'PL','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(266,'PL','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(267,'PL','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(268,'PL','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(269,'PL','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(270,'PL','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(271,'PL','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(272,'PL','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(273,'PL','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(274,'PL','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(275,'PL','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(276,'PL','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(277,'PL','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(278,'PL','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(279,'PL','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(280,'PL','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(281,'PL','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(282,'PL','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(283,'PL','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(284,'PL','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(285,'PL','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(286,'PL','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(287,'PL','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(288,'PL','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(289,'PL','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(290,'PL','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(291,'PL','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(292,'PL','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(293,'PL','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(294,'PL','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(295,'PL','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(296,'PL','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(297,'PL','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(298,'PL','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(299,'PL','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(300,'PL','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(301,'PL','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(302,'PL','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(303,'PL','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(304,'PL','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(305,'PL','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(306,'PL','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(307,'PL','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(308,'PL','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(309,'PL','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(310,'PL','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(311,'PL','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(312,'PL','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(313,'PL','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(314,'PL','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(315,'PL','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(316,'PL','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(317,'PL','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(318,'PL','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(319,'PL','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(320,'PL','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(321,'PL','Thalapathpitiya - South','123456789V','123.231.124.4','2016-05-10 10:29:38'),(322,'KD','Kaduwela - Sandasiripura','123456789V','123.231.124.4','2016-05-19 11:48:46'),(323,'KD','Yakala','123456789V','123.231.124.4','2016-05-20 13:47:02'),(324,'KD','Nelum Pedesa','123456789V','123.231.124.4','2016-05-23 16:00:54'),(325,'PL','Molpe','123456789V','123.231.124.4','2016-06-03 11:48:58'),(326,'PL','Sudarshi - Polgaovita','123456789V','123.231.124.4','2016-06-06 08:51:02'),(327,'PL','Honnanthara south','123456789V','123.231.124.4','2016-06-06 11:12:10'),(328,'WP','Kahatapitiya','123456789V','123.231.124.4','2016-06-06 13:22:40'),(329,'KD','Walgama','123456789V','123.231.124.4','2016-06-06 14:22:25'),(330,'AV','Kahatapitiya','123456789V','123.231.124.4','2016-06-07 09:27:45'),(331,'AV','Kotahara Kanda','123456789V','112.134.157.74','2016-06-07 09:44:26'),(332,'KD','Oruwala','123456789V','123.231.124.4','2016-06-07 11:25:05'),(333,'AV','Salawa','123456789V','112.134.243.37','2016-06-09 10:37:21'),(334,'KD','Batapotha','123456789V','112.134.98.157','2016-06-09 12:22:38'),(335,'KD','Pothuarawa','123456789V','123.231.124.4','2016-06-09 16:30:26'),(336,'PL','Badovita Araliya','123456789V','123.231.124.4','2016-06-10 09:27:00'),(337,'PL','Ran tharu','123456789V','123.231.124.4','2016-06-10 10:27:00'),(338,'AV','Avissawella','123456789V','112.134.215.8','2016-06-13 10:55:42'),(339,'PL','Liyasewana','123456789V','123.231.124.4','2016-06-14 11:08:39'),(340,'KD','Rathnara Kaduwela','123456789V','112.134.96.237','2016-06-17 15:40:43'),(341,'KD','Nobendi Mawatha -Kaduwela','123456789V','112.134.96.38','2016-06-22 14:52:00'),(342,'KD','Mullegama- Kaduwela','123456789V','112.134.96.144','2016-06-23 09:46:11'),(343,'KD','Wekkawaththa -Kaduwela','123456789V','112.134.97.30','2016-06-23 13:29:18'),(344,'KD','Thalahena -Kaduwela','123456789V','112.134.97.243','2016-06-28 12:17:53'),(345,'NT','Nittambuwa','123456789V','123.231.123.243','2016-08-15 16:31:28'),(346,'KG','Kegalle','123456789V','123.231.10.206','2016-10-06 11:58:05'),(347,'NT','Kiriwandala','123456789V','123.231.10.206','2016-10-19 10:12:23'),(348,'BG','Bandaragama','123456789V','123.231.10.206','2016-11-08 16:10:31'),(349,'MG','Mathugama','123456789V','112.134.40.243','2016-11-25 08:31:08'),(350,'PL1','Piliyandala Old','123456789V','175.157.34.91','2016-12-07 17:06:14'),(351,'PL','Lakki','123456789V','127.0.0.1','2017-01-30 11:41:55');
/*!40000 ALTER TABLE `villages_name` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-05 19:30:23