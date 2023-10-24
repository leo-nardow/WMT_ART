using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] itens = new int[12,12];
    public int[,] carrinho = new int[12,12];
    public int pontos = 1000;
    public int total = 0;
    public Text pontosText;
    public Text totalText;
    public RawImage imagem;

    void Start()
    {
        pontosText.text = "Pontos: " + pontos.ToString();

        foreach (ETipoArte tipoArte in Enum.GetValues(typeof(ETipoArte)))
        {
            itens[(int)ETipoItem.TipoArte, (int)tipoArte] = (int)tipoArte;
            itens[(int)ETipoItem.Preco, (int)tipoArte] = 50;
            itens[(int)ETipoItem.Quantidade, (int)tipoArte] = 0;
        }
        itens[(int)ETipoItem.Quantidade, 3] = 1;
        carrinho = itens;

        var titulo = GameObject.Find("Titulo").GetComponent<Text>().text;

        if (titulo == "Meus Badges")
        {
            foreach (ETipoArte tipoArte in Enum.GetValues(typeof(ETipoArte)))
            {
                if (itens[(int)ETipoItem.Quantidade, (int)tipoArte] == 0)
                {
                    GameObject.Find(tipoArte.ToString()).GetComponent<RawImage>().color = Color.black;
                }
            }
        }
    }

    public void AddCart()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (pontos > total)
        {
            if (carrinho[(int)ETipoItem.Quantidade, buttonRef.GetComponent<ButtonInfo>().ItemId] == 0)
            {
                carrinho[(int)ETipoItem.Quantidade, buttonRef.GetComponent<ButtonInfo>().ItemId]++;
                total += carrinho[(int)ETipoItem.Preco, buttonRef.GetComponent<ButtonInfo>().ItemId];
                totalText.text = "Total: " + total.ToString();
                buttonRef.GetComponent<ButtonInfo>().QuantityTxt.text = carrinho[(int)ETipoItem.Quantidade, buttonRef.GetComponent<ButtonInfo>().ItemId].ToString();            
            }
        }
    }

    public void Buy()
    {
        itens = carrinho;
        pontos -= total;
        total = 0;
        totalText.text = "Total: " + total.ToString();
        pontosText.text = "Pontos: " + pontos.ToString();
    }
}
