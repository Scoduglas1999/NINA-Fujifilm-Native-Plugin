using System.ComponentModel.Composition;
using System.Windows;

namespace NINA.Plugins.Fujifilm.UI;

/// <summary>
/// Exports the ResourceDictionary containing the Fujifilm lens info DataTemplate.
/// </summary>
[Export(typeof(ResourceDictionary))]
[PartCreationPolicy(CreationPolicy.Shared)]
public partial class LensInfoResources : ResourceDictionary
{
    public LensInfoResources()
    {
        var uri = new System.Uri("/NINA.Plugins.Fujifilm;component/UI/LensInfoResources.xaml", System.UriKind.Relative);
        System.Windows.Application.LoadComponent(this, uri);
    }
}
