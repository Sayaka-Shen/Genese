using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; }

    [Header("Infos")] 
    [SerializeField] private TMP_Text txtInfo;
    [SerializeField] private Canvas canvas;

    [Header("Choices")] 
    [SerializeField] private GameObject choicesParent;
    [SerializeField] private GameObject choicePrefab;

    [Header("Player Infos")]
    [SerializeField] private PlayerInteraction playerInteraction;

    public bool isDialogOn;
  
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        playerInteraction = FindObjectOfType<PlayerInteraction>();
    }

    private void Start()
    {
        isDialogOn = false;
    }

    private void CleanDefaultChoices()
    {
        foreach (var go in choicesParent.GetComponentsInChildren<Button>())
            Destroy(go.gameObject);
    }

    public void InitDialog(DialogData data, DialogDatabase dialogDatabase)
    {
        if(string.IsNullOrEmpty(data.Id)) 
            return;
        
        isDialogOn = true;
        txtInfo.text = data.sentence;
        InitChoices(data, dialogDatabase);
    }

    private void InitChoices(DialogData data, DialogDatabase dialogDatabase)
    {
        CleanDefaultChoices();

        foreach (var choice in data.choices)
        {
            GameObject choiceInstance = Instantiate(choicePrefab, choicesParent.transform);

            if (choiceInstance.TryGetComponent<Button>(out var button))
            {
                Debug.Log("oui");
                if (choice.IDChoice.ToLower() == "c_ok" || choice.IDChoice.ToLower() == "c_close")
                {
                    button.onClick.AddListener(() => 
                    {
                        canvas.gameObject.SetActive(false); 
                        isDialogOn = false;
                    });
                }
                else
                {
                    button.onClick.AddListener(() => 
                    {
                        InitDialog(dialogDatabase.GetData(choice.IDDialog), dialogDatabase);
                        isDialogOn = true;
                    }); 
                }   
            }
            
            choiceInstance.GetComponentInChildren<TMP_Text>().text = dialogDatabase.GetChoiceData(choice.IDChoice).label;
        }
    }
}
