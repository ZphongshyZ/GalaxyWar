using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class HighScoreData : PhongMonobehaviour
{
    //Properties
    public string playerName;
    public int score;
    public string filePath;
    public string fileName = "HightScore.txt";

    protected override void Start()
    {
        base.Start();
        this.CreateData();
    }

    public virtual void CreateData()
    {
        string fullPath = Path.Combine(Application.dataPath, fileName);
        this.filePath = fullPath;
        if(!File.Exists(filePath))
        {
            File.Create(filePath); 
        }
    }

    public virtual void SaveData()
    {
        this.playerName = PointSave.Instance.SaveName;
        this.score = PointSave.Instance.SaveScore;

        string data = this.playerName + "\n" + this.score.ToString() + "\n";
        File.AppendAllText(filePath, data);
    }
}
