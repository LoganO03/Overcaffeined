using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    [SerializeField]private int health = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out EnemyDamageSource damageSource)) 
        {
            health -= damageSource.damage;
            GameManager.Instance.ChangeHealth(health);
        }
    }
}
