using sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sales.Infrastructure
{
    public class IntanceLocator
    {
        public MainViewModel Main { get; set; }

        public IntanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
