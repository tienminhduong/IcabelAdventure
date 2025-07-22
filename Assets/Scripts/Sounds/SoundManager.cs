using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip backgroundMusic;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Play background music on start
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or Background Music is not assigned in the SoundManager.");
        }
    }
}
