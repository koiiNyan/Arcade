using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Ovinnikova_AS_3_1
{


    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private Button resumeGameButton;

        [SerializeField]
        private Button restartGameButton;

        [SerializeField]
        private Button settingsButton;

        [SerializeField]
        private Button exitButton;

        [SerializeField]
        private GameObject SettingsPanel;




        private void OnResumePanel_EditorEvent()
        {
            gameObject.SetActive(false);
            var _backgr = FindObjectOfType<PlayerOneController>().GetBackgroundImage();
            _backgr.SetActive(false);
            FindObjectOfType<PlayerOneController>().isMenuActive = false;
            Time.timeScale = 1;
        }



        private void OnRestartPanel_EditorEvent()
        {
            SceneManager.LoadSceneAsync(1);
            Time.timeScale = 1;
        }


        private void OnSettingsPanel_EditorEvent()
        {
            /*var _settings = FindObjectOfType<PlayerOneController>().GetSettingsPanel();
            _settings.SetActive(true);
            gameObject.SetActive(false);*/

            StartCoroutine(AnimateMenuClose());


        }


        private void OnExitPanel_EditorEvent()
        {
            EditorApplication.isPlaying = false;
        }


        public IEnumerator AnimateMenuClose()
        {
            
            this.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            yield return new WaitForSecondsRealtime(0.2f);
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSecondsRealtime(0.2f);
            this.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSecondsRealtime(0.2f);
            this.gameObject.transform.localScale = new Vector3(0, 0, 0f);
            yield return new WaitForSecondsRealtime(0.2f);

            StartCoroutine(AnimateSettingsOpen(SettingsPanel));

        }




        public IEnumerator AnimateSettingsOpen(GameObject SettingsPanel)
        {
            SettingsPanel.SetActive(true);
            SettingsPanel.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSecondsRealtime(0.2f);
            SettingsPanel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSecondsRealtime(0.2f);
            SettingsPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSecondsRealtime(0.2f);
            SettingsPanel.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            yield return new WaitForSecondsRealtime(0.2f);
            gameObject.SetActive(false);


        }

    }
}
