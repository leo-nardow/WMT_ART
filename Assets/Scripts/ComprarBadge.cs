using UnityEngine;
using UnityEngine.SceneManagement;

public class ComprarBadge : MonoBehaviour
{
    public void chamaComprarBadges()
    {
        SceneManager.LoadScene("ShopV2");
    }

    public void chamaMeusBadges()
    {
        SceneManager.LoadScene("MeusBadges");
    }
}
