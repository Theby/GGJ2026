using System;
using System.Collections.Generic;

namespace GGJ2026.Data
{
    public class CompleteMask
    {
        readonly Dictionary<MaskPartType, MaskPart> parts = new();

        public bool IsComplete => parts.Count == Enum.GetValues(typeof(MaskPartType)).Length;

        public void AddMaskPart(MaskPart part) => parts[part.MaskPartType] = part;
        public MaskPart GetPart(MaskPartType type) => parts.GetValueOrDefault(type);
        public void RemovePart(MaskPartType type) => parts.Remove(type);
    }
}