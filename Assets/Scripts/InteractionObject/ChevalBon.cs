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
            if (playerInteraction.IsPlayerPressingI)
            {
                InteractioMenu.gameObject.SetActive(true);
                InteractioMenu.GetComponentInChildren<TMP_Text>().text = "L'Ecuyer caresse le cheval...";
                
                StartCoroutine(WaitBeforeClosingInteractionMenu());

                UnlockDialog();
            }
        }
    }
}
