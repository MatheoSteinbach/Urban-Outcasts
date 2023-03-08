using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSavePanel : MonoBehaviour
{
    [SerializeField] GameObject saveButton;
    [SerializeField] GameObject loadButton;
    [SerializeField] GameObject saveSlotsButtons;
    [SerializeField] GameObject loadSlotsButtons;


    private void Start()
    {
        
    }

    public void OnLoadClick()
    {
        saveButton.gameObject.SetActive(false);
        loadButton.gameObject.SetActive(false);
        loadSlotsButtons.gameObject.SetActive(true);
    }
    public void OnSaveClick()
    {
        saveButton.gameObject.SetActive(false);
        loadButton.gameObject.SetActive(false);
        saveSlotsButtons.gameObject.SetActive(true);
    }
    public void OnBackClick()
    {
        loadSlotsButtons.gameObject.SetActive(false);
        saveSlotsButtons.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(true);
        loadButton.gameObject.SetActive(true);
    }
}
