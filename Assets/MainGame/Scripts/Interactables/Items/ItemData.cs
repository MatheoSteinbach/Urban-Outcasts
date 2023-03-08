using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] int id;
    [SerializeField] Sprite icon;
    [SerializeField] string itemName;
    [SerializeField] int amount;

    public int Id => id;
    public Sprite Icon => icon;
    public string ItemName => itemName;
    public int Amount => amount;
}
