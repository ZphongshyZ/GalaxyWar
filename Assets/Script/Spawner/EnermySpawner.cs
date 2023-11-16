    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : Spawner
{
    //Singleton
    private static EnermySpawner instance;
    public static EnermySpawner Instance { get => instance; }

    //List Enermy
    public static string[] enermyNames = new string[] { "Enermy_1", "Enermy_2", "Enermy_3", "Meteorite", "Enermy_4", "Enermy_5", "Enermy_4.5", "Enermy_5.5"};

    public static string[] bonusEnermy = new string[] { "Enermy_6" };

    public static string[] bossNames = new string[] { "Boss_1", "Boss_1" };

    public static List<string> enermyLevel = new List<string>();

    //Properties
    //Enermy
    [SerializeField] protected float spawnDelay;
    [SerializeField] protected float spawnDelayMin = 4f;
    [SerializeField] protected float spawnTime = 0f;
    [SerializeField] public int bossCount = 0;

    //Bonus Enermy
    //-- Time Again --
    [SerializeField] protected float spawnBonusAgain = 15f;
    [SerializeField] protected float timeBonusAgain = 0f;

    //--Time Delay to Spawn--
    [SerializeField] protected float spawnBonusDelay = 1f;
    [SerializeField] protected float timeBonusDelay = 0f;
    
    //--Time in Bonus --
    [SerializeField] protected float spawnInBonus = 20f;
    [SerializeField] protected float timeInBonus = 0f;

    [SerializeField] protected bool isBonusEnermyTime = false;

    [SerializeField] public int level;
    [SerializeField] protected int count;
    [SerializeField] protected int nextCount;

    //EnermySpawn System
    protected override void Start()
    {
        base.Start();
        EnermySpawner.enermyLevel.Add(enermyNames[0]);
    }

    protected override void Awake()
    {
        base.Awake();
        if (EnermySpawner.instance != null) Debug.LogError("Only one EnermySpawner allowed to exist");
        EnermySpawner.instance = this;
        EnermySpawner.enermyLevel.Clear();
        this.level = 0;
        this.count = 0;
        this.nextCount = 3;
        this.spawnDelay = 7.5f;
    }

    private void Update()
    {
        this.SpawnGame();
        this.SetLevel();
        this.CheckBonusTime();
    }

    //Set Level
    protected virtual void SetLevel()
    {
        if (this.count == this.nextCount)
        {
            if (this.level +1 >= EnermySpawner.enermyNames.Length)
            {
                this.level++;
                this.nextCount += 1;
                this.count = 0;
                this.spawnDelay -= 0.5f;
                if (this.spawnDelay <= this.spawnDelayMin) this.spawnDelay = this.spawnDelayMin;
            }
            else
            {
                this.level++;
                EnermySpawner.enermyLevel.Add(enermyNames[this.level]);
                this.count = 0;
                this.spawnDelay -= 0.8f;
                this.nextCount += 1;
                if (this.spawnDelay <= this.spawnDelayMin) this.spawnDelay = this.spawnDelayMin;
            }
        }
    }

    //Spawn
    protected virtual void SpawnGame()
    {
        if (GameOverScene.Instance.IsWinning == true || GameOverScene.Instance.IsLossing == true) return;
        if (this.level > 0 && this.level % 5 == 0) this.BossSpawning();
        this.EnermySpawning();
        this.TimeBonusEnermy();
    }

    //Spawn Enermy
    protected virtual void EnermySpawning()
    {
        if (this.bossCount > 0) return;
        this.spawnTime += Time.deltaTime;
        if (this.spawnTime < this.spawnDelay) return;
        this.spawnTime = 0f;
        string name = RandomPrefab(EnermySpawner.enermyLevel);
        List<Transform> enermys = SpawnPoint.Instance.ListEnermy(name);
        for (int i = 0; i < enermys.Count; i++)
        {
            Transform ranPos = enermys[i];
            Vector3 pos = ranPos.position;
            Quaternion rot = transform.rotation;
            Transform obj = this.Spawn(name, pos, rot);
            obj.gameObject.SetActive(true);
        }
        this.count++;
    }

    //Bonus Enermy
    protected virtual void CheckBonusTime()
    {
        if (this.isBonusEnermyTime == false) return;
        this.timeInBonus += Time.deltaTime;
        if(this.timeInBonus < this.spawnInBonus) return;
        this.timeInBonus = 0f;
        this.timeBonusAgain = 0f;
        this.isBonusEnermyTime = false;
    }

    protected virtual void TimeBonusEnermy()
    {
        if (this.level < 3) return;
        if (this.bossCount > 0) return;
        this.timeBonusAgain += Time.deltaTime;
        if (this.timeBonusAgain < this.spawnBonusAgain) return;
        this.isBonusEnermyTime = true;
        this.SpawnBounusEnermy();
    }

    protected virtual void SpawnBounusEnermy()
    {
        if (this.isBonusEnermyTime == false) return;
        this.timeBonusDelay += Time.deltaTime;
        if (this.timeBonusDelay < this.spawnBonusDelay) return;
        this.timeBonusDelay = 0f;
        string name = RandomPrefab(bonusEnermy);
        List<Transform> enermys = SpawnPoint.Instance.ListEnermy(name);
        for (int i = 0; i < enermys.Count; i++)
        {
        Transform ranPos = enermys[i];
        Vector3 pos = ranPos.position;
        pos.x = ranPos.position.x + Random.Range(-5f, 5f);
        Quaternion rot = transform.rotation;
        Transform obj = this.Spawn(name, pos, rot);
        obj.gameObject.SetActive(true);
        }
    }

    //Spawn Boss
    protected virtual void BossSpawning()
    {
        if (this.bossCount > 0) return;
        this.spawnTime += Time.deltaTime;
        if (this.spawnTime < this.spawnDelay) return;
        this.spawnTime = 0f;
        string name = RandomPrefab(EnermySpawner.bossNames);
        List<Transform> enermys = SpawnPoint.Instance.ListEnermy(name);
        for (int i = 0; i < enermys.Count; i++)
        {
            Transform ranPos = enermys[i];
            Vector3 pos = ranPos.position;
            Quaternion rot = transform.rotation;
            Transform obj = this.Spawn(name, pos, rot);
            obj.gameObject.SetActive(true);
        }
        this.bossCount++;
    }

    //Random
    protected virtual string RandomPrefab(string[] enermys)
    {
        int rand = Random.Range(0, enermys.Length);
        return enermys[rand];
    }

    protected virtual string RandomPrefab(List<string> enermys)
    {
        int rand = Random.Range(0, enermys.Count);
        return enermys[rand];
    }
}