using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public Respawn respawn;
    public PlayerController player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            respawn.RespawnPlayer();
        }
    }
}
