using AutoMapper.QueryableExtensions;
using System;
using System.Linq;

namespace EF6CodeFirstDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var student = new Student() { StudentName = "Bill" };

                ctx.Students.Add(student);
                ctx.SaveChanges();
                Console.WriteLine(ctx.Students.Count().ToString());
                var _lst = ctx.Students.ProjectTo<StudentDto>(AutomapperConfig.mapper.ConfigurationProvider).ToList();
                Console.WriteLine(_lst.ToString());
            }
            Console.WriteLine("Demo completed.");
            Console.ReadLine();
        }
    }
}