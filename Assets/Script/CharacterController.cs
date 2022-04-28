using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CharacterController : MonoBehaviour
{
    public float MovementSpeed = 0;
    public bool isMove = false;
    public GameObject StartButton;
    public GameObject WelcomeText;
    [DllImport("_Internal")]
    private static extern void PlayerScore(int score);
    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, MovementSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, MovementSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
}
