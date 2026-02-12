namespace PortalOS.Domain.Constants
{
    public static class DatabaseConstants
    {
        public static class Tables
        {
            public const string Users = "users";
        }

        public static class Columns
        {
            public const string Id = "id";
            public const string Email = "email";
            public const string PasswordHash = "password_hash";
            public const string Role = "role";
            public const string CreatedAt = "created_at";
            public const string UpdatedAt = "updated_at";
        }
    }
}
