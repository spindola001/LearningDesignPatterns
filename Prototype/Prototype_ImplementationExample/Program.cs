namespace Prototype_ImplementationExample
{
    public class User : ICloneable
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        private string password { get; set; }

        public User(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public object Clone()
        {
            return new User(this.username, this.email, this.password);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ICloneable userOriginal = new User("spindola", "teste@teste.com", "teste123");
            ICloneable userClone = (ICloneable)userOriginal.Clone();

            Console.WriteLine("Hello, World!");
        }
    }
}
