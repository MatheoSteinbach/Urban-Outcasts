using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour
{
    [SerializeField] GameObject choiceButton1;
    [SerializeField] GameObject choiceButton2;
    [SerializeField] GameObject choiceButton3;

    [SerializeField] GameObject shadow1;
    [SerializeField] GameObject shadow2;
    [SerializeField] GameObject shadow3;

    
    private void Update()
    {
        if(choiceButton1.activeSelf)
        {
            shadow1.SetActive(true);
        }
        else if (!choiceButton1.activeSelf)
        {
            shadow1.SetActive(false);
        }
        if (choiceButton2.activeSelf)
        {
            shadow2.SetActive(true);
        }
        else if (!choiceButton2.activeSelf)
        {
            shadow2.SetActive(false);
        }
        if (choiceButton3.activeSelf)
        {
            shadow3.SetActive(true);
        }
        else if (!choiceButton3.activeSelf)
        {
            shadow3.SetActive(false);
        }
    }
}
