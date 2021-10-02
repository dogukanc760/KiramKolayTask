using Core.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ClinicAdded = "Clinic Added";
        public static string ClinicUpdated = "Clinic Updated";
        public static string ClinicDeleted = "Clinic Deleted";

        public static string EquipmentAdded = "Equipment Added";
        public static string EquipmentUpdated = "Equipment Updated";
        public static string EquipmentDeleted = "Equipment Deleted";

        public static string UserNotFound = "User has not found!!";

        public static string PasswordError = "Password Error!";
        public static string LoginSuccessfull = "Login Successfull";
        public static string UserAlreadyExist = "This User Has Already Exist!";
        public static string UserRegisterSuccess = "User Registered Successfull";
        public static string AddedLog = "Log Added";

        public static string Added = "Added to database.";
        public static string Deleted = "Deleted From Database";
        public static string Updated = "Updated on the database";
    }
}
