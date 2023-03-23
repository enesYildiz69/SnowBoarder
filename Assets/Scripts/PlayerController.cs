using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotation;
    [SerializeField] float baseSpeed;
    [SerializeField] float boostSpeed;
    SurfaceEffector2D se2d;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotatePlayer();
        speedUp();
    }

    void rotatePlayer () {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddTorque(rotation * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb.AddTorque(-rotation * Time.deltaTime);
    }

    void speedUp () {
        if (Input.GetKey(KeyCode.Space))
            se2d.speed = boostSpeed;
        else
            se2d.speed = baseSpeed;
    }
}
