using BaseScripts.ConfigInfo;
using UnityEngine;

namespace BaseScripts
{
    public class PolivaikaMover : MonoBehaviour
    {
        [SerializeField] private PolivaikaInfo polivaikaInfo;
        [SerializeField] private Vector3 offset;
        
        private void Update() => 
            transform.Rotate(offset, polivaikaInfo.Speed * Time.deltaTime);
    }
}
