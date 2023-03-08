using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PhoneUI : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] PlayerController playerController;
    [Header("Goldbag")]
    [SerializeField] GameObject coldbag;
    [Header("ShinyBlink")]
    [SerializeField] GameObject toggleShinyBlink;
    [SerializeField] GameObject phoneShinyBlink;
    [Header("Buttons")]
    [SerializeField] GameObject togglePhone;
    [SerializeField] GameObject Phone;
   
    [Header("Panels")]
    [SerializeField] GameObject questlogPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject savePanel;
    [SerializeField] GameObject inventoryPanel;

    [Header("Bapple Store")]
    [SerializeField] DialogueObject bappleStore;

    private bool isPhoneOpen;
    private bool isPhoneUnlocked;
    private GameObject lastOpenedPanel;

    private bool isOnPause;
    private void Start()
    {
        isOnPause = false;
        isPhoneUnlocked = false;
        isPhoneOpen = false;
        lastOpenedPanel = questlogPanel;
    }

    private void Update()
    {
        if (Keyboard.current[Key.Escape].wasPressedThisFrame && !isOnPause && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            pauseScreen.SetActive(true);
            playerController.DisableMovement();
            isOnPause = true;
        }
        else if (Keyboard.current[Key.Escape].wasPressedThisFrame && isOnPause && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            pauseScreen.SetActive(false);
            playerController.EnableMovement();
            isOnPause = false;
        }

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (isPhoneOpen)
            {
                ClosePhone();

            }
        }
        if(!isPhoneUnlocked && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            bappleStore.SetToCanInteract();
            isPhoneUnlocked = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("getPhone")).value;
            if(isPhoneUnlocked)
            {
                coldbag.SetActive(false);
                questlogPanel.GetComponent<QuestManager>().ShowPhoneQuest();
                Phone.SetActive(true);
                questlogPanel.SetActive(true);
                isPhoneOpen = true;
                bappleStore.SetToCanNotInteract();
            }
        }
        if(isPhoneUnlocked && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (Keyboard.current[Key.I].wasPressedThisFrame && !isPhoneOpen)
            {
                OpenPhone();
                if(toggleShinyBlink.activeSelf)
                {
                    DeactivateToggleBlink();
                    ActivatePhoneBlink();
                }
            }
            else if (Keyboard.current[Key.I].wasPressedThisFrame && isPhoneOpen)
            {
                DeactivatePhoneBlink();
                ClosePhone();
            }
        }
    }
    public void SetPauseOff()
    {
        isOnPause = false;
    }
    public void ActivateToggleBlink()
    {
        toggleShinyBlink.SetActive(true);
    }
    public void ActivatePhoneBlink()
    {
        if(!isPhoneOpen)
        {
            phoneShinyBlink.SetActive(true);

        }
    }
    public void DeactivateToggleBlink()
    {
        toggleShinyBlink.SetActive(false);
    }
    public void DeactivatePhoneBlink()
    {
        phoneShinyBlink.SetActive(false);
    }
    public void OpenPhoneOnInventory()
    {
        Phone.gameObject.SetActive(true);
        togglePhone.gameObject.SetActive(false);
        isPhoneOpen = true;
        questlogPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(true);

        lastOpenedPanel = inventoryPanel.gameObject;
    }

    public void OpenPhoneOnMenu()
    {
        Phone.gameObject.SetActive(true);
        togglePhone.gameObject.SetActive(false);
        isPhoneOpen = true;
        questlogPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(true);
        savePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);

        lastOpenedPanel = inventoryPanel.gameObject;
    }
    public void OpenPhone()
    {
        Phone.gameObject.SetActive(true);
        lastOpenedPanel.SetActive(true);
        togglePhone.gameObject.SetActive(false);
        isPhoneOpen = true;
    }
    public void ClosePhone()
    {
        Phone.gameObject.SetActive(false);
        togglePhone.gameObject.SetActive(true);
        questlogPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);
        isPhoneOpen = false;
    }
    public void OnTogglePhoneClick()
    {
        togglePhone.gameObject.SetActive(false);
        Phone.gameObject.SetActive(true);
    }

    public void OnMainMenuClick()
    {
        questlogPanel.gameObject.SetActive(true);
        settingsPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);

        lastOpenedPanel = questlogPanel.gameObject;
    }

    public void OnSettingsClick()
    {
        questlogPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(true);
        savePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);

        lastOpenedPanel = settingsPanel.gameObject;
    }

    public void OnSaveClick()
    {
        questlogPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(true);
        inventoryPanel.gameObject.SetActive(false);

        lastOpenedPanel = savePanel.gameObject;
    }

    public void OnInventoryClick()
    {
        questlogPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(true);
        phoneShinyBlink.SetActive(false);

        lastOpenedPanel = inventoryPanel.gameObject;
    }

    public void OnQuestLogClick()
    {
        questlogPanel.gameObject.SetActive(true);
        settingsPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);

        lastOpenedPanel = inventoryPanel.gameObject;
    }

    public void OnBackToMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }

}
