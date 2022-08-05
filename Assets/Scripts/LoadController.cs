using UnityEngine.SceneManagement;

public static class LoadController 
{
    /*
     * Load between scenes
     */
    public static void ChangeScene(int scene)
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
}
