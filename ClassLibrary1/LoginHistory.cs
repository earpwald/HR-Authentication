//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HumanResources.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginHistory
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public System.DateTime LoginAttemptTime { get; set; }
        public bool Successful { get; set; }
    }
}
