﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace xChanger.Core.POC.Brokers.Sheets
{
    public partial class SheetBroker : ISheetBroker, IDisposable
    {
        private readonly IConfiguration configuration;

        public SheetBroker(IConfiguration configuration) =>
            this.configuration = configuration;

        public void Dispose() { }

        private string GetSheetLocationWithName() =>
            this.configuration.GetConnectionString("SheetConnection");

        private FileInfo GetFileInfo() =>
            new FileInfo(fileName: GetSheetLocationWithName());
    }
}
