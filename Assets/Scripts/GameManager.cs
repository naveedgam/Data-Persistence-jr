using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.IO;

public class GameManager : MonoBehaviour
{


    
    public TMP_InputField playerNameField;
    public TMP_Text tmp_high;

    public int scoreSaver;
    public static GameManager instance;


    private void Awake()
    {
        

        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Loadjosn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    
        public void Loadjosn()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                data aaa = JsonUtility.FromJson<data>(json);
                tmp_high.text = aaa.name + " : " + aaa.score;
                scoreSaver = aaa.score;
            }
        
        }

    public void saveData(string name, int score)
    {
        data aa = new data();

        aa.name = name;
        aa.score = score;


        string json = JsonUtility.ToJson(aa);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);


    }


    public class data
    {
        public string name;
        public int score;
    }
}
