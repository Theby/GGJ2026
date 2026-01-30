using System;
using GGJ2026.Data;
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

        void Awake()
        {
             basePart.gameObject.SetActive(false);
             facePart.gameObject.SetActive(false);
             lowerPart.gameObject.SetActive(false);
             higherPart.gameObject.SetActive(false);
             topPart.gameObject.SetActive(false);
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
        }
    }
}
