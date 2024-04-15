using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemySlimePrefab;
    public GameObject AttackEffectPrefab;
    public GameObject AttackEffectPrefab2;
    public GameObject AttackEffectPrefab3;

    private GameObject[] enemySlime;
    private GameObject[] AttackEffect;
    private GameObject[] AttackEffect2;
    private GameObject[] AttackEffect3;

    private GameObject[] targetPool;

    void Awake()
    {
        enemySlime = new GameObject[2];
        AttackEffect = new GameObject[20];
        AttackEffect2 = new GameObject[20];
        AttackEffect3 = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < enemySlime.Length; i++)
        {
            enemySlime[i] = Instantiate(enemySlimePrefab, transform); // Set parent as ObjectManager
            enemySlime[i].SetActive(false);
        }

        for (int i = 0; i < AttackEffect.Length; i++)
        {
            AttackEffect[i] = Instantiate(AttackEffectPrefab, transform); // Set parent as ObjectManager
            AttackEffect[i].SetActive(false);
        }

        for (int i = 0; i < AttackEffect2.Length; i++)
        {
            AttackEffect2[i] = Instantiate(AttackEffectPrefab2, transform); // Set parent as ObjectManager
            AttackEffect2[i].SetActive(false);
        }

        for (int i = 0; i < AttackEffect3.Length; i++)
        {
            AttackEffect3[i] = Instantiate(AttackEffectPrefab3, transform); // Set parent as ObjectManager
            AttackEffect3[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string type, Transform parent = null)
    {
        switch (type)
        {
            case "enemySlime":
                targetPool = enemySlime;
                break;
            case "AttackEffect":
                targetPool = AttackEffect;
                break;
            case "AttackEffect2":
                targetPool = AttackEffect2;
                break;
            case "AttackEffect3":
                targetPool = AttackEffect3;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                if (parent != null)
                {
                    targetPool[i].transform.SetParent(parent); // Set parent if specified
                }
                return targetPool[i];
            }
        }
        return null;
    }

    public GameObject[] GetPool(string type)
    {
        return targetPool;
    }
}
