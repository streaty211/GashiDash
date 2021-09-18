using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public float JumpPower = 5.0f;
    [SerializeField] public float speed = 2.0f;
    Rigidbody2D player;
    private Animator anim;
    public bool isGrounded = false;
    float posX = 0.0f;
    public bool isGameOver = false;
    

    private void Awake()
    {
        player = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isGrounded) State = States.idle;
        if (!isGrounded) State = States.Jump;

            if (Input.GetButton("Jump") && isGrounded && !isGameOver)
        {
            player.AddForce(Vector3.up * (JumpPower * player.mass * player.gravityScale * 20.0f));
        }

        // встреча с препятствием лицом
        if (transform.position.x < posX)
            GameOver();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = true;

        

        if (other.collider.tag == "Enemy")
            GameOver();

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = false;
    }

    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
}

public enum States
{
    idle,
    Jump
}