using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
	[SerializeField] private CollectableObject interactablePrefab;
	[SerializeField] private Transform collector;
	[SerializeField] private AudioSource collectionSoundEffectt;
    [SerializeField] private AudioSource deathSoundEffectt;

    private readonly float delay = 0.5f;
	private float timer = 0f;
	private int result = 0;
	private int missedObjects = 0;

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
		Debug.Log(result);
	}

	private void OnMissedObject()
	{
		missedObjects++;

		if (missedObjects > 10)
		{
			deathSoundEffectt.Play();
            Debug.Log("End of Game!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Debug.Log("Start again!");
		}
	}
}
