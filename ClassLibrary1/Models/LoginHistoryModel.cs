using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HumanResources.Data
{
    class LoginHistoryModel
    {
        private LoginHistory _loginHistory;

        public LoginHistoryModel()
        {
            _loginHistory = new LoginHistory();
            SetDefaultValues();
        }

        public LoginHistoryModel(LoginHistory model)
        {
            _loginHistory = model;
        }

        [Required]
        public int Id
        {
            get
            {
                return _loginHistory.Id;
            }
        }

        [Required]
        [StringLength(50)]
        public string Username
        {
            get
            {
                return _loginHistory.Username;
            }
            set
            {
                _loginHistory.Username = value;
            }
        }

        [Required]
        public DateTime LoginAttemptTime
        {
            get
            {
                return _loginHistory.LoginAttemptTime;
            }
            set
            {
                _loginHistory.LoginAttemptTime = value;
            }
        }

        [Required]
        public bool Successful
        {
            get
            {
                return _loginHistory.Successful;
            }
            set
            {
                _loginHistory.Successful = value;
            }
        }

        public LoginHistory GetDataModel()
        {
            return _loginHistory;
        }

        public void SetDefaultValues()
        {
            _loginHistory.LoginAttemptTime = DateTime.Now;
        }

    }
}
