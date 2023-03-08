using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField] string prompt;
    [SerializeField] ItemData itemData;
    public string InteractionPrompt => prompt;
    public bool CanInteract => canInteract;

    private bool canInteract;

    private bool hasRedBox => !gameObject.activeSelf;

    private void Start()
    {
        canInteract = true;
       var hasRedBox = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("hasRedBox")).value;
        gameObject.SetActive(!hasRedBox);
        Debug.Log(hasRedBox);
    }
    private void Update()
    {
        
    }
    public bool Interact(Interactor interactor)
    {
        gameObject.SetActive(false);
        InventoryManager.Instance.AddItem(itemData);
        Ink.Runtime.Object obj = new Ink.Runtime.BoolValue(hasRedBox);
        DialogueManager.GetInstance().SetVariableState("hasRedBox", obj);
        Debug.Log("PickUp");
        //Destroy(gameObject);
        return true;
    }

    public void LoadData(GameData data)
    {
       // gameObject.SetActive(!data.hasRedBox);
    }

    public void SaveData(GameData data)
    {
        //data.hasRedBox = gameObject.activeSelf;
    }
}
