using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheval : InteractableObject
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            if (playerInteraction.IsPlayerPressingI)
            {
                UnlockDialog();
                Destroy(gameObject);
            }
        }
    }
}
