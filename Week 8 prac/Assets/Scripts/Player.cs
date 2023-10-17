using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    float score = 0;
    [SerializeField] private TMP_Text scoreText;

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
        scoreText.text = string.Format("Score: {0}", score);

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
            float coinPoint = coin.GetComponent<Coin>().GetPoint();
            Debug.Log(coinPoint);
            score += coinPoint;
            Destroy(coin);
        }
    }
}
