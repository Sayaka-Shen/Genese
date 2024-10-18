using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionNPC : MonoBehaviour
{
    [Header("Dialog Informations")]
    [SerializeField] private DialogDatabase currentDialog;
    [SerializeField] private string idSentence;
    [SerializeField] private Canvas canvas;

    private int indexDialogBon = 0;
    public int IndexDialogBon
    {
        get { return indexDialogBon; }
    }

    private int indexDialogBrute = 0;
    public int IndexDialogBrute
    {
        get { return indexDialogBrute; }
    }

    private int indexDialogDonJuan = 0;
    public int IndexDialogDonJuan
    {
        get { return indexDialogDonJuan; }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            if(playerInteraction.IsPlayerPressingE)
            {
                canvas.gameObject.SetActive(true);
                DialogueController.Instance.InitDialog(currentDialog.GetData(idSentence), currentDialog);
                playerInteraction.ResetInteractionState();
            }

            if (playerInteraction.CompareTag("LeBon"))
            {
                indexDialogBon++;
            }

            if (playerInteraction.CompareTag("LaBrute"))
            {
                indexDialogBrute++;
            }

            if (playerInteraction.CompareTag("LeDonJuan"))
            {
                indexDialogDonJuan++;
            }
        }
    }

    public void SetNextDialog(DialogDatabase newDialog, string newIdSentence)
    {
        currentDialog = newDialog;
        idSentence = newIdSentence;
    }
}
