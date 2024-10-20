using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;

public class Inventory : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Canvas UIinventory;
    [SerializeField] private TMP_Text prefabText;
    [SerializeField] private GameObject panelParent;

    private TMP_Text instanceTextBox;

    [SerializeField] private CollisionNPC collisionNPC;
    private InteractableObject interactableObject;

    private List<GameObject> inventoryList = new List<GameObject>();

    private void Awake()
    {
        interactableObject = FindAnyObjectByType<InteractableObject>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TakeObject"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                UIinventory.gameObject.SetActive(true);

                inventoryList.Add(new GameObject(collision.gameObject.name));

                if (panelParent.transform.childCount > 0 && panelParent.transform.GetChild(0) != null)
                {
                    Destroy(panelParent.transform.GetChild(0).gameObject);

                    instanceTextBox = Instantiate(prefabText);
                    instanceTextBox.transform.SetParent(panelParent.transform);

                    instanceTextBox.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    instanceTextBox.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    instanceTextBox.rectTransform.sizeDelta = new Vector2(200, 50);
                    instanceTextBox.rectTransform.anchoredPosition = Vector2.zero;

                    instanceTextBox.text = collision.gameObject.name;

                    instanceTextBox.transform.SetAsLastSibling();
                }
                else
                {
                    instanceTextBox = Instantiate(prefabText);
                    instanceTextBox.transform.SetParent(panelParent.transform);

                    instanceTextBox.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);  
                    instanceTextBox.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);  
                    instanceTextBox.rectTransform.sizeDelta = new Vector2(200, 50); 
                    instanceTextBox.rectTransform.anchoredPosition = Vector2.zero;

                    instanceTextBox.text = collision.gameObject.name;

                    instanceTextBox.transform.SetAsLastSibling();
                }

                Destroy(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        if (IsInventoryContaining("Epee") && collisionNPC.iterationCount == 1 && !interactableObject.isInteractionMenuOpen)
        {
            interactableObject.isInteractionMenuOpen = true;
            interactableObject.InteractioMenu.gameObject.SetActive(true);
            GameManager.Instance.StartTypeWriter("L'Ecuyer récupère l'Epée...", interactableObject.InteractioMenu.GetComponentInChildren<TMP_Text>());
            AudioManager.Instance.PlaySFX("epee");

            StartCoroutine(interactableObject.WaitBeforeClosingInteractionMenu());
        }
    }

    public bool IsInventoryContaining(string name)
    {
        foreach (GameObject item in inventoryList)
        {
            if (item != null && item.name == name)
            {
                return true;
            }
        }

        return false;
    }
}
