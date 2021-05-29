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

    private static readonly int HideDiscovery = Animator.StringToHash("HideDiscovery");
    private static readonly int ShowDiscovery = Animator.StringToHash("ShowDiscovery");

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
        DiscoveryAnimator.SetTrigger(HideDiscovery);
        Invoke(nameof(DeActivePanel), 0.5f);
        
    }

    public void DeActivePanel()
    {
        Debug.Log("Deactivate Panel");
        DiscoveryPanel.SetActive(false);
    }
    
    private void OpenPanel()
    {
        SoundManager.Instance.playSuccess();
        DiscoveryPanel.SetActive(true);
        DiscoveryAnimator.SetTrigger(ShowDiscovery);

        var item = _itemQueue.Dequeue();
        var presenter = DiscoveryPanel.GetComponent<DiscoveryPresenter>();
        presenter.Show(item);
    }
}
