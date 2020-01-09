using UnityEngine;
using System.Collections;

public static class SA_TextureExtensions  {
	public static Sprite ToSprite(this Texture texture) {
		return Sprite.Create(texture as Texture2D, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f)); 
	}
}
