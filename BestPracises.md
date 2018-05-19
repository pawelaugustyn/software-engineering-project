# Best practices in C#
### Rules

Make sure that:
1. "No error or warnings" on the right side of the page is displayed (In some cases it is not possible, but almost always trust ReSharper)
2. There is NO unnecessary:
    - empty lines - code should be clean so it is necessary to separate blocks of code by blnak lines, but do not overuse it! e.g. before return statement have to be blank line
    - whitespaces at the end of line with code ( Ctr+K then Ctr+D and other formatting)
3. Remove unused usings (Alt, Enter - when cursor is at the using lines)
4. Every class should be in separate file named the same as class
4. Names convention is respected
    - **PascalCase** required in all names
    - Meaningfull names
    >class - MyUser
    >method - GetUser(string firstName);
    >interface - IMyUser
    >properties - MyProperty
    > private class field - _myField- 
    > variable - **var** myVariable = Get...

4. Remember about enum 
```.cs
enum UserRoles
{
    Guest,
    Developer,
    ScrumMaster,
    Admin
}
```
5. Remember about const, readonly and static
    - e.g. public static readonly nazwa = "Text variable that sholud not be wtirren direct in code but at the beginning of class"
6. Remember about organization of class
```.cs
using ...;

namespace ScrumIt...
{
    public class MyUser: SuperUser, IUser
    {
        private static readony string _imie = "Me";
        public Property {get;}
        ...
        MyUser()
        {
            ...
        }
        public void MyMethod(string something)
        {
            ...
        }
        
        private int MyAge()
        {
            var age=...;
            
            return age;
        }
    }
}
```
More informations https://msdn.microsoft.com/pl-pl/library/dobre-i-zle-praktyki-w-c-sharp--czesc-1.aspx
Do not hetisate to ask questions!
 
