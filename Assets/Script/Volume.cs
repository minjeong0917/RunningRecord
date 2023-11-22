using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    // 게임 시작 시 호출되는 메서드
    void Start()
    {
        // 저장된 볼륨 값이 있는지 확인하고, 없으면 기본 값 설정
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", 0.7f);
        }

        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 0.7f);
        }

        // 저장된 볼륨 값을 슬라이더에 설정
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        // 볼륨 조절 메서드 등록
        bgmSlider.onValueChanged.AddListener(BGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(SFXVolumeChanged);
    }

    // BGM 볼륨 변경 시 호출되는 메서드
    void BGMVolumeChanged(float value)
    {
        // 볼륨 값을 PlayerPrefs에 저장
        PlayerPrefs.SetFloat("BGMVolume", value);
        // AudioManager의 BGMVolume 메서드 호출
        AudioManager.instance.BGMVolume(value);
    }

    // SFX 볼륨 변경 시 호출되는 메서드
    void SFXVolumeChanged(float value)
    {
        // 볼륨 값을 PlayerPrefs에 저장
        PlayerPrefs.SetFloat("SFXVolume", value);
        // AudioManager의 SFXVolume 메서드 호출
        AudioManager.instance.SFXVolume(value);
    }
}