using System.Collections.Generic;
using System.Linq;
using GGJ2026.Data;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class MaskManager : MonoBehaviour
    {
        const string MaskPartsDataRoute = "Data/MaskParts";
        const string MaskPartColorsDataRoute = "Data/MaskPartColors";
        const string MaskPartMaterialsDataRoute = "Data/MaskPartMaterials";

        readonly Dictionary<MaskPartType, List<MaskPart>> maskTypeToParts = new();

        public List<MaskPartColor> MaskPartColors { get; private set; }
        public List<MaskPartMaterial> MaskPartMaterials { get; private set; }

        void Awake()
        {
            LoadAllMaskParts();
        }

        void LoadAllMaskParts()
        {
            var maskPartsData = Resources.LoadAll<MaskPart>(MaskPartsDataRoute);

            foreach (var maskPart in maskPartsData)
            {
                if (!maskTypeToParts.TryGetValue(maskPart.MaskPartType, out var list))
                {
                    list = new List<MaskPart>();
                    maskTypeToParts[maskPart.MaskPartType] = list;
                }
                list.Add(maskPart);
            }

            MaskPartColors = Resources.LoadAll<MaskPartColor>(MaskPartColorsDataRoute).ToList();
            MaskPartMaterials = Resources.LoadAll<MaskPartMaterial>(MaskPartMaterialsDataRoute).ToList();
        }

        public List<MaskPart> GetMaskParts(MaskPartType type, MaskColor maskColor, MaskMaterial maskMaterial)
        {
            if (!maskTypeToParts.TryGetValue(type, out var parts))
                return null;

            return parts
                .Where(p => p.MaskColor == maskColor && p.MaskMaterial == maskMaterial)
                .ToList();
        }

        public MaskPart GetMaskPart(string maskName, MaskPartType type, MaskColor maskColor, MaskMaterial maskMaterial)
        {
            return !maskTypeToParts.TryGetValue(type, out var parts)
                ? null
                : parts.Find(m => m.MaskName == maskName && m.MaskColor == maskColor && m.MaskMaterial == maskMaterial);
        }
    }
}