create database LabReservation;
use LabReservation;


drop table TimeSlots;
drop table Devices;
drop table Users;
drop table Reservations;
drop table CancelledReservations;
drop table UserFeedback;
drop table AdminRemarks;
drop table RestrictedUsers;
drop table CheckDemand;
drop table UserLog;
drop table AdminLog;



create table Devices(
	d_id varchar(25) primary key,
	d_type 	varchar(25) not null

);

create table TimeSlots(
	t_id int primary key,
	availableTime varchar(5) not null

);


create table Users(
	u_id int primary key,
	u_name varchar(25) not null,
	u_regID varchar(25) unique not null,
	u_program varchar(25) not null,
	u_semester varchar(25),
	u_contact varchar(11) unique not null,
	u_email nvarchar(25) unique not null,
	u_password nvarchar(25) not null,
);



create table Reservations(
	r_id int primary key identity(1,1),
	r_status char(1) not null Default 'P',
	r_date date not null,
	u_id int foreign key references Users(u_id),
	t_id int foreign key references TimeSlots(t_id),
	d_id varchar(25) foreign key references Devices(d_id)

);

create table CancelledReservations(
	
	cr_id int primary key,
	r_id int foreign key references Reservations(r_id)




);

create table UserFeedback(
	feedBack_id int primary key,
	feedBack varchar(255),
	r_id int foreign key references Reservations(r_id),
);


create table AdminRemarks(
	ar_id int primary key,
	remarks varchar(255),
	r_id int foreign key references Reservations(r_id),

);



create table CheckDemand(
	demand_id int primary key,
	d_id varchar(25) foreign key references Devices(d_id)

);


create table RestrictedUsers(
	
	ru_id int primary key,
	u_id int foreign key references Users(u_id) 
);

create table UserLog(
	ul_id int primary key,
	u_id int foreign key references Users(u_id),
);

create table AdminLog(
	al_id int primary key,
	u_id int foreign key references Users(u_id)
);

