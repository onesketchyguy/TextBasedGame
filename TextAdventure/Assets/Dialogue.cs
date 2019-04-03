using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string DisplayedOption;

    [Space]

    public string Intro;

    public List<Dialogue> Dialogues;

    internal int CurrentIndex;
    internal string CurrentSentance;

    public void StartedDialogue()
    {
        CurrentIndex = 0;

        CurrentSentance = Dialogues[CurrentIndex].DisplayedOption;
    }

    public void UpdateDialogue(int moveDirection)
    {
        CurrentIndex += moveDirection;

        CurrentSentance = Dialogues[CurrentIndex].DisplayedOption;
    }
}
