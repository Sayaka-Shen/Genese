using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChevalBrute : InteractableObject
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            if (playerInteraction.IsPlayerPressingI && CollisionNPC.iterationCount == 2 && !isInteractionMenuOpen)
            {
                isInteractionMenuOpen = true;
                InteractioMenu.gameObject.SetActive(true);
                GameManager.Instance.StartTypeWriter("L'Ecuyer sabote le cheval de La Brute...", InteractioMenu.GetComponentInChildren<TMP_Text>());
                AudioManager.Instance.PlaySFX("Horse");
                StartCoroutine(WaitBeforeClosingInteractionMenu());

                UnlockDialog();
            }
        }
    }
}
