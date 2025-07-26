using UnityEngine;

namespace BaseScripts
{
    public class PlantClicker : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask layer;

        private void Start()
        {
            if (mainCamera == null)
                mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer))
                {
                    Plant plant = hit.collider.GetComponentInParent<Plant>();

                    if (plant != null)
                    {
                        plant.Harvest();
                    }
                }
            }
        }
    }
}