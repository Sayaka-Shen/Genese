using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChevalBon : InteractableObject
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            VisualCueI.gameObject.SetActive(true);
            if (playerInteraction.IsPlayerPressingI && CollisionNPC.iterationCount == 1 && !isInteractionMenuOpen)
            {
                isInteractionMenuOpen = true;
                InteractioMenu.gameObject.SetActive(true);
                GameManager.Instance.StartTypeWriter("L'Ecuyer caresse le cheval...", InteractioMenu.GetComponentInChildren<TMP_Text>());
                AudioManager.Instance.PlaySFX("Horse");
                StartCoroutine(WaitBeforeClosingInteractionMenu());

                UnlockDialog();
            }
        }
    }
}
