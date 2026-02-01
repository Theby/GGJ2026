using System;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaskPartTypeSelectorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] MaskPartType maskPartType;
    [SerializeField] bool isPart = true;
    [SerializeField] bool isColor = true;
    [SerializeField] bool isMaterial = true;
    [SerializeField] Image baseImage;
    [SerializeField] Image outlineImage;
    [SerializeField] MMF_Player hoverEnterFeedback;
    [SerializeField] MMF_Player hoverExitFeedback;

    public event Action<MaskPartType> OnClicked;
    public event Action OnClickedColor;
    public event Action OnClickedMaterial;

    RectTransform rt;
    Button selectionButton;

    void Awake()
    {
        selectionButton = GetComponent<Button>();
        selectionButton.onClick.AddListener(OnClickedHandler);
    }

    void OnClickedHandler()
    {
        if (isPart)
        {
            OnClicked?.Invoke(maskPartType);
        }
        else if (isColor)
        {
            OnClickedColor?.Invoke();
        }
        else if (isMaterial)
        {
            OnClickedMaterial?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverExitFeedback.StopFeedbacks();
        hoverEnterFeedback.PlayFeedbacks();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverEnterFeedback.StopFeedbacks();
        hoverExitFeedback.PlayFeedbacks();
    }
}
