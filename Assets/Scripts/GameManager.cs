using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private int points = 1000;

    private int[,] badges = new int[12,12];

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            foreach (EArtType artType in Enum.GetValues(typeof(EArtType)))
            {
                badges[(int)EItemType.ArtType, (int)artType] = (int)artType;
                badges[(int)EItemType.Price, (int)artType] = 50;
                badges[(int)EItemType.Quantity, (int)artType] = 0;
            }

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SavePoints(int points) => this.points = points;

    public int GetPoints() => points;

    public void SaveBadges(int[,] badges) => this.badges = badges;

    public int[,] GetBadges() => this.badges;
}
