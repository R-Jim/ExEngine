using System.Collections.Generic;
using UnityEngine;

public class AnimationGameObject : MonoBehaviour
{
    private readonly AnimationSet AnimationSet = new AnimationSet(GetDefaultAnimationSet());
    public Model Model;
    public AnimationPreset.Preset AnimationPresetType;
    private int LastTick = 0;

    // Update is called once per frame
    void Update()
    {
        if (Model == null)
        {
            return;
        }
        UpdateNewAnimation();
        UpdateAnimator();
        SystemTickAnimationHandler();
    }

    private void SystemTickAnimationHandler()
    {
        int systemTick = SystemProperties.SystemProfile.SystemTick;
        if (LastTick != systemTick)
        {
            AnimationSet.Tick();
            LastTick = systemTick;
        }
    }

    private void UpdateNewAnimation()
    {
        if (Model.SourceExecutedEffect.Count > 0)
        {
            Effect effect = Model.SourceExecutedEffect.Dequeue();
            AnimationTransition animationTransition = AnimationPreset.GetAnimationTransition(AnimationPresetType, effect.Trigger.Type);
            AnimationSet.Add(animationTransition);
        }
    }

    private void UpdateAnimator()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        foreach(string tag in AnimationSet.GetTags())
        {
            animator.SetInteger(tag, AnimationSet.GetValue(tag));
        }
    }

    private static Dictionary<string, int> GetDefaultAnimationSet()
    {
        Dictionary<string, int> defaultSet = new Dictionary<string, int>
        {
            { SpawnTrigger.TYPE, 0 } //firing
        };

        return defaultSet;
    }
}
