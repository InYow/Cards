using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioClip1; // ��һ����Ƶ����
    public AudioClip audioClip2; // �ڶ�����Ƶ����
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // ���ŵ�һ����Ƶ
        PlayAudioClip(audioClip1);
    }

    void Update()
    {
        // ��鵱ǰ���ŵ���Ƶ�Ƿ�Ϊ��һ����Ƶ���Ѿ�������ϣ�����ǣ����л������ŵڶ�����Ƶ
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
