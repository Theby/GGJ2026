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

        private List<MaskPart> loadedMaskParts;

        public void SetData(List<MaskPart> maskParts)
        {
            loadedMaskParts = maskParts;

            partsRoot.DestroyAllChildren();

            for (var i = 0; i < loadedMaskParts.Count; i++)
            {
                var maskPart = loadedMaskParts[i];
                var maskPartUI = Instantiate(maskPartUIPrefab, partsRoot, false);
                maskPartUI.SetData(i, maskPart);
                maskPartUI.OnClick += OnClickHandler;
            }
        }

        void OnClickHandler(int index)
        {
            var maskPart = loadedMaskParts[index];
            OnPartSelected?.Invoke(maskPart);
        }
    }
}