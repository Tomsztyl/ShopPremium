using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemShop", order = 0)]
public class ShopItems : ScriptableObject
{
    [Header("Properties item")]
    [Tooltip("Name item")]
    [SerializeField] private string _nameItem;
    [Tooltip("Item value")]
    [SerializeField] private float _valueMoneyItem;
    [Tooltip("Item count")]
    [SerializeField] private int _countItem;
    [Tooltip("Item sprite")]
    [SerializeField] private Sprite _spriteItem;


    #region Get Properties Item
    public string GetNameItem()
    {
        return _nameItem;
    }
    public float GetValueMoneyItem()
    {
        return _valueMoneyItem;
    }
    public int GetCountItem()
    {
        return _countItem;
    }
    public  Sprite GetSpriteItem()
    {
        return _spriteItem;
    }
    #endregion
}
