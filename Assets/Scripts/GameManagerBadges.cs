using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerBadges : MonoBehaviour
{
    private static GameManagerBadges _instance;
    public static GameManagerBadges Instance { get { return _instance; } }

    private int _points = 0;

    private int[,] _badges = new int[12, 12];

    private List<QuestionObject> _questions = new List<QuestionObject>(30);

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.Log("GameManagerBadges já existe na cena");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("GameManagerBadges Nao existe na cena");

            GenerateBadges();
            GenerateQuestions();

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SavePoints(int points) => this._points = points;

    public int GetPoints() => _points;

    public void SaveBadges(int[,] badges) => this._badges = badges;

    public int[,] GetBadges() => this._badges;

    private void GenerateBadges()
    {
        foreach (EArtType artType in Enum.GetValues(typeof(EArtType)))
        {
            _badges[(int)EItemType.ArtType, (int)artType] = (int)artType;
            _badges[(int)EItemType.Price, (int)artType] = 30;
            _badges[(int)EItemType.Quantity, (int)artType] = 0;
        }
    }

    private void GenerateQuestions()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Questoes_json");
        //string json = File.ReadAllText("C:\\Users\\casju\\Documents\\UFABC\\WMT_ART\\Assets\\Scripts\\Questoes_json.json"); // alterar caminho do JSON
        _questions = JsonConvert.DeserializeObject<List<QuestionObject>>(jsonFile.ToString());
        for (int i = 0; i < _questions.Count; i++)
        {
            _questions[i].Index = i + 1;
        }
    }

    public List<QuestionObject> GetQuestions() => this._questions;
    public void SaveQuestions(List<QuestionObject> questions) => this._questions = questions;

    public void ResetBadges()
    {
        GenerateBadges();
    }
    public void ResetQuestions()
    {
        GenerateQuestions();
    }
}