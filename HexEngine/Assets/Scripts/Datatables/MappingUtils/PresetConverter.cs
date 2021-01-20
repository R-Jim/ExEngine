using System.Text.RegularExpressions;

public class PresetConverter
{


    static readonly PresetRegex[] Presets = new PresetRegex[]
{
       new PresetRegex("model,placeholder", ModelPreset.Preset.Placeholder),
       new PresetRegex("model,storage", ModelPreset.Preset.Storage),

       new PresetRegex("trigger,placeholder", TriggerPreset.Preset.Placeholder),
       new PresetRegex("trigger,request", TriggerPreset.Preset.Request),
       new PresetRegex("trigger,move", TriggerPreset.Preset.Move),
       new PresetRegex("trigger,chain", TriggerPreset.Preset.Chain),
       new PresetRegex("trigger,collision", TriggerPreset.Preset.Collision),
       new PresetRegex("trigger,spawn", TriggerPreset.Preset.Spawn),
       new PresetRegex("trigger,target", TriggerPreset.Preset.Target),

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
