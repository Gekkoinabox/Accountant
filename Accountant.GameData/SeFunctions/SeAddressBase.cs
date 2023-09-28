﻿using System;
using Dalamud.Game;
using Dalamud.Plugin.Services;

namespace Accountant.SeFunctions;

public class SeAddressBase
{
    public readonly IntPtr Address;

    public SeAddressBase(IPluginLog log, ISigScanner sigScanner, string signature, int offset = 0)
    {
        Address = sigScanner.GetStaticAddressFromSig(signature);
        if (Address != IntPtr.Zero)
            Address += offset;
        var baseOffset = (ulong)Address.ToInt64() - (ulong)sigScanner.Module.BaseAddress.ToInt64();
        log.Debug($"{GetType().Name} address 0x{Address.ToInt64():X16}, baseOffset 0x{baseOffset:X16}.");
    }
}
