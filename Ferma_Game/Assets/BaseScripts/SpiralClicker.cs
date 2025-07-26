using UnityEngine;
using UnityEngine.EventSystems;

namespace BaseScripts
{
    public class SpiralClicker : MonoBehaviour
    {
        [SerializeField] private SpawnPlantUI[] spawnPlantsUI;
        [SerializeField] private PanelAnimator panelUI;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask raycastMask;
        
        private void Start()
        { 
            spawnPlantsUI = FindObjectsOfType<SpawnPlantUI>();
            panelUI = GameObject.Find("Canvas").GetComponent<PanelAnimator>();

            if (mainCamera == null)
                mainCamera = Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                bool clickedInWorld = false;
                
                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, raycastMask))
                {
                    clickedInWorld = true;
                    
                    if (hit.transform == transform)
                    {
                        Debug.Log("Clicked on SpiralClicker via raycast.");
                        ChangeParent();
                    }
                    
                    panelUI.TogglePanel(true);
                }
                
                if (!clickedInWorld)
                {
                    panelUI.TogglePanel(false);
                }
            }
        }
        
        private void ChangeParent()
        {
            PolivaikaTriggerDetected trigger = GetComponent<PolivaikaTriggerDetected>();
            if (trigger == null)
            {
                Debug.LogWarning("PolivaikaTriggerDetected not found on SpiralClicker.");
                return;
            }
            
            foreach (SpawnPlantUI spawnPlant in spawnPlantsUI)
                spawnPlant.triggerDetected = trigger;
        }
    }
}
