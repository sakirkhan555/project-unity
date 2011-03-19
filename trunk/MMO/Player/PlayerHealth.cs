using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int MaxHealth = 100;
    public int CurHealth = 100;

    private float healthBarLength;

	// Use this for initialization
	void Start ()
    {
        healthBarLength = Screen.width / 4;
	}
	
	// Update is called once per frame
	void Update ()
    {
        AdjustCurrentHealth(0);
	}

    public void AdjustCurrentHealth(int adj)
    {
        CurHealth += adj;

        // Divide by zero checks

        if (CurHealth < 0)
            CurHealth = 0;

        if (CurHealth > MaxHealth)
            CurHealth = MaxHealth;

        if (MaxHealth < 1)
            MaxHealth = 1;

        healthBarLength = (Screen.width / 4) * (CurHealth / (float)MaxHealth);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 30, healthBarLength, 20), CurHealth + "/" + MaxHealth);
    }
}
