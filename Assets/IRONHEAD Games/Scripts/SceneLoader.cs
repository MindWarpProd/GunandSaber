using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public Canvas loadingCanvas;
    public static SceneLoader instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(ShowOverlayAndLoad(sceneName));
    }

    IEnumerator ShowOverlayAndLoad(string sceneName)
    {
        if (loadingCanvas != null)
        {
            loadingCanvas.gameObject.SetActive(true);
        }
       
        //Waiting for seconds to prevent "pop" to new scene
        yield return new WaitForSeconds(3f);

        //Load Scene and wait until complete
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        if (loadingCanvas != null)
        {
            loadingCanvas.gameObject.SetActive(false);
        }
        yield return null;

    }
}
