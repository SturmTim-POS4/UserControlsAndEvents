using System;

namespace TrackControl;

public class ValueChangeEventArg : EventArgs
{
    public int newValue { get; set; }

    public int oldValue { get; set; }
}