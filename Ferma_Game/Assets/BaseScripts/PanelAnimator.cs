using UnityEngine;
using DG.Tweening;

namespace BaseScripts
{
    public class PanelAnimator : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject slot_1;
        [SerializeField] private GameObject slot_2;

        [SerializeField] private float animationDuration = 0.4f;

        private Vector3 _initialScalePanel;
        private Vector3 _initialScaleSlot1;
        private Vector3 _initialScaleSlot2;

        private void Awake()
        {
            _initialScalePanel = panel.transform.localScale;
            _initialScaleSlot1 = slot_1.transform.localScale;
            _initialScaleSlot2 = slot_2.transform.localScale;
            
            panel.transform.localScale = Vector3.zero;
            slot_1.transform.localScale = Vector3.zero;
            slot_2.transform.localScale = Vector3.zero;
            panel.transform.localScale = Vector3.zero;
        }

        public void TogglePanel(bool show)
        {
            if (show)
            {
                panel.SetActive(true);
                
                panel.transform.localScale = Vector3.zero;
                slot_1.transform.localScale = Vector3.zero;
                slot_2.transform.localScale = Vector3.zero;
                
                panel.transform.DOScale(_initialScalePanel, animationDuration)
                    .SetEase(Ease.OutBack);
                
                slot_1.transform.DOScale(_initialScaleSlot1, animationDuration)
                    .SetEase(Ease.OutBack).SetDelay(0.05f);

                slot_2.transform.DOScale(_initialScaleSlot2, animationDuration)
                    .SetEase(Ease.OutBack).SetDelay(0.1f);
            }
            else
            {
                panel.transform.DOScale(Vector3.zero, animationDuration)
                    .SetEase(Ease.InBack)
                    .OnComplete(() => panel.SetActive(false));

                slot_1.transform.DOScale(Vector3.zero, animationDuration)
                    .SetEase(Ease.InBack);

                slot_2.transform.DOScale(Vector3.zero, animationDuration)
                    .SetEase(Ease.InBack);
            }
        }
    }
}
