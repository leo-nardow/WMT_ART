using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemId;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        if (ItemId == 12) return;
        PriceTxt.text = Enum.GetValues(typeof(ETipoArte)).GetValue(ItemId - 1).ToString();
        QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().itens[3, ItemId].ToString();
    }
}
