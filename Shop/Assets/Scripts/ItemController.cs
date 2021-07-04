using RotaryHeart.Lib.SerializableDictionary;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [Header("Item properties")]
    [Tooltip("Item count")]
    [SerializeField] private float count;
    [Tooltip("Item Name Text in frame")]
    [SerializeField] private Text textName = null;
    [Tooltip("Item Text Count in frame")]
    [SerializeField] private Text textCount = null;
    [Tooltip("Text Value money in frame [Component:Button]")]
    [SerializeField] private Text textValueMoney = null;
    [Tooltip("Image Sprite in frame")]
    [SerializeField] private Image imageSpriteItem = null;

    ItemAssistant ItemAssistant;                            //using item assistan to manage item
    ShopManager ShopManager;                                //manager shop item
    EquipmentBox EquipmentBox;                              //manager box equipment is used to store items in your inventory

    ShopItems ShopItems;                                    //scriptable object stores the properties of the item

    // Start is called before the first frame update
    private void Awake()
    {
        ItemAssistant = new ItemAssistant();
    }

    void Start()
    {
        EquipmentBox = GameObject.FindObjectOfType<EquipmentBox>().GetComponent<EquipmentBox>();
        ShopManager = GameObject.FindObjectOfType<ShopManager>().GetComponent<ShopManager>();
    }

    #region Manager Item
    /// <summary>
    /// Method is used to display the properties of an item in the item frame    
    /// </summary>
    public void PrintPropertiesItem()
    {
        if (IsShopItem())
        {
            //print all properties in frame
            ItemAssistant.PrintNameItem(textName, ShopItems.GetNameItem());
            ItemAssistant.PrintCountItem(textCount, count);
            ItemAssistant.PrintMoneyValue(textValueMoney, ShopItems.GetValueMoneyItem());
            ItemAssistant.PrintSpriteItem(imageSpriteItem, ShopItems.GetSpriteItem());
        }
    }
    /// <summary>
    /// Check is ScriptableObject is assigned
    /// </summary>
    /// <returns></returns>
    private bool IsShopItem()
    {
        if (ShopItems != null)
            return true;
        return false;
    }
    /// <summary>
    /// The method is used to trigger the button in the item frame
    /// </summary>
    public void BuyItem()
    {
        if (ShopManager!=null)
        {
            float calculateBuyItem = ShopManager.GetMoney()- ShopItems.GetValueMoneyItem();
            if (calculateBuyItem >= 0)
            {
                ShopManager.SubbstractionMoney(ShopItems.GetValueMoneyItem());
                if (EquipmentBox!=null)
                {
                    EquipmentBox.AddItemToEquipment(ShopItems, EquipmentBox.GetEquipment(), count);
                }
            }
            else
                Debug.LogError("You don't have money");
        }
    }
    #endregion

    #region Set Get Propeirtes ItemController
    public void SetShopItem(ShopItems shopItems)
    {
        ShopItems = shopItems;
    }
    public void SetCountItem(float count)
    {
        this.count = count;
    }
    public ShopItems GetShopItem()
    {
        return ShopItems;
    }
    #endregion

}
/// <summary>
/// [Using] Managing the item's actions
/// </summary>
public class ItemAssistant
{
    #region Display Items
    /// <summary>
    /// The method is used to display the name of the item in a frame
    /// </summary>
    /// <param name="nameItem">The text where the name will be displayed</param>
    /// <param name="name">Text who will be displayed</param>
    public void PrintNameItem(Text nameItem, string name)
    {
        if (nameItem != null)
        {
            nameItem.text = name;
        }
    }
    /// <summary>
    /// The method is used to display the count of the item in a frame
    /// </summary>
    /// <param name="countItem">The text where the count will be displayed</param>
    /// <param name="count">Float who will be displayed</param>
    public void PrintCountItem(Text countItem, float count)
    {
        if (countItem != null)
        {
            countItem.text = string.Format("{0}", count);
        }
    }
    /// <summary>
    /// The method is used to display the money value of the item in a frame
    /// </summary>
    /// <param name="moneyValue">The text where the money value will be displayed</param>
    /// <param name="money">Float money who will be displayed</param>
    public void PrintMoneyValue(Text moneyValue, float money)
    {
        if (moneyValue != null)
        {
            moneyValue.text = string.Format("{0}$", money);
        }
    }
    /// <summary>
    /// The method is used to display the image item of the item in a frame
    /// </summary>
    /// <param name="imageItem">The image where the money value will be displayed</param>
    /// <param name="spriteItem">Sprite item who will be displayed</param>
    public void PrintSpriteItem(Image imageItem, Sprite spriteItem)
    {
        if (imageItem != null)
        {
            imageItem.sprite = spriteItem;
        }
    }
    #endregion

    #region Actions on the item
    /// <summary>
    /// The method is used to search for a free index [key] in the dictionary
    /// </summary>
    /// <param name="someDictionary">The dictionary in which the index will be searched</param>
    /// <returns>Is contains key [true] / No constains key [false]</returns>
    public int IncrementCountIndex(SerializableDictionaryBase<int, EquipmentItem> someDictionary)
    {
        if (someDictionary.Count != 0)
        {
            int last = someDictionary.Keys.Last();
            int increment = last + 1;
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
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// The method checks if the object is in the inventory
    /// </summary>
    /// <param name="someDictionary">Dictionary in which the object will be searched for</param>
    /// <param name="shopItems">Object that will be searched for in the dictionary</param>
    /// <returns>[true] if the object exists in the inventory [false] if it does not exist</returns>
    public bool IsObjectInEquipment(SerializableDictionaryBase<int, EquipmentItem> someDictionary, ShopItems shopItems)
    {
        if (someDictionary != null)
        {
            foreach (var equipmentItem in someDictionary)
            {
                if (shopItems == equipmentItem.Value._itemEquipment)
                {
                    return true;
                }
            }
        }
        return false;
    }
    /// <summary>
    /// The method looks for the item with the index in the dictionary
    /// </summary>
    /// <param name="someDictionary">Dictionary where the method will look for an index</param>
    /// <param name="shopItems">The item that will be searched for</param>
    /// <returns>The item's index value is returned, or -1 if it is not in the inventory</returns>
    public int ObjectInEquipmentIndex(SerializableDictionaryBase<int, EquipmentItem> someDictionary, ShopItems shopItems)
    {
        if (someDictionary != null)
        {
            foreach (var equipmentItem in someDictionary)
            {
                if (shopItems == equipmentItem.Value._itemEquipment)
                {
                    return equipmentItem.Key;
                }
            }
        }
        return -1;
    }
    #endregion
}
