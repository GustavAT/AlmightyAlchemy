using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Prefab for the icon
    /// </summary>
    public GameObject ItemPrefab;

    /// <summary>
    /// Grid
    /// </summary>
    public Transform InventoryGrid;
    
    /// <summary>
    /// Start items to have in the inventory
    /// </summary>
    public List<Item> StartItems;
    
    /// <summary>
    /// All items available in the inventory
    /// </summary>
    public List<Item> AllItems;

    private void Start()
    {
        foreach (var startItem in StartItems)
        {
            AddItem(startItem, true);
        }
    }

    private void AddItem(Item item, bool isStartItem)
    {
        AllItems.Add(item);
        
        // Display discovery message if a crafted item is added
        if (!isStartItem)
        {
            // TODO
            Debug.Log("Item crafted");
        }
        
        Debug.Log("Item added " + item.name);
        
        // Instantiate game object
        var itemGameObject = Instantiate(ItemPrefab, InventoryGrid);
        var itemPresenter = itemGameObject.GetComponent<ItemPresenter>();
        if (itemPresenter != null)
        {
            itemPresenter.Initialize(item);
        }
    }
}
