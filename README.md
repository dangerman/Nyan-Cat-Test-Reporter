# Nyan Cat Test Reporter for Visual Studio

A 'diagnostic data adapter'
that makes Nyan Cat fly across your screen
whilst your tests are running :3

![NyanCat](nyancat_running.gif)

## 🔨 Building and Installation
* Run Visual Studio as Administrator, if possible.
* Build solution.

 If you're Administrator, the post build script should copy the files:
 * `NyanCatReporterDataCollector.dll`
 * `NyanCatDisplay.dll`
 * `WpfAnimatedGif.dll`

 into `%PROGRAMFILES(X86)%\Microsoft Visual Studio 14.0\Common7\IDE\PrivateAssemblies\DataCollectors\`.
 Otherwise you'll have to do it yourself.

* Create a new `.runsettings` file, and select it in VS.
  * See `UnitTestProject1\.runsettings` as an example. You just need the `DataCollector` element with the friendlyName, uri, and assemblyQualifiedName attributes set.
 * Open your test project in VS.
 * From the menu, select **Test** > **Test Settings** > **Select Test Settings File**
 * Choose the `.runsettings` file and click **Open**.


### ⚙ Configuring your test project

* In a Test Class, add an AssemblyCleanup method like `CloseTestDiscoveryEngine()` from from the example project into your TestClass.
  * This is a workaround for a problem where you can't use Nyan Cat twice in a row.

## 🐛 Known issues
* If you're running tests in multiple projects, Nyan Cat will only show up once.
  * This is because it doesn't relaunch after TestDiscoveryEngine is closed in the AssemblyCleanup.

## TODO
* Add configuration editor option to set speed (in nyanometers per second).
