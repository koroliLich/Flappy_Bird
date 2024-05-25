using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    private float spawntime = 1f;
    private float lowerlimit = -1f;
    private float upperlimit = 2f;

    private void Start() {
        InvokeRepeating(nameof(Spawn), spawntime, spawntime);
    }

    private void Spawn() {
        GameObject pipes = Instantiate(prefab, transform.position, transform.rotation);
        pipes.transform.position += Vector3.up * Random.Range(lowerlimit, upperlimit);
    }

}
