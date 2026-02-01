using System;
using System.Collections.Generic;
using GGJ2026.Data;
using GGJ2026.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2026.UI
{
    public class MaskPartUISelector : MonoBehaviour
    {
        [SerializeField] RectTransform partsRoot;
        [SerializeField] ScrollRect scrollRect;
        [SerializeField] MaskPartUI maskPartUIPrefab;

        public event Action<MaskPart> OnPartSelected;
        public event Action<MaskPartColor> OnColorSelected;
        public event Action<MaskPartMaterial> OnMaterialSelected;

        List<MaskPart> loadedMaskParts;
        List<MaskPartColor> loadedMaskPartColors;
        List<MaskPartMaterial> loadedMaskPartMaterials;

        public void SetData(List<MaskPart> maskParts)
        {
            loadedMaskParts = maskParts;
            loadedMaskPartColors = null;
            loadedMaskPartMaterials = null;

            partsRoot.DestroyAllChildren();

            for (var i = 0; i < loadedMaskParts.Count; i++)
            {
                var maskPart = loadedMaskParts[i];
                var maskPartUI = Instantiate(maskPartUIPrefab, partsRoot, false);
                maskPartUI.SetData(i, maskPart);
                maskPartUI.OnClick += OnClickHandler;
            }
        }

        public void SetData(List<MaskPartColor> maskPartColors)
        {
            loadedMaskParts = null;
            loadedMaskPartColors = maskPartColors;
            loadedMaskPartMaterials = null;

            partsRoot.DestroyAllChildren();

            for (var i = 0; i < loadedMaskPartColors.Count; i++)
            {
                var maskPartColor = loadedMaskPartColors[i];
                var maskPartUI = Instantiate(maskPartUIPrefab, partsRoot, false);
                maskPartUI.SetData(i, maskPartColor);
                maskPartUI.OnClick += OnClickHandler;
            }
        }

        public void SetData(List<MaskPartMaterial> maskPartMaterials)
        {
            loadedMaskParts = null;
            loadedMaskPartColors = null;
            loadedMaskPartMaterials = maskPartMaterials;

            partsRoot.DestroyAllChildren();

            for (var i = 0; i < loadedMaskPartMaterials.Count; i++)
            {
                var maskPartMaterial = loadedMaskPartMaterials[i];
                var maskPartUI = Instantiate(maskPartUIPrefab, partsRoot, false);
                maskPartUI.SetData(i, maskPartMaterial);
                maskPartUI.OnClick += OnClickHandler;
            }
        }

        void OnClickHandler(int index)
        {
            if (loadedMaskParts != null)
            {
                var maskPart = loadedMaskParts[index];
                OnPartSelected?.Invoke(maskPart);
                return;
            }

            if (loadedMaskPartColors != null)
            {
                var maskPartColor = loadedMaskPartColors[index];
                OnColorSelected?.Invoke(maskPartColor);
                return;
            }

            if (loadedMaskPartMaterials != null)
            {
                var maskPartMaterial = loadedMaskPartMaterials[index];
                OnMaterialSelected?.Invoke(maskPartMaterial);
                return;
            }
        }
    }
}