using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveDuringDialogue : MonoBehaviour
{
    public DialogueController dialogueController;

    public GameObject[] activateDuringDialogue;

    public GameObject[] deactivateDuringDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueController.isTalking)
        {
            foreach(GameObject thing in activateDuringDialogue)
            {
                thing.SetActive(true);
            }

            foreach(GameObject thing in deactivateDuringDialogue)
            {
                thing.SetActive(false);
            }
        }
        else
        {
            foreach(GameObject thing in activateDuringDialogue)
            {
                thing.SetActive(false);
            }
            
            foreach(GameObject thing in deactivateDuringDialogue)
            {
                thing.SetActive(true);
            }
        }
    }
}
