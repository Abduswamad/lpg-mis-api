using Microsoft.AspNetCore.Routing.Matching;

namespace Gas.Common
{
    public static class UserData
    {
        public static int? DepoId { get; set; } = 0;
        public static int? StoreId { get; set; } = 0;
        public static int? UserId { get; set; } = 0;
        public static int? DriverId { get; set; } = 0;
        public static int? SuperDealerId { get; set; } = 0;
    }
}
