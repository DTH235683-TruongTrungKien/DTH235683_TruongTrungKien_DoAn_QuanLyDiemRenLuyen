using Guna.UI2.WinForms;

namespace QLDRL.Helpers.States
{
    public static class MenuState
    {
        public static Guna2Button buttonState;
        public static void Active()
        {
            buttonState.Checked = true;
        }
        public static void Deactive()
        {
            buttonState.Checked = false;
        }
        public static void SetButtonState(Guna2Button button)
        {
            if(buttonState != null)
            {
                Deactive();
            }
            buttonState = button;
            Active();
        }
    }
}
