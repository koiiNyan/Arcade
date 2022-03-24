using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ovinnikova_AS_3_1
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerOneController : MonoBehaviour
    {
        [SerializeField, Tooltip("Компонент GameManager, не удалять!")]
        private GameManager GameManager;

        private bool PlayerOneHasBall = true;

        public void SetPlayerOneHasBallTrue() => PlayerOneHasBall = true;


        private Coroutine BallInitialMovementCourutine;

        public Coroutine GetBallInitialMovementCourutine() => BallInitialMovementCourutine;

        [SerializeField]
        private GameObject MenuPanel;

        [SerializeField]
        private GameObject SettingsPanel;

        [SerializeField]
        private GameObject BackgroundImage;

        public GameObject GetBackgroundImage() => BackgroundImage;

        public GameObject GetMenuPanelPanel() => MenuPanel;

        public GameObject GetSettingsPanel() => SettingsPanel;

        public bool isMenuActive = false;

        private void Awake()
        {
            MenuPanel.SetActive(false);
            SettingsPanel.SetActive(false);
            BackgroundImage.SetActive(false);
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Движение игрока
            if (Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                MoveCharacter(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), GameManager.FirstPlayerSpeed);

                // Двигаем шар, если он находится у первого игрока, вместе с игроком
                if (PlayerOneHasBall)
                {
                    StartCoroutine(MoveBallCharacter(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

                }
            }

            // Если нажимаем Space, когда мяч у игрока - мяч летит вперед
            if (Input.GetKey(KeyCode.Space) && PlayerOneHasBall)
            {
                PlayerOneHasBall = false;
                BallInitialMovementCourutine = StartCoroutine(MoveBallForward(new Vector3(0f, 0f, 0f)));
            }

            if (!PlayerOneHasBall)
            {
                GameManager.BallSpeedModifier += 0.001f;
            }

            if (!isMenuActive && Input.GetKey(KeyCode.Escape) )
            {
                ShowPauseMenu ();
            }
        }


        private void MoveCharacter(float x, float z, float _speed)
        {
            //transform.position += new Vector3(x, 0, z) * Time.deltaTime * 5;
            var _rb = this.gameObject.GetComponent<Rigidbody>();
            _rb.AddForce(x * _speed, 0f, z* _speed, ForceMode.Impulse);
        }


        
        private IEnumerator MoveBallCharacter(float x, float z)
        {
              
            yield return GameObject.Find("Ball").transform.position += new Vector3(x, 0, z) * Time.deltaTime * GameManager.PlayerOneBallSpeed;

        }

        public IEnumerator MoveBallForward(Vector3 direction)
        {
            
            if (direction == new Vector3(0f, 0f, 0f)) direction = GameObject.Find("Ball").transform.forward;
            
            while (!PlayerOneHasBall)
            {
           

                yield return GameObject.Find("Ball").transform.position += direction * GameManager.BallSpeedModifier * Time.deltaTime;
            }

        }


        private void ShowPauseMenu()
        {
            MenuPanel.SetActive(true);
            BackgroundImage.SetActive(true);
            isMenuActive = true;
            Time.timeScale = 0;
        }
    }
}
