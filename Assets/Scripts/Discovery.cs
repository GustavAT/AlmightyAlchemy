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
    /// Animator for the panel
    /// </summary>
    public Animator DiscoveryAnimator;

    /// <summary>
    /// Items to be displayed in the discovery screen
    /// </summary>
    private readonly Queue<Item> _itemQueue = new Queue<Item>();

    private static readonly int DiscoveryClose = Animator.StringToHash("DiscoveryClose");

    public void AddItem(Item item)
    {
        _itemQueue.Enqueue(item);
    }

    public void ShowNextDiscovery()
    {
        if (_itemQueue.Count == 0)
        {
            ClosePanel();
            return;
        }
        
        OpenPanel();
    }

    private void ClosePanel()
    {
        DiscoveryAnimator.SetTrigger(DiscoveryClose);
        Invoke(nameof(DeActivePanel), 0.3f);
        
    }

    public void DeActivePanel()
    {
        DiscoveryPanel.SetActive(false);
    }
    
    private void OpenPanel()
    {
        DiscoveryPanel.SetActive(true);
        DiscoveryAnimator.Play("DiscoveryOpen");

        var item = _itemQueue.Dequeue();
        var presenter = DiscoveryPanel.GetComponent<DiscoveryPresenter>();
        presenter.Show(item);
    }
}
