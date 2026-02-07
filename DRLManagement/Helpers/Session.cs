using QLDRL.DTOs.UserDTOs;

namespace QLDRL.Helpers
{
    public static class Session
    {
        public static UserDTO? CurrentUser { get; set; }
        public static bool IsAuthenticated { get {  return CurrentUser != null; } }
    }
}
