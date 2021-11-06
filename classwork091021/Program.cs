using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.IO;

namespace classwork091021
{
    struct Student
    {
        public string name;
        public string lastName;
        public string subject;
        public int birth;
        public int scores;

        struct Employeer
        {
            string name;
            string post;
            public int impudence;
            public bool stupidity;
            public List<Employeer> friends;
            public Employeer(string Name, string Post, int Impudence, bool Stupidity)
            {
                name = Name;
                post = Post;
                impudence = Impudence;
                stupidity = Stupidity;
                friends = null;
            }
            public override string ToString()
            {
                return name;
            }
            public static bool operator ==(Employeer E1, Employeer E2)
            {
                if (E1.name != E2.name)
                {
                    return false;
                }
                if (E1.post != E2.post)
                {
                    return false;
                }
                if (E1.impudence != E2.impudence)
                {
                    return false;
                }
                if (E1.stupidity != E2.stupidity)
                {
                    return false;
                }
                return true;
            }
            public static bool operator !=(Employeer E1, Employeer E2)
            {
                if (E1.name != E2.name)
                {
                    return true;
                }
                if (E1.post != E2.post)
                {
                    return true;
                }
                if (E1.impudence != E2.impudence)
                {
                    return true;
                }
                if (E1.stupidity != E2.stupidity)
                {
                    return true;
                }
                return false;
            }
            public void AddFriend(Employeer friend)
            {
                if (friends == null)
                    friends = new List<Employeer>(1);
                friends.Add(friend);
            }
            public Employeer[] GetFriends()
            {
                if (friends != null)
                {
                    return friends.ToArray();
                }
                else
                    return null;
            }
        }
        class Table
        {
            int number;
            string color;
            public List<Employeer> employeers;
            public Table(int Number, string Color)
            {
                number = Number;
                color = Color;
                employeers = null;
            }
            public int countEmployeers()
            {
                if (employeers == null)
                {
                    return 0;
                }
                else
                {
                    return employeers.Count;
                }
            }
            public void AddEmployeer(Employeer employeer)
            {
                if (employeers == null)
                    employeers = new List<Employeer>(1);
                employeers.Add(employeer);
            }
            public override string ToString()
            {
                return Convert.ToString(number);
            }
            public bool HaveEmployeer(Employeer employeer)
            {
                if (employeers != null)
                {
                    foreach (Employeer E in employeers)
                    {
                        if (employeer == E)
                            return true;
                    }
                }
                return false;
            }
        }
        class Program
        {
            static void AddQueue(Employeer newEmployeer, Queue<Employeer> employeers)
            {
                if (newEmployeer.stupidity)
                {
                    int count = employeers.Count;
                    int numberOvertake = 1;
                    if (newEmployeer.impudence != 0)
                    {
                        numberOvertake = newEmployeer.impudence;
                    }
                    Employeer[] copyQueue = new Employeer[employeers.Count];
                    int N = employeers.Count - numberOvertake;
                    if (N < 0) N = 0;
                    for (int i = 0; i < count; i++)
                    {
                        copyQueue[i] = employeers.Dequeue();
                    }
                    for (int i = 0; i < N; i++)
                    {
                        employeers.Enqueue(copyQueue[i]);
                    }
                    employeers.Enqueue(newEmployeer);
                    for (int i = N; i < count; i++)
                    {
                        employeers.Enqueue(copyQueue[i]);
                    }
                }
                else
                {
                    employeers.Enqueue(newEmployeer);
                }
            }
            static void Sit(Employeer employeer, Stack<Table> tables)
            {
                bool isFounded = false;
                Stack<Table> checkedTables = new Stack<Table>(tables.Count);
                int freedomNumb = 2;
                if (employeer.impudence != 0)
                {
                    freedomNumb = 3;
                }
                if (employeer.stupidity) freedomNumb = 0;
                while (!isFounded)
                {
                    Table currentTable;
                    try
                    {
                        currentTable = tables.Peek();
                    }
                    catch
                    {
                        Console.WriteLine(employeer + " обедает стоя");
                        break;
                    }
                    int countEmployeers = currentTable.countEmployeers();
                    if (countEmployeers == 0)
                    {
                        Console.WriteLine(employeer + " Сел за стол " + currentTable);
                        currentTable.AddEmployeer(employeer);
                        isFounded = true;
                    }
                    else if (countEmployeers <= freedomNumb)
                    {
                        Employeer[] friends = employeer.GetFriends();
                        if (friends != null)
                        {
                            foreach (Employeer friend in friends)
                            {
                                if (currentTable.HaveEmployeer(friend))
                                {
                                    Console.WriteLine(employeer + " Сел за стол " + currentTable);
                                    currentTable.AddEmployeer(employeer);
                                    isFounded = true;
                                }
                            }
                        }
                    }
                    checkedTables.Push(tables.Pop());
                }
                while (checkedTables.Count > 0)
                {
                    tables.Push(checkedTables.Pop());
                }
            }
            static int idStudent = 0; // Это айдишник студента, он будет ключом для нашего словаря
            static void NewStudent(Dictionary<int, Student> students)
            {
                Student newStudent;
                Console.Write("Введите фамилию студента: ");
                newStudent.lastName = Console.ReadLine();
                Console.Write("Введите имя студента: ");
                newStudent.name = Console.ReadLine();
                Console.Write("Введите год рождения студента: ");
                newStudent.birth = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите основной предмет студента: ");
                newStudent.subject = Console.ReadLine();
                Console.Write("Введите количество баллов студента: ");
                newStudent.scores = Convert.ToInt32(Console.ReadLine());
                idStudent++; // Увеличим id студента
                students.Add(idStudent, newStudent);
            }
            static void Delete(Dictionary<int, Student> students)
            {
                Console.WriteLine("Введите id Студента: ");
                int id = Convert.ToInt32(Console.ReadLine());
                students.Remove(id); // Удаляем по id
            }

            static void Sort(Dictionary<int, Student> students)
            { 
                foreach (var pair in students.OrderBy(pair => pair.Value.scores))
                {
                    //Выводим наш сортированный список
                    Console.WriteLine($"{pair.Value.lastName} {pair.Value.name} {pair.Value.subject} {pair.Value.scores}");
                }
            }
            static void Swap(List<String> array, int i1, int i2, string value1, string value2)
            {
                array[i1] = value1;
                array[i2] = value2;
            }
            //1.5
            struct Granny
            {
                string name;
                public string Name
                {
                    get
                    {
                        return name;
                    }
                    set
                    {

                    }
                }
                int age;
                public List<string> desease;
                string medicine;
                public Granny(string Name, int Age, List<string> Desease, string Medicine)
                {
                    name = Name;
                    age = Age;
                    desease = Desease;
                    medicine = Medicine;
                }
                public override string ToString()
                {
                    return name;
                }
            }
            struct Hospital
            {
                string name;
                List<string> deseases;
                List<Granny> Patients;
                int capacity;
                public Hospital(string Name, List<string> Deseases, int Capacity)
                {
                    name = Name;
                    deseases = Deseases;
                    Patients = new List<Granny>(Capacity);
                    capacity = Capacity;
                }
                public bool TryAddPatient(Granny patient)
                {
                    if (Patients.Count < capacity)
                    {
                        if (patient.desease.Count != 0)
                        {
                            int numberGrannyDeseases = 0;
                            foreach (string desease in deseases)
                            {
                                foreach (string grannyDesease in patient.desease)
                                {
                                    if (grannyDesease == desease)
                                    {
                                        numberGrannyDeseases++;
                                    }
                                }
                            }
                            double part = (double)numberGrannyDeseases / (double)patient.desease.Count;
                            if (part > 0.5)
                            {
                                Patients.Add(patient);
                                return true;
                            }
                            else return false;
                        }
                        else
                        {
                            Patients.Add(patient);
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                public void Statis()
                {
                    Console.WriteLine(name);
                    foreach (string D in deseases)
                    {
                        Console.WriteLine(D);
                    }
                    Console.WriteLine("Пациентов в больнице " + Patients.Count);
                    Console.WriteLine(100 * (Convert.ToDouble(Patients.Count) / Convert.ToDouble(capacity)) + "%");
                }
            }
            static void distribute(Granny granny, Stack<Hospital> hospitals)
            {
                bool flag = false;
                foreach (Hospital H in hospitals)
                {
                    flag = H.TryAddPatient(granny);
                    if (flag)
                    {
                        Console.WriteLine("Бабушка " + granny + " попала в больницу");
                        return;
                    }
                }
                Console.WriteLine("Бабушка " + granny + " осталась плакать(((");
            }
            static void Main(string[] args)
            {
                {
                    Console.WriteLine("1.1");
                    int[] bavaria = new int[] { 1, 2, 4, 5, 6, 7, 8, 5, 0 };
                    int[] scandiv = new int[] { 3, 4, 5, 6, 7, 8, 0, 5, 1 };
                    int quantitybav = 0; int quantityscand = 0;
                    for (int i = 0; i < scandiv.Length; i++)
                    {
                        if (bavaria[i] == 5)
                        {
                            quantitybav++;
                        }
                        if (scandiv[i] == 5)
                        {
                            quantityscand++;
                        }
                    }
                    if (quantitybav == quantityscand)
                    {
                        Console.WriteLine("Drinks All Round!FreeBeeers on Bjorn!");
                    }
                    else
                    {
                        Console.WriteLine("Ой,Бьорг-пончик!Ни для кого пива!");
                    }

                    //1.2
                    Console.WriteLine("1.2");
                    List<string> pictures = new List<string>()

            {
                @"folder\1.jpg",
                @"folder\1-копия.jpg",
                @"folder\2.jpg",
                @"folder\2-копия.jpg",
                @"folder\3.jpg",
                @"folder\3-копия.jpg",
                @"folder\4.jpg",
                @"folder\4-копия.jpg",
                @"folder\5.jpg",
                @"folder\5-копия.jpg",
                @"folder\6.jpg",
                @"folder\6-копия.jpg",
                @"folder\7.png",
                @"folder\7-копия.jpg",
                @"folder\8.jpg",
                @"folder\8-копия.jpg",
                @"folder\9.jpg",
                @"folder\9-копия.jpg",
                @"folder\10.jpg",
                @"folder\10-копия.jpg",
                @"folder\11.jpg",
                @"folder\11-копия.jpg",
                @"folder\12.jpg",
                @"folder\12-копия.jpg",
                @"folder\13.jpg",
                @"folder\13-копия.jpg",
                @"folder\14.jpg",
                @"folder\14-копия.jpg",
                @"folder\15.jpg",
                @"folder\15-копия.jpg",
                @"folder\16.jpg",
                @"folder\16-копия.jpg",
                @"folder\17.jpg",
                @"folder\17-копия.jpg",
                @"folder\18.jpg",
                @"folder\18-копия.jpg",
                @"folder\19.jpg",
                @"folder\19-копия.jpg",
                @"folder\20.jpg",
                @"folder\20-копия.jpg",
                @"folder\21.jpg",
                @"folder\21-копия.jpg",
                @"folder\22.jpg",
                @"folder\22-копия.jpg",
                @"folder\23.jpg",
                @"folder\23-копия.jpg",
                @"folder\24.jpg",
                @"folder\24-копия.jpg",
                @"folder\25.jpg",
                @"folder\25-копия.jpg",
                @"folder\26.jpg",
                @"folder\26-копия.jpg",
                @"folder\27.jpg",
                @"folder\27-копия.jpg",
                @"folder\28.jpg",
                @"folder\28-копия.jpg",
                @"folder\29.jpg",
                @"folder\29-копия.jpg",
                @"folder\30.jpg",
                @"folder\30-копия.jpg",
                @"folder\31.jpg",
                @"folder\31-копия.jpg",
                @"folder\32.jpg",
                @"folder\32-копия.jpg"
            };
                    Console.WriteLine("\nНе перемешанный:\n" + String.Join("\n", pictures));
                    Random rnd = new Random();
                    for (int i = 0; i < pictures.Count; i++)
                    {
                        int odd = rnd.Next(pictures.Count);
                        Swap(pictures, i, odd, pictures[i], pictures[odd]);
                    }
                    Console.WriteLine("\nПеремешанный:\n" + String.Join("\n", pictures));
                    //1.3
                    Console.WriteLine("1.3");
                    Dictionary<int, Student> students = new Dictionary<int, Student>(10);
                    using (StreamReader reader = new StreamReader("input.txt"))
                    {
                        string strFromFile; 
                        while ((strFromFile = reader.ReadLine()) != null)
                        { 
                            string[] studentData = strFromFile.Split();
                            //создадим объект который добавим в словарь по id
                            Student student = new Student();
                            student.lastName = studentData[0]; 
                            student.name = studentData[1];
                            student.birth = Convert.ToInt32(studentData[2]); 
                            student.subject = studentData[3]; 
                            student.scores = Convert.ToInt32(studentData[4]); // баллы
                                                                              //Все элементарно!
                            students.Add(idStudent, student);
                            idStudent++;
                        }
                    }
                    Console.WriteLine("Введите одну из возможных команд: новый студент, удалить, сортировать, выход");
                    bool flag = true;
                    while (flag)
                    {

                        Console.Write("Введите команду: ");
                        string instruction = Console.ReadLine().ToLower();
                        switch (instruction)
                        {
                            case "новый студент":
                                NewStudent(students);
                                break;
                            case "удалить":
                                Delete(students);
                                break;
                            case "сортировать":
                                Sort(students);
                                break;
                            case "выход":
                                flag = false;
                                break;
                            default:
                                break;
                        }
                    }

                    //1.4
                    Console.WriteLine("1.4");
                    Stack<Table> tables = new Stack<Table>(10);
                    Queue<Employeer> employeers = new Queue<Employeer>(10);
                    tables.Push(new Table(1, "Красный"));
                    tables.Push(new Table(2, "Синий"));
                    tables.Push(new Table(3, "Зелёный"));
                    Employeer E1 = new Employeer("имя1", "сотрудник", 0, false);
                    Employeer E2 = new Employeer("имя2", "сотрудник", 1, true);
                    E1.AddFriend(E2);
                    E2.AddFriend(E1);
                    AddQueue(E1, employeers);
                    AddQueue(E2, employeers);
                    AddQueue(new Employeer("имя3", "сотрудник", 0, false), employeers);
                    AddQueue(new Employeer("имя4", "сотрудник", 7, true), employeers);
                    AddQueue(new Employeer("имя5", "сотрудник", 2, true), employeers);
                    AddQueue(new Employeer("имя6", "сотрудник", 1, true), employeers);
                    AddQueue(new Employeer("имя7", "сотрудник", 0, false), employeers);
                    foreach (Employeer E in employeers)
                    {
                        Console.WriteLine(E);
                    }
                    while (employeers.Count > 0)
                    {
                        Sit(employeers.Dequeue(), tables);
                    }

                    //1.5
                    Console.WriteLine("1.5");
                    Stack<Hospital> hospitals = new Stack<Hospital>(3);
                    List<string> desease1 = new List<string>(2);
                    desease1.Add("ОРВИ");
                    desease1.Add("Диабет");
                    hospitals.Push(new Hospital("Больница 1", desease1, 1));
                    List<string> desease2 = new List<string>(1);
                    desease2.Add("Гонорея");
                    hospitals.Push(new Hospital("Больница 2", desease2, 5));
                    List<string> desease3 = new List<string>(2);
                    desease3.Add("Шизофрения");
                    desease3.Add("Деменция");
                    hospitals.Push(new Hospital("Больница 3", desease3, 10));
                    List<Granny> grannies = new List<Granny>(4);
                    Console.WriteLine("Введите бабуль");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine("введите имя");
                        string newName = Console.ReadLine();
                        Console.WriteLine("введите возраст");
                        int newAge = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("введите количество заболеваний");
                        int numberDesease = Convert.ToInt32(Console.ReadLine());
                        List<string> deseases = new List<string>(numberDesease);
                        for (int j = 0; j < numberDesease; j++)
                        {
                            Console.WriteLine("введите название болезни");
                            deseases.Add(Console.ReadLine());
                        }
                        Console.WriteLine("введите лекарство");
                        grannies.Add(new Granny(newName, newAge, deseases, Console.ReadLine()));
                    }
                    foreach (Granny G in grannies)
                    {
                        distribute(G, hospitals);
                    }
                    foreach (Granny G in grannies)
                    {
                        Console.WriteLine(G);
                    }
                    foreach (Hospital H in hospitals)
                    {
                        H.Statis();
                    }
                }



            }

        }
    }
}


    



    

