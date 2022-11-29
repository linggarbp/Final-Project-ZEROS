using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<DropItem> Items { get => items; }
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject listLocation;
    [SerializeField] ItemPrefab itemPrefab;
    DropItem newDropItem;
    List<DropItem> items = new List<DropItem>();
    bool onDropItem;


    private void Update()
    {
        // ambil drop item
        if (Input.GetKeyDown("e") && onDropItem)
        {
            AddToInventory();
        }

        // buka inventory
        if (Input.GetKeyDown(KeyCode.Tab))
            inventoryPanel.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Tab))
            inventoryPanel.SetActive(false);
    }

    // update list pada panel inventory
    public void AddToInventory()
    {
        // add ke list
        Items.Add(newDropItem);

        // set dalam panel
        itemPrefab.Set(newDropItem.itemName, newDropItem.sprite);
        Instantiate(itemPrefab, listLocation.transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DropItem")
        {
            onDropItem = true;
            newDropItem = other.GetComponent<DropItem>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onDropItem = false;
    }
}