using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    float rota = 0;


    [SerializeField] LayerMask groundLayer;
    bool isGround = false;

    [SerializeField] LayerMask enemyLayer;

    PlayerInput playerInput;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var move = playerInput.actions["Move"].ReadValue<Vector2>();

        if (isGround)
            rb.linearVelocityX = move.x * speed;

        var dir = move.normalized;
        if (dir.x == 1)
        {
            rota = 0;
        }
        else if (dir.x == -1)
        {
            rota = 180;
        }
        this.transform.rotation = Quaternion.Euler(0, rota, 0);

        if (playerInput.actions["Jump"].WasPressedThisFrame())
        {
            if (isGround)
            {
               

                rb.linearVelocityY = jumpSpeed;
                rb.linearVelocityX = dir.x * 2;
                isGround = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGround = true;
        }
        if(((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            //Destroy(this.gameObject);
        }
    }
}
