using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace MusicFind
{
    public class settings
    {
		private List<indexingLocation> indexingLocations = new List<indexingLocation>();
		public string indexFileLocation { set; get; }
        public string settingsFileLocation { set; get; }
		public string launchProgram = @"c:\Program Files (x86)\foobar2000\foobar2000.exe";

		// private errorStrings errorStrings;

		public bool hideRootDirectories = false;

        //public DateTime indexDate;
        public uint files;
        public uint dirs;

		public void addIndexingLocation(string newLocation, bool reindexAsDefault)
		{
			indexingLocation loc = new indexingLocation(newLocation, reindexAsDefault);
			indexingLocations.Add(loc);
		}

		public List<indexingLocation> getIndexingLocations()
		{
			return indexingLocations;
		}

        //true=success
        public bool loadSettings(out List<string> errors)
        {
            indexFileLocation = "";
            indexingLocations.Clear();
            errors = new List<string>();
            // check?
            if (settingsFileLocation != null)
            {
                try
                {
                    List<string> settingLines = File.ReadAllLines(settingsFileLocation).ToList();
                    if (settingLines.Count == 0)
                    {
						errors.Add(errorStrings.settingsNotFound);
                        return false;
                    }
                    if (!parseSettings(settingLines))
                    {
                        errors.Add(errorStrings.settingsParseErrors);
                    }
                    if (indexFileLocation != "" && indexingLocations.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        errors.Add(errorStrings.settingsAllNotFound);
                    }
                }
                catch (DirectoryNotFoundException)
                {
					errors.Add(errorStrings.settingsFileNotFound);
                }
                catch (FileNotFoundException)
                {
					errors.Add(errorStrings.settingsFileNotFound);
                }
                catch (FileLoadException)
                {
					errors.Add(errorStrings.settingsFileNotReadable);
                }


            }
            else
            {
                // you shouldn't be here
				errors.Add(errorStrings.settingsFileNotSet);
            }
            return false;
        }

        //true=success
        private bool parseSettings(List<string> settingLines)
        {

            //better signaling..?

            //string pattern = "^(\\w+)=(.*)$";
			//string argPattern = "^([^,]+),(.*)$";
            bool everythingSucceeded = true;
            foreach (string line in settingLines)
            {

				Match reg = Regex.Match(line, fileStrings.patternSettings);
                if (reg.Success)
                {
                    if (reg.Groups[1].Value == fileStrings.keywordIndexLocation)
                    {
						
                        // TODO check location validity!
						Match arg = Regex.Match(reg.Groups[2].Value, fileStrings.patternArg);
						if (arg.Success)
						{
							addIndexingLocation(arg.Groups[2].Value, arg.Groups[1].Value.Equals("1"));
						}
						else
						{
							everythingSucceeded = false;
						}
                    }

					else if (reg.Groups[1].Value == fileStrings.keywordIndexFileLocation)
					{
						// TODO check location validity!
						indexFileLocation = reg.Groups[2].Value;
					}

					/*else if (reg.Groups[1].Value == fileStrings.keywordIndexDate)
					{
						if (!DateTime.TryParse(reg.Groups[2].Value, out indexDate))
						{
							everythingSucceeded = false;
						}
					}*/
					else
					{
						// keyword not found, ignore
						everythingSucceeded = false;
                    }
                }
                else
                {
					// malformed settings line, ignore
                    everythingSucceeded = false;
                }
            }
            return everythingSucceeded;
        }

        // true=success
        public bool saveSettings(out List<string> errors)
        {
            errors = new List<string>();
            bool everythingSuccesful = false;
            if (settingsFileLocation == "" || settingsFileLocation == null)
            {
				errors.Add(errorStrings.settingsFileNotSet);
                return false;
            }

			FileInfo info = new FileInfo(settingsFileLocation);
			if (!info.Exists)
			{
				errors.Add(errorStrings.noFileFoundButCreating);
				DirectoryInfo dinfo = info.Directory;
				if (!dinfo.Exists)
				{
					errors.Add(errorStrings.noDirFoundButCreating);
					dinfo.Create();
				}
			}

 
            try
            {
                using (StreamWriter sr = new StreamWriter(settingsFileLocation))
                {
                    sr.Write(fileStrings.keywordIndexFileLocation + fileStrings.valueSettingsSeparator + indexFileLocation + fileStrings.valueLineTerminator);
                    foreach (indexingLocation loc in indexingLocations)
                    {
						sr.Write(fileStrings.keywordIndexLocation + fileStrings.valueSettingsSeparator + ((loc.reindexAsDefault) ? fileStrings.valueTrue : fileStrings.valueFalse) + fileStrings.valueArgSeparator + loc.location + fileStrings.valueLineTerminator);
                    }

                    everythingSuccesful = true;
                }
            }
            catch (Exception)
            {
				// separate catches?
				errors.Add(errorStrings.settingsFileNotWritable);
            }

            return everythingSuccesful;
        }
    }

}
