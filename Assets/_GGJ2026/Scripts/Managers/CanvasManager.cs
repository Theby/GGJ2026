using GGJ2026.Data;
using GGJ2026.UI;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] MaskUI maskUI;
        [SerializeField] MaskPartUISelector baseMaskPartUISelector;
        [SerializeField] MaskPartUISelector faceMaskPartUISelector;
        [SerializeField] MaskPartUISelector lowerMaskPartUISelector;
        [SerializeField] MaskPartUISelector higherMaskPartUISelector;
        [SerializeField] MaskPartUISelector topMaskPartUISelector;

        void Start()
        {
            var baseMaskParts = GameManager.Instance.MaskManager.GetMaskParts(MaskPartType.Base);
            var faceMaskParts = GameManager.Instance.MaskManager.GetMaskParts(MaskPartType.Face);
            var lowerMaskParts = GameManager.Instance.MaskManager.GetMaskParts(MaskPartType.Lower);
            var higherMaskParts = GameManager.Instance.MaskManager.GetMaskParts(MaskPartType.Higher);
            var topMaskParts = GameManager.Instance.MaskManager.GetMaskParts(MaskPartType.Top);

            baseMaskPartUISelector.SetData(baseMaskParts);
            baseMaskPartUISelector.OnPartSelected += OnPartSelected;

            faceMaskPartUISelector.SetData(faceMaskParts);
            faceMaskPartUISelector.OnPartSelected += OnPartSelected;

            lowerMaskPartUISelector.SetData(lowerMaskParts);
            lowerMaskPartUISelector.OnPartSelected += OnPartSelected;

            higherMaskPartUISelector.SetData(higherMaskParts);
            higherMaskPartUISelector.OnPartSelected += OnPartSelected;

            topMaskPartUISelector.SetData(topMaskParts);
            topMaskPartUISelector.OnPartSelected += OnPartSelected;
        }

        void OnPartSelected(MaskPart maskPart)
        {
            maskUI.SetMaskPart(maskPart);
        }
    }
}