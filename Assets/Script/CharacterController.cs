using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CharacterController : MonoBehaviour
{
    float MovementSpeed = 5.0f;
    public bool isMove = false;

    public bool isDash = false;

    Animator animator;
    Rigidbody2D rb;

    Vector2 movement;

    [DllImport("_Internal")]
    private static extern void PlayerScore(int score);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    IEnumerator DashTime()
    {
        yield return new WaitForSeconds(0.5f);
        isDash = false;
        MovementSpeed = 5f;
    }
    void PlayerDash()
    {
        isDash = true;
        if (MovementSpeed == 5f && isDash == true)
        {
            MovementSpeed = 50f;
            
            

            if(isDash == true && MovementSpeed == 50f)
            {
                StartCoroutine(DashTime());
            }
        }

    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * MovementSpeed * Time.deltaTime);

        Debug.Log(movement);

        if (movement.x != 0)
        {
            animator.SetFloat("moveX", 1);
        }
        if (movement.y != 0)
        {
            animator.SetFloat("moveY", 1);
        }
        if (movement.x == 0)
        {
            animator.SetFloat("moveX", 0);
        }
        if (movement.y == 0)
        {
            animator.SetFloat("moveY", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerDash();  
        }
        //if (isMove)
        //{
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        transform.position += new Vector3(0, MovementSpeed * Time.deltaTime, 0);
        //    }
        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        transform.position -= new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
        //    }
        //    if (Input.GetKey(KeyCode.S))
        //    {
        //        transform.position -= new Vector3(0, MovementSpeed * Time.deltaTime, 0);
        //    }
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        transform.position += new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
        //    }
        //    animator.SetBool("Walk", true);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            gameObject.GetComponent<CharacterController>().isMove = false;
            int Score = GameObject.Find("ScoreManager").GetComponent<ScoreCollector>().Score;
            GameObject[] AllBullet = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in AllBullet)
            {
                bullet.GetComponent<Bullet>().Speed = bullet.GetComponent<Bullet>().StartSpeed;
                bullet.SetActive(false);
                StartButton.SetActive(true);
                WelcomeText.SetActive(true);
            }
#if UNITY_WEBGL == true && UNITY_EDITOR == false
                WebGLInput.captureAllKeyboardInput = false;
                PlayerScore(Score);
#endif
        }
    }
