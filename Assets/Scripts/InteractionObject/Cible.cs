using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cible : InteractableObject
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            if (playerInteraction.IsPlayerPressingI && CollisionNPC.iterationCount == 2 && !isInteractionMenuOpen)
            {
                isInteractionMenuOpen = true;
                InteractioMenu.gameObject.SetActive(true);
                GameManager.Instance.StartTypeWriter("La cible encourage Le Bon....", InteractioMenu.GetComponentInChildren<TMP_Text>());
                
                StartCoroutine(WaitBeforeClosingInteractionMenu());

                UnlockDialog();
            }
        }
    }
}
