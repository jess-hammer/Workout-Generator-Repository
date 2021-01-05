using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Gradient : MonoBehaviour
{
	public Color toptopLeft;
	public Color toptopRight;
	public Color topbotLeft;
	public Color topbotRight;
	public Color bottopLeft;
	public Color bottopRight;
	public Color botbotLeft;
	public Color botbotRight;
	

	private Image image;

    // Start is called before the first frame update
    void Start()
    {
		
		image = GetComponent<Image> ();


		if (Resources.Load<Texture2D> ("background") == null) {
			image.sprite = CreateNewImage ();
		} else {
			image.sprite = LoadImage ();
		}
    }

	private Sprite CreateNewImage ()
	{
		Texture2D tex = new Texture2D (2, 4);
		tex.SetPixel (0, 0, botbotLeft);
		tex.SetPixel (0, 1, bottopLeft);
		tex.SetPixel (1, 0, botbotRight);
		tex.SetPixel (1, 1, bottopRight);
		tex.SetPixel (0, 2, topbotLeft);
		tex.SetPixel (0, 3, toptopLeft);
		tex.SetPixel (1, 2, topbotRight);
		tex.SetPixel (1, 3, toptopRight);
		tex.wrapMode = TextureWrapMode.Clamp;

		tex.Apply ();

		
		SaveImage (tex);
		return GenerateSpriteFromTex (tex);
	}

	private Sprite LoadImage ()
	{
		Texture2D tex = Resources.Load<Texture2D> ("background");
		return GenerateSpriteFromTex (tex);
	}

	private Sprite GenerateSpriteFromTex(Texture2D tex)
	{
		Sprite sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2 (0.5f, 0.5f));
		return sprite;
	}


	private void SaveImage (Texture2D tex)
	{
		byte [] bytes = tex.EncodeToPNG ();
		var dirPath = Application.dataPath + "/Resources/";
		if (!Directory.Exists (dirPath)) {
			Directory.CreateDirectory (dirPath);
		}
		File.WriteAllBytes (dirPath + "background" + ".png", bytes);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
