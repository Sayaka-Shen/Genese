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

    [Header("UI Interaction")]
    [SerializeField] private Canvas interactionMenu;
    public bool isInteractionMenuOpen;
    public Canvas InteractioMenu
    {
        get { return interactionMenu; }
    }

    private bool isUnlocked = false;
    public bool IsUnlocked { get { return isUnlocked; } }


    [Header("VisualCue")]
    [SerializeField] private GameObject visualCueI;
    public GameObject VisualCueI
    {
        get { return visualCueI; }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            playerInteraction.ResetInteractionStateE();
            playerInteraction.ResetInteractionStateI();

            visualCueI.gameObject.SetActive(false);
        }
    }

    public void UnlockDialog()
    {
        isUnlocked = true;
        collisionNPC.SetNextDialog(nextDialog, nextIdSentence);
    }

    public IEnumerator WaitBeforeClosingInteractionMenu()
    {
        yield return new WaitForSeconds(3f);
        interactionMenu.gameObject.SetActive(false);
    }
}
