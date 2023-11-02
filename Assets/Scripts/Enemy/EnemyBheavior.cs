using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyBheavior : MonoBehaviour
{
    private Animator animator;
    private Rigidbody enemyRigidbody;
    private Vector3 playerPosition;

    private bool canWalk = false;
    private float timeLapse = 0;

    [SerializeField, Range(1f, 15f)] private float velocity;
    [SerializeField] private float walkDelay;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody>();        
    }

    private void Start()
    {
        playerPosition = Player.instance.transform.position;
        transform.LookAt(new Vector3(playerPosition.x, transform.position.y, playerPosition.z));
    }

    private void Update()
    {
        timeLapse += Time.deltaTime;
        if (canWalk)
        {
            enemyRigidbody.velocity = transform.forward * velocity;
        }

        if (timeLapse >= walkDelay)
        {
            canWalk = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Projectile>())
        {
            Destroy(other.gameObject);
            canWalk = false;
            enemyRigidbody.velocity = Vector3.zero;
            GameManager.instance.IncreaseScore();
            Die();
        }

        if (other.TryGetComponent(out Player player)) //out pega o dado da função get e guarda na variável
        {
            player.TakeDamage();
        }
    }

    private void Die()
    {
        enemyRigidbody.velocity = Vector3.zero;
        animator.SetTrigger("Die");
        Destroy(this.gameObject, 1f);
    }
}
