using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipDialogue : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public DialogueWindow dialogueWindow;

    public Button yourButton;

	void Start()
    {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}


	void TaskOnClick()
    {
        dialogueWindow.StopAllCoroutines();
        dialogueWindow.completedText = true;
        tutorialManager.skip = true;
	}
}
