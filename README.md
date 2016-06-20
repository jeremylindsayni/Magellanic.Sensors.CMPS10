# Magellanic.Sensors.CMPS10
This is a C# implementation of code which integrates the CMPS10 tilt compensated compass with Windows 10 IoT Core on the Raspberry Pi 3.

## Getting started
To build this project, you'll need the Magellanic.I2C project also (this is a NuGet package which is referenced in the project, so you may need to restore NuGet packages in your solution).

You should reference the Magellanic.Sensors.CMPS10 in your Visual Studio solution. The CMPS10 can be used with the following sample code from a blank Windows 10 UWP app:

```C#
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
 
        Loaded += MainPage_Loaded;
    }
 
    private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        try
        {
            var compass = new CMPS10();

            await compass.Initialize();

            while (true)
            {
                var compassData = compass.GetCompassData();

                Debug.WriteLine(((float)compassData.BearingAsWord)/10);
                
                Task.Delay(1000).Wait();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
```
