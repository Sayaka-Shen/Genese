using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cible : InteractableObject
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerInteraction))
        {
            if (playerInteraction.IsPlayerPressingI)
            {
                if (CollisionNPC.IndexDialogBon != 2)
                {
                    return;
                }

                UnlockDialog();
            }
        }
    }
}
