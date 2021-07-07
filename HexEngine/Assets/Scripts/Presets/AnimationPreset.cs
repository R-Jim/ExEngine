using System.Collections.Generic;

public class AnimationPreset
{
    public enum Preset
    {
        Cannon,
        Alie,
    }


    public class CannonPreset : IPreset
    {
        public Dictionary<string, int> GetAnimationTransition(string type)
        {
            if (SpawnTrigger.TYPE == type)
            {
                return new Dictionary<string, int>() {
                    {SpawnTrigger.TYPE, 1 }
                };
            }
            return null;
        }

    }

    public static Dictionary<string, int> GetAnimationTransition(Preset preset, string type)
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
        Dictionary<string, int> GetAnimationTransition(string type);
    }
}
