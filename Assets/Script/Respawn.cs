using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;

        
        if (player == null || respawnPoint == null)
        {
            return;
        }

        
        player.position = respawnPoint.position;
    }
}