using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLanceDialog : InteractableObject
{
    [SerializeField] private Inventory inventory;

    private void Update()
    {
        if (inventory.IsInventoryContaining("lance1") && CollisionNPC.iterationCount == 2)
        {
            InteractioMenu.gameObject.SetActive(true);
            InteractioMenu.GetComponent<TMP_Text>().text = "L'Ecuyer récupère la lance...";

            StartCoroutine(WaitBeforeClosingInteractionMenu());

            UnlockDialog();
        }
    }
}
