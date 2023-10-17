using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HighScoreScene : SceneManager
{
    //GameObj
    [SerializeField] protected TextMeshProUGUI top1;
    [SerializeField] protected TextMeshProUGUI top2;
    [SerializeField] protected TextMeshProUGUI top3;

    //Properties
    public string filePath;
    protected List<Player> topPlayer = new List<Player> { new Player { Name = "", Score = 0 },
                                                          new Player { Name = "", Score = 0 },
                                                          new Player { Name = "", Score = 0 }};

    protected List<Player> players = new List<Player> ();

    protected override void Start()
    {
        base.Start();
        string folderPath = "Assets/Data";
        string fileName = "HighScore.txt";
        string fullPath = Path.Combine(folderPath, fileName);
        this.filePath = fullPath;
        this.ReadData();
        this.SetRank();
        this.Display();
        Debug.Log(this.players.Count);
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
        for(int i = 0; i < data.Length; i += 2)
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
        for(int i = 0; i < 3; i++)
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
