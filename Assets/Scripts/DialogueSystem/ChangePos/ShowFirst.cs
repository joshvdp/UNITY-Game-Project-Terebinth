using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Manager;

namespace DialogueSystem
{
    public enum UIPlatform
    {
        PC,
        Mobile
    }
    public class ShowFirst : MonoBehaviour
    {
        public UIPlatform PlatformType;

        public float ShowDelay;
        int index;
        public GameObject inventoryBtn, inventoryBtnTutorial, analog, analogTutorial, quest, kill;
        private bool hasBeenCalled = false;
        private void Update()
        {
            if (!hasBeenCalled && !SceneLoader.Instance.IsLoadingScreenPresent)
            {
                StartCoroutine(show());
            }
            
        }

        IEnumerator show()
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            if (activeSceneName == "Tutorial Scene")
            {
                inventoryBtn.SetActive(false);
                analog.SetActive(false);
                quest.SetActive(false);
                kill.SetActive(false);
                yield return new WaitForSeconds(ShowDelay);
                
                switch (PlatformType)
                {
                    case UIPlatform.PC:
                        index = 17;
                        DialogueHandler.Instance.EnableDialogue(index);
                        break;
                    case UIPlatform.Mobile:
                        index = 2;
                        DialogueHandler.Instance.EnableDialogue(index);
                        break;
                }
            }
            else
            {
                analogTutorial.SetActive(false);
                inventoryBtn.SetActive(true);
                inventoryBtnTutorial.SetActive(false);
            }

            hasBeenCalled = true;
        }
    }
}


