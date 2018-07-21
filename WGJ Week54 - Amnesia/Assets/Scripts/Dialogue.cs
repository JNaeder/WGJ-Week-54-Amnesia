using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;
	[TextArea(3,10)]
	public string[] sentences;
	public Sprite picture;
	public int sceneToLoad;
	public bool loadsScene;

}
