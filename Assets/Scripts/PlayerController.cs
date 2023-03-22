using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotation;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddTorque(rotation * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb.AddTorque(-rotation * Time.deltaTime);
    }
}
