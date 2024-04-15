using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static UnityEditor.PlayerSettings;

public class Monster : MonoBehaviour
{
    [SerializeField]
    Slider HPbar;

    [SerializeField]
    Transform playerPos;

    [SerializeField]
    float StopDis;

    [SerializeField]
    float CurHP;
    [SerializeField]
    float MaxHP;

  

    void OnEnable()
    {
        CurHP = MaxHP;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPos = player.transform;
        }
    }


    void Update()
    {
        HPbar.value = CurHP / MaxHP;

        Move();
        Die();
    }


    void Move()
    {


        StopDis = Vector2.Distance(playerPos.position, transform.position);

        if (StopDis >= 1)
        {
            transform.Translate(Vector2.left * GameManager.instance.speed * Time.deltaTime);
        }
        else
        {
            GameManager.instance.Battle = true;

        }


    }
    void Die()
    {
        if (CurHP <= 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.Battle = false;
            GameManager.instance.Kill = true;   
        }
    }
    public void TakeDamage(float damage)
    {
        CurHP -= damage;
    }
}
