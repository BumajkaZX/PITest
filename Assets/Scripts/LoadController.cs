using UnityEngine.SceneManagement;

public static class LoadController 
{
    public static void ChangeScene(int scene)
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
}
