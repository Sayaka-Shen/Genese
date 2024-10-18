using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CollisionNPC : MonoBehaviour
{
    [Header("Dialog Informations")]
    [SerializeField] private DialogDatabase currentDialog;
    [SerializeField] private string idSentence;
    [SerializeField] private Canvas canvas;

    public int iterationCount = 0;

    /// <summary>
    /// Merci Emile !!!!
    /// </summary>
    /// <param name="other">un truc là</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            if(playerInteraction.IsPlayerPressingE)
            {
                canvas.gameObject.SetActive(true);
                DialogueController.Instance.InitDialog(currentDialog.GetData(idSentence), currentDialog);
                playerInteraction.ResetInteractionStateE();

                iterationCount++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            playerInteraction.ResetInteractionStateE();
            playerInteraction.ResetInteractionStateI();
        }
    }

    private void Update()
    {
        Debug.Log(iterationCount);
    }

    public void SetNextDialog(DialogDatabase newDialog, string newIdSentence)
    {
        currentDialog = newDialog;
        idSentence = newIdSentence;
    }
}
