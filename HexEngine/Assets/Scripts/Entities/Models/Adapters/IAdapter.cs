using System.Text.RegularExpressions;

interface IAdapter
{
    Regex GetTypeRegex();

    string buildTypeValue(object value);

    object Process(object input, Model model);

    string[] GetTypes(Model model);
}
