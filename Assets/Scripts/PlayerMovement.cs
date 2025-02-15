using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D pRB;

    [SerializeField] int maxSpeed = 5;

    float hor;
    float vert;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        pRB.linearVelocity = new Vector2(hor * maxSpeed, vert* maxSpeed);
    }
}
