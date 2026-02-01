using System;
using GGJ2026.Data;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2026.UI
{
    public class MaskPartUI : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] Button button;

        public event Action<int> OnClick;

        int index;

        void Awake()
        {
            button.onClick.AddListener(OnClickHandler);
        }

        public void SetData(int index, MaskPart maskPart)
        {
            this.index = index;
            image.sprite = maskPart?.PartImage;
            gameObject.SetActive(image.sprite != null);
        }

        public void SetData(int index, MaskPartColor maskPartColor)
        {
            this.index = index;
            image.sprite = maskPartColor?.ColorImage;
            gameObject.SetActive(image.sprite != null);
        }

        public void SetData(int index, MaskPartMaterial maskPartMaterial)
        {
            this.index = index;
            image.sprite = maskPartMaterial?.MaterialImage;
            gameObject.SetActive(image.sprite != null);
        }

        void OnClickHandler()
        {
            OnClick?.Invoke(index);
        }
    }
}