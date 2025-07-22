using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : SingletonObject<SFXManager>
{
    protected override bool IsDontDestroyOnLoad => true;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private AudioSource audioSource;

    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip eatClip;
    [SerializeField] private AudioClip punchClip;

    public void PlaySFX(SFXType type)
    {
        switch (type)
        {
            case SFXType.Jump:
                audioSource.PlayOneShot(jumpClip);
                break;
            case SFXType.Eat:
                audioSource.PlayOneShot(eatClip);
                break;
            case SFXType.Punch:
                audioSource.PlayOneShot(punchClip);
                break;
            default:
                Debug.LogWarning("SFX type not recognized: " + type);
                break;
        }
    }

    public enum SFXType
    {
        Jump,
        Eat,
        Punch
    }
}
