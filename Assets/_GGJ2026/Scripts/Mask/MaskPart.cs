using UnityEngine;

namespace GGJ2026.Data
{
    [CreateAssetMenu(fileName = "MaskPart", menuName = "GGJ2026/Mask Part", order = 1)]
    public class MaskPart : ScriptableObject
    {
        [SerializeField] string maskName;
        [SerializeField] MaskPartType maskPartType;
        [SerializeField] Sprite partImage;
        [SerializeField] MaskColor maskColor;
        [SerializeField] MaskMaterial maskMaterial;

        public string MaskName => maskName;
        public MaskPartType MaskPartType => maskPartType;
        public Sprite PartImage => partImage;
        public MaskColor MaskColor => maskColor;
        public MaskMaterial MaskMaterial => maskMaterial;
    }
}