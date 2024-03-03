using MGQS.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MGQS.EnumTagHelper;

public class EnumTagHelper : TagHelper
{
    public Type? Type { get; set; }
    public Enum? Value { get; set; }



    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (Type == null)
        {
            throw new InvalidOperationException("The type parameter is required");
        }
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "select";
        //foreach (var attribute in context.AllAttributes)
        //{
        //    var specialAttributes = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        //    {
        //        nameof(Type), nameof(Value)
        //    };

        //    if (!specialAttributes.Contains(attribute.Name))
        //    {
        //        output.Attributes.Add(attribute);
        //    }
        //}

        var values = Enum.GetValues(Type).OfType<Enum>();
        output.Content.AppendHtmlLine("<option></option>");
        foreach (var value in values)
        {
            output.Content.AppendHtmlLine(
                Equals(value, Value)
                    ? $@"<option value = ""{value}"" selected = ""selected"">{value.GetDescription()}</option>"
                    : $@"<option value = ""{value}"">{value.GetDescription()}</option>");
        }
    }
}
