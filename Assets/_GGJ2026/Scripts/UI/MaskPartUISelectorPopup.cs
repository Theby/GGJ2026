using System;
using System.Collections.Generic;
using GGJ2026.Data;
using GGJ2026.UI;
using UnityEngine;
using UnityEngine.UI;

public class MaskPartUISelectorPopup : MonoBehaviour
{
    [SerializeField] MaskUI maskUI;
    [SerializeField] MaskPartUISelector maskPartUISelector;
    [SerializeField] Button closeButton;

    public event Action<MaskPart> OnPartSelected;
    public event Action<MaskColor> OnColorSelected;
    public event Action<MaskMaterial> OnMaterialSelected;

    void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    void OnEnable()
    {
        maskPartUISelector.OnPartSelected += OnPartSelectedHandler;
        maskPartUISelector.OnColorSelected += OnColorSelectedHandler;
        maskPartUISelector.OnMaterialSelected += OnMaterialSelectedHandler;
    }

    void OnDisable()
    {
        maskPartUISelector.OnPartSelected -= OnPartSelectedHandler;
        maskPartUISelector.OnColorSelected -= OnColorSelectedHandler;
        maskPartUISelector.OnMaterialSelected -= OnMaterialSelectedHandler;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetMaskPart(CompleteMask completeMask, List<MaskPart> maskParts)
    {
        maskUI.SetCompleteMask(completeMask);
        maskPartUISelector.SetData(maskParts);
    }

    public void SetColors(CompleteMask completeMask, List<MaskPartColor> maskPartColors)
    {
        maskUI.SetCompleteMask(completeMask);
        maskPartUISelector.SetData(maskPartColors);
    }

    public void SetMaterials(CompleteMask completeMask, List<MaskPartMaterial> maskPartMaterials)
    {
        maskUI.SetCompleteMask(completeMask);
        maskPartUISelector.SetData(maskPartMaterials);
    }

    void OnPartSelectedHandler(MaskPart part)
    {
        maskUI.SetMaskPart(part);
        OnPartSelected?.Invoke(part);
    }

    void OnColorSelectedHandler(MaskPartColor part)
    {
        maskUI.UpdateWithColor(part.MaskColor);
        OnColorSelected?.Invoke(part.MaskColor);
    }

    void OnMaterialSelectedHandler(MaskPartMaterial part)
    {
        maskUI.UpdateWithMaterial(part.MaskMaterial);
        OnMaterialSelected?.Invoke(part.MaskMaterial);
    }

    public void Clear()
    {
        maskUI.Clear();
    }
}
