using System;

namespace VenusBiller.Reports
{
    public static class SalesTypeExtension
    {
        public static string EnumToString(this SalesType salesType)
        {
            switch (salesType)
            {
                case SalesType.B2B:
                    return "B 2 B";
                case SalesType.B2C:
                    return "B 2 C";
                case SalesType.Both:
                    return "Both";
                default:
                    throw new ArgumentException("Invalid enum type");
            }
        }

        public static SalesType StringToEnum(string enumMemberName)
        {
            switch (enumMemberName)
            {
                case "B 2 C":
                    return SalesType.B2C;
                case "B 2 B":
                    return SalesType.B2B;
                case "Both":
                    return SalesType.Both;
                default:
                    throw new ArgumentException("Invalid enum member name  : " + enumMemberName);
            }
        }
    }
}