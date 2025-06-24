using UnityEngine;

public class Tank : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction;
    float speed = 0f;

    Vector2 min;
    Vector2 max;

    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

    void Start()
    {
        min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -horizontal);

        float vertical = Input.GetAxis("Vertical");
        speed += vertical * Time.deltaTime * 10f;

        direction = transform.right;
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;

        Vector3 pos = transform.position;
        if (pos.x > max.x) pos.x = min.x;
        if (pos.x < min.x) pos.x = max.x;
        if (pos.y > max.y) pos.y = min.y;
        if (pos.y < min.y) pos.y = max.y;
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right * 0.5f, transform.rotation * Quaternion.Euler(0, 0, -90));


            Rigidbody2D rb = bullet.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.velocity = transform.right * bulletSpeed;
            Destroy(bullet, 2f);
        }
    }
}
