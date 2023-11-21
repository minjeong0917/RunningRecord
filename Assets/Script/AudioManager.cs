using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //inspector ???? ???? ?? ?? ????
public class Sound
{
    public string name;
    public AudioClip clip;
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

    private bool isBGMPaused = false;

    void Awake()
    {
        instance = this;
    }

    public void PlayBGM(string p_bgmName) // ?????? ????
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            if (p_bgmName == bgm[i].name) // ?????? p_bgmName?? Sound???????? ???? name ???? ???????? ???? 
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }

        }
    }

    public void StopBGM() // ?????? ????
    {
        bgmPlayer.Stop();
    }

    public void PauseBGM()
    {
        if (bgmPlayer.isPlaying)
        {
            bgmPlayer.Pause();
            isBGMPaused = true;
        }
    }

    public void ResumeBGM()
    {
        if (isBGMPaused)
        {
            bgmPlayer.UnPause();
            isBGMPaused = false;
        }
    }

    public void PlaySFX(string p_sfxName) // ?????? ????
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name) // ?????? p_sfxName?? Sound???????? ???? name ???? ???????? ???? 
            {
                for(int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying) // ?????????? ???? ???????? ??????
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("???? ?????? ?????????? ????????????.");
                return;
            }
        }
         Debug.Log(p_sfxName + "?????? ???????? ????????.");
    }

    public void StopSFX(string p_sfxName)
    {
        for (int i = 0; i < sfxPlayer.Length; i++)
        {
            if (sfxPlayer[i].clip != null && sfxPlayer[i].clip.name == p_sfxName)
            {
                sfxPlayer[i].Stop();
                sfxPlayer[i].clip = null; // 사운드 초기화
            }
        }
    }

    public void BGMVolume(float volume)
    {
        bgmPlayer.volume = volume;
    }


    public void SFXVolume(float volume)
    {
        for (int i = 0; i < sfxPlayer.Length; i++)
        {
            sfxPlayer[i].volume = volume;
        }
    }
}

