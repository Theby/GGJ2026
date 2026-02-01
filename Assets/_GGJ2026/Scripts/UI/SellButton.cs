using System;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    Button button;

    public event Action OnSell;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickedHandler);
    }

    void OnClickedHandler()
    {
        OnSell?.Invoke();
    }
}
