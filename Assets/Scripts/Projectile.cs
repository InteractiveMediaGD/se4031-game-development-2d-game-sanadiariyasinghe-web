using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        // Gets references to the Animator and BoxCollider2D components on the fireball
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // If the fireball has already hit something, stop moving
        if (hit) return;

        // Calculate movement based on speed, direction, and time
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        // Deactivate the fireball automatically if it travels for too long without hitting anything
        lifetime += Time.deltaTime;
        if (lifetime > 15) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger the explosion when the fireball touches a collider
        hit = true;
        boxCollider.enabled = false; // Disable collider so it doesn't hit multiple things
        anim.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        // Reset fireball state so it can be reused from the Object Pool
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        // Flip the fireball sprite to face the direction of travel
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    // This is the function called by the Animation Event at the end of the explosion
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}