using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Player : IComparable<Player>
{
    protected string name;
    public string Name { get => name; set => name = value; }

    protected int score;
    public int Score { get => score; set => score = value; }

    public int CompareTo(Player other)
    {
        return score.CompareTo(other.score);
    }

    public virtual void SetPlayer(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
