using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int coin = 0;
    public AudioClip coinSfx;
    private AudioSource coinSfxSource;

    private void Awake()
    {
        coinSfxSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin += 1;
            Destroy(collision.gameObject);
            coinSfxSource.PlayOneShot(coinSfx);
        }
    }
}
