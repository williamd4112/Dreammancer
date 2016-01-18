using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;


public class DialogController : MonoBehaviour {

	[SerializeField] private string select_diolag;


	private List<string> sentence = new List<string>();

	private int x = 0;
	private GameObject m_dialog;
	private Image m_image;
	private Text dialog_txt;

	// Use this for initialization

	void Awake(){
		m_dialog = GameObject.FindGameObjectWithTag ("Dialog");
		dialog_txt = m_dialog.GetComponentInChildren<Text>();
		dialog_txt.text = "";
	}
	void Start () {
		sentence.Clear ();
		readTextFile ("Assets/Dreammancer/Dialog/" + select_diolag);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (dialog_txt.text);
		if (Input.GetMouseButtonDown (0) && x < sentence.Count && m_image.enabled) {
			dialog_txt.text = sentence [x];
			x = x + 1;
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
		
		while(!inp_stm.EndOfStream)
		{
			sentence.Add(inp_stm.ReadLine());
			// Do Something with the input. 
			Debug.Log(sentence);
		}
		
		inp_stm.Close( );  
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Time.timeScale = 0;
			m_image = m_dialog.GetComponent<Image>();
			m_image.enabled = true;
			dialog_txt.text = sentence [x];
			x = x + 1;
		}
		
	}
	void OnTriggerExit2D(Collider2D other)
	{

		
	}

}
