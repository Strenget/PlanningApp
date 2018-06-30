namespace PlanningApp.Properties
{


	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
	internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
	{

		private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

		public static Settings Default
		{
			get
			{
				return defaultInstance;
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("cs-cz")]
		public string Culture
		{
			get
			{
				return ((string)(this["Culture"]));
			}
		}
	}
}
