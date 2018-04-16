using UnityEngine;
using System.Collections;

public class Drunk : MonoBehaviour 
{
	public Material material;
    float time;
    float TimeEvolution;
    float min;
    float sec;
    float value1;

    float alcool_ingere;

    float alcool_actif;

    float max_alcool_ingere;
	
	// Creates a private material used to the effect
	void Awake ()
	{
        TimeEvolution = 60f;

        alcool_ingere = Mathf.Clamp(AlcoolQuantity.alcool_quantity,0,max_alcool_ingere);

        time = 0f;

		material = new Material(Shader.Find("Custom/Drunk"));

        max_alcool_ingere = 6f;
	}

    void CalculateShaderValue()
    {
        alcool_actif = (alcool_ingere * min) / 30;
        if (alcool_actif < alcool_ingere)
        {
            material.SetFloat("_OffsetFactor", (alcool_actif / max_alcool_ingere) * 0.05f);
            material.SetFloat("_DisplacementFactor", (alcool_actif / max_alcool_ingere) * 0.1f);

           // Debug.LogError(material.GetFloat("_OffsetFactor") + "   " + material.GetFloat("_DisplacementFactor"));
        }
    }

	void OnRenderImage (RenderTexture source, RenderTexture destination) 
	{
		Graphics.Blit (source, destination, material);
	}

    void AdaptTime()
    {
        min = Mathf.Floor(time/60);
        sec = Mathf.RoundToInt(time % 60);
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime*TimeEvolution;
        AdaptTime();
        //Debug.LogError("Time : " + min +":"+sec);
        CalculateShaderValue();
    }
}