using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public void RespawnPlayer()
    {
        if (player == null || respawnPoint == null) return;

        if (player.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // ใช้ MovePosition เพื่อความนุ่มนวลของ Physics
            rb.position = respawnPoint.position;
            rb.rotation = respawnPoint.rotation;
        }

        player.SetPositionAndRotation(respawnPoint.position, respawnPoint.rotation);
    }

    // สำหรับใช้กับ Ground (พื้นอันตราย)
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RespawnPlayer();
        }
    }


}