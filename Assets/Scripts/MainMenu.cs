using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Ovinnikova_AS_3_1
{


    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button newGameButton;


        [SerializeField]
        private Button settingsButton;

        [SerializeField]
        private Button exitButton;

        [SerializeField]
        private GameObject SettingsPanel;

        [SerializeField]
        private TextMeshProUGUI _text;


        private void Awake()
        {
            SettingsPanel.SetActive(false);
            StartCoroutine(TextAnimationFirst());
        }


        private void OnNewPanel_EditorEvent()
        {
            SceneManager.LoadSceneAsync(1);
        }


        private void OnSettingsPanel_EditorEvent()
        {
            StartCoroutine(AnimateMenuClose());

        }


        private void OnExitPanel_EditorEvent()
        {
            EditorApplication.isPlaying = false;
        }


        private IEnumerator TextAnimationFirst()
        {

            _text.text = "<color=#F329E8><i>Cube Shooter</i></color>";
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(TextAnimationSecond());

        }

        private IEnumerator TextAnimationSecond()
        {

            _text.text = "<color=#FFFFFF><b>Cube Shooter</b></color>";
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(TextAnimationFirst());

        }

        public IEnumerator AnimateMenuClose()
        {

            this.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            yield return new WaitForSeconds(0.2f);
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.2f);
            this.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSeconds(0.2f);
            this.gameObject.transform.localScale = new Vector3(0, 0, 0f);
            yield return new WaitForSeconds(0.2f);

            StartCoroutine(AnimateSettingsOpen(SettingsPanel));

        }




        public IEnumerator AnimateSettingsOpen(GameObject SettingsPanel)
        {
            SettingsPanel.SetActive(true);
            SettingsPanel.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.2f);
            SettingsPanel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSeconds(0.2f);
            SettingsPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.2f);
            SettingsPanel.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            yield return new WaitForSeconds(0.2f);
            gameObject.SetActive(false);


        }


    }
}