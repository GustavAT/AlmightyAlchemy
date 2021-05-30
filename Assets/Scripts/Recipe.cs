using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField]
    public ItemPair[] Inputs;
    [SerializeField]
    public Item Result;

    [System.Serializable]
    public class ItemPair
    {
        [SerializeField]
        public Item Input1;
        [SerializeField]
        public Item Input2;
    }
}
