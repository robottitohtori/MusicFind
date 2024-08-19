using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicFind
{
	public struct errorStrings
	{
		public static string settingsFileNotSet = "No settings file set";
		public static string settingsFileNotFound = "Settings file not found";
		public static string settingsFileNotReadable = "Settings file not readable";
		public static string settingsFileNotWritable = "Settings file not writable";
		public static string settingsNotFound = "No settings found";
		public static string settingsParseErrors = "Settings file parse errors";
		public static string settingsAllNotFound = "All settings not found";
		public static string settingsIndexNotSet = "No index location set";
		public static string indexFileNotWritable = "Index file not writable";
		public static string indexFileNotReadable = "Index file not readable";
		public static string indexParseError = "Error parsing index file";
		public static string settingsLoadError = "Error loading settings from";
		public static string settingsSaveError = "Error saving settings to";
		public static string noFileFoundButCreating = "No file found, creating";
		public static string noDirFoundButCreating = "No dir found, creating";
		public static string internalError = "Internal error";


	}

	public struct fileStrings
	{
		public static string patternSettings = @"^(\w+)=(.*)$";
		public static string patternArg = @"^([^,]+),(.*)$";
		public static string patternIndexLine = @"^(\w)(\s*\<[^\<\>]+\>)*$";
		public static char indexSeparator = '|';
		public static string valueSettingsSeparator = "=";
		public static string valueArgSeparator = ",";
		public static string valueTrue = "1";
		public static string valueFalse = "0";
		public static string valueLineTerminator = "\n";
		public static string valueDirSeparator = @"\";
		public static string keywordIndexFileLocation = "indexFileLocation";
		public static string keywordIndexLocation = "indexingLocation";
		//public static string keywordIndexDate = "indexDate";
	}

	public struct searchStrings
	{
		public static string patternKeywordSplit = @"\s+";
		public static string patternFileNameSeparation = @"\\([^\\]+)$";
	}

	public struct helpStrings
	{
		public static string defaultIndexTarget = "Check to include as a default reindex target";
	}
}
