using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private const float gravity = 9.8f;
    public float fly_power = 4f;

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Mouse0)) {
            direction = Vector3.up * fly_power;
        }
        direction.y += -gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
}
