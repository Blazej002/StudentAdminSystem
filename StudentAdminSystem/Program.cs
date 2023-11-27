namespace StudentAdminSystem
{
    internal class Program
    {
        static void Main()
        {
            //Subjects
            var Courses = new List<Fag>
            {
                new("Math", 15, 1),
                new("English", 20, 2),
                new("Coding", 40, 3)
            };

            //Students Dummy data
            var Students = new List<Student>
            {
                new("Blazej", 21, Courses, 101),
                new("Emily", 22, Courses, 102),
                new("Jacky", 30, Courses, 103),
            };

            //Grades Dummy data
            var st1 = new Grades(Students[0], Courses[0], 75);
            var st1Eng = new Grades(Students[0], Courses[1], 75);

            StartPrompt();

            while (true)
            {
                Console.Clear();

                mainMenu();
                var choice = Console.ReadLine();

                Console.Clear();

                if (int.TryParse(choice, out int check))
                {
                    if (Convert.ToInt32(choice) == 1) ShowCourses(Courses);

                    if (Convert.ToInt32(choice) == 2) ShowStudents(Students, Courses);
                }
            }
        }

        private static void ShowStudents(List<Student> students, List<Fag> courses)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("");
            foreach (var student in students)
            {
                Console.WriteLine($"ID {student.Id} : {student.Name} , Age : {student.Age}");
                Console.WriteLine("........................");
            }

            Console.WriteLine("");


            Console.WriteLine("---------------------------------------");
            StdNav(students, courses);
        }

        public static void StdNav(List<Student> students, List<Fag> courses)
        {
            Console.WriteLine("1. Show Student (ID) ");
            Console.WriteLine("2. Add Student       3. Remove student");
            Console.WriteLine("5. Back");
            //Console.WriteLine("5. Prev. Page        6. Next page");
            Console.WriteLine("---------------------------------------");

            var userInp = Console.ReadLine();
            switch (userInp)
            {
                case "1":
                    ShowGrades(students, courses);
                    break;
                case "2":
                    NewStudent();
                    break;
            }
        }

        private static void NewStudent()
        {
            
        }

        private static void ShowGrades(List<Student> students, List<Fag> courses)
        {
            //Finding student by id
            var id = Console.ReadLine();
            var foundIndex = FindUserById(students, id);
            Console.Clear();

            //Showing student info
            students[foundIndex].ShowStdInfo();
            var student = students[foundIndex];

            //What to do with the student
            Console.WriteLine("1. Show Grades   2. Add Grade   3. Back  4. Main");
            var inputStd = Console.ReadLine();


            if (inputStd == "1")
            {
            }
            else if (inputStd == "2")
            {
                Console.WriteLine("What class? (Subject ID)");
                //Finding subject index by searching for id
                var subj = Console.ReadLine();
                var a = Convert.ToInt32(subj);

                var SubIndex = Find(courses, a);
                var Subj = courses[SubIndex];


                Console.WriteLine("What grade?");
                var grd = Console.ReadLine();


                AddGrade(student, Subj, Convert.ToInt32(grd));

            }
            else if (inputStd == "3")
            {
                ShowStudents(students, courses);
                Console.Clear();
            }
        }

        private static int Find(List<Fag> courses, int subj)
        {
            var SubIndex = FindSubByID(subj, courses);
            return SubIndex;
        }

        public static int FindSubByID(int subj, List<Fag> courses)
        {
            int find = 0;
            int found = 0;
            foreach (var course in courses)
            {
                if (course.SubId == subj)
                {
                    found = find;
                }

                find++;
            }

            return found;
        }

        private static void AddGrade(Student student, Fag courses, int grade)
        {

        }


        public static int FindUserById(List<Student> students, string? inp)
        {
            //letter etter ID
            int find = 0;
            int found = 0;

            foreach (var student in students)
            {
                ;
                if (students[find].Id == Convert.ToInt32(inp))
                {
                    found = find;
                }

                find++;
            }

            return found;
        }

        private static void ShowCourses(List<Fag> courses)
        {
            Console.WriteLine("--------------");
            foreach (var Fag in courses)
            {
                Console.WriteLine($"ID {Fag.SubId} : {Fag.Subject} - {Fag.PointCount} points");
            }

            Console.WriteLine("--------------");
            Console.ReadKey();
        }

        private static void mainMenu()
        {
            Console.WriteLine("---- Main ----");
            Console.WriteLine("1. Subjects");
            Console.WriteLine("2. Students");
            Console.WriteLine("--------------");
        }

        private static void StartPrompt()
        {
            //Console.WriteLine("Hello, Welcome to Student Administrasion System");
            //Console.WriteLine("SAS for short");
            //Console.WriteLine("");
            //Thread.Sleep(1000);
            //Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            //Console.Clear();
        }

        public class Student
        {
            public string Name;
            public int Age;
            public int Id;
            public List<Fag> StudieProg;

            public Student(string name, int age, List<Fag> studieProg, int id)
            {
                Name = name;
                Age = age;
                Id = id;
                StudieProg = studieProg;
            }

            public void ShowStdInfo()
            {
                Console.WriteLine("----------");
                Console.WriteLine($"Id : {Id}");
                Console.WriteLine("----------");

                Console.WriteLine($"{Name}");
                Console.WriteLine($"Age : {Age}");
                Console.WriteLine("Courses :");
                foreach (var Fag in StudieProg)
                {
                    Console.WriteLine($"   - {Fag.Subject} : ID {Fag.SubId}");
                }

                Console.WriteLine("----------");
            }
        }

        public class Fag
        {
            public int SubId;
            public string Subject;
            public int PointCount;

            public Fag(string subject, int pointCount, int subId)
            {
                SubId = subId;
                Subject = subject;
                PointCount = pointCount;
            }

            public void ShowSubInfo()
            {
                Console.WriteLine();
                Console.WriteLine("----------------");
                Console.WriteLine($"Subject    : {Subject}");
                Console.WriteLine($"Points     : {PointCount}+ ");
                Console.WriteLine();
                Console.WriteLine($"Subject-ID : {SubId} ");
                Console.WriteLine("----------------");
            }
        }

        class Grades
        {
            public Student Student;
            public Fag Fag;
            public int Grade;

            public Grades(Student student, Fag fag, int grade)
            {
                Student = student;
                Fag = fag;
                Grade = grade;
            }

            public void showGrade()
            {
                Console.WriteLine($"----------------");
                Console.WriteLine($"{Fag.Subject}   : {Grade}");
                Console.WriteLine("-----------------");
                Console.WriteLine("");
            }
        }
    }
}