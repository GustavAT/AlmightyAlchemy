using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// Slot number - either 1 or 2
    /// </summary>
    public int SlotNumber;

    /// <summary>
    /// Display image
    /// </summary>
    public Image Image;

    /// <summary>
    /// Display text
    /// </summary>
    public TextMeshProUGUI ItemName;
    

    public void OnDrop(PointerEventData eventData)
    {
        var itemGameObject = DragDropHandler.GetItemBeingDragged();
        var itemPresenter = itemGameObject.GetComponent<ItemPresenter>();
        if (itemPresenter != null)
        {
            Debug.Log("[Slot] #" + SlotNumber + " Item dropped " + itemPresenter.name + " " + itemPresenter.Image);
            var item = itemPresenter.Item;
            Image.sprite = item.Icon;
            ItemName.text = item.name;
            
            Crafting.Instance.AddItem(item, SlotNumber);
        }
    }
}
