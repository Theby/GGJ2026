using System.Collections;
using TMPro;
using UnityEngine;

public class DialogBubbleUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialog;
    [SerializeField] float typingSpeed;
    [SerializeField] float waitTimeAtEnd;

    string displayText;
    Coroutine coroutine;

    // MMF_Player with a MMF_TMPTextReveal

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        gameObject.SetActive(true);

        displayText = text;
        dialog.text = displayText;
        dialog.maxVisibleCharacters = 0;

        if(coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(TypeWriterEffect());
    }

    IEnumerator TypeWriterEffect()
    {
        int textCount = displayText.Length;

        for (int i = 1; i <= textCount; i++)
        {
            dialog.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(waitTimeAtEnd);

        coroutine = null;
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        if(coroutine != null)
            StopCoroutine(coroutine);

        coroutine = null;

        gameObject.SetActive(false);
    }
}
