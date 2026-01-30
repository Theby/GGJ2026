using System.Collections.Generic;
using GGJ2026.Data;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class MaskManager : MonoBehaviour
    {
        const string MaskPartsDataRoute = "Data/MaskParts";

        readonly Dictionary<MaskPartType, List<MaskPart>> maskTypeToParts = new();

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
        }

        public List<MaskPart> GetMaskParts(MaskPartType type)
        {
            return maskTypeToParts.GetValueOrDefault(type);
        }
    }
}