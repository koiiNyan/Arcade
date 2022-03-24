using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ovinnikova_AS_3_1
{
    public class BallController : MonoBehaviour
    {
        [SerializeField, Tooltip("Компонент PlayerOneController для контроля за шаром, не удалять!")]
        private PlayerOneController PlayerOneController;

        [SerializeField, Tooltip("Компонент GameManager, не удалять!")]
        private GameManager GameManager;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);
            if (collision.gameObject.name.Contains("Cube"))
            {
                GameManager.DestroyCube(collision.gameObject.name);
            }
            var direction = Vector3.Reflect(transform.forward, collision.GetContact(0).normal);
            transform.forward = direction;

            StopAllCoroutines();
            StartCoroutine(PlayerOneController.MoveBallForward(direction));
        }
    }
}