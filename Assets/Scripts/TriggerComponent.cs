using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ovinnikova_AS_3_1
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField, Tooltip("Компонент GameManager, не удалять!")]
        private GameManager GameManager;

        [SerializeField, Tooltip("Компонент PlayerOneController для контроля за шаром, не удалять!")]
        private PlayerOneController PlayerOneController;


        private float BallOriginalSpeed;

        private void Awake()
        {
            BallOriginalSpeed = GameManager.BallSpeedModifier;
        }
            // Start is called before the first frame update
            void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            GameManager.Health--;
            PlayerOneController.SetPlayerOneHasBallTrue();
            GameObject.Find("Ball").transform.position = GameManager.BallStartPosition; // Перемещаем шарик на изначальную позицию к 1-му игроку
            GameObject.Find("Ball").transform.forward = new Vector3(0f, -1f, 0f);
            GameManager.BallSpeedModifier = BallOriginalSpeed;
        }
    }
}
