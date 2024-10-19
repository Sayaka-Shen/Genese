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
            if (playerInteraction.IsPlayerPressingI && playerInteraction.GetComponent<Inventory>().IsInventoryContaining("Epee") && CollisionNPC.iterationCount == 1)
            {
                InteractioMenu.gameObject.SetActive(true);
                InteractioMenu.GetComponent<TMP_Text>().text = "L'Ecuyer polit l'épée...";
                AudioManager.Instance.PlaySFX("Meule");

                StartCoroutine(WaitBeforeClosingInteractionMenu());

                UnlockDialog();
            }
        }
    }
}
