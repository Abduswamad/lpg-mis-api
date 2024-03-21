namespace Gas.Domain.Enums
{
    public static class Codes
    {
        public static readonly int Success = 200;
        public static readonly int BadRequest = 100;
        public static readonly int Exception = 500;
        public static readonly int FirstLogin = 211;
        public static readonly int locked = 301;

    }

    public static class CodesMessage
    {
        public static string Success = "Successfull";
        public static string DefaultPassword = "@1234";
    }

    public static class CodesBatchType
    {
        public static int IN = 1;
        public static int OUT = 2;
    }

}
