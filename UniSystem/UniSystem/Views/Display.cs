using System;
using UniSystem.Controllers;

namespace UniSystem.Views
{
    public class Display(
        UniversityController universityController, 
        FacultyController facultyController,
        MajorController majorController)
    {
        public async Task Operations()
        {
            #region Menu
            Console.WriteLine("Welcome to the university system");
            Console.WriteLine("Use the following commands to interact with the data base:");
            Console.WriteLine("1. Add university");
            Console.WriteLine("2. Add faculty");
            Console.WriteLine("3. Add major");
            Console.WriteLine("4. Show all universities");
            Console.WriteLine("5. Show faculties by university ID");
            Console.WriteLine("6. Show majors by faculty ID");
            Console.WriteLine("7. Show university ID by name");
            Console.WriteLine("8. Show faculty ID and name by name");
            Console.WriteLine("9. Show major ID and name by name");
            Console.WriteLine("10. Exit");
            #endregion

            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();                            

            while (input[0] == "Exit")
            {
                var command = input[0];

                switch (command)
                {
                    case "1":
                        var uniName = input[1];

                        await universityController.AddUniversity(uniName);

                        break;

                    case "2":
                        var facultyName = input[1];
                        int uniId = int.Parse(input[2]);

                        await facultyController.AddFaculty(facultyName, uniId);

                        break;

                    case "3":
                        var majorName = input[1];
                        int facultyId = int.Parse(input[2]);

                        await majorController.AddMajor(majorName, facultyId);

                        break;

                    case "4":
                        var universities = await universityController.GetAllUniversities();

                        foreach (var uni in universities)
                        {
                            Console.WriteLine($"{uni.UniName}");
                            Console.WriteLine("------------------");

                            foreach (var item in uni.FacultyNames)
                            {
                                Console.WriteLine($"{item}");
                            }
                        }

                        break;

                    case "5":
                        int uniIdForFaculties = int.Parse(input[1]);

                        var faculties = await facultyController.GetFacultiesByUniversityId(uniIdForFaculties);

                        foreach (var faculty in faculties)
                        {
                            Console.WriteLine($"{faculty.FacultyName} - {faculty.UniName}");
                        }

                        break;

                    case "6":
                        int facultyIdForMajors = int.Parse(input[1]);

                        var majors = await majorController.GetMajorsByFacultyId(facultyIdForMajors);

                        foreach (var major in majors)
                        {
                            Console.WriteLine($"{major.MajorName} - {major.FacultyName}");
                        }

                        break;

                    case "7":
                        var uniNameForId = input[1];

                        var uniIdResult = await universityController.GetUniversityIdByName(uniNameForId);

                        Console.WriteLine($"University ID: {uniIdResult}");
                        break;

                    case "8":
                        var facultyByName = input[1];

                        var facultyResults = await facultyController.GetFacultiesByName(facultyByName);

                        foreach (var faculty in facultyResults)
                        {
                            Console.WriteLine($"{faculty.FacultyName} - {faculty.UniName}");
                        }

                        break;

                    case "9":
                        var majorByName = input[1];

                        var majorResults = await majorController.GetMajorsByName(majorByName);

                        foreach (var major in majorResults)
                        {
                            Console.WriteLine($"{major.MajorName} - {major.FacultyName}");
                        }

                        break;
                }

                #region Menu
                Console.WriteLine("Welcome to the university system");
                Console.WriteLine("Use the following commands to interact with the data base:");
                Console.WriteLine("1. Add university");
                Console.WriteLine("2. Add faculty");
                Console.WriteLine("3. Add major");
                Console.WriteLine("4. Show all universities");
                Console.WriteLine("5. Show faculties by university ID");
                Console.WriteLine("6. Show majors by faculty ID");
                Console.WriteLine("7. Show university ID by name");
                Console.WriteLine("8. Show faculty ID and name by name");
                Console.WriteLine("9. Show major ID and name by name");
                Console.WriteLine("10. Exit");
                #endregion

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
        }
    }
}
