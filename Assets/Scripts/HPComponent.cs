using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ovinnikova_AS_3_1
{
    
    public class HPComponent : MonoBehaviour
    {
        [SerializeField]
        private GameManager GameManager;

        [SerializeField]
        private TextMeshProUGUI _text;

        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            if (_text.text != GameManager.Health.ToString())
            {
                _text.text = GameManager.Health.ToString();
            }
        }
    }
}
