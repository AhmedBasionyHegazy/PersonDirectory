Key Features
1-Repository Pattern: Clean separation of data access

2-Dependency Injection: Flexible service composition

3-Strategy Pattern: Different data source strategies

4-Async/Await: Full async pipeline

5-Entity Framework Core: For SQL Server access

6-Docker Support: Ready for containerization

-------------Execution Plan--------------------------------------

1- run this on sql server 

use [PersonDirectory]

CREATE TABLE Person_Details (
    [id] int IDENTITY(101, 1) PRIMARY KEY,
    [name] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [telephone Number] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [address] varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [country] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

INSERT INTO Person_Details
(
    [name],
    [telephone Number],
    [address],
    [country]
)
VALUES
(
    'Ahmed Mohammed',
    '20-010334445',
    '10 Road Street',
    'Egypt'
),
(
    'Mona Mahmoud',
    '20-010334445',
    '11 Road Street',
    'Egypt'   
),
(
    'Mohammed Rabie',
    '970-111111111',
    '15 Road Street',
    'Palestine'
),
(
    'Ana yousif',
    '961-111111111',
    '20 Road Street',
    'Lebanon'
);

2- create csv file as data.csv with this format 

First Name,Last Name,Country code,Number,Full Address
Ahmed,Amr,20,122002020,"10 Road Street, Egypt"
Mohamed,Khaled,20,444444030,"11 Road Street, Egypt"
Amr,Bahy,20,123409586,"12 Road Street, Egypt"
Mostafa,Mohame,20,109345677,"13 Road Street, Egypt"
Reem,Akram,20,333333444,"14 Road Street, Egypt"
Sara,Mohammed,20,109345677,"15 Road Street, Egypt"
Monica,Samy,212,222223334,"16 Road Street, Morocco"
Rana,Ahmed,966,444444030,"17 Road Street, Saudi Arabia"

3- run project ---->
