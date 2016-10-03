

###### Story Board Objectives
+ I need to be able to enter students. I need to be able to enter a student's first name, last name, date they started the program, email address, and a link to their picture.
+ I need to be able to enter in courses, including the name and start date of the course, and if the course is active.  Notice that the design of courses is that there would be an "Intro to Programming: June" and an "Intro to Programming: August."
+ I need to be able to add student Friday projects.  Each project should have a name and due date.
+ I need to be able to view all students, all courses, and all projects.
+ I need to be able to add, change, and delete student projects.
+ When I click a specific student, I would like to see all their information, the courses that they took, and the grades they received in that course.
+ When I click a specific course, I would like to see the students, the grades of each student in the course, and the overall course average grade.
+ When I click a specific project, I would like to see all the grade for that course for any student who had taken the course, and the overall project grade average.

  **This is important:** _one way to do this project is to have one master join table query that SELECT the entire table and then we can use javascript to display the table. Then we can send this one table through the model._
+ The site does not need a login screen, unless there is extra time..
###### Epicodus Database VIEW
![alt text](tables.png "logo")

###### Epicodus Database SQL
```sql


CREATE DATABASE epicodus;
GO
USE epicodus;
GO

DROP TABLE IF EXISTS students;

CREATE TABLE students (
  id INTEGER NOT NULL IDENTITY(1,1),
  fname VARCHAR(255) NULL DEFAULT NULL,
  lname VARCHAR(255) NULL DEFAULT NULL,
  email VARCHAR(255) NULL DEFAULT NULL,
  picture VARCHAR(255) NULL DEFAULT NULL,
  sdate DATE NOT NULL,
  PRIMARY KEY (id)
);

DROP TABLE IF EXISTS courses;

CREATE TABLE courses (
  id INTEGER NOT NULL IDENTITY(1,1),
  name VARCHAR(255) NULL DEFAULT NULL,
  sdate DATE NOT NULL,
  active TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

DROP TABLE IF EXISTS project;

CREATE TABLE project (
  id INTEGER NOT NULL IDENTITY(1,1),
  name VARCHAR(255) NULL DEFAULT NULL,
  date DATE NOT NULL,
  PRIMARY KEY (id)
);

DROP TABLE IF EXISTS scg;

CREATE TABLE scg (
  id INTEGER NOT NULL IDENTITY(1,1),
  student_id INTEGER NULL DEFAULT NULL,
  class_id INTEGER NULL DEFAULT NULL,
  project_id INTEGER NULL DEFAULT NULL,
  grade INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

ALTER TABLE scg ADD FOREIGN KEY (student_id) REFERENCES students (id);
ALTER TABLE scg ADD FOREIGN KEY (class_id) REFERENCES courses (id);
ALTER TABLE scg ADD FOREIGN KEY (project_id) REFERENCES project (id);

-- ---
-- Test Data
-- ---

-- INSERT INTO students (id,fname,lname,email,picture,sdate) VALUES
-- ('','','','','','');
-- INSERT INTO courses (id,name,sdate,active) VALUES
-- ('','','','');
-- INSERT INTO project (id,name,date) VALUES
-- ('','','');
-- INSERT INTO scg (id,student_id,class_id,project_id,grade) VALUES
-- ('','','','','');
```
