using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ovinnikova_AS_3_1
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField, Tooltip("Скорость платформы первого игрока"), Range(0.01f, 0.9f)]
        public float FirstPlayerSpeed = 0.01f;

        [SerializeField, Tooltip("Скорость платформы второго игрока"), Range(0.01f, 0.9f)]
        public float SecondPlayerSpeed = 0.01f;

        [SerializeField, Tooltip("Скорость шарика во время нахождения у первого игрока"), Range(1f, 5f)]
        public float PlayerOneBallSpeed = 1f;

        [SerializeField, Tooltip("Скорость шарика"), Range(1f, 100f)]
        public float BallSpeedModifier = 1f;


        [SerializeField, Tooltip("Здоровье игроков"), Range(1, 100)]
        public int Health = 1;

        [SerializeField, Tooltip("Начальная позиция шарика")]
        public Vector3 BallStartPosition = new Vector3(0f, 10.5f, 4.5f);

        [SerializeField, Tooltip("Пул кубиков, не удалять!")]
        private List<GameObject> Cubes;


        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < Cubes.Count; i++)
            {
                Cubes[i].transform.rotation = Random.rotation;
            }

            
        }

        // Update is called once per frame
        void Update()
        {
            if (Health <= 0)
            {
                Debug.Log("YOU LOSE");
                UnityEditor.EditorApplication.isPaused = true;
            }


        }


        public void DestroyCube(string CubeName)
        {
            for (int i = 0; i < Cubes.Count; i++)
                {
                    if (Cubes[i].name.Equals(CubeName))
                        {
                            Destroy(Cubes[i]);
                            Cubes.RemoveAt(i);
                        }
                }
        }
    }
}
