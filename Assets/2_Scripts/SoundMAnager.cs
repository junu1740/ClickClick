using UnityEngine;

public class SoundMAnager : MonoBehaviour
{
    public static SoundMAnager Instance;
    public AudioClip[] audioClips;

    private AudioSource[] audioSources;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSources = new AudioSource[audioClips.Length];


        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = audioClips[i];
        }
    }


    public void Sound(int index)
    {
        audioSources[index].Play();
    }
}
