using System.Collections;
using System.Collections.Generic;
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
    public Item Slot1;
    /// <summary>
    /// Second Item Slot
    /// </summary>
    public Item Slot2;
}
