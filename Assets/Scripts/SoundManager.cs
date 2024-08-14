using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("����ւ���BGM")] [SerializeField] AudioClip changeBGM;
    [Header("����ւ���BGM����")] [SerializeField] float changeBGMVolume;
    [Header("�t�F�[�h���鎞��")] [SerializeField] float fadeTime=3f;

    AudioSource audioSource;
    float bgmVolume = 0;
    float fadeDeltaTime = 0, FadeDeltaTimeReset = 0;
    float volumeMin = 0;
    bool isFadeIn = false, isFadeOut = false;
    bool changeBGMStart = false;

    // Start is called before the first frame update
    void Start()
    {
        //�I�[�f�B�I�\�[�X���擾
        audioSource = GetComponent<AudioSource>();
        //���݂̉��ʂ��擾
        bgmVolume = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        //BGM����ւ��t���O��false
        if (!changeBGMStart)
        {
            if (audioSource==null || changeBGM == null)
            {
                //�����𒆒f
                return;
            }
        }

        if (isFadeOut)
        {
            fadeDeltaTime += Time.deltaTime;
            if (fadeDeltaTime>=fadeTime)
            {
                fadeDeltaTime = fadeTime;
                isFadeOut = false;
            }
            audioSource.volume = bgmVolume - (fadeDeltaTime / fadeTime);
            if(audioSource.volume<=volumeMin)
            {
                audioSource.volume = volumeMin;
                isFadeOut = false;
                isFadeIn = true;
                fadeDeltaTime = FadeDeltaTimeReset;
            }
        }

        if (isFadeIn)
        {
            fadeDeltaTime += Time.deltaTime;
            audioSource.clip = changeBGM;
            audioSource.Play();

            if (fadeDeltaTime >= fadeTime)
            {
                fadeDeltaTime = fadeTime;
                isFadeIn = false;
            }

            audioSource.volume = (fadeDeltaTime / fadeTime);
            if (audioSource.volume >= changeBGMVolume)
            {
                audioSource.volume = changeBGMVolume;
                isFadeIn = false;
                fadeDeltaTime = FadeDeltaTimeReset;
                changeBGMStart = false;
            }
        }

    }
    public void ChangeBGMStart()
    {
        changeBGMStart = true;
        isFadeOut = true;
    }

    public void BGMStop()
    {
        audioSource.Stop();
    }
}
