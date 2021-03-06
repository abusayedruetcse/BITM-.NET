CREATE DATABASE universityDB
USE universityDB

CREATE TABLE department
(
dept_name VARCHAR(20),
building VARCHAR(15),
budget NUMERIC(12,2),
PRIMARY KEY(dept_name)
)
CREATE TABLE course
(
course_id VARCHAR(7),
title VARCHAR(50),
dept_name VARCHAR(20),
credits NUMERIC(2,0),
PRIMARY KEY(course_id),
FOREIGN KEY(dept_name) REFERENCES department
)
CREATE TABLE instructor
(
ID VARCHAR(5),
name VARCHAR(20) NOT NULL,
dept_name VARCHAR(20),
salary NUMERIC(8,2),
PRIMARY KEY(ID),
FOREIGN KEY(dept_name) REFERENCES department
)
CREATE TABLE classroom
(
building VARCHAR(15),
room_number VARCHAR(7),
capacity NUMERIC(3,0),
PRIMARY KEY(building,room_number)
)
CREATE TABLE section
(
course_id VARCHAR(7),
sec_id VARCHAR(8),
semester VARCHAR(6),
year NUMERIC(4,0),
building VARCHAR(15),
room_number VARCHAR(7),
time_slot_id VARCHAR(4),
PRIMARY KEY(course_id,sec_id,semester,year),
FOREIGN KEY(course_id) REFERENCES course,
FOREIGN KEY(building,room_number) REFERENCES classroom
)
CREATE TABLE teaches
(
ID VARCHAR(5),
course_id VARCHAR(7),
sec_id VARCHAR(8),
semester VARCHAR(6),
year NUMERIC(4,0),
PRIMARY KEY(ID,course_id,sec_id,semester,year),
FOREIGN KEY(course_id,sec_id,semester,year) REFERENCES section,
FOREIGN KEY(ID) REFERENCES instructor
)
CREATE TABLE prereq
(
course_id VARCHAR(7),
prereq_id VARCHAR(7),
PRIMARY KEY(course_id,prereq_id),
FOREIGN KEY(course_id) REFERENCES course
)
CREATE TABLE student 
(
ID VARCHAR(5),
name VARCHAR(50),
dept_name VARCHAR(20),
tot_cred NUMERIC(8,2),
PRIMARY KEY(ID),
FOREIGN KEY(dept_name) REFERENCES department
)
CREATE TABLE takes
(
ID VARCHAR(5),
course_id VARCHAR(7),
sec_id VARCHAR(8),
semester VARCHAR(6),
year NUMERIC(4,0),
grade VARCHAR(5),
PRIMARY KEY(ID,course_id,sec_id,semester,year),
FOREIGN KEY(course_id,sec_id,semester,year) REFERENCES section,
FOREIGN KEY(ID) REFERENCES student
)
//department
INSERT INTO department(dept_name,building,budget)
VALUES ('Biology','Watson',90000)
INSERT INTO department(dept_name,building,budget)
VALUES ('Comp. Sci.','Taylor',100000)
INSERT INTO department(dept_name,building,budget)
VALUES ('Elec. Eng.','Taylor',85000)
INSERT INTO department(dept_name,building,budget)
VALUES ('Finance','Painter',120000)
INSERT INTO department(dept_name,building,budget)
VALUES ('History','Painter',50000)
INSERT INTO department(dept_name,building,budget)
VALUES ('Music','Packard',80000)
INSERT INTO department(dept_name,building,budget)
VALUES ('Physics','Watson',70000)
//instructor
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('10101','Srinivasan','Comp. Sci.',000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('12121','Wu','Finance',90000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('15151','Mozart','Music',40000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('22222','Einstein','Physics',95000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('32343','El Said','History',60000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('33456','Gold','Physics',87000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('45565','Katz','Comp. Sci.',75000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('58583','Kalifieri','History',62000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('76543','Singh','Finance',80000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('76766','Crick','Biology',72000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('83821','Brandt','Comp. Sci.',92000)
INSERT INTO instructor (ID,name,dept_name,salary)
VALUES ('98456','Kim','Elec. Eng.',80000)
//course
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('BIO-101','Intro. to Biology','Biology',4)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('BIO-301','Genetics','Biology',4)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('BIO-399','Computational Biology','Biology',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('CS-101','Intro. to Computer Science','Comp. Sci.',4)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('CS-190','Game Design','Comp. Sci.',4)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('CS-315','Robotics','Comp. Sci.',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('CS-319','Image Processing','Comp. Sci.',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('CS-347','Database System Concepts','Comp. Sci.',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('EE-181','Intro. to Digital Systems','Elec. Eng.',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('FIN-201','Investment Banking','Finance',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('HIS-351','World History','History',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('MU-199','Music Video Production','Music',3)
INSERT INTO course (course_id,title,dept_name,credits)
VALUES ('PHY-101','Physical Principles','Physics',4)
//prereq
INSERT INTO prereq (course_id,prereq_id)
VALUES ('BIO-301','BIO-101')
INSERT INTO prereq (course_id,prereq_id)
VALUES ('BIO-399','BIO-101')
INSERT INTO prereq (course_id,prereq_id)
VALUES ('CS-190','CS-101')
INSERT INTO prereq (course_id,prereq_id)
VALUES ('CS-315','CS-101')
INSERT INTO prereq (course_id,prereq_id)
VALUES ('CS-319','CS-101')
INSERT INTO prereq (course_id,prereq_id)
VALUES ('CS-347','CS-101')
INSERT INTO prereq (course_id,prereq_id)
VALUES ('EE-181','PHY-101')
//classroom
INSERT INTO classroom (building,room_number)
VALUES ('Painter','514')
INSERT INTO classroom (building,room_number)
VALUES ('Watson','100')
INSERT INTO classroom (building,room_number)
VALUES ('Watson','120')
INSERT INTO classroom (building,room_number)
VALUES ('Packard','101')
INSERT INTO classroom (building,room_number)
VALUES ('Taylor','3128')
//section
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('BIO-101','1','Summer',2009 ,'Painter','514','B')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('BIO-301','1','Summer',2010 ,'Painter','514','A')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-101','1','Fall',2009 ,'Packard','101','H')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-101','1','Spring',2010 ,'Packard','101','F')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-190','1','Spring',2009 ,'Taylor','3128','E')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-190','2','Spring',2009 ,'Taylor','3128','A')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-315','1','Spring',2010 ,'Watson','120','D')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-319','1','Spring',2010 ,'Watson','100','B')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-319','2','Spring',2010 ,'Taylor','3128','C')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('CS-347','1','Fall',2009 ,'Taylor','3128','A')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('EE-181','1','Spring',2009 ,'Taylor','3128','C')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('FIN-201','1','Spring',2010 ,'Packard','101','B')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('HIS-351','1','Spring',2010 ,'Painter','514','C')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('MU-199','1','Spring',2010 ,'Packard','101','D')
INSERT INTO section (course_id,sec_id,semester,year,building,room_number,time_slot_id)
VALUES ('PHY-101','1','Fall',2009 ,'Watson','100','A')
//teaches
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('10101','CS-101','1','Fall',2009)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('10101','CS-315','1','Spring',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('10101','CS-347','1','Fall',2009)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('12121','FIN-201','1','Spring',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('15151','MU-199','1','Spring',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('22222','PHY-101','1','Fall',2009)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('32343','HIS-351','1','Spring',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('45565','CS-101','1','Spring',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('45565','CS-319','1','Spring',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('76766','BIO-101','1','Summer',2009)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('76766','BIO-301','1','Summer',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('83821','CS-190','1','Spring',2009)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('83821','CS-190','2','Spring',2009)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('83821','CS-319','2','Spring',2010)
INSERT INTO teaches(ID,course_id,sec_id,semester,year)
VALUES ('98345','EE-181','1','Spring',2009)
//student
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('00128','Zhang','Comp. Sci.',102)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('12345','Shankar','Comp. Sci.',32)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('19991','Brandt','History',80)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('23121','Chavez','Finance',110)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('44553','Peltier','Physics',56)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('45678','Levy','Physics',46)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('54321','Williams','Comp. Sci.',54)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('55739','Sanchez','Music',38)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('70557','Snow','Physics',0)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('76543','Brown','Comp. Sci.',58)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('76653','Aoi','Elec. Eng.',60)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('98765','Bourikas','Elec. Eng.',98)
INSERT INTO student (ID,name,dept_name,tot_cred)
VALUES ('98988','Tanaka','Biology',120)
//takes
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('00128','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('00128','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('12345','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('12345','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('12345','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('12345','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('19991','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('23121','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('44553','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('45678','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('45678','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('45678','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('54321','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('54321','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('55739','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('76543','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('76543','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('76543','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('98765','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('98765','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('98988','','','', ,'')
INSERT INTO takes (ID,course_id,sec_id,semester,year,grade)
VALUES ('98988','','','', ,'')



SELECT * FROM student
UPDATE instructor
SET salary=65000
WHERE ID='10101'
