using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    private PlayerControls inputs;
    private int lifes = 3;

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
        Instantiate(this.projectile.gameObject, shootPos.position, shootPos.rotation);
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
        lifes--;
        GameManager.instance.LoseLife(lifes);
        if (lifes <= 0)
        {
            TurnOffInputs();
        }
        print("Player took damage");
    }

    private void TurnOffInputs()
    {
        inputs.Disable();
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
