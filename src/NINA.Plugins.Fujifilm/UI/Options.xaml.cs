using System.ComponentModel.Composition;
using System.Windows;

namespace NINA.Plugins.Fujifilm.UI;

[Export(typeof(ResourceDictionary))]
[PartCreationPolicy(CreationPolicy.Shared)]
public partial class Options : ResourceDictionary
{
    public Options()
    {
        InitializeComponent();
    }
}
