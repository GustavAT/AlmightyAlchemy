using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public static Crafting Instance;

    public void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// First Item Slot
    /// </summary>
    public Item Item1;
    /// <summary>
    /// Second Item Slot
    /// </summary>
    public Item Item2;

    /// <summary>
    /// All Recipes
    /// </summary>
    private List<Recipe> Recipes;

    public void Start()
    {
        Recipes = Resources.LoadAll<Recipe>("Recipes").ToList();
    }

    public void AddItem(Item item, int slot)
    {
        Debug.Log("[Crafting] Add item " + item.name + " to slot " + slot);
        if (slot == 1)
        {
            Item1 = item;
        } else if (slot == 2)
        {
            Item2 = item;
        }

        Craft();
    }

    private void Craft()
    {
        if (Item1 == null || Item2 == null)
        {
            return;
        }

        var inventory = Inventory.Instance.AllItems;
        var matches = GetMatches();

        // Add crafted items to results grid
        Results.Instance.AddItems(matches);
        
        var newItems = new List<Item>();
        foreach (var item in matches)
        {
            if (!inventory.Contains(item))
            {
                newItems.Add(item);
            }
        }
        
        Debug.Log("[Crafting] Crafted " + matches.Count + " (New: " + newItems.Count + ")");

        // Add new items to inventory
        foreach (var newItem in newItems)
        {
            Inventory.Instance.AddItem(newItem, false);
        }

        // TODO: discoveries
    }

    private List<Item> GetMatches()
    {
        var crafted = new List<Item>();
        foreach (var recipe in Recipes)
        {
            foreach (var inputs in recipe.Inputs)
            {
                if (inputs.Input1 == Item1 && inputs.Input2 == Item2 ||
                    inputs.Input2 == Item1 && inputs.Input1 == Item2)
                {
                    crafted.AddRange(recipe.Result);
                }
            }
        }

        return crafted.Distinct().ToList();
    }
}
