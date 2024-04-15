using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public bool Battle = false;
    public float curspeed;
    public float speed;
    public float Attackspeed;
    public float Power;
    public bool Kill = true;
    void Awake()
    {
        instance = this;
    }

  
    void Update()
    {
        
    }
}
