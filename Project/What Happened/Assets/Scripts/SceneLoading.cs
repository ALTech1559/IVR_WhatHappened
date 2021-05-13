using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    internal static bool statement = false;
    private Animator animator;
    private static SceneLoading sceneLoading;
    private AsyncOperation asyncLoadingScene;
    [SerializeField] private static bool openScene = true;
    [SerializeField] private float animationLength;
    
    private void Start() 
    {
        //initialize components
        animator = GetComponent<Animator>();
        sceneLoading = this;
        if (openScene)
        {
            sceneLoading.animator.SetTrigger("sceneOpening");
        }

    }

    internal static void ChangeScene(string sceneName)
    {
        if (!statement) 
        {
            //start new scene loading
            sceneLoading.animator.SetTrigger("sceneClosing");
            sceneLoading.asyncLoadingScene = SceneManager.LoadSceneAsync(sceneName);
            sceneLoading.asyncLoadingScene.allowSceneActivation = false;
            sceneLoading.Invoke("OnAniamtionOver", sceneLoading.animationLength);
            statement = true;
        }
    }

    private void OnAniamtionOver() 
    {
        //change flag
        statement = false;
        openScene = true;
        asyncLoadingScene.allowSceneActivation = true;
    }
}
