using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 pos;
    Vector3 num;
    float rota = 0;
    [SerializeField] private float speed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        num.x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (pos.x < -7)
        {
            num.x = 1;
            rota = 0;
        }
        else if (pos.x > 7)
        {
            num.x = -1;
            rota = 180;
        }

        rb.linearVelocityX = num.x * speed ;
        this.transform.rotation = Quaternion.Euler(0,rota,0);
    }
}
