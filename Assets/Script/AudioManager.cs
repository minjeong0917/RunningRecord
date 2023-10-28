using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //inspector â�� ���� �� �� ����
public class Sound
{
    public string name;
    public AudioClip clip;
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // ���� ��𼭵� ȣ�� �� �� �ֵ��� �ڱ��ڽ��� instace�� ����..?

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

    void Start()
    {
        instance = this;
    }


    public void PlayBGM(string p_bgmName) // ����� ���
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            if (p_bgmName == bgm[i].name) // ���� p_bgmName�� SoundŬ������ �ִ� name ���� ��ġ���� �� 
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM() // ����� ����
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string p_sfxName) // ȿ���� ���
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (p_sfxName == sfx[i].name) // ���� p_sfxName�� SoundŬ������ �ִ� name ���� ��ġ���� �� 
            {
                for(int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying) // ��������� ���� ȿ������ �߿���
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("��� ����� �÷��̾ ������Դϴ�.");
                return;
            }
        }
         Debug.Log(p_sfxName + "�̸��� ȿ������ �����ϴ�.");
    }
}

