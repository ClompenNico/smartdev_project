﻿/*
 * using MvvmCross.Plugins.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    //[Preserve(AllMembers = true)]
    public class MvxIosFileStore : IMvxFileStore
    {
        public MvxIosFileStore()
        {
        }

        public const string ResScheme = "res:";

        protected override string AppendPath(string path)
        {
            if (path.StartsWith(ResScheme))
                return path.Substring(ResScheme.Length);

            return base.AppendPath(path);
        }
    }
}
}
*/