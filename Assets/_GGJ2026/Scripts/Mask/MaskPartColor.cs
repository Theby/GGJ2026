using UnityEngine;

namespace GGJ2026.Data
{
    [CreateAssetMenu(fileName = "MaskPartColor", menuName = "GGJ2026/Mask Part Color", order = 1)]
    public class MaskPartColor : ScriptableObject
    {
        [SerializeField] string colorName;
        [SerializeField] MaskColor maskColor;
        [SerializeField] Sprite colorImage;

        public string ColorName => colorName;
        public MaskColor MaskColor => maskColor;
        public Sprite ColorImage => colorImage;
    }
}