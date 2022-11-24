using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] TMP_Text itemText;
    Food food;

    public void Set(Food food)
    {
        this.food = food;
        itemText.text = food.foodName;
    }
    public void ClickItemButton()
    {
        Debug.Log(food.foodName + " is clicked");
    }
}
