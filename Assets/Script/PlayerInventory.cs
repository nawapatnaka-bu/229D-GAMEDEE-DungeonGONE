using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int coin = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin += 1;
            Destroy(collision.gameObject);
        }
    }
}
