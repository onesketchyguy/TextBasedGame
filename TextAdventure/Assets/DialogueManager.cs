using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text IntroText;
    public Text SentenceText;

    public Dialogue CurrentDialogue;

    private void Start()
    {
        CurrentDialogue.StartedDialogue();

        Debug.Log(CurrentDialogue.CurrentSentance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpdateDialogue(-1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UpdateDialogue(0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpdateDialogue(1);
        }

        IntroText.text = CurrentDialogue.Intro;

        ShowOptions();
    }

    void UpdateDialogue(int moveDirection)
    {
        if (moveDirection == 0)
        {
            Dialogue newDialogue = CurrentDialogue.Dialogues[CurrentDialogue.CurrentIndex];

            CurrentDialogue = newDialogue;

            CurrentDialogue.StartedDialogue();
        }
        else
        {
            int current = CurrentDialogue.CurrentIndex + moveDirection;

            if (current < CurrentDialogue.Dialogues.Count && current >= 0)
                CurrentDialogue.UpdateDialogue(moveDirection);
        }

        Debug.Log(CurrentDialogue.CurrentSentance);
    }

    void ShowOptions()
    {
        string[] options = new string[CurrentDialogue.Dialogues.Count];

        for (int i = 0; i < options.Length; i++)
        {
            options[i] = CurrentDialogue.Dialogues[i].DisplayedOption;
        }

        string optionsText = "";

        for (int i = 0; i < options.Length; i++)
        {
            string item = options[i];

            string currentSelected = (i == CurrentDialogue.CurrentIndex)? "-><color=#f9e900>" : "--<color=#f90000>";

            optionsText += $"{currentSelected}{item}  </color>\n";
        }

        SentenceText.text = optionsText;
    }
}
