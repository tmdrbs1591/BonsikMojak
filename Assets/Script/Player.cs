using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    float timer = 0f;

    [SerializeField]
    Vector2 AttackboxSize; //공격 박스 범위
    [SerializeField]
    Transform Attackpos;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("RunSpeed", GameManager.instance.speed);

        Attack();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Attackpos.position, AttackboxSize);
    }
    void Attack()
    {
        if (GameManager.instance.Battle)
        {
            anim.SetFloat("Attack1Speed", GameManager.instance.Attackspeed);
            anim.SetTrigger("Attack1");

            // Attackspeed에 따라 일정 시간마다 "Attack"을 출력.
            if (GameManager.instance.Attackspeed > 0)
            {
                timer += Time.deltaTime * GameManager.instance.Attackspeed;
                if (timer >= 1f)
                {
                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Attackpos.position, AttackboxSize, 0);
                    foreach (Collider2D collider in collider2Ds)
                    {
                        if (collider != null)
                        {
                            collider.GetComponent<Monster>().TakeDamage(GameManager.instance.Power);
                        }
                    }
                    timer = 0f;
                }
            }
        }
    }
}
