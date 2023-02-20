using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; private set; }
    public List<GameObject> Enemies { get; private set; } = new List<GameObject>();
    public List<GameObject> Pickups { get; private set; } = new List<GameObject>();
    public GameObject Player { get; private set; }

    static public event Action ScoreUpdated;

    //singleton implementation
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else Instance = this;
    }

    void Start()
    {
        PickupScript.Picked += IncreaseScore;
    }

    public void AddEnemy(GameObject t)
    {
        Enemies.Add(t);
    }

    public void AddPickup(GameObject t)
    {
        Pickups.Add(t);
    }

    public void AddPlayer(GameObject t)
    {
        Player = t;
    }

    void IncreaseScore(GameObject go)
    {
        Score++;
        ScoreUpdated.Invoke();
    }
}
