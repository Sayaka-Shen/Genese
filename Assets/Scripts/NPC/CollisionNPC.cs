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


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            if(playerInteraction.IsPlayerPressingE)
            {
                canvas.gameObject.SetActive(true);
                DialogueController.Instance.InitDialog(currentDialog.GetData(idSentence), currentDialog);
            }
        }
    }

    public void SetNextDialog(DialogDatabase newDialog, string newIdSentence)
    {
        currentDialog = newDialog;
        idSentence = newIdSentence;
    }
}
