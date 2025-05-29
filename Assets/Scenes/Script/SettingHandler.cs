using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingHandler : MonoBehaviour
{
    [SerializeField] private GameObject SettingTab;
    [SerializeField] private Slider VolumeSlider;
    public static SettingHandler instance;
    private void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
       
        Showtab(false);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Showtab(bool status)
    {
        SettingTab.SetActive(status);
    }
    private void Update()
    {
        AudioManager.instance.MusicVolume(VolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", VolumeSlider.value);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SettingTab.activeSelf)
            {
                Showtab(false);
            }
            else
            {
                Showtab(true);
            }
        }
    }
}
