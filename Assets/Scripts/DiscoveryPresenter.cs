using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiscoveryPresenter : MonoBehaviour, IPointerClickHandler
{
    public Image Icon;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Quote;
    private Image _background;

    public void Awake()
    {
        _background = transform.GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Discovery.Instance.ShowNextDiscovery();
    }

    public void Show(Item item)
    {
        Icon.sprite = item.Icon;
        Name.text = item.name;
        Quote.text = item.Quote;
        _background.color = item.CustomColor;
        
        Debug.Log("[Discovery Presenter] Show item " + item.name + ", color: " + item.CustomColor);
    }
}
