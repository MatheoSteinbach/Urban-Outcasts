using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI amountText;
    [SerializeField] TextMeshProUGUI amountAddedText;
    [SerializeField] Animator animator;
    private int amount;
    private int amountAdded;
    

    private void Start()
    {
        amount = 0;
    }

    private void Update()
    {
        amountText.text = amount.ToString();
        amountAddedText.text = ("+ " +amountAdded.ToString());
    }
    public void AddCoin(int _amount)
    {
        amountAdded = _amount;
        amount += _amount;
        animator.Play("CoinsAddedAnim");
        Ink.Runtime.Object obj = new Ink.Runtime.IntValue(amount);
        DialogueManager.GetInstance().SetVariableState("coins", obj);
    }
}
