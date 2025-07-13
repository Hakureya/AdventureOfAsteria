using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int nyawa;
    public enum AttackDirection 
    {
        kanan, kiri
    }

    public AttackDirection attackDirection;

    Vector2 rightAttackOffset;

    Collider2D swordCollider;

    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.localPosition;
        swordCollider.enabled = false; // Pastikan collider tidak aktif saat mulai
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Jika mouse diklik
        {
            Attack();
        }
        if (Input.GetMouseButtonUp(0)) // Jika mouse dilepas
        {
            SerangBerhenti();
        }
    }

    public void Attack() 
    {
        switch (attackDirection) 
        {
            case AttackDirection.kiri:
                SerangKiri();
                break;
            case AttackDirection.kanan:
                SerangKanan();
                break;
        }
    }

    public void SerangKanan()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    private void SerangKiri()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void SerangBerhenti()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.nyawa--;
                if (enemyScript.nyawa <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            VerticalEnemy enemyScript = collision.gameObject.GetComponent<VerticalEnemy>();
            if (enemyScript != null)
            {
                enemyScript.nyawa--;
                if (enemyScript.nyawa <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
