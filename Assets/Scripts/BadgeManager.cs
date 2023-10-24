using UnityEngine;

public class BadgeManager : MonoBehaviour
{
    public int[,] itens = new int[12,12];

    void Start()
    {
        var shopManager = GameObject.Find("ShopManager").GetComponent<ShopManagerScript>();
        itens = shopManager.itens;
    }

    void Update()
    {
        
    }
}
