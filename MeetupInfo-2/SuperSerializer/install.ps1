param($installPath, $toolsPath, $package, $project)

$readmeFile = $project.ProjectItems.Item("SuperSerializerReadme.txt");

# set 'Copy To Output Directory' to 'Never'
# https://msdn.microsoft.com/en-us/library/vslangproj80.__copytooutputstate.aspx
$readmeFile.Properties.Item("CopyToOutputDirectory").Value = [int]0;

# set 'Build Action' to 'None'
# https://msdn.microsoft.com/en-us/library/aa983962(VS.71).aspx
$readmeFile.Properties.Item("BuildAction").Value = [int]0;