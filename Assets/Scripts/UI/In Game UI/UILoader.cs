using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class UILoader : MonoBehaviour
    {
        public void Start()
        {
            if (IsUIAlreadyAdded()) return;
            loadUI();
        }
        public void loadUI()
        {

            SceneManager.LoadScene("InGameUI", LoadSceneMode.Additive);
        }
        bool IsUIAlreadyAdded()
        {
            if (SceneManager.GetSceneByName("InGameUI").isLoaded) return true;
            else return false;
        }
        public void UnloadThisScene() => SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }
}
