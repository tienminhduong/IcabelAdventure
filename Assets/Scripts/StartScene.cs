using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartButtonClick()
    {
        if (PlayerPrefs.HasKey(ConstValue.PLAYED_TUTORIAL))
        {
            SceneManager.LoadSceneAsync(ConstValue.PLAY_SCENE);
        }
        else
        {
            PlayerPrefs.SetInt(ConstValue.PLAYED_TUTORIAL, 1);
            SceneManager.LoadSceneAsync(ConstValue.TUTORIAL_SCENE);
        }
        
    }
}
