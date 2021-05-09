using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TurtleGuardController guardController;
    public TurtleGuardController GuardController => guardController;
    [SerializeField] private ChairController chairController;
    public ChairController ChairController => chairController;
    public int savedTurtles;
    public bool gameIsRunning = true;
    public int GetAmountOfBornTurtles()
    {
        if (EggSpawner.Instance.BornTurtles.Count > 0)
            return EggSpawner.Instance.BornTurtles.Count;
        else
            return 0;
    }

    public void SavedTurtle()
    {
        savedTurtles++;
        UIManager.Instance.UpdateSavedTurtles();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else
            Destroy(this);
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
