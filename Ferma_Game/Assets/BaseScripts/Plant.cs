using System.Collections.Generic;
using UnityEngine;

namespace BaseScripts
{
    public class Plant : MonoBehaviour
    {
        [Range(1, 4)] public int plantLiveIndex = 1;

        private List<GameObject> _levels = new List<GameObject>();
        private Wallet _wallet;
        private bool _isFullyGrown => plantLiveIndex == 4;

        [SerializeField] private int reward = 70;

        private void Start()
        {
            _wallet = FindObjectOfType<Wallet>();
            
            for (int i = 0; i < transform.childCount; i++)
            {
                var level = transform.GetChild(i).gameObject;
                _levels.Add(level);
            }
            
            if (_levels.Count == 0)
            {
                Debug.LogWarning($"У растения {gameObject.name} нет дочерних уровней.");
                return;
            }
            
            SetLevel(plantLiveIndex);
        }
        
        private void Update()
        {
            SetLevel(plantLiveIndex);
        }
        
        private void SetLevel(int index)
        {
            int levelIndex = Mathf.Clamp(index - 1, 0, _levels.Count - 1);

            for (int i = 0; i < _levels.Count; i++)
            {
                _levels[i].SetActive(i == levelIndex);
            }

            if (index >= 4)
            {
                plantLiveIndex = 4;
                Debug.Log($" Растение {gameObject.name} завершило рост.");
            }
        }

        
        public void Harvest()
        {
            if (!_isFullyGrown)
                return;

            if (_wallet != null)
                _wallet.AddCoin(reward);
            
            gameObject.SetActive(false);
            Destroy(gameObject, 0.05f);
        }

    }
}
