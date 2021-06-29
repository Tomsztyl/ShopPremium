using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsenalBox : MonoBehaviour
{
    [SerializeField] List<ShopItems> shopItems = new List<ShopItems>();
    [SerializeField] private GameObject frameForItem = null;

    private void Start()
    {
        AddListItemDisplay();
    }

    public void AddListItemDisplay()
    {
        if (frameForItem!=null)
        {
            foreach (ShopItems item in shopItems)
            {
                GameObject itemInstantiate = Instantiate(frameForItem, this.gameObject.transform);
                ItemController itemController = itemInstantiate.GetComponent<ItemController>();

                if (itemController != null)
                {
                    itemController.SetShopItem(item);
                    itemController.PrintPropertiesItem();
                }
            }
        }  
    }
}
