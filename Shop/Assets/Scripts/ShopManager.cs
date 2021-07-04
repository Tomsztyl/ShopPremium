using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    [Header("Store properties")]
    [Tooltip("The player's money")]
    [SerializeField] private float money = 0;
    [Tooltip("Text where is display money")]
    [SerializeField] private Text textMoney = null;


    [Header("Store tabs")]
    [Tooltip("Controller to control the shop box")]
    [SerializeField] private ScrollRect _weaponeShopScrollRect;
    [Tooltip("The box where the rifles are stored")]
    [SerializeField] private GameObject _boxRifle;
    [Tooltip("The box where the grenade are stored")]
    [SerializeField] private GameObject _boxGrenade;
    [Tooltip("The box where is equipment box")]
    [SerializeField] private GameObject _boxEquipment;

    ItemAssistant moneyDisplay;                       //using item assistan to manage item   

    private void Start()
    {
        moneyDisplay = new ItemAssistant();
    }

    private void Update()
    {
        moneyDisplay.PrintMoneyValue(textMoney, money);
    }
    #region Manage Money
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
    #endregion

    /// <summary>
    /// Changes the current shop box
    /// </summary>
    /// <param name="buttonIndex">The index is set in the OnClick button</param>
    public void SwitchBoxShop(int buttonIndex)
    {
        if (_weaponeShopScrollRect!=null)
        {
            switch (buttonIndex)
            {
                case 0:
                    if (_boxRifle != null)
                    {
                        _boxRifle.SetActive(true);
                        _weaponeShopScrollRect.content = _boxRifle.GetComponent<RectTransform>();
                        _boxGrenade.SetActive(false);
                        _boxEquipment.SetActive(false);
                    }
                    break;
                case 1:
                    if (_boxGrenade != null)
                    {
                        _boxRifle.SetActive(false);
                        _boxGrenade.SetActive(true);
                        _weaponeShopScrollRect.content = _boxGrenade.GetComponent<RectTransform>();
                        _boxEquipment.SetActive(false);
                    }
                    break;
                case 2:
                    if (_boxEquipment != null)
                    {
                        _boxRifle.SetActive(false);
                        _boxGrenade.SetActive(false);
                        _boxEquipment.SetActive(true);
                        _weaponeShopScrollRect.content = _boxEquipment.GetComponent<RectTransform>();
                    }
                    break;
            }
        }       
    }


}
