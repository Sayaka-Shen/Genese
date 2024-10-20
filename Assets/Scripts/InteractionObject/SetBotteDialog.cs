using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetBotteDialog : InteractableObject
{
    [SerializeField] private Inventory inventory;

    private void Update()
    {
        if(inventory.IsInventoryContaining("Bottes1") && CollisionNPC.iterationCount == 1 && !isInteractionMenuOpen)
        {
            isInteractionMenuOpen = true;
            InteractioMenu.gameObject.SetActive(true);
            GameManager.Instance.StartTypeWriter("L'Ecuyer récupère les bottes...", InteractioMenu.GetComponentInChildren<TMP_Text>());

            StartCoroutine(WaitBeforeClosingInteractionMenu());

            UnlockDialog();
        }
    }
}
