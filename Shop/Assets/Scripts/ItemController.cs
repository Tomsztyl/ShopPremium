using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ShopItems shopItems = null;
    [SerializeField] private Text textName = null;
    [SerializeField] private Text textCount = null;
    [SerializeField] private Text textValueMoney = null;
    [SerializeField] private Image imageSpriteItem = null;

    ItemAssistant ItemAssistant;
    ShopManager ShopManager;

    // Start is called before the first frame update
    private void Awake()
    {
        ItemAssistant = new ItemAssistant();
    }

    void Start()
    {
        ShopManager = GameObject.FindObjectOfType<ShopManager>().GetComponent<ShopManager>();
    }
    public void PrintPropertiesItem()
    {
        if (IsShopItem())
        {
            ItemAssistant.PrintNameItem(textName, shopItems.GetNameItem());
            ItemAssistant.PrintCountItem(textCount, shopItems.GetCountItem());
            ItemAssistant.PrintMoneyValue(textValueMoney, shopItems.GetValueMoneyItem());
            ItemAssistant.PrintSpriteItem(imageSpriteItem, shopItems.GetSpriteItem());
        }
    }
    private bool IsShopItem()
    {
        if (shopItems != null)
            return true;
        return false;
    }
    public void BuyItem()
    {
        if (ShopManager!=null)
        {
            float calculateBuyItem = ShopManager.GetMoney()- shopItems.GetValueMoneyItem();
            if (calculateBuyItem > 0)
                ShopManager.SubbstractionMoney(shopItems.GetValueMoneyItem());
            else
                Debug.LogError("You don't have money");
        }
    }
    public void SetShopItem(ShopItems shopItems)
    {
        this.shopItems = shopItems;
    }
}
