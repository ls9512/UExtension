using UnityEngine;
using UnityEngine.UI;

namespace Aya.Extension
{
    public static class ButtonExtension
    {
        public static Button SetNormalColor(this Button button, Color color)
        {
            var cb = button.colors;
            cb.normalColor = color;
            button.colors = cb;
            return button;
        }

        public static Button SetHighLightedColor(this Button button, Color color)
        {
            var cb = button.colors;
            cb.highlightedColor = color;
            button.colors = cb;
            return button;
        }

        public static Button SetPressedColor(this Button button, Color color)
        {
            var cb = button.colors;
            cb.pressedColor = color;
            button.colors = cb;
            return button;
        }

        public static Button SetDisabledColor(this Button button, Color color)
        {
            var cb = button.colors;
            cb.disabledColor = color;
            button.colors = cb;
            return button;
        }
    }
}