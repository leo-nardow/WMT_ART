using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] cart;
    public int points = 0;
    public int total = 0;
    public Text pointText;
    public Text totalText;

    void Start()
    {
        points = GameManagerBadges.Instance.GetPoints();
        cart = GameManagerBadges.Instance.GetBadges();
        UpdatePointText();
    }

    public void AddCart()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (points > total)
        {
            if (cart[(int)EItemType.Quantity, buttonRef.GetComponent<ButtonInfo>().ItemId] == 0)
            {
                cart[(int)EItemType.Quantity, buttonRef.GetComponent<ButtonInfo>().ItemId]++;
                total += cart[(int)EItemType.Price, buttonRef.GetComponent<ButtonInfo>().ItemId];
                UpdateTotalText();
                buttonRef.GetComponent<ButtonInfo>().QuantityTxt.text = cart[(int)EItemType.Quantity, buttonRef.GetComponent<ButtonInfo>().ItemId].ToString();
            }
        }
    }

    public void Buy()
    {
        points -= total;
        total = 0;
        UpdatePointText();
        UpdateTotalText();
        GameManagerBadges.Instance.SaveBadges(cart);
        GameManagerBadges.Instance.SavePoints(points);
        SceneManager.LoadScene("MeusBadges");
    }

    private void UpdatePointText() => pointText.text = "Pontos: " + points.ToString();
    private void UpdateTotalText() => totalText.text = "Total: " + total.ToString();
}
