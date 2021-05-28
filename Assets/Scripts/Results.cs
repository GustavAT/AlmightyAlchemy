using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour
{
    public static Results Instance;

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
    public Transform ResultGrid;


    public void AddItems(List<Item> items)
    {
        RemoveChildren();

        foreach (var item in items)
        {
            // Instantiate game object
            var itemGameObject = Instantiate(ItemPrefab, ResultGrid);
            var itemPresenter = itemGameObject.GetComponent<ItemPresenter>();
            if (itemPresenter != null)
            {
                itemPresenter.Initialize(item);
            }
        }
    }

    private void RemoveChildren()
    {
        Debug.Log("[Results] Remove items: " + transform.childCount);
        foreach (Transform child in ResultGrid.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
