using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    private bool awareOfPlayer;
    private Vector2 directionToPlayer;
    [SerializeField] private int awarenessArea;

    private Rigidbody2D rb;
    private Transform player;

    [SerializeField] private float enemySpeed;
    [SerializeField] private float enemyRotSpeed;

    private Vector2 targetDirection;

    /*private bool canSeePlayer() 
    {

    }*/


    private void Awake()
    {
        player = FindFirstObjectByType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Awareness
        checkAwareness();

    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (awareOfPlayer)
        {
            targetDirection = directionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }
        Debug.Log("Here");
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, enemyRotSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = transform.up * enemySpeed;
        }
    }

    private void checkAwareness() 
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;
        if (enemyToPlayerVector.magnitude <= awarenessArea)
        {
            awareOfPlayer = true;
        }
        else
        {
            awareOfPlayer = false;
        }
    }
}
