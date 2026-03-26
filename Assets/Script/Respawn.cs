using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (player == null || respawnPoint == null) return;

        // จัดการ Rigidbody ก่อนย้ายตำแหน่ง
        if (player.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // กันบัค physics ตอน teleport
            rb.position = respawnPoint.position;
            rb.rotation = respawnPoint.rotation;
        }
        else
        {
            // fallback กรณีไม่มี Rigidbody
            player.SetPositionAndRotation(
                respawnPoint.position,
                respawnPoint.rotation
            );
        }
    }
}