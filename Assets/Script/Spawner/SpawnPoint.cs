using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : PhongMonobehaviour
{
    //Singleton
    private static SpawnPoint instance;
    public static SpawnPoint Instance { get => instance; }

    [SerializeField] protected List<Transform> points;

    protected override void Awake()
    {
        base.Awake();
        if (SpawnPoint.instance != null) Debug.LogError("Only one SpawnPoint allowed to exist");
        SpawnPoint.instance = this;
    }

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
        Debug.Log(transform.name + " LoadPoints", gameObject);
    }

    //SpawnPoint
    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }

    public virtual List<Transform> ListEnermy(string name)
    {
        List<Transform> enermys = new List<Transform>();
        foreach(Transform enermy in points)
        {
            if(enermy.CompareTag(name))
            {
                enermys.Add(enermy);
            }
        }
        return enermys;
    }
}
