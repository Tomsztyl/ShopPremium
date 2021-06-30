using RotaryHeart.Lib.SerializableDictionary;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EquipmentBox : ArsenalBox
{

    public void AddItemToEquipment(ShopItems shopItems,float countItem)
    {
        EquipmentItem equipmentItem = new EquipmentItem();
        equipmentItem.EquipmentAdd(shopItems, countItem);
        _equipment.Add(IncrementCountIndex(_equipment), equipmentItem);
    }
    public int IncrementCountIndex(SerializableDictionaryBase<int, EquipmentItem> someDictionary)
    {
        int last = someDictionary.Keys.Last();
        int increment = last++;
        if (someDictionary.ContainsKey(increment))
        {
            //is contains key [true]
            return -1;
        }
        else
        {
            //no constains key [false]
            return increment;
        }
    }

    #region Equipment Dictionary
    [SerializeField]
    public Equipment _equipment;

    [System.Serializable]
    public class Equipment : SerializableDictionaryBase<int, EquipmentItem> { }

    [System.Serializable]
    public class EquipmentItem
    {

        public ShopItems _itemEquipment;
        public float _countItemEquipment;

        public void EquipmentAdd (ShopItems _itemEquipment, float _countItemEquipment)
        {
            this._itemEquipment= _itemEquipment;
            this._countItemEquipment = _countItemEquipment;
        }
    }
    private EquipmentItem GetValueItem(int _itemKindObjectIndex)
    {
        return _equipment.FirstOrDefault(x => x.Key == _itemKindObjectIndex).Value;
    }
    private EquipmentItem GetItem(int _itemKindObjectIndex)
    {
        return _equipment.FirstOrDefault(x => x.Key == _itemKindObjectIndex).Value;
    }

    #endregion
}
