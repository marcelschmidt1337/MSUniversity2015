using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameScreen : MonoBehaviour, IUIScreen 
{

	public UIState StateId { get { return UIState.IngameScreen; } }

	[SerializeField]
	private Text[] PlayerScore;

    public void Activate(UIState OldState)
    {
		this.gameObject.SetActive( true );
        if (OldState != UIState.PauseScreen)
        {
            Application.LoadLevelAdditive("Arena");
        }
	}

	public void Deactivate (System.Action onDone) {
        var animator = this.gameObject.GetComponent<Animator>();
        animator.GetBehaviour<AnimationFinished>().RegisterOnDoneCallBack(() =>
        {
            this.gameObject.SetActive(false);
            onDone();
        });
        animator.Play("HideUI");
	}

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            UIScreenHandler.Instance.ChangeState(UIState.PauseScreen);
        }

		for (int i = 0; i < this.PlayerScore.Length; i++) {
			this.PlayerScore[i].text = GameManager.Instance.player[i].Score.ToString();
		}
    }
}
