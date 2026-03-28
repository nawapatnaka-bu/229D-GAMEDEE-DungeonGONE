using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText;
    private PlayerInventory playerCoin;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        playerCoin = playerObj.GetComponent<PlayerInventory>();
    }
    private void Update()
    {
        coinText.text = "Coins: " + playerCoin.coin.ToString();
    }
}
