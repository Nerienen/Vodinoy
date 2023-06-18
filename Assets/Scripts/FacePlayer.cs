using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    public float offset = 0f;

    private void Start()
    {
        player = GameObject.Find("PlayerControllerFPS");
        playerTransform = player.transform;
    }

    private void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        rotation *= Quaternion.Euler(0, offset, 0);
        transform.rotation = rotation;
    }
}
