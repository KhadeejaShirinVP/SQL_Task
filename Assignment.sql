create database ConnectionProject
use ConnectionProject

create table Engineers(
Eng_ID int primary key identity (101,1) not null,
Eng_Name varchar (100) not null,
Eng_Age int not null
);

select *from Engineers
insert into Engineers(Eng_Name,Eng_Age) values ('Afsal',29)

Update Engineers
set Eng_Age=28
where Eng_ID=102

delete from Engineers where Eng_ID=102



