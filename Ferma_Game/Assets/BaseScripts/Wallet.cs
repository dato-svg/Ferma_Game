using TMPro;
using UnityEngine;

namespace BaseScripts
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int coin;
        [SerializeField] private TextMeshProUGUI coinText;
        
        public int Coin => coin;

        private void Start() => 
            UpdateText();

        public void AddCoin(int amount)
        {
            coin += amount;
            UpdateText();
        }

        public void SpendCoin(int amount)
        {
            coin -= amount;
            UpdateText();
        }


        private void UpdateText() => 
            coinText.text = coin.ToString();
    }
}