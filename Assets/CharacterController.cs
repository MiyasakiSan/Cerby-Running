using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float MovementSpeed = 0;
    public bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
