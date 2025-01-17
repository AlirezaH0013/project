using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using workshap_my.model;
using workshap_my.serveses;
Student_reposestory repo = new Student_reposestory();

while (true)
{
    Console.Clear();
    Console.WriteLine("Student Manager");
    Console.WriteLine($"Total student:{repo.cont}");
    Console.WriteLine("______________________________");
    Console.WriteLine("1-Add");
    Console.WriteLine("2-Edit");
    Console.WriteLine("3-delete");
    Console.WriteLine("4-Find");
    Console.WriteLine("5-List ");
    Console.WriteLine("6-Exit");
    Console.Write("Select Item:");
    var Item= Console.ReadLine();
    switch (Item)
    {
            case "1":
            {
                Console.Clear();
                Console.WriteLine("Add student");
                Console.WriteLine("-----------------------");
                Console.Write("Id:");
                var id = Console.ReadLine();
                if (string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("Please enter the correct Id...");
                    Console.ReadKey();
                    continue;
                }
                if (repo.Findindex(id).HasValue)
                {
                    Console.WriteLine($"student with {id} already exists.");
                    Console.ReadKey();
                    continue;
                }
                if (Getinput(out var firstname, out var lastname, out var nationalid, out var age, out var country, out var city, out var phone))
                    continue;
                Console.WriteLine("student Add...");
                Console.ReadKey();
                repo.Add(id, firstname, lastname, nationalid, age, country, city, phone);
                break;
            }
            case "2":
            { 
                Console.Clear();
                Console.WriteLine("Edit Student...");
                Console.WriteLine("---------------------------");
                var student = Getstudent(repo, out var id);
                if (student == null)
                {
                    Console.WriteLine($"Student with Id {id} not found!");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine();
                Console.WriteLine("current student values:");
                Console.WriteLine();
                Console.WriteLine($"Firstname: {student.Firstname} | Lastname: {student.Lastname} | NationalId: {student.NationalId}");
                Console.WriteLine();
                Console.WriteLine($"Country: {student.Country} | City: {student.City} | Phone: {student.Phone} | Age: {student.Age}");
                if(Getinput(out var firstname,out var lastname,out var nationalid, out var age,out var country, out var city,out var phone))
                    continue ;
                if(repo.Editstudent(id, firstname, lastname, nationalid, age, country, city, phone))
                {
                    Console.WriteLine("student updated...");
                    Console.ReadKey();
                    continue ;
                }
                else
                {
                    Console.WriteLine("Cannot student updated...");

                }
                Console.ReadKey();

                break;
            }
        case "3":
            {
                Console.Clear();
                Console.WriteLine("delete student...");
                Console.WriteLine("---------------------------------");

                Console.WriteLine("Enter Id:");
                var id = Console.ReadLine();
                if (repo.Deletestudent(id))
                {
                    Console.WriteLine("Student Delete...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"student with id {id} not exists!");
                    Console.ReadKey();
                }
                break;

              
            }
            case "4":
            {
                Console.Clear();
                Console.WriteLine("Find student...");
                Console.WriteLine("----------------------------");
                var student = Getstudent(repo, out var id);
                if (student == null)
                {
                    Console.WriteLine($"Student with Id {id} not found!");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    Console.WriteLine($"Firstname: {student.Firstname} | Lastname: {student.Lastname} | NationalId: {student.NationalId}");
                    Console.WriteLine();
                    Console.WriteLine($"Country: {student.Country} | City: {student.City} | Phone: {student.Phone} | Age: {student.Age}");
                }
                Console.ReadKey();

            }
            break;
            case "5":
            Console.WriteLine("List student...");
            Console.WriteLine("-----------------------------");
            var all=repo.GetAll();
            for (int index = 0; index < all.Length; index++)
            {
                var student = all[index];   
                if (student != null)
                    Console.WriteLine($"{index + 1}-Firstname: {student.Firstname} | Lastname: {student.Lastname} | NationalId: {student.NationalId} | Country: {student.Country} | City: {student.City} | Phone: {student.Phone} | Age: {student.Age} ");
            }
            Console.WriteLine("press any kay to retern to the menu...");
            Console.ReadKey();
            
            break;
            case "6":
            return;
            default:
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine(" Select invalid Item...please press any kay to retern to the menu!");
            Console.ReadKey();
            Console.ForegroundColor= ConsoleColor.White;
            continue;
    }
}

bool Getinput(out string firstname,out string lastname,out string nationalid,out byte age,out string? country ,out string city,out string phone)
{
    country = string.Empty;
    city = string.Empty;
    phone = string.Empty;
    age = 0;
    Console.Write("Firstname:");
     firstname = Console.ReadLine();
    if (string.IsNullOrEmpty(firstname))
    {
        Console.Beep();
        Console.WriteLine("Please enter the correct firstname...");
        Console.ReadKey();
        lastname = null;
        nationalid = null;
        return true;
    }

    Console.Write("Lastname:");
     lastname = Console.ReadLine();
    if (string.IsNullOrEmpty(lastname))
    {
        Console.Beep();
        Console.WriteLine("Please enter the correct lastname...");
        Console.ReadKey();
        nationalid = null;
        return true;

    }

    Console.Write("NationalId:");
     nationalid = Console.ReadLine();

    if ( nationalid.Length != 10|| string.IsNullOrEmpty(nationalid))
    {
        Console.Beep();

        Console.WriteLine("Invalid national Id format!");
        Console.ReadKey();
       
        return true;
    }

    Console.Write("Age:");
    if (byte.TryParse(Console.ReadLine(), out byte parsage))
    {
        age = parsage;
    }
    else
    {
        Console.Beep();

        Console.WriteLine("Input age is not valid!");
        Console.ReadKey();
       
        return true;
    }

    Console.Write("Country:");
     country = Console.ReadLine();
    if(string.IsNullOrEmpty(country))
    {
        Console.Beep();

        Console.WriteLine("please Enter a country...");
        Console.ReadKey(); return true;
    }

    Console.Write("City:");
     city = Console.ReadLine();
    if (string.IsNullOrEmpty(city))
    {
        Console.Beep();
        Console.WriteLine("please Enter a city...");
        Console.ReadKey(); return true;
    }

    Console.Write("Phone:");
     phone = Console.ReadLine();
    if (phone.Length != 11 || string.IsNullOrEmpty(phone))
    {
        Console.Beep();

        Console.WriteLine("Invalid phone format!");
        Console.ReadKey();
        return true ;
    }
    return false;

}

Student? Getstudent(Student_reposestory student_Reposestory,out string id)
{
    Console.Write("Enter Student Id:");
     id = Console.ReadLine();
    var student = repo.GetStudent(id);
    return student;
}