using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreData : PhongMonobehaviour
{
    //Properties
    public string playerName;
    public int score;
    public string filePath;
    protected string data;

    protected override void Start()
    {
        base.Start();
        string folderPath = "Assets/Data";
        string fileName = "HighScore.txt";
        string fullPath = Path.Combine(folderPath, fileName);
        this.filePath = fullPath;
    }

    public virtual void SaveData()
    {
        this.playerName = PointSave.Instance.SaveName;
        this.score = PointSave.Instance.SaveScore;

        this.data += this.playerName + "\n" + this.score.ToString() + "\n";
        File.AppendAllText(this.filePath, data);
    }
}
