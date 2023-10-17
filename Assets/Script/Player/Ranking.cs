using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : PhongMonobehaviour
{
    //Singleton
    protected static Ranking instance;
    public static Ranking Instance { get => instance; }

    //Properties
    public List<Player> ranking = new List<Player>();

    protected override void Awake()
    {
        base.Awake();
        if (Ranking.instance != null) Debug.Log("Only 1 Ranking allowed to exist");
        Ranking.instance = this;
    }

    //Ranking

    public virtual void AddToRanking(Player player)
    {
        this.ranking.Add(player);
    }
}
