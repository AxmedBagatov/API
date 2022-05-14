namespace API
{
    public class Class
    {
        static void Main(string[] args)
        {
            // добавление данных
            using (webportalContext db = new webportalContext())
            {
                // создаем два объекта User
                Person person1 = new Person { Name = "krat0", Surname = "krat0", Lastname = "krats0", Email = "krat0@mail.ru", Password = "Proto0" };


                // добавляем их в бд
                db.People.AddRange(person1);
                db.SaveChanges();
            }
            // получение данных
            using (webportalContext db = new webportalContext())
            {
                // получаем объекты из бд и выводим на консоль
                var persons = db.People.ToList();
                Console.WriteLine("Users list:");
                foreach (Person u in persons)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname} - {u.Lastname} - {u.Email} - {u.Password}");
                }
            }

        }
    }
}
