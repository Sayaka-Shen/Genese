using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetBotteDialog : InteractableObject
{
    [SerializeField] private Inventory inventory;

    private void Update()
    {
        if(inventory.IsInventoryContaining("Bottes1") && CollisionNPC.iterationCount == 1)
        {
            UnlockDialog();
        }
    }
}
