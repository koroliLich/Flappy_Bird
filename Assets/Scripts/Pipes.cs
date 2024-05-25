using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftside = -11f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftside) {
            Destroy(gameObject);
        }  
    }
}
