using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System;

public class algorithmController : MonoBehaviour{ 
	public int numberOfCubes = 5;
	public int cubeMaxHeight = 10;

	public GameObject[] originalData;
 	public GameObject[] cubes;

	public void InitializeRandom(Slider slider)
	{
		if (transform.childCount > 1)
		{ 
			Array.Clear(cubes, 0, cubes.Length);
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
		}

		
		
		transform.position = new Vector3(0, 0, 0);

		numberOfCubes = Mathf.RoundToInt(slider.value);
		cubes = new GameObject[numberOfCubes];

		for (int i = 0; i < numberOfCubes; i++)
		{
			int randomNumber = UnityEngine.Random.Range(1, cubeMaxHeight + 1);

			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
			cube.transform.position = new Vector3(i, randomNumber / 2.0f, 0);

			cube.transform.SetParent(this.transform);

			cubes[i] = cube;
		}

		transform.position = new Vector3(-numberOfCubes / 2f, -cubeMaxHeight / 2f, 0);
		
	}//randomise the data

	//sorting algorithms
	public IEnumerator SelectionSort(GameObject[] unsortedList)
	{
		print("selection sort starting");

		int min;
		GameObject temp;
		Vector3 tempPosition;

		for (int i = 0; i < unsortedList.Length; i++)
		{
			min = i;
			yield return new WaitForSeconds(1);

			for (int j = 0; j < unsortedList.Length; j++)
			{
				if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y) 
				{
					min = j;
				}
			}

			if(min != i)
			{
				yield return new WaitForSeconds(1);

				temp = unsortedList[i];
				unsortedList[i] = unsortedList[min];
				unsortedList[min] = temp;

				tempPosition = unsortedList[i].transform.localPosition;

				LeanTween.moveLocalX(unsortedList[i], unsortedList[min].transform.localPosition.x, 1);
				LeanTween.moveLocalZ(unsortedList[i], -3, .5f).setLoopPingPong(1);

				LeanTween.moveLocalX(unsortedList[min], tempPosition.x, 1);
				LeanTween.moveLocalZ(unsortedList[min], 3, .5f).setLoopPingPong(1);
			}

			LeanTween.color(unsortedList[i], Color.green, 1f);
		}
	}
	public IEnumerator BubbleSort(GameObject[] unsortedList)
	{
		print("bubble sort starting");

		GameObject temp;
		Vector3 tempPosition;

		for (int i = 0; i < unsortedList.Length - 1; i++)
		{
			yield return new WaitForSeconds(1);

			for (int j = 0; j < unsortedList.Length - 1; j++)
			{
				if (unsortedList[j].transform.localScale.y > unsortedList[j + 1].transform.localScale.y)
				{
					yield return new WaitForSeconds(1);

					temp = unsortedList[j + 1];
					unsortedList[j + 1] = unsortedList[j];
					unsortedList[j] = temp;

					tempPosition = unsortedList[j].transform.localPosition;

					LeanTween.moveLocalX(unsortedList[j], unsortedList[j + 1].transform.localPosition.x, 1);
					LeanTween.moveLocalZ(unsortedList[j], -3, .5f).setLoopPingPong(1);

					LeanTween.moveLocalX(unsortedList[j + 1], tempPosition.x, 1);
					LeanTween.moveLocalZ(unsortedList[j + 1], 3, .5f).setLoopPingPong(1);
				}
			}
		}
		foreach (GameObject item in unsortedList)
		{
			yield return new WaitForSeconds(0.5f);
			LeanTween.color(item, Color.green, 1f);
		}
	}
}
