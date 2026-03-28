namespace QLDRL.Enums
{
    public enum ValidateUserResult
    {
        Success,
        EmptyEmail,
        InvalidEmail,
        ExistedEmail,
        EmptyPassword,
        ShortPassword,
        EmptyName,
        InvalidBirthday,
        InvalidPhoneNumber,
        NoRoleSelected
    }
}
