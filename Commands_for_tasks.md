// Пункты 1-5 задания
cat > HomeAnimals
dog 1, dog 2, dog 3
cat 1, cat 2
hamster 1, hamster 2
cat > BeastsOfBurden
horse 1, horse 2, horse 3
camel 1, camel 2
donkey 1, donkey 2
cat  HomeAnimals BeastsOfBurden > Animals
cat Animals
mv Animals humanFriends
mkdir Nursery
mv humanFriends Nursery/

sudo apt install mysql-server
sudo apt install mysql-client
sudi dpkg -i docker-desktop -4.16.2-amd64.deb
 sudi dpkg -r docker-desktop

// Пункт 7
sudo mysql
CREATE DATABASE HumanFriends;

// Пункт 8
USE HumanFriends;
CREATE TABLE animals_type
     ( Id INT AUTO_INCREMENT PRIMARY KEY,
    Type_name VARCHAR(20) );

INSERT INTO animals_type (Type_name)
    VALUES ("домашние"),
    ("вьючные");

CREATE TABLE home_animals
     ( Id INT AUTO_INCREMENT PRIMARY KEY,
    Kind_name VARCHAR(20),
    Type_id INT,
    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );

INSERT INTO home_animals (Kind_name, Type_id)
VALUES ("Собака", 1),
("Кошка", 1),  
("Хомяк", 1); 



CREATE TABLE BEAST_OF_BURDEN
( Id INT AUTO_INCREMENT PRIMARY KEY,
    Kind_name VARCHAR(20),
    Type_id INT,
    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );
    
INSERT INTO beast_of_burden (Kind_name, Type_id)
VALUES ("Лошадь", 2),
("Верблюд", 2),  
("Осел", 2);
CREATE TABLE dog 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(20), 
    Birthday DATE,
    Commands VARCHAR(50),
    Kind_id int,
    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE cat
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(20), 
    Birthday DATE,
    Commands VARCHAR(50),
    Kind_id int,
    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE hamster 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(20), 
    Birthday DATE,
    Commands VARCHAR(50),
    Kind_id int,
    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE horse 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(20), 
    Birthday DATE,
    Commands VARCHAR(50),
    Kind_id int,
    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE camel 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(20), 
    Birthday DATE,
    Commands VARCHAR(50),
    Kind_id int,
    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE donkey 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(20), 
    Birthday DATE,
    Commands VARCHAR(50),
    Kind_id int,
    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

// Пункт 9
INSERT INTO dog (Name, Birthday, Commands, Kind_id)
VALUES ('Арчи', '2012-01-01', 'ко мне, лежать, лапу, голос', 1),
('Стаф', '2019-06-12', "сидеть, лежать, лапу", 1);

INSERT INTO cat (Name, Birthday, Commands, Kind_id)
VALUES ('Злата', '2010-01-20', 'кушать', 2),
('Муська', '2009-06-12', "кыс-кыс", 2);

INSERT INTO hamster (Name, Birthday, Commands, Kind_id)
VALUES ('Нюша', '2020-12-20', 'свали', 3);

INSERT INTO horse (Name, Birthday, Commands, Kind_id)
VALUES ('Буцефал', '2020-12-20', 'но, тпруу', 1);

INSERT INTO camel (Name, Birthday, Commands, Kind_id)
VALUES ('Араб', '2021-12-20', 'вниз', 2);

INSERT INTO donkey (Name, Birthday, Commands, Kind_id)
VALUES ('Иа', '2022-10-01', 'пошел', 3);
// Пункт 10
SET SQL_SAFE_UPDATES = 0;
DELETE FROM camel;

SELECT Name, Birthday, Commands FROM horse
UNION SELECT  Name, Birthday, Commands FROM donkey;

// Пункт 11
CREATE TEMPORARY TABLE animals AS 
SELECT *, 'Лошадь' as kind FROM horse
UNION SELECT *, 'Осел' AS kind FROM donkey
UNION SELECT *, 'Собака' AS kind FROM dog
UNION SELECT *, 'Кошка' AS kind FROM cat
UNION SELECT *, 'Хомяк' AS kind FROM hamster;

CREATE TABLE yang_animal AS
SELECT Name, Birthday, Commands, kind, TIMESTAMPDIFF(MONTH, Birthday, CURDATE()) AS Age_in_month
FROM animals WHERE Birthday BETWEEN ADDDATE(curdate(), INTERVAL -3 YEAR) AND ADDDATE(CURDATE(), INTERVAL -1 YEAR);
 
SELECT * FROM yang_animal;

// Пункт 12
SELECT h.Name, h.Birthday, h.Commands, bob.Kind_name, ya.Age_in_month 
FROM horse h
LEFT JOIN yang_animal ya ON ya.Name = h.Name
LEFT JOIN beast_of_burden bob ON bob.Id = h.Kind_id
UNION 
SELECT d.Name, d.Birthday, d.Commands, bob.Kind_name, ya.Age_in_month 
FROM donkey d 
LEFT JOIN yang_animal ya ON ya.Name = d.Name
LEFT JOIN beast_of_burden bob ON bob.Id = d.Kind_id
UNION
SELECT c.Name, c.Birthday, c.Commands, ha.Kind_name, ya.Age_in_month 
FROM cat c
LEFT JOIN yang_animal ya ON ya.Name = c.Name
LEFT JOIN home_animals ha ON ha.Id = c.Kind_id
UNION
SELECT d.Name, d.Birthday, d.Commands, ha.Kind_name, ya.Age_in_month 
FROM dog d
LEFT JOIN yang_animal ya ON ya.Name = d.Name
LEFT JOIN home_animals ha ON ha.Id = d.Kind_id
UNION
SELECT hm.Name, hm.Birthday, hm.Commands, ha.Kind_name, ya.Age_in_month 
FROM hamster hm
LEFT JOIN yang_animal ya ON ya.Name = hm.Name
LEFT JOIN home_animals ha ON ha.Id = hm.Kind_id;
