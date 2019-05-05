using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice01
{

    partial class Program
    {
       
        static void Main(string[] args)
        {
            Practice01 ctx = new Practice01();
            ctx.Database.EnsureCreated();
            //List<Person> people = new List<Person>
            //{
            //    new Person{FistName="مهدی", LastName="فرامرزی" , Address="تهران"},
            //    new Person{FistName="وحید", LastName="گلپایگانی" , Address="کرمان"},
            //    new Person{FistName="حسین", LastName="موذن" , Address="گیلان"},
            //    new Person{FistName="مسعود", LastName="موذن" , Address="کرمانشاه"}
            //};
            //ctx.People.AddRange(people);
            var person = ctx.People.FirstOrDefault();
            person.FistName = "مهدی";
            person.LastName = "faramarzi";
            //UpdateProperties(new List<string> { "LastName" }, person); 

            //ctx.SaveChanges();
            ctx.People.RemoveAll();
            Console.WriteLine("Done!!!");
        }
        public static void UpdateProperties<T>(List<string> properties, T entity) where T : class
        {
            Practice01 ctx = new Practice01();

            foreach (var item in properties)
            {
                if (ctx.Entry(entity).Properties.Any(c=> c.Metadata.Name == item))
                    ctx.Entry(entity).Properties.Single(c => c.Metadata.Name == item).IsModified = true;
            }

            ctx.SaveChanges();
        }
      

    }
}
