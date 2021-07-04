using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;


public class EquipmentBox : MonoBehaviour
{
    [Header("Inventory properties")]
    [Tooltip("Inventory dictionary")]
    [SerializeField] private Equipment _equipment;
    [Tooltip("Arsenal box where the item will be displayed by the script")]
    [SerializeField] private ArsenalBox _arsenalShopDisplay;

    #region Adding and managing items in dictionaries
    /// <summary>
    /// The method adds items to the ArselanBox script where it will be displayed in the item frames
    /// </summary>
    public void AddItemToArsenalEquipment()
    {
        foreach (var item in _equipment)
        {
            AddItemToArsenal(item.Value._itemEquipment, _arsenalShopDisplay.GetEquipmentArsenal(), item.Value._countItemEquipment);
        }
    }
    /// <summary>
    /// The method adds items to your internal inventory
    /// </summary>
    /// <param name="shopItems">An item to be added to your internal inventory</param>
    /// <param name="_shopEqupment">Internal inventory</param>
    /// <param name="countItem">Amount of an item added to the internal inventory</param>
    public void AddItemToEquipment(ShopItems shopItems,Equipment _shopEqupment , float countItem)
    {
        EquipmentItem equipmentItem = new EquipmentItem();
        ItemAssistant itemAssistant = new ItemAssistant();

        if (_shopEqupment != null)
        {
            if (!itemAssistant.IsObjectInEquipment(_shopEqupment, shopItems))
            {
                equipmentItem.EquipmentAdd(shopItems, countItem);
                _shopEqupment.Add(itemAssistant.IncrementCountIndex(_shopEqupment), equipmentItem);
            }
            else
            {        
                _shopEqupment[itemAssistant.ObjectInEquipmentIndex(_shopEqupment, shopItems)]._countItemEquipment += countItem;
            }
        }  
    }
    /// <summary>
    /// The method adds items to your arsenal's inventory where it will be displayed in the item frame
    /// </summary>
    /// <param name="shopItems">Item to be added to the arsenal</param>
    /// <param name="_shopEqupment">Arsenal where the item will be added</param>
    /// <param name="countItem">The amount of item that will be added to the arsenal</param>
    private void AddItemToArsenal(ShopItems shopItems,Equipment _shopEqupment , float countItem)
    {
        EquipmentItem equipmentItem = new EquipmentItem();
        ItemAssistant itemAssistant = new ItemAssistant();

        if (_shopEqupment != null)
        {
            if (!itemAssistant.IsObjectInEquipment(_shopEqupment, shopItems))
            {
                equipmentItem.EquipmentAdd(shopItems, countItem);
                _shopEqupment.Add(itemAssistant.IncrementCountIndex(_shopEqupment), equipmentItem);
            }
            else
            {        
                _shopEqupment[itemAssistant.ObjectInEquipmentIndex(_shopEqupment, shopItems)]._countItemEquipment = countItem;
            }
        }  
    }
    #endregion

    #region Get Properties
    public Equipment GetEquipment()
    {
        return _equipment;
    }
    #endregion
}

#region A universal dictionary that holds items
[System.Serializable]
public class Equipment : SerializableDictionaryBase<int, EquipmentItem> { }

/// <summary>
/// The class that stores the properties of the item (Dictionaries)
/// </summary>
[System.Serializable]
public class EquipmentItem
{
    public ShopItems _itemEquipment;                //scriptable object where is holded properties item
    public float _countItemEquipment;               //amount of item stored

    /// <summary>
    /// The method adds the properties of the item to the dictionary
    /// </summary>
    /// <param name="_itemEquipment">Added item</param>
    /// <param name="_countItemEquipment">Item quantity</param>
    public void EquipmentAdd(ShopItems _itemEquipment, float _countItemEquipment)
    {
        this._itemEquipment = _itemEquipment;
        this._countItemEquipment = _countItemEquipment;
    }
}
#endregion
