using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public Respawn respawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (respawn != null)
            {
                respawn.RespawnPlayer();
            }
        }
    }
}
