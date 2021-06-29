using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemShop", order = 0)]
public class ShopItems : ScriptableObject
{
    [SerializeField] private string _nameItem;
    [SerializeField] private float _valueMoneyItem;
    [SerializeField] private int _countItem;
    [SerializeField] private Sprite _spriteItem;


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
}
