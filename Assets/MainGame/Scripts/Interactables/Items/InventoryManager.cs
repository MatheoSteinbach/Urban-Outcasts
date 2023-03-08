using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemData> Items = new List<ItemData>();

    public ItemController[] InventoryItems;

    public Transform inventoryUI;
    public GameObject inventoryItem;

    public int itemsStored = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        // change to list items called on items pickup or items delete

    }

    public void AddItem(ItemData item)
    {
        Items.Add(item);
        ListItems();
    }

    public void RemoveItem(ItemData item)
    {
        Items.Remove(item);
        ListItems();
    }
    public void ListItems()
    {
        foreach(Transform item in inventoryUI)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, inventoryUI);
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            var itemName = obj.transform.Find("Name").GetComponent<TextMeshProUGUI>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.Icon;

        }
        SetInventoryItems();
        itemsStored++;
    }

    public void SetInventoryItems()
    {
        InventoryItems = inventoryUI.GetComponentsInChildren<ItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].Add(Items[i]);
        }
    }
}
