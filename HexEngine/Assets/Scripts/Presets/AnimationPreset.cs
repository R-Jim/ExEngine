using System.Collections.Generic;

public class AnimationPreset
{
    public enum Preset
    {
        Placeholder,
        Cannon,
    }


    public class CannonPreset : IPreset
    {
        private readonly Dictionary<string, AnimationTransition> EffectTypeWithAnimation = new Dictionary<string, AnimationTransition>();
        public CannonPreset()
        {
            EffectTypeWithAnimation.Add(SpawnTrigger.TYPE, new AnimationTransition(new string[] { SpawnTrigger.TYPE }, 1, 2));
        }

        public AnimationTransition GetAnimationTransition(string type)
        {
            EffectTypeWithAnimation.TryGetValue(type, out AnimationTransition animationTransition);
            return animationTransition;
        }

    }

    public static AnimationTransition GetAnimationTransition(Preset preset, string type)
    {
        return GetPreset(preset).GetAnimationTransition(type);
    }

    private static IPreset GetPreset(Preset preset)
    {
        switch (preset)
        {
            case Preset.Cannon: return new CannonPreset();
        }
        return null;
    }

    interface IPreset
    {
        AnimationTransition GetAnimationTransition(string type);
    }
}
