using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    float score;

    private PlayerAction action;
    private InputAction walk;
    
    void Awake()
    {
        action = new PlayerAction();
        walk = action.Movement.Walk;
    }

    void OnEnable()
    {
        walk.Enable();
    }

    void OnDisable()
    {
        walk.Disable();
    }

    void Update()
    {   
        float x = walk.ReadValue<Vector2>().x;
        float z = walk.ReadValue<Vector2>().y;
        Vector3 direction = new Vector3(x, 0, z);

        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameObject coin = collision.gameObject;
            score += coin.GetComponent<Coin>().GetPoint();
            Destroy(coin);
        }
    }
}
