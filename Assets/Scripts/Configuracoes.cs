using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Configuracoes : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
	[SerializeField] private Slider volumeSlider;

	private void Start()
	{
		if(PlayerPrefs.HasKey("Volum" +
			"e"))
		{
			LoadVolume();
		}
		else
		{
			SetVolume();
		}
	}

	public void SetVolume()
	{
		float volume = volumeSlider.value;
		audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
		PlayerPrefs.SetFloat("Volume", volume);
	}

	private void LoadVolume()
	{
		volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
		SetVolume();
	}
}
