using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TurtleGuardController guardController;
    public TurtleGuardController GuardController => guardController;
    [SerializeField] private ChairController chairController;
    public ChairController ChairController => chairController;


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
