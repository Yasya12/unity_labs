using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
	[SerializeField] private CollectableObject interactablePrefab;
	[SerializeField] private Transform collector;
	[SerializeField] private AudioSource collectionSoundEffectt;
    [SerializeField] private AudioSource deathSoundEffectt;
	[SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI lostText;

    private readonly float delay = 0.5f;
	private float timer = 0f;
	private int result = 0;
	private int missedObjects = 0;

    private void Start()
    {
		LoadFromJson();
    }

    void Update()
	{
		timer += Time.deltaTime/2;
		if (timer >= delay)
		{
			timer = 0f;
			var x = Random.Range(-3f, 3f);
			var y = Random.Range(1f, 3f); 

			var position = new Vector2(x, y); 


			var clickable = Instantiate(interactablePrefab, position, Quaternion.identity);
			clickable.Initialize(OnCollectObject, OnMissedObject);
		}
	}

	private void OnCollectObject()
	{
        collectionSoundEffectt.Play();
        result++;
		countText.text = "Count: " + result;
        SaveToJson();
        //Debug.Log(result);
    }

	private void OnMissedObject()
	{
		missedObjects++;
        lostText.text = "Lost: " + missedObjects;
        SaveToJson();

        if (missedObjects > 10)
		{
			deathSoundEffectt.Play();
			result = 0;
			missedObjects = 0;
			SaveToJson();
            Debug.Log("End of Game!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Debug.Log("Start again!");
		}
	}

	public void SaveToJson()
	{
		Data data = new Data();
		data.Count = result;
		data.Lost = missedObjects;

		string json = JsonUtility.ToJson(data, true);
        // Specify the file path separately from the json data
        string filePath = Application.dataPath + "/DataFile.json";

        File.WriteAllText(filePath, json);

        Debug.Log("File created: " + filePath);
    }

	public void LoadFromJson()
	{
        string filePath = Application.dataPath + "/DataFile.json";
        Debug.Log( filePath);
        if (File.Exists(filePath))
        {
            Debug.Log("yesssssss: " + filePath);
            string json = File.ReadAllText(filePath);
            Data data = JsonUtility.FromJson<Data>(json);

            result = data.Count;
            missedObjects = data.Lost;
            Debug.Log(data.Count);
            countText.text = "Count: " + result;
            lostText.text = "Lost: " + missedObjects;
        }
        else
        {
            Debug.LogWarning("File does not exist: " + filePath);
        }
    }
}
