namespace _03.ESGI.DesignPattern.Builder
{
    public class User
    {
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; }
        public int BirthYear { get; }
        public int BirthMonth { get; }
        public int BirthDay { get; }

        public User(string firstname, string lastname, string email, int birthYear, int birthMonth, int birthDay)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            BirthYear = birthYear;
            BirthMonth = birthMonth;
            BirthDay = birthDay;
        }
    }

    public class UserBuilder
    {
        private string _firstname;
        private string _lastname;
        private string _email;
        private int _birthYear;
        private int _birthMonth;
        private int _birthDay;

        public UserBuilder WithFirstname(string firstname)
        {
            _firstname = firstname;

            return this;
        }

        public UserBuilder WithLastname(string lastname)
        {
            _lastname = lastname;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public UserBuilder WithBirthYear(int birthYear)
        {
            _birthYear = birthYear;
            return this;
        }

        public UserBuilder WithBirthMonth(int birthMonth)
        {
            _birthMonth = birthMonth;
            return this;
        }

        public UserBuilder WithBirthDay(int birthDay)
        {
            _birthDay = birthDay;
            return this;
        }

        public User Build()
        {
            return new User(_firstname, _lastname, _email, _birthYear, _birthMonth, _birthDay);
        }
    }
}
