using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLanceDialog : InteractableObject
{
    [SerializeField] private Inventory inventory;

    private void Update()
    {
        if (inventory.IsInventoryContaining("lance1") && CollisionNPC.iterationCount == 2 && !isInteractionMenuOpen)
        {
            isInteractionMenuOpen = true;
            InteractioMenu.gameObject.SetActive(true);
            GameManager.Instance.StartTypeWriter("L'Ecuyer récupère la lance...", InteractioMenu.GetComponentInChildren<TMP_Text>());

            StartCoroutine(WaitBeforeClosingInteractionMenu());

            UnlockDialog();
        }
    }
}
