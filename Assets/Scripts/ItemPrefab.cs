using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemPrefab : MonoBehaviour
{
    [SerializeField] TMP_Text itemNameText;
    [SerializeField] Image itemSprite;
    public void Set(string itemName, Sprite sprite)
    {
        itemNameText.text = itemName;
        itemSprite.sprite = sprite;
    }
}
