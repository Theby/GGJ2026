using GGJ2026.Data;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] DialogBubbleUI dialogBubbleUI;

    ShopClient shopClient;
    Button showDialogButton;

    int textIndex = 0;

    void Awake()
    {
        showDialogButton = GetComponent<Button>();
        showDialogButton.onClick.AddListener(OnShowDialogHandler);
    }

    public void SetCharacter(ShopClient character)
    {
        shopClient = character;
        ShowDialogHandler();
    }

    void OnShowDialogHandler()
    {
        ShowDialogHandler();
    }

    void ShowDialogHandler()
    {
        var currentText = shopClient.DialogTexts[textIndex];
        dialogBubbleUI.SetText(currentText);

        textIndex =  (textIndex + 1) % shopClient.DialogTexts.Length;
    }

    public void Clear()
    {
        textIndex = 0;
    }
}
