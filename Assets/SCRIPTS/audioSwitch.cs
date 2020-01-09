using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audioSwitch : MonoBehaviour {


	bool isMute;
	public GameObject audioButton;
	private Button audioBtn;
	public Sprite audioMute;
	private Sprite audioOn;

	// Use this for initialization
	void Start () {
		audioBtn = audioButton.GetComponent<Button> ();
		audioOn = audioBtn.image.sprite;

		if (AudioListener.volume == 0) {

			isMute = true;
			audioBtn.image.sprite = audioMute;
		} else {
			isMute = false;
		}

		print (AudioListener.volume);

	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void muteAudio(){
		if (isMute == false) {
			isMute = true;
			AudioListener.volume = 0;
			audioBtn.image.sprite = audioMute;

		} else {
			isMute= false;
			AudioListener.volume = 1;
			audioBtn.image.sprite = audioOn;
			AudioListener.pause = false;
		}
	}



}
