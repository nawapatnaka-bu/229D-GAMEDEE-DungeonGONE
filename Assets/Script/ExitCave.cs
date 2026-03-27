using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCave : MonoBehaviour
{
    public PlayerInventory playerInventory;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

            if (inventory.coin >= 3)
            {
                SceneManager.LoadScene("End Credit");
            }
            else
            {
                Debug.Log("เหรียญยังไม่ครบนะ! มีแค่ " + (inventory != null ? inventory.coin : 0));
            }
        }
    }
}
