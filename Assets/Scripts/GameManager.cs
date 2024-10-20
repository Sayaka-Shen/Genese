using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [Header("TypeWriter")]
    [SerializeField] private float typingSpeed = 0.05f;
    private string currentTextNPC;

    [Header("UI")]
    [SerializeField] private Canvas endScene;
    [SerializeField] private GameObject panelEndScene;

    [Header("NPC Collision")]
    [SerializeField] private CollisionNPC collisionNPCBon;
    [SerializeField] private CollisionNPC collisionNPCBrute;
    [SerializeField] private CollisionNPC collisionNPCDonJuan;

    [Header("NPC End SpriteRenderer")]
    [SerializeField] private Sprite spriteEndBon;
    [SerializeField] private Sprite spriteEndBrute;
    [SerializeField] private Sprite spriteEndDonJuan;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        EndGame();
    }

    public void StartTypeWriter(string text, TMP_Text assignedText)
    {
        currentTextNPC = text;
        assignedText.text = "";

        StartCoroutine(TypeText(assignedText));
    }

    private IEnumerator TypeText(TMP_Text textBox)
    {
        foreach (char letter in currentTextNPC.ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndGame()
    {
        if(collisionNPCBon.iterationCount == 3 && !DialogueController.Instance.IsDialogOn)
        {
            endScene.gameObject.SetActive(true);
            panelEndScene.GetComponent<Image>().sprite = spriteEndBon;
        }

        if (collisionNPCBrute.iterationCount == 3 && !DialogueController.Instance.IsDialogOn)
        {
            endScene.gameObject.SetActive(true);
            panelEndScene.GetComponent<Image>().sprite = spriteEndBrute;
        }

        if(collisionNPCDonJuan.iterationCount == 3 && !DialogueController.Instance.IsDialogOn)
        {
            endScene.gameObject.SetActive(true);
            panelEndScene.GetComponent<Image>().sprite = spriteEndDonJuan;
        }
    }
}
