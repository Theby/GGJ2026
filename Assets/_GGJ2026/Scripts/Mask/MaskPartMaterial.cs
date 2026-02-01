using UnityEngine;

namespace GGJ2026.Data
{
    [CreateAssetMenu(fileName = "MaskPartMaterial", menuName = "GGJ2026/Mask Part Material", order = 1)]
    public class MaskPartMaterial : ScriptableObject
    {
        [SerializeField] string materialName;
        [SerializeField] MaskMaterial maskMaterial;
        [SerializeField] Sprite materialImage;

        public string MaterialName => materialName;
        public MaskMaterial MaskMaterial => maskMaterial;
        public Sprite MaterialImage => materialImage;
    }
}