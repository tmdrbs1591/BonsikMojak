using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{

    [SerializeField]
    ObjectManager objectManager;

    void Start()
    {
        
    }

  
    void Update()
    {
        if (GameManager.instance.Kill)
        {
            GameObject slime = objectManager.MakeObj("enemySlime");
            slime.transform.position = transform.position;
            GameManager.instance.Kill = false;
        }
    }
}
