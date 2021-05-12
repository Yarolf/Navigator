using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void LoadNavigatorUser()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNavigatorAdmin()
    {
        SceneManager.LoadScene(2);
    }
}
