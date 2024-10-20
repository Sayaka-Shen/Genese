using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Meule : InteractableObject
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            VisualCueI.gameObject.SetActive(true);
            if (playerInteraction.IsPlayerPressingI && playerInteraction.GetComponent<Inventory>().IsInventoryContaining("Epee") && CollisionNPC.iterationCount == 1 && !isInteractionMenuOpen)
            {
                isInteractionMenuOpen = true;
                InteractioMenu.gameObject.SetActive(true);
                GameManager.Instance.StartTypeWriter("L'Ecuyer polit l'épée...", InteractioMenu.GetComponentInChildren<TMP_Text>());
                AudioManager.Instance.PlaySFX("Meule");

                StartCoroutine(WaitBeforeClosingInteractionMenu());

                UnlockDialog();
            }
        }
    }
}
