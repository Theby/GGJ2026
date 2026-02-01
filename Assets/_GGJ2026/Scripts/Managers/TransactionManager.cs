using System;
using GGJ2026.Data;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class TransactionManager : MonoBehaviour
    {
        [SerializeField] float perfectScore;

        [Header("Scoring Weights")]
        [SerializeField, Range(0, 1)] float attributeWeight = 0.5f;
        [SerializeField, Range(0, 1)] float colorWeight = 0.25f;
        [SerializeField, Range(0, 1)] float materialWeight = 0.25f;

        public ShopClient CurrentClient { get; set; }
        public CompleteMask CraftedMask  { get; set; }

        public float CalculateReward()
        {
            if (CurrentClient == null || CraftedMask == null)
                return 0.0f;

            float scoreFactor = 0.0f;
            int maskParts = 0;

            foreach (MaskPartType type in Enum.GetValues(typeof(MaskPartType)))
            {
                var part = CraftedMask.GetPart(type);
                if (part == null)
                    return 0.0f;

                maskParts++;
                scoreFactor += ScorePart(part);
            }

            scoreFactor /= maskParts;
            return perfectScore * scoreFactor;
        }

        float ScorePart(MaskPart part)
        {
            float score = 0.0f;

            if (part.MaskColor == CurrentClient.RequiredColor)
                score += colorWeight;

            if (part.MaskMaterial == CurrentClient.RequiredMaterial)
                score += materialWeight;

            score += CalculateAttributeScore(part.MaskAttribute) * attributeWeight;
            return score;
        }

        float CalculateAttributeScore(MaskPartAttribute partAttribute)
        {
            var required = CurrentClient.RequiredAttribute;
            if (required == MaskPartAttribute.None)
                return 1.0f;

            float requiredCount = 0.0f;
            float matchCount = 0.0f;

            foreach (MaskPartAttribute flag in Enum.GetValues(typeof(MaskPartAttribute)))
            {
                if (flag == MaskPartAttribute.None)
                    continue;

                if (!required.HasFlag(flag))
                    continue;

                requiredCount++;
                if (partAttribute.HasFlag(flag))
                    matchCount++;
            }

            return requiredCount > 0.0f ? matchCount / requiredCount : 1.0f;
        }
    }
}
