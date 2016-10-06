### Methods Student

### Fields


* private int _id;
* private string _firstName;
* private string _lastName;
* private string _email;
* private string _picture;
* private DateTime _startDate;_


###### Constructor:
* public Student(string firstName, string lastName, string email, string picture, DateTime startDate, int id = 0)
for Join Table using Course
* public Course(string name, DateTime startDate, int active, int id = 0)

Name|Description
---|---
GetId() | Gets ID
GetFName() | Get firstName
GetLName() | Get lastName
GetEmail() | Get string email
GetPicture() | Get string "/img.student.jpg"
GetStartDate() | Get DateTime date = new DateTime (2016, 08, 01)
Save() | Insert student's properties into a specific student_id and save that student to the Table.
UpdateAll(Student currentStudent) | Update all student's properties in the form, need to create form that already has the student information premade so the student can see what he/she is editing.
DeleteOne() | Delete 1 student using student_id @studentId
AddCourse(Course newCourse) | Using student id and class id to add all properties of a course to the student in the Join Table students_courses. This method add new Course to a student.
GetCourses() | Return List<Course from coursesList.Add(newCourse), by using select all courses from students_courses Join Table using student_id and course_id
 DeleteCourse (int classId) | Delete the individual course from a student; using class_id & student_id from students_courses Join Table. ie; student1.DeleteCourse(testCourses.GetId());

###### Static

Name| Description
---|---
GetAll() | Returns a List<Student
Student.Find(int id /student1.GetId()) | find a student using the student_id return this specific student.
DeleteAll() | delete all the students in students Table and students_courses Table.



### Methods Project

### Fields
* private int _id;
* private string _Name;
* private DateTime _date;

###### Constructor:
* public Project(string Name, DateTime , int id = 0)
for Join Table using Course
* public Course(string name, DateTime , int active, int id = 0)

Name|Discription
---|---
GetId() | Gets ID
GetFName() | Get Name
GetStartDate() | Get DateTime date = new DateTime (2016, 08, 01)
GetActive() |  int GetActive()
Save() | Insert project's properties into a specific project_id and save that project to the Table.
UpdateAll(Project currentProject) | Update all project's properties in the form, need to create form that already has the project information premade so the project can see what he/she is editing.
DeleteOne() | Delete 1 project using project_id


###### Static

Name| Description
---|---
GetAll() | Returns a List<Project
Project.Find(int id /project1.GetId()) | find a project using the project_id return this specific project.
DeleteAll() | delete all the project in project Table
