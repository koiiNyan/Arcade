using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Ovinnikova_AS_3_1
{


    public class SettingsMenu : MonoBehaviour
    {

        [SerializeField]
        private Button backButton;

        [SerializeField]
        private GameObject MenuPanel;



        private void OnBack_EditorEvent()
        {
            MenuPanel.SetActive(true);
            StartCoroutine(AnimateSettingsClose());
            //gameObject.SetActive(false); 
        }


        private void SetVolume_EditorEvent()
        {
            Debug.Log("Setting Volume...");
        }

        private void MuteSound_EditorEvent()
        {
            Debug.Log("Mute Sound");
        }

        private void EasyDifficultyToggle_EditorEvent()
        {
            Debug.Log("Easy Difficulty Checked");
        }

        private void MediumDifficultyToggle_EditorEvent()
        {
            Debug.Log("Medium Difficulty Checked");
        }

        private void HardDifficultyToggle_EditorEvent()
        {
            Debug.Log("Hard Difficulty Checked");
        }


        public IEnumerator AnimateSettingsClose()
        {

            this.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            yield return new WaitForSecondsRealtime(0.2f);
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSecondsRealtime(0.2f);
            this.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSecondsRealtime(0.2f);
            this.gameObject.transform.localScale = new Vector3(0, 0, 0f);
            yield return new WaitForSecondsRealtime(0.2f);

            StartCoroutine(AnimateMenuOpen(MenuPanel));

        }



        public IEnumerator AnimateMenuOpen(GameObject MenuPanel)
        {

            MenuPanel.SetActive(true);
            MenuPanel.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSecondsRealtime(0.2f);
            MenuPanel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSecondsRealtime(0.2f);
            MenuPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSecondsRealtime(0.2f);
            MenuPanel.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            yield return new WaitForSecondsRealtime(0.2f);
            gameObject.SetActive(false);



        }
    }
}
