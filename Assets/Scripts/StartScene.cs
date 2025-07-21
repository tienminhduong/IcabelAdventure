using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadSceneAsync(ConstValue.PLAY_SCENE);
    }
}
