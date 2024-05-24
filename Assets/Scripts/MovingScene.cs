using UnityEngine;

public class Move : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float speed = 0.1f;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    private void Update() {
        meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
