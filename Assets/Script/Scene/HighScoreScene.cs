using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class HighScoreScene : SceneManager
{
    //GameObj
    [SerializeField] protected TextMeshProUGUI top1;
    [SerializeField] protected TextMeshProUGUI top2;
    [SerializeField] protected TextMeshProUGUI top3;

    //Properties
    public string filePath;
    public string fileName = "HighScore.txt";
    protected List<Player> topPlayer = new List<Player> { new Player { Name = "Robot", Score = 0 },
                                                          new Player { Name = "Robot", Score = 0 },
                                                          new Player { Name = "Robot", Score = 0 }};

    protected List<Player> players = new List<Player> ();

    protected override void Awake()
    {
        base.Awake();
        string path = Path.Combine(Application.dataPath, this.fileName);
        if (!File.Exists(path))
        {
            File.Create(path);
        }
    }

    protected override void Start()
    {
        base.Start();
        string fullPath = Path.Combine(Application.dataPath, fileName);
        this.filePath = fullPath;
        this.ReadData();
        this.SetRank();
        this.Display();
    }

    protected virtual void Display()
    {
        this.top1.text = "1. " + this.topPlayer[0].Name + "\t" + this.topPlayer[0].Score.ToString();
        this.top2.text = "2. " + this.topPlayer[1].Name + "\t" + this.topPlayer[1].Score.ToString();
        this.top3.text = "3. " + this.topPlayer[2].Name + "\t" + this.topPlayer[2].Score.ToString();
    }

    protected virtual void ReadData()
    {
        //Read Data
        string[] data = File.ReadAllLines(filePath);
        if (data.Length == 0) return;
        for (int i = 0; i < data.Length; i += 2)
        {
            Player newPlayer = new Player();
            for(int j = i; j <= i + 1; j++)
            {
                if(j % 2 == 0) newPlayer.Name = data[j];
                else newPlayer.Score = int.Parse(data[j]);
            }
            this.players.Add(newPlayer);
        }

        this.Soft();
    }

    protected virtual void SetRank()
    {
        if(this.players.Count == 0) return;
        if(this.players.Count < 3 && this.players.Count > 0)
        {
            for(int i = 0; i < this.players.Count; i++)
            {
                this.topPlayer[i] = this.players[i];
            }
            return;
        }
        for(int i = 0; i < this.topPlayer.Count; i++)
        {
            this.topPlayer[i] = this.players[i];
        }
    }

    protected virtual void Soft()
    {
        this.players.Sort();
        this.players.Reverse();
    }
}
