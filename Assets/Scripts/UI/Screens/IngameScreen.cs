using UnityEngine;
using System.Collections;

public class IngameScreen : MonoBehaviour, IUIScreen 
{

	public UIState StateId { get { return UIState.IngameScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
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
    }
}
