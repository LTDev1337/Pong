using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager Manager;
    public Rigidbody2D rb;
    public float startingSpeed;
    public GameObject p1Paddle;
    public GameObject p2Paddle;
    Vector2 direction;
    public float xVelocity;
    public float yVelocity;

    void Start()
    {
        StartCoroutine(BallReset());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        /*if(collision.gameObject.CompareTag("p1Paddle"))
        {
            BallDirect(p1Paddle.GetComponent<PlayerController>().vertical);
        }
        else if (collision.gameObject.CompareTag("p2Paddle"))
        {
            BallDirect(p2Paddle.GetComponent<Player2Controller>().vertical);
        }*/

        // Reflects ball based on collider normal direction
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        rb.linearVelocity = direction * startingSpeed;

        if (collision.gameObject.CompareTag("RightGoal"))
        {
            Manager.Player1Scored();
            StartCoroutine(BallReset());
        }
        else if (collision.gameObject.CompareTag("LeftGoal"))
        {
            Manager.Player2Scored();
            StartCoroutine(BallReset());
        }
    }

    public IEnumerator BallReset()
    {
        rb.linearVelocity = Vector2.zero;
        this.GetComponent<Transform>().position = Vector2.zero;

        float horizontal = Random.value >= 0.5f ? 1f : -1f;
        float vertical = Random.value >= 0.5f ? 1f : -1f;

        xVelocity = Random.Range(0.5f, 0.9f) * horizontal;
        yVelocity = (1 - Mathf.Abs(xVelocity)) * vertical;

        yield return new WaitForSeconds(3);

        direction = new Vector2(xVelocity, yVelocity);
        direction.Normalize();
        rb.linearVelocity = direction * startingSpeed;
    }

}
