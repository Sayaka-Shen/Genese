using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DialogData
{
    [Serializable]
    public struct ChoiceWrapper
    {
        public string IDChoice;
        public string IDDialog;
    }
    
    public string Id;
    public string speekerName;

    [TextArea]
    public string sentence;

    public List<ChoiceWrapper> choices;
    
    public DialogData(string id, string speekerName, string sentence, List<ChoiceWrapper> choices)
    {
        Id = id;
        this.speekerName = speekerName;
        this.sentence = sentence;
        this.choices = choices;
    }
}
