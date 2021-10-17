using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace homework22 {
    class Program {
        static async Task Main(string[] args) { 
            #region Adding
            //bool added = await AddStudentAsync(new Student { Name = "ABOBA", Age = 100 });

            //Console.WriteLine($"User is {(!added ? "not" : "")} added");
            #endregion

            #region Updating
            //bool changed = await UpdateStudentAsync(3, new Student { Age = 16, Name = "Amed" });

            //if(changed)
            //    Console.WriteLine($"User with ID: {3} has been changed");
            #endregion

            #region Deleting
            //bool deleted = await DeleteStudentAsync(4);
            //Console.WriteLine($"User with ID: {4} has been deleted");
            #endregion


            #region Reading
            foreach(var student in await ReadStudentsAsync()) 
               Console.WriteLine($"{student.ID}.{student.Name} - {student.Age} лет");
            #endregion
            
            Console.ReadLine();
        }

        static async Task<bool> AddStudentAsync(Student student) {
            using EFCtestContext DB = new EFCtestContext();
            DB.Students.Add(student);

            var changes = await DB.SaveChangesAsync();

            return changes > 0;
        }

        static async Task<List<Student>> ReadStudentsAsync() {
            using EFCtestContext DB = new EFCtestContext();
            List<Student> result = new List<Student>();

            await foreach(var student in DB.Students) 
                result.Add(student);
            
            return result;
        } 

        static async Task<bool> UpdateStudentAsync(int ID, Student student) {
            using EFCtestContext DB = new EFCtestContext();

            Student studentToChange = await DB.Students.FindAsync(ID);

            if(studentToChange == null)
                return false;

            studentToChange.Name = student.Name;
            studentToChange.Age = student.Age;

            var changes = await DB.SaveChangesAsync();

            return changes > 0;
        }

        static async Task<bool> DeleteStudentAsync(int ID) {
            using EFCtestContext DB = new EFCtestContext();

            Student studentToChange = await DB.Students.FindAsync(ID);

            if(studentToChange == null)
                return false;

            DB.Remove(studentToChange);

            var changes = await DB.SaveChangesAsync();

            return changes > 0;
        }
    }
}
