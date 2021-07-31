using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace New_World
{
    class MainViewModel : BaseModel
    {
        public string tbText { get; set; }

        public void Initialisierung()
        {
            Material m = Material.Lesen(2);

            tbText = m.bezeichnung;
            onPropertyChanged(this, "tbText");
        }
    }
}
