### Course Fields
* private int _id;
* private string _name;
*private DateTime _startDate;
private int _active;_

### Methods
###### Constructor:
* public Course(string name, DateTime startDate, int active, int id = 0)
for Join Table using Student
* public Student(string fristName, string lastName, string email, string picture, DateTime startDate, int id = 0)

Name|Description
---|---
GetId() Gets ID
GetName() | Get name
GetStartDate() | Get startDate
GetActive()| Get active
Save() | INSERT courses properties into a specific course_id and save course to the course table.
UpdateAll()(Course currentCourse) | UPdate all courses properties in the form.
DeleteOne() | Delete 1 course using course_id


###### Static

Name | Description
---|---
GetAll() | Returns a list:<Course>
Course.Find(int id/course1.GetId()) | find a course using the course_id return this specific course
DeleteAll() | Delete all the courses in courses table and students_courses table.
