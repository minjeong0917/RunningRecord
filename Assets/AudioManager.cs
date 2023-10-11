using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //inspector 창에 노출 할 수 있음
public class Sound
{
    public string name;
    public AudioClip clip;
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // 언제 어디서든 호출 할 수 있도록 자기자신을 instace로 만듦..?

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

    void Start()
    {
        instance = this;
    }


    public void PlayBGM(string p_bgmName) // 배경음 재생
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            if (p_bgmName == bgm[i].name) // 들어온 p_bgmName과 Sound클래스에 있는 name 값이 일치한지 비교 
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM() // 배경음 정지
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string p_sfxName) // 효과음 재생
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (p_sfxName == sfx[i].name) // 들어온 p_sfxName과 Sound클래스에 있는 name 값이 일치한지 비교 
            {
                for(int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying) // 재생중이지 않은 효과음들 중에서
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("모든 오디오 플레이어가 재생중입니다.");
                return;
            }
        }
         Debug.Log(p_sfxName + "이름의 효과음이 없습니다.");
    }
}

