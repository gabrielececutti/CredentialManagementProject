create database LogInfo
go
use LogInfo
go

create table Account (
Number int not null primary key,
Username nvarchar(50) not null,
Password nvarchar(50) not null,
Date date not null)

