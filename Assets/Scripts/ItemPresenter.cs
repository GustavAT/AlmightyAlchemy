using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPresenter : MonoBehaviour
{
    /// <summary>
    /// Image placeholder
    /// </summary>
    public Image Image;
    
    /// <summary>
    /// Name placeholder
    /// </summary>
    public TextMeshProUGUI NameText;

    /// <summary>
    /// Item
    /// </summary>
    public Item Item;
    
    public void Initialize(Item item)
    {
        Item = item;
        Image.sprite = item.Icon;
        NameText.text = item.name;
    }
}
