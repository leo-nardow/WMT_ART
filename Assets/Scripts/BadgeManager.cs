using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadgeManager : MonoBehaviour
{
    public int[,] badges = new int[12, 12];
    public Text pointText;

    void Start()
    {
        badges = GameManagerBadges.Instance.GetBadges();
        pointText.text = "Pontos: " + GameManagerBadges.Instance.GetPoints().ToString();

        foreach (EArtType tipoArte in Enum.GetValues(typeof(EArtType)))
        {
            if (badges[(int)EItemType.Quantity, (int)tipoArte] == 0)
            {
                GameObject.Find(tipoArte.ToString()).GetComponent<RawImage>().color = Color.black;
            }
        }
    }

    public void AbrirMenu()
    {
        SceneManager.LoadScene("Middle");
    }
}
