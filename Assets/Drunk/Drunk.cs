using UnityEngine;
using System.Collections;

public class Drunk : MonoBehaviour 
{
	public Material material;
	
	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material(Shader.Find("Custom/Drunk"));
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination) 
	{
		Graphics.Blit (source, destination, material);
	}
}