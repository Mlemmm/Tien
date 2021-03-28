using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Asm2
{
    class Check
    {
            private Check() { }

            public static bool ListIsNull(List<Users> listToCheck, UserTpye Up)
            {
                var foo = !listToCheck.Where(a => a.UP == Up).Any();
                if (foo)
                {
                    Console.WriteLine($"There are no {Up}s in the current list!\n" +
                                        "Please add more!");
                    Console.ReadLine();
                }
                return foo;
            }

            public static bool KeyIsNull(Users UserToCheck, string id)
            {
                var foo = UserToCheck is null;
                if (foo)
                {
                    Console.WriteLine($"This {id} is not in the list");
                    Console.ReadLine();
                }
                return foo;
            }

            public static bool InputIsNull(string field)
            {
                var foo = string.IsNullOrWhiteSpace(field);
                if (foo)
                {
                    Console.WriteLine($"This {field} is required!");
                    Console.ReadLine();
                }
                return foo;
            }

            public static bool IsDuplicate(IEnumerable<Users> listToCheck, string field)
            {
                var foo = listToCheck.Any();
                if (foo)
                {
                    Console.WriteLine($"This {field} is already existed");
                    Console.ReadLine();
                }
                return foo;
            }
        }
    }
