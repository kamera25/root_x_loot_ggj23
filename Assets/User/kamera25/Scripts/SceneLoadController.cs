using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneLoadController : MonoBehaviour 
{
	public string scene;

	private void Update()
	{
		var _keyboard = Keyboard.current;
		if( _keyboard.enterKey.wasPressedThisFrame )
		{
			GoToScene();
		}
	}

	public void GoToScene()
	{
		SceneManager.LoadScene ( scene );
	}
}
