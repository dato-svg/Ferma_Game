using UnityEngine;
using UnityEngine.UI;

namespace BaseScripts
{
    public class SpawnPlantUI : MonoBehaviour
    { 
        public PolivaikaTriggerDetected  triggerDetected;
        [SerializeField] private GameObject plantPrefab;
        [SerializeField] private int price = 50;
        
        private Button _button;
        private Wallet _wallet;
        
        private void Start()
        {
            _wallet =  FindObjectOfType<Wallet>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ClickButton);
        }
        
        private void ClickButton()
        {
            if (triggerDetected == null)
            {
                Debug.LogWarning("Trigger is not assigned.");
                return;
            }
        
            Transform parent = triggerDetected.transform;
            
            if (parent.childCount < 3)
            {
                Debug.LogWarning("Expected 3 child positions inside PolivaikaTriggerDetected.");
                return;
            }
            
            Transform[] spawnPoints = new Transform[3];
            for (int i = 0; i < 3; i++)
            {
                spawnPoints[i] = parent.GetChild(i);
            }
            
            System.Random rng = new System.Random();
            int[] indices = { 0, 1, 2 };
            for (int i = indices.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (indices[i], indices[j]) = (indices[j], indices[i]);
            }
            
            foreach (int i in indices)
            {
                Transform point = spawnPoints[i];
                if (point.childCount == 0)
                {
                    if (_wallet.Coin >= price)
                    { 
                        _wallet.SpendCoin(price);
                        GameObject plant = Instantiate(plantPrefab, point.position, Quaternion.identity);
                        plant.transform.SetParent(point);
                        triggerDetected.plants.Add(plant.GetComponent<Plant>());
                        return;  
                    }
                    
                    else
                    {
                        Debug.LogWarning("Not enough coins.");
                    }
                    
                }
            }
            
            Debug.LogWarning("All spawn points are occupied.");
        }

    }
}
