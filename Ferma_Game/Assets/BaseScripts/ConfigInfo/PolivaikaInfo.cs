using UnityEngine;

namespace BaseScripts.ConfigInfo
{
    [CreateAssetMenu(fileName = "PolivaikaInfo", menuName = "PolivaikaInfo")]
    public class PolivaikaInfo : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}