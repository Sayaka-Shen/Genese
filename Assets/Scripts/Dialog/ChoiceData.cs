using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ChoiceData
{
    public string Id;
    public string label;

    public ChoiceData(string id, string label)
    {
        Id = id;
        this.label = label;
    }
}
