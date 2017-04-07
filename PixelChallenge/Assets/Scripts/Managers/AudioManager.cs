using UnityEngine;
using System.Collections;

[System.Serializable]
public class Sound
{
	public string name;
	public AudioClip audioClip;
	public AudioSource audioSource;
	[Range(0f, 1f)]
	public float volume = 1f;
	[Range(0f, 2f)]
	public float pitch = 1f;

	[Range(0f, 0.5f)]
	public float randomVolume = 0.0f;
	[Range(0f, 0.5f)]
	public float randomPitch = 0.0f;

	public void SetSource(AudioSource source)
	{
		audioSource = source;
		audioSource.clip = audioClip;
	}

	public void Play(float audioManagerVolume = 1f){
		audioSource.volume = volume*audioManagerVolume + (1*Random.Range(-randomVolume/2f, randomVolume/2f));
		audioSource.pitch = pitch + (1*Random.Range(-randomPitch/2f, randomPitch/2f));
		audioSource.Play ();
	}
}


public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	[Range(0f, 1f)]
	public float volume = 1f;

	[SerializeField]
	public Sound[] sounds;

	void Awake()
	{
		if (instance != null) {
			Debug.LogWarning ("AudioManager : More than one defined");
		} else
			instance = this;
	}
	// Use this for initialization
	void Start () {
		Sound currentSound;
		for (int i = 0; i < sounds.Length; i++) {
			currentSound = sounds [i];
			GameObject currentGameObject = new GameObject ("Sound_"+i+"_"+name);
			currentGameObject.transform.SetParent (transform);
			currentSound.SetSource (currentGameObject.AddComponent<AudioSource> ());
		}
	}


	public void PlaySound (string name) {
		Sound currentSound;
		for (int i = 0; i < sounds.Length; i++) {
			currentSound = sounds [i];
			if (currentSound.name == name) {
				currentSound.Play (volume);
				return;
			}
		}
		Debug.LogWarning ("AudioManager : Sound not found : " + name);
	}
		
	public void Mute (bool mute) {
		volume = mute ? 0f : 1f;
	}
}
