using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCanvasController : MonoBehaviour {

	[SerializeField]
	private Animator m_animator;

	[SerializeField]
	private Text m_scoreText;

	[SerializeField]
	private LevelController m_levelController;

	// Use this for initialization
	void Start () {
		m_animator = GetComponent<Animator>();
	}

	public void CloseStart()
	{
		m_animator.SetTrigger("CloseStart");
		m_levelController.StartGame();
	}
	
	public void ShowGameEnd(float final_score)
	{
		int percent_score = (int)(final_score * 100.0f);

		m_scoreText.text = percent_score.ToString() + " %";
		m_animator.SetTrigger("ShowEnd");
	}

	public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
