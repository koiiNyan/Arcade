using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ovinnikova_AS_3_1
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTwoController : MonoBehaviour
    {

        [SerializeField, Tooltip("Компонент GameManager, не удалять!")]
        private GameManager GameManager;

        // Start is called before the first frame update

        private void Awake()
        {

        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                MoveCharacter(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), GameManager.SecondPlayerSpeed);
            }
        }

        // Корутина движения
        /*private IEnumerator MoveCharacter(float x, float z)
        {
            //yield return transform.position += new Vector3(x, 0, z) * Time.deltaTime * 5;
            var _rb = this.gameObject.GetComponent<Rigidbody>();
            yield return _rb.AddForce(transform.forward * x, ForceMode.Impulse);
        }*/

        private void MoveCharacter(float x, float z, float _speed)
        {
            //transform.position += new Vector3(x, 0, z) * Time.deltaTime * 5;
            var _rb = this.gameObject.GetComponent<Rigidbody>();
            _rb.AddForce(x * (_speed * -1), 0f, z * _speed, ForceMode.Impulse);
        }
    }
}
