using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class uiController : MonoBehaviour{
	public Slider slider;
	public Text text;

	public GameObject prefab;
	[SerializeField]
	GameObject currentSortingCubes;

	public algorithmController AC;

	public Dropdown dropDown;

	[Header("Buttons")]
	public Button start;
	public Button randomise;

	public void Start()
	{
		start.interactable = false;
		randomise.interactable = true;
	} //set buttons to inactive on start

	public void Update()
	{
		if(AC.cubes.Length > 1)
		{
			start.interactable = true;
		}
	}

	public void StartSorting() //starts the sorting
	{
		switch (dropDown.value)
		{
			case 0:
				StartCoroutine(AC.BubbleSort(AC.cubes));
				print("case 0");
				break;
			case 1:
				StartCoroutine(AC.SelectionSort(AC.cubes));
				print("case 1");
				break;
		}
	}

	public void RandomiseData() //randomises the data
	{
		AC.InitializeRandom(slider);
	}

	public void ShowSliderValue()
	{
		text.text = Convert.ToString(Mathf.Round(slider.value));
	}
}
