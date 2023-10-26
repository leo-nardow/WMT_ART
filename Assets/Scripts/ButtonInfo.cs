using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemId;
    public int[,] Badges;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        if (ItemId == 12) return;
        Badges = GameManagerBadges.Instance.GetBadges();
        Debug.Log(Badges);

        if (QuantityTxt != null)
        {
            QuantityTxt.text = Badges[3, ItemId].ToString();
        }

        PriceTxt.text = Enum.GetValues(typeof(EArtType)).GetValue(ItemId - 1).ToString();
    }
}
