### Student method
* private int _id;
* private string _firstName;
* private string _lastName;
* private string _email;
* private string _picture;
* private DateTime _startDate;

* public Student(string firstName, string lastName, string email, string picture, DateTime startDate, int id = 0)

* GetId, GetFName, GetLName, GetEmail, GetPicture, GetStartDate
* GetAll using List<Student> .. return List<Student> allStudents
* student1.Save
* Student.Find(int id /student1.GetId()) return foundStudent
* student1.UpdateAll(Student currentStudent)
ie: UpdateAll method .. update every properties in Student class
in the form .. need to create form that already has the student
information prefilled so the studen can see what he/she is editing.
* DeleteOne() take studentId, delete 1 student
* DeleteAll() :delete all students & students from join students_courses table.
* AddCourse(Course newCourse) take studentId & newCourse.GetId(classId)
 Add new Course to Student.
* GetCourse() return List<Course>{coursesList.Add(newCourse)}
newCourse has properties: name, sdate, active & id
- take student Id & select course from that student
* DeleteCourse (int classId)
- select from student Id and delete class_id from course
-student1.DeleteCourse(testCourse.GetId()); >how to write it 
