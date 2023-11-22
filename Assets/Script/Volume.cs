using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    // ���� ���� �� ȣ��Ǵ� �޼���
    void Start()
    {
        // ����� ���� ���� �ִ��� Ȯ���ϰ�, ������ �⺻ �� ����
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", 0.7f);
        }

        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 0.7f);
        }

        // ����� ���� ���� �����̴��� ����
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        // ���� ���� �޼��� ���
        bgmSlider.onValueChanged.AddListener(BGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(SFXVolumeChanged);
    }

    // BGM ���� ���� �� ȣ��Ǵ� �޼���
    void BGMVolumeChanged(float value)
    {
        // ���� ���� PlayerPrefs�� ����
        PlayerPrefs.SetFloat("BGMVolume", value);
        // AudioManager�� BGMVolume �޼��� ȣ��
        AudioManager.instance.BGMVolume(value);
    }

    // SFX ���� ���� �� ȣ��Ǵ� �޼���
    void SFXVolumeChanged(float value)
    {
        // ���� ���� PlayerPrefs�� ����
        PlayerPrefs.SetFloat("SFXVolume", value);
        // AudioManager�� SFXVolume �޼��� ȣ��
        AudioManager.instance.SFXVolume(value);
    }
}