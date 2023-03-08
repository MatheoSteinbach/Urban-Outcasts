using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    // same as MainMenu 
    [Header("Menu Navigation")]
    [SerializeField] CanvasGroup shadow;
    [SerializeField] MainMenu mainMenu;
    [SerializeField] Button backButton;
    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;
    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        if(!isLoadingGame)
        {
            DataPersistenceManager.instance.NewGame();
            SceneManager.LoadScene(4);
        }
        //DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene(3);
    }
    public void OnBackClicked()
    {
        shadow.alpha = 1;
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProiflesGameData();

        // for controller
        //GameObject firstSelected = backButton.gameObject;
        foreach(SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);

            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
                //for controller
                //if(firstSelected.Equals(backButton.gameObject))
                //{
                //    firstSelected = saveSlot.gameObject;
                //}
            }
        }
       // StartCoroutine(this.SetFirstSelected(firstSelected));
    }
    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}
