namespace ProgettoFinaleC_.Models.DB
{
    public class Database
    {
        public static List<User> listOfUsers = new List<User>()
        {
        new User() { UserName = "Jane_Doe", Email="Jane@gmail.com", Password = "Janepass"},
        new User() { UserName = "Ciro", Email="ciro@gmail.com", Password = "ciropass"},
        new User() { UserName = "Maria", Email="MAria@gmail.com", Password = "MAriapass"},
        };
        public static void AddUser(User user)
        {
            listOfUsers.Add(user);
        }
        public static string Login(string email, string passworld)
        {
            var utente = listOfUsers.SingleOrDefault(x => x.Email == email && x.Password == passworld);
            if (utente != null)
            {
                return "1234";
            }
            return "0";
        }
        //public static List<Phone> GetList()
        //{
        //    return listPhone;
        //}
    }
}
