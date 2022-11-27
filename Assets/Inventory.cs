using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<DropItem> Items { get => items; }
    [SerializeField] GameObject itemListLocation;
    [SerializeField] ItemPrefab itemPrefab;
    [SerializeField] DataStorage dataStorage;
    DropItem newDropItem;
    List<DropItem> items = new List<DropItem>();
    GameObject go;
    bool onDropItem;

    private void Update()
    {
        // ambil drop item
        if (Input.GetKey("e") && onDropItem)
        {
            AddToInventory();
            Destroy(go);
        }
    }

    // update list pada panel inventory
    public void AddToInventory()
    {
        // add ke list
        Items.Add(newDropItem);

        // simpan sementara
        dataStorage.itemCollect++;

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
