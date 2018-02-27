Insert into tpCategories([Description],[SysCode]) values
('Featured','FEATURED'),('Addon','ADDON'),('Activities','ACTIVITY'),('Accommodation','ACCOM'),('Transportation','TRANSPO');

Insert into tpUoms([Measure],[Remarks]) values
('Unit','Per unit ( Room, Car, Boat)'),('Pax','per person rate');

Insert into tpAreas([Name],[PageRemarks],[PageView],[PgFeatureImg],[Sort]) values 
('DAVAO','Davao City','DavaoPage','/Images/abreeza-mall.gif',1),
('BOHOL','One of the most popular travel and vacation destination in Philippines. Great Tour packages awaits!','BoholPage','/Images/Bohol101.png',2),
('CAMIGUIN','Northern Mindanao','CamiguinPage','/Images/SamalIslandHopping.png',3);


Insert into [tpProducts]([Name],[ShortRemarks],[PageView],[PgFeatureImg], [Sort], [tpAreasId]) values 
('City Tour','City Tour','ProductDefaultView','/Images/abreeza-mall.gif',1,1),
('Country Side Tour','Country Side Tour','ProductDefaultView','/Images/CountrySide.gif',2,1),
('Country Side Tour','7 - 9 hrs tour across the island of Bohol. Passing thru is cultural destinations and fascinating views of the main island','BoholPackages/CountrySide','/Images/Destinations/Bohol/CountrySideTour.png',1,2),
('Panglao Tour','8hrs island tour to the treasured beaches of Panglao.','BoholPackages/Panglao','/Images/Destinations/Bohol/PanglaoTour.png',2,2),
('3D2N Vacation','3Days 2 Nights Vacation Package. staying at the heart of the most visited beaches of Panglao.','BoholPackages/3d2n_Panglao_Alona42','/Images/Destinations/Bohol/3d2nBoholVacation.png',4,2),
('Domestic Airticket Manila - Bohol','Economy Airticket Manila - Tagbilaran','BoholPackages/AirTicket','/Images/Destinations/Bohol/Airlines101.png',3,2),
('Bohol Bee Farm - Panglao, Bohol','Resort & Restaurant','ProductDefaultView','/Images/Destinations/Bohol/accom_boholbeefarm_04.jpg',8,2),
('Alona Tropical Beach Resort','Resort and Accommodation','ProductDefaultView','/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-10.jpg',5,2),
('South Palms Resort Panglao','Resort and Accommodation','ProductDefaultView','/Images/Destinations/Bohol/accom_southpalmresort_08.jpg',6,2),
('Dumaluan Beach Resort - Panglao','Resort and Accommodation','ProductDefaultView','/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-09.jpg',7,2),
('Bohol Beach Club - Panglao, Bohol','Resort and Accommodation','ProductDefaultView','/Images/Destinations/Bohol/accom_bohol_beachclub_02.jpg',4,2),
('Island Hopping','Dolphin and whale watching, Island Hopping (Balicasag and Virgin Island)','BoholPackages/IslandHopping','/Images/Destinations/Bohol/Attraction_BoholIslandHopping.png',3,2);

Insert into [tpProductImages]([tpProductsId], [ImgPath],[Desc],[AltName],[Sort]) values
-- Bohol -CountrySide tour --
(3,'/Images/Destinations/Bohol/BloodCompactShrine.jpg','Blood Compact Shrine','Blood Compact Shrine',1),
(3,'/Images/Destinations/Bohol/LobocRiverCruising.jpg','Loboc River Cruising','Loboc River Cruising',2),
(3,'/Images/Destinations/Bohol/BaclayonChurch.jpg','Baclayon Church','BaclayonChurch.jpg',3),
(3,'/Images/Destinations/Bohol/ChocolateHills.jpg','Chocolate Hills','ChocolateHills.jpg',4),
(3,'/Images/Destinations/Bohol/ManMadeForest.jpg','Man Made Forest','ManMadeForest.jpg',5),
(3,'/Images/Destinations/Bohol/BloodCompactShrine.jpg','Blood Compact Shrine','Blood Compact Shrine',6),
(3,'/Images/Destinations/Bohol/Tarsier.jpg','Tarsier','Tarsier.jpg',7),
-- Bohol -Panglao tour --
(4,'/Images/Destinations/Bohol/attraction_Panglao_dauis_church.jpg','Dauis Church','Dauis Church',1),
(4,'/Images/Destinations/Bohol/attraction_Panglao_Hinagdanan_Cave.jpg','Hinagdanan Cave','Hinagdanan Cave',2),
(4,'/Images/Destinations/Bohol/attraction_Panglao_church.jpg','Panglao Church','Panglao Church',3),
(4,'/Images/Destinations/Bohol/attraction_Panglao_beefarm.jpg','Bee Farm','Bee Farm',4),
(4,'/Images/Destinations/Bohol/attraction_Panglao_beach1.jpg','Beach Resort','Beach Resort',5),
(4,'/Images/Destinations/Bohol/attraction_Panglao_beach2.jpg','Beach Resort','Beach Resort',6),
(4,'/Images/Destinations/Bohol/attraction_Panglao_beach3.jpg','Beach Resort','Beach Resort',7),
(4,'/Images/Destinations/Bohol/attraction_Panglao_beach4.jpg','Beach Resort','Beach Resort',8),
-- Bohol -3d 2n vacation --
(5,'/Images/Destinations/Bohol/holiday_bohol_3d2n_01.jpg','Alona42 Beach Resort','alona42',1),
(5,'/Images/Destinations/Bohol/holiday_bohol_3d2n_02.jpg','Hinagdanan Cave','Hinagdanan Cave',2),
(5,'/Images/Destinations/Bohol/holiday_bohol_3d2n_03.jpg','Panglao Church','Panglao Church',3),
(5,'/Images/Destinations/Bohol/holiday_bohol_3d2n_04.jpg','Bee Farm','Bee Farm',4),
(5,'/Images/Destinations/Bohol/holiday_bohol_3d2n_05.jpg','Beach Resort','Beach Resort',5),
-- Bohol -Bee Farm resort and Restaurant--
(7,'/Images/Destinations/Bohol/accom_boholbeefarm_01.jpg','Bee Farm Restaurant','Bee Farm Restaurant',1),
(7,'/Images/Destinations/Bohol/accom_boholbeefarm_02.jpg','Ocean view','Ocean view',2),
(7,'/Images/Destinations/Bohol/accom_boholbeefarm_03.jpg','at night','Bee farm at night',3),
(7,'/Images/Destinations/Bohol/accom_boholbeefarm_04.jpg','Pool View','Bee farm Pool View',4),
(7,'/Images/Destinations/Bohol/accom_boholbeefarm_05.jpg','Pool','Bee Farm Pool',5),
(7,'/Images/Destinations/Bohol/accom_boholbeefarm_06.jpg','Garden','Bee Farm Garden',6),
-- Alona Tropical Beach Resort--
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-01.jpg','','Alona Tropical Beach Resort',1),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-02.jpg','','Alona Tropical Beach Resort',2),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-03.jpg','','Alona Tropical Beach Resort',3),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-04.jpg','','Alona Tropical Beach Resort',4),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-05.jpg','','Alona Tropical Beach Resort',5),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-06.jpg','','Alona Tropical Beach Resort',6),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-07.jpg','','Alona Tropical Beach Resort',7),
--(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-08.jpg','','Alona Tropical Beach Resort',8),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-09.jpg','','Alona Tropical Beach Resort',9),
--(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-10.jpg','','Alona Tropical Beach Resort',10),
--(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-11.jpg','','Alona Tropical Beach Resort',11),
(8,'/Images/Destinations/Bohol/accom_alona-tropical-beach-resort-12.jpg','','Alona Tropical Beach Resort',12),
-- South Palms Beach Resort--
(9,'/Images/Destinations/Bohol/accom_southpalmresort_01.jpg','','South Palms Beach Resort',1),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_02.jpg','','South Palms Beach Resort',2),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_03.jpg','','South Palms Beach Resort',3),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_04.jpg','','South Palms Beach Resort',4),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_05.jpg','','South Palms Beach Resort',5),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_06.jpg','','South Palms Beach Resort',6),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_07.jpg','','South Palms Beach Resort',7),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_08.jpg','','South Palms Beach Resort',8),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_09.jpg','','South Palms Beach Resort',9),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_10.jpg','','South Palms Beach Resort',10),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_11.jpg','','South Palms Beach Resort',11),
(9,'/Images/Destinations/Bohol/accom_southpalmresort_12.jpg','','South Palms Beach Resort',12),
-- Dumaluan Beach Resort--
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-01.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-02.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-03.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-04.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-05.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-06.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-07.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-08.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-09.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-10.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-11.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-12.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-13.jpg','','Dumaluan beach resort',1),
(10,'/Images/Destinations/Bohol/accom_Dumaluan_beach-resort-14.jpg','','Dumaluan beach resort',1),
-- Bohol Beach Club--
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_01.jpg','','Bohol Beach Club',1),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_02.jpg','','Bohol Beach Club',2),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_03.jpg','','Bohol Beach Club',3),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_04.jpg','','Bohol Beach Club',4),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_05.jpg','','Bohol Beach Club',5),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_06.jpg','','Bohol Beach Club',6),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_07.jpg','','Bohol Beach Club',7),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_08.jpg','','Bohol Beach Club',8),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_09.jpg','','Bohol Beach Club',9),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_10.jpg','','Bohol Beach Club',10),
(11,'/Images/Destinations/Bohol/accom_bohol_beachclub_11.jpg','','Bohol Beach Club',11),
-- Bohol - Island Hopping --
(12,'/Images/Destinations/Bohol/Attraction_BoholIslandHopping.png','','Bohol Island Hopping',1),
(12,'/Images/Destinations/Bohol/attraction_islandHopping_virgin_island_01.JPG','','Island Hopping Virgin Island Bohol ',2),
(12,'/Images/Destinations/Bohol/attraction_islandHopping.jpg','','Bohol Island Hopping',3),
(12,'/Images/Destinations/Bohol/attraction_islandHopping_balicasag_island_02.jpg','','Island Hopping Balicasag Island Bohol ',4),
(12,'/Images/Destinations/Bohol/attraction_islandHopping_balicasag_island_04.jpg','','Island Hopping Balicasag Island Bohol ',5),
(12,'/Images/Destinations/Bohol/attraction_islandHopping_snorkeling_01.jpg','','Island Hopping Snorkeling Balicasag Island Bohol ',6),
(12,'/Images/Destinations/Bohol/attraction_islandHopping_snorkeling_02.jpg','','Island Hopping Snorkeling Balicasag Island Bohol ',7),
(12,'/Images/Destinations/Bohol/attraction_islandHopping_snorkeling_03.jpg','','Island Hopping Snorkeling Balicasag Island Bohol ',8);


Insert into tpProdCats([tpCategoryId],[tpProductsId]) values
(1,1),(1,2), -- Davao
(1,3),(1,4),(1,5),(1,12), -- Bohol - Featured - Tour Packages 
(2,6),(2,7),(2,8),(2,9),(2,10),(2,11); -- bohol add on products

Insert into tpProdRates([tpProductsId],[tpUomId],[GroupOf],[Rate],[Remarks],[Sort]) values
(3,2,1,4250,'',1),(3,2,2,2600,'',1),(3,2,3,2100,'',1),(3,2,4,1950,'',1),(3,2,5,1800,'',1),(3,2,6,1700,'',1),(3,2,7,1600,'',1),(3,2,8,1550,'',1),(3,2,9,1450,'',1),(3,2,10,1350,'',1);

Insert into tpProductDescs([tpProductsId],[tpDescH1],[tpDescH2], [tpDesc],[Sort]) values
(7,'Garden Rooms - Php3,000','(12 units, 25sqm, 3pax)','Inspired by fruits and vegetables ingredients with farm.',1),
(7,'Deluxe Rooms - Php4,000','(8 units, 30sqm, 3pax)','These beehive rooms are our garden view rooms. Have veranda and lounge.',2),
(7,'Family Rooms - Php5,000','(6 units)','2 queen size beds, 2 toilet and bath',3),
(7,'Ocean View - Php6,000','(8 units)','Spacious and veranda and lounge with excellent view of the beach. 1 king size beds and 1 single bed',4),
(7,'','','-------------------------------------',5),
(7,'Extra Person - Php800/night','','',6),
(7,'Amenities','','- Farm Tour (Organic farming, Craft & Livelihood, Raffia Weaving, Bee Colony)',7),
(7,'','','- Dive Center',8),
(7,'','','- Massage SPA and Wellness',9),
(7,'','','- Function Halls (Wedding, Birthday, Special Events)',10),
-- Alona rooms --
(8,'Double Deluxe','Php 3,360 per room/night','Tax inclusive',1),
(8,'','Php 4,015 per room/night','With BreakFast, Tax inclusive',2),
(8,'','Php 4,730 per room/night','Half Board, Tax inclusive',3),
(8,'','Php 5,445 per room/night','Full Board, Tax inclusive',4),
(8,'Suite Beach Front','Php 3,360 per room/night','Tax inclusive',5),
(8,'','Php 6,815 per room/night','With BreakFast, Tax inclusive',6),
(8,'','Php 7,530 per room/night','Half Board, Tax inclusive',7),
(8,'','Php 8,245 per room/night','Full Board, Tax inclusive',8),
(8,'Suite Pool View','Php 6,750 per room/night','Tax inclusive',9),
(8,'','Php 7,450 per room/night','With BreakFast, Tax inclusive',10),
(8,'','Php 8,130 per room/night','Half Board, Tax inclusive',11),
(8,'','Php 8,840 per room/night','Full Board, Tax inclusive',12),

-- South Palms  --
(9,'Deluxe - Double or Twin','Php 9,125 per night Pool View','With Breakfast for 2',1),
(9,'','Php 11,050 per night Beach Front','With Breakfast for 2',2),
(9,'Premium - Double or Twin','Php 18,650 per night Beach Front','With Breakfast for 2',3),
(9,'Panglao Villa','Php 39,050 per night','With Breakfast for 2',3),

-- Dumaluan  --
(10,'Room Rates','No Available as of this time','Contact our travel consultant for reservation',1),

-- Bohol Beach Club --
(11,'Room Rates','No Available as of this time','Contact our travel consultant for reservation',1);


Insert into tpKeywords([Keyword],[tpProductsId]) values
('Bohol','3'),('Tour','3'),('Travel','3'),('Vacation','3'),('Package','3'),
('Bohol','4'),('Tour','4'),('Travel','4'),('Vacation','4'),('Package','4'),
('Bohol','5'),('Tour','5'),('Travel','5'),('Vacation','5'),('Package','5'),
('Bohol','6'),('Tour','6'),('Travel','6'),('Vacation','6'),('Package','6'),
('Bohol','7'),('Tour','7'),('Travel','7'),('Vacation','7'),('Package','7'),
('Bohol','8'),('Tour','8'),('Travel','8'),('Vacation','8'),('Package','8'),
('Bohol','9'),('Tour','9'),('Travel','9'),('Vacation','9'),('Package','9'),
('Bohol','10'),('Tour','10'),('Travel','10'),('Vacation','10'),('Package','10'),
('Bohol','11'),('Tour','11'),('Travel','11'),('Vacation','11'),('Package','11'),
('Bohol','12'),('Tour','12'),('Travel','12'),('Vacation','12'),('Package','12');


Insert into tpBacklinks([LinkType],[LinkUrl],[Description],[LinkExpiry],[Status]) values
('PRODUCT','http://realbreezedavaotours.com/','Real Breeze Davao - Affordable Tour Packages in Davao','2020-01-01','ACT'),
('PRODUCT','http://davaotourpackages.com/','Popular Tour Packages in Davao','2020-01-01','ACT'),
('PRODUCT','http://www.ajdavaocarrental.com/','AJ Davao Car Rental - Rent a car in Davao','2020-01-01','ACT'),
('PRODUCT','http://realwheelsdavao.com/','Real Wheels Davao  Rent a car in Davao','2020-01-01','ACT');
