using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace Asm2
{
        internal class Management
        {
            private List<Users> _listUsers;

            public Management(List<Users> listUser) => _listUsers = listUser;

            public void MainManage()
            {
                Console.Clear();
                Console.WriteLine(
                    "Univesity Manage System\n"+
                    "1.Manage Students\n" +
                    "2.Manage Lecturers\n" +
                    "3.Exit\n") ;

                var choice = int.Parse(Console.ReadLine());
                do
                {
                    var cases = new Dictionary<Func<int, bool>, Action>
                {
                    { x => x == 1, () => PersonManagement(UserTpye.Student)   },
                    { x => x == 2, () => PersonManagement(UserTpye.Lecturer)  },
                    { x => x == 3, () => Environment.Exit(0)                        },
                };
                    cases.FirstOrDefault(c => c.Key(choice)).Value();
                } while (choice > 0 || choice < 4);
                Console.ReadLine();
            }

            private void PersonManagement(UserTpye position)
            {
                OperationDisplay(position);

                // Opetation determination process
                int choice;
                do
                {
                    OperationDisplay(position);
                    choice = int.Parse(Console.ReadLine());

                    var cases = new Dictionary<Func<int, bool>, Action>
                {
                    { x => x == 1, () => Add(position)      },
                    { x => x == 2, () => ViewAll(position)  },
                    { x => x == 3, () => Search(position)   },
                    { x => x == 4, () => Delete(position)   },
                    { x => x == 5, () => Update(position)   },
                    { x => x == 6, () => MainManage()       },
                };
                    cases.FirstOrDefault(c => c.Key(choice)).Value();
                } while (choice > 0 || choice < 7);
            }

            private void Add(UserTpye position)
            {
                Console.Clear();
                Console.WriteLine("Please enter the following fields!");
                var UsersToAdd = inputFields(position);
                if (Check.InputIsNull(UsersToAdd[0])
                    || Check.InputIsNull(UsersToAdd[3]))
                    return;

                var creationCases = new Dictionary<Func<UserTpye, bool>, Action>
            {
                { x => x == UserTpye.Student,
                    () => _listUsers.Add(new Student(UsersToAdd)) },
                { x => x == UserTpye.Lecturer,
                    () => _listUsers.Add(new Lecturer(UsersToAdd)) },
            };
                creationCases.FirstOrDefault(c => c.Key(position)).Value();

                Console.WriteLine("Add Successfully!");
                Console.ReadKey();
            }

            private void ViewAll(UserTpye position)
            {
                Console.Clear();
                if (Check.ListIsNull(_listUsers, position)) return;
                else
                {
                    var resultList = _listUsers.Where(a => a.UP == position).ToList();
                    Console.WriteLine(
                        $"LIST OF {position}s:\n");
                    foreach (var p in resultList) Console.WriteLine(p.DiplayUsers());
                    Console.ReadLine();
                }
            }

            private void Search(UserTpye position)
            {
                Console.Clear();
                if (Check.ListIsNull(_listUsers, position)) return;
                else
                {
                    Console.Write($"Enter the {position}'s name: ");
                    var UsersToSearch = Console.ReadLine();

                    var resultList = _listUsers.Where(p => p.GetName() == UsersToSearch
                                                            || p.UP == position)
                                                .ToArray();
                    Console.WriteLine(
                        "=======================\n" +
                        "Results:");
                    if (resultList is null)
                    {
                        Console.WriteLine("No results!");
                        Console.ReadLine();
                        return;
                    }
                    else foreach (var p in resultList) Console.WriteLine(p.DiplayUsers());
                    Console.ReadLine();
                }
            }

            private void Delete(UserTpye position)
            {
                Console.Clear();
                if (Check.ListIsNull(_listUsers, position)) return;
                else
                {
                    Console.Write($"Enter the {position}'s ID to Delete: ");
                    var foo = Console.ReadLine();
                    var UserToDelete = _listUsers.SingleOrDefault(p => p.GetID() == foo
                                                                    || p.UP == position);

                    if (Check.KeyIsNull(UserToDelete, foo)) return;
                    else
                    {
                    _listUsers.Remove(UserToDelete);
                        Console.WriteLine(
                                $"{UserToDelete}\n\n" +
                                "Delete succesfully!");
                        Console.ReadLine();
                    }
                }
            }

            private void Update(UserTpye position)
            {
                Console.Clear();
                if (Check.ListIsNull(_listUsers, position)) return;
                else
                {
                    Console.Write($"Enter the {position}'s ID to Update: ");
                    var foo = Console.ReadLine();
                    var personToUpdate = _listUsers.FirstOrDefault(p => p.GetID() == foo
                                                                         || p.UP == position);
                    Console.WriteLine(
                        $"\n{personToUpdate.DiplayUsers()}\n");

                    var listOfUpdate = inputFields(position);

                    if (Check.KeyIsNull(personToUpdate, foo)) return;
                    // TODO: Please test this - PersonManagement(position);

                    // Basically switch cases
                    var updateCases = new Dictionary<Func<int, bool>, Action>
                {
                    { c => c == 0, () => personToUpdate.SetID(listOfUpdate[0]) },
                    { c => c == 1, () => personToUpdate.SetName(listOfUpdate[1]) },
                    { c => c == 2, () => personToUpdate.SetDateOfBirth(DateTime.Parse(listOfUpdate[2], CultureInfo.CreateSpecificCulture("de-DE"))) },
                    { c => c == 3, () => personToUpdate.SetEmail(listOfUpdate[3]) },
                    { c => c == 4, () => personToUpdate.SetAddress(listOfUpdate[4]) },
                    { c => c == 5, () => personToUpdate.SetType(listOfUpdate[5]) },
                };
                    for (int i = 0; i < listOfUpdate.Length; i++)
                        if (!string.IsNullOrWhiteSpace(listOfUpdate[i]))
                            updateCases.First(c => c.Key(i)).Value();

                    Console.WriteLine("\nUpdate successfully!");
                }
            }

            private void OperationDisplay(UserTpye position)
            {
                Console.Clear();
                Console.WriteLine(
                    "1.Add new {0}\n" +
                    "2.View all {0}\n" +
                    "3.Search {0}\n" +
                    "4.Delete {0}\n" +
                    "5.Update {0}\n" +
                    "6.Back to main menu\n", position);
            }

            private string[] inputFields(UserTpye position)
            {
                var Type = position == UserTpye.Lecturer ? "DEPARTMENT" : "CLASS";
                string[] fieldNames =
                {
                "ID: ",
                "NAME: ",
                "DATE OF BIRTH: ",
                "EMAIL: ",
                "ADDRESS: ",
                $"{Type}: "
            };

                var fieldToOperate = new List<string>();
                for (int i = 0; i < 6; i++)
                {
                    Console.Write(fieldNames[i]);
                    fieldToOperate.Add(Console.ReadLine());
                }

                return fieldToOperate.ToArray();
            }
        }
    }
