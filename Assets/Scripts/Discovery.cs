using System.Collections.Generic;
using UnityEngine;

public class Discovery : MonoBehaviour
{
    public static Discovery Instance;

    public void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Discovery panel
    /// </summary>
    public GameObject DiscoveryPanel;

    /// <summary>
    /// Items to be displayed in the discovery screen
    /// </summary>
    public Queue<Item> ItemQueue = new Queue<Item>();

    public void AddItem(Item item)
    {
        ItemQueue.Enqueue(item);
    }

    public void ShowNextDiscovery()
    {
        if (ItemQueue.Count == 0)
        {
            DiscoveryPanel.SetActive(false);
            return;
        }
        
        DiscoveryPanel.SetActive(true);

        var item = ItemQueue.Dequeue();
        var presenter = DiscoveryPanel.GetComponent<DiscoveryPresenter>();
        presenter.Show(item);
    }
}
