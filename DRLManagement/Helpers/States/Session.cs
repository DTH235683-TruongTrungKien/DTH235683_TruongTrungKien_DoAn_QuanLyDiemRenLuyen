using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Models;

public class Session
{
    private CurrentUserDTO _currentUser;
    public CurrentUserDTO? CurrentUser => _currentUser;
    public bool IsAuthenticated => _currentUser != null;

    public event Action<CurrentUserDTO>? OnUserChanged;

    public void SetCurrentUser(CurrentUserDTO? currentUserDTO)
    {
        if (currentUserDTO != null)
        {
            _currentUser = currentUserDTO;
            OnUserChanged?.Invoke(currentUserDTO);
        }  
    }
    public bool CheckRole(string role)
    {
        if (_currentUser != null && _currentUser.RoleNames.Contains(role)) return true;
        return false;
    }
    public bool CheckRole(List<string> roles)
    {
        foreach (var r in roles)
        {
            if (_currentUser != null && _currentUser.RoleNames.Contains(r))
            {
                return true;
            }
        }
        return false;
    }
}