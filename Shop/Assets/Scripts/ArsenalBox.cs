using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsenalBox : MonoBehaviour
{
    [Header("Properties Arsenal")]
    [Tooltip("Dictionaries Item Arsenal")]
    [SerializeField] private Equipment _shopItems;
    [Tooltip("The frame where the item will be displayed")]
    [SerializeField] private GameObject _frameForItem = null;


    private void Awake()
    {
        //getting initial value from scriptableobject
        UpdateCountItem(_shopItems);
    }
    private void OnDisable()
    {
        //removing all children of the arsenal after disabling its activity
        foreach (Transform destroyObject in this.gameObject.transform)
        {
            Destroy(destroyObject.gameObject);
        }
    }

    #region Add Item To Equipment
    /// <summary>
    /// The method creates the item frame
    /// </summary>
    public void AddListItemButton()
    {
        AddListItemDisplay(_shopItems, _frameForItem);
    }
    /// <summary>
    /// The method checks if the item frame is created
    /// </summary>
    /// <param name="childArsenal">Checks the frame of the object in the children</param>
    /// <param name="shopItems">The item that is being checked</param>
    /// <returns>[true] if the item frame was found / [false] if not found</returns>
    private bool CheckIsFrameCrated(Transform childArsenal, ShopItems shopItems)
    {
        foreach(Transform frameObject in childArsenal.transform)
        {
            ItemController itemController = frameObject.GetComponent<ItemController>();

            if (itemController!=null)
            {
                if (shopItems == itemController.GetShopItem())
                {
                    return true;
                }
            }
        }
        return false;

    }

    /// <summary>
    /// Creates children for the object where the ArsenalBox component is located
    /// </summary>
    /// <param name="_shopItems">Dictionary of items</param>
    /// <param name="frameForItem">Item frame</param>
    public void AddListItemDisplay(Equipment _shopItems, GameObject frameForItem)
    {
        if (frameForItem!=null )
        {
            foreach (var item in _shopItems.Values)
            {
                if (!CheckIsFrameCrated(this.gameObject.transform, item._itemEquipment))
                {
                    GameObject itemInstantiate = Instantiate(frameForItem, this.gameObject.transform);
                    ItemController itemController = itemInstantiate.GetComponent<ItemController>();

                    if (itemController != null)
                    {
                        itemController.SetShopItem(item._itemEquipment);
                        itemController.SetCountItem(item._countItemEquipment);
                        itemController.PrintPropertiesItem();
                    }
                }               
            }
        }  
    }
    /// <summary>
    /// Method getting initial value from scriptableobject
    /// </summary>
    /// <param name="_shopItems">Dictionaries of items</param>
    public void UpdateCountItem(Equipment _shopItems)
    {
        if (_shopItems.Count!=0)
        {
            foreach (var itemEq in _shopItems.Values)
            {
                itemEq._countItemEquipment = itemEq._itemEquipment.GetCountItem();
            }
        }
       
    }
    #endregion

    #region Get Properties
    public Equipment GetEquipmentArsenal()
    {
        return _shopItems;
    }
    public GameObject GetFrameForItem()
    {
        return _frameForItem;
    }
    #endregion
}
