using DigitalLibrary.Data;
using System;
using DigitalLibrary.Entities;
using System.Collections.Generic;
using System.Linq;
namespace DigitalLibrary.Repository
{
	public class UserRepository
    {

        //Получить пользователя по Id
            public static void GetUser(int Id)
            {
                using (var db = new AppContexts())
                {
                    var userName = from user in db.Users
                                   where user.Id == Id
                                   select user;

                    foreach (var user in userName)
                    {
                        Console.WriteLine($"Пользователь {user.Name} имеет идентификатор {Id}");
                        Console.WriteLine();
                    }
                }
            }

            //Получить всех пользователей
            public static List<User> GetAllUsers()
            {
                using (var db = new AppContexts())
                {
                    var result = db.Users.ToList();
                    return result;
                }
            }

            //Создание пользователя
            public static string CreateUser(User user)
            {
                string result = "Уже существует";

            using (var db = new AppContexts())
                {
                    //проверяем существует ли данный пользователь
                    bool checkIsExist = db.Users.Any(u => u.Name == user.Name && u.Email == user.Email);
                    if (!checkIsExist)
                    {
                        User newUser = new User { Name = user.Name, Email = user.Email };
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        result = "Пользователь " + user.Name + " добавлен!";
                    }
                }
                return result;
            }

            //Удаление пользователя
            public static string DeleteUser(User user)
            {
                string result = "Такого пользователя не существует";

                using (var db = new AppContexts())
                {
                    bool checkIsExist = db.Users.Any(u => u.Name == user.Name && u.Email == user.Email);
                    if (checkIsExist)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        result = "Пользователь " + user.Name + " удален!";
                    }
                }
                return result;
            }
            //обновление имени пользователя
            public static string UpdateUser(User oldUser, string newName)
            {
                string result = "Такого пользователя не существует";

                using (var db = new AppContexts())
                {
                    User user = db.Users.FirstOrDefault(user => user.Id == oldUser.Id);
                    user.Name = newName;
                    db.SaveChanges();
                    result = "Имя пользователя " + user.Name + " обновлено!";
                }
                Console.WriteLine($"Пользователь {oldUser.Name} был изменен на {newName}");
                Console.WriteLine();

                return result;
            }
        
    }
}

