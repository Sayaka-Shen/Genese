using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Dialog Unlock Information")]
    [SerializeField] private DialogDatabase nextDialog;
    [SerializeField] private string nextIdSentence;

    [Header("NPC")]
    [SerializeField] private CollisionNPC collisionNPC;

    public CollisionNPC CollisionNPC
    {
        get { return collisionNPC; }
    }

    private bool isUnlocked = false;
    public bool IsUnlocked { get { return isUnlocked; } }

    public void UnlockDialog()
    {
        isUnlocked = true;
        collisionNPC.SetNextDialog(nextDialog, nextIdSentence);
    }
}
