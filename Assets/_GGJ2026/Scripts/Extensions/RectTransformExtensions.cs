using UnityEngine;

namespace GGJ2026.Extensions
{
    public static class RectTransformExtensions
    {
        public static void DestroyAllChildren(this RectTransform rectTransform)
        {
            for (int i = rectTransform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(rectTransform.GetChild(i).gameObject);
            }
        }

        public static void DestroyAllChildrenImmediate(this RectTransform rectTransform)
        {
            for (int i = rectTransform.childCount - 1; i >= 0; i--)
            {
                Object.DestroyImmediate(rectTransform.GetChild(i).gameObject);
            }
        }
    }
}
