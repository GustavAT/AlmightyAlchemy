using System.Collections.Generic;
using System.Resources;
using TMPro;
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
    /// Text element to count discovered items
    /// </summary>
    public TextMeshProUGUI ItemCounter;
    
    /// <summary>
    /// Start items to have in the inventory
    /// </summary>
    public List<Item> StartItems;
    
    /// <summary>
    /// All items available in the inventory
    /// </summary>
    public List<Item> AllItems;

    private int _maxItemCount;

    private void Start()
    {
        InitializeMaxItemCounter();
        
        var loadedItems = SaveManager.LoadGame();
        if (loadedItems.Count > 0)
        {
            StartItems = loadedItems;
        }

        foreach (var startItem in StartItems)
        {
            AddItem(startItem, true);
        }
    }

    public void AddItem(Item item, bool isStartItem)
    {
        item.New = !isStartItem;
        AllItems.Add(item);

        Debug.Log("[Inventory] Item added " + item.name);
        
        // Instantiate game object
        var itemGameObject = Instantiate(ItemPrefab, InventoryGrid);
        var itemPresenter = itemGameObject.GetComponent<ItemPresenter>();
        if (itemPresenter != null)
        {
            itemPresenter.Initialize(item);
            itemPresenter.UpdateBadge();
        }
        
        // Start animation for new items
        if (!isStartItem)
        {
            var dragHandler = itemGameObject.GetComponent<DragDropHandler>();
            if (dragHandler != null)
            {
                dragHandler.StartIsNewAnimation();
            }
        }
        
        UpdateCurrentItemCount();
    }

    private void InitializeMaxItemCounter()
    {
        _maxItemCount = Resources.LoadAll<Item>("Items").Length;
        Debug.Log("[Inventory] Max item count " + _maxItemCount);
    }
    
    private void UpdateCurrentItemCount()
    {
        ItemCounter.text = $"Discovered {AllItems.Count,2} / {_maxItemCount,2}";
    }
}
