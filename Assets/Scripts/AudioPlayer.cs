using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioClip1; // 第一段音频剪辑
    public AudioClip audioClip2; // 第二段音频剪辑
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 播放第一段音频
        PlayAudioClip(audioClip1);
    }

    void Update()
    {
        // 检查当前播放的音频是否为第一段音频且已经播放完毕，如果是，则切换到播放第二段音频
        if (!audioSource.isPlaying && audioSource.clip == audioClip1)
        {
            PlayAudioClip(audioClip2);
        }
    }

    void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
