using System;
using GGJ2026.Data;
using GGJ2026.UI;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] MaskUI maskUI;
        [SerializeField] MaskPartUISelectorPopup maskPartUISelectorPopup;
        [SerializeField] MaskPartTypeSelectorButton[] selectorButtons;
        [SerializeField] MaskPartTypeSelectorButton colorButton;
        [SerializeField] MaskPartTypeSelectorButton materialButton;
        [SerializeField] SellButton sellButton;
        [SerializeField] CharacterUI characterUI;
        [SerializeField] ScoreUI scoreUI;
        [SerializeField] GameOverUI gameOverUI;

        public event Action<CompleteMask> OnSell;

        MaskPartType? lastSelectedMarkType = null;

        void Start()
        {
            foreach (var selectorButton in selectorButtons)
            {
                selectorButton.OnClicked += OnSelectorButtonClicked;
            }

            colorButton.OnClickedColor += OnSelectorColorButtonClicked;
            maskPartUISelectorPopup.OnColorSelected += OnColorSelected;

            materialButton.OnClickedMaterial += OnSelectorMaterialButtonClicked;
            maskPartUISelectorPopup.OnMaterialSelected += OnMaterialSelected;

            maskPartUISelectorPopup.OnPartSelected += OnPartSelected;

            sellButton.OnSell += OnSellHandler;
            sellButton.gameObject.SetActive(false);

            gameOverUI.gameObject.SetActive(false);
        }

        public void SetCharacter(ShopClient character)
        {
            characterUI.SetCharacter(character);
        }

        public void SetScore(int score)
        {
            scoreUI.AddScore(score);
        }

        void OnSelectorButtonClicked(MaskPartType type)
        {
            if (lastSelectedMarkType == type)
            {
                lastSelectedMarkType = null;
                return;
            }

            lastSelectedMarkType = type;
            var maskParts = GameManager.Instance.GetMaskParts(type);

            maskPartUISelectorPopup.Show();
            maskPartUISelectorPopup.SetMaskPart(maskUI.CompleteMask, maskParts);
        }

        void OnSelectorColorButtonClicked()
        {
            maskPartUISelectorPopup.Show();
            maskPartUISelectorPopup.SetColors(maskUI.CompleteMask, GameManager.Instance.MaskManager.MaskPartColors);
        }

        void OnSelectorMaterialButtonClicked()
        {
            maskPartUISelectorPopup.Show();
            maskPartUISelectorPopup.SetMaterials(maskUI.CompleteMask, GameManager.Instance.MaskManager.MaskPartMaterials);
        }

        void OnPartSelected(MaskPart maskPart)
        {
            maskUI.SetMaskPart(maskPart);
            if (maskUI.IsComplete)
            {
                sellButton.gameObject.SetActive(true);
            }
        }

        void OnColorSelected(MaskColor maskColor)
        {
            maskUI.UpdateWithColor(maskColor);
        }

        void OnMaterialSelected(MaskMaterial maskMaterial)
        {
            maskUI.UpdateWithMaterial(maskMaterial);
        }

        void OnSellHandler()
        {
            if (!maskUI.IsComplete)
                return;

            var completeMask = maskUI.CompleteMask;

            sellButton.gameObject.SetActive(false);
            characterUI.Clear();
            maskPartUISelectorPopup.Clear();
            maskUI.Clear();

            OnSell?.Invoke(completeMask);

        }

        public void ShowGameOver()
        {
            gameOverUI.gameObject.SetActive(true);
            gameOverUI.SetText(scoreUI.CurrentScore.ToString());
        }
    }
}