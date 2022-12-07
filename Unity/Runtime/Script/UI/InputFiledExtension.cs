using UnityEngine.UI;

namespace Aya.Extension
{
    public static class InputFieldExtension
    {
        public static void Focus(this InputField inputField)
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }
}