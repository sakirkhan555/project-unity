using UnityEngine;
using System.Collections;
using System;                       //used for Enum class

public class CharacterGenerator : MonoBehaviour {

    private PlayerCharacter _toon;
    private const int STARTING_POINTS = 350;
    private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
    private const int STARTING_VALUE = 50;
    private int pointsLeft;

    private const int OFFSET = 5;
    private const int LINE_HEIGHT = 20;

    private const int STAT_LABEL_WIDTH = 100;
    private const int BASE_VALUE_LABEL_WIDTH = 30;
    private const int BUTTON_WIDTH = 20;
    private const int BUTTON_HEIGHT = 20;

    private int statStartingPos = 40;

	// Use this for initialization
	void Start ()
    {
        _toon = new PlayerCharacter();
        _toon.Awake();

        pointsLeft = STARTING_POINTS;

        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            _toon.GetPrimaryAttribute(i).BaseValue = STARTING_VALUE;
            pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
        }

        _toon.StatUpdate();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnGUI()
    {
        DisplayName();
        DisplayPointsLeft();
        DisplayAttributes();
        DisplayVitals();
        DisplaySkills();
    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name");
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
    }

    private void DisplayAttributes()
    {
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            GUI.Label(new Rect(OFFSET, statStartingPos + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((AttributeName)i).ToString());
            GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET, statStartingPos + (i * LINE_HEIGHT), BASE_VALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetPrimaryAttribute(i).AdjustedBaseValue.ToString());
            if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH, statStartingPos + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "-"))
            {
                if (_toon.GetPrimaryAttribute(i).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE)
                {
                    _toon.GetPrimaryAttribute(i).BaseValue--;
                    pointsLeft++;
                    _toon.StatUpdate();
                }
            }
            if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH + BUTTON_WIDTH, statStartingPos + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "+"))
            {
                if (pointsLeft > 0)
                {
                    _toon.GetPrimaryAttribute(i).BaseValue++;
                    pointsLeft--;
                    _toon.StatUpdate();
                }
            }
        }
    }

    private void DisplayVitals()
    {
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            GUI.Label(new Rect(OFFSET, statStartingPos + ((i + 7) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalName)i).ToString());
            GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH, statStartingPos + ((i + 7) * LINE_HEIGHT), BASE_VALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetVital(i).AdjustedBaseValue.ToString());
        }
    }

    private void DisplaySkills()
    {
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2, statStartingPos + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName)i).ToString());
            GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2 + STAT_LABEL_WIDTH, statStartingPos + (i * LINE_HEIGHT), BASE_VALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetSkill(i).AdjustedBaseValue.ToString());
        }
    }

    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft.ToString());
    }
}
