using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MENGO_TOUR.MAIN 
{
    public class PanelCtrl : MonoBehaviour
    {
        private void Start()
        {
            Invoke(nameof(Init), .1f);
        }

        public void Init()
        {
            RectTransform rect = GetComponent<RectTransform>();
            rect.DOLocalMoveX(0, 1f)
                .SetEase(Ease.OutElastic);
        }
    }
}


