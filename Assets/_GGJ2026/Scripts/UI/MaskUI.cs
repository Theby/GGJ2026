using System;
using GGJ2026.Data;
using GGJ2026.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2026.UI
{
    public class MaskUI : MonoBehaviour
    {
        [SerializeField] Image basePart;
        [SerializeField] Image facePart;
        [SerializeField] Image lowerPart;
        [SerializeField] Image higherPart;
        [SerializeField] Image topPart;

        public CompleteMask CompleteMask { get; private set; }
        public bool IsComplete => CompleteMask.IsComplete;

        void Awake()
        {
            Clear();
        }

        public void SetCompleteMask(CompleteMask completeMask)
        {
            foreach (MaskPartType type in Enum.GetValues(typeof(MaskPartType)))
            {
                var maskPart = completeMask.GetPart(type);
                if (maskPart == null)
                    continue;

                SetMaskPart(maskPart);
            }
        }

        public void SetMaskPart(MaskPart maskPart)
        {
            Image partImage = maskPart.MaskPartType switch
            {
                MaskPartType.Base => basePart,
                MaskPartType.Face => facePart,
                MaskPartType.Lower => lowerPart,
                MaskPartType.Higher => higherPart,
                MaskPartType.Top => topPart,
                _ => throw new ArgumentOutOfRangeException()
            };

            partImage.sprite = maskPart.PartImage;
            partImage.gameObject.SetActive(true);

            CompleteMask.AddMaskPart(maskPart);
        }

        public void UpdateWithColor(MaskColor maskColor)
        {
            foreach (MaskPartType type in Enum.GetValues(typeof(MaskPartType)))
            {
                var maskPart = CompleteMask.GetPart(type);
                if (maskPart == null)
                    continue;

                var newMaskPart = GameManager.Instance.MaskManager.GetMaskPart(maskPart.MaskName, maskPart.MaskPartType,
                    maskColor, maskPart.MaskMaterial);
                SetMaskPart(newMaskPart);
            }
        }

        public void UpdateWithMaterial(MaskMaterial maskMaterial)
        {
            foreach (MaskPartType type in Enum.GetValues(typeof(MaskPartType)))
            {
                var maskPart = CompleteMask.GetPart(type);
                if (maskPart == null)
                    continue;

                var newMaskPart = GameManager.Instance.MaskManager.GetMaskPart(maskPart.MaskName, maskPart.MaskPartType,
                    maskPart.MaskColor, maskMaterial);
                SetMaskPart(newMaskPart);
            }
        }

        public void Clear()
        {
            CompleteMask = new CompleteMask();

            basePart.gameObject.SetActive(false);
            facePart.gameObject.SetActive(false);
            lowerPart.gameObject.SetActive(false);
            higherPart.gameObject.SetActive(false);
            topPart.gameObject.SetActive(false);
        }
    }
}
