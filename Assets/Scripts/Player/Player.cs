using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerControls inputs;
    public static Player instance;

    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform shootPos;

    private void Awake()
    {
        CheckInstance();

        inputs = new PlayerControls();

        inputs.Behaviours.Firing.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            print("Shooting projectile");
            ShootHandler();
        }
    }

    private void ShootHandler()
    {
        GameObject projectile = Instantiate(this.projectile.gameObject, shootPos.position, Quaternion.identity);
    }

    private void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage()
    {
        print("Ouch! It hurts");
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
