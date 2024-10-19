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
            if (playerInteraction.IsPlayerPressingI && CollisionNPC.iterationCount == 2)
            {
                InteractioMenu.gameObject.SetActive(true);
                InteractioMenu.GetComponent<TMP_Text>().text = "L'Ecuyer sabote le cheval de La Brute...";
                AudioManager.Instance.PlaySFX("Horse");
                StartCoroutine(WaitBeforeClosingInteractionMenu());

                UnlockDialog();
            }
        }
    }
}
