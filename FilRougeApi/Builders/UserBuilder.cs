using FilRougeCore.Models;

namespace FilRougeApi.Builders
{
    public class UserBuilder
    {
        private string? firstName;
        private string? lastName;
        private string? phoneNumber;
        private string? address;
        private string? email;
        private string? passWord;
        private bool isAdmin;

        public UserBuilder FirstName(string firstname)
        {
            this.firstName= firstname;
            return this;
        }
        public UserBuilder LastName(string lastname)
        {
            this.lastName= lastname;
            return this;
        }
        public UserBuilder PhoneNumber(string phonenumber)
        {
            this.phoneNumber = phonenumber;
            return this;
        }
        public UserBuilder Address(string address)
        {
            this.address = address;
            return this;
        }
        public UserBuilder Email(string email)
        {
            this.email = email;
            return this;
        }
        public UserBuilder Password(string password)
        {
            this.passWord= password;
            return this;
        }
        public UserBuilder IsAdmin(bool isadmin)
        {
            this.isAdmin= isadmin;
            return this;
        }

        public User Build()
        {
            User user = new User();
            if (firstName != null) user.FirstName= firstName;
            if (lastName!= null) user.LastName= lastName;
            if (phoneNumber != null) user.PhoneNumber= phoneNumber;
            if (address!= null) user.Address = address;
            if (email!= null) user.Email = email;
            if (passWord != null) user.PassWord = passWord;
            return user;
        }


    }
}
