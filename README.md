# Nyan Cat Test Reporter for Visual Studio

A 'diagnostic data adapter'
that makes Nyan Cat fly across your screen
whilst your tests are running :3

## Building and Installation
* Run Visual Studio as Administrator preferably.
* Build project.

 If you're administrator, the post build script should copy the files:
 * `NyanCatReporterDataCollector\bin\Release\NyanCatReporterDataCollector.dll`
 * `NyanCatReporterDataCollector\bin\Release\WpfControlLibrary1.dll`

 into `%PROGRAMFILES(X86)%\Microsoft Visual Studio 14.0\Common7\IDE\PrivateAssemblies\DataCollectors\`.
 Otherwise you'll have to do it yourself.

### Configuring your test project
* Add a `.runsettings` file to your test project, if you don't already have one.
 * See `UnitTestProject1\.runsettings` as an example. You just need the `DataCollector` element with the friendlyName, uri, and assemblyQualifiedName attributes set.
* Open your test project in VS.
* From the menu, select **Test** > **Test Settings** > **Select Test Settings File**
* Choose the `.runsettings` file and click **Open**.

## Known issues
 * Can't run tests twice in a row. Output says:
```
Data collection will be stopped for current test run. WCF Communication channel with DataCollection service is unavailable.
```
