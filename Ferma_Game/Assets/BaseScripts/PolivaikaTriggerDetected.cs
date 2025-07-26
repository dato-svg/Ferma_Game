using System.Collections.Generic;
using UnityEngine;

namespace BaseScripts
{
    public class PolivaikaTriggerDetected : MonoBehaviour
    {
        public List<Plant> plants;

        private int _triggerEnterCount = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Polivaika>() != null)
            {
                _triggerEnterCount++;
                
                if (_triggerEnterCount % 2 == 0)
                {
                    foreach (var plant in plants)
                    {
                        plant.plantLiveIndex = Mathf.Min(plant.plantLiveIndex + 1, 4);
                    }

                    Debug.Log("Каждое третье попадание: растения выросли на 1 уровень.");
                }
                else
                {
                    Debug.Log($"Вход №{_triggerEnterCount}, пока без роста.");
                }
            }
        }
    }
}