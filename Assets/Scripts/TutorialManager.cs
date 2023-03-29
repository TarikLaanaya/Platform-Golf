using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public DialogueController dialogueController;
    public DialogueWindow dialogueWindow;
    public CheckPointScript checkPointScript;
    public AddForceToBall addForceToBall;

    int sentence = 0;

    [Header("Imagine These Values +1")]
    public int[] pauseAfterThisSentence; 

    public bool pauseDialogue;

    bool sentenceIsUnpaused;

    public int lastDialogueBox;

    public bool skip;

    public string nextLevelsName;

    // Start is called before the first frame update
    void Start()
    {
        addForceToBall.canMove = false;
        dialogueController.DialogueText = dialogueController.sentences[sentence];
        dialogueController.startTalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:

                    if (dialogueWindow.completedText && !pauseDialogue)
                    {
                        sentenceIsUnpaused = false;
                        sentence += 1;
                        dialogueWindow.completedText = false;
                        dialogueController.DialogueText = dialogueController.sentences[sentence];
                        dialogueController.startTalking = true;
                        dialogueController.continueTalking = true;
                        Time.timeScale = 0.5f;
                    }

                    if ((System.Array.IndexOf (pauseAfterThisSentence, sentence) != -1) && !dialogueWindow.completedText && !pauseDialogue && !sentenceIsUnpaused) 
                    {
                        pauseDialogue = true;
                        dialogueController.startTalking = false;
                        dialogueController.continueTalking = false;
                        addForceToBall.canMove = true;
                        Time.timeScale = 1f;
                    }

                    break;
            }
        }

        if (checkPointScript.checkPointNumber != checkPointScript.previousNumber && !dialogueController.isTalking)
        {
            checkPointScript.previousNumber = checkPointScript.checkPointNumber;
            sentenceIsUnpaused = true;
            pauseDialogue = false;
            dialogueController.DialogueText = dialogueController.sentences[sentence];
            dialogueController.startTalking = true;
            addForceToBall.canMove = false;
            Time.timeScale = 0.5f;
        }

        if (sentence == lastDialogueBox)
        {
            SceneManager.LoadScene(nextLevelsName, LoadSceneMode.Single);
        }

        if (skip)
        {
            if (dialogueWindow.completedText && !pauseDialogue)
            {
                sentenceIsUnpaused = false;
                sentence += 1;
                dialogueWindow.completedText = false;
                dialogueController.DialogueText = dialogueController.sentences[sentence];
                dialogueController.startTalking = true;
                dialogueController.continueTalking = true;
                Time.timeScale = 0.5f;
            }

            if ((System.Array.IndexOf (pauseAfterThisSentence, sentence) != -1) && !dialogueWindow.completedText && !pauseDialogue && !sentenceIsUnpaused) 
            {
                pauseDialogue = true;
                dialogueController.startTalking = false;
                dialogueController.continueTalking = false;
                addForceToBall.canMove = true;
                Time.timeScale = 1f;
            }

            skip = false;
        }
    }
}
