using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GeometryObjects;

public class GameController : MonoBehaviour {
    public TextAsset textAsset;
    public GameObject objectPrefab;
    public GameObject objectsContainer;
    public Text scoreText;
    public int score;
    // Use this for initialization
    void Start () {
        GetScore();
        Elements elements = Elements.Load(textAsset);
        foreach (Element el in elements.element)
        {
            GameObject tempObjectPanel = Instantiate(objectPrefab);
            tempObjectPanel.transform.SetParent(objectsContainer.transform);
            tempObjectPanel.transform.localScale = Vector3.one;
            tempObjectPanel.transform.localPosition = Vector3.zero;

            tempObjectPanel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + el.name);
            tempObjectPanel.transform.GetChild(1).GetComponent<Text>().text = el.reward.ToString();
            tempObjectPanel.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { SpawnObject(el); });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnObject(Element el)
    {
        GameObject tempGameObject = Instantiate(Resources.Load<GameObject>("Prefabs/" + el.name.Split(' ')[1]));
        tempGameObject.GetComponent<Figure>().name = el.name;
        tempGameObject.GetComponent<Figure>().reward = el.reward;
        tempGameObject.GetComponent<Figure>().SetMaterial();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
    }

    public void GetScore()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        else
        {
            score = 0;
        }
        scoreText.text = score.ToString();
    }
}
