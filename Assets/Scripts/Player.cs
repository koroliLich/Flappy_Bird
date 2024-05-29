using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private const float gravity = 9.8f;
    public float fly_power = 4f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private float rotationSpeed = 7f;
    private float rotationAngle = 45f;
    private Quaternion targetRotation;
    
    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.1f, 0.1f);
    }
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Mouse0)) {
            direction = Vector3.up * fly_power;
        } 
        
        direction.y += -gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        if (direction.y > 0) {
            targetRotation = Quaternion.Euler(0, 0, rotationAngle);
        }
        else {
            targetRotation = Quaternion.Euler(0, 0, -rotationAngle);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    private void AnimateSprite()
    {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Crash") {
            FindObjectOfType<Game>().GameOver();
        } else if (other.gameObject.tag == "PlusPoint") {
            FindObjectOfType<Game>().Scoring();
        }
    }
}
