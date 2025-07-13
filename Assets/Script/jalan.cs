using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jalan : MonoBehaviour
{
    Text infochest;
    Text infoNyawa; // UI Text for nyawa
    public int Chest;
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public int nyawa;
    public bool ulang;
    private Vector2 movement;
    public SwordAttack swordAttack;
    
    public Image kalah;
    public Image menang;
    // public GameOverScreen gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        infochest = GameObject.Find("UI Chest").GetComponent<Text>();
        infoNyawa = GameObject.Find("UI Nyawa").GetComponent<Text>(); // Reference the UI Text for nyawa
    }

    // Update is called once per frame
    void Update()
    {   
        infochest.text = "Poin : " + Chest.ToString();
        infoNyawa.text = "Nyawa : " + nyawa.ToString(); 

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Debug.Log("This is movement.x" + movement.x);
        Debug.Log("This is movement.y" + movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if(movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            var targetPos = transform.position;
            targetPos.x += movement.x;
            targetPos.y += movement.y;
        }

        if (nyawa <= 0 )
        {
            Destroy(gameObject);
            kalah.gameObject.SetActive(true);
            
        }

        if (Chest >= 5){
            menang.gameObject.SetActive(true);
        }

        if (ulang==true){
            transform.position = movement;
            ulang = false;
        }
    }

    // int maxPlatform = 0;
    // public void GameOver(){
    // GameOverScreen.Setup(maxPlatform);
    // }

    void FixedUpdate ()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Chest"))
        {
            Chest chest = collision.gameObject.GetComponent<Chest>();
            if (!chest.isCollected)
            {
                chest.isCollected = true;
                Chest++;
                infochest.text = "Poin : " + Chest.ToString();
            }
        }
    }
}
