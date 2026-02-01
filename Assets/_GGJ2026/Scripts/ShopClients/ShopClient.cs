using UnityEngine;

namespace GGJ2026.Data
{
    [CreateAssetMenu(fileName = "ShopClient", menuName = "GGJ2026/Shop Client", order = 1)]
    public class ShopClient : ScriptableObject
    {
        [SerializeField] Sprite sprite;
        [SerializeField] string[] dialogTexts;
        [SerializeField] MaskPartAttribute requiredAttributes;
        [SerializeField] MaskColor requiredColor;
        [SerializeField] MaskMaterial requiredMaterial;

        public Sprite Sprite => sprite;
        public string[] DialogTexts => dialogTexts;
        public MaskPartAttribute RequiredAttribute => requiredAttributes;
        public MaskColor RequiredColor => requiredColor;
        public MaskMaterial RequiredMaterial => requiredMaterial;
    }
}
