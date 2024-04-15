using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject monsters;

    void Start()
    {
        
    }

  
    void Update()
    {
        if (GameManager.instance.Kill)
        {
            Instantiate(monsters,transform.position,transform.rotation);
            GameManager.instance.Kill = false;
        }
    }
}
