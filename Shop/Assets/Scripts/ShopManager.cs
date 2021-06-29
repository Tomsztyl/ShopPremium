using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private float money = 0;
    [SerializeField] private float addMoneyBtn = 1000;

    [SerializeField] private Text textMoney = null;

    ItemAssistant moneyDisplay;

    private void Start()
    {
        moneyDisplay = new ItemAssistant();
    }

    private void Update()
    {
        moneyDisplay.PrintMoneyValue(textMoney, money);
    }

    public void AddMoneyBtn()
    {
        money += addMoneyBtn;
    }
    public void AddMoneyCount(float countadd)
    {
        money+=countadd;
    }
    public void SubbstractionMoney(float countsubbstraction)
    {
        money -= countsubbstraction;
    }
    public float GetMoney()
    {
        return money;
    }


}
public class ItemAssistant
{
    public void PrintNameItem(Text nameItem,string name)
    {
        if (nameItem!=null)
        {
            nameItem.text = name;
        }
    }
    public void PrintCountItem(Text countItem,int count)
    {
        if (countItem!=null)
        {
            countItem.text = string.Format("{0}", count);
        }
    }
    public void PrintMoneyValue(Text moneyValue, float money)
    {
        if (moneyValue != null)
        {
            moneyValue.text = string.Format("{0}$", money);
        }
    }
    public void PrintSpriteItem(Image imageItem,Sprite spriteItem)
    {
        if (imageItem!=null)
        {
            imageItem.sprite = spriteItem;
        }
    }
}
