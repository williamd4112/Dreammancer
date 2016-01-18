using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;


public class DialogController : MonoBehaviour {

	[SerializeField] private string select_diolag;


	private List<string> sentence = new List<string>();

	private Dictionary<string, int> speaker = new Dictionary<string, int>();
	private int x = 0;
	private GameObject m_dialog;
	private Image m_image;
	private Text dialog_txt;
	private string cur_speaker;
	// Use this for initialization

	void Awake(){
		m_dialog = GameObject.FindGameObjectWithTag ("Dialog");
		dialog_txt = m_dialog.GetComponentInChildren<Text>();
		dialog_txt.text = "";
		cur_speaker = "";
	}
	void Start () {
		sentence.Clear ();
		readTextFile ("Assets/Dreammancer/Dialog/" + select_diolag);
		setPhoto ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (dialog_txt.text);
		if (Input.GetMouseButtonDown (0) && x < sentence.Count && m_image.enabled) {
			cur_speaker = getSpeaker(sentence[x-1]);
			dialog_txt.text = sentence [x];
			x = x + 2;
			if(x >= sentence.Count){
				dialog_txt.text = "";
				m_image.enabled = false;
				Time.timeScale = 1;
				Destroy (gameObject);
			}
		}
	}
	
	void FixedUpdate(){
		
	}
	
	void readTextFile(string file_path)
	{
		StreamReader inp_stm = new StreamReader(file_path);
		int i = 0;
		while(!inp_stm.EndOfStream)
		{
			sentence.Add(inp_stm.ReadLine());
			if(i % 2 == 0 && sentence[i] != " "){
				if(speaker.ContainsKey(sentence[i])){
					speaker[sentence[i]] = speaker[sentence[i]] + 1;
				}
				else{
					speaker.Add(sentence[i], 1);
				}
			}
			i = i + 1;
		}
		Debug.Log (speaker.Count + 100);
		inp_stm.Close();  
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Time.timeScale = 0;
			m_image = m_dialog.GetComponent<Image>();
			m_image.enabled = true;
			dialog_txt.text = sentence [1];
			cur_speaker = getSpeaker(sentence[0]);
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
		return sp;
	}

	private void setPhoto(){


	}
}
