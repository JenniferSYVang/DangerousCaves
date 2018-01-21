using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    private string scene;
    [SerializeField]
    private Canvas myCanvas;

    private void Start()
    {
        myCanvas.enabled = true;
        if (myCanvas.name == "TryAgainCanvas" || myCanvas.name == "CanvasD")
        {
            // GameObject.Find("CanvasD").GetComponent<Canvas>().enabled = false;
            Cursor.visible = true; ;
        }
        Cursor.visible = false;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
    public void StartNewScene(string sceneName)
    {
        // SceneManager.LoadScene(sceneName);
        
        
        scene = sceneName;
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
