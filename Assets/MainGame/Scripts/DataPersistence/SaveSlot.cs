using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] string profileId = "";

    [Header("Content")]
    [SerializeField] GameObject noDataContent;
    [SerializeField] GameObject hasDataContent;
    [SerializeField] TextMeshProUGUI dateCreated;
    [SerializeField] TextMeshProUGUI timePlayed;

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }
    public void SetData(GameData data)
    {
        if(data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);

        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            // GET WHEN CREATED AND TIME PLAYED
            // dateCreated.text = data.dateCreated
            //timePlayed.text = data.timePlayed
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}
