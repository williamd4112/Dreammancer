using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;


public class DialogController : MonoBehaviour {

	[SerializeField] private string select_diolag;


	//private List<string> sentence = new List<string>();
	private string[] sentence;
	private Dictionary<string, int> speaker = new Dictionary<string, int>();
	private Dictionary<string, Sprite> speaker_photo = new Dictionary<string, Sprite>();

	private int x = 0;
	private GameObject m_dialog;
	private Image m_Photo;
	private Image m_image;
	private Text dialog_txt;
	private string cur_speaker;

	private bool m_StopFlag = false;
	// Use this for initialization

	void Awake(){
		m_dialog = GameObject.FindGameObjectWithTag ("Dialog");
		m_Photo = GameObject.FindGameObjectWithTag ("DialogPhoto").GetComponent<Image>();
		dialog_txt = m_dialog.GetComponentInChildren<Text>();
		dialog_txt.text = "";
		cur_speaker = "";
	}
	void Start () {
		//sentence.Clear ();
		readTextFile (select_diolag);
		setPhoto ();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_StopFlag) {
			Time.timeScale = 0;
		}

		if (Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && (m_image != null && m_image.enabled)) {
				//Debug.Log(x);
				//if(x >= sentence.Count){
				if (x >= sentence.Length) {
					dialog_txt.text = "";
					m_image.enabled = false;
					m_Photo.enabled = false;
					Time.timeScale = 1;
					Destroy (gameObject);
				} else {
					cur_speaker = getSpeaker (sentence [x - 1]);
					dialog_txt.text = sentence [x];
					Debug.Log ("s: " + cur_speaker);
					Debug.Log ("c: " + sentence [x]);
					
					m_Photo.sprite = speaker_photo [cur_speaker];
					x = x + 2;

				}
			}
		} else {
			if (Input.GetMouseButtonDown(0) && (m_image != null && m_image.enabled)) {
				//Debug.Log(x);
				//if(x >= sentence.Count){
				if (x >= sentence.Length) {
					dialog_txt.text = "";
					m_image.enabled = false;
					m_Photo.enabled = false;
					Time.timeScale = 1;
					Destroy (gameObject);
				} else {
					cur_speaker = getSpeaker (sentence [x - 1]);
					dialog_txt.text = sentence [x];
					Debug.Log ("s: " + cur_speaker);
					Debug.Log ("c: " + sentence [x]);
					Debug.Log ("asd: "+Time.timeScale.ToString());
					m_Photo.sprite = speaker_photo [cur_speaker];
					x = x + 2;

				}
			}
		}

	}
	
	void FixedUpdate(){
		
	}
	
	void readTextFile(string file_path)
	{

		TextAsset txt = (TextAsset)Resources.Load("Dialogs/"+file_path, typeof(TextAsset));
		string content = txt.text;
		sentence = content.Split('\n');
		int i = 0;
		foreach (string s in sentence) {

			//string tmp =  inp_stm.ReadLine();
			//sentence.Add(tmp);
			if(s != ""){
				if(i % 2 == 0){
					if(speaker.ContainsKey(s)){
						speaker[s] = speaker[s] + 1;
					}
					else{
						speaker.Add(s, 1);
					}
				}
				i = i + 1;
			}
		}




		/*
		StreamReader inp_stm = new StreamReader("Assets/Dreammancer/Dialog/" + file_path);
		//Debug.Log (Application.persistentDataPath);
		int i = 0;
		while(!inp_stm.EndOfStream)
		{
			string tmp =  inp_stm.ReadLine();
			sentence.Add(tmp);
			if(i % 2 == 0){
				if(speaker.ContainsKey(sentence[i])){
					speaker[sentence[i]] = speaker[sentence[i]] + 1;
				}
				else{
					speaker.Add(sentence[i], 1);
				}
			}
			i = i + 1;
		}

		inp_stm.Close();
		*/

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.CompareTag("Player"))
		{

			m_StopFlag = true;
			m_image = m_dialog.GetComponent<Image>();
			m_image.enabled = true;
			m_Photo.enabled = true;
			dialog_txt.text = sentence [1];
			cur_speaker = getSpeaker(sentence[0]);
			m_Photo.sprite = speaker_photo[cur_speaker];
			x = 3;
		}
		
	}
	void OnTriggerExit2D(Collider2D other)
	{

		
	}

	private string getSpeaker(string raw){
		string sp;
		sp = raw.Replace ("[","");
		sp = sp.Replace ("]","");
		sp = sp.Substring(0,sp.Length-1);
		return sp;
	}

	private void setPhoto(){
		foreach (string s in speaker.Keys) {
			//Debug.Log(s + "Photo");
			string tmp_speaker = getSpeaker(s);
			//Sprite tmp_sprite = new Sprite();

			string path = "Sprites/"+tmp_speaker;
			//Debug.Log(tmp_speaker[tmp_speaker.Length-1]);
			Sprite tmp_sprite = Resources.Load<Sprite>(path) as Sprite;
			Debug.Log(tmp_sprite);


			speaker_photo[tmp_speaker] = tmp_sprite;
		}

	}
}
