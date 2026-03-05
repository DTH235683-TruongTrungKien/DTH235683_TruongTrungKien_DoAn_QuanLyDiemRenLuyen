using QLDRL.DTOs.UserDTOs;

namespace QLDRL.Helpers
{
    public class Session
    {
        public UserDTO? CurrentUser { get; set; }
        public bool IsAuthenticated { get {  return CurrentUser != null; } }
    }
}
