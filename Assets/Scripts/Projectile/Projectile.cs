using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private int lifeSpanTime;

    private void Start()
    {
        Destroy(this.gameObject, lifeSpanTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
