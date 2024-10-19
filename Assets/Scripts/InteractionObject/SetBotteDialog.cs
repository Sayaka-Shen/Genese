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
        if(inventory.IsInventoryContaining("Bottes1") && CollisionNPC.iterationCount == 1)
        {
            InteractioMenu.gameObject.SetActive(true);
            InteractioMenu.GetComponent<TMP_Text>().text = "L'Ecuyer r�cup�re les bottes...";

            StartCoroutine(WaitBeforeClosingInteractionMenu());

            UnlockDialog();
        }
    }
}
