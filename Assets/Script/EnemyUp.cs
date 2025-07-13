using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 5f;
    private Vector3 startPos;
    private bool movingUp = true;
    jalan KomponenGerak;
    public int nyawa;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        KomponenGerak = GameObject.Find("Player").GetComponent<jalan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= startPos.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= startPos.y - moveDistance)
            {
                movingUp = true;
            }
        }

        if (nyawa <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jalan playerScript = collision.gameObject.GetComponent<jalan>();
            if (playerScript != null)
            {
                playerScript.nyawa--;
                playerScript.ulang = true;
            }
        }
    }
}
