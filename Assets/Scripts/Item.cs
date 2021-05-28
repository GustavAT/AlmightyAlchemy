using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string name;
    public Sprite Icon;
    public Color CustomColor = Color.black;
    public bool New = false;
}
