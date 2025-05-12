using Domain.Exceptions;

namespace Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; private set; }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public User(Guid id, string name, string email)
        {
            Id = id;
            ValidateEntity(name, email);
            Name = name;
            Email = email;
        }

        public void AddUser(string name, string email)
        {
            ValidateEntity(name, email);
            Name = name;
            Email = email;
        }

        private static void ValidateEntity(string name, string email)
        {
            ValidateName(name);
            ValidateEmail(email);
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                throw new InvalidNameException("Nome inválido");
            }
        }

        private static void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains('@'))
            {
                throw new InvalidNameException("Email inválido");
            }
        }
    }
}