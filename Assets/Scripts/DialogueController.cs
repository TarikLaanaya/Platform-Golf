using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public string DialogueText;
    public DialogueWindow Dialogue;

    public bool startTalking;
    public bool isTalking;
    public bool continueTalking;

    [TextArea(3,10)]
    public string[] sentences;

    void Update()
    {
        if (startTalking && !isTalking || continueTalking)
        {
            continueTalking = false;
            Dialogue.Show(DialogueText);
            isTalking = true;
        }
        
        if (!startTalking)
        {
            Dialogue.Close();
            isTalking = false;
        }
    }
}
