using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    public TMP_Text Text;

    float textSpeed;
    public float textSpeedMin;
    public float textSpeedMax;

    private string CurrentText;

    CanvasGroup Group;

    public bool completedText;

    // Start is called before the first frame update
    void Start()
    {
        Group = GetComponent<CanvasGroup>();
        Group.alpha = 0;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            textSpeed = textSpeedMax;
        }
        else
        {           
            textSpeed = textSpeedMin;
        }
    }

    public void Show(string text)
    {
         Group.alpha = 1;
         CurrentText = text;
         StartCoroutine(DisplayText());
    }

    public void Close()
    {
        StopAllCoroutines();
        Group.alpha = 0;
    }

    private IEnumerator DisplayText()
    {
        completedText = false;
        Text.text = "";

        foreach(char c in CurrentText.ToCharArray())
        {
            Text.text += c;

            yield return new WaitForSecondsRealtime(textSpeed);
        }

        completedText = true;
        yield return null;
    }
}
