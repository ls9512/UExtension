#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Extension
{
    public static class GenericMenuExtension
    {
        #region Add Item
        
        public static GenericMenu AddItem(this GenericMenu menu, string content, GenericMenu.MenuFunction func, bool disabled = false, bool on = false)
        {
            if (disabled)
            {
                menu.AddDisabledItem(new GUIContent(content), on);
            }
            else
            {
                menu.AddItem(new GUIContent(content), on, func);
            }

            return menu;
        }

        public static GenericMenu AddItem(this GenericMenu menu, string content, GenericMenu.MenuFunction2 func, object userData, bool disabled = false, bool on = false)
        {
            if (disabled)
            {
                menu.AddDisabledItem(new GUIContent(content), on);
            }
            else
            {
                menu.AddItem(new GUIContent(content), on, func, userData);
            }

            return menu;
        }

        public static GenericMenu AddItem(this GenericMenu menu, GUIContent content, GenericMenu.MenuFunction func, bool disabled = false, bool on = false)
        {
            if (disabled)
            {
                menu.AddDisabledItem(content, on);
            }
            else
            {
                menu.AddItem(content, on, func);
            }

            return menu;
        }

        public static GenericMenu AddItem(this GenericMenu menu, GUIContent content, GenericMenu.MenuFunction2 func, object userData, bool disabled = false, bool on = false)
        {
            if (disabled)
            {
                menu.AddDisabledItem(content, on);
            }
            else
            {
                menu.AddItem(content, on, func, userData);
            }

            return menu;
        } 

        #endregion
    }
}
#endif