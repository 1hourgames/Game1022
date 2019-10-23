using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if(Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
}
