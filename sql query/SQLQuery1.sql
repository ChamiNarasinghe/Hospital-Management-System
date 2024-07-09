create database Hospital;

create table AddPatient(
        Name Varchar(150),
		Address Varchar(300),
		Contact bigint,
		Age int,
		Gender Varchar(10),
		Blood_Group Varchar(20),
		Major_Disease Varchar(400),
		pid bigint UNIQUE
		);

select * from AddPatient;

create table PatientMore(
              pid bigint,
			  Symptoms varchar(150),
			  Diagnosis varchar(150),
			  Medicines varchar(150),
			  ward varchar(10),
			  ward_type varchar(20)
			  );

select * from PatientMore;

create table Login(
             username varchar(50),
			 password varchar(50)
			  );

INSERT INTO Login (username, password) VALUES ('chami', '123');
INSERT INTO Login (username, password) VALUES ('admin', 'admin123');
INSERT INTO Login (username, password) VALUES ('user', 'userpass');

DELETE FROM PatientMore;



