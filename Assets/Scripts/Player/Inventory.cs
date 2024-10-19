using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Search;

public class Inventory : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Canvas UIinventory;
    [SerializeField] private TMP_Text prefabText;
    [SerializeField] private GameObject panelParent;

    [SerializeField] private CollisionNPC collisionNPC;
    private InteractableObject interactableObject;

    private List<GameObject> inventoryList = new List<GameObject>();

    private void Awake()
    {
        interactableObject = FindAnyObjectByType<InteractableObject>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TakeObject") && Input.GetMouseButtonDown(0))
        {
            if(collision.gameObject.name == "Epee" && collisionNPC.iterationCount != 1)
            {
                return;
            } 
            else
            {
                interactableObject.InteractioMenu.gameObject.SetActive(true);
                interactableObject.InteractioMenu.GetComponent<TMP_Text>().text = "L'Ecuyer récupère l'Epée...";
                AudioManager.Instance.PlaySFX("epee");

                StartCoroutine(interactableObject.WaitBeforeClosingInteractionMenu());
                
            }

            UIinventory.gameObject.SetActive(true);
            inventoryList.Add(collision.gameObject);

            foreach (GameObject item in inventoryList)
            {
                TMP_Text instancePrefabText = Instantiate(prefabText);
                instancePrefabText.transform.SetParent(panelParent.transform, false);
                instancePrefabText.SetText(item.name);
            }

            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public bool IsInventoryContaining(string name)
    {
        foreach (GameObject item in inventoryList)
        {
            if(item != null && item.name == name)
            {
                return true;
            }
        }

        return false;
    }
}
