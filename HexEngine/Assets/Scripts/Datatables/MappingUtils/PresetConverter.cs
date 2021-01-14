using System.Text.RegularExpressions;

public class PresetConverter
{


    static readonly PresetRegex[] Presets = new PresetRegex[]
{
       new PresetRegex("model,storage", ModelPreset.Preset.Storage),
       new PresetRegex("effect,request", EffectPreset.Preset.Request),
       new PresetRegex("effect,move", EffectPreset.Preset.Move),
       new PresetRegex("effect,chain", EffectPreset.Preset.Chain),
       new PresetRegex("effect,collision", EffectPreset.Preset.Collision),
       new PresetRegex("effect,spawn", EffectPreset.Preset.Spawn),
};

    public static object GetPreset(string preset)
    {
        foreach (PresetRegex presetRegex in Presets)
        {
            if (presetRegex.Regex.IsMatch(preset))
            {
                return presetRegex.Preset;
            }
        }
        return null;
    }

    class PresetRegex
    {
        public Regex Regex;
        public object Preset;

        public PresetRegex(string regex, object preset)
        {
            Regex = new Regex(regex);
            Preset = preset;
        }
    }
}
