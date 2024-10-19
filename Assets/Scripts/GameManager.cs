using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [Header("TypeWriter")]
    [SerializeField] private float typingSpeed = 0.05f;
    private string currentTextNPC;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
}
