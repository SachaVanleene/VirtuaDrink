using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public Text time_ui;
	
	// Creates a private material used to the effect
	void Awake ()
	{
        TimeEvolution = 60f;

        max_alcool_ingere = 6f;

        alcool_ingere = Mathf.Clamp(AlcoolQuantity.alcool_quantity,0,max_alcool_ingere);

        Debug.LogError("alcool_ingere"+alcool_ingere);

        time = 0f;

		material = new Material(Shader.Find("Custom/Drunk"));

	}

    void CalculateShaderValue()
    {
        alcool_actif = (alcool_ingere * min) / 30;
        if (alcool_actif < alcool_ingere)
        {
            material.SetFloat("_OffsetFactor", (alcool_actif / max_alcool_ingere) * 0.05f);
            material.SetFloat("_DisplacementFactor", (alcool_actif / max_alcool_ingere) * 0.1f);

            //Debug.LogError(material.GetFloat("_OffsetFactor") + "   " + material.GetFloat("_DisplacementFactor"));
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

        if(min < 10)
        {
            time_ui.text = "Temps depuis l'ingestion d'alcool : 0" + min + ":" + sec;
        } else
        {
            if(min < 30)
            {
                time_ui.text = "Temps depuis l'ingestion d'alcool : " + min + ":" + sec;
            }
            else
            {
                time_ui.text = "30 minutes se sont écoulés depuis l'ingestion, taux d'alcool dans le sang : " + alcool_ingere + " g/cl";
            }

        }
        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime*TimeEvolution;
        AdaptTime();
        //Debug.LogError("Time : " + min +":"+sec);
        CalculateShaderValue();
    }
}