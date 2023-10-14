namespace FitnessWebApp.Common
{
    public static class EntityValidationConstants
    {
        public static class GymUser
        {
            public const int MinWeight = 20;
            public const int MaxWeight = 635;
            public const int MinHeight = 100;
            public const int MaxHeight = 251;
            public const int MinAge = 1;
            public const int MaxAge = 120;
        }
        public static class Food
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 171;
            public const double MinMacrosValue = 0;
            public const double MaxMacrosValue = 100;

        }
        public static class PartOfDay 
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 100;
        }
        public static class Activities
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
        }

    }
}
