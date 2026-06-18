using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void LoaderByName(string scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log($"сцена {scene} загружена");
    }
    public void LoaderByNumber(int scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log($"сцена {scene} загружена");
    }
}
