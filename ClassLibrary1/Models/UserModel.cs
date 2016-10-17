using HumanResources.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Linq;
using System;

namespace HumanResources.Data
{
    public class UserModel
    {
        private User _user;
        private const int MAX_LOGIN_COUNT = 3;
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int COOKIE_SALT_LENGTH = 12;

        public UserModel()
        {
            _user = new User();
            SetDefaultValues();
        }

        public UserModel(User user)
        {
            _user = user;
        }

        [Required]
        public int Id { 
            get
            {
                return _user.Id;
            }
        }

        [Required]
        [StringLength(50)]
        public string Username
        {
            get
            {
                return _user.Username;
            }
            set
            {
                _user.Username = value;
            }
        }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName
        {
            get
            {
                return _user.FirstName;
            }
            set
            {
                _user.FirstName = value;
            }
        }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName
        {
            get
            {
                return _user.LastName;
            }
            set
            {
                _user.LastName = value;
            }
        }

        [Required]
        [StringLength(200)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email
        {
            get
            {
                return _user.Email;
            }
            set
            {
                _user.Email = value;
            }
        }

        [Required]
        [PasswordPropertyText]
        [DisplayName("Password")]
        public string Pass
        {
            get
            {
                return _user.Pass;
            }
            set
            {
                _user.Pass = value;
            }
        }

        [Required]
        public bool TwoStepActive
        {
            get
            {
                return _user.TwoStepActive;
            }
            set
            {
                _user.TwoStepActive = value;
            }
        }

        [Required]
        public int NumLoginAttempts
        {
            get
            {
                return _user.NumLoginAttempts;
            }
        }

        [Required]
        public string Salt
        {
            get
            {
                return _user.Salt;
            }
        }

        public User GetDataModel()
        {
            return _user;
        }

        public void SetDefaultValues()
        {
            GenerateCookieSalt();
        }

        public string Name()
        {
            return _user.FirstName + " " + _user.LastName;
        }

        public void GenerateCookieSalt()
        {
            Random random = new Random();
            _user.Salt = new string(Enumerable.Repeat(CHARS, COOKIE_SALT_LENGTH)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool AuthenticateUserPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, _user.Pass);
        }

        public bool HasNotReachedLoginMax()
        {
            return NumLoginAttempts < MAX_LOGIN_COUNT;
        }

        public void IncrementLoginAttempts()
        {
            _user.NumLoginAttempts++;
        }

        public void ResetLoginAttempts()
        {
            _user.NumLoginAttempts = 0;
        }
    }
}