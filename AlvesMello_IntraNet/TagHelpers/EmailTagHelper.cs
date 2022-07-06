using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AlvesMello_IntraNet.TagHelpers
{
	public class EmailTagHelper : TagHelper
	{
		public string Email { get; set; }
		public string Content { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";
			output.Attributes.SetAttribute("href", "mailto:" + Email);
			output.Content.SetContent(Content);
		}
	}
}
