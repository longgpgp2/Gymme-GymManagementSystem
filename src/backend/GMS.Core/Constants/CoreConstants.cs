using System;

namespace GMS.Core.Constants;


public class CoreConstants
{

    public static Guid AdminId = Guid.Parse("14448318-7efc-4b97-9b46-0d6ea6ab2056");
    public struct Schemas
    {
        public const string Common = "Common";
        public const string Security = "Security";
    }

    public struct UserRoles
    {
        public const string Manager = "manager";
        public const string PersonalTrainer = "personalTrainer";
        public const string Receptionist = "receptionist";
        public const string Admin = "admin";
        public const string Member = "member";



    }
}
