using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] TMP_Text backpackText;
    public List<DropItem> Items { get => items; }
    [SerializeField] ItemPrefab itemPrefab;
    [SerializeField] DataStorage dataStorage;
    [SerializeField] GameObject inventoryPanel;

    [Header("InventoryPanel>ScrollView>Viewport>ItemList")]
    [SerializeField] GameObject itemListLocation;
    DropItem newDropItem;
    List<DropItem> items = new List<DropItem>();
    GameObject go;
    bool onDropItem;
    public int itemAddSFX;

    private void Update()
    {
        if (backpackText == null || itemListLocation == null || inventoryPanel == null || itemPrefab == null)
            Debug.Log("Attach All Component in " + this.name);

        backpackText.text = items.Count.ToString() + "/7";
        // TAKE DROP ITEM
        if (Input.GetKey("e") && onDropItem)
        {
            AddToInventory();
            Destroy(go);
            itemAddSFX++;
        }

        // OPEN INVENTORY
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

        // simpan sementara


        // set dalam panel
        itemPrefab.Set(newDropItem.itemName, newDropItem.sprite);
        Instantiate(itemPrefab, itemListLocation.transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DropItem>() != null)
        {
            onDropItem = true;
            newDropItem = other.GetComponent<DropItem>();
        }
        go = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onDropItem = false;
    }
}
